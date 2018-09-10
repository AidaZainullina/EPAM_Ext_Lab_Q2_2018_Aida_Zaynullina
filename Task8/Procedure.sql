/*13.1	�������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� ������������ ���. 
� ����������� �� ����� ���� ��������� ������� ������ ��������, ������ ���� ������ ���� � ����� �������. 
� ����������� ������� ������ ���� �������� ��������� �������: ������� � ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), 
����� ������ � ��� ���������. � ������� ���� ��������� Discount ��� ������� �������. 
��������� ���������� ���, �� ������� ���� ������� �����, � ���������� ������������ �������. 
���������� ������� ������ ���� ����������� �� �������� ����� ������. 
��������� ������ ���� ����������� � �������������� ��������� SELECT � ��� ������������� ��������. 
�������� ������� �������������� GreatestOrders. ���������� ������������������ ������������� ���� ��������. 
����� ������ ������������ ������� �������� � ������� Query.sql ���� �������� ��������� �������������� ����������� ������
��� ������������ ������������ ������ ��������� GreatestOrders. 
����������� ������ ������ �������� � ������� ��� ��������� � ������������ ������ 
�������� ���� ��� ������������� �������� ��� ���� ��� ������� �� ������������ ��������� ��� � ����������� ��������� �������: 
��� ��������, ����� ������, ����� ������. ����������� ������ �� ������ ��������� ������, ���������� � ���������, - 
�� ������ ��������� ������ ��, ��� ������� � ����������� �� ����.*/
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
/*13.2	�������� ���������, ������� ���������� ������ � ������� Orders, 
�������� ���������� ����� �������� � ���� (������� ����� OrderDate � ShippedDate).  
� ����������� ������ ���� ���������� ������, ���� ������� ��������� ���������� �������� ��� ��� �������������� ������.
�������� �� ��������� ��� ������������� ����� 35 ����. �������� ��������� ShippedOrdersDiff. 
��������� ������ ����������� ��������� �������: OrderID, OrderDate, ShippedDate, ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), 
SpecifiedDelay (���������� � ��������� ��������).  ���������� ������������������ ������������� ���� ���������.*/

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

/*13.3	�������� ���������, ������� ����������� ���� ����������� ��������� ��������, 
��� ����������������, ��� � ����������� ��� �����������. 
� �������� �������� ��������� ������� ������������ EmployeeID. 
���������� ����������� ����� ����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� ����������. 
��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������.
�������� ��������� SubordinationInfo.
� �������� ��������� ��� ������� ���� ������ ���� ������������ ������, ����������� � Books Online 
� ��������������� Microsoft ��� ������� ��������� ���� �����. 
������������������ ������������� ���������.*/

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

/*�������� �������, ������� ����������, ���� �� � �������� �����������.
���������� ��� ������ BIT. � �������� �������� ��������� ������� ������������ EmployeeID.
�������� ������� IsBoss.
������������������ ������������� ������� ��� ���� ��������� �� ������� Employees.*/


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