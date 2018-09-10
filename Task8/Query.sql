/*1.1	Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) 
включительно и которые доставлены с ShipVia >= 2.
Формат указания даты должен быть верным при любых региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements”
в Books Online раздел “Accessing and Changing Relational Data Overview”. 
Этот метод использовать далее для всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia. 
Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. */

SELECT OrderDate, ShippedDate, ShipVia
FROM  MASTER.NORTHWIND.ORDERS
WHERE SHIPVIA >= 2 AND SHIPPEDDATE >= DATEADD(Y, 0, '1998-05-06');

/*1.2	Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ – использовать системную функцию CASЕ. 
Запрос должен высвечивать только колонки OrderID и ShippedDate.*/

SELECT OrderID,
	CASE 
		WHEN ShippedDate IS NULL Then 'Not Shipped'
	END ShippedDate
FROM MASTER.NORTHWIND.ORDERS
WHERE ShippedDate IS NULL;

/*1.3 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate) 
не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только колонки 
OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date). 
В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’, 
для остальных значений высвечивать дату в формате по умолчанию.*/

SELECT OrderID AS 'Order Number',
	CASE
		WHEN ShippedDate IS NULL Then 'Not Shipped'
		ELSE CONVERT(nchar, ShippedDate)
	END 'Shipped Date'
FROM MASTER.NORTHWIND.ORDERS
WHERE ShippedDate > CONVERT(datetime, '19980506')
	OR ShippedDate IS NULL;

/*2.1	Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada.
Запрос сделать с только помощью оператора IN.
Высвечивать колонки с именем пользователя и названием страны в результатах запроса.
Упорядочить результаты запроса по имени заказчиков и по месту проживания.*/

SELECT ContactName, Country
FROM Master.Northwind.Customers
WHERE Country IN ('USA','Canada')
ORDER BY ContactName ASC,Country ASC;

/*2.2	Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada.
Запрос сделать с помощью оператора IN. 
Высвечивать колонки с именем пользователя и названием страны в результатах запроса. 
Упорядочить результаты запроса по имени заказчиков.*/

SELECT ContactName, Country
FROM master.Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName;

/* 2.3	Выбрать из таблицы Customers все страны, в которых проживают заказчики.
Страна должна быть упомянута только один раз и список отсортирован по убыванию.
Не использовать предложение GROUP BY. 
Высвечивать только одну колонку в результатах запроса. */

SELECT DISTINCT Country
FROM master.Northwind.Customers
ORDER BY Country DESC;

/*3.1	Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице Order Details.
Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID.*/

SELECT OrderID
FROM master.Northwind.[Order Details]
WHERE Quantity BETWEEN 3 and 10;

/*3.2	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g.
Использовать оператор BETWEEN. 
Проверить, что в результаты запроса попадает Germany. 
Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.*/

SELECT CustomerID, Country 
	FROM master.Northwind.Customers
WHERE Country BETWEEN 'b%' AND 'h%'
ORDER BY Country;

/*3.3	Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g, не используя оператор BETWEEN.
С помощью опции “Execution Plan” определить какой запрос предпочтительнее
3.2 или 3.3 – для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов,
результаты выполнения Execution Plan надо ввести в скрипт в виде комментария и по их результатам дать ответ на вопрос – по какому параметру было проведено сравнение. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.*/
/*Разницы нет (во времени) в выполнении заданий.*/
SELECT CustomerID,Country FROM master.Northwind.Customers 
WHERE	Country Like 'b%' or
		Country Like 'c%' or
		Country Like 'd%' or
		Country Like 'e%' or
		Country Like 'f%' or
		Country Like 'g%'
ORDER BY Country ASC;

/*4.1	В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'.
Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты,
которые удовлетворяют этому условию.
Подсказка: результаты запроса должны высвечивать 2 строки.*/

SELECT ProductName FROM master.Northwind.Products WHERE ProductName LIKE '%cho_olade%';

/*5.1	Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и скидок по ним.
Результат округлить до сотых и высветить в стиле 1 для типа данных money.
Скидка (колонка Discount) составляет процент из стоимости для данного товара.
Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке UnitPrice цены.
Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.*/

SELECT ROUND(SUM((UnitPrice - UnitPrice * Discount)*Quantity),2,1.0) 'Totals' FROM master.Northwind.[Order Details];

/*5.2	По таблице Orders найти количество заказов, которые еще не были доставлены (т.е. в колонке ShippedDate нет значения даты доставки).
 Использовать при этом запросе только оператор COUNT. Не использовать предложения WHERE и GROUP.*/

SELECT COUNT( 
CASE 
	WHEN ShippedDate is null THEN ''
END) 'Number of Counts'
FROM master.Northwind.Orders;

/*5.3	По таблице Orders найти количество различных покупателей (CustomerID), сделавших заказы.
Использовать функцию COUNT и не использовать предложения WHERE и GROUP.*/

SELECT COUNT(CustomerID) 'Number of Customers' FROM master.Northwind.Orders;

