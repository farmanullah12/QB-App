USE [master]
GO
/****** Object:  Database [QBranch]    Script Date: 17-Jun-23 9:48:26 AM ******/
CREATE DATABASE [QBranch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QBranch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QBranch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QBranch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QBranch_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QBranch] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QBranch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QBranch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QBranch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QBranch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QBranch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QBranch] SET ARITHABORT OFF 
GO
ALTER DATABASE [QBranch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QBranch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QBranch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QBranch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QBranch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QBranch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QBranch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QBranch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QBranch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QBranch] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QBranch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QBranch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QBranch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QBranch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QBranch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QBranch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QBranch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QBranch] SET RECOVERY FULL 
GO
ALTER DATABASE [QBranch] SET  MULTI_USER 
GO
ALTER DATABASE [QBranch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QBranch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QBranch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QBranch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QBranch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QBranch', N'ON'
GO
ALTER DATABASE [QBranch] SET QUERY_STORE = OFF
GO
USE [QBranch]
GO
/****** Object:  UserDefinedFunction [dbo].[CSVToTable]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CSVToTable] (@InStr VARCHAR(MAX))
RETURNS @TempTab TABLE
   (id int not null)
AS
BEGIN
    ;-- Ensure input ends with comma
	SET @InStr = REPLACE(@InStr + ',', ',,', ',')
	DECLARE @SP INT
DECLARE @VALUE VARCHAR(1000)
WHILE PATINDEX('%,%', @INSTR ) <> 0 
BEGIN
   SELECT  @SP = PATINDEX('%,%',@INSTR)
   SELECT  @VALUE = LEFT(@INSTR , @SP - 1)
   SELECT  @INSTR = STUFF(@INSTR, 1, @SP, '')
   INSERT INTO @TempTab(id) VALUES (@VALUE)
END
	RETURN
END
GO
/****** Object:  Table [dbo].[Item_Master]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item_Master](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[TranDate] [datetime] NULL,
	[PartNo] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[StockQty] [int] NULL,
	[Unit_ID] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[User_ID] [int] NULL,
	[PurchaseBillNo] [int] NULL,
	[status] [nvarchar](20) NULL,
	[category] [nvarchar](10) NULL,
	[ThrashHoldQTY] [int] NULL,
	[TotalAmount]  AS ([StockQty]*[Cost]),
	[TransactionType] [nvarchar](15) NULL,
 CONSTRAINT [PK_Item_Master] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit_OM]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit_OM](
	[UnitID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NULL,
	[UnitTitle] [nvarchar](20) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_TBL_Unit_Measure] PRIMARY KEY CLUSTERED 
(
	[UnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_ItemMaster]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ItemMaster]
AS
SELECT dbo.Item_Master.ItemID, dbo.Item_Master.TranDate, dbo.Item_Master.PartNo, dbo.Item_Master.Description, dbo.Item_Master.StockQty, dbo.Unit_OM.UnitTitle, dbo.Item_Master.Cost, dbo.Item_Master.ThrashHoldQTY, 
                  dbo.Item_Master.category
FROM     dbo.Item_Master LEFT OUTER JOIN
                  dbo.Unit_OM ON dbo.Item_Master.Unit_ID = dbo.Unit_OM.UnitID
GO
/****** Object:  View [dbo].[View_StockOpening]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[View_StockOpening]
as
select ItemID, Partno,Stockqty from view_ItemMaster
GO
/****** Object:  Table [dbo].[CRM_ClientInfo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_ClientInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[BusinessName] [nvarchar](80) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[StreetNo] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](25) NULL,
	[EmailID] [nvarchar](60) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[ContactNo] [nvarchar](20) NULL,
	[DateOfRegistry] [date] NULL,
	[Remarks] [nvarchar](100) NULL,
	[ClientImage] [image] NULL,
	[EntryDate] [date] NULL,
	[EnteredBy] [int] NULL,
	[LeadSourceID] [int] NULL,
	[LeadSourceName] [nvarchar](50) NULL,
	[LeadSourceContact] [nvarchar](15) NULL,
	[User_ID] [int] NULL,
	[AddedOn] [date] NULL,
 CONSTRAINT [PK_CRM_ClientInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_Detail]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Detail](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Item_ID] [nvarchar](40) NULL,
	[Item_Title] [nvarchar](50) NULL,
	[ProductGroup] [nvarchar](20) NULL,
	[Qty] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Sale_ID] [int] NULL,
	[User_ID] [int] NULL,
	[EntryDate] [datetime] NULL,
	[ItemCost] [decimal](18, 2) NULL,
	[TotalCost]  AS ([itemcost]*[qty]),
 CONSTRAINT [PK_Sale_Detail] PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_Master]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Master](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[BillNo] [nvarchar](50) NULL,
	[SaleDate] [date] NULL,
	[Remarks] [nvarchar](100) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Paid] [decimal](18, 2) NULL,
	[Balance] [decimal](18, 2) NULL,
	[User_ID] [int] NULL,
	[EntryDate] [date] NULL,
 CONSTRAINT [PK_Sale_Master] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_User]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[User_TypeID] [int] NULL,
	[FullName] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](20) NULL,
	[EmailID] [nvarchar](80) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[UserImage] [image] NULL,
 CONSTRAINT [PK_TBL_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Sale_Invoice_Preview]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Sale_Invoice_Preview]
AS
SELECT dbo.Sale_Master.SaleID, dbo.Sale_Master.Customer_ID, dbo.CRM_ClientInfo.FullName, dbo.Sale_Master.BillNo, dbo.Sale_Master.SaleDate, dbo.Sale_Master.Remarks, dbo.Sale_Master.Amount, dbo.Sale_Master.Paid, 
                  dbo.Sale_Master.Balance, dbo.Sale_Master.User_ID, dbo.TBL_User.FullName AS Expr1, dbo.Sale_Detail.Item_ID, dbo.Sale_Detail.Item_Title, dbo.Sale_Detail.Qty, dbo.Sale_Detail.Rate, dbo.Sale_Detail.TotalPrice, 
                  dbo.CRM_ClientInfo.PhoneNo, dbo.CRM_ClientInfo.City, dbo.Sale_Detail.ProductGroup
FROM     dbo.Sale_Master INNER JOIN
                  dbo.Sale_Detail ON dbo.Sale_Master.SaleID = dbo.Sale_Detail.Sale_ID INNER JOIN
                  dbo.CRM_ClientInfo ON dbo.Sale_Master.Customer_ID = dbo.CRM_ClientInfo.ID INNER JOIN
                  dbo.TBL_User ON dbo.Sale_Master.User_ID = dbo.TBL_User.UserID AND dbo.CRM_ClientInfo.User_ID = dbo.TBL_User.UserID
GO
/****** Object:  View [dbo].[sale_Collection]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[sale_Collection]
AS
SELECT Item_ID + ' ' + Item_Title AS description, Qty, Rate, TotalPrice, FullName, BillNo, SaleDate, Remarks, Amount, ProductGroup
FROM     dbo.Sale_Invoice_Preview
GO
/****** Object:  View [dbo].[Low_Stock]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[Low_Stock]
as
SELECT PartNo, Description, SUM(StockQty) AS TotalQty
FROM     dbo.View_ItemMaster
WHERE  (StockQty <= thrashholdQty)
GROUP BY PartNo, Description
GO
/****** Object:  View [dbo].[Closing_Inventory]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view  [dbo].[Closing_Inventory]
as
select ItemID,Trandate,PartNo,Description,StockQty,Cost,StockQty*Cost as TotalCost from View_ItemMaster
where stockQty<>0
GO
/****** Object:  Table [dbo].[Stock_Master]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Master](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[TranDate] [datetime] NULL,
	[PartNo] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[StockQty] [int] NULL,
	[Unit_ID] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
	[User_ID] [int] NULL,
	[PurchaseBillNo] [int] NULL,
	[status] [nvarchar](20) NULL,
	[Category] [nvarchar](10) NULL,
 CONSTRAINT [PK_Stock_Master] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[a]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[a]
as

with r as
(
    select d.PartNo
          ,d.TranDate
          ,d.StockQty
          ,d.Cost
         ,isnull(sum(d.StockQty) over (partition by d.PartNo order by d.TranDate rows between unbounded preceding and 1 preceding),0) as RunningQuantityStart
          ,sum(d.StockQty) over (partition by d.PartNo order by d.TranDate) as RunningQuantityEnd
    from stock_Master as d
)
select r.PartNo
      ,s.Qty
      ,sum(case when r.RunningQuantityEnd >= s.Qty
                then (s.Qty - r.RunningQuantityStart) * r.Cost
              else (r.RunningQuantityEnd - r.RunningQuantityStart) * r.Cost
                end
          ) as CostOfSalesValue
from r
    join Sale_Detail as s
        on r.PartNo = s.Item_ID
            and r.RunningQuantityStart < s.Qty
group by r.PartNo
        ,s.Qty;

		
GO
/****** Object:  View [dbo].[CGS]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[CGS]
as
WITH UnitsCTE
AS
(
-- GET Total Units Left
    SELECT SUM(
            CASE TransactionType 
            WHEN 'Purchase' Then StockQty 
            When 'Sale' THEN StockQty * -1 
            ELSE StockQty END) AS Units
    FROM Item_Master
), PurchaseCTE
AS
(
-- Get only purchases in reverse order
    SELECT StockQty, Cost, TranDate, ROW_NUMBER() OVER (ORDER BY TranDate DESC ) AS RN
    FROM Item_Master
    WHERE TransactionType <> 'Sale'
),
UnitCost
AS
(
-- Recursive CTE to get number of units left at each price
    SELECT CASE WHEN StockQty > UnitsCTE.Units THEN UnitsCTE.Units ELSE StockQty END As Units, Cost
    FROM PurchaseCTE 
    CROSS APPLY UnitsCTE
    WHERE RN = 1
    UNION ALL
    SELECT CASE WHEN P1.StockQty > (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN))
            THEN    CASE WHEN (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) < 0 THEN 0
                        ELSE (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) END
            ELSE P1.StockQty END,
            P1.Cost 
    FROM PurchaseCTE P1
    INNER JOIN PurchaseCTE P2
        ON P1.RN = P2.RN + 1
    CROSS APPLY UnitsCTE
)
SELECT SUM(Units) as units, SUM(Cost * Units) / SUM(Units) AS UnitCost, SUM(Units * Cost) AS TotalCost
FROM UnitCost
WHERE Units > 0
GO
/****** Object:  View [dbo].[PickCGS]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[PickCGS]
as
WITH UnitsCTE
AS
(
-- GET Total Units Left
    SELECT SUM(
            CASE TransactionType 
            WHEN 'Purchase' Then StockQty 
            When 'Sale' THEN StockQty * -1 
            ELSE StockQty END) AS Units,
			PartNo
    FROM Item_Master
	group by PartNo
), PurchaseCTE
AS
(
-- Get only purchases in reverse order
    SELECT PartNo,StockQty, Cost, TranDate, ROW_NUMBER() OVER (ORDER BY TranDate DESC ) AS RN
    FROM Item_Master
    WHERE TransactionType <> 'Sale'
),
UnitCost
AS
(
-- Recursive CTE to get number of units left at each price
    SELECT CASE WHEN StockQty > UnitsCTE.Units THEN UnitsCTE.Units ELSE StockQty END As Units, Cost,UnitsCTE.PartNo
    FROM PurchaseCTE 
    CROSS APPLY UnitsCTE
    WHERE RN = 1
    UNION ALL
    SELECT CASE WHEN P1.StockQty > (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN))
            THEN    CASE WHEN (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) < 0 THEN 0
                        ELSE (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) END
            ELSE P1.StockQty END,
            P1.Cost,p1.PartNo
    FROM PurchaseCTE P1
    INNER JOIN PurchaseCTE P2
        ON P1.RN = P2.RN + 1
    CROSS APPLY UnitsCTE
)
SELECT SUM(Units) as units, SUM(Cost * Units) / SUM(Units) AS UnitCost, SUM(Units * Cost) AS TotalCost
FROM UnitCost
WHERE Units > 0
GO
/****** Object:  View [dbo].[PickCGSCost]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[PickCGSCost]
as
WITH UnitsCTE
AS
(
-- GET Total Units Left
    SELECT SUM(
            CASE TransactionType 
            WHEN 'Purchase' Then StockQty 
            When 'Sale' THEN StockQty * -1 
            ELSE StockQty END) AS Units,
			PartNo
    FROM Item_Master
	group by PartNo
), PurchaseCTE
AS
(
-- Get only purchases in reverse order
    SELECT PartNo,StockQty, Cost, TranDate, ROW_NUMBER() OVER (ORDER BY TranDate DESC ) AS RN
    FROM Item_Master
    WHERE TransactionType <> 'Sale'
),
UnitCost
AS
(
-- Recursive CTE to get number of units left at each price
    SELECT CASE WHEN StockQty > UnitsCTE.Units THEN UnitsCTE.Units ELSE StockQty END As Units, Cost,UnitsCTE.PartNo
    FROM PurchaseCTE 
    CROSS APPLY UnitsCTE
    WHERE RN = 1
    UNION ALL
    SELECT CASE WHEN P1.StockQty > (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN))
            THEN    CASE WHEN (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) < 0 THEN 0
                        ELSE (UnitsCTE.Units - (SELECT SUM(StockQty) FROM PurchaseCTE P3 WHERE p3.RN < p1.RN)) END
            ELSE P1.StockQty END,
            P1.Cost,p1.PartNo
    FROM PurchaseCTE P1
    INNER JOIN PurchaseCTE P2
        ON P1.RN = P2.RN + 1
    CROSS APPLY UnitsCTE
)
SELECT PartNo,SUM(Units) as units, SUM(Cost * Units) / SUM(Units) AS UnitCost, SUM(Units * Cost) AS TotalCost
FROM UnitCost
WHERE Units > 0
group by PartNo
GO
/****** Object:  Table [dbo].[CRM_Supplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[City] [nvarchar](30) NULL,
	[State] [nvarchar](30) NULL,
	[PinCode] [nvarchar](20) NULL,
	[Country] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](20) NULL,
	[BankName] [nvarchar](50) NULL,
	[BankAccountNumber] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](20) NULL,
	[RemarkNote] [nvarchar](200) NULL,
 CONSTRAINT [PK_CRM_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Detail]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Detail](
	[PurchaseDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Item_ID] [nvarchar](50) NULL,
	[Item_Title] [nvarchar](50) NULL,
	[ProductGroup] [nvarchar](20) NULL,
	[Qty] [int] NULL,
	[PurchaseUnitPrice] [decimal](18, 2) NULL,
	[PurchaseTotalPrice] [decimal](18, 2) NULL,
	[Purchase_ID] [int] NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_Purchase_Detail] PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_Master]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_Master](
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNumber] [nvarchar](50) NULL,
	[Supplier_ID] [int] NULL,
	[PartyNumber] [nvarchar](50) NULL,
	[PurchaseDate] [date] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[ValueOfGoods] [decimal](18, 2) NULL,
	[EntryDate] [date] NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_Purchase_Master] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Purchase_Report_Invoice]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Purchase_Report_Invoice]
AS
SELECT dbo.Purchase_Master.PurchaseID, dbo.Purchase_Master.Supplier_ID, dbo.Purchase_Master.PartyNumber, dbo.Purchase_Master.PurchaseDate, dbo.Purchase_Master.TotalAmount, dbo.Purchase_Master.User_ID, 
                  dbo.CRM_Supplier.CompanyName, dbo.TBL_User.FullName, dbo.CRM_Supplier.Address, dbo.CRM_Supplier.City, dbo.CRM_Supplier.Email, dbo.CRM_Supplier.PhoneNo, dbo.CRM_Supplier.ContactPerson, dbo.CRM_Supplier.ContactNo, 
                  dbo.Purchase_Detail.Item_ID, dbo.Purchase_Detail.Item_Title, dbo.Purchase_Detail.Qty, dbo.Purchase_Detail.PurchaseUnitPrice, dbo.Purchase_Detail.PurchaseTotalPrice
FROM     dbo.Purchase_Master INNER JOIN
                  dbo.Purchase_Detail ON dbo.Purchase_Master.PurchaseID = dbo.Purchase_Detail.Purchase_ID INNER JOIN
                  dbo.CRM_Supplier ON dbo.Purchase_Master.Supplier_ID = dbo.CRM_Supplier.SupplierID INNER JOIN
                  dbo.TBL_User ON dbo.Purchase_Master.User_ID = dbo.TBL_User.UserID
GO
/****** Object:  Table [dbo].[TBL_Audit_Log]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Audit_Log](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[LOGIN] [varchar](50) NULL,
	[LOGOUT] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_Audit_Log] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[User_Logs]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[User_Logs]
as
select l.log_ID,u.UserName,L.Login,L.Logout
from TBL_Audit_Log l inner join TBL_User u
on u.UserID=l.User_ID
GO
/****** Object:  Table [dbo].[LeadSource]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeadSource](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LeadSourceTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_LeadSource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_ClientInfo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ClientInfo]
AS
SELECT dbo.CRM_ClientInfo.ID, dbo.CRM_ClientInfo.FullName, dbo.CRM_ClientInfo.BusinessName, dbo.CRM_ClientInfo.ContactPerson, dbo.CRM_ClientInfo.StreetNo, dbo.CRM_ClientInfo.City, dbo.CRM_ClientInfo.State, 
                  dbo.CRM_ClientInfo.ZipCode, dbo.CRM_ClientInfo.EmailID, dbo.CRM_ClientInfo.PhoneNo, dbo.CRM_ClientInfo.ContactNo, dbo.CRM_ClientInfo.DateOfRegistry, dbo.CRM_ClientInfo.Remarks, dbo.LeadSource.LeadSourceTitle, 
                  dbo.CRM_ClientInfo.LeadSourceName, dbo.CRM_ClientInfo.LeadSourceContact
FROM     dbo.CRM_ClientInfo LEFT OUTER JOIN
                  dbo.LeadSource ON dbo.CRM_ClientInfo.LeadSourceID = dbo.LeadSource.ID
GO
/****** Object:  Table [dbo].[UserTypeTable]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypeTable](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeTitle] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_UserTypeTable] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_GetUserProfileInfo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetUserProfileInfo]
AS
SELECT u.UserID, ut.UserTypeTitle, u.FullName, u.ContactNo, u.EmailID, u.UserName, u.UserImage
FROM     dbo.TBL_User AS u INNER JOIN
                  dbo.UserTypeTable AS ut ON u.User_TypeID = ut.UserTypeID
GO
/****** Object:  View [dbo].[View_PurchaseList]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[View_PurchaseList]
as 
SELECT PartyNumber,PurchaseDate,TotalAmount from Purchase_Master
GO
/****** Object:  View [dbo].[View_Supplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Supplier]
AS
SELECT        SupplierID, CompanyName, Address, City, State, PinCode, Country, Email, PhoneNo, BankName, BankAccountNumber, ContactPerson, ContactNo, RemarkNote
FROM            dbo.CRM_Supplier
GO
/****** Object:  Table [dbo].[ExternalSale_Detail]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalSale_Detail](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[Item_ID] [nvarchar](40) NULL,
	[Item_Title] [nvarchar](50) NULL,
	[ProductGroup] [nvarchar](20) NULL,
	[Qty] [int] NULL,
	[Rate] [decimal](18, 2) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[User_ID] [int] NULL,
	[EntryDate] [datetime] NULL,
	[ExternalSaleMasterID] [int] NULL,
 CONSTRAINT [PK_ExternalSaleSale_Detail] PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalSale_Master]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalSale_Master](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RONum] [nvarchar](30) NULL,
	[Date] [date] NULL,
	[DeliveryDate] [date] NULL,
	[NormalRO] [nvarchar](40) NULL,
	[CombackRO] [nvarchar](40) NULL,
	[Cwaiting] [nvarchar](50) NULL,
	[CNonWaiting] [nvarchar](50) NULL,
	[Remarks] [nvarchar](200) NULL,
	[Driver] [nvarchar](40) NULL,
	[CustomerName] [nvarchar](30) NULL,
	[Companyname] [nvarchar](50) NULL,
	[CarID] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[Year] [nvarchar](20) NULL,
	[ModelCode] [nvarchar](30) NULL,
	[RegNo] [nvarchar](30) NULL,
	[VNNo] [nvarchar](30) NULL,
	[Kmtr] [nvarchar](20) NULL,
	[Color] [nvarchar](20) NULL,
 CONSTRAINT [PK_ExternalSale_Detail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuList]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuList](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](max) NULL,
	[menuparent] [nvarchar](10) NULL,
 CONSTRAINT [PK_MenuList] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsGroup]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsGroup](
	[ProductGroupID] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroup] [nvarchar](20) NULL,
 CONSTRAINT [PK_ProductsGroup] PRIMARY KEY CLUSTERED 
(
	[ProductGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceType] [nvarchar](40) NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](20) NULL,
	[User_ID] [int] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Audit_Trail]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Audit_Trail](
	[Audit_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[User_ID] [bigint] NOT NULL,
	[Date] [date] NULL,
	[Action] [varchar](50) NULL,
	[Timex] [varchar](50) NULL,
	[Log_ID] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMenuPermission]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMenuPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[menuID] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserMenuPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WRKJOBS]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WRKJOBS](
	[JOBID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](240) NULL,
	[JobType] [varchar](20) NULL,
	[JobClosed] [float] NULL,
 CONSTRAINT [PK_WRKJOBS] PRIMARY KEY CLUSTERED 
(
	[JOBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WRKTechnician]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WRKTechnician](
	[TechID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](240) NULL,
	[Phone] [varchar](50) NULL,
	[Fax] [varchar](50) NULL,
	[EMail] [varchar](70) NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[TechClose] [smallint] NULL,
 CONSTRAINT [PK_WRKTechnician] PRIMARY KEY CLUSTERED 
(
	[TechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_ClientInfo] ON 

INSERT [dbo].[CRM_ClientInfo] ([ID], [FullName], [BusinessName], [ContactPerson], [StreetNo], [City], [State], [ZipCode], [EmailID], [PhoneNo], [ContactNo], [DateOfRegistry], [Remarks], [ClientImage], [EntryDate], [EnteredBy], [LeadSourceID], [LeadSourceName], [LeadSourceContact], [User_ID], [AddedOn]) VALUES (1, N'a', N'd', N'234', N'3', N'23', N'23', N'44', N'a@gmail.com', N'234', N'324', CAST(N'2022-01-31' AS Date), N'asdf', NULL, NULL, NULL, 2, N'a', N'324', 6, NULL)
INSERT [dbo].[CRM_ClientInfo] ([ID], [FullName], [BusinessName], [ContactPerson], [StreetNo], [City], [State], [ZipCode], [EmailID], [PhoneNo], [ContactNo], [DateOfRegistry], [Remarks], [ClientImage], [EntryDate], [EnteredBy], [LeadSourceID], [LeadSourceName], [LeadSourceContact], [User_ID], [AddedOn]) VALUES (2, N's', N'd', N'234', N'3', N'a', N'd', N'33', N'sdf', N'4', N'34', CAST(N'2022-02-01' AS Date), N'fsd', NULL, NULL, NULL, 3, N'a', N'd', 6, NULL)
SET IDENTITY_INSERT [dbo].[CRM_ClientInfo] OFF
SET IDENTITY_INSERT [dbo].[CRM_Supplier] ON 

INSERT [dbo].[CRM_Supplier] ([SupplierID], [CompanyName], [Address], [City], [State], [PinCode], [Country], [Email], [PhoneNo], [BankName], [BankAccountNumber], [ContactPerson], [ContactNo], [RemarkNote]) VALUES (1, N'a', N'd', N's', N'a', N'34', N'abc', N'4', N'34', N'AIB', N'34', N'ASAD', N'345345', N'REM')
SET IDENTITY_INSERT [dbo].[CRM_Supplier] OFF
SET IDENTITY_INSERT [dbo].[ExternalSale_Detail] ON 

INSERT [dbo].[ExternalSale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [User_ID], [EntryDate], [ExternalSaleMasterID]) VALUES (1, N'a', N'abc', N'TGMO', 2, CAST(22.00 AS Decimal(18, 2)), CAST(44.00 AS Decimal(18, 2)), NULL, CAST(N'2022-06-06T11:23:49.797' AS DateTime), NULL)
INSERT [dbo].[ExternalSale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [User_ID], [EntryDate], [ExternalSaleMasterID]) VALUES (2, N'5555', N'TGP', N'TGP', 20, CAST(14.00 AS Decimal(18, 2)), CAST(280.00 AS Decimal(18, 2)), NULL, CAST(N'2022-06-06T11:42:31.853' AS DateTime), 5)
INSERT [dbo].[ExternalSale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [User_ID], [EntryDate], [ExternalSaleMasterID]) VALUES (3, N'2222', N'TGMO', N'TGMO', 5, CAST(15.00 AS Decimal(18, 2)), CAST(75.00 AS Decimal(18, 2)), NULL, CAST(N'2022-06-06T14:29:57.623' AS DateTime), 6)
SET IDENTITY_INSERT [dbo].[ExternalSale_Detail] OFF
SET IDENTITY_INSERT [dbo].[ExternalSale_Master] ON 

INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (1, N'RO-0001', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-06' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asf', N'asdf', N'asd', N'sdf', 3, N'sdf', N'asdf', N'a', N'asdf', N'a', N'sf', N'sdf')
INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (2, N'RO-0002', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-06' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asdf', N'asdf', N'asdf', N'asdf', 4, N'sdf', N'asdf', N'sf', N'asdf', N'asdf', N'asf', N'asdf')
INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (3, N'RO-0003', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-06' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asdf', N'df', N'sdf', N'sdf', 1, N'sdf', N'sdf', N'sdf', N'sdf', N'sdf', N'sdf', N'sdf')
INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (4, N'RO-0004', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-06' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asdf', N'sdf', N'asdf2', N'sdf', 2, N'sdfsdf', N'sdf', N'sdf', N'asdf', N'asdf', N'sdf', N'asdf')
INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (5, N'RO-0005', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-02' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asdf', N'asdf', N'sdff', N'asdf', 2, N'sdf', N'sdfsdf', N'dsf', N'asdf', N'sdf', N'sdf', N'sdf')
INSERT [dbo].[ExternalSale_Master] ([ID], [RONum], [Date], [DeliveryDate], [NormalRO], [CombackRO], [Cwaiting], [CNonWaiting], [Remarks], [Driver], [CustomerName], [Companyname], [CarID], [Description], [Year], [ModelCode], [RegNo], [VNNo], [Kmtr], [Color]) VALUES (6, N'RO-0006', CAST(N'2022-06-06' AS Date), CAST(N'2022-06-07' AS Date), N'Normal R/O', N'Come Back R/O', N'Waiting', N'Non-waiting', N'asdf', N'asdf', N'asdf', N'asdf', 2, N'asdf', N'adf', N'asdf', N'adsf', N'asdf', N'adsf', N'asdf')
SET IDENTITY_INSERT [dbo].[ExternalSale_Master] OFF
SET IDENTITY_INSERT [dbo].[Item_Master] ON 

INSERT [dbo].[Item_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [category], [ThrashHoldQTY], [TransactionType]) VALUES (24, CAST(N'2022-08-26T17:10:37.823' AS DateTime), N'2525', N'0w20', 60, 2, CAST(6.00 AS Decimal(18, 2)), 6, NULL, NULL, N'TGMO', 10, N'Purchase')
INSERT [dbo].[Item_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [category], [ThrashHoldQTY], [TransactionType]) VALUES (25, CAST(N'2022-08-26T17:47:50.123' AS DateTime), N'2525', N'2525', 10, NULL, CAST(13.00 AS Decimal(18, 2)), NULL, 15, NULL, NULL, NULL, N'Purchase')
INSERT [dbo].[Item_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [category], [ThrashHoldQTY], [TransactionType]) VALUES (26, CAST(N'2022-08-26T19:45:28.347' AS DateTime), N'2525', N'2525', 17, NULL, CAST(16.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, N'Sale')
INSERT [dbo].[Item_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [category], [ThrashHoldQTY], [TransactionType]) VALUES (27, CAST(N'2022-08-26T19:47:03.727' AS DateTime), N'2525', N'2525', 20, NULL, CAST(10.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, N'Sale')
INSERT [dbo].[Item_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [category], [ThrashHoldQTY], [TransactionType]) VALUES (28, CAST(N'2022-08-26T19:52:42.860' AS DateTime), N'2525', N'2525', 33, NULL, CAST(20.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, N'Sale')
SET IDENTITY_INSERT [dbo].[Item_Master] OFF
SET IDENTITY_INSERT [dbo].[LeadSource] ON 

INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (1, N'TV')
INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (2, N'Friend')
INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (3, N'Social Media')
INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (4, N'Google Ads')
INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (5, N'Walk-in')
INSERT [dbo].[LeadSource] ([ID], [LeadSourceTitle]) VALUES (6, N'Other')
SET IDENTITY_INSERT [dbo].[LeadSource] OFF
SET IDENTITY_INSERT [dbo].[MenuList] ON 

INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (1, N'masterToolStripMenuItem', N'0')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (2, N'transactionsToolStripMenuItem', N'0')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (3, N'reportsToolStripMenuItem', N'0')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (4, N'securityToolStripMenuItem', N'0')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (5, N'helpToolStripMenuItem', N'0')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (6, N'itemMasterToolStripMenuItem', N'1')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (7, N'auditLogToolStripMenuItem', N'1')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (8, N'logOutToolStripMenuItem', N'1')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (9, N'exitToolStripMenuItem', N'1')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (10, N'uoMUnitsToolStripMenuItem', N'6')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (11, N'itemMasterToolStripMenuItem1', N'6')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (12, N'stockOpeningToolStripMenuItem', N'6')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (13, N'manageSuppliersToolStripMenuItem', N'6')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (14, N'manageCustomersToolStripMenuItem', N'6')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (15, N'retailPurchaseToolStripMenuItem', N'2')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (16, N'retailSaleToolStripMenuItem', N'2')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (17, N'supplierProfileToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (18, N'customerProfileToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (19, N'purchaseToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (20, N'salesReportsToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (21, N'pointOfPaymentToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (22, N'stockReportsToolStripMenuItem', N'3')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (23, N'salesCollectionReportToolStripMenuItem', N'21')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (24, N'collectionSummaryReportToolStripMenuItem', N'21')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (25, N'salesReceiptReportToolStripMenuItem', N'21')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (26, N'currentStockToolStripMenuItem', N'22')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (27, N'stockValuationToolStripMenuItem', N'22')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (28, N'usersManagementToolStripMenuItem', N'4')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (29, N'backupToolStripMenuItem', N'4')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (30, N'addUserToolStripMenuItem', N'4')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (31, N'userTypeToolStripMenuItem', N'4')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (32, N'userProfileToolStripMenuItem', N'4')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (33, N'softwareManualToolStripMenuItem', N'5')
INSERT [dbo].[MenuList] ([MenuID], [MenuName], [menuparent]) VALUES (34, N'aboutToolStripMenuItem', N'5')
SET IDENTITY_INSERT [dbo].[MenuList] OFF
SET IDENTITY_INSERT [dbo].[Purchase_Detail] ON 

INSERT [dbo].[Purchase_Detail] ([PurchaseDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [PurchaseUnitPrice], [PurchaseTotalPrice], [Purchase_ID], [EntryDate]) VALUES (16, N'a', N'23', N'TGMO', 15, CAST(8.00 AS Decimal(18, 2)), CAST(120.00 AS Decimal(18, 2)), 14, CAST(N'2022-07-22T14:25:19.320' AS DateTime))
INSERT [dbo].[Purchase_Detail] ([PurchaseDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [PurchaseUnitPrice], [PurchaseTotalPrice], [Purchase_ID], [EntryDate]) VALUES (17, N'2525', N'2525', N'TGMO', 10, CAST(13.00 AS Decimal(18, 2)), CAST(130.00 AS Decimal(18, 2)), 15, CAST(N'2022-08-26T17:47:50.123' AS DateTime))
SET IDENTITY_INSERT [dbo].[Purchase_Detail] OFF
SET IDENTITY_INSERT [dbo].[Purchase_Master] ON 

INSERT [dbo].[Purchase_Master] ([PurchaseID], [PurchaseNumber], [Supplier_ID], [PartyNumber], [PurchaseDate], [TotalAmount], [ValueOfGoods], [EntryDate], [User_ID]) VALUES (14, NULL, 1, N'p00199', CAST(N'2022-07-22' AS Date), CAST(120.00 AS Decimal(18, 2)), NULL, NULL, 6)
INSERT [dbo].[Purchase_Master] ([PurchaseID], [PurchaseNumber], [Supplier_ID], [PartyNumber], [PurchaseDate], [TotalAmount], [ValueOfGoods], [EntryDate], [User_ID]) VALUES (15, NULL, 1, N'5547', CAST(N'2022-08-25' AS Date), CAST(130.00 AS Decimal(18, 2)), NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[Purchase_Master] OFF
SET IDENTITY_INSERT [dbo].[Sale_Detail] ON 

INSERT [dbo].[Sale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [Sale_ID], [User_ID], [EntryDate], [ItemCost]) VALUES (46, N'2525', N'2525', N'TGMO', 17, CAST(16.00 AS Decimal(18, 2)), CAST(272.00 AS Decimal(18, 2)), 44, NULL, CAST(N'2022-08-26T19:45:28.347' AS DateTime), CAST(7.00 AS Decimal(18, 2)))
INSERT [dbo].[Sale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [Sale_ID], [User_ID], [EntryDate], [ItemCost]) VALUES (47, N'2525', N'2525', N'TGMO', 20, CAST(10.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), 45, NULL, CAST(N'2022-08-26T19:47:03.727' AS DateTime), CAST(7.32 AS Decimal(18, 2)))
INSERT [dbo].[Sale_Detail] ([SaleDetailID], [Item_ID], [Item_Title], [ProductGroup], [Qty], [Rate], [TotalPrice], [Sale_ID], [User_ID], [EntryDate], [ItemCost]) VALUES (48, N'2525', N'2525', N'TGMO', 33, CAST(20.00 AS Decimal(18, 2)), CAST(660.00 AS Decimal(18, 2)), 47, NULL, CAST(N'2022-08-26T19:52:42.860' AS DateTime), CAST(8.12 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Sale_Detail] OFF
SET IDENTITY_INSERT [dbo].[Sale_Master] ON 

INSERT [dbo].[Sale_Master] ([SaleID], [Customer_ID], [BillNo], [SaleDate], [Remarks], [Amount], [Paid], [Balance], [User_ID], [EntryDate]) VALUES (44, 2, N'P-0001', CAST(N'2022-08-26' AS Date), N'Sold', CAST(272.00 AS Decimal(18, 2)), CAST(272.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 6, CAST(N'2022-08-26' AS Date))
INSERT [dbo].[Sale_Master] ([SaleID], [Customer_ID], [BillNo], [SaleDate], [Remarks], [Amount], [Paid], [Balance], [User_ID], [EntryDate]) VALUES (45, 1, N'P-0045', CAST(N'2022-08-26' AS Date), N'', CAST(200.00 AS Decimal(18, 2)), CAST(200.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 6, CAST(N'2022-08-26' AS Date))
INSERT [dbo].[Sale_Master] ([SaleID], [Customer_ID], [BillNo], [SaleDate], [Remarks], [Amount], [Paid], [Balance], [User_ID], [EntryDate]) VALUES (47, 2, N'P-0046', CAST(N'2022-08-26' AS Date), N'Sold', CAST(660.00 AS Decimal(18, 2)), CAST(660.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 6, CAST(N'2022-08-26' AS Date))
SET IDENTITY_INSERT [dbo].[Sale_Master] OFF
SET IDENTITY_INSERT [dbo].[Stock_Master] ON 

INSERT [dbo].[Stock_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [Category]) VALUES (9, CAST(N'2022-07-22T11:30:25.767' AS DateTime), N'212', N'a', 0, 2, CAST(32.00 AS Decimal(18, 2)), 6, NULL, NULL, NULL)
INSERT [dbo].[Stock_Master] ([ItemID], [TranDate], [PartNo], [Description], [StockQty], [Unit_ID], [Cost], [User_ID], [PurchaseBillNo], [status], [Category]) VALUES (10, CAST(N'2022-07-22T11:30:59.580' AS DateTime), N'23', N'da', 0, 2, CAST(12.00 AS Decimal(18, 2)), 6, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Stock_Master] OFF
SET IDENTITY_INSERT [dbo].[TBL_Audit_Log] ON 

INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (2, 5, N'3:24:20 PM Sunday, February 6, 2022', N'3:24:30 PM Sunday, February 6, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (3, 6, N'3:24:53 PM Sunday, February 6, 2022', N'3:25:01 PM Sunday, February 6, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (4, 5, N'9:57:25 AM Monday, February 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (5, 5, N'10:17:09 AM Monday, February 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (6, 5, N'10:19:02 AM Monday, February 7, 2022', N'10:19:15 AM Monday, February 7, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (7, 5, N'10:19:58 AM Monday, February 7, 2022', N'10:20:00 AM Monday, February 7, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (8, 6, N'10:20:09 AM Monday, February 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (9, 5, N'10:07:29 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (10, 5, N'10:53:14 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (11, 5, N'10:54:30 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (12, 5, N'10:55:19 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (13, 6, N'10:56:47 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (14, 5, N'10:58:12 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (15, 5, N'11:01:47 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (16, 5, N'11:07:05 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (17, 5, N'11:31:35 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (18, 5, N'11:32:03 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (19, 5, N'11:32:42 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (20, 5, N'11:33:19 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (21, 5, N'11:56:44 AM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (22, 5, N'12:13:10 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (23, 5, N'12:16:13 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (24, 5, N'12:18:40 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (25, 5, N'4:12:02 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (26, 5, N'4:14:50 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (27, 5, N'4:15:14 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (28, 5, N'7:06:04 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (29, 5, N'7:07:29 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (30, 5, N'7:12:22 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (31, 5, N'7:26:34 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (32, 5, N'7:38:59 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (33, 7, N'7:39:28 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (34, 7, N'7:41:39 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (35, 7, N'7:43:00 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (36, 7, N'7:43:35 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (37, 7, N'7:45:08 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (38, 7, N'7:51:46 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (39, 7, N'7:52:38 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (40, 7, N'7:53:16 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (41, 7, N'7:54:25 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (42, 7, N'8:00:01 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (43, 7, N'8:00:38 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (44, 7, N'8:02:58 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (45, 7, N'8:43:56 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (46, 7, N'8:44:47 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (47, 7, N'8:46:33 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (48, 5, N'8:49:48 PM Tuesday, February 8, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (49, 7, N'3:19:48 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (50, 7, N'3:21:06 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (51, 7, N'3:21:33 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (52, 7, N'3:22:31 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (53, 7, N'3:29:04 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (54, 7, N'3:29:54 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (55, 7, N'3:36:38 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (56, 7, N'3:40:24 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (57, 7, N'3:50:59 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (58, 7, N'3:52:21 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (59, 7, N'3:59:04 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (60, 7, N'3:59:33 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (61, 7, N'4:06:28 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (62, 7, N'4:07:10 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (63, 7, N'4:11:17 PM Wednesday, February 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (64, 6, N'1:01:31 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (65, 7, N'1:02:48 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (66, 6, N'1:05:08 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (67, 6, N'1:06:07 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (68, 6, N'1:07:06 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (69, 6, N'1:19:02 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (70, 7, N'1:19:21 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (71, 7, N'1:21:57 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (72, 6, N'1:56:10 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (73, 6, N'2:02:47 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (74, 6, N'2:18:43 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (75, 6, N'2:19:31 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (76, 6, N'2:25:46 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (77, 6, N'2:31:08 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (78, 6, N'2:32:08 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (79, 6, N'2:52:50 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (80, 6, N'2:53:41 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (81, 6, N'2:54:44 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (82, 6, N'2:55:11 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (83, 6, N'3:03:28 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (84, 6, N'3:19:00 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (85, 6, N'3:23:21 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (86, 6, N'3:24:09 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (87, 6, N'3:27:53 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (88, 6, N'3:30:04 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (89, 7, N'3:31:23 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (90, 6, N'3:32:04 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (91, 7, N'3:33:23 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (92, 7, N'3:34:16 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (93, 6, N'3:48:10 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (94, 6, N'3:55:55 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (95, 6, N'3:56:45 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (96, 6, N'4:32:51 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (97, 7, N'4:34:02 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (98, 6, N'5:21:17 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (99, 6, N'5:22:02 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (100, 6, N'5:23:59 PM Wednesday, March 2, 2022', N'--')
GO
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (101, 6, N'5:26:02 PM Wednesday, March 2, 2022', N'5:26:20 PM Wednesday, March 2, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (102, 7, N'5:26:26 PM Wednesday, March 2, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (103, 6, N'1:37:18 PM Monday, April 4, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (104, 6, N'1:41:16 PM Monday, April 4, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (105, 6, N'1:44:05 PM Monday, April 4, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (106, 6, N'1:44:55 PM Monday, April 4, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (107, 6, N'11:00:46 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (108, 6, N'11:05:00 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (109, 6, N'11:07:18 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (110, 6, N'11:08:24 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (111, 6, N'11:09:01 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (112, 6, N'11:10:48 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (113, 6, N'11:16:16 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (114, 6, N'11:23:38 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (115, 6, N'11:25:14 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (116, 6, N'11:26:47 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (117, 6, N'11:30:00 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (118, 6, N'11:30:20 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (119, 6, N'11:30:34 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (120, 6, N'11:34:52 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (121, 6, N'11:35:34 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (122, 6, N'11:42:50 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (123, 6, N'11:44:51 AM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (124, 6, N'12:25:35 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (125, 6, N'12:27:05 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (126, 6, N'12:29:04 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (127, 6, N'12:30:17 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (128, 6, N'12:32:19 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (129, 6, N'12:33:37 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (130, 6, N'12:39:04 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (131, 6, N'12:39:45 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (132, 6, N'12:41:07 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (133, 6, N'12:49:01 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (134, 6, N'12:49:53 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (135, 6, N'12:52:53 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (136, 6, N'12:53:33 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (137, 6, N'12:53:57 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (138, 6, N'1:02:14 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (139, 6, N'1:04:28 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (140, 6, N'1:05:27 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (141, 6, N'1:09:09 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (142, 6, N'1:21:17 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (143, 6, N'1:22:28 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (144, 6, N'1:24:43 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (145, 6, N'11:28:44 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (146, 6, N'11:31:13 PM Thursday, April 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (147, 6, N'11:50:54 AM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (148, 6, N'11:53:25 AM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (149, 6, N'11:54:48 AM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (150, 6, N'11:57:03 AM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (151, 6, N'11:59:46 AM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (152, 6, N'12:03:27 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (153, 6, N'12:09:00 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (154, 6, N'12:18:41 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (155, 6, N'12:19:09 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (156, 6, N'12:25:32 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (157, 6, N'12:27:26 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (158, 6, N'12:29:19 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (159, 6, N'12:33:59 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (160, 6, N'12:34:54 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (161, 6, N'12:35:40 PM Saturday, April 9, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (162, 6, N'1:57:15 PM Sunday, April 10, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (163, 6, N'2:05:25 PM Sunday, April 10, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (164, 6, N'2:16:48 PM Sunday, April 10, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (165, 6, N'2:20:26 PM Sunday, April 10, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (166, 6, N'11:23:22 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (167, 6, N'11:24:59 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (168, 6, N'11:28:30 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (169, 6, N'11:30:06 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (170, 6, N'11:32:21 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (171, 6, N'11:36:06 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (172, 6, N'11:46:47 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (173, 6, N'11:47:27 AM Monday, April 11, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (174, 6, N'12:14:12 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (175, 6, N'12:17:14 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (176, 6, N'12:41:10 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (177, 6, N'12:42:55 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (178, 6, N'12:44:08 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (179, 6, N'12:56:32 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (180, 6, N'12:58:30 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (181, 6, N'12:59:14 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (182, 6, N'10:48:20 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (183, 6, N'10:54:21 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (184, 6, N'10:55:38 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (185, 6, N'10:58:14 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (186, 6, N'11:26:09 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (187, 6, N'11:29:26 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (188, 6, N'11:30:44 AM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (189, 6, N'12:00:01 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (190, 6, N'12:01:10 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (191, 6, N'12:35:25 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (192, 6, N'1:38:46 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (193, 6, N'1:39:22 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (194, 6, N'1:40:18 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (195, 6, N'1:41:26 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (196, 6, N'1:42:35 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (197, 6, N'1:45:26 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (198, 6, N'1:52:08 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (199, 6, N'1:54:04 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (200, 6, N'1:54:55 PM Tuesday, April 12, 2022', N'--')
GO
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (201, 6, N'1:55:35 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (202, 6, N'1:59:12 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (203, 6, N'2:00:18 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (204, 6, N'2:00:51 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (205, 6, N'2:21:34 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (206, 6, N'2:33:17 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (207, 6, N'2:51:28 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (208, 6, N'2:54:19 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (209, 6, N'2:58:03 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (210, 6, N'2:59:29 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (211, 6, N'3:03:21 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (212, 6, N'7:25:52 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (213, 6, N'7:51:04 PM Tuesday, April 12, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (214, 6, N'9:29:32 AM Wednesday, April 13, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (215, 6, N'9:47:02 AM Wednesday, April 13, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (216, 6, N'9:53:32 AM Wednesday, April 13, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (217, 6, N'11:48:11 PM Wednesday, April 13, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (218, 6, N'1:33:51 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (219, 6, N'1:42:19 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (220, 6, N'1:45:37 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (221, 6, N'9:41:30 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (222, 6, N'9:53:31 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (223, 6, N'9:55:34 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (224, 6, N'9:57:24 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (225, 6, N'10:03:50 AM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (226, 6, N'1:42:16 PM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (227, 6, N'1:44:40 PM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (228, 6, N'1:45:10 PM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (229, 6, N'1:45:48 PM Thursday, April 14, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (230, 6, N'11:00:24 AM Monday, April 25, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (231, 6, N'7:54:34 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (232, 6, N'7:55:38 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (233, 6, N'7:55:55 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (234, 6, N'8:22:03 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (235, 6, N'8:31:05 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (236, 6, N'8:41:37 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (237, 6, N'8:47:42 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (238, 6, N'9:10:03 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (239, 6, N'9:42:06 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (240, 6, N'9:59:26 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (241, 6, N'10:01:39 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (242, 6, N'10:02:52 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (243, 6, N'11:09:19 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (244, 6, N'11:11:55 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (245, 6, N'11:15:55 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (246, 6, N'11:17:10 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (247, 6, N'11:18:55 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (248, 6, N'11:20:48 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (249, 6, N'11:21:40 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (250, 6, N'11:23:26 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (251, 6, N'11:39:37 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (252, 6, N'11:50:25 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (253, 6, N'11:51:36 AM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (254, 6, N'12:20:24 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (255, 6, N'12:24:06 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (256, 6, N'12:25:36 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (257, 6, N'12:27:50 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (258, 6, N'12:33:48 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (259, 6, N'12:38:17 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (260, 6, N'12:39:41 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (261, 6, N'12:41:12 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (262, 6, N'2:12:16 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (263, 6, N'2:20:05 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (264, 6, N'2:29:29 PM Monday, June 6, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (265, 6, N'10:20:57 AM Tuesday, June 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (266, 6, N'11:01:30 AM Tuesday, June 7, 2022', N'11:21:01 AM Tuesday, June 7, 2022')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (267, 6, N'11:21:13 AM Tuesday, June 7, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (268, 6, N'11:04:46 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (269, 6, N'11:05:15 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (270, 6, N'11:30:04 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (271, 6, N'11:38:25 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (272, 6, N'11:41:35 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (273, 6, N'11:46:00 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (274, 6, N'11:46:56 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (275, 6, N'11:52:00 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (276, 6, N'11:52:44 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (277, 6, N'11:56:10 AM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (278, 6, N'12:04:26 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (279, 6, N'1:31:11 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (280, 6, N'1:32:34 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (281, 6, N'1:33:46 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (282, 6, N'1:35:32 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (283, 6, N'1:37:28 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (284, 6, N'2:24:31 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (285, 6, N'2:27:06 PM Friday, July 22, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (286, 6, N'4:30:50 PM Saturday, July 23, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (287, 6, N'5:01:15 PM Saturday, July 23, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (288, 6, N'7:34:09 PM Sunday, August 21, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (289, 6, N'7:34:58 PM Sunday, August 21, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (290, 6, N'7:35:21 PM Sunday, August 21, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (291, 6, N'5:09:58 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (292, 6, N'5:46:50 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (293, 6, N'6:44:53 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (294, 6, N'6:46:25 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (295, 6, N'6:50:50 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (296, 6, N'6:51:54 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (297, 6, N'6:53:11 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (298, 6, N'6:54:22 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (299, 6, N'7:12:33 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (300, 6, N'7:13:07 PM Friday, August 26, 2022', N'--')
GO
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (301, 6, N'7:15:01 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (302, 6, N'7:17:07 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (303, 6, N'7:17:23 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (304, 6, N'7:26:20 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (305, 6, N'7:27:17 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (306, 6, N'7:28:19 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (307, 6, N'7:29:54 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (308, 6, N'7:44:56 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (309, 6, N'7:51:56 PM Friday, August 26, 2022', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (310, 7, N'9:31:39 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (311, 7, N'9:32:33 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (312, 7, N'9:33:22 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (313, 7, N'9:38:00 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (314, 7, N'9:40:35 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (315, 7, N'9:41:43 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (316, 7, N'9:42:03 AM Saturday, June 17, 2023', N'--')
INSERT [dbo].[TBL_Audit_Log] ([Log_ID], [User_ID], [LOGIN], [LOGOUT]) VALUES (317, 7, N'9:46:46 AM Saturday, June 17, 2023', N'--')
SET IDENTITY_INSERT [dbo].[TBL_Audit_Log] OFF
SET IDENTITY_INSERT [dbo].[TBL_User] ON 

INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (1, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'Farmanullah', N'123', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (2, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'Wali', N'wali', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (3, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'Ahmad', N'ahmad123', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (4, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'ahmadzai', N'Ahmad123', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (5, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'farman', N'uBmnT9Q+rFZkSOwOBRNFOQ==', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (6, NULL, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'jamal', N'V8GcchZhKCBcTTefdcm2bdDI1juvlpJgIrFH7SFHKiA=', NULL)
INSERT [dbo].[TBL_User] ([UserID], [User_TypeID], [FullName], [ContactNo], [EmailID], [UserName], [Password], [UserImage]) VALUES (7, 2, N'Sultan Ahmad', N'0789789589', N'asdfas@abc.com', N'sultan', N'gin2TpBpAik4Rwp9Apqtjp3kXhJQbEn/ZBA8jL+fKKE=', 0x53797374656D2E427974655B5D)
SET IDENTITY_INSERT [dbo].[TBL_User] OFF
SET IDENTITY_INSERT [dbo].[Unit_OM] ON 

INSERT [dbo].[Unit_OM] ([UnitID], [Code], [UnitTitle], [User_ID]) VALUES (1, N'PC', N'Piece', NULL)
INSERT [dbo].[Unit_OM] ([UnitID], [Code], [UnitTitle], [User_ID]) VALUES (2, N'LTR1', N'Liter', 6)
INSERT [dbo].[Unit_OM] ([UnitID], [Code], [UnitTitle], [User_ID]) VALUES (3, N'BX', N'Box', NULL)
INSERT [dbo].[Unit_OM] ([UnitID], [Code], [UnitTitle], [User_ID]) VALUES (4, N'MTR', N'Meter', NULL)
SET IDENTITY_INSERT [dbo].[Unit_OM] OFF
SET IDENTITY_INSERT [dbo].[UserMenuPermission] ON 

INSERT [dbo].[UserMenuPermission] ([ID], [UserID], [menuID]) VALUES (1, 6, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35')
INSERT [dbo].[UserMenuPermission] ([ID], [UserID], [menuID]) VALUES (2, 7, N'1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35')
SET IDENTITY_INSERT [dbo].[UserMenuPermission] OFF
SET IDENTITY_INSERT [dbo].[UserTypeTable] ON 

INSERT [dbo].[UserTypeTable] ([UserTypeID], [UserTypeTitle], [User_ID]) VALUES (1, N'Admin', 5)
INSERT [dbo].[UserTypeTable] ([UserTypeID], [UserTypeTitle], [User_ID]) VALUES (2, N'User', 4)
SET IDENTITY_INSERT [dbo].[UserTypeTable] OFF
SET IDENTITY_INSERT [dbo].[WRKJOBS] ON 

INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (1, N'Periodic maintenance @ 1000 Km', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (2, N'Periodic maintenance @ 2500 Km', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (3, N'Periodic maintenance @ 5000 Km', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (4, N'Periodic maintenance @ 10000 Km', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (5, N'Three months inspection', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (6, N'Six months inspection', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (7, N'Nine months inspection', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (8, N'Twelve months inspection', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (9, N'General check up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (10, N'Power train/Chassis check up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (11, N'Electrical check up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (12, N'Brake check up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (13, N'Engine compartment check up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (14, N'Engine overhualing', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (15, N'Suspension overhualing', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (16, N'Air condition service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (17, N'Air condition gas refilling', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (18, N'Lath work', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (19, N'Brake service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (20, N'Brake overhualing', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (21, N'Brake air bleeding', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (22, N'Machining of Rotor discs', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (23, N'Clutch overhauling', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (24, N'Fly wheel skimming', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (25, N'Shock absorber replacement ( Armored )', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (26, N'Gear box service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (27, N'Vane pump installation', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (28, N'Diagnostic trouble shooting', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (29, N'Fuel tank clean up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (30, N'ECU programming', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (31, N'Injector programming', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (32, N'ABS diagnostic and repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (33, N'SRS system repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (34, N'Fuel injection pump caliberation', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (35, N'Fuel injection pump R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (36, N'Labor/Hour', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (37, N'Wheel balance', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (38, N'Wheel alignment', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (39, N'Salf starter repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (40, N'Dashboard opening', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (41, N'Winch installation', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (42, N'Towing charges / Recovery', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (43, N'Mobile service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (44, N'Radiator clean up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (45, N'Radiator R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (46, N'Body Was', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (47, N'Super Wash', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (48, N'Turbo charger installation', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (49, N'Engine tune up', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (50, N'Fuel system service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (51, N'Fuel tank R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (52, N'Clutch adjustment', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (53, N'Clutch overhualing', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (54, N'Spare wheel carrrier Repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (55, N'Combination Meter R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (56, N'4x4 repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (57, N'Evaporative system service', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (58, N'Alternator R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (59, N'Exhuast repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (60, N'Water pump R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (61, N'Tapped cover repair', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (62, N'Headgasket R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (63, N'Brake master cylinder R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (64, N'Brake booster R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (65, N'Horn R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (66, N'Battery R&R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (67, N'Coolant Replacement', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (68, N'Body and paint check up', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (69, N'Frame repair', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (70, N'Panel beating ( Denting )', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (71, N'Full body respray ( color change )', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (72, N'Front bumper paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (73, N'Front bumper repair and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (74, N'Rear bumper paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (75, N'Rear bumper repair and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (76, N'Fender dent and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (77, N'Door dent and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (78, N'Driver door LH paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (79, N'Passenger door RH paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (80, N'Rear LH door paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (81, N'Rear RH door paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (82, N'Rear wing paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (83, N'Rear wing dent and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (84, N'Show adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (85, N'Driver door adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (86, N'All doors adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (87, N'Windshield installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (88, N'Door glass installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (89, N'Quater glass installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (90, N'Tail gate glass installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (91, N'Roof rack installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (92, N'Piller dent and paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (93, N'Windshield resealing', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (94, N'Door lock repair', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (95, N'Door strap band installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (96, N'Lower armored shield refitting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (97, N'Body polish', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (98, N'Headlight adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (99, N'Tail gate dent and paint', N'Body / Paint', 0)
GO
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (100, N'Hood paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (101, N'Full body repray ( excluding roof )', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (102, N'Bumper adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (103, N'Front bumper, Radiator grille, Rear view mirror and door handles paint', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (104, N'Nose cut denting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (105, N'Fender apron denting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (106, N'Fender apron painting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (107, N'Fender apron denting and painting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (108, N'Side menber denting and painting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (109, N'Roof denting and painting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (110, N'Door trim board installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (111, N'Seat adjustment', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (112, N'Crossmenber denting', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (113, N'Hood lock repair', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (114, N'Pre-Delivery Service', N'PDS', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (115, N'First Free Service @ 1000 Km', N'FFS', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (116, N'Warranty Claim', N'Warranty', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (117, N'GEAR OIL CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (118, N'DIESEL FILTER CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (119, N'CENTRAL LOCKING CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (120, N'4x4 OIL CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (121, N'WHEEL STUD CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (122, N'COMPRESSOR BELT CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (123, N'SPIRAL CABLE CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (124, N'THROTTLE BODY SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (125, N'SUNROOF  CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (126, N'POWER WINDOW CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (127, N'POWER OIL CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (128, N'V-Belt replacement', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (129, N'CATALAYTIC CONVERTOR SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (130, N'WIPER RUBBER R/P  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (131, N'ESTIMATE CHARGES (MINIMUM)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (132, N'A/C FILTER CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (133, N'EGR SYSTEM SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (134, N'SPARK PLUGS CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (135, N'GEAR BOX O/R', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (136, N'REAR SHOCK R/P  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (137, N'CLUTCH CABLE CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (138, N'TIMING BELT & BEARING CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (139, N'AXLE SEAL R/P  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (140, N'OIL LEAKAGE FROM DRAIN PLUG', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (141, N'FRONT WHEEL BEARING R/P (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (142, N'ENGINE MOUNTING R/P  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (143, N'REAR WHEEL BEARING R/P  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (144, N'HAND BRAKE ADJUSTMENT', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (145, N'AXLE BOOT REPLACEMENT (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (146, N'ACCELATOR CABLE CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (147, N'CAMBER ADJUSMENT REAR WITH SST', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (148, N'FRONT DISC PAD R/P', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (149, N'STEERING RACK SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (150, N'BATTERY TERMINAL CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (151, N'FUEL CONSUMPTION PROBLEM ON PETROL', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (152, N'TIE ROD END O/R (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (153, N'TIMMING BELT LIGHT ON', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (154, N'INTAKE MANIFOLD SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (155, N'FRONT SUSPENSION CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (156, N'POWER STEERING BELT CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (157, N'BRAKE OIL CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (158, N'REAR DRUM POLISH.', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (159, N'OXYGEN SENSOR R/P', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (160, N'HEATER CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (161, N'INJECTOR SERVICE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (162, N'LOWER ARM CHANGE  (EACH)', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (163, N'PROPELLER SHAFT CHANG', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (164, N'ALTERNATOR BELT CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (165, N'COMPRESSOR BEARING R/P', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (166, N'TIMING CHAIN R/P', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (167, N'RPM SETTING', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (168, N'HEAT UP PROBLEM CHECKUP', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (169, N'DIFFERENTIAL OIL CHANGE FRONT', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (170, N'SEAT COVERS FITTING', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (171, N'CIGRETTE LITER CHECK', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (172, N'THERMOSTATE VALVE CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (173, N'FUEL CONSUMPTION SETTING', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (174, N'ENGINE COMPRESSION CHECK', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (175, N'STEERING BOOT CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (176, N'RR BUMPER TOUCHING', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (177, N'Hoot shock replacement', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (178, N'FR SHOW GRILL R/P', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (179, N'WIPPER SHIELD FITTING', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (180, N'REAR BUMPER BRACKET REPLACEMENT', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (181, N'FRONT BUMPER SUPPORT REPLACEMENT', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (182, N'FUSE BOX CHANGE', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (183, N'ELECTRICAL WORK', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (184, N'AIR CLEENER ASSY CHANGE', N'Mechanical', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (185, N'R/S FR OVER FENDER R/P', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (186, N'FR OVER FENDER F/P', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (187, N'COMPUND POLISH', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (188, N'FRONT GRILL PAINT/FITTING', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (189, N'DOOR MOLDING  O/F PAINT (SET)', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (190, N'MUD FLAP REAR O/F (BOTH)', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (191, N'FR BUMPER GARNISH O/F PAINT (BOTH)', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (192, N'FRONT SAFE GAURD REPAIR/PAINT', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (193, N'PARKING CHARGES', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (194, N'FRONT BUMPER CLIPS FITTING', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (195, N'REAR BUMPER CLIPS FITTING', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (196, N'Windshield rubber replacement', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (197, N'Foot step installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (198, N'Door moulding installation', N'Body / Paint', 0)
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (199, N'DOOR HINGES REPAIR', N'Body / Paint', 0)
GO
INSERT [dbo].[WRKJOBS] ([JOBID], [DESCRIPTION], [JobType], [JobClosed]) VALUES (200, N'FRONT BUMPER LIGHT FITTING', N'Body / Paint', 0)
SET IDENTITY_INSERT [dbo].[WRKJOBS] OFF
SET IDENTITY_INSERT [dbo].[WRKTechnician] ON 

INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (1, N'Mohammad Munir', N'Chel Seton', N'0700-145566', N'', N'mohammad.munir@habibgulzar.com', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (2, N'Abdul Aziz', N'Tara khel', N'077-4242955', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (3, N'Farid', N'Khair Khana', N'0700-990884', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (4, N'Azim', N'Dasht Barchi', N'077-6629685', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (5, N'Younos', N'Dasht Barchi', N'077-9452795', N'', N'', N'kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (6, N'Jawid', N'Kabul', N'0788-325703', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (7, N'Abdul Wakil', N'Khair Khana, Qala-e-Najara', N'077-1075695', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (8, N'Naser Technician', N'Khair Khana, sare Kotal', N'077-2215766', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (9, N'Jafar', N'Yaka toot, Qala-e-Malek Murad', N'077-8810670', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (10, N'Hamed ( Technician )', N'Karte Now', N'0700-050854', N'', N'', N'kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (11, N'Bashir', N'Kabul', N'', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (12, N'Naser ( Electrician )', N'Peshawar', N'077-1743848', N'', N'', N'Peshawar', N'Pakistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (13, N'Allah Gul', N'Kote Sangi', N'0786-424032', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (14, N'Khalid', N'Kolola peshta', N'0700-223846', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (15, N'Rahim', N'Paghman, Pule Musafer', N'0788-621736', N'', N'', N'Paghman', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (16, N'Wahid ---Ebrahem---Parviz--Ziaudeen', N'Qabel Bai', N'0787-531200', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (17, N'Hamed( Painter)---Rahim---Sher Ahmad---Munawarsha', N'karte Now', N'0700-232715', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (18, N'Munawar shah', N'De Khudai Dad', N'0777-028020', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (19, N'Sher Ahmad', N'Toyota Accomodation', N'077-1030119', N'', N'', N'kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (20, N'Najeeb', N'', N'', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (21, N'Ebrahim', N'Toyota Accomodation', N'0787-207391', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (22, N'Omid', N'KABUL', N'', N'', N'', N'KABUL', N'AFGHANISTAN', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (23, N'Ali', N'Kabul', N'', N'', N'', N'Kabul', N'Afghanistan', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (24, N'OTHERS', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (25, N'Mohamad Ali', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (26, N'MOHAMMAD AFZAL', N'PESHAWAR', N'', N'', N'', N'PESHAWAR', N'PAKISTAN', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (27, N'Sakhi', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (28, N'Nawid', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (29, N'KHALID-ALLAH GUL-BASHIR', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (30, N'Abdullah', N'', N'', N'', N'', N'', N'', 0)
INSERT [dbo].[WRKTechnician] ([TechID], [Name], [Address], [Phone], [Fax], [EMail], [City], [Country], [TechClose]) VALUES (31, N'FAHIM', N'QBUL BAI', N'', N'', N'', N'KABUL', N'AFGHANISTAN', 0)
SET IDENTITY_INSERT [dbo].[WRKTechnician] OFF
ALTER TABLE [dbo].[TBL_Audit_Log] ADD  CONSTRAINT [DF_TBL_Audit_Log_LOGOUT]  DEFAULT ('--') FOR [LOGOUT]
GO
ALTER TABLE [dbo].[CRM_ClientInfo]  WITH CHECK ADD  CONSTRAINT [FK_CRM_ClientInfo_LeadSource] FOREIGN KEY([LeadSourceID])
REFERENCES [dbo].[LeadSource] ([ID])
GO
ALTER TABLE [dbo].[CRM_ClientInfo] CHECK CONSTRAINT [FK_CRM_ClientInfo_LeadSource]
GO
ALTER TABLE [dbo].[CRM_ClientInfo]  WITH CHECK ADD  CONSTRAINT [FK_CRM_ClientInfo_TBL_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[CRM_ClientInfo] CHECK CONSTRAINT [FK_CRM_ClientInfo_TBL_User]
GO
ALTER TABLE [dbo].[ExternalSale_Detail]  WITH CHECK ADD  CONSTRAINT [FK_ExternalSale_Detail_ExternalSale_Master] FOREIGN KEY([ExternalSaleMasterID])
REFERENCES [dbo].[ExternalSale_Master] ([ID])
GO
ALTER TABLE [dbo].[ExternalSale_Detail] CHECK CONSTRAINT [FK_ExternalSale_Detail_ExternalSale_Master]
GO
ALTER TABLE [dbo].[Item_Master]  WITH CHECK ADD  CONSTRAINT [FK_Item_Master_Purchase_Master] FOREIGN KEY([PurchaseBillNo])
REFERENCES [dbo].[Purchase_Master] ([PurchaseID])
GO
ALTER TABLE [dbo].[Item_Master] CHECK CONSTRAINT [FK_Item_Master_Purchase_Master]
GO
ALTER TABLE [dbo].[Item_Master]  WITH CHECK ADD  CONSTRAINT [FK_Item_Master_Unit_OM] FOREIGN KEY([Unit_ID])
REFERENCES [dbo].[Unit_OM] ([UnitID])
GO
ALTER TABLE [dbo].[Item_Master] CHECK CONSTRAINT [FK_Item_Master_Unit_OM]
GO
ALTER TABLE [dbo].[Purchase_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Detail_Purchase_Master] FOREIGN KEY([Purchase_ID])
REFERENCES [dbo].[Purchase_Master] ([PurchaseID])
GO
ALTER TABLE [dbo].[Purchase_Detail] CHECK CONSTRAINT [FK_Purchase_Detail_Purchase_Master]
GO
ALTER TABLE [dbo].[Purchase_Master]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Master_CRM_Supplier] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[CRM_Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Purchase_Master] CHECK CONSTRAINT [FK_Purchase_Master_CRM_Supplier]
GO
ALTER TABLE [dbo].[Purchase_Master]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Master_TBL_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[Purchase_Master] CHECK CONSTRAINT [FK_Purchase_Master_TBL_User]
GO
ALTER TABLE [dbo].[Sale_Detail]  WITH CHECK ADD  CONSTRAINT [FK_ExternalSale_Detail_Sale_Master] FOREIGN KEY([Sale_ID])
REFERENCES [dbo].[Sale_Master] ([SaleID])
GO
ALTER TABLE [dbo].[Sale_Detail] CHECK CONSTRAINT [FK_ExternalSale_Detail_Sale_Master]
GO
ALTER TABLE [dbo].[Sale_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Detail_Sale_Master] FOREIGN KEY([Sale_ID])
REFERENCES [dbo].[Sale_Master] ([SaleID])
GO
ALTER TABLE [dbo].[Sale_Detail] CHECK CONSTRAINT [FK_Sale_Detail_Sale_Master]
GO
ALTER TABLE [dbo].[Sale_Master]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Master_CRM_ClientInfo] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[CRM_ClientInfo] ([ID])
GO
ALTER TABLE [dbo].[Sale_Master] CHECK CONSTRAINT [FK_Sale_Master_CRM_ClientInfo]
GO
ALTER TABLE [dbo].[Sale_Master]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Master_TBL_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[Sale_Master] CHECK CONSTRAINT [FK_Sale_Master_TBL_User]
GO
ALTER TABLE [dbo].[Stock_Master]  WITH CHECK ADD  CONSTRAINT [FK_stock_Master_Purchase_Master] FOREIGN KEY([PurchaseBillNo])
REFERENCES [dbo].[Purchase_Master] ([PurchaseID])
GO
ALTER TABLE [dbo].[Stock_Master] CHECK CONSTRAINT [FK_stock_Master_Purchase_Master]
GO
ALTER TABLE [dbo].[Stock_Master]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Master_TBL_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[Stock_Master] CHECK CONSTRAINT [FK_Stock_Master_TBL_User]
GO
ALTER TABLE [dbo].[Stock_Master]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Master_Unit_OM] FOREIGN KEY([Unit_ID])
REFERENCES [dbo].[Unit_OM] ([UnitID])
GO
ALTER TABLE [dbo].[Stock_Master] CHECK CONSTRAINT [FK_Stock_Master_Unit_OM]
GO
ALTER TABLE [dbo].[TBL_Audit_Log]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Audit_Log_TBL_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[TBL_Audit_Log] CHECK CONSTRAINT [FK_TBL_Audit_Log_TBL_User]
GO
ALTER TABLE [dbo].[TBL_User]  WITH CHECK ADD  CONSTRAINT [FK_TBL_User_UserTypeTable] FOREIGN KEY([User_TypeID])
REFERENCES [dbo].[UserTypeTable] ([UserTypeID])
GO
ALTER TABLE [dbo].[TBL_User] CHECK CONSTRAINT [FK_TBL_User_UserTypeTable]
GO
ALTER TABLE [dbo].[UserMenuPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserMenuPermission_TBL_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[TBL_User] ([UserID])
GO
ALTER TABLE [dbo].[UserMenuPermission] CHECK CONSTRAINT [FK_UserMenuPermission_TBL_User]
GO
/****** Object:  StoredProcedure [dbo].[ExternalSaleDetailAddOrEdit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[ExternalSaleDetailAddOrEdit]
@SaleDetailID int,
@Item_ID nvarchar(20),
@Item_Title nvarchar(50),
@ProductGroup nvarchar(20),
@Qty int,
@Rate decimal(18,2),
@TotalPrice decimal(18,2),
@ExternalSaleMasterID int,
@EntryDate datetime
AS
	--Insert
	IF @SaleDetailID = 0 BEGIN
		INSERT INTO ExternalSale_Detail(Item_ID,Item_Title,ProductGroup,Qty,Rate,TotalPrice,ExternalSaleMasterID,EntryDate)
		VALUES (@Item_ID,@Item_Title,@ProductGroup,@Qty,@Rate,@TotalPrice,@ExternalSaleMasterID,@EntryDate)

		SELECT SCOPE_IDENTITY();

		--exec UpdatefifoStock @Item_ID,@Qty
		exec UpdateStockFIFO @Item_ID,@Qty

		END
	--Update
	ELSE BEGIN
		UPDATE ExternalSale_Detail
		SET
			Item_ID=@Item_ID,
			Item_Title=@Item_Title,
			ProductGroup=@ProductGroup,
			Qty=@Qty,
			rate=@Rate,
			totalPrice=@TotalPrice,
			ExternalSaleMasterID=@ExternalSaleMasterID

		WHERE SaleDetailID=@SaleDetailID

		SELECT @SaleDetailID;
		END
GO
/****** Object:  StoredProcedure [dbo].[getSharedUnits]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getSharedUnits]
as
begin
SELECT UnitID,UnitTitle from Unit_OM
end
GO
/****** Object:  StoredProcedure [dbo].[PurchaseAddOrEdit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PurchaseAddOrEdit]
@PurchaseID int,
@SupplierID int,
@PartyNumber nvarchar(20),
@PurchaseDate date,
@TotalAmount decimal(18,2),
@User_ID int
AS

	--Insert
	IF @PurchaseID = 0 BEGIN
		INSERT INTO Purchase_Master(Supplier_ID,PartyNumber,PurchaseDate,TotalAmount,User_ID)
		VALUES (@SupplierID,@PartyNumber,@PurchaseDate,@TotalAmount,@User_ID)

		SELECT SCOPE_IDENTITY();

		END
	--Update
	ELSE BEGIN
		UPDATE Purchase_Master
		SET
			Supplier_ID=@SupplierID,
			PartyNumber=@PartyNumber,
			PurchaseDate=@PurchaseDate,
			TotalAmount=@TotalAmount,
			User_ID=@User_ID

		WHERE PurchaseID=@PurchaseID

		SELECT @PurchaseID;
		END
GO
/****** Object:  StoredProcedure [dbo].[PurchaseDetailAddOrEdit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PurchaseDetailAddOrEdit]
@PurchaseDetailID int,
@Item_ID nvarchar(20),
@Item_Title nvarchar(50),
@ProductGroup nvarchar(20),
@Qty int,
@PurchaseUnitPrice decimal(18,2),
@PurchaseTotalPrice decimal(18,2),
@Purchase_ID int,
@EntryDate datetime
AS
	--Insert
	IF @PurchaseDetailID = 0 BEGIN
		INSERT INTO Purchase_Detail (Item_ID,Item_Title,ProductGroup,Qty,PurchaseUnitPrice,PurchaseTotalPrice,Purchase_ID,EntryDate)
		VALUES (@Item_ID,@Item_Title,@ProductGroup,@Qty,@PurchaseUnitPrice,@PurchaseTotalPrice,@Purchase_ID,@EntryDate)

		SELECT SCOPE_IDENTITY();

		select * from Item_Master

		insert into Item_Master (TranDate,PartNo,Description,StockQty,Cost,PurchaseBillNo) 
								values
								(@EntryDate,@Item_ID,@Item_Title,@Qty,@PurchaseUnitPrice,@Purchase_ID)
		--insert into Stock_Master (TranDate,PartNo,Description,StockQty,Cost,PurchaseBillNo) 
		--						values
		--						(@EntryDate,@Item_ID,@Item_Title,@Qty,@PurchaseUnitPrice,@Purchase_ID)

		END
	--Update
	ELSE BEGIN
		UPDATE Purchase_Detail
		SET
			Item_ID=@Item_ID,
			Item_Title=@Item_Title,
			ProductGroup=@ProductGroup,
			Qty=@Qty,
			PurchaseUnitPrice=@PurchaseUnitPrice,
			purchaseTotalPrice=@PurchaseTotalPrice,
			Purchase_ID=@Purchase_ID

		WHERE PurchaseDetailID=@PurchaseDetailID

		SELECT @PurchaseDetailID;
		END
GO
/****** Object:  StoredProcedure [dbo].[SaleAddOrEdit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SaleAddOrEdit]
@SaleID int,
@Customer_ID int,
@BillNo nvarchar(20),
@SaleDate date,
@Remarks nvarchar(100),
@Amount decimal(18,2),
@Paid decimal(18,2),
@Balance decimal(18,2),
@User_ID int,
@EntryDate date
AS

	--Insert
	IF @SaleID = 0 BEGIN
		INSERT INTO Sale_Master (customer_ID,BillNo,SaleDate,Remarks,Amount,Paid,Balance,User_ID,EntryDate)
		VALUES (@Customer_ID,@BillNo,@SaleDate,@Remarks,@Amount,@Paid,@Balance,@User_ID,@EntryDate)

		SELECT SCOPE_IDENTITY();

		END
	--Update
	ELSE BEGIN
		UPDATE Sale_Master
		SET
			Customer_ID=@Customer_ID,
			BillNo=@BillNo,
			SaleDate=@SaleDate,
			Remarks=@Remarks,
			Amount=@Amount,
			Paid=@Paid,
			Balance=@Balance

		WHERE SaleID=@SaleID

		SELECT @SaleID;
		END
GO
/****** Object:  StoredProcedure [dbo].[SaleDetailAddOrEdit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SaleDetailAddOrEdit]
@SaleDetailID int,
@Item_ID nvarchar(20),
@Item_Title nvarchar(50),
@ProductGroup nvarchar(20),
@Qty int,
@Rate decimal(18,2),
@TotalPrice decimal(18,2),
@Sale_ID int,
@EntryDate datetime,
@ItemCost decimal(18,2)
AS
	--Insert
	IF @SaleDetailID = 0 BEGIN
		INSERT INTO Sale_Detail(Item_ID,Item_Title,ProductGroup,Qty,Rate,TotalPrice,Sale_ID,EntryDate,itemCost)
		VALUES (@Item_ID,@Item_Title,@ProductGroup,@Qty,@Rate,@TotalPrice,@Sale_ID,@EntryDate,@ItemCost)

		SELECT SCOPE_IDENTITY();

		insert into Item_Master (TranDate,PartNo,Description,StockQty,Cost,TransactionType)
		values (@EntryDate,@Item_ID,@Item_Title,@Qty,@Rate,'Sale')
		--select * from Item_Master

		--exec UpdatefifoStock @,@Qty
		--exec UpdateStockFIFO @Item_ID,@Qty

		END
	--Update
	ELSE BEGIN
		UPDATE Sale_Detail
		SET
			Item_ID=@Item_ID,
			Item_Title=@Item_Title,
			ProductGroup=@ProductGroup,
			Qty=@Qty,
			rate=@Rate,
			totalPrice=@TotalPrice,
			Sale_ID=@Sale_ID,
			ItemCost=@ItemCost

		WHERE SaleDetailID=@SaleDetailID

		SELECT @SaleDetailID;
		END
GO
/****** Object:  StoredProcedure [dbo].[UpdatefifoStock]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatefifoStock] 
	-- Add the parameters for the stored procedure here
	@ItemID int,
	@OrderQty int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Fetch total stock in hand
	DECLARE @TotalStock INT
	SET @TotalStock = (Select SUM(StockQty) from Item_Master where PartNo = @ItemID)
	
	-- Check if the available stock is less than ordered quantity
	IF @TotalStock < @OrderQty
	BEGIN
		PRINT 'Stock not available'
		RETURN -1
	END
	
	DECLARE @InventoryID INT
	DECLARE @QuantityInHand INT
	-- Declare a CURSOR to hold ID, Quantity
	DECLARE @GetInventoryID CURSOR
 
	SET @GetInventoryID = CURSOR FOR
	SELECT PartNo, StockQty
	FROM Item_Master
	WHERE PartNo = @ItemID
	ORDER BY TranDate
 
	-- Open the CURSOR
	OPEN @GetInventoryID

	-- Fetch record from the CURSOR
	FETCH NEXT
	FROM @GetInventoryID INTO @InventoryID, @QuantityInHand

	-- Loop if record found in CURSOR
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Check if Order quantity becomes 0
		IF @OrderQty = 0
		BEGIN
			PRINT 'Updated Successfully'
			RETURN 1
		END
		-- If Order Qty is less than or equal to Quantity In Hand
		IF @OrderQty <= @QuantityInHand 
		BEGIN
			UPDATE Item_Master
			SET StockQty = StockQty - @OrderQty
			WHERE PartNo = @InventoryID
			
			SET @OrderQty = 0
		END
		-- If Order Qty is greater than Quantity In Hand
		ELSE
		BEGIN
			UPDATE Item_Master
			SET StockQty = 0
			WHERE PartNo = @InventoryID

			SET @OrderQty = @OrderQty - @QuantityInHand
		END
		
		FETCH NEXT
		FROM @GetInventoryID INTO @InventoryID, @QuantityInHand
	END
		
	-- Close and  Deallocate CURSOR
	CLOSE @GetInventoryID
	DEALLOCATE @GetInventoryID
	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateStockFIFO]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateStockFIFO] 
	-- Add the parameters for the stored procedure here
	@ProductID int, 
	@OrderQuantity int
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Fetch total stock in hand
	DECLARE @TotalStock INT
	SET @TotalStock = (Select SUM(StockQty) from item_master where PartNo = @ProductID)
	
	-- Check if the available stock is less than ordered quantity
	IF @TotalStock < @OrderQuantity
	BEGIN
		PRINT 'Stock not available'
		RETURN -1
	END
	
	DECLARE @InventoryID INT
	DECLARE @QuantityInHand INT
	-- Declare a CURSOR to hold ID, Quantity
	DECLARE @GetInventoryID CURSOR
 
	SET @GetInventoryID = CURSOR FOR
	SELECT ItemID, StockQty
	FROM Item_Master
	WHERE PartNo = @ProductID
	--ORDER BY ReceivedDate
 
	-- Open the CURSOR
	OPEN @GetInventoryID

	-- Fetch record from the CURSOR
	FETCH NEXT
	FROM @GetInventoryID INTO @InventoryID, @QuantityInHand

	-- Loop if record found in CURSOR
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Check if Order quantity becomes 0
		IF @OrderQuantity = 0
		BEGIN
			PRINT 'Updated Successfully'
			RETURN 1
		END
		-- If Order Qty is less than or equal to Quantity In Hand
		IF @OrderQuantity <= @QuantityInHand 
		BEGIN
			
			--insert into Item_Master (PartNo,StockQty,status,Cost) values (@ProductID,@OrderQuantity,'Out',@Cost)

				UPDATE Item_Master
				SET StockQty = StockQty - @OrderQuantity
				WHERE ItemID = @InventoryID
			
				SET @OrderQuantity = 0
			END
		-- If Order Qty is greater than Quantity In Hand
		ELSE
		BEGIN
		
			--insert into Item_Master (PartNo,StockQty,status,Cost) values (@ProductID,@OrderQuantity,'Out',@Cost)

			UPDATE Item_Master
			SET StockQty = 0
			WHERE ItemID = @InventoryID

			SET @OrderQuantity = @OrderQuantity - @QuantityInHand
		END
		
		FETCH NEXT
		FROM @GetInventoryID INTO @InventoryID, @QuantityInHand
	END
		
	-- Close and  Deallocate CURSOR
	CLOSE @GetInventoryID
	DEALLOCATE @GetInventoryID
	
END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditClientInfo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[usp_AddOrEditClientInfo]
@ClientID int,
@FullName nvarchar(50),
@BusinessName nvarchar(50),
@ContactPerson nvarchar(50),
@StreetNo nvarchar(50),
@City nvarchar(50),
@State nvarchar(50),
@ZipCode nvarchar(50),
@EmailID nvarchar(50),
@PhoneNo nvarchar(50),
@ContactNo nvarchar(50),
@DateOfRegistry date,
@Remarks nvarchar(150),
@LeadSourceID int,
@LeadSourceName nvarchar(50),
@LeadSourceContact nvarchar(15),
@User_ID int
as
	if @ClientID=0 begin
		insert into CRM_ClientInfo (FullName,BusinessName,ContactPerson,StreetNo,City,State,ZipCode,EmailID,PhoneNo,ContactNo,
									DateOfRegistry,Remarks,LeadSourceID,LeadSourceName,LeadSourceContact,User_ID)
		
		values (@FullName,@BusinessName,@ContactPerson,@StreetNo,@City,@State,@ZipCode,@EmailID,@PhoneNo,@ContactNo,
				@DateOfRegistry,@Remarks,@LeadSourceID,@LeadSourceName,@LeadSourceContact,@User_ID)
		
		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN
	
		UPDATE CRM_ClientInfo
		set
		FullName=@FullName,
		BusinessName=@BusinessName,
		ContactPerson=@ContactPerson,
		StreetNo=@StreetNo,
		City=@city,
		State=@State,
		ZipCode=@ZipCode,
		EmailID=@EmailID,
		PhoneNo=@PhoneNo,
		ContactNo=@ContactNo,
		DateOfRegistry=@DateOfRegistry,
		Remarks=@Remarks,
		LeadSourceID=@LeadSourceID,
		LeadSourceName=@LeadSourceName,
		LeadSourceContact=@LeadSourceContact,
		User_ID=@User_ID

		where ID=@ClientID
		
	SELECT @ClientID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditExternalSaleMaster]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[usp_AddOrEditExternalSaleMaster]
@ID int,
@RONum nvarchar(40),
@Date date,
@DeliveryDate date,
@NormalRo nvarchar(50),
@ComBackRO nvarchar(50),
@CWaiting nvarchar(30),
@CNonWating nvarchar(30),
@Remarks nvarchar(200),
@Driver nvarchar(40),
@CustomerName nvarchar(50),
@CompanyName nvarchar(50),
@CarID int,
@Description nvarchar(200),
@Year nvarchar(20),
@ModelCode nvarchar(30),
@RegNo nvarchar(40),
@VNNo nvarchar(30),
@Kmtr nvarchar(20),
@Color nvarchar(30)
as
	if @ID=0 begin
		insert into ExternalSale_Master (ROnum,Date,DeliveryDate,NormalRO,CombackRO,CWaiting,CNonWaiting,Remarks,Driver,CustomerName,CompanyName,CarID,Description,Year,ModelCode,RegNo,VNNo,Kmtr,Color)
		values (@RONum,@Date,@DeliveryDate,@NormalRo,@ComBackRO,@CWaiting,@CNonWating,@Remarks,@Driver,@CustomerName,@CompanyName,@CarID,@Description,@Year,@ModelCode,@RegNo,@VNNo,@Kmtr,@Color)
		
		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN

		UPDATE ExternalSale_Master
		set 
		--TranDate=@TranDate,
		ROnum=@RONum,
		Date=@Date,
		DeliveryDate=@DeliveryDate,
		NormalRO=@NormalRo,
		CombackRO=@ComBackRO,
		CWaiting=@CWaiting,
		CNonWaiting=@CNonWating,
		Remarks=@Remarks,
		Driver=@Driver,
		CustomerName=@CustomerName,
		CompanyName=@CompanyName,
		CarID=@CarID,
		Description=@Description,
		Year=@Year,
		ModelCode=@ModelCode,
		RegNo=@RegNo,
		VNNo=@VNNo,
		Kmtr=@Kmtr,
		Color=@Color
		
			
		where ID=@ID
		
	SELECT @ID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditItemMaster]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_AddOrEditItemMaster]
@ItemID int,
@TranDate datetime,
@PartNo nvarchar(50),
@Description nvarchar(100),
@StockQty int,
@Unit_ID int,
@Cost decimal(18,2),
@ThrashHoldQty int,
@category nvarchar(10),
@User_ID int,
@TransactionType nvarchar(15)
as
	if @ItemID=0 begin
		insert into Item_Master (TranDate,PartNo,Description,StockQty,Unit_ID,Cost,thrashHoldqty,Category,User_ID,TransactionType)
		values (@TranDate,@PartNo,@Description,@StockQty,@Unit_ID,@Cost,@ThrashHoldQty,@category,@User_ID,@TransactionType)
		
		--insert into stock_Master (TranDate,PartNo,Description,StockQty,Unit_ID,Cost,User_ID)
		--values (@TranDate,@PartNo,@Description,@StockQty,@Unit_ID,@Cost,@User_ID)

		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN

		UPDATE Item_Master
		set 
		--TranDate=@TranDate,
		PartNo=@PartNo,
		Description=@Description,
		StockQty=@StockQty,
		Unit_ID=@Unit_ID,
		Cost=@Cost,
		thrashholdqty=@ThrashHoldQty,
		Category=@Category,
		User_ID=@User_ID,
		TransactionType=@TransactionType
		
			
		where ItemID=@ItemID
		
	SELECT @ItemID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditSupplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_AddOrEditSupplier]
@SupplierID int,
@CompanyName nvarchar(50),
@Address nvarchar(100),
@City nvarchar(50),
@State nvarchar(50),
@PinCode nvarchar(50),
@Country nvarchar(50),
@EmailID nvarchar(50),
@PhoneNo nvarchar(20),
@BankName nvarchar(100),
@BankAccountNumber nvarchar(50),
@ContactPerson nvarchar(50),
@ContactNo nvarchar(20),
@Remarks nvarchar(200)
as
	if @SupplierID=0 begin
		insert into CRM_Supplier (CompanyName,Address,City,State,PinCode,Country,Email,PhoneNo,BankName,BankAccountNumber,ContactPerson,ContactNo,RemarkNote)
		values (@CompanyName,@Address,@City,@State,@PinCode,@Country,@EmailID,@PhoneNo,@BankName,@BankAccountNumber,@ContactPerson,@ContactNo,@Remarks)
		
		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN

		UPDATE CRM_Supplier
		set 
		CompanyName=@CompanyName,
		Address=@Address,
		City=@City,
		State=@State,
		PinCode=@PinCode,
		Country=@Country,
		Email=@EmailID,
		PhoneNo=@PhoneNo,
		BankName=@BankName,
		BankAccountNumber=@BankAccountNumber,
		ContactPerson=@ContactPerson,
		ContactNo=@ContactNo,
		RemarkNote=@Remarks
			
		where SupplierID=@SupplierID
		
	SELECT @SupplierID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditUnit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_AddOrEditUnit]
@UnitID int,
@Code nvarchar(10),
@Unit nvarchar(20),
@User_ID int
as
	if @UnitID=0 begin
		insert into Unit_OM (Code,UnitTitle,User_ID)
		values (@Code,@Unit,@User_ID)
		
		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN

		UPDATE Unit_OM
		set 
		Code=@code,
		UnitTitle=@Unit,
		User_ID=@User_ID
		
			
		where UnitID=@UnitID
		
	SELECT @UnitID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrEditUserType]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_AddOrEditUserType]
@UserTypeID int,
@UserTypeTitle nvarchar(10),
@User_ID int
as
	if @UserTypeID=0 begin
		insert into UserTypeTable (UserTypeTitle,user_ID)
		values (@UserTypeTitle,@User_ID)
		
		select SCOPE_IDENTITY();
		
		END
	ELSE BEGIN

		UPDATE UserTypeTable
		set 
		UserTypeTitle=@UserTypeTitle,
		User_ID=@User_ID
		where UserTypeID=@UserTypeID
		
	SELECT @UserTypeID;
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteItem]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteItem]
@ID int
as
begin
	Delete from Item_Master where ItemID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteSupplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteSupplier]
@SupplierID int
as
begin
	Delete from CRM_Supplier where SupplierID=@SupplierID
end
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUnit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteUnit]
@ID int
as
begin
	Delete from Unit_OM where UnitID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetClientInfo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[usp_GetClientInfo]
as
begin
select ID,FullName,ContactNo from CRM_ClientInfo
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetClients]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetClients]
as
begin
select * from view_clientinfo
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetItemMaster]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[usp_GetItemMaster]
as
begin
select ItemID,PartNo,Description,StockQty,UnitTitle,Cost,thrashHoldQty,category from View_ItemMASTER
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetItemOpening]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetItemOpening]
as
begin
select * from View_StockOpening
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPurchase_List]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetPurchase_List]
as
begin
	select * from View_PurchaseList
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSharedLeadSource]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[usp_GetSharedLeadSource]
as
begin
select * from LeadSource
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSharedUnit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetSharedUnit]
as
begin
select UnitID,code,UnitTitle from Unit_OM
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSharedUserType]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[usp_GetSharedUserType]
as
begin
select UserTypeID,UserTypeTitle from UserTypeTable
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetSupplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GetSupplier]
as
begin
select * from crm_supplier
end
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserType]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GetUserType]
as
begin
select UserTypeID,UserTypeTitle from UserTypeTable
end
GO
/****** Object:  StoredProcedure [dbo].[usp_InvoiceAlphaNumber]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_InvoiceAlphaNumber]
as
begin
declare @maxno int,@no varchar(50);
	select @maxno=isnull(max(cast(right(SaleID,9) as int)),0)+1 from Sale_Master;
	select 'P'+'-'+ right('0000'+ CAST (@maxno as varchar),4);
end
GO
/****** Object:  StoredProcedure [dbo].[usp_PickCostByPartNo]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_PickCostByPartNo]
@PartNo nvarchar(20)
as
begin
select unitCost from pickcgscost WHERE PARTNO=@PartNo
end
GO
/****** Object:  StoredProcedure [dbo].[usp_QuantityInHand]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_QuantityInHand]
@PartNo int
as
begin
select partno,sum(stockQty) as QuantityInHand from (
select PartNo,stockQty from Item_Master where PartNo=@PartNo  union all
select Item_title,-1*qty qty from sale_detail where Item_title=@PartNo
) as a
group by Partno
end
GO
/****** Object:  StoredProcedure [dbo].[usp_ROAlphaNumber]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_ROAlphaNumber]
as
begin
declare @maxno int,@no varchar(50);
	select @maxno=isnull(max(cast(right(ID,9) as int)),0)+1 from ExternalSale_Master;
	select 'RO'+'-'+ right('0000'+ CAST (@maxno as varchar),4);
end

















GO
/****** Object:  StoredProcedure [dbo].[usp_SaleList]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SaleList]
as
begin
select BillNO,SaleDate,Amount from Sale_Master
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchClient]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchClient]
@ClientTitle nvarchar(50)
as
begin
select * from View_ClientInfo where FullName like '%'+@ClientTitle+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchItem]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchItem]
@PartNo nvarchar(50)
as
begin
select ItemID,PartNo,Description,StockQty,UnitTitle,Cost from view_ItemMaster where PartNo like '%'+@PartNo+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchOpeningStock]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchOpeningStock]
@PartNo nvarchar(50)
as
begin
select ItemID,PartNo,StockQty from view_ItemMaster where PartNo like '%'+@PartNo+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchPurchase_Invoice]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchPurchase_Invoice]
@InvoiceNumber nvarchar(50)
as
begin
select partyNumber,PurchaseDate,TotalAmount from view_purchaseList where partyNumber like '%'+@InvoiceNumber+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchSale_Invoice]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchSale_Invoice]
@InvoiceNumber nvarchar(50)
as
begin
select BillNo,SaleDate,Amount from Sale_Master where BillNo like '%'+@InvoiceNumber+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchSupplier]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchSupplier]
@CompanyName nvarchar(50)
as
begin
select * from CRM_Supplier where CompanyName like '%'+@CompanyName+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchUnit]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchUnit]
@Unit nvarchar(50)
as
begin
select UnitID,code,UnitTitle from Unit_OM where UnitTitle like '%'+@Unit+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchUserType]    Script Date: 17-Jun-23 9:48:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SearchUserType]
@UserType nvarchar(50)
as
begin
select UserTypeID,UserTypeTitle from UserTypeTable where UserTypeTitle like '%'+@UserType+'%'
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Purchase_Master"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 288
               Right = 255
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Purchase_Detail"
            Begin Extent = 
               Top = 7
               Left = 303
               Bottom = 236
               Right = 522
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "CRM_Supplier"
            Begin Extent = 
               Top = 7
               Left = 570
               Bottom = 293
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "TBL_User"
            Begin Extent = 
               Top = 7
               Left = 853
               Bottom = 170
               Right = 1047
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Purchase_Report_Invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Purchase_Report_Invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Sale_Invoice_Preview"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 15
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'sale_Collection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'sale_Collection'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Sale_Master"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 300
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Sale_Detail"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 290
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CRM_ClientInfo"
            Begin Extent = 
               Top = 7
               Left = 522
               Bottom = 299
               Right = 755
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "TBL_User"
            Begin Extent = 
               Top = 7
               Left = 803
               Bottom = 276
               Right = 997
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Sale_Invoice_Preview'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Sale_Invoice_Preview'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CRM_ClientInfo"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "LeadSource"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 294
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ClientInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ClientInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "u"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ut"
            Begin Extent = 
               Top = 175
               Left = 48
               Bottom = 316
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetUserProfileInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetUserProfileInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Item_Master"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 306
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Unit_OM"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ItemMaster'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ItemMaster'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CRM_Supplier"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 191
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Supplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Supplier'
GO
USE [master]
GO
ALTER DATABASE [QBranch] SET  READ_WRITE 
GO
