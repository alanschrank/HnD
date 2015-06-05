/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using SD.HnD.BL.TypedDataClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.SelfServicing;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.TypedListClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.DaoClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Forum Gui
	/// </summary>
	public class ForumGuiHelper
    {
		/// <summary>
		/// Returns a TypedList which contains the last (amount) posted messages in
		/// the forum given. For RSS production.
		/// </summary>
		/// <param name="amount">limit of amount of messages to return</param>
		/// <param name="forumID">ID of forum to pull the messages for</param>
		/// <returns>typed list with data requested</returns>
		public static List<ForumMessagesRow> GetLastPostedMessagesInForum(int amount, int forumID)
		{
			var qf = new QueryFactory();
			var q = qf.GetForumMessagesTypedList()
						  .Where((ForumFields.ForumID == forumID).And(ForumFields.HasRSSFeed == true))
						  .OrderBy(MessageFields.PostingDate.Descending())
						  .Limit(amount);
			return new TypedListDAO().FetchQuery(q);
		}

		
		/// <summary>
		/// Returns a list with aggregated data objects, one per thread, for the requested forum and page
		/// </summary>
		/// <param name="forumID">ID of Forum for which the Threadlist is required</param>
		/// <param name="pageNumber">The page number to fetch, which is used to fetch non-sticky posts</param>
		/// <param name="pageSize">The number of rows to fetch for the page. </param>
		/// <param name="canViewNormalThreadsStartedByOthers">If set to true, the user calling the method has the right to view threads started by others.
		/// Otherwise only the threads started by the user calling the method are returned.</param>
		/// <param name="userID">The userid of the user calling the method.</param>
		/// <returns>List with all the thread info, aggregated. Sticky threads are sorted to the top.</returns>
		public static List<AggregatedThreadRow> GetAllThreadsInForumAggregatedData(int forumID, int pageNumber, int pageSize, bool canViewNormalThreadsStartedByOthers, int userID)
		{
			// create a query which always fetches the sticky threads, and besides those the threads which are visible to the user. 
			// then sort the sticky threads at the top and page through the resultset.
			var qf = new QueryFactory();
			var q = qf.Create()
						  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf))
						  .Where(ThreadFields.ForumID == forumID)
						  .OrderBy(ThreadFields.IsSticky.Descending(), ThreadFields.ThreadLastPostingDate.Descending())
						  .Select(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStats(qf))
						  .Distinct()
						  .Offset(pageSize * (pageNumber-1))		// skip the pages we don't need.
						  .Limit(pageSize+1);						// fetch 1 row extra, which we can use to determine whether there are more pages left.

			// if the user can't view threads started by others, filter out threads started by users different from userID. Otherwise just filter on forumid and stickyness.
			if(!canViewNormalThreadsStartedByOthers)
			{
				// caller can't view threads started by others: add a filter so that threads not started by calling user aren't enlisted. 
				// however sticky threads are always returned so the filter contains a check so the limit is only applied on threads which aren't sticky
				// add a filter for sticky threads, add it with 'OR', so sticky threads are always accepted. The whole expression is and-ed to the already existing
				// expression
				q.AndWhere((ThreadFields.StartedByUserID == userID).Or(ThreadFields.IsSticky == true));
			}
			var dao = new TypedListDAO();
			return dao.FetchQuery(q);
		}


		/// <summary>
		/// Gets all forum data with section name in a typedlist. Sorted on Section.OrderNo, Section.SectionName, Forum.OrderNo, Forum.ForumName.
		/// </summary>
		/// <returns>Filled typedlist with all forum names / forumIDs and their containing section's name, sorted on Sectionname, and then forumname</returns>
		public static List<ForumsWithSectionNameRow> GetAllForumsWithSectionNames()
		{
			var qf = new QueryFactory();
			var q = qf.GetForumsWithSectionNameTypedList()
							.OrderBy(SectionFields.OrderNo.Ascending(), SectionFields.SectionName.Ascending(), ForumFields.OrderNo.Ascending(), ForumFields.ForumName.Ascending());
			return new TypedListDAO().FetchQuery(q);
		}


		/// <summary>
		/// Gets all forum entities which belong to a given section. 
		/// </summary>
		/// <param name="sectionID">The section ID from which forums should be retrieved</param>
		/// <returns>Entity collection with entities for all forums in this section sorted alphabitacally</returns>
		public static ForumCollection GetAllForumsInSection(int sectionID)
		{
			var q = new QueryFactory().Forum
						.Where(ForumFields.SectionID == sectionID)
						.OrderBy(ForumFields.OrderNo.Ascending(), ForumFields.ForumName.Ascending());
			var toReturn = new ForumCollection();
			toReturn.GetMulti(q);
			return toReturn;
		}


		/// <summary>
		/// Retrieves for all available sections all forums with all relevant statistical information. This information is stored per forum in an
		/// AggregatedForumRow instance. The forum instances are indexed under their sectionid. Only forums which are vieable by the user are returned. 
		/// </summary>
		/// <param name="availableSections">SectionCollection with all available sections</param>
		/// <param name="accessableForums">List of accessable forums IDs.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>
		/// MultiValueHashtable with per key (sectionID) a set of AggregatedForumRow instance, one row per forum in the section. If a section contains no forums displayable to the
		/// user it's not present in the returned hashtable.
		/// </returns>
        public static MultiValueHashtable<int, AggregatedForumRow> GetAllAvailableForumsAggregatedData(SectionCollection availableSections, List<int> accessableForums,
																			   List<int> forumsWithThreadsFromOthers, int userID)
        {
			var toReturn = new MultiValueHashtable<int, AggregatedForumRow>();

            // return an empty list, if the user does not have a valid list of forums to access
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return toReturn;
            }

			// fetch all forums with statistics in a dynamic list, while filtering on the list of accessable forums for this user. 
			// Create the filter separate of the query itself, as it's re-used multiple times. 
			IPredicateExpression threadFilter = ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userID);

			var qf = new QueryFactory();
			var q = qf.Create()
						.Select(() => new AggregatedForumRow()
									  {
										ForumID = ForumFields.ForumID.ToValue<int>(), 
										ForumName = ForumFields.ForumName.ToValue<string>(), 
										ForumDescription = ForumFields.ForumDescription.ToValue<string>(), 
										ForumLastPostingDate = ForumFields.ForumLastPostingDate.ToValue<DateTime?>(),
										// add a scalar query which retrieves the # of threads in the specific forum. 
										// this will result in the query:
										// (
										//		SELECT COUNT(ThreadID) FROM Thread 
										//		WHERE ForumID = Forum.ForumID AND threadfilter. 
										// ) As AmountThreads
										AmountThreads = qf.Create()
															.Select(ThreadFields.ThreadID.Count())
															.CorrelatedOver(ThreadFields.ForumID == ForumFields.ForumID)
															.Where(threadFilter)
															.ToScalar().As("AmountThreads").ToValue<int>(),
										// add a scalar query which retrieves the # of messages in the threads of this forum. 
										// this will result in the query:
										// (
										//		SELECT COUNT(MessageID) FROM Message 
										//		WHERE ThreadID IN
										//		(
										//			SELECT ThreadID FROM Thread WHERE ForumID = Forum.ForumID AND threadfilter
										//		)
										// ) AS AmountMessages
							 			AmountMessages = qf.Create()
												.Select(MessageFields.MessageID.Count())
												.Where(MessageFields.ThreadID.In(
														qf.Create()
															.Select(ThreadFields.ThreadID)
															.CorrelatedOver(ThreadFields.ForumID == ForumFields.ForumID)
															.Where(threadFilter)))
												.ToScalar().As("AmountMessages").ToValue<int>(),
										HasRSSFeed = ForumFields.HasRSSFeed.ToValue<bool>(), 
										SectionID = ForumFields.SectionID.ToValue<int>()
									})
						.Where(ForumFields.ForumID == accessableForums)
						.OrderBy(ForumFields.OrderNo.Ascending(), ForumFields.ForumName.Ascending());

			var results = new TypedListDAO().FetchQuery(q);

			foreach(var forum in results)
			{
				toReturn.Add(forum.SectionID, forum);
			}
            return toReturn;
        }


		/// <summary>
		/// Returns a ForumEntity of the given forum
		/// </summary>
		/// <param name="forumID">ForumID of forum which data should be read</param>
		/// <returns>forum entity with the data requested, or null if not found</returns>
		public static ForumEntity GetForum(int forumID)
		{
			ForumEntity toReturn = new ForumEntity(forumID);
			if(toReturn.Fields.State!=EntityState.Fetched)
			{
				return null;
			}
			return toReturn;
		}
	}
}
