USE [Sparrow]
GO
ALTER TABLE [dbo].[CarInsurancePolicy] DROP CONSTRAINT [FK_CarInsurancePolicy_CarInsuranceCoverage]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[UserRole]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[TransactionHistory]
GO
/****** Object:  Table [dbo].[SalesAgent]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[SalesAgent]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[CarInsurrancePayment]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[CarInsurrancePayment]
GO
/****** Object:  Table [dbo].[CarInsurancePolicy]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[CarInsurancePolicy]
GO
/****** Object:  Table [dbo].[CarInsuranceCoverage]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[CarInsuranceCoverage]
GO
/****** Object:  Table [dbo].[CarInsuranceCommission]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[CarInsuranceCommission]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 2/23/2016 9:29:27 PM ******/
DROP TABLE [dbo].[Bank]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 2/23/2016 9:29:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarInsuranceCommission]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[CarInsuranceCoverage]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[CarInsurancePolicy]    Script Date: 2/23/2016 9:29:28 PM ******/
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
	[Agent] [uniqueidentifier] NULL,
	[PolicyNo] [varchar](50) NULL,
	[Paid] [decimal](18, 2) NOT NULL,
	[Payment_Method] [varchar](50) NULL,
	[Car_Class] [varchar](50) NULL,
	[Car_Type] [varbinary](10) NULL,
 CONSTRAINT [PK_CarInsurancePolicy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CarInsurrancePayment]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[SalesAgent]    Script Date: 2/23/2016 9:29:28 PM ******/
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
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
 CONSTRAINT [PK_SalesAgent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 2/23/2016 9:29:28 PM ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 2/23/2016 9:29:28 PM ******/
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
