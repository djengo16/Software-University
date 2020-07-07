CREATE DATABASE Minions

--Problem 2.	Create Tables
--In the newly created database Minions add table Minions (Id, Name, Age). 
--Then add new table Towns (Id, Name). Set Id columns of both tables to be primary key as constraint.

USE Minions

CREATE TABLE Minions
(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(30) NOT NULL,
Age INT NOT NULL
)

CREATE TABLE Towns
(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL 
)

--Problem 3.	Alter Minions Table
--Change the structure of the Minions table to have new column TownId that
--would be of the same type as the Id column of Towns table.
--Add new constraint that makes TownId foreign key and references to Id column of Towns table.

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id) 

--Problem 4.	Insert Records in Both Tables
ALTER TABLE Minions ALTER COLUMN Age INT NULL;

INSERT INTO Towns(Id,[Name]) VALUES
(1,	'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO  Minions VALUES
(1,	'Kevin',22,	1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)


SELECT * FROM Minions

--Problem 5.	Truncate Table Minions
--Delete all the data from the Minions table using SQL query.

TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables
--Delete all tables from the Minions database using SQL query.

DROP TABLE Towns
DROP TABLE Minions

--Problem 7.Create Table People


CREATE TABLE People(
Id			INT PRIMARY KEY NOT NULL IDENTITY,
[Name]		NVARCHAR(200) NOT NULL,
Picture		varbinary(max),
Height		NUMERIC(20,2),
[Weight]    NUMERIC(20,2),
Gender char(6) NOT NULL CHECK (Gender IN ('m', 'f')),
Birthdate Date Not null,
Biography NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
	('Maria', 011010101, 1.64, 65.77, 'f', '1985/01/17', 'Marias Bio'),
	('Peter', 01111101, 1.88, 87.00, 'm', '1980/06/11', 'Peters Bio'),
	('Ida', 100000001, 1.64, 65.77, 'f', '1985/05/03', 'Idas Bio'),
	('Nia', 000011010, 1.70, 60.52, 'f', '1975/06/06', 'Nias Bio'),
	('Tom', 101010101, 1.90, 85.7, 'm', '1995/08/08', 'Toms Bio')

--Problem 8.	Create Table Users

CREATE Table Users
(
Id				INT PRIMARY KEY NOT NULL IDENTITY,
Username		NVARCHAR(30) UNIQUE NOT NULL,
Password		NVARCHAR(26) NOT NULL,
ProfilePicture  VARBINARY(MAX)
CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime   DATETIME2 NOT NULL,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username,Password,LastLoginTime,IsDeleted) VALUES
('Pesho','12345','05.19.2020',0),
('Pesho2','123455','05.18.2020',1),
('Pesho3','123454','05.17.2020',0),
('Pesho4','123453','05.16.2020',2),
('Pesho5','123451','05.15.2020',0)


--Problem 9.	Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC076ED6ED4C

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id,Username)

--Problem 10.	Add Check Constraint
ALTER TABLE Users 
ADD CONSTRAINT CHK_Person CHECK (LEN([Password]) >= 5)

--Problem 11.	Set Default Value of a Field
--Using SQL queries modify table Users. 
--Make the default value of LastLoginTime field to be the current time.

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

--Problem 12.	Set Unique Field


ALTER TABLE Users
DROP PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT
PK_Users_Id 
PRIMARY KEY(Id)

ALTER TABLE USERS
ADD CONSTRAINT CHK_Users_Username  CHECK (LEN(Username) >=3)

--Problem 13.	Movies Database

CREATE DATABASE Movies

USE Movies
--•	Directors (Id, DirectorName, Notes)
--•	Genres (Id, GenreName, Notes)
--•	Categories (Id, CategoryName, Notes)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Directors
(
Id			  INT PRIMARY KEY NOT NULL,
DirectorName  NVARCHAR(30) NOT NULL,
Notes		  NVARCHAR(MAX)
)

CREATE TABLE Genres
(
Id			  INT PRIMARY KEY NOT NULL,
GenreName     NVARCHAR(30)    NOT NULL,
Notes         NVARCHAR(30)
)

CREATE TABLE Categories
(
Id			  INT PRIMARY KEY NOT NULL,
CategoryName  NVARCHAR(30) NOT NULL,
Notes		  NVARCHAR(MAX)
)
--•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

CREATE TABLE Movies
(
Id		      INT PRIMARY KEY NOT NULL,
Title         NVARCHAR(30)    NOT NULL,
DirectorId    INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear INT NOT NULL,
[Length]      time,
GenreId       INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId    INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Rating        DECIMAL(12,1),
Notes         NVARCHAR(MAX)
)

INSERT INTO Directors VALUES 
(1,'Ivan','note 1'),
(2,'Petur','note 2'),
(3,'Stefan','note 3'),
(4,'Georgi','note 4'),
(5,'Stanislav','note 5')

INSERT INTO Genres VALUES 
(1,'Ivan','note 1'),
(2,'Petur','note 2'),
(3,'Stefan','note 3'),
(4,'Georgi','note 4'),
(5,'Stanislav','note 5')

INSERT INTO Categories VALUES 
(1,'Horror','note 1'),
(2,'Drama','note 2'),
(3,'Scifi','note 3'),
(4,'Advendure','note 4'),
(5,'Comedy','note 5')

INSERT INTO Movies(Id,Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId)
VALUES
(1,'Movie1',2,1995,'02:48:12',3,4),
(2,'Movie1',3,1996,'02:48:12',1,3),
(3,'Movie1',4,2005,'02:48:12',4,1),
(4,'Movie1',5,1995,'02:48:12',3,2),
(5,'Movie1',1,2006,'02:48:12',5,5)

--Problem 14.	Car Rental Database

--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--Employees (Id, FirstName, LastName, Title, Notes)
--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
--StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE DATABASE CarRental 
USE CarRental
CREATE TABLE Categories
(
Id         INT PRIMARY KEY NOT NULL,
[Name]	   NVARCHAR(30)    NOT NULL,
DailyRate        DECIMAL(12,1),
WeeklyRate        DECIMAL(12,1),
MonthlyRate        DECIMAL(12,1),
WeekendRate        DECIMAL(12,1),
)

INSERT INTO Categories(Id,Name,DailyRate,WeekendRate) VALUES
(1,'Category One',20,30),
(2,'Category Two',20,30),
(3,'Category Three',20,30)

CREATE TABLE Cars
(
Id           INT PRIMARY KEY NOT NULL,
PlateNumber  NVARCHAR(20) UNIQUE   NOT NULL,
Manufacturer NVARCHAR(20)    NOT NULL,
Model        NVARCHAR(20)    NOT NULL,
CarYear      INT             NOT NULL,
CategoryId   INT FOREIGN KEY REFERENCES Categories(Id)NOT NULL,
Doors        INT,
Picture      VARBINARY(MAX),
Condition    NVARCHAR(20),
Available    NVARCHAR(20)
)

INSERT INTO Cars(Id,PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors)
VALUES
(1,'PB123','Manufacturer One','Model1',1999,1,4),
(2,'PB223','Manufacturer Two','Model2',1999,2,4),
(3,'PB423','Manufacturer Three','Model3',1999,3,4)
--Employees (Id, FirstName, LastName, Title, Notes)

CREATE TABLE Employees
(
Id			INT PRIMARY KEY NOT NULL,
FirstName   NVARCHAR(20)    NOT NULL,
LastName    NVARCHAR(20)    NOT NULL,
Title       NVARCHAR(20)    NOT NULL,
Notes       NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
(1,'Ivan','Ivanov','Title1','note1'),
(2,'Georgi','Petrov','Title2','note2'),
(3,'Ivan','Stefanov','Title3','note3')

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)

CREATE TABLE Customers
(
Id					 INT PRIMARY KEY NOT NULL,
DriverLicenceNumber  NVARCHAR(20)    NOT NULL,
FullName             NVARCHAR(30)    NOT NULL,
[Address]			 NVARCHAR(30),
City                 NVARCHAR(20),
ZIPCode              CHAR(5),
Notes                NVARCHAR(MAX)
)

INSERT INTO Customers
VALUES
(1,'num123','Ivan Ivanov','Adress1','Asenovgrad','12345','note1'),
(2,'num323','Georgi Ivanov','Adress1','Asenovgrad','12345','note1'),
(3,'num223','Stefan Ivanov','Adress1','Asenovgrad','12345','note1')
--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
CREATE TABLE RentalOrders
(	
Id				 INT PRIMARY KEY                          NOT NULL,
EmployeeId		 INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId		 INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CarId			 INT FOREIGN KEY REFERENCES Cars(Id)		 NOT NULL,
TankLevel		 INT,
KilometrageStart INT,
TotalKilometrage INT,
StartDate		 DATE,
EndDate			 DATE,
TotalDays		 INT,
RateApplied      DECIMAL(10, 2),
TaxRate          DECIMAL(10, 2),
OrderStatus      NVARCHAR(50),
NOTES            NVARCHAR(MAX)
)

--StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

INSERT INTO RentalOrders(Id,EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,TotalKilometrage) VALUES
(1,1,1,1,10,20,20),
(2,1,1,1,10,20,20),
(3,1,1,1,10,20,20)

--Problem 15.	Hotel Database




CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
Id			INT PRIMARY KEY NOT NULL,
FirstName   NVARCHAR(20)    NOT NULL,
LastName    NVARCHAR(20)    NOT NULL,
Title       NVARCHAR(20),
Notes       NVARCHAR(MAX)
)

