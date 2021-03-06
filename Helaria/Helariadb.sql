USE [Helarai]
GO
/****** Object:  Table [dbo].[Helaria]    Script Date: 25/04/2017 12:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Helaria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Venue] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
	[Time] [datetime] NULL,
	[Price] [decimal](18, 2) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Helaria] ON 

INSERT [dbo].[Helaria] ([Id], [Title], [Venue], [Date], [Time], [Price]) VALUES (5, N'Eve', N'Tema', CAST(N'2017-04-10 00:00:00.000' AS DateTime), CAST(N'1900-01-01 11:59:41.000' AS DateTime), CAST(598.00 AS Decimal(18, 2)))
INSERT [dbo].[Helaria] ([Id], [Title], [Venue], [Date], [Time], [Price]) VALUES (4, N'House party', N'Accra', CAST(N'2017-04-25 00:00:00.000' AS DateTime), CAST(N'1900-01-01 11:54:11.000' AS DateTime), CAST(589355.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Helaria] OFF
