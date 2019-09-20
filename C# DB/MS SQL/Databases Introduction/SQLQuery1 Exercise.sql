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

