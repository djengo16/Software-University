USE SoftUni

SELECT FirstName,LastName
FROM Employees
Where FirstName LIKE 'SA%'

SELECT FirstName,LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) 
AND CAST(DATEPART(YEAR,HireDate)AS INT) BETWEEN 1995 AND 2005

SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] 
FROM Towns
Where LEN([Name]) IN (5,6)
ORDER BY [Name] ASC

SELECT TownID,[Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

SELECT TownID,[Name]
FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

SELECT FirstName,LastName
FROM Employees
WHERE LEN(LastName) = 5

SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC

SELECT * FROM (SELECT EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 ) AS temp
WHERE temp.Rank = 2
ORDER BY temp.Salary DESC

USE [Geography]

SELECT CountryName,IsoCode 
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

SELECT p.PeakName,r.RiverName,LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName)-1),r.RiverName)) AS [Mix]
FROM Peaks AS p, Rivers as r
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY [Mix]

USE Diablo

SELECT TOP(50)[Name],FORMAT ([Start], 'yyyy-MM-dd') as [Start]
FROM Games
WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start]

SELECT Username, SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email)) 
AS 'Email Provider' 
FROM Users
ORDER BY [Email Provider], Username