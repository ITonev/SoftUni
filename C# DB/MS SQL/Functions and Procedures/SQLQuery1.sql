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

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @YearlyInterestRate DECIMAL(10,4), @NumberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
DECLARE @result DECIMAL (18,4)
	RETURN @sum * POWER(@sum + @YearlyInterestRate, @NumberOfYears)
END

GO
EXEC ufn_CalculateFutureValue 1000, 0.1, 5






















































































































































