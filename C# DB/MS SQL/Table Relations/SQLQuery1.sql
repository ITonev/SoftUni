CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName NVARCHAR(30),
Salary DECIMAL(15,2),
PassportID INT
)

CREATE TABLE Passports(
PassportID INT,
PassportNumber NVARCHAR(20)
PRIMARY KEY(PassportID)
)

INSERT INTO Persons(PersonID,FirstName,Salary,PassportID) VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)


INSERT INTO Passports (PassportID,PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons
PRIMARY KEY(PersonID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passport
FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)

CREATE TABLE Models(
ModelID INT NOT NULL,
[Name] VARCHAR(30),
ManufacturerID INT NOT NULL
CONSTRAINT PK_Models
PRIMARY KEY(ModelID)
)

INSERT INTO Models(ModelID,[Name],ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

CREATE TABLE Manufacturers(
ManufacturerID INT NOT NULL,
[Name] VARCHAR(30),
EstablishedOn DATE,
CONSTRAINT PK_Manufacturers
PRIMARY KEY(ManufacturerID)
)

INSERT INTO Manufacturers(ManufacturerID,Name,EstablishedOn) VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manifacturer
FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

SELECT m.Name, ma.Name, ma.EstablishedOn 
FROM Models AS m
JOIN Manufacturers AS ma 
ON m.ManufacturerID=ma.ManufacturerID







































































