--------------------------------------Exam – 17 Feb 2019--------------------------------

CREATE DATABASE School

USE School

--PROBLEM 1 CREATE TABLES

CREATE TABLE Students 
(
Id         INT PRIMARY KEY IDENTITY,
FirstName  NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName   NVARCHAR(30) NOT NULL,
Age		   INT CHECK(Age > 0),
[Address]  NVARCHAR(50),
Phone      CHAR(10),
)

CREATE TABLE Subjects 
(
Id     INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL,
CHECK(Lessons > 0)
)

CREATE TABLE Exams
(
Id        INT PRIMARY KEY IDENTITY,
[Date]    DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE Teachers
(
Id          INT PRIMARY KEY IDENTITY,
FirstName   NVARCHAR(20) NOT NULL,
LastName    NVARCHAR(20) NOT NULL,
[Address]   NVARCHAR(20) NOT NULL,
Phone       CHAR(10),
SubjectId   INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsSubjects
(
Id        INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade     DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6)
)

CREATE TABLE StudentsExams
(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId    INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade     DECIMAL(15,2) NOT NULL CHECK(Grade BETWEEN 2 AND 6),
PRIMARY KEY(StudentId,ExamId)
)

CREATE TABLE StudentsTeachers 
(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY(StudentId,TeacherId)
)


--Probelm 2. INSERT
INSERT INTO Teachers(FirstName,	LastName,	Address,	Phone,	SubjectId) 
VALUES
('Ruthanne',	'Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza'	,'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects(Name,	Lessons)
VALUES
('Geometry',	12),
('Health',	10),
('Drama',	7),
('Sports',	9)

--Problem 3.
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE  Grade >= 5.50 AND SubjectId IN (1,2)

--Problem 4.
DELETE FROM StudentsTeachers WHERE TeacherId IN ( SELECT Id FROM Teachers WHERE Phone LIKE '%72%')
DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--Problem 5.
SELECT FirstName,LastName,Age FROM Students
WHERE AGE >= 12
ORDER BY FirstName ASC,LastName ASC

--Probelm 6.
SELECT FirstName + ' ' + ISNULL(MiddleName,'') + ' ' + LastName AS [Full Name],
Address FROM Students
WHERE [Address] LIKE '%road%'
ORDER BY FirstName ASC,
LastName ASC,
[Address] ASC

--Probelem 7.
SELECT FirstName,Address,Phone FROM Students
WHERE MiddleName IS NOT NULL
AND Phone Like '42%'
ORDER BY FirstName ASC

--Probelm 8.
SELECT s.FirstName,s.LastName,COUNT(st.TeacherId) FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id = st.StudentId
GROUP BY s.FirstName,s.LastName

--Probelm 9.
SELECT t.FirstName + ' ' + t.LastName AS [FullName],
s.Name +'-'+ CAST(s.Lessons AS NVARCHAR(5)) AS [Subjects],
COUNT(st.StudentId) AS [Students]
FROM Teachers AS t
JOIN Subjects AS s ON t.SubjectId = s.Id
JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName,t.LastName,s.Name,s.Lessons
ORDER BY COUNT(st.StudentId) DESC,FullName ASC,Subjects ASC

--Probelm 10.
SELECT s.FirstName + ' '+ LastName AS [Full Name]
FROM Students AS s
FULL OUTER JOIN StudentsExams AS se ON s.Id = se.StudentId
WHERE StudentId IS NULL
ORDER BY [Full Name] ASC

--Problem 11.
SELECT   TOP(10)t.FirstName,t.LastName,COUNT(st.StudentId) AS StudentsCount
FROM     Teachers AS t
JOIN     StudentsTeachers AS st ON t.Id = st.TeacherId
GROUP BY t.FirstName,t.LastName
ORDER BY StudentsCount DESC,t.FirstName,t.LastName

--Probelm 12.
SELECT TOP(10)s.FirstName,s.LastName,CONVERT(DECIMAL(12,2),AVG(se.Grade)) AS Grade
FROM Students AS s 
JOIN StudentsExams AS se ON s.Id = se.StudentId
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC,FirstName,LastName

--Probelm 13.
SELECT k.FirstName,k.LastName,k.Grade FROM
(SELECT FirstName,LastName,Grade,ROW_NUMBER() OVER (PARTITION BY FirstName, LastName ORDER BY Grade DESC) AS RowNumber
FROM Students AS s
JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId) AS k
WHERE RowNumber = 2
ORDER BY FirstName,LastName

--Probelm 14.
SELECT FirstName + ' ' + ISNULL(s.MiddleName +' ','') + s.LastName AS FullName
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
WHERE ss.Id IS NULL
ORDER BY FullName 

--15. Top Student per Teacher
--Find all teachers with their top students. 
--The top student is the person with highest average grade.
--Select teacher full name (first name + last name), subject name,
--student full name (first name + last name) and corresponding grade.
--The grade must be formatted to the second digit after the decimal point.
--Sort the results by subject name (ascending), then by teacher full name (ascending), then by grade (descending)

SELECT k.[Teacher Full Name],k.[Subject Name],k.[Student Full Name],FORMAT(k.Grade,'N2') FROM
(SELECT  t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
	    s.Name AS [Subject Name],
        stu.FirstName + ' ' + stu.LastName AS [Student Full Name],
		AVG(ss.Grade) AS Grade,
		ROW_NUMBER() OVER(PARTITION BY t.FirstName,T.LastName ORDER BY AVG(ss.Grade) DESC) AS RowNumber
FROM Teachers AS t
	 JOIN StudentsTeachers AS st ON t.Id = st.TeacherId
	 JOIN Students AS stu ON st.StudentId = stu.Id
	 JOIN StudentsSubjects AS ss ON stu.Id = ss.StudentId
	 JOIN Subjects AS s ON ss.SubjectId = s.Id AND s.Id = t.SubjectId
GROUP BY t.FirstName,t.LastName,s.Name,stu.FirstName,stu.LastName) AS k
WHERE RowNumber = 1
ORDER BY k.[Subject Name] ASC,k.[Teacher Full Name] ASC,k.Grade DESC

--16. Average Grade per Subject
--Find the average grade for each subject. Select the subject name and the average grade. 
--Sort them by subject id (ascending).

SELECT   s.Name,AVG(ss.Grade) AS [Average Grade]
FROM     Subjects AS s
JOIN     StudentsSubjects AS ss ON s.Id = SubjectId
GROUP BY s.Name,s.Id
ORDER BY s.Id ASC

--17. Exams Information
--Divide the year in 4 quarters using the exam dates.
--For each quarter get the subject name and the count of students who took the exam with grade more or equal to 4.00.
--If the date is missing, replace it with “TBA”. Order them by quarter ascending.

SELECT k.[Quarter],k.SubjectName,COUNT(k.StudentId) FROM
(SELECT s.Name AS [SubjectName],
se.StudentId,
CASE
WHEN DATEPART(MONTH,e.Date) BETWEEN 1 AND 3 THEN 'Q1'
WHEN DATEPART(MONTH,e.Date) BETWEEN 4 AND 6 THEN 'Q2'
WHEN DATEPART(MONTH,e.Date) BETWEEN 7 AND 9 THEN 'Q3'
WHEN DATEPART(MONTH,e.Date) BETWEEN 10 AND 12 THEN 'Q4'
WHEN Date IS NULL THEN 'TBA'
END AS [Quarter]
FROM   Exams As e
		JOIN Subjects AS s ON e.SubjectId = s.Id
		JOIN StudentsExams AS se On e.Id = se.ExamId
		WHERE se.Grade >= 4 ) AS k
		GROUP BY k.SubjectName,k.Quarter
		ORDER BY k.Quarter ASC



		--Section 4. Programmability

--18. Exam Grades

CREATE  FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(18,2))
RETURNS NVARCHAR(MAX)
AS 
BEGIN

DECLARE @Id INT = (SELECT TOP(1)StudentId From StudentsExams WHERE StudentId = @studentId)

IF @Id IS NULL
BEGIN
RETURN ('The student with provided id does not exist in the school!')
END

IF @grade > 6
BEGIN 
RETURN ('Grade cannot be above 6.00!')
END

DECLARE @count INT = (SELECT COUNT(Grade) FROM StudentsExams WHERE StudentId =
@studentId AND Grade >= @grade AND Grade <= @grade + 0.50)
DECLARE @name NVARCHAR(20) = (SELECT TOP(1)FirstName FROM Students WHERE Id = @studentId)


RETURN ('You have to update ' + CAST(@count AS NVARCHAR(20)) +' grades for the student ' + @name)
END
		

---PROBLEM 19

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS


DECLARE @targetStudent INT =(SELECT Id FROM Students WHERE Id = @StudentId)

IF(@targetStudent IS NULL)
BEGIN
	RAISERROR('This school has no student with the provided id!', 16, 1)
	RETURN
END

DELETE FROM StudentsExams
WHERE StudentId = @StudentId

DELETE FROM StudentsSubjects
WHERE StudentId = @StudentId

DELETE FROM StudentsTeachers
WHERE StudentId = @StudentId

DELETE FROM Students
WHERE Id = @StudentId



--PROBELM 20

CREATE TABLE ExcludedStudents
(StudentId INT, 
StudentName VARCHAR(30)
)

CREATE TRIGGER tr_StudentsDelete ON Students 
INSTEAD OF DELETE
AS
INSERT INTO ExcludedStudents(StudentId, StudentName)
		SELECT Id, FirstName + ' ' + LastName FROM deleted




