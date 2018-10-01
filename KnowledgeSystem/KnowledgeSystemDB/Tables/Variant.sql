CREATE TABLE [dbo].[Variant]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
    [IsRight] INT NOT NULL, 
    [Text] NCHAR(100) NULL, 
    [Score] INT NULL,
	[QuestionId] int foreign key (QuestionId) references dbo.Question (Id)
)
