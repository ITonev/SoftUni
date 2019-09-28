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




