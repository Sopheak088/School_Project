Create Database SCHOOL On (Name = DBNOTICE, FileName = "E:\School_Project\SCHOOL\SCHOOL.mdf",
Size = 5MB,MaxSize = Unlimited, FileGrowth = 2MB)
Log On (Name = DBNOTICE_log, FileName = "E:\School_Project\SCHOOL\SCHOOL_log.ldf",
Size = 4MB, MaxSize = Unlimited, FileGrowth =10%)
Go
CREATE TABLE tbStudent
(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	StudentID NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	FullName NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	Gender NVARCHAR(10) COLLATE Khmer_100_BIN NOT NULL,
	BirthDate DATETIME NOT NULL,
	BirthPlace NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	FatherName 	NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	FatherJob NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	MotherName NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	MotherJob NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	CurrentPlace NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	Contact NVARCHAR (255) COLLATE Khmer_100_BIN NOT NULL,
	Photo VARBINARY(MAX) NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
CREATE TABLE tbClass(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Name NVARCHAR(255) COLLATE khmer_100_BIN NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
CREATE TABLE tbStudentDetail(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	StudentID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_STUDENT_FK FOREIGN KEY(StudentID)REFERENCES [tbStudent](ID),
	ClassID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_CLASS_FK FOREIGN KEY(ClassID)REFERENCES [tbClass](ID),
	StudentFrom NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
CREATE TABLE tbSubject(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Name NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	
	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
CREATE TABLE tbTeacher(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	SubjectID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_SUBJECT_FK FOREIGN KEY(SubjectID)REFERENCES [tbSubject](ID),
   Name NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
   Gender NVARCHAR(10) COLLATE Khmer_100_BIN NOT NULL,
   Phone NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
   
	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO
CREATE TABLE tbAttendance(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	StudentDetailID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_STUDENTDETAIL_FK FOREIGN KEY(StudentDetailID)REFERENCES [tbStudentDetail](ID),
   SubjectID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_SUBJECT_FK FOREIGN KEY(SubjectID)REFERENCES [tbSubject](ID),
   AttendanceDate DATETIME NOT NULL,
   [Absent] INT NULL,
   Permission INT NULL,

   	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL

)
GO
CREATE TABLE tbScore(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	ScoreType NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	ScoreDate DATETIME NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL

)
GO
CREATE TABLE tbScoreDetail(
	ID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	ScoreID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_SCORE_FK FOREIGN KEY(ScoreID)REFERENCES [tbScore](ID),
   StudentDetailID UNIQUEIDENTIFIER,
   CONSTRAINT Type_PK_STUDENTDETAIL_FK FOREIGN KEY(StudentDetailID)REFERENCES [tbStudentDetail](ID),
   KHMER FLOAT NOT NULL,
   I FLOAT NOT NULL,
   History FLOAT NOT NULL,
   [Geography] FLOAT NOT NULL,
   Math FLOAT NOT NULL,
   Physic FLOAT NOT NULL,
   Chemistry FLOAT NOT NULL,
   Biology FLOAT NOT NULL,
   Earth FLOAT NOT NULL,
   English FLOAT NOT NULL,
   ICT FLOAT NOT NULL,
	HomeEd FLOAT NOT NULL,
   ArtEd FLOAT NOT NULL,
   SportEd FLOAT NOT NULL,
   Agriculture FLOAT NOT NULL,

	CreatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NOT NULL,
	CreatedDate DATETIME NULL,
	UpdatedBy NVARCHAR(255) COLLATE Khmer_100_BIN NULL,
	UpdatedDate DATETIME NULL
)
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_STUDENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_STUDENT
GO
CREATE PROCEDURE INSERT_STUDENT( 
								@Id	UNIQUEIDENTIFIER,
								@StudentID NVARCHAR(255),
								@FullName NVARCHAR(255),
								@Gender NVARCHAR(10),
								@BirthDate DATETIME,
								@BirthPlace NVARCHAR(255),
								@FatherName NVARCHAR(255),
								@FatherJob NVARCHAR(255),
								@MotherName NVARCHAR(255),
								@MotherJob NVARCHAR(255),
								@CurrentPlace NVARCHAR(255),
								@Contact NVARCHAR(255),
								@Photo VARBINARY(MAX),
								@CreatedBy NVARCHAR(255),
								@CreatedDate DATETIME
								)
AS
BEGIN
	INSERT INTO tbStudent(
			[ID],
			[StudentID],
			[FullName],
			[Gender],
			[BirthDate],
			[BirthPlace],
			[FatherName],
			[FatherJob],
			[MotherName],
			[MotherJob],
			[CurrentPlace],
			[Contact],
			[Photo],
			[CreatedBy],
			[CreatedDate])
		VALUES (@Id,@StudentID,@FullName,@Gender,@BirthDate,@BirthPlace,@FatherName,@FatherJob,@MotherName,@MotherJob,@CurrentPlace,@Contact,@Photo,@CreatedBy,@CreatedDate)
END
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_STUDENT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_STUDENT
GO
CREATE PROCEDURE UPDATE_STUDENT( 
								@Id	UNIQUEIDENTIFIER,
								@StudentID NVARCHAR(255),
								@FullName NVARCHAR(255),
								@Gender NVARCHAR(10),
								@BirthDate DATETIME,
								@BirthPlace NVARCHAR(255),
								@FatherName NVARCHAR(255),
								@FatherJob NVARCHAR(255),
								@MotherName NVARCHAR(255),
								@MotherJob NVARCHAR(255),
								@CurrentPlace NVARCHAR(255),
								@Contact NVARCHAR(255),
								@Photo VARBINARY(MAX),
								@CreatedBy NVARCHAR(255),
								@CreatedDate DATETIME
								)
AS
BEGIN
	UPDATE tbStudent SET 
			[StudentID] = @StudentID
			,[FullName] = @FullName
			,[Gender] = @Gender
			,[BirthDate] = @BirthDate
			,[BirthPlace] = @BirthPlace
			,[FatherName] = @FatherName
			,[FatherJob] = @FatherJob
			,[MotherName] = @MotherName
			,[MotherJob] = @MotherJob
			,[CurrentPlace] = @CurrentPlace
			,[Contact] = @Contact
			,[Photo] = @Photo
			,[CreatedBy] = @CreatedBy
			,[CreatedDate] = @CreatedDate
			WHERE [ID] = @Id
END

/*tbClASS*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_CLASS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_CLASS
GO
CREATE PROCEDURE INSERT_CLASS(
								@Id UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
							)
					AS 
					BEGIN
					INSERT INTO tbClass(
							[ID]
							,[Name]
							,[CreatedBy]
							,[CreatedDate]
						)
						VALUES (@Id, @Name,@CreatedBy,@CreatedDate)
END
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_CLASS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_CLASS
GO
CREATE PROCEDURE UPDATE_CLASS(
								@Id UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
							)
					AS 
					BEGIN
					UPDATE tbClass SET
							[Name] = @Name
							,[CreatedBy] = @CreatedBy
							,[CreatedDate] = @CreatedDate 
						WHERE [ID] = @Id
END
GO
/*tbSubject*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_SUBJECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_SUBJECT
GO
CREATE PROCEDURE INSERT_SUBJECT(
								@Id	UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
								)
					AS 
					BEGIN
					INSERT INTO tbSubject(
							[ID]
							,[Name]
							,[CreatedBy]
							,[CreatedDate]
						)
						VALUES (@Id, @Name,@CreatedBy,@CreatedDate)
END
Go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_SUBJECT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_SUBJECT
GO
CREATE PROCEDURE UPDATE_SUBJECT(
								@Id UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
							)
					AS 
					BEGIN
					UPDATE tbClass SET
							[Name] = @Name
							,[CreatedBy] = @CreatedBy
							,[CreatedDate] = @CreatedDate 
						WHERE [ID] = @Id
END
GO
/*tbTeacher*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[INSERT_TEACHER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].INSERT_TEACHER
GO
CREATE PROCEDURE INSERT_TEACHER(
								@Id	UNIQUEIDENTIFIER
								,@SubjectId UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@Gender NVARCHAR(255)
								,@Phone NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
								)
					AS 
					BEGIN
					INSERT INTO tbTeacher(
							[ID]
							,[SubjectID]
							,[Name]
							,[Gender]
							,[Phone]
							,[CreatedBy]
							,[CreatedDate]
						)
						VALUES (@Id,@SubjectId, @Name, @Gender,@Phone,@CreatedBy,@CreatedDate)
END
Go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPDATE_TEACHER]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].UPDATE_TEACHER
GO
CREATE PROCEDURE UPDATE_TEACHER(
								@Id	UNIQUEIDENTIFIER
								,@SubjectId UNIQUEIDENTIFIER
								,@Name NVARCHAR(255)
								,@Gender NVARCHAR(255)
								,@Phone NVARCHAR(255)
								,@CreatedBy NVARCHAR(255)
								,@CreatedDate DATETIME
								)
					AS 
					BEGIN
					UPDATE tbTeacher SET
							
							[SubjectID] = @SubjectId
							,[Name] = @Name
							,[Gender] =  @Gender
							,[Phone] = @Phone
							,[CreatedBy] = @CreatedBy
							,[CreatedDate] = @CreatedDate
						WHERE [ID] = @Id
END