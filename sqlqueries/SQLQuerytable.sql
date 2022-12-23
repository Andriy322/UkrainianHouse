DROP TABLE Project;

CREATE TABLE Project(
   project_id int  IDENTITY(1,1) PRIMARY KEY,
   project_name varchar(255) NOT NULL,
   project_status varchar(255) NOT NULL,
   employee_id int,
   location_id int
);

SELECT * FROM PROJECT;

CREATE TABLE Location(
   location_id int PRIMARY KEY,
   country varchar(255) NOT NULL,
   city varchar(255) NOT NULL,
   address varchar(255) NOT NULL
);

CREATE TABLE SetEmployee(
   location_id int PRIMARY KEY,
   country varchar(255) NOT NULL,
   city varchar(255) NOT NULL,
   address varchar(255) NOT NULL
);

CREATE TABLE Employee(
   employee_id int PRIMARY KEY,
   first_name varchar(255) NOT NULL,
   last_name varchar(255) NOT NULL,
   age int,
   phone varchar(255),
   active_flag int,
   specialization varchar(255)
);

DROP TABLE if exists Storage;

CREATE TABLE Storage(
   storage_id int PRIMARY KEY,
   material_id int NOT NULL,
   count int NOT NULL,
   comments varchar(255)
);

DROP TABLE Material;
CREATE TABLE Material(
   material_id int NOT NULL PRIMARY KEY,
   material_name varchar(255) NOT NULL,
   price int NOT NULL,
   comments varchar(255)
);

DROP TABLE Accounting;
CREATE TABLE Accounting(
   transaction_id int PRIMARY KEY,
   salary int,
   employee_id int,
   date_id int
);

CREATE TABLE Operation(
   operation_id int PRIMARY KEY,
   material_id int,
   count int NOT NULL,
   project_id int,
   date_id int
);

CREATE TABLE Date(
   date_id int PRIMARY KEY,
   calendar_date date NOT NULL,
   year int,
   month int,
   day int
);


CREATE TABLE Task(
   task_id int PRIMARY KEY,
   task_name varchar(255),
   --employee_id int 
   --status_id int 
);

CREATE TABLE Status(
   status_id int PRIMARY KEY,
   status_name varchar(255) NOT NULL,
);

ALTER TABLE Project
ADD FOREIGN KEY (location_id) REFERENCES Location(location_id);

ALTER TABLE Project
ADD FOREIGN KEY (project_manager) REFERENCES Employee(employee_id);



ALTER TABLE Accounting
ADD FOREIGN KEY (employee_id) REFERENCES Employee(employee_id);

ALTER TABLE Accounting
ADD FOREIGN KEY (date_id) REFERENCES Date(date_id);

ALTER TABLE Storage
ADD FOREIGN KEY (material_id) REFERENCES Material(material_id);



ALTER TABLE Operation
ADD FOREIGN KEY (project_id) REFERENCES Project(project_id);

ALTER TABLE Operation
ADD FOREIGN KEY (material_id) REFERENCES Material(material_id);

ALTER TABLE Operation
ADD FOREIGN KEY (date_id) REFERENCES Date(date_id);
