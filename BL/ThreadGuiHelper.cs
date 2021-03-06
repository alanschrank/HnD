/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
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
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SD.HnD.BL.TypedDataClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter;
using SD.HnD.DALAdapter.DatabaseSpecific;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.Linq;
using SD.HnD.DTOs.DtoClasses;
using SD.HnD.DTOs.Persistence;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Thread Gui
	/// </summary>
	public static class ThreadGuiHelper
	{
		/// <summary>
		/// Gets the thread.
		/// </summary>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>Thread object or null if not found</returns>
		public static async Task<ThreadEntity> GetThreadAsync(int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var q = new QueryFactory().Thread.Where(ThreadFields.ThreadID.Equal(threadId));
				var toReturn = await adapter.FetchFirstAsync(q).ConfigureAwait(false);
				return toReturn;
			}
		}


		/// <summary>
		/// Gets the thread subscription object for the thread - user combination passed in. If there's no subscription, null is returned.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userId">The user ID.</param>
		/// <returns>requested Threadsubscription entity or null if not found</returns>
		public static Task<ThreadSubscriptionEntity> GetThreadSubscriptionAsync(int threadId, int userId)
		{
			return GetThreadSubscriptionAsync(threadId, userId, null);
		}


		/// <summary>
		/// Gets the thread subscription object for the thread - user combination passed in. If there's no subscription, null is returned.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="userId">The user ID.</param>
		/// <param name="adapter">The live adapter with an active transaction. Can be null, in which case a local adapter is used.</param>
		/// <returns>
		/// requested Threadsubscription entity or null if not found
		/// </returns>
		public static async Task<ThreadSubscriptionEntity> GetThreadSubscriptionAsync(int threadId, int userId, IDataAccessAdapter adapter)
		{
			var localAdapter = adapter == null;
			var adapterToUse = adapter ?? new DataAccessAdapter();
			try
			{
				var q = new QueryFactory().ThreadSubscription.Where(ThreadSubscriptionFields.ThreadID.Equal(threadId)
																							.And(ThreadSubscriptionFields.UserID.Equal(userId)));
				return await adapterToUse.FetchFirstAsync(q).ConfigureAwait(false);
			}
			finally
			{
				if(localAdapter)
				{
					adapterToUse.Dispose();
				}
			}
		}


		/// <summary>
		/// Gets the total number of messages in thread.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <returns></returns>
		public static async Task<int> GetTotalNumberOfMessagesInThreadAsync(int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchScalarAsync<int>(new QueryFactory().Message
																			 .Where(MessageFields.ThreadID.Equal(threadId))
																			 .Select(Functions.CountRow()))
									.ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the active threads visible to the user.
		/// </summary>
		/// <param name="accessableForums">A list of accessable forums IDs, which the user has permission to access.</param>
		/// <param name="hoursThreshold">The hours threshold for the query to fetch the active threads. All threads within this threshold's period of time (in hours)
		/// are fetched.</param>
		/// <param name="forumsWithThreadsFromOthers">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userId">The userid of the calling user.</param>
		/// <returns>a list with objects representing the Active threads</returns>
		public static async Task<List<AggregatedThreadRow>> GetActiveThreadsAggregatedData(List<int> accessableForums, short hoursThreshold,
																						   List<int> forumsWithThreadsFromOthers, int userId)
		{
			if(accessableForums == null || accessableForums.Count <= 0)
			{
				return null;
			}

			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select<AggregatedThreadRow>(ThreadGuiHelper.BuildQueryProjectionForAllThreadsWithStatsWithForumName(qf).ToArray())
					  .From(ThreadGuiHelper.BuildFromClauseForAllThreadsWithStats(qf)
										   .InnerJoin(qf.Forum).On(ThreadFields.ForumID.Equal(ForumFields.ForumID)))
					  .Where(ThreadFields.ForumID.In(accessableForums)
										 .And(ThreadFields.IsClosed.Equal(false))
										 .And(ThreadFields.MarkedAsDone.Equal(false))
										 .And(MessageFields.PostingDate.Source("LastMessage").GreaterEqual(DateTime.Now.AddHours((double)0 - hoursThreshold)))
										 .And(ThreadGuiHelper.CreateThreadFilter(forumsWithThreadsFromOthers, userId)))
					  .OrderBy(MessageFields.PostingDate.Source("LastMessage").Ascending());
			using(var adapter = new DataAccessAdapter())
			{
				return await adapter.FetchQueryAsync(q).ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Gets the dto of the last message in the thread, which contains all information to render a message pane, which can be used to
		/// show the last message in a thread one is replying to. 
		/// </summary>
		/// <param name="threadId">Thread ID.</param>
		/// <returns>fetched messageentity with the userentity + usertitle entity fetched as well of the user who posted the message.</returns>
		public static async Task<MessageInThreadDto> GetLastMessageInThreadDtoAsync(int threadId)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				var q = metaData.Message
								.Where(m => m.ThreadID == threadId)
								.OrderByDescending(m => m.PostingDate);
				return await q.ProjectToMessageInThreadDto().FirstOrDefaultAsync().ConfigureAwait(false);
			}
		}


		/// <summary>
		/// Constructs a list of hierarchical DTOs with all message data for a page. This is a list of DTOs as the attachments information is
		/// fetched as well, which have a 1:n relationship with message. 
		/// </summary>
		/// <param name="threadId">ID of Thread which messages should be returned</param>
		/// <param name="pageNo">The page no.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>List with all messages in the thread for the page specified</returns>
		public static async Task<List<MessageInThreadDto>> GetAllMessagesInThreadAsDTOsAsync(int threadId, int pageNo, int pageSize)
		{
			using(var adapter = new DataAccessAdapter())
			{
				var metaData = new LinqMetaData(adapter);
				var q = metaData.Message
								.Where(m => m.ThreadID == threadId)
								.OrderBy(m => m.PostingDate)
								.TakePage(pageNo, pageSize);
				var messages = await q.ProjectToMessageInThreadDto().ToListAsync().ConfigureAwait(false);

				// update thread entity directly inside the DB with an update statement so the # of views is increased by one.
				var updater = new ThreadStatisticsEntity();
				// set the NumberOfViews field to an expression which increases it by 1
				updater.Fields[(int)ThreadStatisticsFieldIndex.NumberOfViews].ExpressionToApply = (ThreadStatisticsFields.NumberOfViews + 1);
				await adapter.UpdateEntitiesDirectlyAsync(updater, new RelationPredicateBucket(ThreadStatisticsFields.ThreadID == threadId)).ConfigureAwait(false);
				return messages;
			}
		}


		/// <summary>
		/// Will return the StartMessageNo for including it in the URL when redirecting to a page with messages in the given
		/// thread. The page started with StartMessageNo will contain the message with ID messageID. Paging is done using the
		/// maxAmountMessagesPerPage property in Application.
		/// </summary>
		/// <param name="threadId">ID of the thread to which the messages belong</param>
		/// <param name="messageId"></param>
		/// <param name="maxAmountMessagesPerPage">The max amount of messages per page to show. </param>
		/// <returns></returns>
		public static async Task<int> GetStartAtMessageForGivenMessageAndThreadAsync(int threadId, int messageId, int maxAmountMessagesPerPage)
		{
			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select(() => MessageFields.MessageID.ToValue<int>())
					  .Where(MessageFields.ThreadID.Equal(threadId))
					  .OrderBy(MessageFields.PostingDate.Ascending())
					  .Distinct();
			
			using(var adapter = new DataAccessAdapter())
			{
				var messageIds = await adapter.FetchQueryAsync(q).ConfigureAwait(false);
				var startAtMessage = 0;
				var rowIndex = 0;
				if(messageIds.Count > 0)
				{
					for(var i = 0; i < messageIds.Count; i++)
					{
						if(messageIds[i] == messageId)
						{
							// found the row
							rowIndex = i;
							break;
						}
					}

					startAtMessage = (rowIndex / maxAmountMessagesPerPage) * maxAmountMessagesPerPage;
				}

				return startAtMessage;
			}
		}


		/// <summary>
		/// Checks if the message with the ID specified is first message in thread with id specified.
		/// </summary>
		/// <param name="threadId">The thread ID.</param>
		/// <param name="messageId">The message ID.</param>
		/// <returns>true if message is first message in thread, false otherwise</returns>
		public static async Task<bool> CheckIfMessageIsFirstInThreadAsync(int threadId, int messageId)
		{
			// use a scalar query, which obtains the first MessageID in a given thread. We sort on posting date ascending, and simply read
			// the first messageid. If that's not available or not equal to messageID, the messageID isn't the first post in the thread, otherwise it is.
			var qf = new QueryFactory();
			var q = qf.Create()
					  .Select(() => MessageFields.MessageID.ToValue<int>())
					  .Where(MessageFields.ThreadID.Equal(threadId))
					  .OrderBy(MessageFields.PostingDate.Ascending())
					  .Limit(1);
			using(var adapter = new DataAccessAdapter())
			{
				var firstMessageId = await adapter.FetchScalarAsync<int?>(q).ConfigureAwait(false);
				return firstMessageId.HasValue && firstMessageId.Value == messageId;
			}
		}


		/// <summary>
		/// Creates the thread filter. Filters on the threads viewable by the passed in userid, which is the caller of the method. 
		/// If a forum isn't in the list of forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should 
		/// be counted / taken into account. Which comes down to: (ForumID in forumsWithThreadsFromOthers) OR IsSticky Or StartedBy==Userid.
		/// It's ok it doesn't filter on forums not visible to the user, as this filter is used in combination of a filter on forums with a filter on visible forums
		/// by the user.
		/// </summary>
		/// <param name="forumsWithThreadsFromOthers">The forums with threads from others.</param>
		/// <param name="userId">The user ID.</param>
		/// <returns>ready to use thread filter.</returns>
		internal static IPredicateExpression CreateThreadFilter(List<int> forumsWithThreadsFromOthers, int userId)
		{
			if((forumsWithThreadsFromOthers != null) && (forumsWithThreadsFromOthers.Count > 0))
			{
				// accept only those threads which are in the forumsWithThreadsFromOthers list or which are either started by userID or sticky.
				return ThreadFields.ForumID.In(forumsWithThreadsFromOthers).Or((ThreadFields.IsSticky == true).Or(ThreadFields.StartedByUserID == userId));
			}

			// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
			// sticky threads or threads started by the calling user.
			return (ThreadFields.IsSticky.Equal(true)).Or(ThreadFields.StartedByUserID.Equal(userId));
		}


		/// <summary>
		/// Builds the projection for a dynamic query which contains thread and statistics information.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		/// <remarks>Doesn't add the forum fields</remarks>
		internal static List<object> BuildQueryProjectionForAllThreadsWithStats(QueryFactory qf)
		{
			return new List<object>()
				   {
					   ThreadFields.ThreadID,
					   ThreadFields.ForumID,
					   ThreadFields.Subject,
					   ThreadFields.StartedByUserID.As("ThreadStartedByUserID"),
					   ThreadFields.IsSticky,
					   ThreadFields.IsClosed,
					   ThreadFields.MarkedAsDone,
					   ThreadStatisticsFields.NumberOfMessages,
					   ThreadStatisticsFields.NumberOfViews,
					   MessageFields.PostingDate.Source("LastMessage").As("ThreadLastPostingDate"),
					   UserFields.NickName.Source("ThreadStarterUser").As("ThreadStartedByNickName"),
					   UserFields.UserID.Source("LastPostingUser").As("LastPostByUserID"),
					   UserFields.NickName.Source("LastPostingUser").As("LastPostByNickName"),
					   MessageFields.MessageID.Source("LastMessage").As("MessageIDLastPost"),
				   };
		}


		/// <summary>
		/// Builds the projection elements for a dynamic query which contains thread information and additionally the forum name.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>The fields for the projection</returns>
		internal static List<object> BuildQueryProjectionForAllThreadsWithStatsWithForumName(QueryFactory qf)
		{
			var toReturn = BuildQueryProjectionForAllThreadsWithStats(qf);
			toReturn.Add(ForumFields.ForumName);
			return toReturn;
		}


		/// <summary>
		/// Builds form clause for the query specified for a fetch of all threads with statistics.
		/// </summary>
		/// <param name="qf">The query factory to use.</param>
		/// <returns>ready to use join operand</returns>
		internal static IJoinOperand BuildFromClauseForAllThreadsWithStats(QueryFactory qf)
		{
			// The older system recalculated the statistics for a set of threads on the fly. This is very bad for performance if there are a lot of 
			// messages in the system. So we now use a threadstatistics entity which keeps track of the last post and the last post. 
			return qf.Thread
					 .LeftJoin(qf.User.As("ThreadStarterUser")).On(ThreadFields.StartedByUserID.Equal(UserFields.UserID.Source("ThreadStarterUser")))
					 .InnerJoin(qf.ThreadStatistics).On(ThreadFields.ThreadID.Equal(ThreadStatisticsFields.ThreadID))
					 .LeftJoin(qf.Message.As("LastMessage")).On(ThreadStatisticsFields.LastMessageID.Equal(MessageFields.MessageID.Source("LastMessage")))
					 .LeftJoin(qf.User.As("LastPostingUser")).On(MessageFields.PostedByUserID.Source("LastMessage").Equal(UserFields.UserID.Source("LastPostingUser")));
		}
	}
}