USE Bank
--Exercise - Triggers and Transactions


--===============================
--Problem 14. Create Table Logs
--===============================
CREATE TABLE Logs 
(
LogId INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum DECIMAL(15,2),
NewSum DECIMAL(15,2)
)


CREATE OR ALTER TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
DECLARE @oldBalance DECIMAL(15,2) = (SELECT Balance FROM deleted)
DECLARE @newBalance DECIMAL(15,2) = (SELECT Balance FROM inserted)
DECLARE @accountID INT = (SELECT Id FROM inserted)

INSERT INTO Logs(AccountId,OldSum,NewSum) VALUES
(@accountID,@oldBalance,@newBalance)

UPDATE Accounts
SET Balance+=10
WHERE Id = 2

SELECT * FROM Logs

--===============================
--Problem 15. Create Table Emails
--===============================

CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
[Subject] VARCHAR(50),
Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
DECLARE @oldBalance DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM deleted)
DECLARE @newBalance DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted)
DECLARE @accountID INT = (SELECT TOP(1) AccountId FROM inserted)

INSERT INTO NotificationEmails VALUES
(@accountID,
'Balance change for account: ' + CAST(@accountID AS VARCHAR(20)),
'On ' + CONVERT(VARCHAR(30),GETDATE(),103) + ' your balance was changed from ' +
CAST(@oldBalance AS VARCHAR(20)) + ' to ' + CAST(@newBalance AS VARCHAR(20)) + '.'
)

SELECT * FROM NotificationEmails


--===============================
--Problem 16. Deposit Money
--===============================

CREATE OR ALTER PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(18,4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
ROLLBACK
RAISERROR('Invalid Account Id!',16,1)
RETURN
END

IF(@moneyAmount < 0)
BEGIN
ROLLBACK
RAISERROR('Money cannot be zero or negative!',16,1)
RETURN
END

UPDATE Accounts
SET Balance +=@moneyAmount
WHERE Id = @accountId

COMMIT

--===============================
--Problem 17.Withdraw Money
--===============================

CREATE OR ALTER PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(18,4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
DECLARE @accountMoney DECIMAL = (SELECT Balance FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
ROLLBACK
RAISERROR('Invalid Account Id!',16,1)
RETURN
END

IF(@moneyAmount < 0)
BEGIN
ROLLBACK
RAISERROR('Money cannot be zero or negative!',16,2)
RETURN
END

IF(@moneyAmount > @accountMoney)
BEGIN
ROLLBACK
RAISERROR('You dont have enough money!',16,3)
RETURN
END

UPDATE Accounts
SET Balance-= @moneyAmount
WHERE Id = @accountId

COMMIT


--===============================
--Problem 18. Money Transfer
--===============================

CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
EXEC  usp_WithdrawMoney @senderId,@amount
EXEC  usp_DepositMoney @receiverId,@amount
COMMIT


--===============================
--Problem 19. Money Transfer
--===============================




--===============================
--Problem 21. Employees with Three Projects
--===============================

USE SoftUni

CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION

DECLARE @projectCount INT = 
(SELECT COUNT(EmployeeID) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)

IF (@projectCount >= 3)
BEGIN
ROLLBACK
RAISERROR('The employee has too many projects!',16,1)
RETURN
END

INSERT INTO EmployeesProjects VALUES
(@emloyeeId,@projectID)


COMMIT

--===============================
--Problem 22. Delete Employees
--===============================

--Create a table Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary) 
--that will hold information about fired (deleted) employees from the Employees table.
--Add a trigger to Employees table that inserts the corresponding information about the deleted records in Deleted_Employees.


CREATE TABLE Deleted_Employees(
EmployeeId INT PRIMARY KEY,
FirstName NVARCHAR(20) NOT NULL, 
LastName NVARCHAR(20) NOT NULL, 
MiddleName NVARCHAR(20), 
JobTitle NVARCHAR(20) NOT NULL, 
DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentId), 
Salary DECIMAL NOT NULL
) 

CREATE TRIGGER tr_SaveDeleted ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees  
(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary) 
SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary FROM deleted