INSERT INTO  KnowledgeManagementSystemDB.[dbo].Role VALUES (1, 'Admin'), (2, 'Manager'), (3, 'Programmer')
INSERT INTO KnowledgeManagementSystemDB.[dbo].[User] ([Name], [Password], [Role], Email) VALUES ('Aida Zaynullia', '111', 3, 'aida.zaynullina@yandex.ru'), ('Egor Gladkov', '222', 2, 'egor.gladkov@gmail.com'), ('Svetlana Beznosova', '333', 3, 'beznosova@mail.ru')

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Test] ([Name], UserId, [Description]) VALUES ('Test 1: C# Programming Test.', 1, 'Introduction test');

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, '��� ������������ �������� ����� ������������ ������� ������ ��� ������� ����� Finalize() ��� Dispose(). ��� ���?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, '���, �� �� ������ ���� ������� ����� Finalize().', 1, 1);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, '��, ��� ���.', 0, 1);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, '�� ���������� �������� ������� � ������������� ������. ��� ����� �������� ������� ��������� � �������� ��� �� ����� �� ������ ����. ����� ������� �� ��������������?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, '	Interlocked.Exchange(ref currentState, newState).', 0, 2);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'Interlocked.CompareExchange(ref currentState, newState, expectedState).', 1, 2);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, '��� ����� ����������� ������ ����� ������������ �������. ����� ������ ����� ��� ��������?');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, 'CancellationTokenSource.', 0, 3);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, 'CancellationToken.', 1, 3);

INSERT INTO KnowledgeManagementSystemDB.[dbo].[Question] ([TestId], [Text]) VALUES (1, '�� ����������� ������������� ������� � ����������� ������������. �� ������ ���������, ��� ��� ���������� ����������, ���� ��� ������������ ����������.');
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (1, '����� ������� ������� ������� � ������� GetInvocationList()).', 1, 4);
INSERT INTO KnowledgeManagementSystemDB.[dbo].[Variant] ([IsRight], [Text], [Score], [QuestionId]) VALUES (0, '����� �������� ����� ������� � try/catch.', 0, 4);
