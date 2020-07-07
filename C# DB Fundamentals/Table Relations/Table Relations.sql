CREATE DATABASE TableReationsDemo

USE TableReationsDemo
--Problem 1.	One-To-One Relationship
CREATE TABLE Passports
(
PassportID  INT  PRIMARY KEY,
PassportNumber NVARCHAR(8) NOT NULL
)

CREATE TABLE Persons
(
PersonID INT PRIMARY KEY,
FirstName VARCHAR(20) NOT NULL,
Salary DECIMAL(15,2),
PassportID INT NOT NULL
)

Alter Table Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)

ALTER TABLE Persons
ADD UNIQUE (PassportID)

ALTER TABLE Passports
ADD UNIQUE (PassportNumber)

INSERT INTO Passports (PassportID,PassportNumber) VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

INSERT INTO Persons (PersonID,FirstName,Salary,PassportID) VALUES
(1, 'Roberto', 43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)



--------- Problem 02.

CREATE TABLE Manufacturers
(
ManufacturerID INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
EstablishedOn DATE NOT NULL
)

CREATE TABLE Models
(
ModelID INT PRIMARY KEY,
[Name] NVARCHAR(20) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers (ManufacturerID,[Name],EstablishedOn) VALUES
(1  ,'BMW',	'07/03/1916'),
(2	,'Tesla','01/01/2003'),
(3,	'Lada',	'01/05/1966')

INSERT INTO Models (ModelID,[Name],ManufacturerID) VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)



------------Problem 03.

CREATE TABLE Students
(
StudentID INT PRIMARY KEY,
[Name] VARCHAR(40) NOT NULL
)

CREATE TABLE Exams
(
ExamID INT PRIMARY KEY,
[Name] VARCHAR(40) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentID_ExamID PRIMARY KEY(StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
)

--------Probelm 04.

CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(40) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

---------Problem 5.	Online Store Database

CREATE DATABASE [Online Store]

USE [Online Store]

CREATE TABLE Cities
(
CityID INT PRIMARY KEY NOT NULL,
Name   VARCHAR(50)    NOT NULL
)

CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY NOT NULL,
[Name]     VARCHAR(50)     NOT NULL,
Birthday   DATE             NOT NULL,
CityID     INT  FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders
(
OrderID     INT PRIMARY KEY NOT NULL,
CustomerID  INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)


CREATE TABLE ItemTypes
(
ItemTypeID INT PRIMARY KEY NOT NULL,
Name       VARCHAR(50)     NOT NULL
)

CREATE TABLE Items
(
ItemID      INT PRIMARY KEY NOT NULL,
Name        VARCHAR(50)     NOT NULL,
ItemTypeID  INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems
(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
ItemID  INT FOREIGN KEY REFERENCES Items(ItemID)   NOT NULL,
PRIMARY KEY(OrderID,ItemID)
)

--Problem 6.	University Database
CREATE DATABASE University

USE University

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY NOT NULL,
[Name]  VARCHAR(50)     NOT NULL
)

CREATE TABLE Students
(
StudentID      INT PRIMARY KEY NOT NULL,
StudentNumber  INT             NOT NULL,
StudentName    VARCHAR(50)	   NOT NULL,
MajorID        INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL,
)

CREATE TABLE Subjects
(
SubjectID	INT PRIMARY KEY NOT NULL,
SubjectName NVARCHAR(50)    NOT NULL
)

CREATE TABLE Agenda
(
StudentID  INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
SubjectID  INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL,
PRIMARY KEY (StudentID,SubjectID)
)

CREATE TABLE Payments
(
PaymentID		INT PRIMARY KEY NOT NULL,
PaymentDate		DATE            NOT NULL,
PaymentAmount   DECIMAL(12,2)   NOT NULL,
StudentID       INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)


--Problem 9.	*Peaks in Rila

USE Geography

SELECT m.MountainRange,p.PeakName,p.Elevation
FROM   Peaks AS p
JOIN   Mountains AS m ON p.MountainId = m.Id
WHERE  m.MountainRange LIKE 'Rila'
ORDER BY p.Elevation DESC