INSERT INTO Employees VALUES
(1,'Ivan','Stefanov','title one','note one'),
(2,'Stefan','Petrov','title two','note two'),
(3,'Petur','Ivanov','title three','note three')
--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
CREATE TABLE Customers
(
AccountNumber   INT PRIMARY KEY NOT NULL,
FirstName       NVARCHAR(20)    NOT NULL,
LastName        NVARCHAR(20)    NOT NULL,
PhoneNumber     CHAR(10) CHECK (PhoneNumber = 10),
EmergencyName   NVARCHAR(20) NOT NULL,
EmergencyNumber CHAR(10) CHECK (EmergencyNumber = 10),
Notes			NVARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber,FirstName,LastName,EmergencyName)
VALUES
(1,'Ivan','Ivanov','emergency1'),
(2,'Georgi','Ivanov','emergency2'),
(3,'Petur','Ivanov','emergency3')

--•	RoomStatus (RoomStatus, Notes)

CREATE TABLE RoomStatus
(
RoomStatus  NVARCHAR(20) PRIMARY KEY NOT NULL,
Notes       NVARCHAR(MAX)
)
INSERT INTO RoomStatus VALUES
('free','note1'),
('not free','note2'),
('free1','note3')

--•	RoomTypes (RoomType, Notes)
CREATE TABLE RoomTypes
(
RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes    NVARCHAR(MAX)
)
INSERT INTO RoomTypes VALUES
('small','note1'),
('big','note2'),
('midle','note3')
SELECT * FROM RoomTypes
--•	BedTypes (BedType, Notes)

