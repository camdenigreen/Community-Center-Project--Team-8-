CREATE OR ALTER PROCEDURE RetrieveAllMembers

AS
SELECT PersonId,FirstName,LastName,[Address]
FROM People.People
WHERE IsMember=1;

GO