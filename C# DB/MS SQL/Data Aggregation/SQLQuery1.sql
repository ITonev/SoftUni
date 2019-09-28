Use Gringotts

SELECT COUNT(*) as [Count]
FROM WizzardDeposits AS w

SELECT MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w

SELECT w.DepositGroup,
MAX(w.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits w
GROUP BY w.DepositGroup


