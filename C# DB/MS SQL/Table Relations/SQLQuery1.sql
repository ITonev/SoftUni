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

















































































