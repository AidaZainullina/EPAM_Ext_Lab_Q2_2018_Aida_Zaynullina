CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TestId] INT NULL foreign key (TestId) references Test (Id), 
    [Text] NCHAR(100) NULL,
	[Success] bit 
)
