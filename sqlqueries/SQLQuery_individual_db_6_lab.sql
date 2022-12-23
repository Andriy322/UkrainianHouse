USE ConstructionCompany2

Begin tran
DECLARE
    --project table
    @project_project_id int,
	@project_name varchar(255)  ,
	@project_status varchar(255)  ,
	@project_location_id int ,
	
	--location table
	@location_location_id int  ,
	@country varchar(255)  ,
	@city varchar(255)  ,
	@address varchar(255)  ,
	
	--employee table
	@employee_employee_id int  ,
	@first_name varchar(255)  ,
	@last_name varchar(255)  ,
	@age int ,
	@phone varchar(255) ,
	@active_flag int ,
	@specialization varchar(255) ,
	
	--bridgeemployeeproject table
	@employee_project_id int  ,
	
	--material table
	@material_material_id int  ,
	@material_name varchar(255)  ,
	@price int  ,
	@material_comments varchar(255) ,
	
	--storage table
	@storage_id int  ,
	@storage_material_id int  ,
	@storage_count int  ,
	@storage_comments varchar(255) ,
	
	--date table
	@date_date_id int  ,
	@calendar_date date  ,
	@year int ,
	@month int ,
	@day int ,
	
	--accounting table
	@transaction_id int  ,
	@salary int ,
	
	--operation table
	@operation_id int  ,
	@operation_material_id int ,
	@operation_count int  ,
	@operation_project_id int ,
	@operation_date_id int ;

DECLARE @ConstructionCompanyTable TABLE(
     --project table
  project_name varchar(255) NOT NULL,
  project_status varchar(255) NOT NULL,

  --location table
  country varchar(255) NOT NULL,
  city varchar(255) NOT NULL,
  address varchar(255) NOT NULL,

  --employee table
  first_name varchar(255) NOT NULL,
  last_name varchar(255) NOT NULL,
  age int NULL,
  phone varchar(255) NULL,
  active_flag int NULL,
  specialization varchar(255) NULL,

  --bridgeemployeeproject table

  --material table
  material_name varchar(255) NOT NULL,
  price int NOT NULL,
  material_comments varchar(255) NULL,

  --storage table
  storage_count int NOT NULL,
  storage_comments varchar(255) NULL,

  --date table
  calendar_date date NOT NULL,
  year int NULL,
  month int NULL,
  day int NULL,

  --accounting table
  salary int NULL,

  --operation table
  operation_count int NOT NULL
);

INSERT INTO @ConstructionCompanyTable VALUES
(
   'Residence','Active',
   'Ukraine','Lviv','Ivasuka 121',
   'Anton','Serpin',25,'0981727902',1,'Manager',

   'Window',20000,'It is window',
   25,'Is in enough count',
   '20211127',2021,11,27,
   10000,
   10
),
(
   'Estate','Active',
   'Ukraine','Lviv','Dushest 13',
   'Sergii','Fun',23,'0981727998',1,'Builder',

   'Window',20000,'It is window',
   15,'Is in enough count',
   '20211012',2021,10,12,
   8000,
   5
);

DECLARE ConstructionCompanyCursor CURSOR FOR
SELECT * FROM @ConstructionCompanyTable;

OPEN ConstructionCompanyCursor; 

-----------------------------

FETCH NEXT FROM ConstructionCompanyCursor INTO 
   --project table
  @project_name,
  @project_status,
  
  --location table
  @country,
  @city,
  @address,
  
  --employee table
  @first_name,
  @last_name,
  @age,
  @phone,
  @active_flag,
  @specialization,
  
  --bridgeemployeeproject table
  
  --material table
  @material_name,
  @price,
  @material_comments,
  
  --storage table
  @storage_count,
  @storage_comments,
  
  --date table
  @calendar_date,
  @year,
  @month,
  @day,
  
  --accounting table
  @salary,
  
  --operation table
  @operation_count;


  WHILE @@FETCH_STATUS = 0 BEGIN 
  --location table
  DECLARE 
     @maxLocationID int

     SET @maxLocationID = (SELECT max(Location.location_id)
     FROM Location) + 1;
  if not exists(
    SELECT * FROM Location
	WHERE country = @country and 
	city = @city and address = @address
	)insert into Location Values(@maxLocationID,@country,@city,@address);

	SET @location_location_id = (SELECT TOP 1 location_id
                           FROM Location
						   WHERE country = @country and 
	                       city = @city and address = @address);
  

  --project table
  if not exists(
     SELECT * FROM Project
	 WHERE project_name = @project_name and project_status = @project_status
	 AND location_id = @location_location_id
)insert into Project Values(@project_name,@project_status,@location_location_id);

