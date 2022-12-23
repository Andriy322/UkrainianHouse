DBCC USEROPTIONS


SELECT ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
 ERROR_MESSAGE() as ErrorMessage into ErrorLog


 SELECT * FROM ErrorLog;

 SELECT * FROM Operation;

 SELECT * FROM Storage;

 DELETE  FROM Operation
 WHERE project_id is NULL


 Begin try
 Begin tran
 insert into Operation (operation_id,project_id,material_id,count) values (7,2,10,10);
 update Storage
 Set count = count - 10
 WHERE material_id = 2;
 SELECT s.material_id,s.count
 FROM Storage as s
 WHERE material_id = 2;
 Commit tran;
 end try
 Begin catch
 insert into ErrorLog
SELECT ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
 ERROR_MESSAGE() as ErrorMessage
 RAISERROR('Error in transaction!',14,1);
 SELECT * FROM ErrorLog;
 ROLLBACK TRAN
 End catch

 





 Begin try
 Begin tran
 insert into Operation (operation_id,project_id,material_id,count) values (10,2,2,10);
 update Storage
 Set count = count - 10
 WHERE material_id = 2;
 SELECT s.material_id,s.count
 FROM Storage as s
 WHERE material_id = 2;
 
 SELECT resource_type, resource_associated_entity_id,
 request_mode,request_status
 FROM sys.dm_tran_locks dml
 INNER JOIN sys.dm_tran_current_transaction dmt
 ON dml.request_owner_id = dmt.transaction_id;

 Commit tran;
 end try
 Begin catch
 insert into ErrorLog
SELECT ERROR_NUMBER() AS ErrorNumber,
ERROR_SEVERITY() AS ErrorSeverity,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
 ERROR_MESSAGE() as ErrorMessage
 RAISERROR('Error in transaction!',14,1);
 SELECT * FROM ErrorLog;
 ROLLBACK TRAN
 End catch

 Begin tran
 insert into Operation (operation_id,project_id,material_id,count) values (8,2,2,10);
 waitfor delay '00:00:30'
 update Storage
 Set count = count - 10
 WHERE material_id = 2;
  waitfor delay '00:00:30'
 SELECT s.material_id,s.count
 FROM Storage as s
 WHERE material_id = 2;
 Commit tran;

 
 Set transaction isolation level Serializable;

 Set transaction isolation level read committed

 insert into Operation (operation_id,project_id,material_id,count) values (9,2,2,10);
 waitfor delay '00:00:10'
 delete from operation
 where operation_id = 9;