CREATE TABLE COMPANY
(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),			
	NameInKhmer NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	NameInEnglish NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	Email NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	Phone NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	Location NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	Active BIT NOT NULL DEFAULT 1,
	Logo VARBINARY(MAX) NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_COMPANY
GO
 CREATE PROCEDURE INSERT_COMPANY(
								@Id UNIQUEIDENTIFIER,
								@NameInKhmer NVARCHAR(255),
								@NameInEnglish NVARCHAR(255),
								@Email NVARCHAR(255),
								@Phone NVARCHAR(255),
								@Location NVARCHAR(255),
								@Active BIT,
								@Logo VARBINARY(MAX),
								@CreatedBy NVARCHAR(255),
								@CreatedDate DATETIME
							  )
AS 
BEGIN
	INSERT INTO COMPANY (
	   [ID]
      ,[NameInKhmer]
      ,[NameInEnglish]
      ,[Email]
      ,[Phone]
      ,[Location]
      ,[Active]
      ,[Logo]
      ,[CreatedBy]
      ,[CreatedDate])
	VALUES(@Id,@NameInKhmer,@NameInEnglish,@Email,@Phone,@Location,@Active,@Logo,@CreatedBy,@CreatedDate)
END
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_COMPANY]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_COMPANY
GO
 CREATE PROCEDURE UPDATE_COMPANY(
								@Id UNIQUEIDENTIFIER,
								@NameInKhmer NVARCHAR(255),
								@NameInEnglish NVARCHAR(255),
								@Email NVARCHAR(255),
								@Phone NVARCHAR(255),
								@Location NVARCHAR(255),
								@Active BIT,
								@Logo VARBINARY(MAX),
								@UpdatedBy NVARCHAR(255),
								@UpdatedDate DATETIME
							  )
AS 
BEGIN
		UPDATE COMPANY SET
		[NameInKhmer] = @NameInKhmer
      ,[NameInEnglish] = @NameInEnglish
      ,[Email] = @Email
      ,[Phone] = @Phone
      ,[Location] = @Location
      ,[Active] = @Active
      ,[Logo] = @Logo
      ,[UpdatedBy] = @UpdatedBy
      ,[UpdatedDate] = @UpdatedDate
	  WHERE ID = @Id
END
