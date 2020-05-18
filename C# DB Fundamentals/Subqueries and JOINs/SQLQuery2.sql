USE SoftUni

--Problem 01.

SELECT TOP(5) e.EmployeeID,e.JobTitle,e.AddressID,a.AddressText
FROM Employees AS e
JOIN  Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY a.AddressID

--Problem 02.

SELECT TOP(50)
e.FirstName,e.LastName,t.[Name] AS [Town],a.AddressText 
 FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName,e.LastName

--Problem 03.

SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 04.

SELECT TOP(5)e.EmployeeID,e.FirstName,e.Salary,d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID AND e.Salary > 15000
ORDER BY e.DepartmentID

--Problem 05.

SELECT TOP(3) e.EmployeeID,e.FirstName 
FROM Employees AS e
LEFT  JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID 
WHERE ep.ProjectID is NULL
ORDER BY e.EmployeeID

--Problem 06.

SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS [DeptName] 
FROM Employees AS e
FULL OUTER JOIN Departments As d ON e.DepartmentID = d.DepartmentID 
AND e.HireDate > '01.01.1999'
WHERE d.Name = 'Sales' OR d.Name LIKE  'Finance' 
ORDER BY e.HireDate

--Problem 07.

SELECT TOP(5) e.EmployeeID,e.FirstName,p.Name AS [ProjectName] FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID 
WHERE p.EndDate is NULL AND p.StartDate > '2002.08.13'
ORDER BY e.EmployeeID

--Problem 08.

SELECT e.EmployeeID,e.FirstName,
IIF(p.StartDate >= '01.01.2005',NULL,p.Name) AS ProjectName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--Problem 09.

SELECT e.EmployeeID,e.FirstName,e.ManagerID,m.FirstName 
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--Problem 10.


SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName,' ',e.LastName),
	CONCAT(m.FirstName,' ',m.LastName),
	d.Name AS [DepartmentName]
FROM Employees AS e
	JOIN Employees As m ON e.ManagerID = m.EmployeeID
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11.
SELECT MIN(dt.AverageSalary) AS MinAverageSalary FROM
(
SELECT AVG(e.Salary) AS AverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
)as dt

-------- examples with other db

USE Geography

--Probelm 12.

Select mc.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC


--Problem 13.

SELECT mc.CountryCode,COUNT(m.MountainRange)
FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode IN('BG','RU','US')
GROUP BY mc.CountryCode

--Problem 14.

SELECT TOP(5) c.CountryName,r.RiverName
FROM Rivers AS r
	FULL  JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
	FULL  JOIN Countries AS c ON cr.CountryCode = c.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName ASC

-- Problem 15.


--Problem 16.

SELECT * FROM Countries

SELECT COUNT(DISTINCT c.CountryCode)-COUNT(DISTINCT mc.CountryCode) AS [Count]
FROM MountainsCountries AS mc
, Countries AS c



SELECT * FROM Rivers