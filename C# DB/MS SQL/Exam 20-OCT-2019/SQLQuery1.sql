CREATE DATABASE [Service]

USE [Service]

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME2,
Age INT CHECK(Age>=14 AND Age <=110),
Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME2,
Age INT CHECK(Age >=18 AND Age <= 110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) 
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL 
)

CREATE TABLE [Status](
Id INT PRIMARY KEY IDENTITY,
Label VARCHAR(30) NOT NULL 
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME2 NOT NULL,
CloseDate DATETIME2,
[Description] VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

INSERT INTO Employees (FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId) VALUES
(1,1,'2017-04-13', NULL, 'Stuck Road on Str.133', 6,2),
(6,3, '2015-09-05', '2015-12-06', 'Charity trail running', 3,5),
(14,2,'2015-09-07', NULL, 'Falling bricks on Str.58', 5,2),
(4,3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1,1)

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

DELETE FROM Reports
WHERE StatusId = 4

SELECT [Description], 
       CONVERT(VARCHAR, OpenDate, 105) AS Dates  
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description] 

SELECT r.[Description],
       c.[Name]
FROM Reports AS r
JOIN Categories AS c ON c.Id=r.CategoryId
ORDER BY r.[Description], c.[Name] 

SELECT TOP(5) c.[Name], COUNT(*) AS ReportsNumber
FROM Reports AS r 
JOIN Categories AS c ON c.Id=r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name]

SELECT u.Username, c.[Name] 
FROM Reports AS r
JOIN Users AS u ON r.UserId=u.Id
JOIN Categories AS c ON r.CategoryId=c.Id
WHERE DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate) 
  AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)  
ORDER BY u.Username, c.[Name]

SELECT * FROM Employees

SELECT * FROM Users

SELECT CONCAT(secondTable.FirstName, ' ', secondTable.LastName) AS [FullName], 
	   secondTable.UsersCount  
FROM (
			SELECT e.FirstName, e.LastName, COUNT(u.Username) AS [UsersCount] 
			FROM Reports AS r
			FULL JOIN Employees AS e ON r.EmployeeId=e.Id
			FULL JOIN Users AS u ON r.UserId=u.Id
			WHERE e.FirstName IS NOT NULL AND e.LastName IS NOT NULL
			GROUP BY e.FirstName, e.LastName ) AS secondTable
ORDER BY secondTable.UsersCount DESC, FullName

SELECT 
       CASE WHEN LEN(CONCAT(e.FirstName,' ', e.LastName)) <2 THEN 'None'
	   Else CONCAT(e.FirstName,' ', e.LastName)
	   END AS [Employee],
       ISNULL(d.[Name], 'None') AS [Department],
	   ISNULL(c.[Name], 'None') AS [Category],
	   ISNULL(r.[Description], 'None') AS [Description],
	   CONVERT(VARCHAR, r.OpenDate, 104) AS OpenDate,
	   ISNULL(s.Label, 'None') AS [Status],
	   ISNULL(u.[Name], 'None') AS [User] 
FROM Reports AS r
FULL JOIN Employees AS e ON e.Id=r.EmployeeId
FULL JOIN Users AS u ON u.Id=r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
FULL JOIN Departments AS d ON d.Id = e.DepartmentId
JOIN [Status] AS s ON s.Id = r.StatusId
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.[Description], OpenDate, [Status], [User] 

GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL)
	  BEGIN
	   RETURN 0
	  END

	IF(@EndDate IS NULL)
	  BEGIN
	   RETURN 0
	  END
   DECLARE @Datediff INT = DATEDIFF(hour, @StartDate, @EndDate)

   RETURN @Datediff
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

SELECT OpenDate, CloseDate FROM Reports

GO

CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
   DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE @EmployeeId=Id)
   DECLARE @ReportDepartmentId INT = (SELECT c.DepartmentId 
										FROM Reports AS r
										JOIN Categories AS c ON r.CategoryId=c.Id
										WHERE @ReportId = r.Id)
	
	IF (@EmployeeDepartmentId <> @ReportDepartmentId)
	  BEGIN
	       RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	  END

	IF (@EmployeeDepartmentId = @ReportDepartmentId)
		BEGIN
		  UPDATE Reports
		  SET EmployeeId=@EmployeeId
		  WHERE Id=@ReportId
		END
END





















































