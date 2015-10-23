create view Dislocations as
select Cargo.Name as CargoName, CarNumber, Weight, ReceiverCode, CarType, 
CarOperation.Name as OperationName,arrStation.Name as ArriveStation, opStation.Name as OperationStationName,
depStation.Name as DepartStation, OperationDate, OperationYear, OperationTime,
delRoad.Name as DeliveryRoad, recRoad.Name as ReceiptRoad, TrainIndex, TrainNumber

from CarDB 
inner join Cargo on Cardb.CargoCode = Cargo.ShortCode
inner join CarOperation on (CarDB.OperationCode = CarOperation.Code and 
						CarDB.OperationType = CarOperation.OperationType)
inner join Station arrStation on CarDB.ArriveStation = arrStation.Code
inner join Station opStation on CarDB.OperationStation = opStation.Code
inner join Station depStation on CarDB.DepartStation = depStation.Code
inner join Road delRoad on CarDB.DeliveryRoad = delRoad.Code
inner join Road recRoad on CarDB.ReceiptRoad = recRoad.Code
