USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Project]
           ([project_name],
           [project_status]
           ,[project_manager]
           ,[location_id])
     VALUES
           ('Tower'
           ,'Active'
           ,1
           ,1
		   ),
		    ('Paradise'
           ,'Active'
           ,1
           ,2
		   ),
		    ('Hospital'
           ,'Not active'
           ,2
           ,3
		   )
GO



USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Location]
           ([location_id]
           ,[country]
           ,[city]
           ,[address])
     VALUES
           (1
           ,'Ukraine'
           ,'Lviv'
           ,'Ivasuka 25'),
		   (2
           ,'Ukraine'
           ,'Lviv'
           ,'Bandera 12'),
		   (3
           ,'Ukraine'
           ,'Lviv'
           ,'Gorodotska 144')
GO





USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Employee]
           ([employee_id]
           ,[first_name]
           ,[last_name]
           ,[age]
           ,[phone]
           ,[active_flag]
           ,[specialization])
     VALUES
           (1
           ,'Andrii'
           ,'Fostiak'
           ,20
           ,'0986154732'
           ,1
           ,'manager'),
		    (2
           ,'Oksana'
           ,'Fostiak'
           ,26
           ,'0988454732'
           ,1
           ,'manager'),
		    (3
           ,'Ivan'
           ,'Ivanov'
           ,45
           ,'0989898321'
           ,0
           ,'builder')

GO





USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Accounting]
           ([transaction_id]
           ,[salary]
           ,[employee_id]
           ,[date_id])
     VALUES
           (1
           ,10000
           ,1
           ,1),
		   (2
           ,15000
           ,2
           ,2),
		   (3
           ,10000
           ,1
           ,3),
		   (4
           ,6000
           ,3
           ,4)

GO




USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Date]
           ([date_id]
           ,[calendar_date]
           ,[year]
           ,[month]
           ,[day])
     VALUES
           (1
           ,'2021-10-03'
           ,2021
           ,10
           ,3),
		   (2
           ,'2021-09-03'
           ,2021
           ,9
           ,3),
		   (3
           ,'2021-11-03'
           ,2021
           ,11
           ,3),
		   (4
           ,'2021-12-03'
           ,2021
           ,12
           ,3)
GO




USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Material]
           ([material_id]
           ,[material_name]
           ,[price])
     VALUES
           (1
           ,'Brick'
           ,10),
		    (2
           ,'Concrete'
           ,50),
		    (3
           ,'Window'
           ,1000)
GO

INSERT INTO [dbo].[Material]
           ([material_id]
           ,[material_name]
           ,[price])
     VALUES
           (4
           ,'Wood'
           ,20)

GO

USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Storage]
           ([storage_id]
           ,[material_id]
           ,[count]
           ,[comments])
     VALUES
           (1
           ,1
           ,100
           ,'need to order'),
		     (2
           ,2
           ,50           
		   ,'need to order'),

		     (3
           ,3
           ,5
           ,'need to order')

GO



USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Operation]
           ([operation_id]
           ,[material_id]
           ,[count]
           ,[project_id]
           ,[date_id])
     VALUES
           (1
           ,1
           ,100
           ,1
           ,1),

		    (2
           ,2
           ,50
           ,2
           ,2),

		    (3
           ,3
           ,-5
           ,3
           ,3)
GO
USE [ÑonstructionÑompany]
GO

INSERT INTO [dbo].[Operation]
           ([operation_id]
           ,[material_id]
           ,[count]
           ,[project_id]
           ,[date_id])
     VALUES
           (4
           ,1
           ,10
           ,1
           ,4)
GO

SELECT * FROM Project as p
join Location as l on p.location_id = l.location_id
join Employee as e on p.project_manager = e.employee_id
join Accounting as a on e.employee_id = a.employee_id;




/*starting lab number 3 */

/*starting lab number 3 */

/*starting lab number 3 */


/*changing the order in which attributes are written in the table*/

INSERT INTO [dbo].[Project]
           ([location_id],
		   [project_status],
		   [project_name],
           [project_manager]
          )
     VALUES
		    (4,
			'Not active'
           ,'Hospital'
           ,2
		   )
GO


ALTER TABLE Project COLUMN project_manager to employee_id;
/*write to one of the attributes of the default value*/
EXEC sp_RENAME 'Project.project_manager', 'employee_id', 'COLUMN'

SELECT * FROM Project

INSERT INTO [dbo].[Storage]
           ([storage_id]
           ,[material_id]
           ,[count]
           ,[comments])
     VALUES
           (1
           ,1
           ,100
           ,DEFAULT)
