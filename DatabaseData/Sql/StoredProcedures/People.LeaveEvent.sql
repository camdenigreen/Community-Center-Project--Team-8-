CREATE OR ALTER PROCEDURE People.LeaveEvent
    @PersonID INT,
    @EventID INT
AS
DELETE FROM [Events].EventAttendance
WHERE PersonID=@PersonId AND EventID=@EventId;

INSERT People.Payments(PersonID, Amount, Reason, [Date])
SELECT 1,E.Charge, E.Name + N'Refund', GETDATE()

 FROM [Events].[Events] E WHERE E.EventID=@EventID
AND DATEDIFF(day, GETDATE(), E.Date) >= 18;

GO