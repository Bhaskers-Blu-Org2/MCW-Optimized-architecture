
IF(NOT EXISTS(
SELECT 1
FROM sys.tables t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'dbo' AND t.name = 'Transaction'
))
	BEGIN
	CREATE TABLE [dbo].[Transaction]
	(
		[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
		[DateTime] DATETIME NOT NULL,
		[Description] NVARCHAR(255) NOT NULL,
		[Amount] FLOAT NOT NULL,
		[Balance] FLOAT NOT NULL
	)

	PRINT '[Transaction] Table Created'
END
ELSE
BEGIN
	PRINT '[Transaction] Table Already Exists'
END
