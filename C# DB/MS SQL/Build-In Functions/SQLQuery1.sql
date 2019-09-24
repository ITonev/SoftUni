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



