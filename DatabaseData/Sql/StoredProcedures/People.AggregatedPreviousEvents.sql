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
    WHERE E.Date <= GETDATE()
    GROUP BY E.EventID,E.Date,MONTH(E.Date),YEAR(E.Date),E.Name
    
    ) 
SELECT ET.EventID, ET.Name,CONVERT(date, ET.Date) AS Date , ET.Registrants, ET.Attendees, ROUND(ET.AttendanceRatio,2) AS AttendanceRatio,
    SUM(ET.Registrants) OVER(
        PARTITION BY ET.EventYear,ET.EventMonth
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdRegistrants,
    SUM(ET.Attendees) OVER(
        PARTITION BY ET.EventMonth
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdAttendees,
     ROUND((SUM(ET.AttendanceRatio)   OVER(
        PARTITION BY ET.EventMonth 
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)
        / COUNT(*) OVER(
        PARTITION BY ET.EventMonth 
        ORDER BY ET.Date
        ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)),2) AS MtdAttendanceRatio
FROM EventTotalCte ET
GROUP BY ET.Name, ET.EventID, ET.Date, ET.Registrants, ET.Attendees, ET.AttendanceRatio, ET.EventYear, ET.EventMonth
ORDER BY ET.Date ASC;






GO
