USE [ecomDB]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Nat_ID] [int] NOT NULL,
	[Fname] [nvarchar](30) NOT NULL,
	[fathername] [nvarchar](30) NOT NULL,
	[lname] [nvarchar](30) NOT NULL,
	[Birth_Date] [date] NOT NULL,
	[UserType] [int] NOT NULL,
	[status] [int] NOT NULL,
	[RatePoints] [smallint] NULL,
	[phone] [varchar](30) NOT NULL,
	[email] [varchar](30) NOT NULL,
	[GovId] [int] NOT NULL,
	[City] [nvarchar](30) NULL,
	[address] [varchar](50) NULL,
	[Homelocation] [varchar](50) NULL,
	[gender] [bit] NOT NULL,
 CONSTRAINT [PKnational] PRIMARY KEY CLUSTERED 
(
	[Nat_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserType]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] NOT NULL,
	[Descreption] [nvarchar](30) NULL,
 CONSTRAINT [UTID] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Governorate]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Governorate](
	[govID] [int] NOT NULL,
	[govName] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[govID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewCustomers]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewCustomers] AS 
SELECT fname , fathername , lname , [status], phone,email , G.govName,city , Homelocation
FROM userinfo U join UserType T on T.UserTypeID = U.UserType join Governorate G on G.govID = U.GovId
where UserTypeID= 1 
GO
/****** Object:  View [dbo].[ViewSellers]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewSellers] AS 
SELECT fname , fathername , lname , [status], phone,email , G.govName,city , Homelocation
FROM userinfo U join UserType T on T.UserTypeID = U.UserType join Governorate G on G.govID = U.GovId
where UserTypeID= 2
GO
/****** Object:  Table [dbo].[transporter]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transporter](
	[userID] [int] NOT NULL,
	[licensID] [int] NOT NULL,
	[VechileNO] [varchar](30) NOT NULL,
	[vechileType] [varchar](30) NOT NULL,
	[LicenseValidity] [date] NULL,
 CONSTRAINT [transID] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [licIDun] UNIQUE NONCLUSTERED 
(
	[licensID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [VechNOun] UNIQUE NONCLUSTERED 
(
	[VechileNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewTransporters]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewTransporters] AS 
SELECT fname , fathername , lname , [status], phone,email , G.govName,city , Homelocation ,
TR.vechileType , TR.VechileNO
FROM userinfo U join UserType T on T.UserTypeID = U.UserType 
join Governorate G on G.govID = U.GovId
join transporter TR ON TR.userID = U.Nat_ID
where UserTypeID= 3
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[empID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[SocialInsuranceID] [int] NOT NULL,
	[Qualfication] [nvarchar](30) NOT NULL,
	[Institute] [nvarchar](50) NOT NULL,
	[AuthorityLevel] [int] NOT NULL,
	[SupervisedBY] [int] NOT NULL,
 CONSTRAINT [UIDPK] PRIMARY KEY CLUSTERED 
(
	[empID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [SocialInsuranceUN] UNIQUE NONCLUSTERED 
(
	[SocialInsuranceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewEmployees]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewEmployees] AS 
SELECT fname , fathername , lname , [status], E.SocialInsuranceID,E.Institute,E.AuthorityLevel, phone, email , G.govName ,city ,[address]
FROM userinfo U join UserType T on T.UserTypeID = U.UserType join Governorate G on G.govID = U.GovId
Join Employee E ON E.userID =U.Nat_ID
where UserTypeID= 4
GO
/****** Object:  Table [dbo].[AuthorityLevel]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorityLevel](
	[ID] [int] NOT NULL,
	[Title] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[dispute]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dispute](
	[disputid] [int] NOT NULL,
	[orederID] [int] NOT NULL,
	[arbiterID] [int] NOT NULL,
	[result] [varchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[finishDate] [datetime] NOT NULL,
	[status] [varchar](30) NULL,
	[TimeToFinish] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[disputid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[userID] [int] NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[Order_ID] [int] NOT NULL,
	[USER_ID] [int] NOT NULL,
	[Service_ID] [int] NOT NULL,
	[ShippmentId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[ORDER_status] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[finishDate] [date] NOT NULL,
	[closeCode] [smallint] NOT NULL,
	[RatePoint] [smallint] NOT NULL,
 CONSTRAINT [PKorder] PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Report]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Report_ID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[type] [int] NOT NULL,
	[empID] [int] NOT NULL,
	[Files] [binary](300) NULL,
 CONSTRAINT [PKReport] PRIMARY KEY CLUSTERED 
(
	[Report_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportTypes]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTypes](
	[ID] [int] NOT NULL,
	[Description] [nvarchar](30) NULL,
 CONSTRAINT [PKReportType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Service]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Service_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Cat_ID] [int] NOT NULL,
	[Desc] [nvarchar](50) NOT NULL,
	[Physicalitems] [bit] NOT NULL,
	[deliveryTime] [datetime] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PKService] PRIMARY KEY CLUSTERED 
(
	[Service_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServiceCategory]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategory](
	[CatID] [int] NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PKServiceCat] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 08/31/2020 07:06:31 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[shipmentID] [int] NOT NULL,
	[TransporterID] [int] NOT NULL,
	[ShippingDate] [date] NOT NULL,
	[ShippingFees] [decimal](18, 0) NOT NULL,
	[PickUpLocation] [varchar](50) NULL,
	[deliverylocation] [varchar](50) NULL,
 CONSTRAINT [PKshipID] PRIMARY KEY CLUSTERED 
(
	[shipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserInfo] ADD  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[dispute]  WITH CHECK ADD  CONSTRAINT [FKarbiterID] FOREIGN KEY([arbiterID])
REFERENCES [dbo].[Employee] ([empID])
GO
ALTER TABLE [dbo].[dispute] CHECK CONSTRAINT [FKarbiterID]
GO
ALTER TABLE [dbo].[dispute]  WITH CHECK ADD  CONSTRAINT [FKorderNID] FOREIGN KEY([orederID])
REFERENCES [dbo].[order] ([Order_ID])
GO
ALTER TABLE [dbo].[dispute] CHECK CONSTRAINT [FKorderNID]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FKauthorityLevel] FOREIGN KEY([AuthorityLevel])
REFERENCES [dbo].[AuthorityLevel] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FKauthorityLevel]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FKemployee] FOREIGN KEY([SupervisedBY])
REFERENCES [dbo].[Employee] ([empID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FKemployee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [fkUserinfo] FOREIGN KEY([userID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [fkUserinfo]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FKLogin] FOREIGN KEY([userID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FKLogin]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FKorderuserID] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FKorderuserID]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FKserviceID] FOREIGN KEY([Service_ID])
REFERENCES [dbo].[Service] ([Service_ID])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FKserviceID]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FKshipID] FOREIGN KEY([ShippmentId])
REFERENCES [dbo].[Shipment] ([shipmentID])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FKshipID]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FKemprepoID] FOREIGN KEY([empID])
REFERENCES [dbo].[Employee] ([empID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FKemprepoID]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FKrpotype] FOREIGN KEY([type])
REFERENCES [dbo].[ReportTypes] ([ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FKrpotype]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FKuserID] FOREIGN KEY([userID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FKuserID]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FKcatuserID] FOREIGN KEY([Cat_ID])
REFERENCES [dbo].[ServiceCategory] ([CatID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FKcatuserID]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FKserviceuserID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FKserviceuserID]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [FKshepoID] FOREIGN KEY([TransporterID])
REFERENCES [dbo].[transporter] ([userID])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [FKshepoID]
GO
ALTER TABLE [dbo].[transporter]  WITH CHECK ADD  CONSTRAINT [FKtransID] FOREIGN KEY([userID])
REFERENCES [dbo].[UserInfo] ([Nat_ID])
GO
ALTER TABLE [dbo].[transporter] CHECK CONSTRAINT [FKtransID]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [fk_govID] FOREIGN KEY([GovId])
REFERENCES [dbo].[Governorate] ([govID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [fk_govID]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FKUserType] FOREIGN KEY([UserType])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FKUserType]
GO
