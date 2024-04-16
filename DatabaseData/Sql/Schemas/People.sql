IF NOT EXISTS
   (
      SELECT *
      FROM sys.schemas s
      WHERE s.[name] = N'People'
   )
BEGIN
   EXEC(N'CREATE SCHEMA [People] AUTHORIZATION [dbo]');
END;