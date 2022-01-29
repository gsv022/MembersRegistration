USE [demoDb]
GO

/****** Object:  Table [dbo].[ProfileCreation]    Script Date: 29-01-2022 11:56:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProfileCreation](
	[ApplicationId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Suffix] [nvarchar](10) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gender] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_ProfileCreation] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProfileCreation]  WITH CHECK ADD  CONSTRAINT [UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserRegistration] ([UserId])
GO

ALTER TABLE [dbo].[ProfileCreation] CHECK CONSTRAINT [UserId]
GO

