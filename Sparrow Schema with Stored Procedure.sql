USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetCarInsurancePolicyReport]    Script Date: 3/20/2016 10:36:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCarInsurancePolicyReport]
(
	@FromDate datetime,
	@ToDate	datetime
)
AS
SELECT PlateNo, PolicyNo, CONVERT(varchar, CONVERT(VarChar, Effectivity, 101)) as Effectivity, 
CONVERT(varchar, CONVERT(varchar,Expiration_Date, 101)) as Expiration_Date, Assured, Car_Make, 
YearModel, SerialNo, MotorNo  FROM CarInsurancePolicy

WHERE CreateDate between @FromDate and @ToDate
ORDER BY CreateDate ASC
GO
/****** Object:  StoredProcedure [dbo].[GetIncomeReport]    Script Date: 3/20/2016 10:36:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIncomeReport]
(
	@FromDate datetime,
	@TODate datetime
)
as
SELECT PolicyNo, Assured, YearModel, PlateNo, Mortagee, Deductible, TotalAnnualPremium, Gross, Net, Paid, (Gross-TotalAnnualPremium) as Income FROM CarInsurancePolicy
WHERE CreateDate between @FromDate and @TODate
ORDER BY CreateDate ASC
GO
/****** Object:  StoredProcedure [dbo].[GetSalesAgentReport]    Script Date: 3/20/2016 10:36:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSalesAgentReport]
(
	@SalesAgent uniqueidentifier,
	@FromDate datetime,
	@ToDate datetime
)
as


SELECT car.PolicyNo, car.Assured, car.YearModel, car.PlateNo, car.Mortagee, car.Deductible, 
car.TotalAnnualPremium, car.Gross, car.Net, car.Paid, 
(car.Gross-car.TotalAnnualPremium) as Income, car.Agent, sales.FullName
FROM CarInsurancePolicy as car
LEFT JOIN SalesAgent as sales
ON car.Agent = sales.ID
WHERE car.CreateDate between @FromDate and @ToDate
AND
car.Agent = @SalesAgent

ORDER BY car.CreateDate ASC
GO
/****** Object:  Table [dbo].[BankProfile]    Script Date: 3/20/2016 10:36:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankProfile](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarInsuranceCommission]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarInsuranceCommission](
	[ID] [uniqueidentifier] NOT NULL,
	[CarInsurancePolicyID] [uniqueidentifier] NOT NULL,
	[SalesAgent] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [varbinary](200) NULL,
 CONSTRAINT [PK_CarInsuranceCommission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarInsuranceCoverage]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarInsuranceCoverage](
	[ID] [uniqueidentifier] NOT NULL,
	[A_LossAndDamage] [decimal](18, 2) NULL,
	[A_CTPL] [decimal](18, 2) NULL,
	[A_ExcessBodilyInjury] [decimal](18, 2) NULL,
	[A_VolPropertyDamage] [decimal](18, 2) NULL,
	[A_PersonalAccident] [decimal](18, 2) NULL,
	[A_MR] [decimal](18, 2) NULL,
	[A_Total] [decimal](18, 2) NULL,
	[P_LossAndDamage] [decimal](18, 2) NULL,
	[P_CPTL] [decimal](18, 2) NULL,
	[P_ExcessBodilyInjury] [decimal](18, 2) NULL,
	[P_VolPropertyDamage] [decimal](18, 2) NULL,
	[P_PersonalAccident] [decimal](18, 2) NULL,
	[P_MR] [decimal](18, 2) NULL,
	[P_Total] [decimal](18, 2) NULL,
	[P_AdditionalCharges] [decimal](18, 2) NULL,
	[P_DocumentaryTax] [decimal](18, 2) NULL,
	[P_EVAT] [decimal](18, 2) NULL,
	[P_LocalGovernmentTax] [decimal](18, 2) NULL,
	[TotalAnnualPremium] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CarInsuranceCoverage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarInsurancePolicy]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarInsurancePolicy](
	[ID] [uniqueidentifier] NOT NULL,
	[Assured] [varchar](150) NULL,
	[Address] [varchar](250) NULL,
	[YearModel] [varchar](5) NULL,
	[SerialNo] [varchar](50) NULL,
	[MotorNo] [varchar](50) NULL,
	[PlateNo] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Mortagee] [varchar](50) NULL,
	[Deductible] [varchar](50) NULL,
	[CreateBy] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[Aircon] [varchar](1) NULL,
	[SterioSpeakers] [varchar](1) NULL,
	[Magwheels] [varchar](1) NULL,
	[Others] [varchar](200) NULL,
	[Status] [varchar](20) NULL,
	[CarInsuranceCoverageID] [uniqueidentifier] NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [uniqueidentifier] NULL,
	[Effectivity] [datetime] NULL,
	[Unit] [varchar](150) NULL,
	[TotalAnnualPremium] [decimal](18, 2) NULL,
	[A_LossAndDamage] [decimal](18, 2) NULL,
	[A_CTPL] [decimal](18, 2) NULL,
	[A_ExcessBodilyInjury] [decimal](18, 2) NULL,
	[A_VolPropertyDamage] [decimal](18, 2) NULL,
	[P_PersonalAccident] [decimal](18, 2) NULL,
	[P_MR] [decimal](18, 2) NULL,
	[P_Total] [decimal](18, 2) NULL,
	[P_AdditionalCharges] [decimal](18, 2) NULL,
	[P_DocumentaryTax] [decimal](18, 2) NULL,
	[P_EVAT] [decimal](18, 2) NULL,
	[P_LocalGovernmentTax] [decimal](18, 2) NULL,
	[P_LossAndDamage] [decimal](18, 2) NULL,
	[P_CTPL] [decimal](18, 2) NULL,
	[P_ExcessBodilyInjury] [decimal](18, 2) NULL,
	[P_VolPropertyDamage] [decimal](18, 2) NULL,
	[Agent] [uniqueidentifier] NOT NULL,
	[PolicyNo] [varchar](50) NULL,
	[Paid] [decimal](18, 2) NOT NULL,
	[Payment_Method] [varchar](50) NULL,
	[Car_Class] [varchar](50) NULL,
	[Car_Make] [varchar](100) NULL,
	[Gross] [decimal](18, 2) NULL,
	[Net] [decimal](18, 2) NULL,
	[Category] [varchar](30) NULL,
	[Expiration_Date] [datetime] NULL,
 CONSTRAINT [PK_CarInsurancePolicy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarInsurrancePayment]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CarInsurrancePayment](
	[ID] [uniqueidentifier] NOT NULL,
	[CarInsurancePolicyID] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Method] [varchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[BankID] [uniqueidentifier] NULL,
	[Remarks] [varchar](200) NULL,
	[Status] [varchar](20) NULL,
	[Check_No] [varchar](50) NULL,
	[Check_Date] [datetime] NULL,
	[Check_Name] [varchar](150) NULL,
 CONSTRAINT [PK_CarInsurrancePayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MakeProfile]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MakeProfile](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](300) NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesAgent]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesAgent](
	[ID] [uniqueidentifier] NOT NULL,
	[AgentNo] [varchar](10) NOT NULL,
	[FirstName] [varchar](80) NOT NULL,
	[LastName] [varchar](80) NOT NULL,
	[MiddleName] [varchar](80) NULL,
	[FullName] [varchar](200) NULL,
 CONSTRAINT [PK_SalesAgent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](80) NOT NULL,
	[LastName] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[Username] [varchar](50) NOT NULL,
	[Hash] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 3/20/2016 10:36:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[RoleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CarInsurancePolicy]  WITH CHECK ADD  CONSTRAINT [FK_CarInsurancePolicy_CarInsuranceCoverage] FOREIGN KEY([CarInsuranceCoverageID])
REFERENCES [dbo].[CarInsuranceCoverage] ([ID])
GO
ALTER TABLE [dbo].[CarInsurancePolicy] CHECK CONSTRAINT [FK_CarInsurancePolicy_CarInsuranceCoverage]
GO
