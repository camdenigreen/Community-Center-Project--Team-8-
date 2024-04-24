CREATE OR ALTER PROCEDURE RetrieveAllMembers
	@PersonID INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@PhoneNumber NVARCHAR(20)
AS

	SELECT P.PersonId, P.FirstName, P.LastName, P.[Address]
	FROM People.People AS P
	WHERE IsMember=1 ;

GO