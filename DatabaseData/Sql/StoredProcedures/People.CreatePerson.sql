CREATE OR ALTER PROCEDURE People.CreatePerson
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Address NVARCHAR(100),
	@PhoneNumber NVARCHAR(20),
	@PersonID INT OUTPUT
AS

INSERT People.People(FirstName,LastName,[Address],PhoneNumber)
VALUES( @FirstName, @LastName, @Address, @PhoneNumber);

SET @PersonID = SCOPE_IDENTITY();

GO
