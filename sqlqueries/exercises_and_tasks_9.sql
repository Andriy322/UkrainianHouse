SELECT SalesOrderID, orderQTY
FROM Sales.SalesOrderDetail
WHERE productid=712 ORDER BY orderQTY DESC
DROP TABLE dbo.Orders;

DROP TABLE dbo.OrderDetails;

USE AdventureWorks2019;
GO
CREATE TABLE dbo.Orders( SalesOrderID int NOT NULL,
 OrderDate datetime NOT NULL,
 ShipDate datetime NULL,
 Status tinyint NOT NULL,
 PurchaseOrderNumber dbo.OrderNumber NULL,
 CustomerID int NOT NULL,
 SalesPersonID int NULL
 );
CREATE TABLE dbo.OrderDetails( SalesOrderID int NOT NULL,
 SalesOrderDetailID int NOT NULL,
 CarrierTrackingNumber nvarchar(25),
 OrderQty smallint NOT NULL,
 ProductID int NOT NULL,
 UnitPrice money NOT NULL,
 UnitPriceDiscount money NOT NULL,
 LineTotal AS (isnull((UnitPrice*((1.0)-
UnitPriceDiscount))*OrderQty,(0.0)))
 );
INSERT INTO dbo.Orders
SELECT SalesOrderID, OrderDate, ShipDate, Status, PurchaseOrderNumber,
 CustomerID, SalesPersonID
 FROM Sales.SalesOrderHeader;
INSERT INTO dbo.OrderDetails(SalesOrderID, SalesOrderDetailID,
 CarrierTrackingNumber, OrderQty,
 ProductID, UnitPrice, UnitPriceDiscount) 
SELECT SalesOrderID, SalesOrderDetailID,CarrierTrackingNumber,OrderQty,
 ProductID, UnitPrice, UnitPriceDiscount
 FROM Sales.SalesOrderDetail; SET STATISTICS IO ON;
SELECT * FROM dbo.Orders;
SET STATISTICS IO OFF


SET STATISTICS IO ON;
SELECT * FROM dbo.Orders WHERE SalesOrderID =46699;
SET STATISTICS IO OFF;CREATE UNIQUE CLUSTERED INDEX CLIDX_Orders_SalesOrderID
 ON dbo.Orders(SalesOrderID) SET STATISTICS IO ON;
SELECT * FROM dbo.Orders;
SELECT * FROM dbo.Orders
 WHERE SalesOrderID =46699;
SET STATISTICS IO OFF;SELECT * FROM dbo.Orders ORDER BY SalesOrderID;
SELECT * FROM dbo.Orders ORDER BY OrderDate;CREATE UNIQUE CLUSTERED INDEX CLIDX_OrderDetails
 ON dbo.OrderDetails(SalesOrderID,SalesOrderDetailID) SELECT * FROM dbo.OrderDetails
 WHERE SalesOrderID = 46999
SELECT * FROM dbo.OrderDetails
WHERE SalesOrderDetailID = 14147CREATE INDEX NCLIX_OrderDetails_ProductID
 ON dbo.OrderDetails(ProductID) SELECT DISTINCT SalesOrderID, CarrierTrackingNumber
 FROM dbo.OrderDetails
 WHERE ProductID = 776 SET STATISTICS IO ON

SELECT DISTINCT SalesOrderID, CarrierTrackingNumber
 FROM dbo.OrderDetails
 WHERE ProductID = 776

SELECT DISTINCT SalesOrderID
 FROM dbo.OrderDetails
 WHERE ProductID = 776
SET STATISTICS IO OFFDROP INDEX dbo.OrderDetails.NCLIX_OrderDetails_ProductID
CREATE INDEX NCLIX_OrderDetails_ProductID
 ON dbo.OrderDetails(ProductID)
 INCLUDE (CarrierTrackingNumber) SET STATISTICS IO ON
SELECT o.SalesOrderID, o.OrderDate, od.ProductID
 FROM dbo.Orders o INNER JOIN dbo.OrderDetails od
 ON o.SalesOrderID = od.SalesOrderID
 WHERE o.SalesOrderID = 43659 SELECT o.SalesOrderID, o.OrderDate, od.ProductID
 FROM dbo.Orders o
 INNER JOIN dbo.OrderDetails od
 ON o.SalesOrderID = od.SalesOrderID 
 WHERE o.SalesOrderID BETWEEN 43659 AND 44000 DROP INDEX CLIDX_Orders_SalesOrderID ON dbo.Orders
DROP INDEX CLIDX_OrderDetails ON dbo.OrderDetailsSELECT o.SalesOrderID, o.OrderDate, od.ProductID
 FROM dbo.Orders o INNER JOIN dbo.OrderDetails od
 ON o.SalesOrderID = od.SalesOrderID
 WHERE o.SalesOrderID = 43659
SELECT o.SalesOrderID, o.OrderDate, od.ProductID
 FROM dbo.Orders o INNER JOIN dbo.OrderDetails od
ON o.SalesOrderID = od.SalesOrderID
 WHERE o.SalesOrderID BETWEEN 43659 AND 44000