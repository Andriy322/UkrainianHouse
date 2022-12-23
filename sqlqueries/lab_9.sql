

CREATE INDEX index1 ON dbo.operation (project_id);

CREATE INDEX index2 ON dbo.operation (material_id);

CREATE INDEX index3 ON dbo.accounting (employee_id);

SET STATISTICS TIME ON;
SELECT * FROM Accounting
WITH(INDEX(index3))
WHERE employee_id = 1;
SET STATISTICS TIME  OFF;  

SET STATISTICS TIME ON;
SELECT * FROM Accounting
WHERE employee_id = 1;
SET STATISTICS TIME  OFF;