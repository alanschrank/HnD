﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.7.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using SD.HnD.DALAdapter.HelperClasses;
using SD.HnD.DALAdapter.FactoryClasses;
using SD.HnD.DALAdapter.RelationClasses;
using System.ComponentModel.DataAnnotations;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DALAdapter.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'Thread'.<br/><br/></summary>
	[Serializable]
	public partial class ThreadEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private EntityCollection<AuditDataThreadRelatedEntity> _auditDataThreadRelated;
		private EntityCollection<BookmarkEntity> _presentInBookmarks;
		private EntityCollection<MessageEntity> _messages;
		private EntityCollection<ThreadSubscriptionEntity> _threadSubscription;
		private EntityCollection<UserEntity> _usersWhoBookmarkedThread;
		private EntityCollection<UserEntity> _usersWhoPostedInThread;
		private EntityCollection<UserEntity> _usersWhoSubscribedThread;
		private ForumEntity _forum;
		private UserEntity _userWhoStartedThread;
		private SupportQueueThreadEntity _supportQueueThread;
		private ThreadStatisticsEntity _statistics;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static ThreadEntityStaticMetaData _staticMetaData = new ThreadEntityStaticMetaData();
		private static ThreadRelations _relationsFactory = new ThreadRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Forum</summary>
			public static readonly string Forum = "Forum";
			/// <summary>Member name UserWhoStartedThread</summary>
			public static readonly string UserWhoStartedThread = "UserWhoStartedThread";
			/// <summary>Member name AuditDataThreadRelated</summary>
			public static readonly string AuditDataThreadRelated = "AuditDataThreadRelated";
			/// <summary>Member name PresentInBookmarks</summary>
			public static readonly string PresentInBookmarks = "PresentInBookmarks";
			/// <summary>Member name Messages</summary>
			public static readonly string Messages = "Messages";
			/// <summary>Member name ThreadSubscription</summary>
			public static readonly string ThreadSubscription = "ThreadSubscription";
			/// <summary>Member name UsersWhoBookmarkedThread</summary>
			public static readonly string UsersWhoBookmarkedThread = "UsersWhoBookmarkedThread";
			/// <summary>Member name UsersWhoPostedInThread</summary>
			public static readonly string UsersWhoPostedInThread = "UsersWhoPostedInThread";
			/// <summary>Member name UsersWhoSubscribedThread</summary>
			public static readonly string UsersWhoSubscribedThread = "UsersWhoSubscribedThread";
			/// <summary>Member name SupportQueueThread</summary>
			public static readonly string SupportQueueThread = "SupportQueueThread";
			/// <summary>Member name Statistics</summary>
			public static readonly string Statistics = "Statistics";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class ThreadEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public ThreadEntityStaticMetaData()
			{
				SetEntityCoreInfo("ThreadEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity, typeof(ThreadEntity), typeof(ThreadEntityFactory), false);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<AuditDataThreadRelatedEntity>>("AuditDataThreadRelated", a => a._auditDataThreadRelated, (a, b) => a._auditDataThreadRelated = b, a => a.AuditDataThreadRelated, () => new ThreadRelations().AuditDataThreadRelatedEntityUsingThreadID, typeof(AuditDataThreadRelatedEntity), (int)SD.HnD.DALAdapter.EntityType.AuditDataThreadRelatedEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<BookmarkEntity>>("PresentInBookmarks", a => a._presentInBookmarks, (a, b) => a._presentInBookmarks = b, a => a.PresentInBookmarks, () => new ThreadRelations().BookmarkEntityUsingThreadID, typeof(BookmarkEntity), (int)SD.HnD.DALAdapter.EntityType.BookmarkEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<MessageEntity>>("Messages", a => a._messages, (a, b) => a._messages = b, a => a.Messages, () => new ThreadRelations().MessageEntityUsingThreadID, typeof(MessageEntity), (int)SD.HnD.DALAdapter.EntityType.MessageEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<ThreadSubscriptionEntity>>("ThreadSubscription", a => a._threadSubscription, (a, b) => a._threadSubscription = b, a => a.ThreadSubscription, () => new ThreadRelations().ThreadSubscriptionEntityUsingThreadID, typeof(ThreadSubscriptionEntity), (int)SD.HnD.DALAdapter.EntityType.ThreadSubscriptionEntity);
				AddNavigatorMetaData<ThreadEntity, ForumEntity>("Forum", "Threads", (a, b) => a._forum = b, a => a._forum, (a, b) => a.Forum = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.ForumEntityUsingForumIDStatic, ()=>new ThreadRelations().ForumEntityUsingForumID, null, new int[] { (int)ThreadFieldIndex.ForumID }, null, true, (int)SD.HnD.DALAdapter.EntityType.ForumEntity);
				AddNavigatorMetaData<ThreadEntity, UserEntity>("UserWhoStartedThread", "StartedThreads", (a, b) => a._userWhoStartedThread = b, a => a._userWhoStartedThread, (a, b) => a.UserWhoStartedThread = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.UserEntityUsingStartedByUserIDStatic, ()=>new ThreadRelations().UserEntityUsingStartedByUserID, null, new int[] { (int)ThreadFieldIndex.StartedByUserID }, null, true, (int)SD.HnD.DALAdapter.EntityType.UserEntity);
				AddNavigatorMetaData<ThreadEntity, SupportQueueThreadEntity>("SupportQueueThread", "Thread", (a, b) => a._supportQueueThread = b, a => a._supportQueueThread, (a, b) => a.SupportQueueThread = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.SupportQueueThreadEntityUsingThreadIDStatic, ()=>new ThreadRelations().SupportQueueThreadEntityUsingThreadID, null, null, null, true, (int)SD.HnD.DALAdapter.EntityType.SupportQueueThreadEntity);
				AddNavigatorMetaData<ThreadEntity, ThreadStatisticsEntity>("Statistics", "Thread", (a, b) => a._statistics = b, a => a._statistics, (a, b) => a.Statistics = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadRelations.ThreadStatisticsEntityUsingThreadIDStatic, ()=>new ThreadRelations().ThreadStatisticsEntityUsingThreadID, null, null, null, true, (int)SD.HnD.DALAdapter.EntityType.ThreadStatisticsEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<UserEntity>>("UsersWhoBookmarkedThread", a => a._usersWhoBookmarkedThread, (a, b) => a._usersWhoBookmarkedThread = b, a => a.UsersWhoBookmarkedThread, () => new ThreadRelations().BookmarkEntityUsingThreadID, () => new BookmarkRelations().UserEntityUsingUserID, "ThreadEntity__", "Bookmark_", typeof(UserEntity), (int)SD.HnD.DALAdapter.EntityType.UserEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<UserEntity>>("UsersWhoPostedInThread", a => a._usersWhoPostedInThread, (a, b) => a._usersWhoPostedInThread = b, a => a.UsersWhoPostedInThread, () => new ThreadRelations().MessageEntityUsingThreadID, () => new MessageRelations().UserEntityUsingPostedByUserID, "ThreadEntity__", "Message_", typeof(UserEntity), (int)SD.HnD.DALAdapter.EntityType.UserEntity);
				AddNavigatorMetaData<ThreadEntity, EntityCollection<UserEntity>>("UsersWhoSubscribedThread", a => a._usersWhoSubscribedThread, (a, b) => a._usersWhoSubscribedThread = b, a => a.UsersWhoSubscribedThread, () => new ThreadRelations().ThreadSubscriptionEntityUsingThreadID, () => new ThreadSubscriptionRelations().UserEntityUsingUserID, "ThreadEntity__", "ThreadSubscription_", typeof(UserEntity), (int)SD.HnD.DALAdapter.EntityType.UserEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static ThreadEntity()
		{
		}

		/// <summary> CTor</summary>
		public ThreadEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ThreadEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ThreadEntity</param>
		public ThreadEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		public ThreadEntity(System.Int32 threadID) : this(threadID, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for Thread which data should be fetched into this Thread object</param>
		/// <param name="validator">The custom validator object for this ThreadEntity</param>
		public ThreadEntity(System.Int32 threadID, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ThreadID = threadID;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ThreadEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'AuditDataThreadRelated' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAuditDataThreadRelated() { return CreateRelationInfoForNavigator("AuditDataThreadRelated"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Bookmark' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPresentInBookmarks() { return CreateRelationInfoForNavigator("PresentInBookmarks"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'Message' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMessages() { return CreateRelationInfoForNavigator("Messages"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'ThreadSubscription' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThreadSubscription() { return CreateRelationInfoForNavigator("ThreadSubscription"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoBookmarkedThread() { return CreateRelationInfoForNavigator("UsersWhoBookmarkedThread"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoPostedInThread() { return CreateRelationInfoForNavigator("UsersWhoPostedInThread"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUsersWhoSubscribedThread() { return CreateRelationInfoForNavigator("UsersWhoSubscribedThread"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Forum' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoForum() { return CreateRelationInfoForNavigator("Forum"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'User' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserWhoStartedThread() { return CreateRelationInfoForNavigator("UserWhoStartedThread"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'SupportQueueThread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSupportQueueThread() { return CreateRelationInfoForNavigator("SupportQueueThread"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'ThreadStatistics' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStatistics() { return CreateRelationInfoForNavigator("Statistics"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ThreadEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static ThreadRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AuditDataThreadRelated' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAuditDataThreadRelated { get { return _staticMetaData.GetPrefetchPathElement("AuditDataThreadRelated", CommonEntityBase.CreateEntityCollection<AuditDataThreadRelatedEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Bookmark' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPresentInBookmarks { get { return _staticMetaData.GetPrefetchPathElement("PresentInBookmarks", CommonEntityBase.CreateEntityCollection<BookmarkEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMessages { get { return _staticMetaData.GetPrefetchPathElement("Messages", CommonEntityBase.CreateEntityCollection<MessageEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ThreadSubscription' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThreadSubscription { get { return _staticMetaData.GetPrefetchPathElement("ThreadSubscription", CommonEntityBase.CreateEntityCollection<ThreadSubscriptionEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoBookmarkedThread { get { return _staticMetaData.GetPrefetchPathElement("UsersWhoBookmarkedThread", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoPostedInThread { get { return _staticMetaData.GetPrefetchPathElement("UsersWhoPostedInThread", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUsersWhoSubscribedThread { get { return _staticMetaData.GetPrefetchPathElement("UsersWhoSubscribedThread", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Forum' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathForum { get { return _staticMetaData.GetPrefetchPathElement("Forum", CommonEntityBase.CreateEntityCollection<ForumEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserWhoStartedThread { get { return _staticMetaData.GetPrefetchPathElement("UserWhoStartedThread", CommonEntityBase.CreateEntityCollection<UserEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SupportQueueThread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSupportQueueThread { get { return _staticMetaData.GetPrefetchPathElement("SupportQueueThread", CommonEntityBase.CreateEntityCollection<SupportQueueThreadEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ThreadStatistics' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStatistics { get { return _staticMetaData.GetPrefetchPathElement("Statistics", CommonEntityBase.CreateEntityCollection<ThreadStatisticsEntity>()); } }

		/// <summary>The ThreadID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ThreadID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		[Required]
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.ThreadID, true); }
			set { SetValue((int)ThreadFieldIndex.ThreadID, value); }		}

		/// <summary>The ForumID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."ForumID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 ForumID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.ForumID, true); }
			set	{ SetValue((int)ThreadFieldIndex.ForumID, value); }
		}

		/// <summary>The Subject property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Subject".<br/>Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 250.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		[StringLength(250)]
		[MinLength(2)]
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Subject, true); }
			set	{ SetValue((int)ThreadFieldIndex.Subject, value); }
		}

		/// <summary>The StartedByUserID property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."StartedByUserID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 StartedByUserID
		{
			get { return (System.Int32)GetValue((int)ThreadFieldIndex.StartedByUserID, true); }
			set	{ SetValue((int)ThreadFieldIndex.StartedByUserID, value); }
		}

		/// <summary>The IsSticky property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsSticky".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Boolean IsSticky
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsSticky, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsSticky, value); }
		}

		/// <summary>The IsClosed property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."IsClosed".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Boolean IsClosed
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.IsClosed, true); }
			set	{ SetValue((int)ThreadFieldIndex.IsClosed, value); }
		}

		/// <summary>The MarkedAsDone property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."MarkedAsDone".<br/>Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Boolean MarkedAsDone
		{
			get { return (System.Boolean)GetValue((int)ThreadFieldIndex.MarkedAsDone, true); }
			set	{ SetValue((int)ThreadFieldIndex.MarkedAsDone, value); }
		}

		/// <summary>The Memo property of the Entity Thread<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Thread"."Memo".<br/>Table field type characteristics (type, precision, scale, length): NText, 0, 0, 1073741823.<br/>Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		[StringLength(1073741823)]
		public virtual System.String Memo
		{
			get { return (System.String)GetValue((int)ThreadFieldIndex.Memo, true); }
			set	{ SetValue((int)ThreadFieldIndex.Memo, value); }
		}

		/// <summary>Gets the EntityCollection with the related entities of type 'AuditDataThreadRelatedEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(AuditDataThreadRelatedEntity))]
		public virtual EntityCollection<AuditDataThreadRelatedEntity> AuditDataThreadRelated { get { return GetOrCreateEntityCollection<AuditDataThreadRelatedEntity, AuditDataThreadRelatedEntityFactory>("Thread", true, false, ref _auditDataThreadRelated); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'BookmarkEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(BookmarkEntity))]
		public virtual EntityCollection<BookmarkEntity> PresentInBookmarks { get { return GetOrCreateEntityCollection<BookmarkEntity, BookmarkEntityFactory>("Thread", true, false, ref _presentInBookmarks); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'MessageEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(MessageEntity))]
		public virtual EntityCollection<MessageEntity> Messages { get { return GetOrCreateEntityCollection<MessageEntity, MessageEntityFactory>("Thread", true, false, ref _messages); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'ThreadSubscriptionEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(ThreadSubscriptionEntity))]
		public virtual EntityCollection<ThreadSubscriptionEntity> ThreadSubscription { get { return GetOrCreateEntityCollection<ThreadSubscriptionEntity, ThreadSubscriptionEntityFactory>("Thread", true, false, ref _threadSubscription); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoBookmarkedThread { get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("ThreadsInBookmarks", false, true, ref _usersWhoBookmarkedThread); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoPostedInThread { get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("PostedMessagesInThreads", false, true, ref _usersWhoPostedInThread); } }

		/// <summary>Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UsersWhoSubscribedThread { get { return GetOrCreateEntityCollection<UserEntity, UserEntityFactory>("ThreadCollectionViaThreadSubscription", false, true, ref _usersWhoSubscribedThread); } }

		/// <summary>Gets / sets related entity of type 'ForumEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual ForumEntity Forum
		{
			get { return _forum; }
			set { SetSingleRelatedEntityNavigator(value, "Forum"); }
		}

		/// <summary>Gets / sets related entity of type 'UserEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(true)]
		public virtual UserEntity UserWhoStartedThread
		{
			get { return _userWhoStartedThread; }
			set { SetSingleRelatedEntityNavigator(value, "UserWhoStartedThread"); }
		}

		/// <summary>Gets / sets related entity of type 'SupportQueueThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/></summary>
		[Browsable(true)]
		public virtual SupportQueueThreadEntity SupportQueueThread
		{
			get { return _supportQueueThread; }
			set { SetSingleRelatedEntityNavigator(value, "SupportQueueThread"); }
		}

		/// <summary>Gets / sets related entity of type 'ThreadStatisticsEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/></summary>
		[Browsable(true)]
		public virtual ThreadStatisticsEntity Statistics
		{
			get { return _statistics; }
			set { SetSingleRelatedEntityNavigator(value, "Statistics"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
	public enum ThreadFieldIndex
	{
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>ForumID. </summary>
		ForumID,
		///<summary>Subject. </summary>
		Subject,
		///<summary>StartedByUserID. </summary>
		StartedByUserID,
		///<summary>IsSticky. </summary>
		IsSticky,
		///<summary>IsClosed. </summary>
		IsClosed,
		///<summary>MarkedAsDone. </summary>
		MarkedAsDone,
		///<summary>Memo. </summary>
		Memo,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Thread. </summary>
	public partial class ThreadRelations: RelationFactory
	{
		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and AuditDataThreadRelatedEntity over the 1:n relation they have, using the relation between the fields: Thread.ThreadID - AuditDataThreadRelated.ThreadID</summary>
		public virtual IEntityRelation AuditDataThreadRelatedEntityUsingThreadID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "AuditDataThreadRelated", true, new[] { ThreadFields.ThreadID, AuditDataThreadRelatedFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and BookmarkEntity over the 1:n relation they have, using the relation between the fields: Thread.ThreadID - Bookmark.ThreadID</summary>
		public virtual IEntityRelation BookmarkEntityUsingThreadID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "PresentInBookmarks", true, new[] { ThreadFields.ThreadID, BookmarkFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and MessageEntity over the 1:n relation they have, using the relation between the fields: Thread.ThreadID - Message.ThreadID</summary>
		public virtual IEntityRelation MessageEntityUsingThreadID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "Messages", true, new[] { ThreadFields.ThreadID, MessageFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and ThreadSubscriptionEntity over the 1:n relation they have, using the relation between the fields: Thread.ThreadID - ThreadSubscription.ThreadID</summary>
		public virtual IEntityRelation ThreadSubscriptionEntityUsingThreadID
		{
			get { return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToMany, "ThreadSubscription", true, new[] { ThreadFields.ThreadID, ThreadSubscriptionFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and SupportQueueThreadEntity over the 1:1 relation they have, using the relation between the fields: Thread.ThreadID - SupportQueueThread.ThreadID</summary>
		public virtual IEntityRelation SupportQueueThreadEntityUsingThreadID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToOne, "SupportQueueThread", true, new[] { ThreadFields.ThreadID, SupportQueueThreadFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and ThreadStatisticsEntity over the 1:1 relation they have, using the relation between the fields: Thread.ThreadID - ThreadStatistics.ThreadID</summary>
		public virtual IEntityRelation ThreadStatisticsEntityUsingThreadID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToOne, "Statistics", true, new[] { ThreadFields.ThreadID, ThreadStatisticsFields.ThreadID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and ForumEntity over the m:1 relation they have, using the relation between the fields: Thread.ForumID - Forum.ForumID</summary>
		public virtual IEntityRelation ForumEntityUsingForumID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Forum", false, new[] { ForumFields.ForumID, ThreadFields.ForumID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadEntity and UserEntity over the m:1 relation they have, using the relation between the fields: Thread.StartedByUserID - User.UserID</summary>
		public virtual IEntityRelation UserEntityUsingStartedByUserID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "UserWhoStartedThread", false, new[] { UserFields.UserID, ThreadFields.StartedByUserID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticThreadRelations
	{
		internal static readonly IEntityRelation AuditDataThreadRelatedEntityUsingThreadIDStatic = new ThreadRelations().AuditDataThreadRelatedEntityUsingThreadID;
		internal static readonly IEntityRelation BookmarkEntityUsingThreadIDStatic = new ThreadRelations().BookmarkEntityUsingThreadID;
		internal static readonly IEntityRelation MessageEntityUsingThreadIDStatic = new ThreadRelations().MessageEntityUsingThreadID;
		internal static readonly IEntityRelation ThreadSubscriptionEntityUsingThreadIDStatic = new ThreadRelations().ThreadSubscriptionEntityUsingThreadID;
		internal static readonly IEntityRelation SupportQueueThreadEntityUsingThreadIDStatic = new ThreadRelations().SupportQueueThreadEntityUsingThreadID;
		internal static readonly IEntityRelation ThreadStatisticsEntityUsingThreadIDStatic = new ThreadRelations().ThreadStatisticsEntityUsingThreadID;
		internal static readonly IEntityRelation ForumEntityUsingForumIDStatic = new ThreadRelations().ForumEntityUsingForumID;
		internal static readonly IEntityRelation UserEntityUsingStartedByUserIDStatic = new ThreadRelations().UserEntityUsingStartedByUserID;

		/// <summary>CTor</summary>
		static StaticThreadRelations() { }
	}
}
