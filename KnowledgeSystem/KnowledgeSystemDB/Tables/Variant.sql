CREATE TABLE [dbo].[Variant]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IsRight] BIT NULL, 
    [Text] NCHAR(100) NULL, 
    [Score] INT NULL,
	[QuestionId] int foreign key (QuestionId) references dbo.Question (Id)
)
