CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [TestId] INT NOT NULL,
		constraint [FK_Question_Test] foreign key (TestId) references Test (Id), 
    [Text] NCHAR(1000) NULL
)
