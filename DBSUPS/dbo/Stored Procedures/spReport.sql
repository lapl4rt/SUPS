CREATE PROCEDURE [dbo].[spReport]

AS

WITH Car AS
(
  SELECT *, rowNumber = ROW_NUMBER() OVER (
			ORDER BY CarNumber, 
			Month(OperationTime),
			DAY(OperationTime),
			DatePart(HOUR,OperationTime),
			DatePart(MINUTE, OperationTime)
			)
  FROM CarDB
)

SELECT 
	Car.CarNumber as CarNumber, 
	Load.OperationTime as LoadTime,
	Unload.OperationTime as UnLoadTime,
	Depart.OperationTime as DepartTime,
	Arrive.OperationTime as ArriveTime 
FROM Car 

LEFT OUTER JOIN Car AS Load ON 
	Car.rowNumber = Load.rowNumber + 1 AND 
	Car.Weight > Load.Weight AND 
	Car.CarNumber = Load.CarNumber

LEFT OUTER JOIN Car as Unload ON 
	Car.rowNumber = Unload.rowNumber + 1 AND 
	Car.Weight < Unload.Weight AND 
	Car.CarNumber = Unload.CarNumber

LEFT OUTER JOIN Car as Depart ON 
	Car.rowNumber = Depart.rowNumber + 1 AND 
	Car.OperationStation <> Depart.OperationStation AND 
	Car.CarNumber = Depart.CarNumber AND 
	Depart.OperationTime IN (
		SELECT MIN(OperationTime) 
		FROM Car WHERE CarNumber = Depart.CarNumber
		)

LEFT OUTER JOIN Car as Arrive ON 
	Car.rowNumber = Arrive.rowNumber + 1 AND 
	Arrive.OperationStation = Depart.DepartStation AND 
	Car.CarNumber = Arrive.CarNumber
	WHERE load.Weight IS NOT NULL OR 
	Unload.Weight IS NOT NULL
	ORDER BY Car.CarNumber