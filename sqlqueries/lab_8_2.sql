
SELECT resource_type, resource_associated_entity_id,
 request_mode,request_status
 FROM sys.dm_tran_locks dml
 INNER JOIN sys.dm_tran_current_transaction dmt
 ON dml.request_owner_id = dmt.transaction_id;

Set transaction isolation level read committed
Set transaction isolation level Serializable;

begin tran
SELECT * FROM Operation
Where material_id = 2;
waitfor delay '00:00:20'
SELECT * FROM Operation
Where material_id = 2;
commit tran



begin tran 
S
