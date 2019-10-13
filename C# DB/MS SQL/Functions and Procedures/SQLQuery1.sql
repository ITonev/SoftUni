USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE Salary > 35000

GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @Number

GO

CREATE PROC usp_GetTownsStartingWith (@Parameter NVARCHAR(10)) 
AS
	SELECT [Name] As Town
	FROM Towns
	WHERE [Name] LIKE @Parameter + '%'

GO

CREATE PROC usp_GetEmployeesFromTown (@TownName NVARCHAR(30))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID=a.TownID
	WHERE t.[Name] = @TownName

GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
AS
	BEGIN
	DECLARE @salaryLevel VARCHAR(20)
		IF(@salary < 30000)
		BEGIN
			SET @salaryLevel = 'Low'
		END
		ELSE IF(@salary >= 30000 AND @salary <= 50000)
		BEGIN
			SET @salaryLevel = 'Average'
		END
		ELSE 
		BEGIN
			SET @salaryLevel = 'High'
		END
	RETURN @salaryLevel
END

GO

CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel NVARCHAR(10))
AS
	SELECT FirstName, LastName 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

GO

EXEC usp_EmployeesBySalaryLevel 'high'

GO

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Counter INT = 1
	DECLARE @currentLetter NVARCHAR(1)
	
	WHILE(@Counter <= LEN(@word))
	  BEGIN
	    SET @currentLetter = SUBSTRING(@word, @Counter, 1)
		
		DECLARE @CharIndex INT = CHARINDEX(@currentLetter, @setOfLetters)
		
		IF (@CharIndex <= 0)
		BEGIN
		  RETURN 0
		END
	    SET @Counter += 1	
	  END

	RETURN 1
END

GO

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
			SELECT EmployeeID 
			FROM Employees 
			WHERE DepartmentID=@departmentId
			)
	
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
			SELECT EmployeeID 
			FROM Employees 
			WHERE DepartmentID=@departmentId
			)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID=@departmentId

	DELETE FROM Departments
	WHERE DepartmentID=@departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID=@departmentId
END

GO

USE Bank

GO

CREATE PROC usp_GetHoldersFullName 
AS
	SELECT FirstName + ' ' + LastName AS [Full Name] 
	FROM AccountHolders

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
	SELECT a.FirstName, a.LastName
	FROM AccountHolders AS a
	JOIN Accounts AS ac ON a.Id = ac.AccountHolderId
	GROUP BY a.FirstName, a.LastName
	HAVING SUM(ac.Balance) >= @number
	ORDER BY a.FirstName, a.LastName 	

GO

EXEC usp_GetHoldersWithBalanceHigherThan 50000

GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @YearlyInterestRate, @NumberOfYears))
END

GO

CREATE PROC usp_CalculateFutureValueForAccount (@AccountID INT, @InterestRate DECIMAL(18,4))
AS
BEGIN
	SELECT a.Id AS [Account Id], 
		   a.FirstName, 
		   a.LastName, 
		   ac.Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue (ac.Balance, @InterestRate, 5) AS [Balance in 5 years] 
	FROM AccountHolders AS a
	JOIN Accounts AS ac ON ac.Id=a.Id
	WHERE a.Id=@AccountID
END

GO

USE Diablo

GO

CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(30))
RETURNS TABLE
AS
	RETURN
	 SELECT SUM(asd.Cash) AS SumCash
		FROM 
	(
	   SELECT 
			g.[Name], 
		    u.Cash,
			ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY u.Cash DESC) AS [Row]
	   FROM UsersGames AS u
	   JOIN Games AS g ON g.Id = u.GameId
	   WHERE g.Name = @GameName
	   ) AS asd
	   WHERE asd.[Row] % 2 <> 0

GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

GO

CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum DECIMAL(15, 2),
	NewSum DECIMAL(15, 2)
)

GO

CREATE TRIGGER tr_NewTrigger ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @newSum DECIMAL(15, 2) = (SELECT i.[Balance] FROM [INSERTED] AS i)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT d.[Balance] FROM [DELETED] AS d)
	DECLARE @accountId INT = (SELECT i.[Id] FROM [INSERTED] AS i)

	INSERT INTO Logs(AccountId,OldSum,NewSum) VALUES
	(@accountId, @oldSum,@newSum)
END

GO

CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Recipient INT,
	[Subject] VARCHAR(500),
	Body VARCHAR(500)
)

GO

CREATE TRIGGER tr_NewEmail ON Logs FOR INSERT
AS
BEGIN
	DECLARE @Recipient INT = (SELECT i.AccountId FROM inserted AS i)
	DECLARE @Subject VARCHAR(500) = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(30))
	DECLARE @Body VARCHAR(500) = 'On ' + CAST(GETDATE() AS NVARCHAR(30)) + ' your balance was changed from ' + CAST((SELECT i.OldSum FROM inserted AS i) AS VARCHAR(10)) + ' to ' + CAST((SELECT i.NewSum FROM inserted AS i) AS VARCHAR(10)) + '.'
	
	INSERT INTO NotificationEmails (Recipient,[Subject],Body) VALUES
	(@Recipient,@Subject,@Body)
END

GO

UPDATE Accounts SET Balance = 666 WHERE Id = 2

GO

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	IF(@MoneyAmount <0)
	BEGIN
		ROLLBACK
		RAISERROR('Money should be positive number', 16,1)
		RETURN
	END

	UPDATE Accounts
	   SET Balance +=@MoneyAmount
	 WHERE Id = @AccountId
COMMIT

GO

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
BEGIN
	DECLARE @targetSender INT = (SELECT Id FROM [dbo].[Accounts] AS a WHERE a.[Id] = @SenderId)
	DECLARE @targetReciver INT = (SELECT Id FROM [dbo].[Accounts] AS a WHERE a.[Id] = @ReceiverId)
	
	IF(@targetReciver IS NULL OR @targetSender IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid Id Parameter', 16, 1)
		RETURN
	END
	
	IF(@Amount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid amount of money', 16, 2)
		RETURN
	END
	
	EXEC dbo.usp_WithdrawMoney @targetSender, @Amount
	EXEC dbo.usp_DepositMoney @targetReciver, @Amount
END

GO

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @projects INT = (SELECT COUNT([ep].[ProjectID])
                           FROM [dbo].[Employees] AS e
						   JOIN [dbo].[EmployeesProjects] AS [ep] ON [e].[EmployeeID] = [ep].[EmployeeID]
						  WHERE [e].[EmployeeID] = @emloyeeId)

IF(@projects >= 3)
BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!', 16, 1)
	RETURN
END

INSERT INTO [dbo].[EmployeesProjects]
(
    [EmployeeID],
    [ProjectID]
)
VALUES
(
    @emloyeeId,
    @projectID
)

COMMIT





























































































































