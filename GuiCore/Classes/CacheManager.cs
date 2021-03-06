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
using SD.HnD.BL;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DALAdapter.HelperClasses;

namespace SD.HnD.Gui
{
	/// <summary>
	/// Simple Cache manager which forms a central point to obtain / invalidate / store data into the ASP.NET cache object of this CacheManager.
	/// </summary>
	/// <remarks>This cache is for caching data only, not page output. It's a set of extension methods on the IMemoryCache interface</remarks>
	public static class CacheManager
	{
		/// <summary>
		/// Gets all sections in a collection from the Cache. If it's not available, the collection with all the section entities is loaded from the DB and
		/// added to the cache. 
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <returns>A SectionCollection with all SectionEntity instances of the sections of the forum system. This collection has to be threated as
		/// a readonly collection with readonly objects</returns>
		public static async Task<EntityCollection<SectionEntity>> GetAllSectionsAsync(this IMemoryCache cache)
		{
			var toReturn = cache.Get<EntityCollection<SectionEntity>>(CacheKeys.AllSections);
			if(toReturn == null)
			{
				// not there, store it.
				toReturn = await SectionGuiHelper.GetAllSectionsAsync();

				// just store it in the cache without any dependency, as it's not changing often. 
				cache.Set(CacheKeys.AllSections, toReturn);
			}

			return toReturn;
		}


		/// <summary>
		/// Gets the name of the section with the id passed in. This routine will utilize the cache instead of going to the DB for the section. 
		/// If the sections aren't available, it will load them into the cache first. 
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <param name="sectionId">The section ID.</param>
		/// <returns>name of the section passed in.</returns>
		public static async Task<string> GetSectionNameAsync(this IMemoryCache cache, int sectionId)
		{
			var cachedSections = await cache.GetAllSectionsAsync();
			var matchingSection = cachedSections.FirstOrDefault(s => s.SectionID == sectionId);
			return matchingSection == null ? string.Empty : matchingSection.SectionName;
		}


		/// <summary>
		/// Gets the forum entity with the passed in forumid from the cache. If it's not there, it will be loaded from the db and stored in the cache. 
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <param name="forumId">The forum ID.</param>
		/// <returns>ForumEntity instance of the forum with id forumID</returns>
		/// <remarks>If forumID isn't found, null is returned. ForumEntity instances are cached indefinitely, until the forum is changed or when a message
		/// is added to a thread in the forum. The forum entities are cached per entity to make the per-entity requests for a forum faster. Bulk fetches
		/// for forum data isn't using this cache, it's fetching the data directly from the DB. This is ok, forumentity data isn't very volatile</remarks>
		public static async Task<ForumEntity> GetForumAsync(this IMemoryCache cache, int forumId)
		{
			var keyToUse = ProduceCacheKey(CacheKeys.SingleForum, forumId);
			var toReturn = cache.Get<ForumEntity>(keyToUse);
			if(toReturn == null)
			{
				toReturn = await ForumGuiHelper.GetForumAsync(forumId);
				if(toReturn != null)
				{
					// found, cache it
					cache.Set(keyToUse, toReturn);
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Gets the system data entity from the cache. If the entity isn't found in the cache, it's loaded first, stored in the cache and then returned.
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <returns>entity with system data, or null if not found.</returns>
		public static async Task<SystemDataEntity> GetSystemDataAsync(this IMemoryCache cache)
		{
			var toReturn = cache.Get<SystemDataEntity>(CacheKeys.SystemData);
			if(toReturn == null)
			{
				toReturn = await SystemGuiHelper.GetSystemSettingsAsync();
				if(toReturn != null)
				{
					// found, cache it
					cache.Set(CacheKeys.SystemData, toReturn);
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Gets all support queues from the cache. If it's not available, the collection with all the support queue entities is loaded from the DB and
		/// added to the cache. 
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <returns>A SupportQueueCollection with all supportqueue Entity instances of the support queues of the forum system. This collection has to be threated as
		/// a readonly collection with readonly objects</returns>
		public static async Task<EntityCollection<SupportQueueEntity>> GetAllSupportQueuesAsync(this IMemoryCache cache)
		{
			var toReturn = cache.Get<EntityCollection<SupportQueueEntity>>(CacheKeys.AllSupportQueues);
			if(toReturn == null)
			{
				// not there, store it.
				toReturn = await SupportQueueGuiHelper.GetAllSupportQueuesAsync();

				// just store it in the cache without any dependency, as it's not changing often. 
				cache.Set(CacheKeys.AllSupportQueues, toReturn);
			}

			return toReturn;
		}


		/// <summary>
		/// Produces the cache key from the passed in values. This routine will append all values in additionalValues to the baseKey, separated by ':'.
		/// </summary>
		/// <param name="baseKey">The base key.</param>
		/// <param name="additionalValues">The additional values.</param>
		/// <returns>ready to use cache key based on the values passed in</returns>
		public static string ProduceCacheKey(string baseKey, params object[] additionalValues)
		{
			var toReturn = new StringBuilder(baseKey);
			foreach(var value in additionalValues)
			{
				toReturn.AppendFormat(":{0}", value);
			}

			return toReturn.ToString();
		}


		/// <summary>
		/// Gets all IP bans cached in the cache. 
		/// </summary>
		/// <param name="cache">The cache object this methods works on</param>
		/// <returns>Dictionary with per range (key) a dictionary with all IP addresses as keys, with the segments falling into the range concatenated
		/// to eachother with a '.'</returns>
		public static async Task<Dictionary<int, Dictionary<string, IPBanEntity>>> GetAllIPBansAsync(this IMemoryCache cache)
		{
			var toReturn = cache.Get<Dictionary<int, Dictionary<string, IPBanEntity>>>(CacheKeys.AllIPBans);
			if(toReturn == null)
			{
				// not there, store it.
				var allIPBans = await SecurityGuiHelper.GetAllIPBansAsync();
				toReturn = new Dictionary<int, Dictionary<string, IPBanEntity>>();
				foreach(var currentIPBan in allIPBans)
				{
					Dictionary<string, IPBanEntity> ipAddresses = null;
					if(!toReturn.TryGetValue(currentIPBan.Range, out ipAddresses))
					{
						// not there yet, add
						ipAddresses = new Dictionary<string, IPBanEntity>();
						toReturn.Add(currentIPBan.Range, ipAddresses);
					}

					// add ip address with segments in range to ipAddresses' key list.
					var key = string.Empty;
					switch(currentIPBan.Range)
					{
						case 8:
							key = currentIPBan.IPSegment1.ToString();
							break;
						case 16:
							key = String.Format("{0}.{1}", currentIPBan.IPSegment1, currentIPBan.IPSegment2);
							break;
						case 24:
							key = String.Format("{0}.{1}.{2}", currentIPBan.IPSegment1, currentIPBan.IPSegment2, currentIPBan.IPSegment3);
							break;
						case 32:
							key = String.Format("{0}.{1}.{2}.{3}", currentIPBan.IPSegment1, currentIPBan.IPSegment2, currentIPBan.IPSegment3, currentIPBan.IPSegment4);
							break;
						default:

							// illegal range, ignore
							continue;
					}

					if(!ipAddresses.ContainsKey(key))
					{
						ipAddresses.Add(key, currentIPBan);
					}
				}

				// just store it in the cache without any dependency
				cache.Set(CacheKeys.AllIPBans, toReturn);
			}

			return toReturn;
		}
	}
}