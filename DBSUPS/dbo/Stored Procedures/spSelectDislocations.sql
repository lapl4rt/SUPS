CREATE PROCEDURE spSelectDislocations
AS
	SELECT TOP 10 * FROM HistoryDislocations
RETURN 0