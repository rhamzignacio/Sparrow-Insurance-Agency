USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetCarInsurancePolicyReport]    Script Date: 5/11/2016 5:31:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetCarInsurancePolicyReport]
(
	@FromDate datetime,
	@ToDate	datetime
)
AS
SELECT PlateNo, PolicyNo, CONVERT(VarChar, Effectivity, 101) as Effectivity, 
CONVERT(varchar,Expiration_Date, 101) as Expiration_Date, Assured, Car_Make, 
YearModel, SerialNo, MotorNo, Status  FROM CarInsurancePolicy

WHERE CreateDate between @FromDate and @ToDate
ORDER BY CreateDate ASC

GO

USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetCarInsurancePolicyReportByCategory]    Script Date: 5/11/2016 5:31:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetCarInsurancePolicyReportByCategory]
(
	@FromDate datetime,
	@ToDate	datetime,
	@Category varchar(10)
)
AS
SELECT PlateNo, PolicyNo, CONVERT(VarChar, Effectivity, 101) as Effectivity, 
CONVERT(varchar,Expiration_Date, 101) as Expiration_Date, Assured, Car_Make, 
YearModel, SerialNo, MotorNo, Status  FROM CarInsurancePolicy

WHERE Category = @Category AND CreateDate between @FromDate and @ToDate
ORDER BY CreateDate ASC

GO

USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetIncomeReport]    Script Date: 5/11/2016 5:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetIncomeReport]
(
	@FromDate datetime,
	@TODate datetime
)
as
SELECT PolicyNo, Assured, YearModel, PlateNo, Mortagee, Deductible, TotalAnnualPremium, Gross, Net, Paid, Status, (Gross-TotalAnnualPremium) as Income FROM CarInsurancePolicy
WHERE CreateDate between @FromDate and @TODate
AND
Status != 'Canceled'
AND
Status != 'Void'
ORDER BY CreateDate ASC


GO


USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetInsurancePaymentReport]    Script Date: 5/11/2016 5:34:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetInsurancePaymentReport]
(
	@PolicyNo uniqueidentifier
)
AS
SELECT CONVERT(varchar, [Date], 101) as [Date], Method, CONVERT(varchar, Check_Date, 101) as Check_Date,
Check_Name, Check_No, Amount, Status
FROM CarInsurrancePayment
WHERE CarInsurancePolicyID = @PolicyNo
ORDER BY Date ASC


GO


USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesAgentReport]    Script Date: 5/11/2016 5:34:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetSalesAgentReport]
(
	@SalesAgent uniqueidentifier,
	@FromDate datetime,
	@ToDate datetime
)
as
SELECT car.PolicyNo, car.Assured, car.YearModel, car.PlateNo, car.Mortagee, car.Deductible, 
car.TotalAnnualPremium, car.Gross, car.Net, car.Paid, 
(car.Gross-car.TotalAnnualPremium) as Income, car.Agent, sales.FullName, Status
FROM CarInsurancePolicy as car
LEFT JOIN SalesAgent as sales
ON car.Agent = sales.ID
WHERE car.CreateDate between @FromDate and @ToDate
AND
car.Agent = @SalesAgent

ORDER BY car.CreateDate ASC


GO


USE [Sparrow]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesAgentReportByCategory]    Script Date: 5/11/2016 5:34:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetSalesAgentReportByCategory]
(
	@SalesAgent uniqueidentifier,
	@FromDate datetime,
	@ToDate datetime,
	@Category varchar(10)
)
AS

SELECT car.PolicyNo, car.Assured, car.YearModel, car.PlateNo, car.Mortagee, car.Deductible, 
car.TotalAnnualPremium, car.Gross, car.Net, car.Paid, 
(car.Gross-car.TotalAnnualPremium) as Income, car.Agent, sales.FullName, Status
FROM CarInsurancePolicy as car
LEFT JOIN SalesAgent as sales
ON car.Agent = sales.ID
WHERE car.CreateDate between @FromDate and @ToDate
AND
car.Agent = @SalesAgent
AND
Category = @Category

ORDER BY car.CreateDate ASC
