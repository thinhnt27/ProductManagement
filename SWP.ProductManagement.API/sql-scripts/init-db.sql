CREATE DATABASE ProductManagement;
USE ProductManagement;
CREATE TABLE Categories (
    CategoryId INT IDENTITY PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductId INT IDENTITY PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    CategoryId INT,
    UnitPrice DECIMAL(18, 2),
    UnitsInStock INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
INSERT INTO Categories (CategoryName) VALUES 
('Beverages'), ('Condiments'), ('Confections'), ('Dairy Products'),('Grains/Cereals'), ('Meat/Poultry'), ('Produce'), ('Seafood');
INSERT INTO Products (ProductName, CategoryId, UnitPrice, UnitsInStock) VALUES
('Chai', 1, 18.00, 39),
('Chang', 1, 19.00, 17),
('Aniseed Syrup', 2, 10.00, 13),
('Chef Anton''s Cajun Seasoning', 2, 22.00, 53),
('Chef Anton''s Gumbo Mix', 2, 21.35, 0),
('Grandma''s Boysenberry Spread', 2, 25.00, 120),
('Uncle Bob''s Organic Dried Pears', 7, 30.00, 15),
('Northwoods Cranberry Sauce', 2, 40.00, 6),
('Mishi Kobe Niku', 6, 97.00, 29),
('Ikura', 8, 31.00, 31),
('Queso Cabrales', 4, 21.00, 22),
('Queso Manchego La Pastora', 4, 38.00, 86),
('Konbu', 8, 6.00, 24),
('Tofu', 7, 23.25, 35),
('Genen Shouyu', 2, 15.50, 39),
('Pavlova', 3, 17.45, 52),
('Alice Mutton', 6, 39.00, 0),
('Carnarvon Tigers', 8, 62.50, 8),
('Teatime Chocolate Biscuits', 3, 9.20, 25),
('Sir Rodney''s Marmalade', 3, 81.00, 40),
('Sir Rodney''s Scones', 3, 10.00, 3);
