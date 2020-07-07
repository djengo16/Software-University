CREATE DATABASE TripService
USE TripService

--DDL

CREATE TABLE Cities
(
Id			INT PRIMARY KEY IDENTITY,
Name        NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
Id			  INT PRIMARY KEY IDENTITY,
Name          NVARCHAR(30) NOT NULL,
CityId        INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate      DECIMAL(18,2)
)

CREATE TABLE Rooms
(
Id			  INT PRIMARY KEY IDENTITY,
Price         DECIMAL(18,2) NOT NULL,
Type          NVARCHAR(20) NOT NULL,
Beds          INT NOT NULL,
HotelId       INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
Id			  INT PRIMARY KEY IDENTITY,
RoomId        INT FOREIGN KEY REFERENCES Rooms(Id)NOT NULL,
BookDate      Date NOT NULL,
ArrivalDate   Date NOT NULL,
ReturnDate    Date NOT NULL,
CancelDate    Date,
CHECK(BookDate < ArrivalDate),
CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
Id			  INT PRIMARY KEY IDENTITY,
FirstName     NVARCHAR(50) NOT NULL,
MiddleName    NVARCHAR(20),
LastName      NVARCHAR(50) NOT NULL,
CityId        INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate     Date NOT NULL,
Email         VARCHAR(100) NOT NULL,
UNIQUE(Email)
)

CREATE TABLE AccountsTrips
(
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId    INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT CHECK(Luggage >= 0),
PRIMARY KEY(AccountId,TripId)
)

--2. Insert

INSERT INTO Accounts
(FirstName,	MiddleName,	LastName,	CityId,	BirthDate,	Email)
VALUES
('John',	'Smith',	'Smith',	34,	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',	'Petrovich',	'Pavlov',	59,	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	2,	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips
(RoomId,	BookDate,	ArrivalDate,	ReturnDate,	CancelDate)
VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',   '2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--3. Update
--Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.

UPDATE Rooms
SET Price = Price + (Price * 0.14)
WHERE HotelId IN (5,7,9)

--4. Delete
--Delete all of Account ID 47’s account’s trips from the mapping table.

DELETE FROM AccountsTrips
WHERE AccountId = 47

SELECT * FROM AccountsTrips
WHERE AccountId = 47

--5. EEE-Mails
--Select accounts whose emails start with the letter “e”.
--Select their first and last name, their birthdate in the format "MM-dd-yyyy", and their city name.
--Order them by city name (ascending)

SELECT FirstName,LastName,
       FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,
	   c.Name,
	   a.Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.Name

--6. City Statistics
--Select all cities with the count of hotels in them.
--Order them by the hotel count (descending),
--then by city name. Do not include cities, which have no hotels in them.

SELECT c.Name,
	   COUNT(h.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Id,c.Name
ORDER BY Hotels DESC,
         c.Name



--7. Longest and Shortest Trips
--Find the longest and shortest trip for each account, in days.
--Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null).
--Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).

