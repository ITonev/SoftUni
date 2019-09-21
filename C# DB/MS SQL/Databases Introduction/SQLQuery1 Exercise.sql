CREATE DATABASE Minions

CREATE TABLE Minions(
Id INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50)
)

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT PK_MinionTownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId) VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)

SELECT [Id], [Name], [Age], [TownId] FROM Minions

TRUNCATE TABLE Minions

DROP TABLE Towns

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(200) NOT NULL,
Picture IMAGE,
Height DECIMAL(3,2),
[Weight] DECIMAL(6,2),
Gender CHAR(1) CHECK(Gender='m' OR Gender='f') NOT NULL,
BirthDay date NOT NULL,
Biography NVARCHAR(MAX)
);

INSERT INTO People([Name], Picture, Height, [Weight], Gender, BirthDay, Biography) VALUES
('Ivan', NULL, 1.85, 81.2, 'm', '1986-02-20', 'I was born in a poor family'),
('Gosho', NULL, 2.102, 105.36, 'm', '2001/02/23', NULL),
('Mitko', NULL, 2.012, 68.236, 'm', '1996/02/11', 'I was ones been...'),
('Sashka', NULL, 1.369, 12.2365, 'f', '1996/06/03', NULL),
('Minka', NULL, 1.596, 56.231, 'f', '1996/09/15', 'Az sam Minka');


CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY(1,1),
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture)<= 921600),
LastLogInTime DATETIME2,
IsDeleted BIT  
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLogInTime, IsDeleted) VALUES
('Ivan', 'Ivanchooo', 75998, '1986-02-20 17:25:15', 0),
('Pesho', 'Ivanchooo', 741, NULL, 0),
('Mitko', 'Ivanchooo', NULL, '1986-02-20 17:25:15', 1),
('Stancho', 'Ivanchooo', 1024, NULL, 0),
('Vancho', 'Ivanchooo', NULL, '1986-02-20 17:25:15', 1)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC079E2DC79C

ALTER TABLE Users
ADD CONSTRAINT PK_IdAndUserName PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordLenght CHECK(LEN([Password])>=5)

ALTER TABLE Users
ADD CONSTRAINT DF_DefaultLogInTime DEFAULT GETDATE() FOR LastLogInTime

INSERT INTO Users(Username, [Password], ProfilePicture, IsDeleted) VALUES
('Pen', 'Goshko', NULL, 0)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK_IdAndUserName

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UC_UserNameLenght CHECK(LEN(UserName)>=3)

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY(1,1),
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY(1,1),
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT,
[Length] NVARCHAR(30),
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors([DirectorName], [Notes])
VALUES('Pesho', NULL),
('Gosho', 'Test * 23'),
('Ivan', NULL),
('Orlando', 'Once upon a time'),
('Penka', 'Penka for the win');

INSERT INTO Genres([GenreName], [Notes])
VALUES('Comedy', NULL),
('Epic', NULL),
('Fantasy', NULL),
('Porno', NULL),
('Drama', NULL);

INSERT INTO Categories([CategoryName], [Notes])
VALUES('Comedy', NULL),
('Action', NULL),
('Serial', NULL),
('Social', NULL),
('Nature', NULL);

