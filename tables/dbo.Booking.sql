USE [Horderns]
GO

/****** Object:  Table [dbo].[Booking]    Script Date: 12/1/2020 4:15:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Booking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Job NO] [varchar](max) NOT NULL,
	[Job Type] [varchar](max) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Service Plan] [varchar](max) NOT NULL,
	[Vehicle Make] [varchar](max) NOT NULL,
	[Vehicle Model] [varchar](max) NOT NULL,
	[Vehicle Reg.NO] [varchar](max) NOT NULL,
	[Mileage] [bigint] NOT NULL,
	[Job Description] [varchar](max) NOT NULL,
	[Loan Car] [varchar](max) NOT NULL,
	[Time In] [float] NOT NULL,
	[Time Out] [float] NOT NULL,
	[Booked By] [varchar](max) NOT NULL,
	[Estimated Time] [float] NOT NULL,
	[Time Remaining] [float] NOT NULL,
	[Insurance Required] [varchar](max) NOT NULL,
	[Notes] [varchar](max) NOT NULL,
	[Booking Date] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

