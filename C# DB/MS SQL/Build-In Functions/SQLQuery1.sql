SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName
  FROM Employees
 WHERE DepartmentID IN (3,10) 
       AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

SELECT FirstName,
	   LastName	
  FROM Employees
 WHERE JobTitle NOT LIKE '%engineer%'

  SELECT [Name] 
    FROM Towns
   WHERE LEN([Name])=5 OR LEN([Name])=6
ORDER BY [Name]

 SELECT TownID,
	    [Name]
   FROM Towns
  WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
 SELECT FirstName,
		LastName
   FROM Employees
  WHERE YEAR(HireDate) > 2000

  SELECT FirstName,
		 LastName
    FROM Employees
   WHERE LEN(LastName) = 5
   
   SELECT EmployeeID,
		  FirstName,
		  LastName,
		  Salary,
		  [Rank]
	 FROM 
	 ( SELECT *, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank] FROM Employees
		WHERE (Salary BETWEEN 10000 AND 50000)
	 ) AS a
	 WHERE a.[Rank] = 2
	 ORDER BY Salary DESC

USE [Geography]

  SELECT CountryName,
 		 IsoCode
    FROM Countries
   WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

SELECT * FROM CountriesRivers
INNER JOIN Rivers

USE Diablo

  SELECT TOP(50) [Name],
		 FORMAT([Start], 'yyy-MM-dd') AS [Start] 
    FROM Games
   WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

  SELECT Username,
         SUBSTRING(Email, CHARINDEX('@', Email)+1, (LEN(Email)-CHARINDEX('@', Email))) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], Username

  SELECT Username,
  	     IpAddress
    FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

  SELECT [Name],
	  CASE
	   WHEN DATEPART(hour,[Start]) >= 0 AND DATEPART(hour,[Start]) < 12 THEN 'Morning'
	   WHEN DATEPART(hour,[Start]) >= 12 AND DATEPART(hour,[Start]) < 18 THEN 'Afternoon'
	   ELSE 'Evening'
	   END AS [Part of the Day],
	  CASE 
	  WHEN Duration <= 3 THEN 'Extra Short'
	  WHEN Duration >=4 AND Duration <= 6 THEN 'Short'
	  WHEN Duration >= 7 THEN 'Long'
	  ELSE 'Extra Long'
	  END AS Duration
    FROM Games
ORDER BY [Name], Duration

  SELECT ProductName, 
         OrderDate, 
		 DATEADD(DAY, 3, OrderDate) AS [Pay Due],
		 DATEADD(MONTH, 1, OrderDate) AS [Deliver Due] 
    FROM Orders;

