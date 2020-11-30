USE [Horderns]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 12/1/2020 4:16:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Honor] [varchar](max) NULL,
	[Name] [varchar](max) NOT NULL,
	[Address1] [varchar](max) NOT NULL,
	[Address2] [varchar](max) NOT NULL,
	[Address3] [varchar](max) NOT NULL,
	[Post Code] [varchar](max) NOT NULL,
	[Tel] [varchar](max) NOT NULL,
	[Email] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

