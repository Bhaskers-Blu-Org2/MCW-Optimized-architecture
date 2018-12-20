IF(EXISTS(
SELECT 1
FROM sys.procedures t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE s.name = 'dbo' AND t.name = 'InsertTransaction'
))
	BEGIN
		DROP PROCEDURE [dbo].[InsertTransaction]
	END
