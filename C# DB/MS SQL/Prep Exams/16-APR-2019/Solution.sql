CREATE DATABASE Airport

USE Airport

CREATE TABLE Planes (
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights (
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME2,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL,
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(18,2) NOT NULL
)

INSERT INTO Planes([Name],Seats,[Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369',231,2355),
('Stelt 297',254, 2143),
('Boeing 338',165, 5111),
('Airbus 558',387, 1342),
('Boeing 128',345, 5541)

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

SELECT * FROM Flights AS f
JOIN Tickets AS t ON t.FlightId = f.Id
WHERE f.Destination = 'Carlsbad'
UPDATE Tickets SET Price *=1.13


DELETE FROM Tickets 
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination='Ayn Halagim')
DELETE FROM Flights
WHERE Destination='Ayn Halagim'

SELECT * 
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range] 

SELECT FlightId, SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId 

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
       f.Origin,
	   f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id=t.PassengerId
JOIN Flights AS f ON t.FlightId=f.Id
ORDER BY [Full Name], f.Origin, f.Destination 

SELECT p.FirstName, p.LastName, p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId=p.Id
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName, p.LastName 

SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
	   pl.[Name] AS [Plane Name],
	   CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
	   lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON p.Id=t.PassengerId
JOIN Flights AS f ON f.Id=t.FlightId
JOIN Planes AS pl ON pl.Id=f.PlaneId
JOIN Luggages AS l ON l.Id=t.LuggageId
JOIN LuggageTypes AS lt ON l.LuggageTypeId=lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, lt.[Type]

SELECT p.[Name],
       p.Seats,
	   COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId=p.Id
LEFT JOIN Tickets AS T ON t.FlightId = f.Id
GROUP BY p.[Name], p.Seats
ORDER BY COUNT(t.Id) DESC, p.[Name], p.Seats 

GO

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(30), @destination VARCHAR(30), @peopleCount INT) 
RETURNS VARCHAR(30)
AS 
BEGIN
	IF(@peopleCount<=0)
	  BEGIN
		RETURN 'Invalid people count!'
	  END

  DECLARE @flightChecker INT = (SELECT TOP(1) Id 
							    FROM Flights 
								WHERE Origin=@origin AND Destination=@destination)
	
	IF(@flightChecker IS NULL)
	  BEGIN
	    RETURN 'Invalid flight!'
	  END

	DECLARE @totalSum DECIMAL(18, 2) = (SELECT TOP(1) t.Price 
								       FROM Tickets AS t
									   JOIN Flights AS f ON t.FlightId=f.Id
									   WHERE f.Origin=@origin AND f.Destination=@destination) * @peopleCount		
	  
	  RETURN 'Total price ' + CAST(@totalSum AS VARCHAR(30))
END

GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

GO

CREATE PROC usp_CancelFlights
AS
BEGIN
SELECT * FROM Flights
WHERE ArrivalTime>DepartureTime
	UPDATE Flights
	SET ArrivalTime = NULL, DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime
END

GO















































































