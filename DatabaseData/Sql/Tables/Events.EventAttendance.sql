if OBJECT_ID(N'Events.EventAttendance') IS NULL
BEGIN
    CREATE TABLE [Events].EventAttendance
    (
        PersonID INT FOREIGN KEY REFERENCES People.People(PersonID) NOT NULL,
        EventID INT FOREIGN KEY REFERENCES [Events].[Events](EventID) NOT NULL,
        DidAttend BIT NULL,

        CONSTRAINT PK_Event_Attendance PRIMARY KEY 
        (
            PersonID,
            EventID
        )
    )
END