INSERT INTO Movies([DirectorId], [Title], CopyrightYear, [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES (3,'Hankok', 2015, 569, 4, 5, 99, NULL),
(1, 'Fast 5', 1955, 785, 3, 4, 77, NULL),
(2, 'Fast 6', 1990, 56, 1, 2, 19, NULL),
(4, 'Slow 1', 1986, 985, 2, 1, 4, NULL),
(5, 'BestOne', 2001, 256, 2, 3, -20, 'The best movie of them all');

CREATE DATABASE CarRental

Use CarRental

CREATE TABLE Categories(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[CategoryName] VARCHAR(20) NOT NULL,
[DailyRate] INT,
[WeeklyRate] INT,
[MonthlyRate] INT,
[WeekendRate] INT
);

INSERT INTO Categories([CategoryName])
VALUES('OF-Road'),
('Speed'),
('Drag Race');

CREATE TABLE Cars(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[PlateNumber] INT NOT NULL,
[Manufacturer] VARCHAR(20) NOT NULL, 
[Model] VARCHAR(20), 
[CarYear] INT NOT NULL,
[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
[Doors] INT NOT NULL,
[Picture] IMAGE,
[Condition] VARCHAR(100),
[Available] VARCHAR(5) NOT NULL CHECK([Available] = 'Yes' Or [Available] = 'No')
);

INSERT INTO Cars([PlateNumber], [Manufacturer], [CarYear], [CategoryId], [Doors], [Available])
VALUES(20, 'Pesho', 1999, 2, 5, 'Yes'),
(30, 'Pesho2', 2001, 1, 3, 'No'),
(40, 'Peshoy', 2018, 3, 2, 'Yes');

CREATE TABLE Employees(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[Title] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName])
VALUES('Pesho', 'Peshov'),
('Gosho', 'Penev'),
('Mario', 'Manchev');

CREATE TABLE Customers(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[DriverLicenceNumber] INT NOT NULL,
[FullName] VARCHAR(100) NOT NULL, 
[Address] VARCHAR(30),
[City] VARCHAR(20), 
[ZIPCode] INT,
[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([DriverLicenceNumber], [FullName])
VALUES(123562, 'Aleks Penev'),
(2560, 'Toma Tomov'),
(236549, 'Milen Malov');

CREATE TABLE RentalOrders(
[Id]INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
[CustomerId]  INT FOREIGN KEY REFERENCES Customers([Id]) NOT NULL,
[CarId]  INT FOREIGN KEY REFERENCES Cars([Id]) NOT NULL, 
[TankLevel] INT, 
[KilometrageStart] INT NOT NULL, 
[KilometrageEnd] INT, 
[TotalKilometrage] INT,
[StartDate] DATETIME,
[EndDate] DATETIME, 
[TotalDays] INT, 
[RateApplied] INT, 
[TaxRate] INT, 
[OrderStatus] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO RentalOrders([EmployeeId], [CustomerId], [CarId], [KilometrageStart])
VALUES(2, 1, 3, 1253620),
(1, 2, 3, 1236322036),
(3, 3, 1, 1523692);

CREATE DATABASE Hotel;
USE Hotel;

CREATE TABLE Employees(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
[FirstName] VARCHAR(20) NOT NULL, 
[LastName] VARCHAR(20) NOT NULL, 
[Title] VARCHAR(20), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName])
VALUES('Peshp', 'Penev'),
('Milen', 'Markov'),
('Filip', 'Maskov');

CREATE TABLE Customers(
[AccountNumber] INT PRIMARY KEY NOT NULL, 
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL, 
[PhoneNumber] VARCHAR(12), 
[EmergencyName] VARCHAR(20), 
[EmergencyNumber] VARCHAR(12), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([AccountNumber], [FirstName], [LastName])
VALUES(12, 'Peshp', 'Penev'),
(13, 'Milen', 'Markov'),
(14, 'Filip', 'Maskov');

CREATE TABLE RoomStatus(
[RoomStatus] VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Full' OR RoomStatus = 'Half'),
[Notes] VARCHAR(MAX)
);

INSERT INTO RoomStatus([RoomStatus])
VALUES('Free'),
('Half'),
('Full');

CREATE TABLE RoomTypes(
[RoomType] VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO RoomTypes([RoomType])
VALUES('Tripple'),
('Double'),
('Mezonet');

CREATE TABLE BedTypes(
[BedType]  VARCHAR(20) PRIMARY KEY NOT NULL,
[Notes]VARCHAR(MAX)
);

INSERT INTO BedTypes([BedType])
VALUES('Single'),
('Double'),
('Tripple');

CREATE TABLE Rooms(
[RoomNumber] INT PRIMARY KEY NOT NULL, 
[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes([RoomType]) NOT NULL,
[BedType] VARCHAR(20) FOREIGN KEY REFERENCES BedTypes([BedType]) NOT NULL,
[Rate] INT,
[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]) NOT NULL, 
[Notes] VARCHAR(MAX)
);

INSERT INTO Rooms([RoomNumber], [RoomType], [BedType], [RoomStatus])
VALUES(123, 'Tripple', 'Tripple', 'Free'),
(1254, 'Mezonet', 'Single', 'Full'),
(2563, 'Double', 'Single', 'Half');

CREATE TABLE Payments(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
[PaymentDate] DATETIME,
[AccountNumber] INT,
[FirstDateOccupied] DATETIME,
[LastDateOccupied] DATETIME,
[TotalDays] INT,
[AmountCharged] DECIMAL(15, 2),
[TaxRate] INT, 
[TaxAmount] DECIMAL(15, 2),
[PaymentTotal] DECIMAL(15, 2), 
[Notes] VARCHAR(MAX)
);

INSERT INTO Payments([EmployeeId])
VALUES(2),
(3),
(1);

CREATE TABLE Occupancies(
[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL, 
[DateOccupied] DATETIME, 
[AccountNumber] INT, 
[RoomNumber] INT, 
[RateApplied] INT, 
[PhoneCharge] INT, 
[Notes] VARCHAR(MAX)
);

INSERT INTO Occupancies([EmployeeId])
VALUES(2),
(1),
(3);

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(100) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id),
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

INSERT INTO Departments([Name]) VALUES
('Engineering'),
('Sales'),
('Software Development'),
('Quality Assurance')

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(30),
LastName NVARCHAR(30) NOT NULL,
JobTitle NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(8,2),
AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
)

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 3, '2013/01/02', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2012/01/02', 4000.00),
('Maria ', 'Petrova', 'Ivanova', 'Intern', 4, '2011/01/02', 525.25),
('Georgi ', 'Teziev', 'Ivanov', 'CEO', 2, '2000/01/02', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 1, '2018/01/02', 599.88)

SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary+=Salary*0.1

SELECT [Salary] FROM Employees

UPDATE Payments
SET TaxRate -= TaxRate * 0.03;
SELECT TaxRate FROM Payments

TRUNCATE Table Occupancies 