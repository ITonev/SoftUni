Use SoftUni

SELECT * FROM Departments

SELECT [Name] FROM Departments

SELECT FirstName, MiddleName, LastName FROM Employees

SELECT FirstName+'.'+LastName+'@'+'softuni.bg' AS [Full Email Address] FROM Employees AS e

SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees
WHERE JobTitle='Sales Representative'


SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000 

SELECT FirstName+' '+ MiddleName+ ' '+LastName AS [Full Name] FROM Employees
WHERE Salary IN (25000,14000,12500,23600)

SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

