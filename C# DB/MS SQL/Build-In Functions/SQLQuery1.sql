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


