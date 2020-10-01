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
	/// <summary>Entity class which represents the entity 'ThreadStatistics'.<br/><br/></summary>
	[Serializable]
	public partial class ThreadStatisticsEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private MessageEntity _lastMessage;
		private ThreadEntity _thread;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static ThreadStatisticsEntityStaticMetaData _staticMetaData = new ThreadStatisticsEntityStaticMetaData();
		private static ThreadStatisticsRelations _relationsFactory = new ThreadStatisticsRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name LastMessage</summary>
			public static readonly string LastMessage = "LastMessage";
			/// <summary>Member name Thread</summary>
			public static readonly string Thread = "Thread";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class ThreadStatisticsEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public ThreadStatisticsEntityStaticMetaData()
			{
				SetEntityCoreInfo("ThreadStatisticsEntity", InheritanceHierarchyType.None, false, (int)SD.HnD.DALAdapter.EntityType.ThreadStatisticsEntity, typeof(ThreadStatisticsEntity), typeof(ThreadStatisticsEntityFactory), false);
				AddNavigatorMetaData<ThreadStatisticsEntity, MessageEntity>("LastMessage", "ThreadStatistics", (a, b) => a._lastMessage = b, a => a._lastMessage, (a, b) => a.LastMessage = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadStatisticsRelations.MessageEntityUsingLastMessageIDStatic, ()=>new ThreadStatisticsRelations().MessageEntityUsingLastMessageID, null, new int[] { (int)ThreadStatisticsFieldIndex.LastMessageID }, null, false, (int)SD.HnD.DALAdapter.EntityType.MessageEntity);
				AddNavigatorMetaData<ThreadStatisticsEntity, ThreadEntity>("Thread", "Statistics", (a, b) => a._thread = b, a => a._thread, (a, b) => a.Thread = b, SD.HnD.DALAdapter.RelationClasses.StaticThreadStatisticsRelations.ThreadEntityUsingThreadIDStatic, ()=>new ThreadStatisticsRelations().ThreadEntityUsingThreadID, null, new int[] { (int)ThreadStatisticsFieldIndex.ThreadID }, null, false, (int)SD.HnD.DALAdapter.EntityType.ThreadEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static ThreadStatisticsEntity()
		{
		}

		/// <summary> CTor</summary>
		public ThreadStatisticsEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ThreadStatisticsEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ThreadStatisticsEntity</param>
		public ThreadStatisticsEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for ThreadStatistics which data should be fetched into this ThreadStatistics object</param>
		public ThreadStatisticsEntity(System.Int32 threadID) : this(threadID, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="threadID">PK value for ThreadStatistics which data should be fetched into this ThreadStatistics object</param>
		/// <param name="validator">The custom validator object for this ThreadStatisticsEntity</param>
		public ThreadStatisticsEntity(System.Int32 threadID, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.ThreadID = threadID;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ThreadStatisticsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Method which will construct a filter (predicate expression) for the unique constraint defined on the fields: LastMessageID .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCLastMessageID()
		{
			var filter = new PredicateExpression();
			filter.Add(SD.HnD.DALAdapter.HelperClasses.ThreadStatisticsFields.LastMessageID == this.Fields.GetCurrentValue((int)ThreadStatisticsFieldIndex.LastMessageID));
 			return filter;
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Message' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLastMessage() { return CreateRelationInfoForNavigator("LastMessage"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Thread' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoThread() { return CreateRelationInfoForNavigator("Thread"); }
		
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
		/// <param name="validator">The validator object for this ThreadStatisticsEntity</param>
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
		public static ThreadStatisticsRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Message' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLastMessage { get { return _staticMetaData.GetPrefetchPathElement("LastMessage", CommonEntityBase.CreateEntityCollection<MessageEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Thread' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathThread { get { return _staticMetaData.GetPrefetchPathElement("Thread", CommonEntityBase.CreateEntityCollection<ThreadEntity>()); } }

		/// <summary>The ThreadID property of the Entity ThreadStatistics<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ThreadStatistics"."ThreadID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		[Required]
		public virtual System.Int32 ThreadID
		{
			get { return (System.Int32)GetValue((int)ThreadStatisticsFieldIndex.ThreadID, true); }
			set	{ SetValue((int)ThreadStatisticsFieldIndex.ThreadID, value); }
		}

		/// <summary>The LastMessageID property of the Entity ThreadStatistics<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ThreadStatistics"."LastMessageID".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 LastMessageID
		{
			get { return (System.Int32)GetValue((int)ThreadStatisticsFieldIndex.LastMessageID, true); }
			set	{ SetValue((int)ThreadStatisticsFieldIndex.LastMessageID, value); }
		}

		/// <summary>The NumberOfMessages property of the Entity ThreadStatistics<br/><br/>Redundant aggregate which is used with the view of threads in a forum. By storing this here we can avoid an expensive aggregate query when viewing a page of threads in a forum.</summary>
		/// <remarks>Mapped on  table field: "ThreadStatistics"."NumberOfMessages".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 NumberOfMessages
		{
			get { return (System.Int32)GetValue((int)ThreadStatisticsFieldIndex.NumberOfMessages, true); }
			set	{ SetValue((int)ThreadStatisticsFieldIndex.NumberOfMessages, value); }
		}

		/// <summary>The NumberOfViews property of the Entity ThreadStatistics<br/><br/>This view was present in the Thread entity but is now refactored to this field. </summary>
		/// <remarks>Mapped on  table field: "ThreadStatistics"."NumberOfViews".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		[Required]
		public virtual System.Int32 NumberOfViews
		{
			get { return (System.Int32)GetValue((int)ThreadStatisticsFieldIndex.NumberOfViews, true); }
			set	{ SetValue((int)ThreadStatisticsFieldIndex.NumberOfViews, value); }
		}

		/// <summary>Gets / sets related entity of type 'MessageEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/></summary>
		[Browsable(true)]
		public virtual MessageEntity LastMessage
		{
			get { return _lastMessage; }
			set { SetSingleRelatedEntityNavigator(value, "LastMessage"); }
		}

		/// <summary>Gets / sets related entity of type 'ThreadEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned.<br/><br/></summary>
		[Browsable(true)]
		public virtual ThreadEntity Thread
		{
			get { return _thread; }
			set { SetSingleRelatedEntityNavigator(value, "Thread"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace SD.HnD.DALAdapter
{
	public enum ThreadStatisticsFieldIndex
	{
		///<summary>ThreadID. </summary>
		ThreadID,
		///<summary>LastMessageID. </summary>
		LastMessageID,
		///<summary>NumberOfMessages. </summary>
		NumberOfMessages,
		///<summary>NumberOfViews. </summary>
		NumberOfViews,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace SD.HnD.DALAdapter.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: ThreadStatistics. </summary>
	public partial class ThreadStatisticsRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between ThreadStatisticsEntity and MessageEntity over the 1:1 relation they have, using the relation between the fields: ThreadStatistics.LastMessageID - Message.MessageID</summary>
		public virtual IEntityRelation MessageEntityUsingLastMessageID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToOne, "LastMessage", false, new[] { MessageFields.MessageID, ThreadStatisticsFields.LastMessageID }); }
		}

		/// <summary>Returns a new IEntityRelation object, between ThreadStatisticsEntity and ThreadEntity over the 1:1 relation they have, using the relation between the fields: ThreadStatistics.ThreadID - Thread.ThreadID</summary>
		public virtual IEntityRelation ThreadEntityUsingThreadID
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.OneToOne, "Thread", false, new[] { ThreadFields.ThreadID, ThreadStatisticsFields.ThreadID }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticThreadStatisticsRelations
	{
		internal static readonly IEntityRelation MessageEntityUsingLastMessageIDStatic = new ThreadStatisticsRelations().MessageEntityUsingLastMessageID;
		internal static readonly IEntityRelation ThreadEntityUsingThreadIDStatic = new ThreadStatisticsRelations().ThreadEntityUsingThreadID;

		/// <summary>CTor</summary>
		static StaticThreadStatisticsRelations() { }
	}
}
