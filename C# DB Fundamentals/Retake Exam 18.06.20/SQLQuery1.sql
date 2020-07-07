CREATE DATABASE ColonialJourney 

USE ColonialJourney 

CREATE TABLE Planets
(
Id INT PRIMARY KEY IDENTITY,
NAME VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
Id INT PRIMARY KEY IDENTITY,
NAME VARCHAR(50) NOT NULL,
PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
Id INT PRIMARY KEY IDENTITY,
NAME VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn       VARCHAR(10) NOT NULL UNIQUE,
BirthDate Date NOT NULL
)

CREATE TABLE Journeys
(
Id INT PRIMARY KEY IDENTITY,
JourneyStart DateTime NOT NULL,
JourneyEnd   DateTime NOT NULL,
Purpose       VARCHAR(11),
DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL,
CONSTRAINT CHK_Purpose CHECK ( Purpose = 'Medical' OR Purpose = 'Technical' OR Purpose = 'Educational' OR  Purpose = 'Military')
)

--Medical”, “Technical”, “Educational”, “Military”.

CREATE TABLE TravelCards
(
Id INT PRIMARY KEY IDENTITY,
CardNumber CHAR(10) NOT NULL UNIQUE,
JobDuringJourney VARCHAR(8),
ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL,
CONSTRAINT CHK_JobDuringJourney CHECK (JobDuringJourney = 'Pilot' OR JobDuringJourney = 'Engineer' OR JobDuringJourney = 'Trooper'
OR JobDuringJourney = 'Cleaner' OR JobDuringJourney = 'Cook')
)
)
--02




INSERT INTO Planets
(Name)
VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships
(Name,Manufacturer,LightSpeedRate)
VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9','SpaceX',1),
('Bed','Vidolov',6)

--3.	Update
--Update all spaceships light speed rate with 1 where the Id is between 8 and 12

UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12


--DELETE
DELETE FROM TravelCards
WHERE JourneyId IN
(SELECT TOP(3)Id FROM Journeys)

DELETE TOP(3) FROM Journeys

--9.	Select all planets and their journey count
--Extract from the database all planets’ names and their journeys count. Order the results by journeys count, descending and by planet name ascending.
--Required Columns
--•	PlanetName
--•	JourneysCount

SELECT p.Name,COUNT(j.Id) FROM Planets AS p
JOIN Spaceports AS s ON p.Id = s.PlanetId
JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
GROUP By p.Name
ORDER BY COUNT(j.Id) DESC,p.Name ASC


--5.	Select all military journeys
--Extract from the database, all Military journeys in the format "dd-MM-yyyy". Sort the results ascending by journey start.

SELECT Id,FORMAT(cast(JourneyStart as date),'dd/MM/yyyy') AS JourneyStart,
FORMAT(cast(JourneyEnd as date),'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart ASC

--6.	Select all pilots
--Extract from the database all colonists, which have a pilot job. Sort the result by id, ascending.
--`Required Columns
--•	Id
--•	FullName

SELECT c.Id,c.FirstName + ' ' + c.LastName AS [FullName
] FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id ASC

--7.	Count colonists
--Count all colonists that are on technical journey. 

SELECT COUNT(*) FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

--8.	Select spaceships with pilots younger than 30 years
--Extract from the database those spaceships, which have pilots,
--younger than 30 years old. In other words, 30 years from 01/01/2019. Sort the results alphabetically by spaceship name.


SELECT ss.NAME,ss.Manufacturer FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
JOIN Spaceships AS ss ON j.SpaceshipId = ss.Id
WHERE tc.JobDuringJourney = 'Pilot' 
AND DATEDIFF(year,c.BirthDate,'01/01/2019') < 30
ORDER BY ss.NAME ASC

--10.	Select Second Oldest Important Colonist
--Find all colonists and their job during journey with rank 2. 
--Keep in mind that all the selected colonists with rank 2 must be the oldest ones.
--You can use ranking over their job during their journey.
--Required Columns
--•	JobDuringJourney
--•	FullName
--•	JobRank



--Section 4. Programmability
--11.	Get Colonists Count
--Create a user defined function with the name dbo.udf_GetColonistsCount(PlanetName VARCHAR (30))
--that receives planet name and returns the count of all colonists sent to that planet.
 GO
CREATE FUNCTION dbo.udf_GetColonistsCount(@name VARCHAR(30))
RETURNS INT
AS
 BEGIN

 DECLARE @output INT;
 SET @output = (SELECT COUNT(*) FROM Planets AS p
 JOIN Spaceports AS sp ON p.Id = sp.PlanetId
 JOIN Journeys AS j ON sp.Id = j.DestinationSpaceportId
 JOIN TravelCards AS tc ON tc.JourneyId = j.Id
 JOIN Colonists AS c ON tc.ColonistId = c.Id
 WHERE p.Id IN (SELECT Id FROM Planets WHERE NAME = @name))
 RETURN @output;
 END

SELECT * FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
JOIN Journeys AS j ON tc.JourneyId = j.Id
JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
WHERE sp.PlanetId IN (SELECT Id FROM Planets WHERE NAME = 'Otroyphus')


----12.	Change Journey Purpose
--Create a user defined stored procedure, named usp_ChangeJourneyPurpose(@JourneyId, @NewPurpose),
--that receives an journey id and purpose, and attempts to change the purpose of that journey.
--An purpose will only be changed if all of these conditions pass:
--•	If the journey id doesn’t exists, then it cannot be changed. Raise an error with the message “The journey does not exist!”
--•	If the journey has already that purpose, raise an error with the message “You cannot change the purpose!”
--If all the above conditions pass, change the purpose of that journey.

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(30))
AS

DECLARE @realJourneyId INT= (SELECT Id FROM Journeys WHERE Id = @JourneyId)

DECLARE @realPurpose VARCHAR(30) = (SELECT Purpose FROM Journeys WHERE Id = @realJourneyId)

IF(@realJourneyId IS NULL)
THROW 50001,'The journey does not exist!',1;

IF(@realPurpose = @NewPurpose)
THROW 50002,'You cannot change the purpose!',1;

UPDATE Journeys
SET Purpose = @NewPurpose
WHERE Id = @JourneyId

EXEC usp_ChangeJourneyPurpose 2, 'Educational'

SELECT * FROM Journeys WHERE Id = 2

EXEC usp_ChangeJourneyPurpose 196, 'Technical'

SELECT * FROM Journeys WHERE Id = 196

----10.	Select Second Oldest Important Colonist
--Find all colonists and their job during journey with rank 2.
--Keep in mind that all the selected colonists with rank 2 must be the oldest ones.
--You can use ranking over their job during their journey.
SELECT * FROM
(
SELECT tc.JobDuringJourney,
       c.FirstName + ' ' + c.LastName AS FullName,
	   DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) AS [Rank]
FROM Colonists AS c
JOIN TravelCards AS tc ON c.Id = tc.ColonistId
) AS tmp
WHERE tmp.Rank = 2









