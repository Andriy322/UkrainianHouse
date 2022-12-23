USE tempdb;
GO
CREATE TABLE table1 (
i int NOT NULL PRIMARY KEY,
col1 varchar(20) NOT NULL,
col2 varchar(20) NULL);USE tempdb;
GO
INSERT INTO table1 (i,col1,col2)
VALUES (1,'First row','First row');
INSERT INTO table1 (i,col1,col2)
VALUES (2,NULL,'Second row');
INSERT INTO table1 (i,col1,col2)
VALUES (3,'Third row','Third row')


USE tempdb;
GO
SELECT i,col1,col2
FROM table1;

USE tempdb;
GO
TRUNCATE TABLE table1;USE tempdb;
GO
BEGIN TRAN
INSERT INTO table1 (i,col1,col2) VALUES (1,'First row','First row');
INSERT INTO table1 (i,col1,col2) VALUES (2,NULL,'Second row');
INSERT INTO table1 (i,col1,col2) VALUES (3,'Third row','Third row');
COMMIT TRAN;USE tempdb;
GO
SELECT i,col1,col2
FROM table1;TRUNCATE TABLE table1
--транзакція з обробником помилок
BEGIN TRY
BEGIN TRAN
 INSERT INTO table1 (i,col1,col2) VALUES (1,'First row','First row');
 INSERT INTO table1 (i,col1,col2) VALUES (2,NULL,'Second row');
 INSERT INTO table1 (i,col1,col2) VALUES (3,'Third row','Third row');
COMMIT TRAN;
END TRY
BEGIN CATCH
SELECT ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
 ERROR_MESSAGE() as ErrorMessage;
 RAISERROR('Error in Transaction!',14,1)
 ROLLBACK TRAN
END CATCH;BEGIN CATCH
DECLARE @er nvarchar(max)
SET @er = "Error: "+ ERROR_MESSAGE();
RAISERROR(@er,14,1);
ROLLBACK TRAN END CATCH;TRUNCATE TABLE table1
--транзакція з обробником помилок
BEGIN TRY
BEGIN TRAN
 INSERT INTO table1 (i,col1,col2) VALUES (1,'First row','First row');
 INSERT INTO table1 (i,col1,col2) VALUES (2,NULL,'Second row');
 INSERT INTO table1 (i,col1,col2) VALUES (3,'Third row','Third row');
COMMIT TRAN;
END TRY
BEGIN CATCH
DECLARE @er nvarchar(max)
SET @er = 'Error: '+ ERROR_MESSAGE();
RAISERROR(@er,14,1);
 ROLLBACK TRAN
END CATCH;SET IMPLICIT_TRANSACTIONS ON;GOCREATE TABLE T1 (i int PRIMARY KEY);INSERT INTO T1 VALUES(5);
GO
SELECT @@TRANCOUNT AS [Transaction Count];ROLLBACK TRAN
GO
SELECT @@TRANCOUNT AS [Transaction Count];SET IMPLICIT_TRANSACTIONS OFF;PRINT "Trancount before transaction: " +
 CAST(@@trancount as char(1))
BEGIN TRAN
PRINT "After first BEGIN TRAN: " +
 CAST(@@trancount as char(1))
BEGIN TRAN
PRINT "After second BEGIN TRAN: " +
 CAST(@@trancount as char(1))
COMMIT TRAN
PRINT "After first COMMIT TRAN: " +
 CAST(@@trancount as char(1))
8
COMMIT TRAN
PRINT "After second COMMIT TRAN: " +
 CAST(@@trancount as char(1)) USE AdventureWorks2019
BEGIN TRAN
PRINT "After 1st BEGIN TRAN: " +
 CAST(@@trancount as char(1))
BEGIN TRAN
PRINT "After 2nd BEGIN TRAN: " +
 CAST(@@trancount as char(1))
BEGIN TRAN
PRINT "After 3rd BEGIN TRAN: " +
 CAST(@@trancount as char(1))
