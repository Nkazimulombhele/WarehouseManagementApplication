USE [WarehouseManagementDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
	[Description] [ntext] NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
	[Discontinued] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Alphabetical list of products]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Alphabetical list of products] AS
SELECT Products.*, Categories.CategoryName
FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
WHERE (((Products.Discontinued)=0))
GO
/****** Object:  View [dbo].[Current Product List]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Current Product List] AS
SELECT Product_List.ProductID, Product_List.ProductName
FROM Products AS Product_List
WHERE (((Product_List.Discontinued)=0))
--ORDER BY Product_List.ProductName
GO
/****** Object:  View [dbo].[Products by Category]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[Products by Category] AS
SELECT Categories.CategoryName, Products.ProductName, Products.QuantityPerUnit, Products.UnitsInStock, Products.Discontinued
FROM Categories INNER JOIN Products ON Categories.CategoryID = Products.CategoryID
WHERE Products.Discontinued <> 1
--ORDER BY Categories.CategoryName, Products.ProductName
GO
/****** Object:  Table [dbo].[ManagerLogin]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerLogin](
	[ManagerName] [nvarchar](50) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL,
	[PhoneNumber] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 2023/02/01 18:53:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[HomePage] [ntext] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (1, N'Beverages', N'Soft drinks, coffees,teas,beers and ales', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[ManagerLogin] ([ManagerName], [EmailAddress], [Password], [PhoneNumber]) VALUES (N'ManagerName', N'Manager@WorkEmail.co.za', N'12345', N'0641254534')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued]) VALUES (5, N'Chai', 1, 1, N'10 Boxes x 20 bags', 39.0000, 0, 10, 10, N'No')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage]) VALUES (1, N'Exotic Liquids', N'Charlotte Cooper', N'Purchasing Manager', N'49 Gilbert St.', N'London', N'Null', N'EC1 4SD', N'UK', N'(171)555-2222', NULL, NULL)
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage]) VALUES (2, N'New Orleans Cajun Delights', N'Shelley Burke', N'Order Administrator', N'P.O Box 78934', N'New Orleans', N'LA', N'70117', N'USA', N'(100)555-4822', N'Null', N'#CAJUN.HTM#')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitsInStock]  DEFAULT ((0)) FOR [UnitsInStock]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitsOnOrder]  DEFAULT ((0)) FOR [UnitsOnOrder]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_ReorderLevel]  DEFAULT ((0)) FOR [ReorderLevel]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Discontinued]  DEFAULT ((0)) FOR [Discontinued]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_Products_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_UnitPrice]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_ReorderLevel] CHECK  (([ReorderLevel]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_ReorderLevel]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsInStock] CHECK  (([UnitsInStock]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_UnitsInStock]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsOnOrder] CHECK  (([UnitsOnOrder]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_UnitsOnOrder]
GO
/****** Object:  StoredProcedure [dbo].[deleteCategory_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[deleteCategory_sp]
   
     @CategoryId int
	

	as
	begin

	delete from Categories
	    Where CategoryID = @CategoryId
	end
GO
/****** Object:  StoredProcedure [dbo].[deleteProduct_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	Create procedure [dbo].[deleteProduct_sp]
   
     @ProductId int

	as
	begin

	delete from Products
	    Where ProductId = @ProductId
	end
GO
/****** Object:  StoredProcedure [dbo].[deleteSupplier_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	Create procedure [dbo].[deleteSupplier_sp]
   
     @SupplierId int
	

	as
	begin

	delete from Suppliers
	    Where SupplierId = @SupplierId
	end
GO
/****** Object:  StoredProcedure [dbo].[insertCategory_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[insertCategory_sp]
    
	@CategoryName nvarchar(15) ,
	@Description ntext,
	@Picture image

	as
	begin

	insert into Categories(CategoryName,Description,Picture)
	 values(@CategoryName,@Description,@Picture)
	end
GO
/****** Object:  StoredProcedure [dbo].[insertProduct_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertProduct_sp]
    
	@ProductName nvarchar(40),
	@SupplierId int,
	@CategoryId int,
	@QuantityPerUnit nvarchar(20),
	@UnitPrice money,
	@UnitsInStock smallint,
	@UnitsOnOrder smallint,
	@ReorderLevel smallint,
	@discontinued varchar

	as
	begin

	insert into Products(ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,discontinued)
	 values(@ProductName,@SupplierId,@CategoryId,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@discontinued)
	end
GO
/****** Object:  StoredProcedure [dbo].[InsertSuppliers_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertSuppliers_sp]
    
	@CompanyName nvarchar(40) ,
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar(60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24),
	@HomePage ntext

	as
	begin

	insert into Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage)
	 values(@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage)
	end
GO
/****** Object:  StoredProcedure [dbo].[updateCategory_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[updateCategory_sp]
    @CategoryId int,
	@CategoryName nvarchar(15) ,
	@Description ntext,
	@Picture image

	as
	begin

	update Categories
	  set CategoryName = @CategoryName,Description = @Description ,Picture = @Picture
	    Where CategoryID = @CategoryId
	end
GO
/****** Object:  StoredProcedure [dbo].[updateProduct_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	Create procedure [dbo].[updateProduct_sp]
	@ProductId int,
   @ProductName nvarchar(40),
	@SupplierId int,
	@CategoryId int,
	@QuantityPerUnit nvarchar(20),
	@UnitPrice money,
	@UnitsInStock smallint,
	@UnitsOnOrder smallint,
	@ReorderLevel smallint,
	@discontinued bit

	as
	begin

	update Products
	  set ProductName = @ProductName,SupplierID=@SupplierId,CategoryID=@CategoryId,QuantityPerUnit=@QuantityPerUnit,UnitPrice=@UnitPrice,UnitsInStock=@UnitsInStock,UnitsOnOrder=@UnitsOnOrder,ReorderLevel=@ReorderLevel,discontinued=@discontinued
	    Where ProductId = @ProductId
	end
GO
/****** Object:  StoredProcedure [dbo].[updateSuppliers_sp]    Script Date: 2023/02/01 18:53:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[updateSuppliers_sp]
    @SupplierId int,
	@CompanyName nvarchar(40) ,
	@ContactName nvarchar(30),
	@ContactTitle nvarchar(30),
	@Address nvarchar(60),
	@City nvarchar(15),
	@Region nvarchar(15),
	@PostalCode nvarchar(10),
	@Country nvarchar(15),
	@Phone nvarchar(24),
	@Fax nvarchar(24),
	@HomePage ntext

	as
	begin

	update Suppliers
	  set CompanyName = @CompanyName,ContactName = @ContactName ,ContactTitle = @ContactTitle,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode, Country=@Country,Phone=@Phone, Fax=@Fax, HomePage=@HomePage
	    Where SupplierId = @SupplierId
	end
GO
