USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetCarInsurancePolicyReport]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetIncomeReport]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetSalesAgentReport]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[BankProfile]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[CarInsuranceCommission]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[CarInsuranceCoverage]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[CarInsurancePolicy]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[CarInsurrancePayment]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[MakeProfile]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[SalesAgent]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 3/20/2016 10:42:32 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 3/20/2016 10:42:32 PM ******/
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
INSERT [dbo].[BankProfile] ([ID], [Name]) VALUES (N'e7952486-4e5e-4f2e-b373-434696b8ab65', N'BDO')
GO
INSERT [dbo].[BankProfile] ([ID], [Name]) VALUES (N'00a6210f-d78b-4693-bb43-793ba1198061', N'LandBank')
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'75cf892b-d322-4866-8f69-223894ce4eec', N'Ramil', N'2', N'2010', N'3', N'3', N'3', N'3', N'', N'100', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5CF0170CCA5 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5CF0170CCAB AS DateTime), N'222', CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'8d26e575-4b1f-44d4-9042-5ee06f846bb6', N'987', CAST(5.00 AS Decimal(18, 2)), N'CASH', N'Medium', N'Toyotas', CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'PC', CAST(0x0000A73C0170CC7D AS DateTime))
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'e265d356-9eae-459c-9b03-47eef7d4135e', N'e', N'E', N'E', N'E', N'E', N'E', NULL, N'E', N'E', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5C2017A1363 AS DateTime), N'N', N'N', N'N', N'', N'Canceled', NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5C2017A136D AS DateTime), N'E', CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(55.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'E', CAST(0.00 AS Decimal(18, 2)), N'CASH', N'Medium', N'Toyotas', CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'CV', NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'90c00a25-7dc5-4d8d-b402-5cda61739706', N'1', N'1', N'11', N'11', N'11', N'11', NULL, N'1', N'1', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5B8013B7188 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5B8013B7194 AS DateTime), N'11', CAST(4.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'11', CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'99e20aa5-223b-435c-9b42-a497815d0d2c', N'q', N'q', N'q', N'q', N'q', N'q', NULL, N'q', N'q', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5C20175E245 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5C20175E251 AS DateTime), N'q', CAST(1.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'q', CAST(0.00 AS Decimal(18, 2)), N'CASH', N'Light', N'Toyotas', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'CV', NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'd8fd9193-5e5c-4348-bc30-b599b860c898', N'4', N'', N'4', N'4', N'4', N'4', N'', N'4', N'4', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5CF01702050 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5CF01702055 AS DateTime), N'4', CAST(25.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'4', CAST(100.00 AS Decimal(18, 2)), N'CASH', N'', N'', CAST(100.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), N'', CAST(0x0000A5CF0170204E AS DateTime))
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'0c394b97-ee36-499e-8d7e-c28298ebed01', N'1', N'1', N'1', N'1', N'1', N'1', NULL, N'', N'1', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A59101537D42 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A59101537D4E AS DateTime), N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8d26e575-4b1f-44d4-9042-5ee06f846bb6', NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'dc5dff84-b7cd-4a28-b88b-c98fe9cc0820', N'y', N'y', N'y', N'y', N'y', N'y', N'y', N'yy', N'y', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5C900002C02 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5C900002C11 AS DateTime), N'y', CAST(1.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'y', CAST(0.00 AS Decimal(18, 2)), N'CHECK', N'Light', N'Toyotas', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'CV', NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'889391ea-5cf5-4ee3-8f6d-de860fa91156', N'Ramil Ignacio', N'Pasig City', N'2015', N'efws32', N'4gf34g', N'gf34g', NULL, N'sample', N'sample', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5A60150F328 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(2150.00 AS Decimal(18, 2)), CAST(2150.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5A60150F335 AS DateTime), N'safkpk', CAST(2150.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(500.00 AS Decimal(18, 2)), CAST(1200.00 AS Decimal(18, 2)), CAST(450.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'8d26e575-4b1f-44d4-9042-5ee06f846bb6', N'123', CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'565c91e6-5772-41bf-b306-e776931c652b', N'6', N'', N'6', N'6', N'6', N'6', NULL, N'6', N'6', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5B9000A0C36 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(45.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5B9000A0C45 AS DateTime), N'6', CAST(25.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'8d26e575-4b1f-44d4-9042-5ee06f846bb6', N'6', CAST(0.00 AS Decimal(18, 2)), N'CASH', NULL, NULL, CAST(105.00 AS Decimal(18, 2)), CAST(45.00 AS Decimal(18, 2)), NULL, NULL)
GO
INSERT [dbo].[CarInsurancePolicy] ([ID], [Assured], [Address], [YearModel], [SerialNo], [MotorNo], [PlateNo], [Color], [Mortagee], [Deductible], [CreateBy], [CreateDate], [Aircon], [SterioSpeakers], [Magwheels], [Others], [Status], [CarInsuranceCoverageID], [Amount], [Balance], [ModifyDate], [ModifyBy], [Effectivity], [Unit], [TotalAnnualPremium], [A_LossAndDamage], [A_CTPL], [A_ExcessBodilyInjury], [A_VolPropertyDamage], [P_PersonalAccident], [P_MR], [P_Total], [P_AdditionalCharges], [P_DocumentaryTax], [P_EVAT], [P_LocalGovernmentTax], [P_LossAndDamage], [P_CTPL], [P_ExcessBodilyInjury], [P_VolPropertyDamage], [Agent], [PolicyNo], [Paid], [Payment_Method], [Car_Class], [Car_Make], [Gross], [Net], [Category], [Expiration_Date]) VALUES (N'4f5d3d74-4243-40b3-930c-e8f9bad8c00b', N'fFf', N'F', N'F', N'F', N'F', N'F', N'F', N'F', N'F', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', CAST(0x0000A5C9013A40A1 AS DateTime), N'N', N'N', N'N', N'', N'New', NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), NULL, NULL, CAST(0x0000A5C9013A40D6 AS DateTime), N'F', CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000000', N'F', CAST(0.00 AS Decimal(18, 2)), N'CHECK', N'', N'', CAST(5.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), N'', NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'43d9ecb4-2c92-4e1b-91f8-046a44957438', N'00000000-0000-0000-0000-000000000000', CAST(60.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5B800000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'5ce7f0ab-cc7b-4472-a862-29f0a4eb5610', N'00000000-0000-0000-0000-000000000000', CAST(100.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5B900000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'c9c46cd6-13e5-4fe4-ab4b-59594efb362f', N'0c394b97-ee36-499e-8d7e-c28298ebed01', CAST(12.00 AS Decimal(18, 2)), N'Cash', CAST(0x0000A594016380A6 AS DateTime), N'bfc81e8d-87a7-4341-8007-8f0385aa815a', NULL, N'', N'Paid', NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'512e08f5-da63-4d33-85fb-6591e6ef7881', N'4f5d3d74-4243-40b3-930c-e8f9bad8c00b', CAST(5.00 AS Decimal(18, 2)), N'CHECKED', CAST(0x0000A5C9013A6954 AS DateTime), N'00000000-0000-0000-0000-000000000000', N'e7952486-4e5e-4f2e-b373-434696b8ab65', N'GS', NULL, N'4343', CAST(0x0000A5C900000000 AS DateTime), N'GSERG')
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'b1341247-1a07-487e-846f-79393e181704', N'565c91e6-5772-41bf-b306-e776931c652b', CAST(105.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5B900000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'2e996221-5663-4163-b7da-9cfbefce9c40', N'75cf892b-d322-4866-8f69-223894ce4eec', CAST(5.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5CF01710F12 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'10012941-aa72-4c8a-b9b9-aaecddc4299d', N'00000000-0000-0000-0000-000000000000', CAST(600.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5B800000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'fc083858-3c49-4635-8433-ba55e2ca63ff', N'dc5dff84-b7cd-4a28-b88b-c98fe9cc0820', CAST(1.00 AS Decimal(18, 2)), N'CHECKED', CAST(0x0000A5C900004B33 AS DateTime), N'00000000-0000-0000-0000-000000000000', N'e7952486-4e5e-4f2e-b373-434696b8ab65', N'123', NULL, N'123123', CAST(0x0000A5C900000000 AS DateTime), N'23123')
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'3f94748b-166f-40f1-8885-c445a33d90fb', N'8459c33a-c2c8-4f4a-927f-f3f96be89d3a', CAST(50.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5C200000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'c2e02ef5-7c55-48e7-8ab4-df98e12c0924', N'd8fd9193-5e5c-4348-bc30-b599b860c898', CAST(100.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5CF01702EFB AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'547b6cae-4812-454f-a4ca-e681460fa3cc', N'e265d356-9eae-459c-9b03-47eef7d4135e', CAST(5.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5C200000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[CarInsurrancePayment] ([ID], [CarInsurancePolicyID], [Amount], [Method], [Date], [CreatedBy], [BankID], [Remarks], [Status], [Check_No], [Check_Date], [Check_Name]) VALUES (N'e0a01fa6-fc0c-408c-89ef-ea0bdc2c5207', N'00000000-0000-0000-0000-000000000000', CAST(1.00 AS Decimal(18, 2)), N'CASH', CAST(0x0000A5C200000000 AS DateTime), N'00000000-0000-0000-0000-000000000000', NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[MakeProfile] ([ID], [Name]) VALUES (N'160079d7-53ae-47ac-8346-afbac9442cb9', N'Toyotas')
GO
INSERT [dbo].[SalesAgent] ([ID], [AgentNo], [FirstName], [LastName], [MiddleName], [FullName]) VALUES (N'4a4d83d5-3f48-4f7c-b2f9-08938fcf30b7', N'2', N'Royce Stephan', N'Ignacios', N'', N'Royce Stephan  Ignacios')
GO
INSERT [dbo].[SalesAgent] ([ID], [AgentNo], [FirstName], [LastName], [MiddleName], [FullName]) VALUES (N'8d26e575-4b1f-44d4-9042-5ee06f846bb6', N'1', N'Ramil Charles', N'Ignacio', N'Valencia', NULL)
GO
INSERT [dbo].[SalesAgent] ([ID], [AgentNo], [FirstName], [LastName], [MiddleName], [FullName]) VALUES (N'5de63266-4414-41cf-8681-8d656fb6f051', N'666', N'Janna Bernice', N'Valdenarro', N'', N'Janna Bernice  Valdenarro')
GO
INSERT [dbo].[TransactionHistory] ([ID], [UserID], [Remarks], [Date]) VALUES (N'00000000-0000-0000-0000-000000000000', N'bfc81e8d-87a7-4341-8007-8f0385aa815a', N'Added New Policy No: 123', CAST(0x0000A5A601513204 AS DateTime))
GO
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [MiddleName], [Username], [Hash]) VALUES (N'bfc81e8d-87a7-4341-8007-8f0385aa815a', N'Ramil Charles', N'Ignacio', N'Valencia', N'Admin', N'admin')
GO
ALTER TABLE [dbo].[CarInsurancePolicy]  WITH CHECK ADD  CONSTRAINT [FK_CarInsurancePolicy_CarInsuranceCoverage] FOREIGN KEY([CarInsuranceCoverageID])
REFERENCES [dbo].[CarInsuranceCoverage] ([ID])
GO
ALTER TABLE [dbo].[CarInsurancePolicy] CHECK CONSTRAINT [FK_CarInsurancePolicy_CarInsuranceCoverage]
GO
