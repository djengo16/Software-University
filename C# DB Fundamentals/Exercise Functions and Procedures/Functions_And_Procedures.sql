USE SoftUni
--Probelm 01.
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
SELECT e.FirstName,e.LastName 
FROM Employees AS e
WHERE e.Salary > 35000
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
SELECT e.FirstName,e.LastName
FROM Employees AS e
WHERE e.Salary >= @salary

EXEC dbo.usp_GetEmployeesSalaryAboveNumber'48100'
GO

CREATE PROC usp_GetTownsStartingWith(@string VARCHAR(10))
AS
SELECT t.Name AS [Town]
FROM Towns AS t
WHERE t.Name LIKE @string + '%' 
GO

CREATE PROC usp_GetEmployeesFromTown (@town NVARCHAR(20))
AS
SELECT e.FirstName,e.LastName FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.Name = @town
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN 
	DECLARE @salarylevel  VARCHAR(7);
	IF (@salary < 30000)
		BEGIN
		SET @salarylevel = 'Low';
		END
	ELSE IF(@salary <= 50000)
		BEGIN 
		SET @salarylevel = 'Average';
		END
    ELSE
		BEGIN
		SET @salarylevel = 'High';
		END
		RETURN @salarylevel;
END


CREATE PROC usp_EmployeesBySalaryLevel(@salary VARCHAR(7))
AS
SELECT e.FirstName,e.LastName 
FROM Employees AS e
WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salary

--Problem 07

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(20))
RETURNS BIT
AS
BEGIN
 DECLARE @counter INT = 1;
 DECLARE @currentLetter CHAR;

 WHILE(@counter<=LEN(@word))
   BEGIN

   SET @currentLetter = SUBSTRING(@word,@counter,1);
   DECLARE @charIndex INT = CHARINDEX(@currentLetter,@setOfLetters)
	IF (@charIndex = 0)
		BEGIN
		RETURN 0;
		END
SET @counter += 1;	
   END
   RETURN 1;
   END

   --Probelm 08.
 
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

DELETE FROM EmployeesProjects 
WHERE EmployeeID IN
(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId);

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN
(SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId);


ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

UPDATE Departments
SET ManagerID = NULL
WHERE DepartmentID = @departmentId

DELETE FROM Employees
WHERE DepartmentID = @departmentId;

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT  COUNT(*) FROM Employees
WHERE DepartmentID = @departmentId

END


--Problem 09.


USE Bank

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
SELECT FirstName+' '+LastName AS [Full Name] 
FROM AccountHolders
END

--Problem 10.

CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
BEGIN
SELECT FirstName,LastName FROM AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY FirstName,LastName
HAVING SUM(Balance) > 7000
ORDER BY ah.FirstName,ah.LastName

END

--Problem 11.

CREATE  FUNCTION ufn_CalculateFutureValue(@InitialSum DECIMAL(18,4),@yearlyInterestRate FLOAT,@numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
RETURN @InitialSum * (POWER(1+@yearlyInterestRate,@numberOfYears));
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--Problem 12. 

CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT,@interesetRate FLOAT)
AS
BEGIN
SELECT a.Id,ah.FirstName,ah.LastName,a.Balance,dbo.ufn_CalculateFutureValue(a.Balance,@interesetRate,5) 
FROM Accounts AS a
JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
WHERE a.Id = @accountId

END

