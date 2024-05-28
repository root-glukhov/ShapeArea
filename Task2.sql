-- Между продуктами и категориями есть отношение многие-ко-многим.
-- Это подразумевает, что в базе должна быть представлена связующая таблица ProductCategories.

-- Создание таблицы Products
CREATE TABLE Products
(
    ProductID int PRIMARY KEY,
    ProductName varchar(255)
)

-- Создание таблицы Categories
CREATE TABLE Categories
(
    CategoryID int PRIMARY KEY,
    CategoryName varchar(255)
)

-- Создание связующей таблицы ProductCategories
CREATE TABLE ProductCategories
(
    ProductID int FOREIGN KEY REFERENCES Products(ProductID),
    CategoryID int FOREIGN KEY REFERENCES Categories(CategoryID),
    PRIMARY KEY (ProductID, CategoryID)
)

-- После чего мы можем добавить некоторые данные в таблицы

-- Добавление продуктов
INSERT INTO Products (ProductID, ProductName)
VALUES (1, 'Банан'), (2, 'Огурец'), (3, 'Помидор'), (4, 'Молоко')

-- Добавление категорий
INSERT INTO Categories (CategoryID, CategoryName)
VALUES (1, 'Овощи'), (2, 'Фрукты')

-- Добавление связей между продуктами и категориями
INSERT INTO ProductCategories (ProductID, CategoryID)
VALUES (1, 2), (2, 2), (3, 1)

-- В итоге конечный запрос будет выглядить следующим образом
SELECT P.ProductName, C.CategoryName
FROM Products P
LEFT JOIN ProductCategories PC ON P.ProductID = PC.ProductID
LEFT JOIN Categories C ON PC.CategoryID = C.CategoryID

