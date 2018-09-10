/*1.1	������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) 
������������ � ������� ���������� � ShipVia >= 2.
������ �������� ���� ������ ���� ������ ��� ����� ������������ ����������, �������� ����������� ������ �Writing International Transact-SQL Statements�
� Books Online ������ �Accessing and Changing Relational Data Overview�. 
���� ����� ������������ ����� ��� ���� �������. ������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia. 
�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate. */

SELECT OrderDate, ShippedDate, ShipVia
FROM  MASTER.NORTHWIND.ORDERS
WHERE SHIPVIA >= 2 AND SHIPPEDDATE >= DATEADD(Y, 0, '1998-05-06');

/*1.2	�������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped� � ������������ ��������� ������� CAS�. 
������ ������ ����������� ������ ������� OrderID � ShippedDate.*/

SELECT OrderID,
	CASE 
		WHEN ShippedDate IS NULL Then 'Not Shipped'
	END ShippedDate
FROM MASTER.NORTHWIND.ORDERS
WHERE ShippedDate IS NULL;

/*1.3 ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate) 
�� ������� ��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������� ������ ������� 
OrderID (������������� � Order Number) � ShippedDate (������������� � Shipped Date). 
� ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�, 
��� ��������� �������� ����������� ���� � ������� �� ���������.*/

SELECT OrderID AS 'Order Number',
	CASE
		WHEN ShippedDate IS NULL Then 'Not Shipped'
		ELSE CONVERT(nchar, ShippedDate)
	END 'Shipped Date'
FROM MASTER.NORTHWIND.ORDERS
WHERE ShippedDate > CONVERT(datetime, '19980506')
	OR ShippedDate IS NULL;

/*2.1	������� �� ������� Customers ���� ����������, ����������� � USA � Canada.
������ ������� � ������ ������� ��������� IN.
����������� ������� � ������ ������������ � ��������� ������ � ����������� �������.
����������� ���������� ������� �� ����� ���������� � �� ����� ����������.*/

SELECT ContactName, Country
FROM Master.Northwind.Customers
WHERE Country IN ('USA','Canada')
ORDER BY ContactName ASC,Country ASC;

/*2.2	������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada.
������ ������� � ������� ��������� IN. 
����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
����������� ���������� ������� �� ����� ����������.*/

SELECT ContactName, Country
FROM master.Northwind.Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName;

/* 2.3	������� �� ������� Customers ��� ������, � ������� ��������� ���������.
������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������.
�� ������������ ����������� GROUP BY. 
����������� ������ ���� ������� � ����������� �������. */

SELECT DISTINCT Country
FROM master.Northwind.Customers
ORDER BY Country DESC;

/*3.1	������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������),
��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � ������� Order Details.
������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID.*/

SELECT OrderID
FROM master.Northwind.[Order Details]
WHERE Quantity BETWEEN 3 and 10;

/*3.2	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g.
������������ �������� BETWEEN. 
���������, ��� � ���������� ������� �������� Germany. 
������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.*/

SELECT CustomerID, Country 
	FROM master.Northwind.Customers
WHERE Country BETWEEN 'b%' AND 'h%'
ORDER BY Country;

/*3.3	������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� ����� �� ��������� b � g, �� ��������� �������� BETWEEN.
� ������� ����� �Execution Plan� ���������� ����� ������ ����������������
3.2 ��� 3.3 � ��� ����� ���� ������ � ������ ���������� ���������� Execution Plan-a ��� ���� ���� ��������,
���������� ���������� Execution Plan ���� ������ � ������ � ���� ����������� � �� �� ����������� ���� ����� �� ������ � �� ������ ��������� ���� ��������� ���������. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.*/
/*������� ��� (�� �������) � ���������� �������.*/
SELECT CustomerID,Country FROM master.Northwind.Customers 
WHERE	Country Like 'b%' or
		Country Like 'c%' or
		Country Like 'd%' or
		Country Like 'e%' or
		Country Like 'f%' or
		Country Like 'g%'
ORDER BY Country ASC;

/*4.1	� ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'.
��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������,
������� ������������� ����� �������.
���������: ���������� ������� ������ ����������� 2 ������.*/

SELECT ProductName FROM master.Northwind.Products WHERE ProductName LIKE '%cho_olade%';

/*5.1	����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � ������ �� ���.
��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.
������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������.
��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� UnitPrice ����.
����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.*/

