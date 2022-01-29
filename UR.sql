USE [demoDb]
GO

/****** Object:  Table [dbo].[UserRegistration]    Script Date: 29-01-2022 11:55:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRegistration](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[ConfirmPassword] [nvarchar](30) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