SELECT a.Id,
       CONCAT(a.FirstName,' ',a.LastName) AS FullName,
	   MAX(DATEDIFF(day,t.ArrivalDate,t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(day,t.ArrivalDate,t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON t.Id = at.TripId
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id,a.FirstName,a.LastName
ORDER BY LongestTrip DESC,ShortestTrip ASC

--8. Metropolis
--Find the top 10 cities, which have the most registered accounts in them.
--Order them by the count of accounts (descending).

SELECT TOP(10) c.Id,
				c.Name,
				c.CountryCode,
               COUNT(a.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id,c.Name,c.CountryCode
ORDER BY Accounts DESC

--09. Find all accounts, which have had one or more trips to a hotel in their hometown.
--Order them by the trips count (descending), then by Account ID.

SELECT a.Id,a.Email,c.Name,COUNT(t.Id) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
WHERE a.CityId = c.Id
GROUP BY a.Id,a.Email,c.Name
ORDER BY Trips DESC,a.Id ASC


--10. GDPR Violation
--Retrieve the following information about each trip:
--•	Trip ID
--•	Account Full Name
--•	From – Account hometown
--•	To – Hotel city
--•	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
--Order the results by full name, then by Trip ID.
SELECT t.Id AS Id,
		a.CityId AS AccountCityId,
	   CONCAT(a.FirstName,IIF(a.MiddleName IS NULL,' ',' ' + a.MiddleName + ' '),a.LastName) AS FullName,
	   c.Name AS [From],
	   (SELECT Name FROM Cities WHERE Id = h.CityId) AS [To],
	   c.Id AS CityId ,
	   IIF(t.CancelDate IS NULL,CONCAT(DATEDIFF(day,t.ArrivalDate,t.ReturnDate),' ','days'),'Canceled') AS Duration
	   
FROM
Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON a.CityId = c.Id
ORDER BY FullName,t.Id



--Create a user defined function, named udf_GetAvailableRoom(@HotelId, @Date, @People),
--that receives a hotel ID, a desired date, and the count of people that are going to be signing up.
--The total price of the room can be calculated by using this formula:
--•	(HotelBaseRate + RoomPrice) * PeopleCount
--The function should find a suitable room in the provided hotel, based on these conditions:
--•	The room must not be already occupied.
--A room is occupied if the date the customers want to book is between the arrival and return dates of a trip to that room and the trip is not canceled.
--•	The room must be in the provided hotel.
--•	The room must have enough beds for all the people.
--If any rooms in the desired hotel satisfy the customers’ conditions, find the highest priced room (by total price)
--of all of them and provide them with that room.
--The function must return a message in the format:
--•	“Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}”
--If no room could be found, the function should return “No rooms available”.
GO
CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId int, @Date Date, @People INT)
RETURNS VARCHAR(MAX)
AS 
  BEGIN

   DECLARE @BaseRate  DECIMAL(18,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
   DECLARE @RoomPrice DECIMAL(18,2) 
   DECLARE @totalPrice DECIMAL(18,2)
   DECLARE @roomType NVARCHAR(20)
   DECLARE @roomBeds INT

   DECLARE @roomId INT = (SELECT TOP(1)r.Id FROM Rooms AS r
							       JOIN Hotels AS h ON r.HotelId = h.Id
								   JOIN Trips AS t ON r.Id = t.RoomId
								   WHERE @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
								   AND t.CancelDate IS NULL
								   AND h.Id = @HotelId
								   AND r.Beds >= @People
						 )

						    IF @roomId IS NOT NULL
    BEGIN 
	SET @RoomPrice  = (SELECT Price FROM Rooms AS r
								       WHERE Id = @roomId) 
    SET @roomType = (SELECT Type FROM Rooms WHERE Id = @roomId)
	SET @roomBeds = (SELECT Beds FROM Rooms WHERE Id = @roomId)
	--
	SET @totalPrice =  (@BaseRate + @RoomPrice) * @People
	RETURN CONCAT('Room ',@roomId,': ',@roomType,' ','(Beds ',@roomBeds,') - $',@totalPrice)
	END
----------------------------------------------------------------------------------
      IF @roomId IS NULL
   BEGIN
  SET @roomId = (SELECT TOP(1)k.Id FROM
				(SELECT r.Id AS Id,MAX((@BaseRate + r.Price) * @People) AS maxpr FROM Rooms AS r
							       JOIN Hotels AS h ON r.HotelId = h.Id
								   JOIN Trips AS t ON r.Id = t.RoomId
								   WHERE
								    @Date NOT  BETWEEN t.ArrivalDate AND t.ReturnDate
								   AND t.CancelDate IS NULL
								   AND h.Id = @HotelId
								   AND r.Beds >= @People
								   GROUP BY r.Id
								   
								   ) AS k
								   ORDER BY k.maxpr DESC)
    IF @roomId IS NULL
	RETURN 'No rooms available';

    SET @RoomPrice = (SELECT  Price FROM Rooms
								       WHERE Id = @roomId) 
    SET @roomType = (SELECT Type FROM Rooms WHERE Id = @roomId)
	SET @roomBeds = (SELECT Beds FROM Rooms WHERE Id = @roomId)
	
	SET @totalPrice =  (@BaseRate + @RoomPrice) * @People;
	RETURN CONCAT('Room ',@roomId,': ',@roomType,' ','(Beds ',@roomBeds,') - $',@totalPrice)
   END
   -----------------------------------------------------------------------------------------


   RETURN '';
   

  END
GO

SELECT * FROM Rooms AS r
JOIN Trips AS t ON r.Id = t.RoomId
WHERE r.HotelId = 94

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
----Create a user defined stored procedure, named usp_SwitchRoom(@TripId, @TargetRoomId),
--that receives a trip and a target room, and attempts to move the trip to the target room.
--A room will only be switched if all of these conditions are true:
--•	If the target room ID is in a different hotel, than the trip is in,
--raise an exception with the message “Target room is in another hotel!”.
--•	If the target room doesn’t have enough beds for all the trip’s accounts,
--raise an exception with the message “Not enough beds in target room!”.
--If all the above conditions pass, change the trip’s room ID to the target room ID.

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
 DECLARE @targetHotel INT = 
 ( SELECT  HotelId FROM Rooms
 WHERE Id = @TargetRoomId
 )

 DECLARE @HotelId INT = 
 (
 SELECT h.Id FROM Hotels AS h
 JOIN Rooms AS r ON h.Id = r.HotelId
 JOIN Trips AS t ON t.RoomId = r.Id
 WHERE t.Id = @TripId
 )

 IF @HotelId != @targetHotel
THROW 50001,'Target room is in another hotel!',1;

DECLARE @tourists INT =
(
SELECT COUNT(*) FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
WHERE t.Id = @TripId
)
DECLARE @beds INT = 
(
SELECT Beds FROM Rooms
WHERE @TargetRoomId = Id
)
 IF @beds < @tourists
THROW 50002,'Not enough beds in target room!',1;

UPDATE Trips
SET   RoomId = @TargetRoomId
WHERE Id = @TripId



EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10



	  EXEC usp_SwitchRoom 10, 7
	  

EXEC usp_SwitchRoom 10, 8


