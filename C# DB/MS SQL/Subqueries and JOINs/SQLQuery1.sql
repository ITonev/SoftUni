SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID 
ORDER BY e.AddressID

SELECT TOP 50 e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
FROM Employees AS e
JOIN Departments AS d 
ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID

SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID 

SELECT TOP 3 e.EmployeeID, e.FirstName 
FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON e.EmployeeID=ep.EmployeeID
FULL JOIN Projects as p ON p.ProjectID=Ep.ProjectID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
AND d.[Name] IN ('Sales','Finance')
WHERE e.HireDate > '1.1.1999'
ORDER BY e.HireDate

SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] 
FROM Employees AS e
JOIN EmployeesProjects AS em ON e.EmployeeID=em.EmployeeID
JOIN Projects AS p ON p.ProjectID=em.ProjectID
AND p.StartDate > '20020813'
AND p.EndDate IS NULL
ORDER BY e.EmployeeID


















































































































