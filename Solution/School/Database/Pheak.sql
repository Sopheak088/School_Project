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
CREATE TABLE tbSubject(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Name NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	
	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_SUBJECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_SUBJECT
GO
 CREATE PROCEDURE [dbo].[INSERT_SUBJECT](
								@Id UNIQUEIDENTIFIER,
								@Name NVARCHAR(255),
								@CreatedBy NVARCHAR(255),
								@CreatedDate DATETIME
							  )
AS 
BEGIN
	INSERT INTO [dbo].[tbSubject] (
	   [ID]
      ,[Name]
      ,[CreatedBy]
      ,[CreatedDate]
	)
	VALUES(@Id,@Name,@CreatedBy,@CreatedDate)
END
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_SUBJECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_SUBJECT
GO
 CREATE PROCEDURE [dbo].[UPDATE_SUBJECT](
								@Id UNIQUEIDENTIFIER,
								@Name NVARCHAR(255),
								@UpdatedBy NVARCHAR(255),
								@UpdatedDate DATETIME
							  )
AS 
BEGIN
	UPDATE [dbo].[tbSubject] 
		SET Name = @Name,
		UpdatedBy=@UpdatedBy,
		UpdatedDate= @UpdatedDate
		WHERE ID=@Id
END
GO
CREATE TABLE tbTeacher(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	SubjectID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_SUBJECT_FK FOREIGN KEY(SubjectID)REFERENCES [tbSubject](ID),
   Name NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
   Gender NVARCHAR(10) COLLATE Khmer_100_BIN NOT NULL,
   Phone NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
   Active BIT DEFAULT 1,
	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_TEACHER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_TEACHER
GO
 CREATE PROCEDURE [dbo].[INSERT_TEACHER](
								@Id UNIQUEIDENTIFIER,
								@SubjectID NVARCHAR(255),
								@Name NVARCHAR(255),
								@Gender NVARCHAR(255),
								@Phone NVARCHAR(255),
								@Active BIT,
								@CreatedBy NVARCHAR(255),
								@CreatedDate DATETIME
							  )
AS 
BEGIN
	INSERT INTO [dbo].[tbTeacher] (
	   [ID]
	,[SubjectID]
      ,[Name]
      ,[Gender]
      ,[Phone]
      ,[Active]
      ,[CreatedBy]
      ,[CreatedDate]
		)
	VALUES(@Id,@SubjectID,@Name,@Gender,@Phone,@Active,@CreatedBy,@CreatedDate)
END
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_TEACHER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_TEACHER
GO
 CREATE PROCEDURE [dbo].[UPDATE_TEACHER](
								@Id UNIQUEIDENTIFIER,
								@SubjectID NVARCHAR(255),
								@Name NVARCHAR(255),
								@Gender NVARCHAR(255),
								@Phone NVARCHAR(255),
								@Active BIT,
								@UpdatedBy NVARCHAR(255),
								@UpdatedDate DATETIME
							  )
AS 
BEGIN
	UPDATE [dbo].[tbTeacher] SET 
		[SubjectID] = @SubjectID
      ,[Name] = @Name
      ,[Gender] = @Gender
      ,[Phone] = @Phone
      ,[Active] = @Active
      ,[UpdatedBy] = @UpdatedBy
      ,[UpdatedDate] = @UpdatedDate
	  WHERE ID=@Id
END
