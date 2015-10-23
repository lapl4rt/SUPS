CREATE PROCEDURE spInsertCargoGuide (
	@Name nvarchar(100),
	@Image varbinary(max),
	@Description nvarchar(250),
	@ShortCode nchar(5),
	@Code nchar(5),
	@CodeGNG nchar(8),
	@Mnemocode nvarchar(12),
	@IsUsed Bit,
	@IsEmpty Bit
	)
AS
	INSERT INTO Cargo
	(
		Name, 
		Image,
		Description, 
		ShortCode,
		Code, 
		CodeGNG,
		Mnemocode, 
		IsUsed, 
		IsEmpty
	)
	VALUES
	(
		@Name, 
		@Image,
		@Description, 
		@ShortCode,
		@Code, 
		@CodeGNG,
		@Mnemocode, 
		@IsUsed, 
		@IsEmpty
	);

RETURN 0