/*6.1	По таблице Orders найти количество заказов с группировкой по годам.
 В результатах запроса надо высвечивать две колонки c названиями Year и Total.
 Написать проверочный запрос, который вычисляет количество всех заказов.*/

SELECT COUNT(OrderID) 'Total', YEAR(OrderDate)'Year' FROM master.Northwind.Orders 
GROUP BY YEAR(OrderDate);

/*6.2	По таблице Orders найти количество заказов, cделанных каждым продавцом.
Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке EmployeeID задано значение для данного продавца.
В результатах запроса надо высвечивать колонку с именем продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName.
Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса.
Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ и колонку c количеством заказов высвечивать с названием 'Amount'.
Результаты запроса должны быть упорядочены по убыванию количества заказов. */
SELECT (SELECT LastName + ' '+ FirstName FROM master.Northwind.Employees AS employees WHERE employees.EmployeeID=orders.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' FROM master.Northwind.Orders AS orders
GROUP BY EmployeeID;

/*6.3	По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого покупателя. 
Необходимо определить это только для заказов сделанных в 1998 году. 
В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’),
колонку с именем покупателя (название колонки ‘Customer’)  и колонку c количеством заказов высвечивать с названием 'Amount'.
В запросе необходимо использовать специальный оператор языка T-SQL для работы с
выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах запроса).
Группировки должны быть сделаны по ID продавца и покупателя.
Результаты запроса должны быть упорядочены по продавцу, покупателю и по убыванию количества продаж.
В результатах должна быть сводная информация по продажам. 
Т.е. в резульирующем наборе должны присутствовать дополнительно к информации о продажах продавца для каждого покупателя следующие строчки:
Seller		Customer	Amount
ALL 		ALL		<общее число продаж>
<имя>		ALL		<число продаж для данного продавца>
ALL		<имя>		<число продаж для данного покупателя>
<имя>		<имя>		<число продаж данного продавца для даннного покупателя>
*/
SELECT 
	CASE WHEN Companyname IS NULL THEN 'ALL' ELSE COMPANYNAME END AS 'SELLER',
	CASE WHEN FIRSTNAME IS NULL THEN 'ALL' ELSE FIRSTNAME END AS 'CUSTOMER',
	COUNT(OrderID) as Amount
FROM master.Northwind.Orders
INNER JOIN master.NORTHWIND.CUSTOMERS ON CUSTOMERS.CUSTOMERID = ORDERS.CUSTOMERID
INNER JOIN master.NORTHWIND.EMPLOYEES ON EMPLOYEES.EMPLOYEEID = ORDERS.EMPLOYEEID
WHERE YEAR(ORDERDATE) = CONVERT(INT, '1998')
GROUP BY CUBE(COMPANYNAME, FIRSTNAME)
ORDER BY SELLER, CUSTOMER, AMOUNT ASC;

/*6.4	Найти покупателей и продавцов, которые живут в одном городе.
Если в городе живут только один или несколько продавцов или только один или несколько покупателей, 
то информация о таких покупателя и продавцах не должна попадать в результирующий набор.
Не использовать конструкцию JOIN. В результатах запроса необходимо вывести следующие заголовки для результатов запроса:
‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или  ‘Seller’ в завимости от типа записи), ‘City’.
Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.*/

SELECT customers.ContactName AS Person, 'Customer' AS Type, customers.City AS City FROM master.Northwind.Customers aS customers
	WHERE EXISTS (SELECT employees.City FROM master.Northwind.Employees AS employees WHERE customers.City = employees.City)
	UNION ALL
SELECT employees.FirstName+' '+ employees.LastName AS Person, 'Seller' AS Type, employees.City AS City
	FROM master.Northwind.Employees AS employees
	WHERE EXISTS (SELECT customers.City FROM master.Northwind.Customers AS customers WHERE employees.City=customers.City)
ORDER BY City, Person


/*6.5	Найти всех покупателей, которые живут в одном городе.
В запросе использовать соединение таблицы Customers c собой - самосоединение. 
Высветить колонки CustomerID и City. Запрос не должен высвечивать дублируемые записи. 
Для проверки написать запрос, который высвечивает города, которые встречаются более одного раза в таблице Customers. 
Это позволит проверить правильность запроса.*/

SELECT Customers1.CustomerID, Customers1.City FROM master.Northwind.Customers Customers1 inner join master.Northwind.Customers Customers2
ON Customers1.City = Customers2.City WHERE Customers1.CustomerID <> Customers2.CustomerID
GROUP BY Customers1.City, Customers1.CustomerID
ORDER BY Customers1.City ASC

/*6.6	По таблице Employees найти для каждого продавца его руководителя, т.е. кому он делает репорты. 
Высветить колонки с именами 'User Name' (LastName) и 'Boss'. 
В колонках должны быть высвечены имена из колонки LastName.*/

SELECT employees1.FirstName + ' ' + employees1.LastName 'User Name', (select employees2.FirstName + ' '+ employees2.LastName from master.Northwind.Employees employees2 where employees1.ReportsTo = employees2.EmployeeID) 'Boss' FROM master.Northwind.Employees AS employees1

/*7.1	Определить продавцов, которые обслуживают регион 'Western' (таблица Region).
Результаты запроса должны высвечивать два поля: 'LastName' продавца и название обслуживаемой территории ('TerritoryDescription' из таблицы Territories).
Запрос должен использовать JOIN в предложении FROM. 
Для определения связей между таблицами Employees и Territories надо использовать графические диаграммы для базы Northwind*/

SELECT E.FirstName + ' ' + E.LastName 'Last Name', T.TerritoryDescription
FROM master.Northwind.Employees AS E 
INNER JOIN master.Northwind.EmployeeTerritories AS ET ON E.EmployeeID = ET.EmployeeID 
INNER JOIN master.Northwind.Territories AS T ON ET.TerritoryID = T.TerritoryID 
INNER JOIN master.Northwind.Region AS R ON T.RegionID = R.RegionID
WHERE RegionDescription = 'Western'

/*8.1	Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное количество их заказов из таблицы Orders.
Принять во внимание, что у некоторых заказчиков нет заказов, но они также должны быть выведены в результатах запроса. 
Упорядочить результаты запроса по возрастанию количества заказов.*/

SELECT 
(SELECT ContactName FROM master.Northwind.Customers AS customers WHERE customers.CustomerID = orders.CustomerID) 'Customer',
COUNT(OrderID) 'Total Amount'
FROM master.Northwind.Orders AS orders GROUP BY CustomerID;

/*9.1	Высветить всех поставщиков колонка CompanyName в таблице Suppliers,
у которых нет хотя бы одного продукта на складе (UnitsInStock в таблице Products равно 0).
Использовать вложенный SELECT для этого запроса с использованием оператора IN.
Можно ли использовать вместо оператора IN оператор '=' ?*/

SELECT CompanyName FROM master.Northwind.Suppliers AS suppliers
WHERE suppliers.SupplierID 
IN (SELECT SupplierID FROM master.Northwind.Products AS products WHERE UnitsInStock = 0);
/*Нельзя*/

/*10.1	Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный коррелированный SELECT.*/

SELECT EmployeeID 'ID of Employee', FirstName + ' ' + LastName 'FullName of Employee' FROM master.Northwind.Employees AS employees 
WHERE EmployeeID
IN  (SELECT EmployeeID FROM Northwind.Orders orders WHERE employees.EmployeeID = orders.EmployeeID
GROUP BY EmployeeID
HAVING COUNT(OrderID) > 150);

/*11.1	Высветить всех заказчиков (таблица Customers), 
которые не имеют ни одного заказа (подзапрос по таблице Orders). 
Использовать коррелированный SELECT и оператор EXISTS.*/

SELECT ContactName 'Name of Customer' 
FROM master.Northwind.Customers AS customers
WHERE NOT EXISTS(SELECT * FROM master.Northwind.Orders AS orders WHERE orders.CustomerID = customers.CustomerID);

/*12.1	Для формирования алфавитного указателя Employees высветить из таблицы Employees список только тех букв алфавита, 
с которых начинаются фамилии Employees (колонка LastName ) из этой таблицы. 
Алфавитный список должен быть отсортирован по возрастанию.*/

SELECT Distinct LEFT(LastName,1) AS 'Letters'
FROM Northwind.Employees
ORDER BY [Letters];

/*13.1*/
exec Northwind.GreatestOrders 1998

/*13.2*/
exec Northwind.ShippedOrdersDiff 20

/*13.3*/
exec Northwind.SubordinationInfo 2

/*13.4*/
SELECT  employees.EmployeeID,employees.ReportsTo, master.Northwind.IsBoss(employees.EmployeeID) AS [IsBoss? 1 - Yes; 0 - No]
FROM Northwind.Employees AS employees;

/*14. На основе диаграммы классов проработайте архитектуру базы данных вашего финального проекта.
Напишите скрипт создания сущностей пользователя, ролей и зависимых сущностей 
(достаточных для выполнения CRUD операций над пользователями и выдачи им определенных ролей)
*Напишите скрипт создания оставшихся сущностей вашей диаграммы. 
*/

GO
IF NOT EXISTS(SELECT * FROM sys.databases 
          WHERE name='KnowledgeManagementSystemDB')
BEGIN
	CREATE DATABASE KnowledgeManagementSystemDB
END;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Role' and xtype='U') 
BEGIN 
CREATE TABLE Role(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Permision nvarchar(10) NOT NULL
)
END;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Account' and xtype='U')
BEGIN
CREATE TABLE Account(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
ProfileImage image,
[Role] nvarchar,
UserName nvarchar(10),
Email nvarchar,
[Password] nvarchar(10)
)
END;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Task' and xtype='U')
BEGIN
CREATE TABLE Task(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Title nvarchar,
StartTime datetime,
EndTime datetime
)
END;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TestAssesment' and xtype='U')
BEGIN
CREATE TABLE TestAssesment(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Theme nvarchar,
Score int
)
END;

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Report' and xtype='U')
BEGIN
CREATE TABLE Report(
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
Title nvarchar,
[Text] nvarchar,
Score int
)
END;