SELECT ROUND(SUM((UnitPrice - UnitPrice * Discount)*Quantity),2,1.0) 'Totals' FROM master.Northwind.[Order Details];

/*5.2	�� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� (�.�. � ������� ShippedDate ��� �������� ���� ��������).
 ������������ ��� ���� ������� ������ �������� COUNT. �� ������������ ����������� WHERE � GROUP.*/

SELECT COUNT( 
CASE 
	WHEN ShippedDate is null THEN ''
END) 'Number of Counts'
FROM master.Northwind.Orders;

/*5.3	�� ������� Orders ����� ���������� ��������� ����������� (CustomerID), ��������� ������.
������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.*/

SELECT COUNT(CustomerID) 'Number of Customers' FROM master.Northwind.Orders;

/*6.1	�� ������� Orders ����� ���������� ������� � ������������ �� �����.
 � ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total.
 �������� ����������� ������, ������� ��������� ���������� ���� �������.*/

SELECT COUNT(OrderID) 'Total', YEAR(OrderDate)'Year' FROM master.Northwind.Orders 
GROUP BY YEAR(OrderDate);

/*6.2	�� ������� Orders ����� ���������� �������, c�������� ������ ���������.
����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, ��� � ������� EmployeeID ������ �������� ��� ������� ��������.
� ����������� ������� ���� ����������� ������� � ������ �������� (������ ������������� ��� ���������� ������������� LastName & FirstName.
��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������.
����� �������� ������ ������ ������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� � ������� c ����������� ������� ����������� � ��������� 'Amount'.
���������� ������� ������ ���� ����������� �� �������� ���������� �������. */
SELECT (SELECT LastName + ' '+ FirstName FROM master.Northwind.Employees AS employees WHERE employees.EmployeeID=orders.EmployeeID) 'Seller',
COUNT(EmployeeID) 'Amount' FROM master.Northwind.Orders AS orders
GROUP BY EmployeeID;

/*6.3	�� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� ����������. 
���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. 
� ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�),
������� � ������ ���������� (�������� ������� �Customer�)  � ������� c ����������� ������� ����������� � ��������� 'Amount'.
� ������� ���������� ������������ ����������� �������� ����� T-SQL ��� ������ �
���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � ����������� �������).
����������� ������ ���� ������� �� ID �������� � ����������.
���������� ������� ������ ���� ����������� �� ��������, ���������� � �� �������� ���������� ������.
� ����������� ������ ���� ������� ���������� �� ��������. 
�.�. � ������������� ������ ������ �������������� ������������� � ���������� � �������� �������� ��� ������� ���������� ��������� �������:
Seller		Customer	Amount
ALL 		ALL		<����� ����� ������>
<���>		ALL		<����� ������ ��� ������� ��������>
ALL		<���>		<����� ������ ��� ������� ����������>
<���>		<���>		<����� ������ ������� �������� ��� �������� ����������>
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

/*6.4	����� ����������� � ���������, ������� ����� � ����� ������.
���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������, 
�� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����.
�� ������������ ����������� JOIN. � ����������� ������� ���������� ������� ��������� ��������� ��� ����������� �������:
�Person�, �Type� (����� ���� �������� ������ �Customer� ���  �Seller� � ��������� �� ���� ������), �City�.
������������� ���������� ������� �� ������� �City� � �� �Person�.*/

SELECT customers.ContactName AS Person, 'Customer' AS Type, customers.City AS City FROM master.Northwind.Customers aS customers
	WHERE EXISTS (SELECT employees.City FROM master.Northwind.Employees AS employees WHERE customers.City = employees.City)
	UNION ALL
SELECT employees.FirstName+' '+ employees.LastName AS Person, 'Seller' AS Type, employees.City AS City
	FROM master.Northwind.Employees AS employees
	WHERE EXISTS (SELECT customers.City FROM master.Northwind.Customers AS customers WHERE employees.City=customers.City)
ORDER BY City, Person


/*6.5	����� ���� �����������, ������� ����� � ����� ������.
� ������� ������������ ���������� ������� Customers c ����� - ��������������. 
��������� ������� CustomerID � City. ������ �� ������ ����������� ����������� ������. 
��� �������� �������� ������, ������� ����������� ������, ������� ����������� ����� ������ ���� � ������� Customers. 
��� �������� ��������� ������������ �������.*/