UPDATE Person.Contact
SET EmailAddress = "test@test.at"
WHERE ContactID = 20
COMMIT TRAN
PRINT "After first COMMIT TRAN: " +
 CAST(@@trancount as char(1))
ROLLBACK TRAN
PRINT "After ROLLBACK TRAN: " +
 CAST(@@trancount as char(1))
SELECT EmailAddress FROM Person.Contact
WHERE ContactID = 20;USE AdventureWorks;
GO
BEGIN TRAN
SELECT FirstName,LastName,EmailAddress
 FROM Person.Contact WITH (HOLDLOCK)
 WHERE ContactID= 15 SELECT resource_type, resource_associated_entity_id,
 request_mode,request_status
 FROM sys.dm_tran_locks dml
 INNER JOIN sys.dm_tran_current_transaction dmt
 ON dml.request_owner_id = dmt.transaction_id;
COMMIT TRANBEGIN TRAN
SELECT FirstName,LastName,EmailAddress
 FROM Person.Contact WITH (HOLDLOCK)
 WHERE ContactID <7000; USE AdventureWorks;
GO
BEGIN TRAN
UPDATE Person.Contact
SET Phone ='+43 555 333 222'
 WHERE ContactID =25;
SELECT resource_type, resource_associated_entity_id,
 request_mode,request_status
 FROM sys.dm_tran_locks dml
 INNER JOIN sys.dm_tran_current_transaction dmt
 ON dml.request_owner_id = dmt.transaction_id;
ROLLBACK TRANUSE AdventureWorks;
BEGIN TRAN
16
SELECT FirstName, LastName, EmailAddress
 FROM Person.Contact
 WHERE ContactID = 1; USE AdventureWorks; BEGIN TRAN
UPDATE Person.Contact
SET EmailAddress = "uncommitted@email.at"
 WHERE ContactID = 1; SELECT resource_type, resource_associated_entity_id,
request_mode, request_status
FROM sys.dm_tran_locks

USE OperationsDB
GO
SELECT SalesOrderID, SalesOrderDetailID,
 ProductID, OrderQty
 FROM Sales.SalesOrderDetail
 WHERE SalesOrderID = 43659
COMMIT TRANGO
-- Створення процедури для отримання інформації
-- про помилку.
CREATE PROCEDURE usp_GetErrorInfo
AS
 SELECT
 ERROR_NUMBER() AS ErrorNumber,
 ERROR_SEVERITY() AS ErrorSeverity,
 ERROR_STATE() AS ErrorState,
 ERROR_LINE () AS ErrorLine,
 ERROR_PROCEDURE() AS ErrorProcedure,
 ERROR_MESSAGE() AS ErrorMessage;
GO
-- Встановлення параметру SET XACT_ABORT ON зробить
-- транзакції нефіксованими якщо виникне помилка
SET XACT_ABORT ON;
BEGIN TRY
 BEGIN TRANSACTION;
 -- Існує зовнішній ключ в цій таблиці.
 -- Ця інструкція згенерує помилку.
 DELETE FROM Production.Product
 WHERE ProductID = 980;
 -- Якщо видалення успішне, підтвердити
 -- транзакцію.
 COMMIT TRAN USE AdventureWorks;
GO
BEGIN TRANSACTION;
BEGIN TRY
 -- Генерується помилка порушення обмеженення.
 DELETE FROM Production.Product
 WHERE ProductID = 980;
END TRY
BEGIN CATCH
 SELECT
 ERROR_NUMBER() AS ErrorNumber,
 ERROR_SEVERITY() AS ErrorSeverity,
 ERROR_STATE() AS ErrorState,
 ERROR_PROCEDURE() AS ErrorProcedure,
 ERROR_LINE() AS ErrorLine,
 ERROR_MESSAGE() AS ErrorMessage;
 IF @@TRANCOUNT > 0
 ROLLBACK TRANSACTION;
END CATCH;
IF @@TRANCOUNT > 0
 COMMIT TRANSACTION;
GO