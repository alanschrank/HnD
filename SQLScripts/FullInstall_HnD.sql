-- ----------------------------------------------------------------------------------------------------------------
-- Installs HnD v3.0's catalog. It will result in an empty catalog and one stored procedure which is ran from the
-- HnD system the first time the forum is started. 
-- 
-- Be sure to change the 'HnD' name below.
-- ----------------------------------------------------------------------------------------------------------------
-- ###############################################################################################################
-- DROP statements for existing elements. 
-- ###############################################################################################################
-- DROP statements for dropping existing elements with the same names as the ones created are commented out below. 
-- If you want to enable these statements for DROPping the existing elements first (which will remove all the data
-- in these existing elements), uncomment these statements by removing the two comment markers /* and */

-- Remove the comment marker on the NEXT line to enable DROP statements to remove existing elements
/* 

-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------

-- CHANGE 'HnD' below if your catalog has a different name!

USE [HnD]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- DROP Foreign keys
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[Attachment] DROP CONSTRAINT [FK_Attachment_Message]
GO

ALTER TABLE [dbo].[AuditDataCore] DROP CONSTRAINT [TF_AuditDataCore_TF_AuditAction_FK1]
GO

ALTER TABLE [dbo].[AuditDataCore] DROP CONSTRAINT [TF_User_TF_AuditDataCore_FK1]
GO

ALTER TABLE [dbo].[AuditDataMessageRelated] DROP CONSTRAINT [TF_AuditDataMessageRelated_TF_AuditDataCore_FK1]
GO

ALTER TABLE [dbo].[AuditDataMessageRelated] DROP CONSTRAINT [TF_AuditDataMessageRelated_TF_Message_FK1]
GO

ALTER TABLE [dbo].[AuditDataThreadRelated] DROP CONSTRAINT [TF_AuditDataThreadRelated_TF_AuditDataCore_FK1]
GO

ALTER TABLE [dbo].[AuditDataThreadRelated] DROP CONSTRAINT [TF_AuditDataThreadRelated_TF_Thread_FK1]
GO

ALTER TABLE [dbo].[Bookmark] DROP CONSTRAINT [TF_Thread_TF_Bookmark_FK]
GO

ALTER TABLE [dbo].[Bookmark] DROP CONSTRAINT [TF_User_TF_Bookmark_FK]
GO

ALTER TABLE [dbo].[Forum] DROP CONSTRAINT [FK_Forum_SupportQueue]
GO

ALTER TABLE [dbo].[Forum] DROP CONSTRAINT [TF_Section_TF_Forum_FK1]
GO

ALTER TABLE [dbo].[ForumRoleForumActionRight] DROP CONSTRAINT [TF_ActionRight_TF_ForumRoleForumActionRight_FK1]
GO

ALTER TABLE [dbo].[ForumRoleForumActionRight] DROP CONSTRAINT [TF_Forum_TF_ForumRoleActionRight_FK1]
GO

ALTER TABLE [dbo].[ForumRoleForumActionRight] DROP CONSTRAINT [TF_Role_TF_ForumRoleActionRight_FK1]
GO

ALTER TABLE [dbo].[IPBan] DROP CONSTRAINT [FK_TF_IPBan_TF_User]
GO

ALTER TABLE [dbo].[Message] DROP CONSTRAINT [TF_Thread_TF_Message_FK1]
GO

ALTER TABLE [dbo].[Message] DROP CONSTRAINT [TF_User_TF_Message_FK1]
GO

ALTER TABLE [dbo].[PasswordResetToken] DROP CONSTRAINT [FK_9f1eaa94f1fb774bb77aad91f5d]
GO

ALTER TABLE [dbo].[RoleAuditAction] DROP CONSTRAINT [TF_AuditAction_TF_RoleAuditAction_FK1]
GO

ALTER TABLE [dbo].[RoleAuditAction] DROP CONSTRAINT [TF_Role_TF_RoleAuditAction_FK1]
GO

ALTER TABLE [dbo].[RoleSystemActionRight] DROP CONSTRAINT [TF_ActionRight_TF_RoleSystemActionRight_FK1]
GO

ALTER TABLE [dbo].[RoleSystemActionRight] DROP CONSTRAINT [TF_Role_TF_RoleSystemActionRight_FK1]
GO

ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [TF_Role_TF_RoleUser_FK1]
GO

ALTER TABLE [dbo].[RoleUser] DROP CONSTRAINT [TF_User_TF_RoleUser_FK1]
GO

ALTER TABLE [dbo].[SupportQueueThread] DROP CONSTRAINT [FK_SupportQueueThread_SupportQueue]
GO

ALTER TABLE [dbo].[SupportQueueThread] DROP CONSTRAINT [FK_SupportQueueThread_Thread]
GO

ALTER TABLE [dbo].[SupportQueueThread] DROP CONSTRAINT [FK_SupportQueueThread_User]
GO

ALTER TABLE [dbo].[SupportQueueThread] DROP CONSTRAINT [FK_SupportQueueThread_User1]
GO

ALTER TABLE [dbo].[SystemData] DROP CONSTRAINT [FK_TF_SystemData_TF_Role]
GO

ALTER TABLE [dbo].[SystemData] DROP CONSTRAINT [FK_TF_SystemData_TF_Role1]
GO

ALTER TABLE [dbo].[Thread] DROP CONSTRAINT [TF_Forum_TF_Thread_FK1]
GO

ALTER TABLE [dbo].[Thread] DROP CONSTRAINT [TF_User_TF_Thread_FK1]
GO

ALTER TABLE [dbo].[ThreadSubscription] DROP CONSTRAINT [FK_ThreadSubscription_Thread]
GO

ALTER TABLE [dbo].[ThreadSubscription] DROP CONSTRAINT [FK_ThreadSubscription_User]
GO

ALTER TABLE [dbo].[User] DROP CONSTRAINT [TF_UserTitle_TF_User_FK1]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- DROP tables for schema 'dbo' 
-- ----------------------------------------------------------------------------------------------------------------

DROP TABLE [dbo].[ActionRight]
GO

DROP TABLE [dbo].[Attachment]
GO

DROP TABLE [dbo].[AuditAction]
GO

DROP TABLE [dbo].[AuditDataCore]
GO

DROP TABLE [dbo].[AuditDataMessageRelated]
GO

DROP TABLE [dbo].[AuditDataThreadRelated]
GO

DROP TABLE [dbo].[Bookmark]
GO

DROP TABLE [dbo].[Forum]
GO

DROP TABLE [dbo].[ForumRoleForumActionRight]
GO

DROP TABLE [dbo].[IPBan]
GO

DROP TABLE [dbo].[Message]
GO

DROP TABLE [dbo].[PasswordResetToken]
GO

DROP TABLE [dbo].[Role]
GO

DROP TABLE [dbo].[RoleAuditAction]
GO

DROP TABLE [dbo].[RoleSystemActionRight]
GO

DROP TABLE [dbo].[RoleUser]
GO

DROP TABLE [dbo].[Section]
GO

DROP TABLE [dbo].[SupportQueue]
GO

DROP TABLE [dbo].[SupportQueueThread]
GO

DROP TABLE [dbo].[SystemData]
GO

DROP TABLE [dbo].[Thread]
GO

DROP TABLE [dbo].[ThreadSubscription]
GO

DROP TABLE [dbo].[User]
GO

DROP TABLE [dbo].[UserTitle]
GO
*/
-- Remove the comment marker on the PREVIOUS line to enable DROP statements to remove existing elements

