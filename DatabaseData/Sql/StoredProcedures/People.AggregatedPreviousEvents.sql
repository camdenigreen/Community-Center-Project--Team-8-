CREATE OR ALTER PROCEDURE People.AggregatedPreviousEvents
AS

DECLARE @CurrentDate DATE
SET @CurrentDate = GETDATE();

WITH EventTotalCte(EventID, Name, [Date], EventMonth,EventYear,Registrants,Attendees,AttendanceRatio )AS 
    (
    SELECT E.EventID, E.Name, E.Date,MONTH(E.Date),YEAR(E.Date),COUNT(EA.PersonID),(
    SELECT COUNT(EA1.PersonID)
    FROM [Events]. EventAttendance EA1
    WHERE EA1.DidAttend=1
    AND E.EventID = EA1.EventID
    )  AS Attendees,(
    CAST((SELECT COUNT(EA2.PersonID)
    FROM [Events].EventAttendance EA2
    WHERE EA2.DidAttend=1
    AND E.EventID = EA2.EventID) AS float)/ CAST((SELECT COUNT(EA2.PersonID) FROM [Events].EventAttendance EA2 WHERE E.EventID = EA2.EventID) AS float)
    ) AS AttendanceRatio 
    FROM [Events].[Events] E
    JOIN [Events].EventAttendance EA ON E.EventID=EA.EventID
    WHERE E.Date <= @CurrentDate
    GROUP BY E.EventID,E.Date,MONTH(E.Date),YEAR(E.Date),E.Name
    
    ) 
SELECT ET.EventID, ET.Name, ET.Date, ET.Registrants, ET.Attendees, ET.AttendanceRatio,
    SUM(ET.Registrants) OVER(
        PARTITION BY ET.EventYear,ET.EventMonth
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdRegistrants,
    SUM(ET.Attendees) OVER(
        PARTITION BY ET.EventMonth, ET.EventYear
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdAttendees,
    CAST(SUM(ET.Attendees) OVER(
        PARTITION BY ET.EventMonth, ET.EventYear
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS float)
        / CAST(SUM(ET.Registrants) OVER(
        PARTITION BY ET.EventYear,ET.EventMonth
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS float) AS MtdAttendanceRatio
FROM EventTotalCte ET
GROUP BY ET.Name, ET.EventID, ET.Date, ET.Registrants, ET.Attendees, ET.AttendanceRatio, ET.EventYear, ET.EventMonth
ORDER BY ET.Date ASC;

GO
