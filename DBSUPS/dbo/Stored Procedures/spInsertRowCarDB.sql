CREATE PROCEDURE spInsertRowCarDB
	@carNumber nvarchar(8),
	@weight nvarchar(3),
	@arriveStation nvarchar(7),
	@cargoCode nchar(5),
	@receiverCode nvarchar(13),
	@carType nvarchar(13),
	@departStation nvarchar(7),
	@operationCode nchar(2),
	@operationDate nvarchar(13),
	@operationYear nvarchar(13),
	@operationTime nvarchar(13),
	@operationStation nvarchar(7),
	@deliveryRoad nvarchar(13),
	@receiptRoad nvarchar(13),
	@trainIndex nvarchar(13),
	@trainNumber nvarchar(13)
AS
	INSERT INTO CarDB
	(CarNumber, Weight, ArriveStation, CargoCode, ReceiverCode, CarType, DepartStation, OperationCode, 
	OperationDate, OperationYear, OperationTime, OperationStation, DeliveryRoad, ReceiptRoad, TrainIndex, 
	TrainNumber) 
	VALUES (@carNumber, @weight, @arriveStation, @cargoCode, @receiverCode, @carType, @departStation, 
	@operationCode, @operationDate, @operationYear, @operationTime, @operationStation, @deliveryRoad, 
	@receiptRoad, @trainIndex, @trainNumber)
RETURN 0