CREATE TABLE BedTypes
(
BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes    NVARCHAR(MAX)
)
INSERT INTO BedTypes VALUES
('small','note1'),
('big','note2'),
('midle','note3')

--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)

CREATE TABLE Rooms 
(
RoomNumber     INT PRIMARY KEY NOT NULL,
RoomType       NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType        NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate           DECIMAL(10,2),
RoomStatus     NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL
)
INSERT INTO Rooms (RoomNumber,RoomType,BedType,RoomStatus)
VALUES
(1,'small','small','free'),
(2,'small','small','free'),
(3,'small','small','free')
--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays,
--AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)

CREATE TABLE Payments 
(
Id					INT PRIMARY KEY NOT NULL,
EmployeeId			INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate			Date NOT NULL,
AccountNumber		INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied	Date,
LastDateOccupied    Date,
TotalDays           INT,
AmountCharged       DECIMAL(12,2),
TaxRate             DECIMAL(12,2),
TaxAmout            DECIMAL(12,2),
PaymentTotal        DECIMAL(12,2),
Notes               NVARCHAR(MAX)
)

INSERT INTO Payments(Id,EmployeeId,PaymentDate,AccountNumber)
VALUES
(1,1,'11.11.2019',1),
(3,1,'11.11.2019',1),
(2,1,'11.11.2019',1)


--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)

CREATE TABLE Occupancies
(
Id					INT PRIMARY KEY NOT NULL,
EmployeeId          INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
AccountNumber       INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber          INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied         DECIMAL(6,2),
PhoneCharge         DECIMAL(6,2),
Notes               NVARCHAR(MAX)
)

INSERT INTO Occupancies(Id,EmployeeId,AccountNumber,RoomNumber)
VALUES
(1,1,1,1),
(2,2,2,2),
(3,3,3,3)

--Problems FOR SoftUni Database

USE SoftUni

SELECT Name FROM Towns
ORDER BY Name ASC

SELECT Name FROM Departments
ORDER BY Name ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC
----------------------------
UPDATE Employees
SET Salary *= 1.10;

SELECT Salary FROM Employees


----------------------
USE Hotel

UPDATE Payments 
SET TaxRate  *= 0.97

SELECT TaxRate FROM Payments
------
DELETE FROM Occupancies 