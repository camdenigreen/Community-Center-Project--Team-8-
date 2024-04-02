/*
CREATE SCHEMA [People] AUTHORIZATION [dbo];
GO

CREATE SCHEMA [Events] AUTHORIZATION [dbo];
GO
*/

DROP TABLE IF EXISTS People.PeopleGroups;
DROP TABLE IF EXISTS [Events].EventAttendance;
DROP TABLE IF EXISTS [Events].[Events];
DROP TABLE IF EXISTS People.Payments;
DROP TABLE IF EXISTS People.Charges;
DROP TABLE IF EXISTS People.People;
DROP TABLE IF EXISTS People.Groups;

DROP TABLE IF EXISTS People.PeopleGroups

CREATE TABLE People.PeopleGroups(
    PersonID INT NOT NULL FOREIGN KEY REFERENCES People.People(PersonID),
    GroupID INT NOT NULL FOREIGN KEY REFERENCES People.Groups(GroupID),
    CONSTRAINT PK_People_Groups PRIMARY KEY (PersonID, GroupID)
)

DROP TABLE IF EXISTS [Events].EventAttendance

CREATE TABLE [Events].EventAttendance(
    PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
    EventID INT FOREIGN KEY REFERENCES [Events].[Events](EventID) NOT NULL,
    DidAttend BIT NOT NULL,
    CONSTRAINT PK_Event_Attendance PRIMARY KEY (PersonID, EventID)
)

DROP TABLE IF EXISTS People.Payments

CREATE TABLE People.Payments(
    PaymentID INT PRIMARY KEY,
    PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
    Amount MONEY NOT NULL,
    Reason NVARCHAR(MAX),
    [Date] DATETIME2(7) NOT NULL,
)

DROP TABLE IF EXISTS People.Charges

CREATE TABLE People.Charges(
    PaymentID INT PRIMARY KEY,
    PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
    EventID INT FOREIGN KEY REFERENCES [Events].[Events](EventID),
    Amount MONEY NOT NULL,
    Reason NVARCHAR(MAX),
    [Date] DATETIME2(7) NOT NULL,
)

DROP TABLE IF EXISTS [Events].[Events]

CREATE TABLE [Events].[Events](
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    Organizer NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    [Date] DATETIME2(7) NOT NULL,
    [Description] NVARCHAR(MAX),
    GroupID INT FOREIGN KEY REFERENCES  People.Groups(GroupID) NOT NULL,
    Charge MONEY NOT NULL,
)

DROP TABLE IF EXISTS People.People

CREATE TABLE People.People(
    PersonID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(256) NOT NULL,
    PhoneNumber NVARCHAR(20) NULL,
    IsMember BIT NOT NULL,
)

DROP TABLE IF EXISTS People.Groups

CREATE TABLE People.Groups(
    GroupID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) UNIQUE NOT NULL,
    [Description] NVARCHAR(MAX),
)