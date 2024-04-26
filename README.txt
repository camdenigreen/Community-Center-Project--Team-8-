This is a visual studio WPF project, open with the .sln file.

RebuildDatabase.ps1 is the script to create the database, insert the data, store procedures etc.
But it's and unsigned script so you may need to change the execution policy to run it.


Table creation files are located in:
DatabaseData\Sql\Tables

Data for the tables located in:
DatabaseData\Sql\Data

Stored Procedures located in:
DatabaseData\Sql\StoredProcedures

DatabaseData has models and repositories for bridging between SQL and C#
DataAccess has Data delegates 
Community-Center-Project--Team-8- Has the GUI and determines when to run queries
