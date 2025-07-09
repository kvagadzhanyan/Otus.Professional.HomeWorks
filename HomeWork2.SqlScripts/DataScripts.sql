--Добавление нового продукта
INSERT INTO Products (ProductName, price, QuantityInStock )
	VALUES('Coca-Cola',199.99,500);

--Обновление цены продукта
UPDATE Products 
SET price = 229.99
WHERE ProductID = 1;

--Выбор всех заказов определенного пользователя
SELECT 
	* 
FROM Orders 
WHERE UserId = 1;

--Расчет общей стоимости заказа
SELECT 
	SUM(TotalCost) AS totalCost
FROM OrderDetails 
WHERE OrderID = 1;

--Подсчет количества товаров на складе
SELECT 
	SUM(QuantityInStock) AS TotalQuantity 
FROM Products;

--Получение 5 самых дорогих товаров
SELECT 
	*
FROM Products 
ORDER BY Price DESC
LIMIT 5;

--Список товаров с низким запасом (менее 5 штук)
SELECT 
	*
FROM Products
WHERE QuantityInStock < 5;