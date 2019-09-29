Use Gringotts

SELECT COUNT(*) as [Count]
FROM WizzardDeposits AS w

SELECT MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w

SELECT w.DepositGroup,
MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits w
GROUP BY w.DepositGroup

SELECT TOP(2) w.DepositGroup
FROM WizzardDeposits w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize) 

SELECT w.DepositGroup,
SUM(w.DepositAmount)
FROM WizzardDeposits w
GROUP BY w.DepositGroup

SELECT w.DepositGroup,
SUM(w.DepositAmount)
FROM WizzardDeposits w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup

SELECT w.DepositGroup,
SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount) < 150000 
ORDER BY TotalSum DESC

SELECT w.DepositGroup,
	   w.MagicWandCreator,
       MIN(w.DepositCharge) as MinDepositCharge
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup, w.MagicWandCreator
ORDER BY w.MagicWandCreator, w.DepositGroup

 SELECT w.AgeGroup,
        COUNT(*) AS WizzardCount
 FROM
(SELECT 
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]' 
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]' 
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]' 
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]' 
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]' 
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS w
GROUP BY w.AgeGroup

SELECT LEFT(w.FirstName, 1) AS FirstLetter 
FROM WizzardDeposits w
WHERE w.DepositGroup = 'Troll Chest'
GROUP BY LEFT(w.FirstName, 1)
ORDER BY FirstLetter


SELECT w.DepositGroup,
	   w.IsDepositExpired,
       AVG(w.DepositInterest) AS AverageInterest
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '01/01/1985'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC

SELECT SUM(Diff.Deposits) AS SumDifference 
FROM 
	(SELECT FirstName AS [Host Wizzard],
    (DepositAmount - (SELECT wd.DepositAmount FROM WizzardDeposits AS wd WHERE w.Id+1 = wd.Id)) AS Deposits
FROM WizzardDeposits AS w) AS Diff


USE SoftUni

SELECT e.DepartmentID,
       SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT e.DepartmentID,
       MIN(e.Salary) AS MinimumSalary
FROM Employees AS e
WHERE e.DepartmentID IN (2,5,7) AND e.HireDate > '01/01/2000'
GROUP BY e.DepartmentID

SELECT *
INTO NewTestTable
FROM Employees AS e
WHERE e.Salary > 30000
DELETE FROM NewTestTable 
WHERE NewTestTable.ManagerID=42
UPDATE NewTestTable
SET Salary+=5000
WHERE NewTestTable.DepartmentID=1
SELECT n.DepartmentID,
       AVG(n.Salary) AS AverageSalary
FROM NewTestTable AS n
GROUP BY n.DepartmentID

SELECT e.DepartmentID,
       MAX(e.Salary) AS MaxSalary
FROM Employees AS e
GROUP BY e.DepartmentID
HAVING MAX(e.Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(*) AS Count
FROM Employees AS e
WHERE e.ManagerID IS NULL

SELECT DepartmentID, Salary AS [ThirdHighestSalary] 
FROM 
	(SELECT DepartmentID, Salary,
	 DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY SALARY DESC) AS [Rank]
     FROM Employees) AS [RankingTable]
WHERE [Rank] = 3
GROUP BY DepartmentID, Salary

SELECT TOP(10) e.FirstName,
       e.LastName,
	   e.DepartmentID
FROM Employees AS e
WHERE e.Salary > (SELECT AVG(em.Salary) FROM Employees AS em WHERE em.DepartmentID=e.DepartmentID)
ORDER BY e.DepartmentID






































































