GO

/*inserts the result of the SELECT query into the table*/

INSERT INTO Accounting VALUES(5, 10000,(SELECT employee_id FROM Employee WHERE employee_id = 1),
(SELECT date_id FROM Date WHERE date_id = 1) )

SELECT * FROM Accounting;

DELETE FROM Accounting
  WHERE transaction_id = 5;

INSERT INTO [dbo].[Project]
           ([location_id],[project_status],[project_name],[employee_id])
     VALUES
		    (3,'Not active','Hospital',2)
GO

  DELETE FROM Project
  WHERE project_id = 6;

SELECT * FROM Project;


INSERT INTO [dbo].[Storage]
           ([storage_id],[material_id],[count],[comments])
     VALUES
           (3,3,5,'need to order')
GO

SELECT * FROM Storage;
DELETE FROM Storage
  WHERE storage_id = 3;

/*using requests and UNION command*/

SELECT date_id
FROM Accounting
UNION
SELECT date_id
FROM Operation
ORDER BY date_id;

/*request to db which update 1 record*/

UPDATE Accounting
SET salary = 15000
WHERE employee_id=2;

SELECT * FROM Accounting;


/*request to db which update 2 records*/

UPDATE Material
SET
material_name = 'cement',
price = 125
WHERE
material_id = 2;


/*request to db which updates the table using a subquery */

UPDATE Accounting
SET salary=(SELECT salary FROM Accounting WHERE employee_id = 3)

SELECT * FROM Accounting;

/*request to db which updates the table using subqueries */


UPDATE Accounting
SET
salary = (SELECT salary FROM Accounting WHERE employee_id = 3),
employee_id =(SELECT employee_id FROM Accounting WHERE transaction_id = 4)
where salary = 6000;


SELECT * FROM Accounting;

/*where salary = 12000;check this task i made some mahination*/

/*using join + Update task 2  */


UPDATE Accounting
SET Accounting.salary = 13000
FROM Accounting a
JOIN Employee e ON a.employee_id = e.employee_id WHERE a.employee_id = 1;


UPDATE Accounting
SET Salary = 12000
WHERE Accounting.employee_id IN(SELECT Employee.employee_id FROM Employee WHERE Employee.first_name = 'Andrii' AND Employee.specialization = 'manager')


SELECT * FROM Accounting;

/*using DELETE */

DELETE FROM Accounting WHERE salary = 6000;

/*delete multiple queries*/

DELETE FROM Accounting WHERE salary > 6000;


/*request to db whice delete records with using subquery*/

DELETE FROM Accounting
WHERE salary < 8000 AND employee_id IN (SELECT Accounting.employee_id FROM Accounting WHERE Accounting.employee_id = 3)

DELETE Accounting FROM Accounting
INNER JOIN Date ON  Accounting.date_id = Date.date_id WHERE Date.month = 10;







/*lab 4 */

/* first request in 4 lab*/

SELECT d.date_id,d.calendar_date,oper.date_id,oper.material_id
FROM Date d
Join Operation oper
ON d.date_id = oper.date_id
WHERE
   oper.material_id = 3;


/* second request in 4 lab*/

SELECT d.date_id,d.calendar_date,oper.material_id
FROM Date d,Operation oper
WHERE oper.material_id = 2 AND  d.date_id = oper.date_id; 




/*third request in 4 lab*/


SELECT oper.date_id, d.date_id,a.date_id
FROM Operation oper
JOIN Date d 
ON oper.date_id = d.date_id
JOIN Accounting a
ON d.date_id = a.date_id;

/*four request in 4 lab*/

SELECT p.project_name
FROM PROJECT p
JOIN Employee e
ON p.project_manager = e.employee_id
WHERE p.project_status = 'Active' AND e.specialization = 'manager';



SELECT d.date_id,d.calendar_date
FROM DATE d
INNER JOIN Operation oper
ON oper.date_id = d.date_id
JOIN Material as mat
ON mat.material_id = oper.material_id
WHERE mat.material_name = 'Window';


SELECT d.calendar_date
FROM DATE d
JOIN Operation oper
ON oper.date_id = d.date_id
JOIN Accounting a
ON a.date_id = oper.date_id;


SELECT p.project_id,first_name,e.last_name,e.phone
FROM Project as p
JOIN Employee e
ON p.project_manager = e.employee_id
JOIN Location as l
ON l.location_id = p.location_id;


