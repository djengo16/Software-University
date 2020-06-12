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
SELECT ContinentCode,CurrencyCode,CurrencyCount1 AS CurrencyUsage FROM 
(
SELECT *,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount1 DESC) AS CurrencyCount FROM
(
SELECT ContinentCode,CurrencyCode,COUNT(*)AS CurrencyCount1 FROM Countries 
GROUP BY ContinentCode,CurrencyCode 
) AS tbl
) AS tbl1
WHERE CurrencyCount = 1 AND CurrencyCount1 != 1
ORDER BY ContinentCode,CurrencyCode

--Problem 16.

SELECT * FROM Countries

SELECT COUNT(DISTINCT c.CountryCode)-COUNT(DISTINCT mc.CountryCode) AS [Count]
FROM MountainsCountries AS mc
, Countries AS c



SELECT * FROM Rivers

--Problem 17.

--For each country, find the elevation of the highest peak and the length of the longest river,
--sorted by the highest peak elevation (from highest to lowest), then by the longest river length 
--(from longest to smallest), then by country name (alphabetically).
--Display NULL when no data is available in some of the columns. Limit only the first 5 rows.

SELECT TOP(5)  c.CountryName,MAX(p.Elevation) AS [HighestPeakElevation],MAX(r.Length) AS [LongestRiverLength]
  FROM Countries AS c
  FULL OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
  FULL OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
  FULL OUTER JOIN Peaks AS p ON m.Id = p.MountainId
  FULL OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
  FULL OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryCode,c.CountryName
ORDER BY HighestPeakElevation DESC,
		 LongestRiverLength   DESC,
		 c.CountryName        ASC


--Problem 18.	* Highest Peak Name and Elevation by Country
--For each country, find the name and elevation of the highest peak,
--along with its mountain. When no peaks are available in some country,
--display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name.
--When multiple peaks in some country have the same elevation, display all of them. 
--Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.

SELECT TOP(5) Country,
	          IIF([Highest Peak Name] IS NULL,'(no highest peak)',[Highest Peak Name]) AS [Highest Peak Name],
	          IIF([Highest Peak Elevation] IS NULL,'0',[Highest Peak Elevation]) AS [Highest Peak Elevation],
	          IIF(Mountain IS NULL,'(no mountain)',Mountain)  AS [Mountain]
	   FROM 
(
SELECT c.CountryName AS [Country],
       p.PeakName AS [Highest Peak Name],
	   p.Elevation AS [Highest Peak Elevation],
	   ROW_NUMBER() OVER (PARTITION BY c.CountryCode ORDER BY p.Elevation) AS [HighestPeak],
	   m.MountainRange AS [Mountain]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT OUTER JOIN Peaks AS p ON mc.MountainId = p.MountainId
GROUP BY c.CountryCode,c.CountryName,p.PeakName,p.Elevation,m.MountainRange
) AS tmp
WHERE HighestPeak = 1
ORDER BY Country ASC,
         [Highest Peak Name] ASC


		 
