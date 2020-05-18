USE Gringotts

SELECT 
COUNT(*)FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS LongestWandSize
FROM WizzardDeposits 

SELECT å.DepositGroup,MAX(å.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits å
GROUP BY å.DepositGroup

SELECT TOP(2)DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup 
ORDER BY AVG(MagicWandSize)

SELECT w.DepositGroup,SUM(w.DepositAmount) 
FROM WizzardDeposits w
GROUP BY DepositGroup

SELECT DepositGroup,SUM(w.DepositAmount) AS TotalDepositAmount
FROM WizzardDeposits w
WHERE w.MagicWandCreator = 'Ollivander family' 
GROUP BY DepositGroup
HAVING SUM(w.DepositAmount) < 150000
ORDER BY TotalDepositAmount DESC

SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits 
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

SELECT 
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
	END AS [AgeGroup],
	COUNT(*) AS [WizardCount]
	FROM WizzardDeposits
	GROUP BY
	CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
	END

SELECT SUBSTRING(FirstName,1,1) 
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName,1,1) 


SELECT DepositGroup,IsDepositExpired,AVG(wd.DepositInterest)
FROM WizzardDeposits wd
WHERE wd.DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,wd.IsDepositExpired

SELECT SUM([DIFFERENCE]) AS SumDifference FROM(SELECT FirstName AS [Host Wizard],DepositAmount AS [Host Wizard Deposit],
LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference
FROM WizzardDeposits) AS DiffTable

USE SoftUni

SELECT e.DepartmentID,SUM(e.Salary) AS TotalSalary
FROM Employees e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT e.DepartmentID,MIN(e.Salary) AS MinimumSalary 
FROM Employees e
WHERE e.DepartmentID IN (2,5,7) AND e.HireDate > '01/01/2000'
GROUP BY e.DepartmentID

SELECT e.DepartmentID,MAX(e.Salary) AS MaxSalary
FROM Employees e 
WHERE e.Salary NOT BETWEEN 30000 AND 70000 
GROUP BY e.DepartmentID

SELECT COUNT(*)
FROM Employees
WHERE ManagerID is NULL







