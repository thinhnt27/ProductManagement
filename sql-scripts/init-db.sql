-- Create the ProductManagement database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProductManagement')
BEGIN
    CREATE DATABASE ProductManagement;
END
GO

-- Use the ProductManagement database
USE ProductManagement;
GO

-- Create Category table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Categories')
BEGIN
    CREATE TABLE Categories (
        CategoryId INT PRIMARY KEY IDENTITY(1,1),
        CategoryName NVARCHAR(100) NOT NULL
    );
END
GO

-- Create Product table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Products')
BEGIN
    CREATE TABLE Products (
        ProductId INT PRIMARY KEY IDENTITY(1,1),
        ProductName NVARCHAR(100) NOT NULL,
        CategoryId INT,
        UnitPrice DECIMAL(18, 2),
        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
    );
END
GO

-- Insert categories
INSERT INTO Categories (CategoryName) VALUES ('Beverages'), ('Condiments'), ('Confections'), ('Dairy Products'),
                                            ('Grains/Cereals'), ('Meat/Poultry'), ('Produce'), ('Seafood');
GO

-- Insert products
INSERT INTO Products (ProductName, CategoryId, UnitPrice) VALUES
('Chai', 1, 18.00),
('Chang', 1, 19.00),
('Aniseed Syrup', 2, 10.00),
('Chef Anton''s Cajun Seasoning', 2, 22.00),
('Chef Anton''s Gumbo Mix', 2, 21.35),
('Grandma''s Boysenberry Spread', 2, 25.00),
('Uncle Bob''s Organic Dried Pears', 7, 30.00),
('Northwoods Cranberry Sauce', 2, 40.00),
('Mishi Kobe Niku', 6, 97.00),
('Ikura', 8, 31.00),
('Queso Cabrales', 4, 21.00),
('Queso Manchego La Pastora', 4, 38.00),
('Konbu', 8, 6.00),
('Tofu', 7, 23.25),
('Genen Shouyu', 2, 15.50),
('Pavlova', 3, 17.45),
('Alice Mutton', 6, 39.00),
('Carnarvon Tigers', 8, 62.50),
('Teatime Chocolate Biscuits', 3, 9.20),
('Sir Rodney''s Marmalade', 3, 81.00),
('Sir Rodney''s Scones', 3, 10.00);
GO
