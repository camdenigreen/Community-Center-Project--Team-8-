CREATE OR ALTER PROCEDURE Person.UpdateInformation
   @PersonId INT OUTPUT,
   @Address NVARCHAR(100),
   @FirstName NVARCHAR(50),
   @LastName NVARCHAR(50),
   @PhoneNumber NVARCHAR(20)
AS

UPDATE People.People
SET 
	[Address]=@Address,
	FirstName=@FirstName,
	LastName=@LastName,
	PhoneNumber=@PhoneNumber

WHERE PersonID=@PersonId;
SET @PersonID =SCOPE_IDENTITY();


GO