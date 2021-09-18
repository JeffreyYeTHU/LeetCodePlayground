--
-- @lc app=leetcode.cn id=181 lang=mysql
--
-- [181] 超过经理收入的员工
--
-- @lc code=start
# Write your MySQL query statement below
/* SELECT a.Name AS Employee
 FROM Employee AS a
 JOIN Employee AS b ON a.ManagerId = b.Id
 AND a.Salary > b.Salary; */
SELECT a.Name AS Employee
FROM Employee AS a,
    Employee AS b
WHERE a.ManagerId = b.Id
    AND a.Salary > b.Salary;
-- @lc code=end