CREATE TABLE [dbo].[Test]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [Duration] DATETIME NOT NULL, 
    [Questions] NCHAR(100) NULL foreign key ([Id]) References Questions ([Id])
)
