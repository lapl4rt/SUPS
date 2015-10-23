CREATE PROCEDURE spUpdateCargoGuide
(
	@Cargo_ID int,
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
	UPDATE Cargo 
	SET Name=@Name, 
	    Image=@Image, 
		Description=@Description,
        ShortCode=@ShortCode, 
		Code=@Code, 
		CodeGNG=@CodeGNG, 
		Mnemocode=@Mnemocode,
        IsUsed=@IsUsed, 
		IsEmpty=@IsEmpty 
	WHERE Cargo_ID=@Cargo_ID
RETURN 0