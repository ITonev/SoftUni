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
        COUNT(w.AgeGroup) AS WizzardCount
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

SELECT DISTINCT LEFT(w.FirstName, 1) AS FirstLetter 
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





























































































































