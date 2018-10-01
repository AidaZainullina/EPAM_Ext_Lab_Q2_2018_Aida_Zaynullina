INSERT INTO KnowledgeManagementSystemDB.[dbo].Role VALUES (1, 'Admin'), (2, 'Manager'), (3, 'Programmer');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[User] ([Name], [Password], [Role], Email) VALUES ('Aida Zaynullia', '111', 3, 'aida.zaynullina@yandex.ru'), ('Egor Gladkov', '222', 2, 'egor.gladkov@gmail.com'), ('Svetlana Beznosova', '333', 3, 'beznosova@mail.ru')

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Test] ([Name], UserId, [Description]) VALUES ('Test 1: C# Programming Test.', 1, 'Introduction test');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Test] ([Name], UserId, [Description]) VALUES ('Test 1: C# Programming Test.', 20, 'Introduction test');


INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, 'Для освобождения ресурсов можно использовать сборщик мусора или вызвать метод Finalize() или Dispose(). Это так?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'Нет, вы не можете явно вызвать метод Finalize().', 1, 1);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, 'Да, это так.', 0, 1);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, 'Вы реализуете конечный автомат в многопоточном классе. Вам нужно получить текущее состояние и изменить его на новое на каждом шаге. Каким методом вы воспользуетесь?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, '	Interlocked.Exchange(ref currentState, newState).', 0, 2);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'Interlocked.CompareExchange(ref currentState, newState, expectedState).', 1, 2);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, 'Вам нужно реализовать отмену долго выполняемого задания. Какой объект нужно ему передать?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, 'CancellationTokenSource.', 0, 3);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'CancellationToken.', 1, 3);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, 'Вы используете многоадресный делегат с несколькими подписчиками. Вы хотите убедиться, что все подписчики уведомлены, даже при выбрасывании исключения.');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'Можно вручную вызвать событие с помощью GetInvocationList()).', 1, 4);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, 'Можно обернуть вызов события в try/catch.', 0, 4);
