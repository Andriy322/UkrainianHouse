CREATE OR ALTER VIEW ProjectView AS
SELECT 
	p.project_id,
	p.project_name,
	l.city,
	l.address,
	e.first_name,
	e.last_name,
	mat.material_name,
	oper.count,
	dat.calendar_date,
	st.storage_id
FROM Project as p
JOIN Location as l
ON p.location_id = l.location_id
JOIN BridgeEmployeeProject as bridge
ON p.project_id = bridge.project_id
JOIN Employee as e
ON e.employee_id = bridge.employee_id
JOIN Operation as oper 
ON p.project_id = oper.project_id
JOIN Date as dat 
ON oper.date_id = dat.date_id
JOIN Material as mat
ON mat.material_id = oper.material_id
JOIN Storage as st
ON st.material_id = mat.material_id


SELECT * FROM ProjectView;


CREATE OR ALTER VIEW EmployeeView AS
SELECT 
	p.project_id,
	p.project_name,
	l.city,
	l.address,
	e.first_name,
	e.last_name,
	e.specialization,
	ac.salary,
	dat.calendar_date
FROM Project as p
JOIN Location as l
ON p.location_id = l.location_id
JOIN BridgeEmployeeProject as bridge
ON p.project_id = bridge.project_id
JOIN Employee as e
ON e.employee_id = bridge.employee_id
JOIN Accounting as ac 
ON e.employee_id = ac.employee_id
JOIN Date as dat 
ON ac.date_id= dat.date_id



SELECT * FROM EmployeeView;


EXECUTE AS LOGIN = 'Oksana'
SELECT SUSER_SNAME()


CREATE OR ALTER VIEW ManagerView AS
SELECT 
	p.project_id,
	p.project_name,
	l.city,
	l.address,
	oper.operation_id,
	dat.calendar_date
FROM Project as p
JOIN Location as l
ON p.location_id = l.location_id
JOIN BridgeEmployeeProject as bridge
ON p.project_id = bridge.project_id
JOIN Employee as e
ON e.employee_id = bridge.employee_id
JOIN Operation as oper 
ON p.project_id = oper.project_id
JOIN Date as dat 
ON oper.date_id = dat.date_id
WHERE e.employee_id IN(SELECT employee_id FROM Employee where e.first_name = SUSER_NAME())

EXECUTE AS LOGIN = 'Oksana'
SELECT * FROM ManagerView;





SELECT * FROM ManagerView



IS_ROLEMEMBER('EnterpriseHead') = 1;


