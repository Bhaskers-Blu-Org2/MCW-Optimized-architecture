
IF (NOT EXISTS(SELECT 1 FROM [dbo].[Transaction]))
BEGIN
	-- Prepopulate with a starting Balance
	DECLARE @dt DATETIME = GETUTCDATE()
	EXEC	[dbo].[InsertTransaction]
			@datetime = @dt,
			@description = N'Opening Balance',
			@amount = 1250000
END