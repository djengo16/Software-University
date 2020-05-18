USE SoftUni

SELECT * FROM Departments

SELECT [Name] FROM Departments

SELECT FirstName,LastName,Salary FROM Employees

SELECT FirstName,MiddleName,LastName FROM Employees

SELECT FirstName + '.' + LastName  + '@softuni.bg' AS [Full Email Address]
FROM Employees

SELECT DISTINCT 
Salary FROM Employees

SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName,LastName,JobTitle
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000 

--Write a SQL query to find the full name of all employees whose salary is 25000, 14000, 12500 or 23600.
--Full Name is combination of first
--, middle and last name (separated with single space) and they should be in one column called “Full Name”.

SELECT FirstName + ' ' + MiddleName + ' ' + LastName  AS [Full Name]
FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

SELECT FirstName,LastName
FROM Employees
WHERE ManagerID is Null

SELECT FirstName,LastName,Salary 
FROM Employees
WHERE SALARY > 50000
ORDER BY SALARY DESC

SELECT TOP(5)FirstName,LastName 
FROM Employees
ORDER BY Salary DESC

SELECT FirstName,LastName 
FROM Employees
WHERE DepartmentID != 4  

SELECT * 
FROM Employees
ORDER BY Salary DESC
,FirstName ASC
,LastName DESC
,MiddleName ASC

CREATE VIEW V_EmployeesSalaries AS 
SELECT FirstName,LastName,Salary FROM Employees 

SELECT * FROM V_EmployeesSalaries


 CREATE VIEW V_EmployeeNameJobTitle AS
 SELECT FirstName + ' ' + ISNULL(MiddleName ,'')  + ' ' + LastName AS [Full Name],JobTitle
 FROM Employees

 SELECT * FROM V_EmployeeNameJobTitle

SELECT DISTINCT JobTitle 
FROM Employees

SELECT TOP(10)* 
FROM Projects
ORDER BY StartDate,[Name]

--Write a SQL query to find last 7 hired employees. Select their first, last name and their hire date

SELECT TOP(7)FirstName,LastName,HireDate
FROM Employees
ORDER BY HireDate DESC

UPDATE Employees
SET Salary +=Salary * 0.12
WHERE DepartmentID IN (1,2,4,11)

SELECT Salary FROM Employees

USE Geography

SELECT PeakName
FROM Peaks
ORDER BY PeakName 

SELECT TOP(30)CountryName,[Population] 
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC,CountryName

SELECT CountryName,CountryCode,
CASE WHEN CurrencyCode = 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS 'Currency'
FROM Countries
ORDER BY CountryName

USE Diablo
SELECT [Name] From Characters
ORDER BY [Name] ASC