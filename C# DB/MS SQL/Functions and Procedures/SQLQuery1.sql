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














































































































































































