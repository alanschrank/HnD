﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 5.0
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;

namespace SD.HnD.DALAdapter.TypedListClasses
{
	/// <summary>Class which represents a row in the typed list 'ForumMessages'.</summary>
	/// <remarks>This class is a result class for a query, which is produced with the method <see cref="SD.HnD.DALAdapter.FactoryClasses.QueryFactory.GetForumMessagesTypedList"/>.
	/// Contains the following entity definition(s):
	/// Entity: Forum. <br/>
	/// Entity: Message. <br/>
	/// Entity: Thread. <br/>
	/// Entity: User. <br/>
	/// Custom Properties: <br/>
	/// </remarks>
	[Serializable]
	public partial class ForumMessagesRow 
	{
		#region Extensibility Method Definitions
		partial void OnCreated();
		#endregion
		
		/// <summary>Initializes a new instance of the <see cref="ForumMessagesRow"/> class.</summary>
		public ForumMessagesRow()
		{
			OnCreated();
		}

		#region Class Property Declarations
		/// <summary>Gets or sets the MessageID field. Mapped onto 'Message.MessageID'</summary>
		public System.Int32 MessageID { get; set; }
		/// <summary>Gets or sets the PostingDate field. Mapped onto 'Message.PostingDate'</summary>
		public System.DateTime PostingDate { get; set; }
		/// <summary>Gets or sets the MessageTextAsHTML field. Mapped onto 'Message.MessageTextAsHTML'</summary>
		public System.String MessageTextAsHTML { get; set; }
		/// <summary>Gets or sets the ThreadID field. Mapped onto 'Message.ThreadID'</summary>
		public System.Int32 ThreadID { get; set; }
		/// <summary>Gets or sets the Subject field. Mapped onto 'Thread.Subject'</summary>
		public System.String Subject { get; set; }
		/// <summary>Gets or sets the EmailAddress field. Mapped onto 'User.EmailAddress'</summary>
		public System.String EmailAddress { get; set; }
		/// <summary>Gets or sets the EmailAddressIsPublic field. Mapped onto 'User.EmailAddressIsPublic'</summary>
		public Nullable<System.Boolean> EmailAddressIsPublic { get; set; }
		/// <summary>Gets or sets the NickName field. Mapped onto 'User.NickName'</summary>
		public System.String NickName { get; set; }
		/// <summary>Gets or sets the MessageText field. Mapped onto 'Message.MessageText'</summary>
		public System.String MessageText { get; set; }
		#endregion
	}
}

