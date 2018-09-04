/*13.1	Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за определенный год. 
В результатах не может быть несколько заказов одного продавца, должен быть только один и самый крупный. 
В результатах запроса должны быть выведены следующие колонки: колонка с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), 
номер заказа и его стоимость. В запросе надо учитывать Discount при продаже товаров. 
Процедуре передается год, за который надо сделать отчет, и количество возвращаемых записей. 
Результаты запроса должны быть упорядочены по убыванию суммы заказа. 
Процедура должна быть реализована с использованием оператора SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. 
Название функции соответственно GreatestOrders. Необходимо продемонстрировать использование этих процедур. 
Также помимо демонстрации вызовов процедур в скрипте Query.sql надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос
для тестирования правильности работы процедуры GreatestOrders. 
Проверочный запрос должен выводить в удобном для сравнения с результатами работы 
процедур виде для определенного продавца для всех его заказов за определенный указанный год в результатах следующие колонки: 
имя продавца, номер заказа, сумму заказа. Проверочный запрос не должен повторять запрос, написанный в процедуре, - 
он должен выполнять только то, что описано в требованиях по нему.*/
IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures 
        WHERE NAME = 'GreatestOrders'
        AND type = 'P'
		  )
			BEGIN
				DROP PROCEDURE Northwind.GreatestOrders
			END;
GO
CREATE PROCEDURE Northwind.GreatestOrders @Year int
AS
BEGIN
	SELECT 
	FirstName + ' ' + LastName 'Full Name', (orderDetails.UnitPrice * (1 - orderDetails.Discount)) * orderDetails.Quantity AS 'Max Price'
	FROM master.Northwind.Employees AS employee
	Inner Join 
	master.Northwind.Orders AS orders ON employee.EmployeeID = orders.EmployeeID 
	Inner Join
	master.Northwind.[Order Details] AS orderDetails ON orders.OrderID = orderDetails.OrderID
	WHERE YEAR(OrderDate) = @Year
	AND 
	(orderDetails.UnitPrice * (1 - orderDetails.Discount)) * orderDetails.Quantity = (SELECT MAX(((orderDetails2.UnitPrice * (1 - orderDetails2.Discount)) * orderDetails2.Quantity))	
	FROM master.Northwind.Orders order2
	Inner Join 
	master.Northwind.[Order Details] orderDetails2
	ON
	order2.OrderID = orderDetails2.OrderID
	WHERE
	YEAR(order2.OrderDate) = @Year)
END;
GO
/*13.2	Написать процедуру, которая возвращает заказы в таблице Orders, 
согласно указанному сроку доставки в днях (разница между OrderDate и ShippedDate).  
В результатах должны быть возвращены заказы, срок которых превышает переданное значение или еще недоставленные заказы.
Значению по умолчанию для передаваемого срока 35 дней. Название процедуры ShippedOrdersDiff. 
Процедура должна высвечивать следующие колонки: OrderID, OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и OrderDate), 
SpecifiedDelay (переданное в процедуру значение).  Необходимо продемонстрировать использование этой процедуры.*/

IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures 
        WHERE NAME = 'ShippedOrdersDiff'
        AND type = 'P'
		  )
			BEGIN
				DROP PROCEDURE Northwind.ShippedOrdersDiff
			END;
GO
CREATE PROCEDURE Northwind.ShippedOrdersDiff @Days int = 35
AS
BEGIN
	SELECT OrderID, OrderDate, ShippedDate, DateDiff(D, OrderDate, ShippedDate) AS 'ShippedDelay'
	FROM master.Northwind.Orders WHERE  DateDiff(D, OrderDate, ShippedDate)  > @Days OR  DateDiff(D, OrderDate, ShippedDate)  IS NULL
	Order By DateDiff(D, OrderDate, ShippedDate) DESC
END;
GO

/*13.3	Написать процедуру, которая высвечивает всех подчиненных заданного продавца, 
как непосредственных, так и подчиненных его подчиненных. 
В качестве входного параметра функции используется EmployeeID. 
Необходимо распечатать имена подчиненных и выровнять их в тексте (использовать оператор PRINT) согласно иерархии подчинения. 
Продавец, для которого надо найти подчиненных также должен быть высвечен.
Название процедуры SubordinationInfo.
В качестве алгоритма для решения этой задачи надо использовать пример, приведенный в Books Online 
и рекомендованный Microsoft для решения подобного типа задач. 
Продемонстрировать использование процедуры.*/

IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures 
        WHERE NAME = 'SubordinationInfo'
        AND type = 'P'
		  )
			BEGIN
				DROP PROCEDURE Northwind.SubordinationInfo
			END;
GO
CREATE PROCEDURE Northwind.SubordinationInfo @sellerId int
AS
DECLARE @string nvarchar(100)= '';
DECLARE @finalString nvarchar(100);
WHILE (@sellerId is not null)
BEGIN
SET @finalString = (SELECT @string + LastName FROM master.Northwind.Employees WHERE EmployeeID = @sellerId)
PRINT @finalString
SET @sellerId = (SELECT ReportsTo FROM master.Northwind.Employees WHERE EmployeeID = @sellerId)
SET @string = @string + ' '
END
GO

/*Написать функцию, которая определяет, есть ли у продавца подчиненные.
Возвращает тип данных BIT. В качестве входного параметра функции используется EmployeeID.
Название функции IsBoss.
Продемонстрировать использование функции для всех продавцов из таблицы Employees.*/


IF EXISTS (
        SELECT type_desc, type
        FROM sys.partition_functions 
        WHERE NAME = 'IsBoss'
        AND type = 'P'
		  )
			BEGIN
				DROP FUNCTION Northwind.IsBoss
			END;
GO
CREATE FUNCTION Northwind.IsBoss (@EmployeeID int)
RETURNS BIT
AS
BEGIN
	IF (EXISTS(SELECT EmployeeID FROM master.Northwind.Employees WHERE ReportsTo = @EmployeeID))
	RETURN 1
RETURN 0
END
GO