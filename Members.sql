USE [demoDb]
GO

/****** Object:  Table [dbo].[Members]    Script Date: 29-01-2022 11:56:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Members](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RelationId] [bigint] NOT NULL,
	[members] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [RelationId] FOREIGN KEY([RelationId])
REFERENCES [dbo].[Relationship] ([RelationId])
GO

ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [RelationId]
GO

