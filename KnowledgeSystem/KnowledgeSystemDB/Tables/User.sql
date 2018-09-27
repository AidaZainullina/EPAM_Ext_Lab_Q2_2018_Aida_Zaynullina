﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(100) NOT NULL, 
    [Password] NCHAR(100) NOT NULL, 
    [Role] INT NOT NULL FOREIGN KEY([Id]) REFERENCES Role (Id),
    [Email] NCHAR(100) NOT NULL
)
