CREATE DATABASE Service
USE Service

--01.DDL
CREATE TABLE Users
(
Id			INT PRIMARY KEY IDENTITY,
Username    VARCHAR(30) NOT NULL,
Password    VARCHAR(50) NOT NULL,
Name        VARCHAR(50),
Birthdate   Datetime,
Age INT CHECK(Age>=14 AND Age<= 110),
Email       VARCHAR(50) NOT NULL,
UNIQUE(Username)
)

CREATE TABLE Departments
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate Datetime,
Age INT CHECK(Age>=18 AND Age<= 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)


CREATE TABLE Status
(
Id INT PRIMARY KEY IDENTITY,
Label VARCHAR(50) NOT NULL
)

CREATE TABLE Reports
(
Id INT PRIMARY KEY IDENTITY,
CategoryId  INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId    INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
OpenDate	Datetime NOT NULL,
CloseDate	Datetime,
Description	VARCHAR(200)	NOT NULL,
UserId	    INT	FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId	INT	FOREIGN KEY REFERENCES Employees(Id),
)

--2.	Insert

INSERT INTO Employees
(FirstName,	LastName,	Birthdate,	DepartmentId)
VALUES
('Marlo','O''Malley','1958-9-21',1),
('Niki','Stanaghan','1969-11-26',4),
('Ayrton','Senna','1960-03-21',9),
('Ronnie','Peterson','1944-02-14',9),
('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports
(CategoryId,	StatusId,	OpenDate,	CloseDate,	Description,	UserId,	EmployeeId)
VALUES
(1,1,'2017-04-13','','Stuck Road on Str.133',6,2),
(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
(14,2,'2015-09-07','','Falling bricks on Str.58',5,2),
(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

--3.	Update
--Update the CloseDate with the current date of all reports, which don't have CloseDate. 

Update Reports
SET CloseDate =  GETDATE()
WHERE CloseDate IS NULL

--4.	Delete
--Delete all reports who have a Status 4.

DELETE FROM Reports
WHERE StatusId = 4

--5.	Unassigned Reports
--Find all reports that don't have an assigned employee.
--Order the results by OpenDate in ascending order, 
--then by description ascending. OpenDate must be in format - 'dd-MM-yyyy'

SELECT 
Description,
FORMAT(OpenDate,'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate ASC,r.Description ASC

--6.	Reports & Categories
--Select all descriptions from reports, which have category.
--Order them by description (ascending) then by category name (ascending).

SELECT r.Description,
       c.Name
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
WHERE CategoryId IS NOT NULL
ORDER BY Description,c.Name

--7.	Most Reported Category
--Select the top 5 most reported categories and order them by the number of reports per category
--in descending order and then alphabetically by name.

SELECT TOP(5) c.Name,COUNT(*) AS ReportNumber
FROM Reports AS r
JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportNumber DESC

--8.	Birthday Report
--Select the user's username and category name in all reports in which users have submitted a report on their birthday.
--Order them by username (ascending) and then by category name (ascending).

SELECT u.Username,
	   c.Name
FROM Users AS u
FULL JOIN Reports AS r ON u.Id = r.UserId
FULL JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(day,u.Birthdate) = DATEPART(day,r.OpenDate)
  AND DATEPART(month,u.Birthdate) = DATEPART(month,r.OpenDate)
ORDER BY u.Username,
         c.Name

--		 9.	Users per Employee 
--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).

SELECT e.FirstName + ' ' + e.LastName AS FullName,
       COUNT(r.UserId) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY r.EmployeeId,e.FirstName,e.LastName
ORDER BY UsersCount DESC,FullName ASC

----Select all info for reports along with employee first name and last name (concataned with space)
--, department name, category name, report description, open date, status label and name of the user.
--Order them by first name (descending), last name (descending), department (ascending), category (ascending),
--description (ascending), open date (ascending), status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'.

--ISNULL(CONCAT(e.FirstName,' ',e.LastName),'None'),

SELECT IIF(CONCAT(e.FirstName,' ',e.LastName) = ' ','None',CONCAT(e.FirstName,' ',e.LastName)),
       ISNULL(d.Name,'None') AS Department,
	   ISNULL(c.Name,'None') AS Category,
	   ISNULL(r.Description,'None'),
	   ISNULL(FORMAT(r.OpenDate,'dd.MM.yyyy'),'None') AS OpenDate,
	   ISNULL(s.Label,'None') AS Status,
	   ISNULL(u.Name,'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Status AS s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC,e.LastName DESC,
         Department ASC,
		 Category ASC,
		 Description ASC,
		 OpenDate ASC,
		 Status ASC,
		 [User] ASC


--11.	Hours to Complete
--Create a user defined function with the name udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
--that receives a start date and end date and must returns the total hours which has been taken for this task.
--If start date is null or end is null return 0.

GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
 BEGIN
 IF @StartDate IS NULL OR @EndDate IS NULL
 RETURN 0;
 ELSE
 RETURN DATEDIFF(hour,@StartDate,@EndDate)

 RETURN '';
 END
 GO

 SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
--that receives an employee's Id and a report's Id and assigns the employee to the report only if
--the department of the employee and the department of the report's category are the same.
--Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!". 

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
DECLARE @employeeDepartmentId INT = (SELECT DepartmentId FROM Employees
WHERE Id = @EmployeeId);
DECLARE @reportDepartmentId INT = (SELECT DepartmentId FROM Reports AS r 
                                    JOIN Categories AS c ON r.CategoryId = c.Id
									WHERE r.Id = @ReportId)

IF @employeeDepartmentId != @reportDepartmentId
THROW 50001,'Employee doesn''t belong to the appropriate department!',1;


UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId

EXEC usp_AssignEmployeeToReport 30, 1