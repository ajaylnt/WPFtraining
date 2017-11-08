--Create table DeptTable( DeptID int primary key identity(1,1), DeptName varchar(100) NOT null)

--insert some records into the table--------------
INSERT INTO DeptTable VALUES('Sales')
INSERT INTO DeptTable VALUES('Production')
INSERT INTO DeptTable VALUES('Accounts')
INSERT INTO DeptTable VALUES('After Sales')
INSERT INTO DeptTable VALUES('Maintainance')

create table EmpTable
(
  EmpID int primary key identity(1,1),
  EmpName varchar(100) not null,
  EmpAddress varchar(200) not null,
  EmpSalary int not null,
  Dept int not null
)

---View the records using select statement----
SELECT * FROM DeptTable

--Alter the EmpTable to add a new Column called Dept----
alter table EmpTable
add Dept int references DeptTable(DeptID)

update EmpTable set Dept = 4 where empid = 6
SELECT * FROM EmpTable