SET @project_project_id = (SELECT TOP 1 project_id
                           FROM Project
						   WHERE project_name = @project_name
						   AND
						   project_status = @project_status AND location_id = @location_location_id);
     
	 --employee table 
	 DECLARE 
     @maxEmployeeID int

     SET @maxEmployeeID = (SELECT max(Employee.employee_id)
     FROM Employee) + 1;

	 if not exists(
     SELECT * FROM Employee
	 WHERE first_name = @first_name and last_name = @last_name
	 AND age = @age and phone = @phone and active_flag = @active_flag
	 AND specialization = @specialization
)insert into Employee Values(@maxEmployeeID,@first_name,@last_name,@age,@phone,@active_flag,@specialization);

SET @employee_employee_id = (SELECT TOP 1 employee_id
                           FROM Employee
						   WHERE  first_name = @first_name and last_name = @last_name
	                       AND age = @age and phone = @phone and active_flag = @active_flag
	                       AND specialization = @specialization);

    --bridge table

     if not exists(
	 SELECT * FROM BridgeEmployeeProject
	 WHERE project_id = @project_project_id and employee_id = @employee_employee_id
	 )insert into BridgeEmployeeProject values(@project_project_id,@employee_employee_id);


	 --not use
	 SET @employee_project_id = (SELECT TOP 1 employee_project_id
                           FROM BridgeEmployeeProject
						   WHERE project_id = @project_project_id 
						   and employee_id = @employee_employee_id);
     --not use


	--material table
	 DECLARE 
     @maxMaterialID int

     SET @maxMaterialID = (SELECT max(Material.material_id)
     FROM Material) + 1;
	if not exists(
	SELECT * FROM Material
	WHERE material_name = @material_name and price = @price
	AND comments = @material_comments
	)insert into Material values(@maxMaterialID,@material_name,@price,@material_comments);

	SET @material_material_id = (SELECT TOP 1 material_id
                           FROM Material
						   WHERE  material_name = @material_name and price = @price
	                       AND comments = @material_comments);

	--storage table 
	DECLARE 
     @maxStorageID int

     SET @maxStorageID = (SELECT max(Storage.storage_id)
     FROM Storage) + 1;
   if not exists(
	SELECT * FROM Storage
	WHERE count = @storage_count and comments = @storage_comments
	AND material_id = @material_material_id
	)insert into Storage values(@maxStorageID,@material_material_id,@storage_count,@storage_comments);

	SET @material_material_id = (SELECT TOP 1 material_id
                           FROM Material
						   WHERE  material_name = @material_name and price = @price
	                       AND comments = @material_comments);

   --date table
     DECLARE 
     @maxDateID int

     SET @maxDateID = (SELECT max(Date.date_id)
     FROM Date) + 1;
    if not exists(
	SELECT * FROM Date
	WHERE calendar_date = @calendar_date and year = @year
	and month = @month and day =@day
	)insert into Date values(@maxDateID,@calendar_date,@year,@month,@day);

	SET @date_date_id = (SELECT TOP 1 date_id
                           FROM Date
						   WHERE calendar_date = @calendar_date and year = @year
	                       and month = @month and day = @day);

	--accounting table
	DECLARE 
     @maxAccountingID int

     SET @maxAccountingID = (SELECT max(Accounting.transaction_id)
     FROM Accounting) + 1;
  
	if not exists(
	SELECT * FROM Accounting
	WHERE salary = @salary and employee_id = @employee_employee_id 
	and date_id = @date_date_id
	)insert into Accounting Values(@maxAccountingID,@salary,@employee_employee_id,@date_date_id);

	SET @transaction_id = (SELECT TOP 1 transaction_id
                           FROM Accounting
						   WHERE salary = @salary and employee_id = @employee_employee_id 
	                       and date_id = @date_date_id);

     --operation
	 DECLARE 
     @maxOperationID int

     SET @maxOperationID = (SELECT max(Operation.operation_id)
     FROM Operation) + 1;
	if not exists(
	SELECT * FROM Operation
	WHERE material_id = @material_material_id and count = @operation_count
	AND  project_id = @project_project_id and date_id = @date_date_id
	)insert into Operation values(@maxOperationID,@material_material_id,@operation_count,@project_project_id,@date_date_id);

	SET @operation_id = (SELECT TOP 1 operation_id
                           FROM Operation
						   WHERE material_id = @material_material_id and count = @operation_count
	                       AND  project_id = @project_project_id and date_id = @date_date_id);
    
	FETCH NEXT FROM ConstructionCompanyCursor INTO 
   --project table
  @project_name,
  @project_status,
  
  --location table
  @country,
  @city,
  @address,
  
  --employee table
  @first_name,
  @last_name,
  @age,
  @phone,
  @active_flag,
  @specialization,
  
  --bridgeemployeeproject table
  
  --material table
  @material_name,
  @price,
  @material_comments,
  
  --storage table
  @storage_count,
  @storage_comments,
  
  --date table
  @calendar_date,
  @year,
  @month,
  @day,
  
  --accounting table
  @salary,
  
  --operation table
  @operation_count;

End

CLOSE ConstructionCompanyCursor; 
DEALLOCATE ConstructionCompanyCursor;

EXEC sp_MSForEachTable 'SELECT * FROM ?'; 
ROLLBACK TRAN
