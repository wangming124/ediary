USE [Horderns]
GO

/****** Object:  Table [dbo].[JobType]    Script Date: 12/1/2020 12:15:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JobType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type Name] [varchar](max) NULL,
	[Background Color] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

