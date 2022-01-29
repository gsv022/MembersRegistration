USE [demoDb]
GO

/****** Object:  Table [dbo].[Relationship]    Script Date: 29-01-2022 11:55:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Relationship](
	[RelationId] [bigint] NOT NULL,
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[ApplicationId] [bigint] NOT NULL,
	[Relation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Relationship_1] PRIMARY KEY CLUSTERED 
(
	[RelationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Relationship]  WITH CHECK ADD  CONSTRAINT [ApplicationId] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[ProfileCreation] ([ApplicationId])
GO

ALTER TABLE [dbo].[Relationship] CHECK CONSTRAINT [ApplicationId]
GO

ALTER TABLE [dbo].[Relationship]  WITH CHECK ADD  CONSTRAINT [FK_Relationship_UserRegistration] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO

ALTER TABLE [dbo].[Relationship] CHECK CONSTRAINT [FK_Relationship_UserRegistration]
GO

