CREATE OR ALTER PROCEDURE RetrieveGroups

AS 

SELECT G.Name,G.Description
FROM People.Groups G;

GO;
