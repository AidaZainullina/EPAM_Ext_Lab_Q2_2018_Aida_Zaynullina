CREATE TABLE [User]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [UserName] NCHAR(100) NULL, 
    [UserPassword] NCHAR(100) NOT NULL, 
    [UserRole] INT NULL,
    [UserEmail] NCHAR(100) NOT NULL
)
