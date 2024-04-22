CREATE OR ALTER PROCEDURE [Events].InsertEventAttendance
	@PersonID INT,
	@EventID INT,
	@DidAttend INT,
	@Amount MONEY,
	@EventAttendanceID INT OUTPUT
AS

INSERT [Events].EventAttendance(PersonID, EventID, DidAttend)
VALUES(@PersonID, @EventID, @DidAttend);

INSERT People.Charges(PersonID, EventID, Amount, Reason, [Date])
SELECT @PersonID,@EventID,@Amount,E.Name, GETDATE()
FROM [Events].[Event] E 
WHERE E.EventID=@EventID


SET @EventAttendanceID=SCOPE_IDENTITY();

GO
