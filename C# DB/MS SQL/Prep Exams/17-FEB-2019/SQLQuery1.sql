CREATE DATABASE School

USE School

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CHECK(Age>0),
[Address] NVARCHAR(50),
Phone VARCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL CHECK(Lessons>0)
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL CHECK(Grade >= 2 AND Grade <=6)
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME2,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL CHECK(Grade >= 2 AND Grade <=6),
CONSTRAINT pk_StudentExam
PRIMARY KEY (StudentId, ExamId) 
)

CREATE TABLE Teachers (
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone VARCHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
CONSTRAINT pk_StudentTeacher
PRIMARY KEY(StudentId, TeacherId)
)

  
INSERT INTO Teachers (FirstName,LastName,[Address],Phone,SubjectId) VALUES
(
    'Ruthanne',
    'Bamb',
    '84948 Mesta Junction',
    '3105500146',
    6
),
(
    'Gerrard',
    'Lowin',
    '370 Talisman Plaza',
    '3324874824',
    2
),
(
    'Merrile',
    'Lambdin',
    '81 Dahle Plaza',
    '4373065154',
    5
),
(
    'Bert',
    'Ivie',
    '2 Gateway Circle',
    '4409584510',
    4
);

INSERT INTO Subjects ([Name], Lessons) VALUES
('Geometry',12),
('Health',10),
('Drama', 7),
('Sports', 9)

UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN (1,2) AND Grade>=5.50

DELETE FROM StudentsTeachers
WHERE TeacherId IN (
				SELECT Id 
				FROM Teachers 
				WHERE Phone LIKE '%72%'
				)

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

SELECT FirstName, LastName, Age 
FROM Students
WHERE Age >=12
ORDER BY FirstName, LastName

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId=s.Id
JOIN Teachers AS t ON st.TeacherId=t.Id
GROUP BY s.FirstName, s.LastName

SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name] 
FROM Students AS s
LEFT OUTER JOIN StudentsExams AS se ON se.StudentId=s.Id
LEFT OUTER JOIN Exams AS e ON se.ExamId=e.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

SELECT TOP(10) s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(15,2)) AS Grade 
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId=s.Id
--JOIN Exams AS e ON se.ExamId=e.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

SELECT 
	 CASE
		WHEN s.MiddleName IS NULL THEN CONCAT(s.FirstName, ' ', s.LastName)
        ELSE CONCAT(s.FirstName, ' ', s.MiddleName, ' ', s.LastName) 
		END	AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id=ss.StudentId
LEFT JOIN Subjects AS su ON su.Id=ss.SubjectId
WHERE su.Id IS NULL
ORDER BY [Full Name]

SELECT sss.[Name], 
	   sss.AverageGrade 
FROM (
	SELECT su.[Name], AVG(ss.Grade) AS AverageGrade, su.Id  
	FROM Students AS s
	JOIN StudentsSubjects AS ss ON ss.StudentId=s.Id
	JOIN Subjects AS su ON su.Id=ss.SubjectId
	GROUP BY su.[Name], su.Id) AS sss
ORDER BY sss.Id

GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Count INT = (SELECT COUNT(*) FROM Students AS s
	JOIN StudentsExams AS se ON se.StudentId=s.Id
	WHERE s.Id=@studentId AND se.Grade >= @grade AND se.Grade <= (@grade+0.50))
	
	DECLARE @StudentIdExist INT = (SELECT Id FROM Students WHERE Id = @studentId)
	DECLARE @StudentName VARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)
	
	IF(@StudentIdExist IS NULL)
	   BEGIN
	   RETURN 'The student with provided id does not exist in the school!'
	   END

	IF(@grade > 6.00)
	BEGIN
	   RETURN 'Grade cannot be above 6.00!'
	   END
	  
  RETURN 'You have to update ' + CAST(@Count AS VARCHAR(30)) + ' grades for the student ' + @StudentName 
END

GO

CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
 BEGIN
	DECLARE @StudentIdExist INT = (SELECT Id FROM Students WHERE Id = @studentId)

	IF(@StudentIdExist IS NULL)
	  BEGIN
	   RAISERROR('This school has no student with the provided id!', 16,1)
	  END

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
	
 END
