﻿/*
	This file is part of HnD.
	HnD is (c) 2002-2020 Solutions Design.
	https://www.llblgen.com
	https://www.sd.nl

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
using System.Collections.Generic;
using System.Linq;
using SD.HnD.DALAdapter.EntityClasses;
using SD.HnD.DTOs.DtoClasses;

namespace SD.HnD.Gui.Models
{
	/// <summary>
	/// Data for the Thread page, which lists a page of messages of a thread.
	/// </summary>
	public class ThreadData
	{
		public string ForumName { get; set; }
		public string SectionName { get; set; }
		public int PageNo { get; set; }
		public int PageSize { get; set; }
		public int NumberOfPages { get; set; }
		public ThreadEntity Thread { get; set; }
		public string MemoAsHTML { get; set; }
		public bool ShowEditMessageLink { get; set; }

		public bool ShowDeleteMessageLink
		{
			get { return this.ShowEditMessageLink; }
		}

		public bool ShowQuoteMessageLink
		{
			get { return this.UserMayAddNewMessages; }
		}

		public bool ShowIPAddresses { get; set; }
		public bool ThreadStartedByCurrentUser { get; set; }
		public bool UserMayAddNewMessages { get; set; }
		public bool UserMayAddAttachments { get; set; }
		public bool UserCanCreateThreads { get; set; }
		public bool UserCanApproveAttachments { get; set; }
		public bool UserMayDoForumSpecificThreadManagement { get; set; }
		public bool UserMayDoSystemWideThreadManagement { get; set; }
		public bool UserMayEditMemo { get; set; }
		public bool UserMayMarkThreadAsDone { get; set; }
		public bool UserMayManageSupportQueueContents { get; set; }
		public bool UserMayManageOtherUsersAttachments { get; set; }
		public bool UserMayDoBasicThreadOperations { get; set; }
		public List<SupportQueueEntity> AllSupportQueues { get; set; }
		public SupportQueueEntity ContainingSupportQueue { get; set; }
		public SupportQueueThreadEntity SupportQueueThreadInfo { get; set; }
		public bool ThreadIsBookmarked { get; set; }
		public bool ThreadIsSubscribed { get; set; }
		public int ForumMaxNumberOfAttachmentsPerMessage { get; set; }
		public List<MessageInThreadDto> ThreadMessages { get; set; }

		public bool IsClosed
		{
			get { return this.Thread.IsClosed; }
		}

		public bool IsSticky
		{
			get { return this.Thread.IsSticky; }
		}

		public int PageNoOlderMessages
		{
			get
			{
				if(this.PageNo >= this.NumberOfPages)
				{
					return this.NumberOfPages - 1;
				}

				return this.PageNo <= 1 ? 0 : this.PageNo - 1;
			}
		}

		public int PageNoNewerMessages
		{
			get { return this.PageNo >= this.NumberOfPages ? 0 : this.PageNo + 1; }
		}

		public SupportQueueEntity ActiveQueue
		{
			get { return this.SupportQueueThreadInfo == null ? null : this.AllSupportQueues.FirstOrDefault(q => q.QueueID == this.SupportQueueThreadInfo.QueueID); }
		}
	}
}