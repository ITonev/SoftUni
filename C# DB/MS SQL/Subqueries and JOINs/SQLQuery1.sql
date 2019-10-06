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

SELECT e.EmployeeID, 
       e.FirstName,
	   CASE 
	      WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		  ELSE p.[Name]
       END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS em ON e.EmployeeID=em.EmployeeID
AND e.EmployeeID = 24
JOIN Projects AS p ON p.ProjectID=em.ProjectID

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName
FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3, 7)

SELECT  TOP 50
        e.EmployeeID, 
		CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
		CONCAT(em.FirstName, ' ', em.LastName) AS ManagerName, 
		d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT MIN(es.Salaries) AS MinAverageSalary 
FROM (SELECT e.DepartmentID, AVG(e.Salary) AS Salaries
FROM Employees AS e
GROUP BY e.DepartmentID) AS es 

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId=m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC

SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Mountains AS m ON m.Id=mc.MountainId
GROUP BY mc.CountryCode
HAVING mc.CountryCode IN ('US', 'RU', 'BG')

SELECT TOP 5 c.CountryName, r.RiverName 
FROM Countries AS c
FULL JOIN CountriesRivers AS co ON c.CountryCode = co.CountryCode
FULL JOIN Rivers as r ON r.Id=co.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName 

SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CountryName) AS somet
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode

SELECT COUNT(c.CountryName) AS [Count]
FROM Countries AS c
FULL JOIN MountainsCountries AS m ON c.CountryCode=m.CountryCode WHERE m.MountainId IS NULL

SELECT TOP 5 c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.[Length]) AS LongestRiverLength 
FROM Countries AS c
FULL JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
FULL JOIN Mountains AS m ON m.Id = mc.MountainId
FULL JOIN Peaks AS p ON p.MountainId = m.Id
FULL JOIN CountriesRivers AS cr ON cr.CountryCode=c.CountryCode
FULL JOIN Rivers AS r ON r.Id=cr.RiverId
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.[Length]) DESC, c.CountryName 












































































