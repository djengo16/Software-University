CREATE DATABASE Airport
USE Airport
--Section 1. DDL (30 pts)
CREATE TABLE Planes
(
Id	INT PRIMARY KEY IDENTITY,
Name	VARCHAR(30)	NOT NULL,
Seats	INT NOT NULL,
Range	INT NOT NULL,
)

CREATE TABLE Flights
(
Id			   INT PRIMARY KEY IDENTITY,
DepartureTime  Datetime,
ArrivalTime    Datetime,
Origin         VARCHAR(50) NOT NULL,
Destination    VARCHAR(50) NOT NULL,
PlaneId        INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
Id         INT PRIMARY KEY IDENTITY,
FirstName  VARCHAR(30) NOT NULL,
LastName   VARCHAR(30) NOT NULL,
Age        INT NOT NULL,
Address    VARCHAR(30) NOT NULL,
PassportId CHAR(11)    NOT NULL
)

CREATE TABLE LuggageTypes
(
Id	    INT PRIMARY KEY IDENTITY,
Type	VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
Id	 INT PRIMARY KEY IDENTITY,
LuggageTypeId	INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId	INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
)

CREATE TABLE Tickets
(
Id	INT PRIMARY KEY IDENTITY,
PassengerId	INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId	INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId	INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price	    DECIMAL(18,2) NOT NULL
)

--2.	Insert

INSERT INTO Planes VALUES
('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--3.	Update
--Make all flights to "Carlsbad" 13% more expensive.

UPDATE Tickets
SET Price += (Price * 0.13)
WHERE FlightId IN
(SELECT Id FROM Flights
WHERE Destination = 'Carlsbad')

--4.	Delete
--Delete all flights to "Ayn Halagim".
DELETE FROM Tickets
WHERE FlightId IN
(SELECT Id FROM Flights
WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--Section 3. Querying (40 pts)
--5.	The "Tr" Planes
--Select all of the planes, which name contains "tr". 
--Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).

SELECT * FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id ASC,
         Name ASC,
		 Seats ASC,
		 Range ASC


		 
--6.	Flight Profits
--Select the total profit for each flight from database. Order them by total price (descending), flight id (ascending).


SELECT f.Id AS FlightId,
SUM(t.Price) AS Price
FROM Flights AS f
JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY f.Id
ORDER BY Price DESC,FlightId ASC

--7.	Passenger Trips
--Select the full name of the passengers with their trips (origin - destination).
--Order them by full name (ascending), origin (ascending) and destination (ascending).

SELECT p.FirstName + ' ' + p.LastName AS [FullName],
       f.Origin,
	   f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY FullName ASC,Origin ASC,Destination ASC


--8.	Non Adventures People
--Select all people who don't have tickets. Select their first name,
--last name and age .Order them by age (descending), first name (ascending) and last name (ascending).

SELECT p.FirstName,
       p.LastName,
	   p.Age
FROM Passengers AS p
FULL OUTER JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY Age DESC,FirstName,LastName

----9.	Full Info
--Select all passengers who have trips. Select their full name (first name – last name),
--plane name, trip (in format {origin} - {destination}) and luggage type.
--Order the results by full name (ascending), name (ascending), origin (ascending),
--destination (ascending) and luggage type (ascending).

SELECT CONCAT(p.FirstName,' ', p.LastName) AS FullName,
       pl.Name AS PlaneName,
	   CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	   lt.Type AS LuggageType
FROM Passengers AS p
INNER JOIN Tickets		AS t ON p.Id = t.PassengerId
INNER JOIN Flights		AS f ON t.FlightId = f.Id
INNER JOIN Planes			AS pl ON f.PlaneId = pl.Id
INNER JOIN Luggages		AS l ON l.Id = t.LuggageId
INNER JOIN LuggageTypes   AS lt ON l.LuggageTypeId = lt.Id
ORDER BY FullName,PlaneName,f.Origin,f.Destination,LuggageType

--10.	PSP
--Select all planes with their name, seats count and passengers count.
--Order the results by passengers count (descending), plane name (ascending) and seats (ascending) 



SELECT p.Name,
Seats,
COUNT(t.Id) AS PassengerCount
FROM Planes AS p
FULL OUTER JOIN Flights AS f ON p.Id = f.PlaneId
FULL OUTER JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY p.Name,p.Seats
ORDER BY PassengerCount DESC,p.Name ASC,Seats ASC

--11.	Vacation
--Create a user defined function, named udf_CalculateTickets(@origin, @destination, @peopleCount) 
--that receives an origin (town name), destination (town name) and people count.
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"

CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin VARCHAR(20), @destination VARCHAR(20), @peopleCount INT)
RETURNS VARCHAR(MAX)
 AS
  BEGIN

  DECLARE @Id INT = (SELECT Id FROM Flights WHERE Origin = @origin AND @destination = Destination)

  IF @peopleCount <= 0
  RETURN 'Invalid people count!'
  ELSE IF (@Id IS NULL)
  RETURN 'Invalid flight!'
  ELSE
   BEGIN
   DECLARE @Price DECIMAL(18,2) = 
      (
	  SELECT Price FROM 
      Tickets AS t
      JOIN Flights AS f ON f.Id = t.FlightId
      WHERE FlightId = @Id
	  )
  RETURN 'Total price ' + CAST((@Price * @peopleCount) AS VARCHAR(20));
    END

	RETURN '';

  END

  SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)


  --Create a user defined stored procedure, named usp_CancelFlights
--The procedure must cancel all flights on which the arrival time is before the departure time.
--Cancel means you need to leave the departure and arrival time empty.

CREATE PROC usp_CancelFlights
AS

UPDATE Flights
SET DepartureTime = NULL,ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime

EXEC dbo.usp_CancelFlights