CREATE TABLE Clients(
ID INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
)

CREATE TABLE AccountTypes(
ID INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Accounts(
ID INT PRIMARY KEY IDENTITY(1,1),
AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
Balance DECIMAL(15,2) NOT NULL DEFAULT(0),
ClientId INT FOREIGN KEY REFERENCES Clients(ID)
)

INSERT INTO Clients(FirstName, LastName) VALUES
('Gosho', 'Ivanov'),
('Pesho', 'Petrov'),
('Ivan', 'Iliev'),
('Merry', 'Ivanova')

INSERT INTO AccountTypes(Name) VALUES
('Checking'),
('Savings')

INSERT INTO Accounts(ClientId, AccountTypeId, Balance) VALUES
(1, 1, 175),
(2, 1, 275.56),
(3, 1, 138.01),
(4, 1, 40.30),
(4, 2, 375.50)

GO
CREATE FUNCTION f_CalculateTotalBalance (@ClientID INT)
RETURNS DECIMAL(15, 2)
BEGIN
	DECLARE @result AS DECIMAL(15, 2) = (
	SELECT SUM(Balance)
	FROM Accounts WHERE ClientId = @ClientId
	)
RETURN @result
END
GO

SELECT dbo.f_CalculateTotalBalance(1) AS Balance

