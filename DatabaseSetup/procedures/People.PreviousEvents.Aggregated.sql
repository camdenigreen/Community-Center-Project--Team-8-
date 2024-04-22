CREATE OR ALTER PROCEDURE People.PreviousEventsAggregated
	AS


DECLARE @CurrentDate DATE
SET @CurrentDate =GETDATE();

WITH EventTotalCte(EventID, Name, [Date], EventMonth,EventYear,Registrants,Attendees,AttendanceRatio )AS 
	(
	SELECT E.EventID, E.Name, E.Date,MONTH(E.Date),YEAR(E.Date),SUM(EA.PersonID),(
	SELECT SUM(EA1.PersonID)
	FROM [Events]. EventAttendance EA1
	WHERE EA1.DidAttend=1
	)  AS Attendees,(
	SELECT SUM(EA1.PersonID)
	FROM [Events]. EventAttendance EA1
	WHERE EA1.DidAttend=1/ (SELECT SUM(EA1.PersonID) FROM [Events]. EventAttendance EA1)
	
	)
	 AS AttendanceRatio 
	FROM [Events].[Events] E
	JOIN [Events].EventAttendance EA ON E.EventID=EA.EventID
	WHERE E.Date <=@CurrentDate
	GROUP BY E.EventID,E.Date,MONTH(E.Date),YEAR(E.Date)
	
	) 
	SELECT ET.EventID, ET.Name, ET.Date, ET.Registrants, ET.Attendees, ET.AttendanceRatio,
	SUM(ET.Registrants) OVER(
	PARTITION BY ET.EventYear,ET.EventMonth
	ORDER BY ET.EventMonth
	ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdRegistrants,
	SUM(ET.Attendees) OVER(
	PARTITION BY ET.EventYear 
	ORDER BY ET.EventYear
	ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdAttendees,
	SUM(ET.AttendanceRatio)   OVER(
	PARTITION BY ET. EventMonth 
	ORDER BY ET.EventMonth
	ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)/COUNT(*) OVER(
	PARTITION BY ET. EventMonth 
	ORDER BY ET.EventMonth
	ROWS  BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS MtdAttendanceRatio
FROM EventTotalCte ET
ORDER BY ET.Date ASC;




GO;
