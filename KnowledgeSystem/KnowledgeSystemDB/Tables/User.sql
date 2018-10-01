CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(100) NOT NULL, 
    [Role] int NOT NULL,
		constraint [FK_User_Role] FOREIGN KEY([Role]) REFERENCES Role (Id),
    [Email] NVARCHAR(100) NOT NULL
)
