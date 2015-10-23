CREATE PROCEDURE spLastDislocation
AS
	SELECT 
		carDB.CarNumber,
		carDB.OperationStation,
		carDB.Weight
	FROM CarDB carDB
RETURN 0