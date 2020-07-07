USE Gringotts
--Problem 1.	Records’ Count
SELECT 
COUNT(*)FROM WizzardDeposits

--Problem 2.	Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestWandSize
FROM WizzardDeposits 

--Problem 3.	Longest Magic Wand per Deposit Groups
SELECT å.DepositGroup,MAX(å.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits å
GROUP BY å.DepositGroup

--Problem 4.    Smallest Deposit Group per Magic Wand Size
SELECT TOP(2)DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup 
ORDER BY AVG(MagicWandSize)

--Problem 5.	Deposits Sum
SELECT w.DepositGroup,SUM(w.DepositAmount) 
FROM WizzardDeposits w
GROUP BY DepositGroup

--Problem 6.	Deposits Sum for Ollivander Family
SELECT w.DepositGroup,SUM(w.DepositAmount)
FROM WizzardDeposits w
WHERE w.MagicWandCreator = 'Ollivander Family'
GROUP BY w.DepositGroup

--Problem 7.	Deposits Filter
SELECT DepositGroup,SUM(w.DepositAmount) AS TotalDepositAmount
FROM WizzardDeposits w
WHERE w.MagicWandCreator = 'Ollivander family' 
GROUP BY DepositGroup
HAVING SUM(w.DepositAmount) < 150000
ORDER BY TotalDepositAmount DESC

--Problem 8.	 Deposit Charge
SELECT w.DepositGroup,w.MagicWandCreator,MIN(w.DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits w
GROUP BY w.DepositGroup,w.MagicWandCreator
ORDER BY w.MagicWandCreator ASC,w.DepositGroup ASC

--Problem 9.	Age Groups
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

--Problem 10.	First Letter
SELECT DISTINCT SUBSTRING(w.FirstName,1,1) AS [FirstLetter]
FROM WizzardDeposits w
WHERE w.DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(w.FirstName,1,1)
ORDER BY FirstLetter ASC

--Problem 11.	Average Interest 
SELECT w.DepositGroup,w.IsDepositExpired,AVG(w.DepositInterest) 
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '1985-01-01'
GROUP BY w.DepositGroup,w.IsDepositExpired
ORDER BY w.DepositGroup DESC,
         w.IsDepositExpired ASC

--Problem 12. Rich Wizard, Poor Wizard
SELECT SUM([DIFFERENCE]) AS SumDifference FROM(SELECT FirstName AS [Host Wizard],DepositAmount AS [Host Wizard Deposit],
LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit],
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Difference
FROM WizzardDeposits) AS DiffTable

--------------------
USE SoftUni
--Problem 13.	Departments Total Salaries
SELECT e.DepartmentID,SUM(e.Salary) AS TotalSalary
FROM Employees e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

--Problem 14.	Employees Minimum Salaries
SELECT e.DepartmentID,MIN(e.Salary) AS MinimumSalary 
FROM Employees e
WHERE e.DepartmentID IN (2,5,7) AND e.HireDate > '01/01/2000'
GROUP BY e.DepartmentID

--Problem 15.	Employees Average Salaries
SELECT * INTO newEmployees
FROM Employees AS e
WHERE e.Salary > 30000

DELETE FROM newEmployees 
WHERE ManagerID = 42

UPDATE newEmployees
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID,AVG(Salary) 
FROM newEmployees
GROUP BY DepartmentID

--Problem 16.	Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.	Employees Count Salaries
SELECT COUNT(*)
FROM Employees
WHERE ManagerID is NULL

--Problem 18.	*3rd Highest Salary
--Find the third highest salary in each department if there is such. 

SELECT DepartmentID,Salary AS ThirdHighestSalary FROM (
SELECT e.DepartmentID,Salary,
        DENSE_RANK() OVER   
    (PARTITION BY e.DepartmentID ORDER BY e.Salary DESC) AS Rank 
FROM Employees AS e
GROUP BY DepartmentID,Salary
) AS tmp
WHERE Rank = 3

--Problem 19.	**Salary Challenge
SELECT TOP(10)
	e1.FirstName,
	e1.LastName,
	e1.DepartmentID
	FROM  Employees 
AS e1
WHERE e1.Salary >
(
SELECT AVG(e2.Salary)
FROM Employees AS e2
WHERE e2.DepartmentID = e1.DepartmentID
GROUP BY e2.DepartmentID
)  
ORDER BY e1.DepartmentID
