-- ###############################################################################################################
-- Create statements for catalogs, schemas, tables and sequences
-- ###############################################################################################################

-- ----------------------------------------------------------------------------------------------------------------
-- Catalog 'HnD'
-- ----------------------------------------------------------------------------------------------------------------

-- CHANGE 'HnD' below if your catalog needs to have a different name!

USE master
GO
CREATE DATABASE [HnD] /* ON PRIMARY (NAME=HnD_dat, FILENAME='c:\mycatalogs\HnD.mdf', SIZE=10MB) */
GO

USE [HnD]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------

-- -------[ Tables ]-----------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[ActionRight] 
(
	[ActionRightID] [int] NOT NULL, 
	[ActionRightDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[AppliesToForum] [bit] NOT NULL, 
	[AppliesToSystem] [bit] NOT NULL 
)
GO

CREATE TABLE [dbo].[Attachment] 
(
	[AttachmentID] [int] IDENTITY (1,1) NOT NULL, 
	[MessageID] [int] NOT NULL, 
	[Filename] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Approved] [bit] NOT NULL, 
	[Filecontents] [image] NOT NULL, 
	[Filesize] [int] NOT NULL, 
	[AddedOn] [datetime] NOT NULL 
)
GO

CREATE TABLE [dbo].[AuditAction] 
(
	[AuditActionID] [int] NOT NULL, 
	[AuditActionDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
)
GO

CREATE TABLE [dbo].[AuditDataCore] 
(
	[AuditDataID] [int] IDENTITY (1,1) NOT NULL, 
	[AuditActionID] [int] NOT NULL, 
	[UserID] [int] NOT NULL, 
	[AuditedOn] [datetime] NOT NULL 
)
GO

CREATE TABLE [dbo].[AuditDataMessageRelated] 
(
	[AuditDataID] [int] NOT NULL, 
	[MessageID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[AuditDataThreadRelated] 
(
	[AuditDataID] [int] NOT NULL, 
	[ThreadID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[Bookmark] 
(
	[ThreadID] [int] NOT NULL, 
	[UserID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[Forum] 
(
	[ForumID] [int] IDENTITY (1,1) NOT NULL, 
	[SectionID] [int] NOT NULL, 
	[ForumName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ForumDescription] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ForumLastPostingDate] [datetime] NULL, 
	[HasRSSFeed] [bit] NOT NULL, 
	[DefaultSupportQueueID] [int] NULL, 
	[OrderNo] [smallint] NOT NULL, 
	[MaxAttachmentSize] [int] NULL, 
	[MaxNoOfAttachmentsPerMessage] [smallint] NULL, 
	[NewThreadWelcomeText] [ntext] NULL, 
	[NewThreadWelcomeTextAsHTML] [ntext] NULL 
)
GO

CREATE TABLE [dbo].[ForumRoleForumActionRight] 
(
	[ForumID] [int] NOT NULL, 
	[RoleID] [int] NOT NULL, 
	[ActionRightID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[IPBan] 
(
	[IPBanID] [int] IDENTITY (1,1) NOT NULL, 
	[IPSegment1] [tinyint] NOT NULL, 
	[IPSegment2] [tinyint] NOT NULL, 
	[IPSegment3] [tinyint] NOT NULL, 
	[IPSegment4] [tinyint] NOT NULL, 
	[Range] [tinyint] NOT NULL, 
	[IPBanSetByUserID] [int] NOT NULL, 
	[IPBanSetOn] [datetime] NOT NULL, 
	[Reason] [ntext] NOT NULL 
)
GO

CREATE TABLE [dbo].[Message] 
(
	[MessageID] [int] IDENTITY (1,1) NOT NULL, 
	[PostingDate] [datetime] NOT NULL, 
	[PostedByUserID] [int] NOT NULL, 
	[ThreadID] [int] NOT NULL, 
	[PostedFromIP] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[ChangeTrackerStamp] [timestamp] NOT NULL, 
	[MessageText] [ntext] NULL, 
	[MessageTextAsHTML] [ntext] NULL 
)
GO

CREATE TABLE [dbo].[PasswordResetToken] 
(
	[UserID] [int] NOT NULL, 
	[PasswordResetToken] [uniqueidentifier] NOT NULL, 
	[PasswordResetRequestedOn] [datetime] NOT NULL 
)
GO

CREATE TABLE [dbo].[Role] 
(
	[RoleID] [int] IDENTITY (1,1) NOT NULL, 
	[RoleDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
)
GO

CREATE TABLE [dbo].[RoleAuditAction] 
(
	[AuditActionID] [int] NOT NULL, 
	[RoleID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[RoleSystemActionRight] 
(
	[RoleID] [int] NOT NULL, 
	[ActionRightID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[RoleUser] 
(
	[RoleID] [int] NOT NULL, 
	[UserID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[Section] 
(
	[SectionID] [int] IDENTITY (1,1) NOT NULL, 
	[SectionName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[SectionDescription] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[OrderNo] [smallint] NOT NULL 
)
GO

CREATE TABLE [dbo].[SupportQueue] 
(
	[QueueID] [int] IDENTITY (1,1) NOT NULL, 
	[QueueName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[QueueDescription] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[OrderNo] [smallint] NOT NULL 
)
GO

CREATE TABLE [dbo].[SupportQueueThread] 
(
	[QueueID] [int] NOT NULL, 
	[ThreadID] [int] NOT NULL, 
	[PlacedInQueueByUserID] [int] NOT NULL, 
	[PlacedInQueueOn] [datetime] NOT NULL, 
	[ClaimedByUserID] [int] NULL, 
	[ClaimedOn] [datetime] NULL 
)
GO

CREATE TABLE [dbo].[SystemData] 
(
	[ID] [int] IDENTITY (1,1) NOT NULL, 
	[DefaultRoleNewUser] [int] NOT NULL, 
	[AnonymousRole] [int] NOT NULL, 
	[DefaultUserTitleNewUser] [int] NOT NULL, 
	[HoursThresholdForActiveThreads] [smallint] NOT NULL, 
	[PageSizeSearchResults] [smallint] NOT NULL, 
	[MinNumberOfThreadsToFetch] [smallint] NOT NULL, 
	[MinNumberOfNonStickyVisibleThreads] [smallint] NOT NULL, 
	[SendReplyNotifications] [bit] NOT NULL 
)
GO

CREATE TABLE [dbo].[Thread] 
(
	[ThreadID] [int] IDENTITY (1,1) NOT NULL, 
	[ForumID] [int] NOT NULL, 
	[Subject] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[StartedByUserID] [int] NOT NULL, 
	[ThreadLastPostingDate] [datetime] NULL, 
	[IsSticky] [bit] NOT NULL, 
	[IsClosed] [bit] NOT NULL, 
	[MarkedAsDone] [bit] NOT NULL, 
	[NumberOfViews] [int] NULL, 
	[Memo] [ntext] NULL 
)
GO

CREATE TABLE [dbo].[ThreadSubscription] 
(
	[UserID] [int] NOT NULL, 
	[ThreadID] [int] NOT NULL 
)
GO

CREATE TABLE [dbo].[User] 
(
	[UserID] [int] IDENTITY (1,1) NOT NULL, 
	[NickName] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Password] [nvarchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[IsBanned] [bit] NOT NULL, 
	[IPNumber] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
	[Signature] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[IconURL] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[EmailAddress] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[UserTitleID] [int] NOT NULL, 
	[DateOfBirth] [datetime] NULL, 
	[Occupation] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[Location] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[Website] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL, 
	[JoinDate] [datetime] NULL, 
	[AmountOfPostings] [int] NULL, 
	[EmailAddressIsPublic] [bit] NULL, 
	[LastVisitedDate] [datetime] NULL, 
	[AutoSubscribeToThread] [bit] NULL, 
	[DefaultNumberOfMessagesPerPage] [smallint] NULL 
)
GO

CREATE TABLE [dbo].[UserTitle] 
(
	[UserTitleID] [int] IDENTITY (1,1) NOT NULL, 
	[UserTitleDescription] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
)
GO

-- ###############################################################################################################
-- Create statements for Primary key constraints, Foreign key constraints, Unique constraints and Default Values
-- ###############################################################################################################

--------------------------------------------------------------------------------------------------------------
-- Primary Key constraints for schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[ActionRight] WITH NOCHECK 
	ADD CONSTRAINT [TF_ActionRight_PK] PRIMARY KEY CLUSTERED 
	( 
		[ActionRightID] 
	)
GO

ALTER TABLE [dbo].[Attachment] WITH NOCHECK 
	ADD CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
	( 
		[AttachmentID] 
	)
GO

ALTER TABLE [dbo].[AuditAction] WITH NOCHECK 
	ADD CONSTRAINT [TF_AuditAction_PK] PRIMARY KEY CLUSTERED 
	( 
		[AuditActionID] 
	)
GO

ALTER TABLE [dbo].[AuditDataCore] WITH NOCHECK 
	ADD CONSTRAINT [TF_AuditDataCore_PK] PRIMARY KEY CLUSTERED 
	( 
		[AuditDataID] 
	)
GO

ALTER TABLE [dbo].[AuditDataMessageRelated] WITH NOCHECK 
	ADD CONSTRAINT [TF_AuditDataMessageRelated_PK] PRIMARY KEY CLUSTERED 
	( 
		[AuditDataID] 
	)
GO

ALTER TABLE [dbo].[AuditDataThreadRelated] WITH NOCHECK 
	ADD CONSTRAINT [TF_AuditDataThreadRelated_PK] PRIMARY KEY CLUSTERED 
	( 
		[AuditDataID] 
	)
GO

ALTER TABLE [dbo].[Bookmark] WITH NOCHECK 
	ADD CONSTRAINT [TF_Bookmark_PK] PRIMARY KEY CLUSTERED 
	( 
		[ThreadID], [UserID] 
	)
GO

ALTER TABLE [dbo].[Forum] WITH NOCHECK 
	ADD CONSTRAINT [TF_Forum_PK] PRIMARY KEY CLUSTERED 
	( 
		[ForumID] 
	)
GO

ALTER TABLE [dbo].[ForumRoleForumActionRight] WITH NOCHECK 
	ADD CONSTRAINT [TF_ForumRoleActionRight_PK] PRIMARY KEY CLUSTERED 
	( 
		[ForumID], [RoleID], [ActionRightID] 
	)
GO

ALTER TABLE [dbo].[IPBan] WITH NOCHECK 
	ADD CONSTRAINT [PK_TF_IPBan] PRIMARY KEY CLUSTERED 
	( 
		[IPBanID] 
	)
GO

ALTER TABLE [dbo].[Message] WITH NOCHECK 
	ADD CONSTRAINT [TF_Message_PK] PRIMARY KEY CLUSTERED 
	( 
		[MessageID] 
	)
GO

ALTER TABLE [dbo].[PasswordResetToken] WITH NOCHECK 
	ADD CONSTRAINT [PK_446ab684e0591442b16f78fc437] PRIMARY KEY CLUSTERED 
	( 
		[UserID] 
	)
GO

ALTER TABLE [dbo].[Role] WITH NOCHECK 
	ADD CONSTRAINT [TF_Role_PK] PRIMARY KEY CLUSTERED 
	( 
		[RoleID] 
	)
GO

ALTER TABLE [dbo].[RoleAuditAction] WITH NOCHECK 
	ADD CONSTRAINT [TF_RoleAuditAction_PK] PRIMARY KEY CLUSTERED 
	( 
		[AuditActionID], [RoleID] 
	)
GO

ALTER TABLE [dbo].[RoleSystemActionRight] WITH NOCHECK 
	ADD CONSTRAINT [TF_RoleSystemActionRight_PK] PRIMARY KEY CLUSTERED 
	( 
		[RoleID], [ActionRightID] 
	)
GO

ALTER TABLE [dbo].[RoleUser] WITH NOCHECK 
	ADD CONSTRAINT [TF_RoleUser_PK] PRIMARY KEY CLUSTERED 
	( 
		[RoleID], [UserID] 
	)
GO

ALTER TABLE [dbo].[Section] WITH NOCHECK 
	ADD CONSTRAINT [TF_Section_PK] PRIMARY KEY CLUSTERED 
	( 
		[SectionID] 
	)
GO

ALTER TABLE [dbo].[SupportQueue] WITH NOCHECK 
	ADD CONSTRAINT [PK_SupportQueue] PRIMARY KEY CLUSTERED 
	( 
		[QueueID] 
	)
GO

ALTER TABLE [dbo].[SupportQueueThread] WITH NOCHECK 
	ADD CONSTRAINT [PK_SupportQueueThread] PRIMARY KEY CLUSTERED 
	( 
		[QueueID], [ThreadID] 
	)
GO

ALTER TABLE [dbo].[SystemData] WITH NOCHECK 
	ADD CONSTRAINT [PK_TF_SystemData] PRIMARY KEY CLUSTERED 
	( 
		[ID] 
	)
GO

ALTER TABLE [dbo].[Thread] WITH NOCHECK 
	ADD CONSTRAINT [TF_Thread_PK] PRIMARY KEY CLUSTERED 
	( 
		[ThreadID] 
	)
GO

ALTER TABLE [dbo].[ThreadSubscription] WITH NOCHECK 
	ADD CONSTRAINT [PK_ThreadSubscription] PRIMARY KEY CLUSTERED 
	( 
		[UserID], [ThreadID] 
	)
GO

ALTER TABLE [dbo].[User] WITH NOCHECK 
	ADD CONSTRAINT [TF_User_PK] PRIMARY KEY CLUSTERED 
	( 
		[UserID] 
	)
GO

ALTER TABLE [dbo].[UserTitle] WITH NOCHECK 
	ADD CONSTRAINT [TF_UserTitle_PK] PRIMARY KEY CLUSTERED 
	( 
		[UserTitleID] 
	)
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Unique constraints for schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[SupportQueueThread] 
	ADD CONSTRAINT [UC_SupportQueueThread_ThreadID] UNIQUE NONCLUSTERED
	(
		[ThreadID] 
	)
GO

ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [TF_User_NickName_U2] UNIQUE NONCLUSTERED
	(
		[NickName] 
	)
GO
-- ----------------------------------------------------------------------------------------------------------------
-- Default values for schema 'dbo'
-- ----------------------------------------------------------------------------------------------------------------
ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [DV_Forum_HasRSSFeed] DEFAULT ((1)) FOR [HasRSSFeed]
GO
ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [DV_Forum_OrderNo] DEFAULT ((0)) FOR [OrderNo]
GO
ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [DV_Forum_MaxAttachmentSize] DEFAULT ((512)) FOR [MaxAttachmentSize]
GO
ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [DV_Forum_MaxNoOfAttachmentsPerMessage] DEFAULT ((1)) FOR [MaxNoOfAttachmentsPerMessage]
GO
ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [DV_IPBan_IPSegment1] DEFAULT ((0)) FOR [IPSegment1]
GO
ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [DV_IPBan_IPSegment2] DEFAULT ((0)) FOR [IPSegment2]
GO
ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [DV_IPBan_IPSegment3] DEFAULT ((0)) FOR [IPSegment3]
GO
ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [DV_IPBan_IPSegment4] DEFAULT ((0)) FOR [IPSegment4]
GO
ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [DV_IPBan_IPBanSetOn] DEFAULT ((getdate())) FOR [IPBanSetOn]
GO
ALTER TABLE [dbo].[Message] 
	ADD CONSTRAINT [DV_Message_PostedFromIP] DEFAULT ('('')') FOR [PostedFromIP]
GO
ALTER TABLE [dbo].[Section] 
	ADD CONSTRAINT [DV_Section_OrderNo] DEFAULT ((0)) FOR [OrderNo]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_DefaultUserTitleNewUser] DEFAULT ((0)) FOR [DefaultUserTitleNewUser]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_HoursThresholdForActiveThreads] DEFAULT ((48)) FOR [HoursThresholdForActiveThreads]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_PageSizeSearchResults] DEFAULT ((50)) FOR [PageSizeSearchResults]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_MinNumberOfThreadsToFetch] DEFAULT ((25)) FOR [MinNumberOfThreadsToFetch]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_MinNumberOfNonStickyVisibleThreads] DEFAULT ((5)) FOR [MinNumberOfNonStickyVisibleThreads]
GO
ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [DV_SystemData_SendReplyNotifications] DEFAULT ((1)) FOR [SendReplyNotifications]
GO
ALTER TABLE [dbo].[Thread] 
	ADD CONSTRAINT [DV_Thread_MarkedAsDone] DEFAULT ((1)) FOR [MarkedAsDone]
GO
ALTER TABLE [dbo].[Thread] 
	ADD CONSTRAINT [DV_Thread_NumberOfViews] DEFAULT ((0)) FOR [NumberOfViews]
GO
ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [DV_User_JoinDate] DEFAULT ((getdate())) FOR [JoinDate]
GO
ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [DV_User_AmountOfPostings] DEFAULT ((0)) FOR [AmountOfPostings]
GO
ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [DV_User_EmailAddressIsPublic] DEFAULT ((0)) FOR [EmailAddressIsPublic]
GO
ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [DV_User_AutoSubscribeToThread] DEFAULT ((1)) FOR [AutoSubscribeToThread]
GO
ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [DV_User_DefaultNumberOfMessagesPerPage] DEFAULT ((25)) FOR [DefaultNumberOfMessagesPerPage]
GO
-- ----------------------------------------------------------------------------------------------------------------
-- All foreign Key constraints
-- ----------------------------------------------------------------------------------------------------------------

ALTER TABLE [dbo].[Attachment] 
	ADD CONSTRAINT [FK_Attachment_Message] FOREIGN KEY
	(
		[MessageID] 
	)
	REFERENCES [dbo].[Message]
	(
		[MessageID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataCore] 
	ADD CONSTRAINT [TF_AuditDataCore_TF_AuditAction_FK1] FOREIGN KEY
	(
		[AuditActionID] 
	)
	REFERENCES [dbo].[AuditAction]
	(
		[AuditActionID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataCore] 
	ADD CONSTRAINT [TF_User_TF_AuditDataCore_FK1] FOREIGN KEY
	(
		[UserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataMessageRelated] 
	ADD CONSTRAINT [TF_AuditDataMessageRelated_TF_AuditDataCore_FK1] FOREIGN KEY
	(
		[AuditDataID] 
	)
	REFERENCES [dbo].[AuditDataCore]
	(
		[AuditDataID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataMessageRelated] 
	ADD CONSTRAINT [TF_AuditDataMessageRelated_TF_Message_FK1] FOREIGN KEY
	(
		[MessageID] 
	)
	REFERENCES [dbo].[Message]
	(
		[MessageID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataThreadRelated] 
	ADD CONSTRAINT [TF_AuditDataThreadRelated_TF_AuditDataCore_FK1] FOREIGN KEY
	(
		[AuditDataID] 
	)
	REFERENCES [dbo].[AuditDataCore]
	(
		[AuditDataID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[AuditDataThreadRelated] 
	ADD CONSTRAINT [TF_AuditDataThreadRelated_TF_Thread_FK1] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Bookmark] 
	ADD CONSTRAINT [TF_Thread_TF_Bookmark_FK] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Bookmark] 
	ADD CONSTRAINT [TF_User_TF_Bookmark_FK] FOREIGN KEY
	(
		[UserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [FK_Forum_SupportQueue] FOREIGN KEY
	(
		[DefaultSupportQueueID] 
	)
	REFERENCES [dbo].[SupportQueue]
	(
		[QueueID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Forum] 
	ADD CONSTRAINT [TF_Section_TF_Forum_FK1] FOREIGN KEY
	(
		[SectionID] 
	)
	REFERENCES [dbo].[Section]
	(
		[SectionID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ForumRoleForumActionRight] 
	ADD CONSTRAINT [TF_ActionRight_TF_ForumRoleForumActionRight_FK1] FOREIGN KEY
	(
		[ActionRightID] 
	)
	REFERENCES [dbo].[ActionRight]
	(
		[ActionRightID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ForumRoleForumActionRight] 
	ADD CONSTRAINT [TF_Forum_TF_ForumRoleActionRight_FK1] FOREIGN KEY
	(
		[ForumID] 
	)
	REFERENCES [dbo].[Forum]
	(
		[ForumID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ForumRoleForumActionRight] 
	ADD CONSTRAINT [TF_Role_TF_ForumRoleActionRight_FK1] FOREIGN KEY
	(
		[RoleID] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[IPBan] 
	ADD CONSTRAINT [FK_TF_IPBan_TF_User] FOREIGN KEY
	(
		[IPBanSetByUserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Message] 
	ADD CONSTRAINT [TF_Thread_TF_Message_FK1] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Message] 
	ADD CONSTRAINT [TF_User_TF_Message_FK1] FOREIGN KEY
	(
		[PostedByUserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[PasswordResetToken] 
	ADD CONSTRAINT [FK_9f1eaa94f1fb774bb77aad91f5d] FOREIGN KEY
	(
		[UserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE CASCADE
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleAuditAction] 
	ADD CONSTRAINT [TF_AuditAction_TF_RoleAuditAction_FK1] FOREIGN KEY
	(
		[AuditActionID] 
	)
	REFERENCES [dbo].[AuditAction]
	(
		[AuditActionID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleAuditAction] 
	ADD CONSTRAINT [TF_Role_TF_RoleAuditAction_FK1] FOREIGN KEY
	(
		[RoleID] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleSystemActionRight] 
	ADD CONSTRAINT [TF_ActionRight_TF_RoleSystemActionRight_FK1] FOREIGN KEY
	(
		[ActionRightID] 
	)
	REFERENCES [dbo].[ActionRight]
	(
		[ActionRightID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleSystemActionRight] 
	ADD CONSTRAINT [TF_Role_TF_RoleSystemActionRight_FK1] FOREIGN KEY
	(
		[RoleID] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleUser] 
	ADD CONSTRAINT [TF_Role_TF_RoleUser_FK1] FOREIGN KEY
	(
		[RoleID] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[RoleUser] 
	ADD CONSTRAINT [TF_User_TF_RoleUser_FK1] FOREIGN KEY
	(
		[UserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SupportQueueThread] 
	ADD CONSTRAINT [FK_SupportQueueThread_SupportQueue] FOREIGN KEY
	(
		[QueueID] 
	)
	REFERENCES [dbo].[SupportQueue]
	(
		[QueueID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SupportQueueThread] 
	ADD CONSTRAINT [FK_SupportQueueThread_Thread] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SupportQueueThread] 
	ADD CONSTRAINT [FK_SupportQueueThread_User] FOREIGN KEY
	(
		[PlacedInQueueByUserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SupportQueueThread] 
	ADD CONSTRAINT [FK_SupportQueueThread_User1] FOREIGN KEY
	(
		[ClaimedByUserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [FK_TF_SystemData_TF_Role] FOREIGN KEY
	(
		[DefaultRoleNewUser] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[SystemData] 
	ADD CONSTRAINT [FK_TF_SystemData_TF_Role1] FOREIGN KEY
	(
		[AnonymousRole] 
	)
	REFERENCES [dbo].[Role]
	(
		[RoleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Thread] 
	ADD CONSTRAINT [TF_Forum_TF_Thread_FK1] FOREIGN KEY
	(
		[ForumID] 
	)
	REFERENCES [dbo].[Forum]
	(
		[ForumID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[Thread] 
	ADD CONSTRAINT [TF_User_TF_Thread_FK1] FOREIGN KEY
	(
		[StartedByUserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ThreadSubscription] 
	ADD CONSTRAINT [FK_ThreadSubscription_Thread] FOREIGN KEY
	(
		[ThreadID] 
	)
	REFERENCES [dbo].[Thread]
	(
		[ThreadID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[ThreadSubscription] 
	ADD CONSTRAINT [FK_ThreadSubscription_User] FOREIGN KEY
	(
		[UserID] 
	)
	REFERENCES [dbo].[User]
	(
		[UserID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO


ALTER TABLE [dbo].[User] 
	ADD CONSTRAINT [TF_UserTitle_TF_User_FK1] FOREIGN KEY
	(
		[UserTitleID] 
	)
	REFERENCES [dbo].[UserTitle]
	(
		[UserTitleID] 
	)
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
GO

CREATE  UNIQUE  INDEX [TF_Section_AK1] ON [dbo].[Section]([SectionName]) ON [PRIMARY]
GO

CREATE  UNIQUE  INDEX [TF_Section_AK2] ON [dbo].[Section]([SectionDescription]) ON [PRIMARY]
GO

-- ----------------------------------------------------------------------------------------------------------------
-- All Indices
-- ----------------------------------------------------------------------------------------------------------------

CREATE INDEX [Ix_Message_ThreadID] ON [dbo].[Message]([ThreadID]) ON [PRIMARY]
GO

CREATE INDEX [Ix_Message_PostedByUserId] ON [dbo].[Message]([PostedByUserID]) ON [PRIMARY]
GO

CREATE  UNIQUE  INDEX [TF_Role_AK1] ON [dbo].[Role]([RoleDescription]) ON [PRIMARY]
GO

CREATE  INDEX [Ix_RoleUser_UserID] ON [dbo].[RoleUser]([UserID]) ON [PRIMARY]
GO

CREATE  INDEX [IX_SupportQueueThread_QueueID] ON [dbo].[SupportQueueThread]([QueueID]) ON [PRIMARY]
GO

CREATE  INDEX [IX_SupportQueueThread_ThreadID] ON [dbo].[SupportQueueThread]([ThreadID]) ON [PRIMARY]
GO

CREATE  INDEX [IX_SupportQueueThread_PlacedInQueueByUserID] ON [dbo].[SupportQueueThread]([PlacedInQueueByUserID]) ON [PRIMARY]
GO

CREATE  INDEX [IX_SupportQueueThread_ClaimedByUserID] ON [dbo].[SupportQueueThread]([ClaimedByUserID]) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** Object:  Stored Procedure dbo.pr_Install    Script Date: 14-9-2008 13:17:21 ******/

-----------------------
-- Installs all necessary data to get the HnD system up and running.
CREATE PROCEDURE [pr_Install]
	@sAdminEmailAddress nvarchar(150), @sAdminPasswordHashed nvarchar(128)
AS
DECLARE	@iAnonymousRoleID int,
	@iAdminRoleID int,
	@iUserRoleID int,
	@iUserID int,
	@iUserTitleID int,
	@iForumID int,
	@iSectionID int

SET IDENTITY_INSERT [User] ON

-- CREATE ActionRights
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (1, N'Add and Edit Message', 1, 0)	-- add a new message and edit your own
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (2, N'Access Forum', 1, 0) 		-- have access to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (3, N'User Management', 0, 1)		-- set all kinds of userproperties/rights
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (4, N'Security Management', 0, 1)		-- set rights on roles, create new roles, assign roles to forums etc.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (5, N'Edit And Delete Other Users Messages', 1,0)	-- edit other users' messages
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (6, N'Forum Specific Thread Management', 1, 0)	-- edit thread's properties like sticky and closed, and move threads
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (7, N'System Management', 0, 1)		-- change system settings like new section/forum etc.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (8, N'Add and Edit Message in Sticky Thread', 1, 0)	-- add a new message to a sticky thread and edit your own 
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (9, N'System Wide Thread Management', 0, 1) -- administrate threads system wide.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (10, N'Add Normal Thread', 1, 0) -- Add a normal thread to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (11, N'Add Sticky Thread', 1, 0) -- Add a sticky thread to a forum
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (12, N'Edit Thread Memo', 1, 0) -- Edit the memo field of a thread
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (13, N'Flag Thread As Done', 1, 0) -- Flag a thread not started by the user as done.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (14, N'Queue Content Management', 0, 1) -- perform content management of support queues.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (15, N'View Normal Threads Started by Others', 1, 0) -- view threads started by others in threadview and message view.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (16, N'Manage Other Users Attachments', 1, 0) -- ability to manage/delete attachments of others
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (17, N'Add Attachment', 1, 0) -- Add an attachment to a message (and also delete it)
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (18, N'Gets Attachments Approved Automatically', 1, 0) -- Attachments added are approved automatically.
INSERT ActionRight (ActionRightID, ActionRightDescription, AppliesToForum, AppliesToSystem)
	VALUES (19, N'Approve Attachment', 1, 0) -- Ability to approve and revoke approval of an attachment of a person.

-- CREATE Administrators Role
INSERT Role (RoleDescription)
	VALUES (N'Administrators Role')
SELECT @iAdminRoleID = SCOPE_IDENTITY()
-- CREATE UserTitle entry
INSERT UserTitle (UserTitleDescription)
	VALUES (N'Administrator')
SELECT @iUserTitleID = SCOPE_IDENTITY()
-- CREATE Admin user, which is always user id 1
INSERT [User] (UserID, NickName, Password, IsBanned, IPNumber, Signature, IconURL, EmailAddress, UserTitleID, DateOfBirth, Occupation, Location, Website, 
			   JoinDate, AmountOfPostings, EmailAddressIsPublic)
	VALUES (1, N'Admin', @sAdminPasswordHashed, 0, N'', N'', N'', @sAdminEmailAddress, @iUserTitleID, NULL, N'', N'', N'', GETDATE(), 0, 0)
SELECT @iUserID = SCOPE_IDENTITY()
-- Add new admin user to new role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iAdminRoleID, @iUserID)

-- Add system rights to new role
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 3)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 4)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 7)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 9)
INSERT RoleSystemActionRight (RoleID, ActionRightID)
	VALUES (@iAdminRoleID, 14)

-- CREATE Default User role
INSERT Role (RoleDescription)
	VALUES (N'User Role')
SELECT @iUserRoleID = SCOPE_IDENTITY()
-- Add admin to this role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iUserRoleID, @iUserID)

-- CREATE Anonymous Role
INSERT Role (RoleDescription)
	VALUES (N'Anonymous user Role')
SELECT @iAnonymousRoleID = SCOPE_IDENTITY()

-- CREATE UserTitle entry
INSERT UserTitle (UserTitleDescription)
	VALUES (N'User')
SELECT @iUserTitleID = SCOPE_IDENTITY()

-- CREATE Anonymous user. 
INSERT [User] (UserID, NickName, Password, IsBanned, IPNumber, Signature, IconURL, EmailAddress, UserTitleID, DateOfBirth, Occupation, Location, Website, 
			   JoinDate, AmountOfPostings, EmailAddressIsPublic)
	VALUES (0, N'Anonymous', N'', 0, N'', N'', N'', N'', @iUserTitleID, NULL, N'', N'', N'', GETDATE(), 0, 0)
-- Add anonymous user to anonymous role
INSERT RoleUser (RoleID, UserID)
	VALUES (@iAnonymousRoleID, 0)

-- Insert the one row in the system data table. Set the values to the defaults. 
INSERT SystemData(DefaultRoleNewUser, AnonymousRole, DefaultUserTitleNewUser, HoursThresholdForActiveThreads, PageSizeSearchResults, 
				  MinNumberOfThreadsToFetch, MinNumberOfNonStickyVisibleThreads, SendReplyNotifications)
	VALUES (@iUserRoleID, @iAnonymousRoleID, @iUserTitleID, 48, 25, 25, 5, 1)

-- Create General Section
INSERT Section (SectionName, SectionDescription)
	VALUES (N'General', N'Section with general forums')
SELECT @iSectionID = SCOPE_IDENTITY()

-- Create General forum, place it in the general section
INSERT Forum (SectionID, ForumName, ForumDescription, ForumLastPostingDate)
	VALUES (@iSectionID, N'General Chat', N'Forum for offtopic talk', NULL)
SELECT @iForumID = SCOPE_IDENTITY()

-- Add all action rights which apply to forum for the admin role to the general chat forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	SELECT 	@iForumID AS ForumID, 
		@iAdminRoleID,
		ActionRightID
	FROM ActionRight
	WHERE AppliesToForum = 1

-- Add User role with the edit/add rights to this forum.
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 1)
-- Add User role with the access forum right to this forum.
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 2)
-- Add User role with the view other people's threads right to this forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iUserRoleID, 15)

-- Add Anonymous role with the access forum right to this forum
INSERT ForumRoleForumActionRight (ForumID, RoleID, ActionRightID)
	VALUES(@iForumID, @iAnonymousRoleID, 2)

-- Add audit actions
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (1, N'Audit login')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (2, N'Audit new message')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (3, N'Audit new thread')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (4, N'Audit altered message')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (5, N'Audit edit memo')
INSERT AuditAction (AuditActionID, AuditActionDescription) VALUES (6, N'Audit approve attachment')
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

