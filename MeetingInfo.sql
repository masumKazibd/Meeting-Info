CREATE DATABASE MeetingInfo
GO

USE MeetingInfo
GO

--------Corporate_Custoer_Tbl
CREATE TABLE Corporate_Custoer_Tbl
(
Corporate_Custoer_Id INT PRIMARY KEY IDENTITY,
Corporate_Custoer_Name NVARCHAR(50)
)
GO
INSERT INTO Corporate_Custoer_Tbl VALUES 
('Masum Kazi'),
('Jahidul Hasan'),
('Nayeem Kazi'),
('Tahamina Akter'),
('Ayesha Begum'),
('Mahedi Hasan'),
('Shahriar Emon'),
('Tanvir Hossain'),
('Hannan Kazi')
GO

SELECT * FROM Corporate_Custoer_Tbl
GO
--------Individual_Customer_Tbl
CREATE TABLE Individual_Customer_Tbl
(
Individual_Customer_Id INT PRIMARY KEY IDENTITY,
Individual_Customer_Name NVARCHAR(50)
)
GO

INSERT INTO Individual_Customer_Tbl VALUES
('Mahmuda Munni'),
('Ashik BIllah'),
('Rayhan Firoz'),
('Yeasin Ahmed'),
('Rakibul Islam'),
('Ibrahim Sazib'),
('Mahmud Mahim'),
('Razzak Rayhan'),
('Khairuzzaman')
GO

SELECT * FROM Individual_Customer_Tbl
GO

--------Products_Service_Tbl
CREATE TABLE Products_Service_Tbl
(
Products_Service_Id INT PRIMARY KEY IDENTITY,
Products_Service_Name NVARCHAR(50),
Unit NVARCHAR(25)
)
GO

INSERT INTO Products_Service_Tbl VALUES 
('ERP Software', '1 pcs'),
('School Managements','1 pcs' ),
('University Management','1 pcs'),
('Monitor','1 pcs'),
('CPU','1 pcs'),
('MotherBoard','1 pcs'),
('Keyboard','1 pcs'),
('Mobile','1 pcs'),
('HardDisk','1 pcs')
GO

SELECT * FROM Products_Service_Tbl
GO

--------Meeting_Minutes_Master_Tbl
CREATE TABLE Meeting_Minutes_Master_Tbl
(
	Meeting_Minutes_Master_ID INT PRIMARY KEY IDENTITY,
	CustomerName NVARCHAR(50) NOT NULL,
	[Date] DATE,
	[Time] TIME,
	MeetingPlace NVARCHAR(50) NOT NULL,
	AttendsFromClientSide NVARCHAR(100) NOT NULL,
	AttendsFromHostSide NVARCHAR(100) NOT NULL,
	MeetingAgenda NVARCHAR(100) NOT NULL,
	MeetingDiscussion NVARCHAR(100) NOT NULL,
	MeetingDecision NVARCHAR(100) NOT NULL
)
GO
CREATE  PROC Meeting_Minutes_Master_Save_SP @CustomerName NVARCHAR(50),
											@Date DATE,
											@Time TIME,
											@MeetingPlace NVARCHAR(50),
											@AttendsFromClientSide NVARCHAR(100),
											@AttendsFromHostSide NVARCHAR(100),
											@MeetingAgenda NVARCHAR(100),
											@MeetingDiscussion NVARCHAR(100),
											@MeetingDecision NVARCHAR(100)
AS
BEGIN
	INSERT INTO Meeting_Minutes_Master_Tbl(
									CustomerName, 
									[Date], 
									[Time], 
									MeetingPlace,
									AttendsFromClientSide,
									AttendsFromHostSide, 
									MeetingAgenda,
									MeetingDiscussion, 
									MeetingDecision
									)
	VALUES (@CustomerName, 
	@Date, 
	@Time, 
	@MeetingPlace, 
	@AttendsFromClientSide,
	@AttendsFromHostSide,
	@MeetingAgenda, 
	@MeetingDiscussion, 
	@MeetingDecision)
END
GO
--------Testing Meeting_Minutes_Master_Save_SP
EXEC Meeting_Minutes_Master_Save_SP 
	'Example Customer', 
	'2023-11-29', 
	'12:30', 
	'Conference Room A', 
	'John Doe, Jane Smith', 
	'Host User', 
	'Agenda item 1, Agenda item 2', 
	'Discussed various topics', 
	'Decision on item 1'
GO
SELECT * FROM Meeting_Minutes_Master_Tbl
GO

-----Meeting_Minutes_Details_Tbl’ using stored procedure ‘Meeting_Minutes _Details_Save_SP’. 
CREATE TABLE Meeting_Minutes_Details_Tbl
(
Meeting_Minutes_Details_Id INT PRIMARY KEY IDENTITY,
Products_Service_Name NVARCHAR(50),
Unit NVARCHAR(25),
Quantity FLOAT
)
GO
----Meeting_Minutes _Details_Save_SP
CREATE  PROC Meeting_Minutes_Details_Save_SP  @Products_Service_Name NVARCHAR(50),
											@Unit NVARCHAR(25),
											@Quantity FLOAT
AS
BEGIN
	INSERT INTO Meeting_Minutes_Details_Tbl (
											Products_Service_Name,
											Unit,
											Quantity
											)
	VALUES (
			@Products_Service_Name,
			@Unit,
			@Quantity
			)
END
