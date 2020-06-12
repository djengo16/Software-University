USE SoftUni

--Problem 1.	Find Names of All Employees by First Name
SELECT FirstName,LastName
FROM Employees
Where FirstName LIKE 'SA%'

--2.Find Names of All employees by Last Name 
SELECT FirstName,LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--Problem 3.	Find First Names of All Employees
--Write a SQL query to find the first names of all employees in the departments with ID 3 or 10
--and whose hire year is between 1995 and 2005 inclusive.

SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) 
AND CAST(DATEPART(YEAR,HireDate)AS INT) BETWEEN 1995 AND 2005


--Problem 4.	Find All Employees Except Engineers
--Write a SQL query to find the first and last names of all employees whose job titles does not contain “engineer”. 


SELECT FirstName,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length
--Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name. 


SELECT [Name] 
FROM Towns
Where LEN([Name]) IN (5,6)
ORDER BY [Name] ASC

--Find Towns Starting With
--Write a SQL query to find all towns that start with letters M, K, B or E.
--Order them alphabetically by town name. 

SELECT * FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC

--Problem 7.	 Find Towns Not Starting With
--Write a SQL query to find all towns that does not start with letters R, B or D.
--Order them alphabetically by name. 

SELECT * FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name] ASC


--Problem 8.	Create View Employees Hired After 2000 Year
--Write a SQL query to create view V_EmployeesHiredAfter2000
--with first and last name to all employees hired after 2000 year. 

CREATE View V_EmployeesHiredAfter2000
AS 
SELECT FirstName,LastName FROM Employees
WHERE CONVERT(INT,DATEPART(year,HireDate)) > 2000

--Problem 9.	Length of Last Name
--Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.

SELECT FirstName,LastName
  FROM Employees
  WHERE LEN(LastName) = 5



--Problem 10. Rank Employees by Salary

SELECT * FROM (
SELECT EmployeeID,FirstName,LastName,Salary,
 DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
 FROM Employees
 WHERE Salary BETWEEN 10000 AND 50000 
 ) AS temp
 WHERE Rank = 2
 ORDER BY Salary DESC


 --Problem 12.	Countries Holding ‘A’ 3 or More Times
 USE Geography

 SELECT CountryName,IsoCode
 FROM Countries
 WHERE CountryName LIKE '%a%a%a%'
 ORDER BY IsoCode

 --Problem 13.	 Mix of Peak and River Names
 SELECT  p.PeakName,
		 r.RiverName,
		 LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName) - 1),r.RiverName)) AS [Mix]
         FROM
         Peaks As p,Rivers AS r
   WHERE Right(p.PeakName,1) = Left(r.RiverName,1)
   ORDER BY Mix



--Problem 14.	Games from 2011 and 2012 year
--Find the top 50 games ordered by start date, then by name of the game. 
--Display only games from 2011 and 2012 year. Display start date in the format “yyyy-MM-dd”. 

USE Diablo

SELECT TOP(50)Name,FORMAT(Start,'yyyy-MM-dd') AS [Start]
       FROM Games
	   WHERE DATEPART(year,start) IN(2011,2012) 
	   ORDER BY Start,Name

--Problem 15.  User Email Providers
--Find all users along with information about their email providers. 
--Display the username and email provider. Sort the results by email provider alphabetically, then by username. 

SELECT Username,SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email))
AS [Email Provider]
FROM Users
ORDER BY [Email Provider],Username

--Problem 16.	 Get Users with IPAdress Like Pattern
--Find all users along with their IP addresses sorted by username alphabetically.
--Display only rows that IP address matches the pattern: “***.1^.^.***”. 
--Legend: * - one symbol, ^ - one or more symbols

SELECT Username,IpAddress AS [IP Adress]
FROM   Users
WHERE  IpAddress LIKE '___.1%.%.___'
ORDER  BY [Username] ASC




--Problem 17. Show All Games with Duration and Part of the Day


  SELECT G.Name,
    CASE
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 0 AND 11 THEN 'Morning'
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 12 AND 17 THEN 'Afternoon'
        WHEN (DATEPART(HOUR, G.Start)) BETWEEN 18 AND 23 THEN 'Evening'
    END AS [Part of Day],
    CASE
        WHEN G.Duration <= 3 THEN 'Extra Short'
        WHEN G.Duration BETWEEN 4 AND 6 THEN 'Short'
        WHEN G.Duration IS NULL THEN 'Extra Long'
        ELSE 'Long'
    END AS [Duration]
FROM Games AS G
ORDER BY G.Name ASC,
    [Duration],
    [Part of Day]

--Problem 18.	 Orders Table
	USE [Online Store]
	SELECT * FROM Orders