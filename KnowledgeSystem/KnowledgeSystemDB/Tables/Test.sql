CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [Name] NCHAR(100) NOT NULL, 
    [Duration] DATETIME NULL, 
    [UserId] INT NULL,
		constraint [FK_Test_User] FOREIGN KEY (UserID) REFERENCES [USER] (ID), 
    [Description] NCHAR(100) NULL,
	[Score] INT NULL
)
