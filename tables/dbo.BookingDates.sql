USE [Horderns]
GO

/****** Object:  Table [dbo].[BookingDates]    Script Date: 12/1/2020 4:16:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BookingDates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[hours] [float] NOT NULL,
	[note] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

