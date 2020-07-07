CREATE DATABASE Bitbucket
USE Bitbucket

--1.Table creation

CREATE TABLE Users
(
Id          INT PRIMARY KEY IDENTITY,
Username    VARCHAR(30) NOT NULL,
Password    VARCHAR(30) NOT NULL,
Email       VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
Id          INT PRIMARY KEY IDENTITY,
Name        VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues 
(
Id          INT PRIMARY KEY IDENTITY,
Title       VARCHAR(255) NOT NULL,
IssueStatus CHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
Id          INT PRIMARY KEY IDENTITY,
Message     VARCHAR(255) NOT NULL,
IssueId	    INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Files
(
Id          INT PRIMARY KEY IDENTITY,
Name        VARCHAR(100) NOT NULL,
Size        DECIMAL(18,2) NOT NULL,
ParentId    INT FOREIGN KEY REFERENCES Files(Id),
CommitId    INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)


--2.	Insert

INSERT INTO Files VALUES
('Trade.idk',2598.0,1,1),
('menu.net',9238.31,2,2),
('Administrate.soshy',1246.93,3,3),
('Controller.php',7353.15,4,4),
('Find.java',9957.86,5,5),
('Controller.json',14034.87,3,6),
('Operate.xix',7662.92,7,7)

INSERT INTO Issues VALUES
('Critical Problem with HomeController.cs file','open',1,4),
('Typo fix in Judge.html','open',4,3),
('Implement documentation for UsersService.cs','closed',8,2),
('Unreachable code in Index.cs','open',9,8)

--3.	Update
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4.	Delete
--Delete repository "Softuni-Teamwork" in repository contributors and issues.


DELETE FROM Files
WHERE CommitId =
(SELECT Id FROM Commits
WHERE RepositoryId=
(SELECT Id FROM Repositories 
WHERE Name = 'Softuni-Teamwork'))

DELETE FROM Issues 
WHERE RepositoryId =
(SELECT Id FROM Repositories 
WHERE Name = 'Softuni-Teamwork')

DELETE FROM Commits
WHERE RepositoryId =
(SELECT Id FROM Repositories 
WHERE Name = 'Softuni-Teamwork')

DELETE FROM RepositoriesContributors
WHERE RepositoryId =
(SELECT Id FROM Repositories 
WHERE Name = 'Softuni-Teamwork')

DELETE FROM Repositories
WHERE Id =
(SELECT Id FROM Repositories 
WHERE Name = 'Softuni-Teamwork')

----5.	Commits
--Select all commits from the database. Order them by id (ascending), 
--message (ascending), repository id (ascending) and contributor id (ascending).


SELECT Id,Message,RepositoryId,ContributorId
FROM Commits
ORDER BY Id ASC,
         Message ASC,
		 RepositoryId ASC,
		 ContributorId ASC


--6.	Heavy HTML
--Select all of the files, which have size, greater than 1000,
--and their name contains "html". Order them by size (descending), id (ascending) and by file name (ascending)

SELECT Id,Name,Size
FROM Files
WHERE Size > 1000 AND 
Name LIKE '%html%'
ORDER BY Size DESC,
         Id ASC,
		 Name ASC

--7.	Issues and Users
--Select all of the issues, and the users that are assigned to them,
--so that they end up in the following format: {username} : {issueTitle}.
--Order them by issue id (descending) and issue assignee (ascending).

SELECT i.Id,CONCAT(u.Username,' : ',i.Title) 
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,i.AssigneeId ASC

--8.	Non-Directory Files
--Examples
--Select all of the files, which are NOT a parent to any other file.
--Select their size of the file and add "KB" to the end of it.
--Order them file id (ascending), file name (ascending) and file size (descending).



SELECT f1.Id, f1.[Name], CONCAT(f1.Size,'KB') AS [Size]
    FROM Files as f1
    LEFT JOIN Files as f2 ON f1.Id = f2.ParentId
    WHERE f2.Id IS NULL
    ORDER BY f1.Id,f1.[Name],f1.Size DESC

--9.	Most Contributed Repositories
--Select the top 5 repositories in terms of count of commits.
--Order them by commits count (descending), repository id (ascending) then by repository name (ascending).



SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS [Commits] FROM Repositories AS r
JOIN Commits AS c
ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]

--  10.Select all users which have commits. Select their username and average size of the file, 
--which were uploaded by them. Order the results by average upload size (descending) and by username (ascending).

SELECT u.Username,AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC,Username ASC

--11.	 User Total Commits
--Create a user defined function, named udf_UserTotalCommits(@username) that receives a username.
--The function must return count of all commits for the user:
GO
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30)) 
RETURNS INT
AS
	BEGIN
	DECLARE @userCommitsCount INT
	SET @userCommitsCount = 
	(SELECT COUNT(c.ContributorId) FROM Users AS u
	JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username
	GROUP BY u.Id);
	RETURN @userCommitsCount;
	END
	GO

	SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

	SELECT * FROM Users AS u
	JOIN Commits AS c ON c.ContributorId = u.Id
	 JOIN RepositoriesContributors AS rc ON u.Id = rc.ContributorId
	 JOIN Repositories AS r ON r.Id = rc.ContributorId
	 WHERE u.Id = 1
	 SELECT * FROM Commits
--12.	 Find by Extensions
--Create a user defined stored procedure, named usp_FindByExtension(@extension),
--that receives a files extensions.
--The procedure must print the id, name and size of the file.
--Add "KB" in the end of the size. Order them by id (ascending),
--file name (ascending) and file size (descending)

CREATE PROC usp_FindByExtension(@extension VARCHAR(30))
AS 
SELECT Id,Name,CAST(Size as varchar(30)) + 'KB'
FROM Files
WHERE Name Like '%' + @extension
ORDER By Id,Name,Size DESC

EXEC usp_FindByExtension 'txt'

SELECT * FROM Commits