IF OBJECT_ID(N'People.PeopleGroups') IS NULL
BEGIN
    CREATE TABLE [People].PeopleGroups
    (
        PersonID INT NOT NULL FOREIGN KEY REFERENCES People.People(PersonID),
        GroupID INT NOT NULL FOREIGN KEY REFERENCES People.Groups(GroupID),

        CONSTRAINT PK_People_Groups_PersonID_GroupID PRIMARY KEY
        (
            PersonID,
            GroupID
        )
    )
END