SELECT Customers1.CustomerID, Customers1.City FROM master.Northwind.Customers Customers1 inner join master.Northwind.Customers Customers2
ON Customers1.City = Customers2.City WHERE Customers1.CustomerID <> Customers2.CustomerID
GROUP BY Customers1.City, Customers1.CustomerID
ORDER BY Customers1.City ASC

/*6.6	�� ������� Employees ����� ��� ������� �������� ��� ������������, �.�. ���� �� ������ �������. 
��������� ������� � ������� 'User Name' (LastName) � 'Boss'. 
� �������� ������ ���� ��������� ����� �� ������� LastName.*/

SELECT employees1.FirstName + ' ' + employees1.LastName 'User Name', (select employees2.FirstName + ' '+ employees2.LastName from master.Northwind.Employees employees2 where employees1.ReportsTo = employees2.EmployeeID) 'Boss' FROM master.Northwind.Employees AS employees1

/*7.1	���������� ���������, ������� ����������� ������ 'Western' (������� Region).
���������� ������� ������ ����������� ��� ����: 'LastName' �������� � �������� ������������� ���������� ('TerritoryDescription' �� ������� Territories).
������ ������ ������������ JOIN � ����������� FROM. 
��� ����������� ������ ����� ��������� Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind*/

SELECT E.FirstName + ' ' + E.LastName 'Last Name', T.TerritoryDescription
FROM master.Northwind.Employees AS E 
INNER JOIN master.Northwind.EmployeeTerritories AS ET ON E.EmployeeID = ET.EmployeeID 
INNER JOIN master.Northwind.Territories AS T ON ET.TerritoryID = T.TerritoryID 
INNER JOIN master.Northwind.Region AS R ON T.RegionID = R.RegionID
WHERE RegionDescription = 'Western'

/*8.1	��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� ���������� �� ������� �� ������� Orders.
������� �� ��������, ��� � ��������� ���������� ��� �������, �� ��� ����� ������ ���� �������� � ����������� �������. 
����������� ���������� ������� �� ����������� ���������� �������.*/

SELECT 
(SELECT ContactName FROM master.Northwind.Customers AS customers WHERE customers.CustomerID = orders.CustomerID) 'Customer',
COUNT(OrderID) 'Total Amount'
FROM master.Northwind.Orders AS orders GROUP BY CustomerID;

/*9.1	��������� ���� ����������� ������� CompanyName � ������� Suppliers,
� ������� ��� ���� �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0).
������������ ��������� SELECT ��� ����� ������� � �������������� ��������� IN.
����� �� ������������ ������ ��������� IN �������� '=' ?*/

SELECT CompanyName FROM master.Northwind.Suppliers AS suppliers
WHERE suppliers.SupplierID 
IN (SELECT SupplierID FROM master.Northwind.Products AS products WHERE UnitsInStock = 0);
/*������*/

/*10.1	��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� ��������������� SELECT.*/

SELECT EmployeeID 'ID of Employee', FirstName + ' ' + LastName 'FullName of Employee' FROM master.Northwind.Employees AS employees 
WHERE EmployeeID
IN  (SELECT EmployeeID FROM Northwind.Orders orders WHERE employees.EmployeeID = orders.EmployeeID
GROUP BY EmployeeID
HAVING COUNT(OrderID) > 150);

/*11.1	��������� ���� ���������� (������� Customers), 
������� �� ����� �� ������ ������ (��������� �� ������� Orders). 
������������ ��������������� SELECT � �������� EXISTS.*/

SELECT ContactName 'Name of Customer' 
FROM master.Northwind.Customers AS customers
WHERE NOT EXISTS(SELECT * FROM master.Northwind.Orders AS orders WHERE orders.CustomerID = customers.CustomerID);

/*12.1	��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ ������ ��� ���� ��������, 
� ������� ���������� ������� Employees (������� LastName ) �� ���� �������. 
���������� ������ ������ ���� ������������ �� �����������.*/

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

/*14. �� ������ ��������� ������� ������������ ����������� ���� ������ ������ ���������� �������.
�������� ������ �������� ��������� ������������, ����� � ��������� ��������� 
(����������� ��� ���������� CRUD �������� ��� �������������� � ������ �� ������������ �����)
*�������� ������ �������� ���������� ��������� ����� ���������. 
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

