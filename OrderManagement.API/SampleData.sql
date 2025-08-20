-- Sample data for Order Management System
-- Execute this script against the orderDB database

-- 1. Insert sample customers
INSERT INTO dbo.Customers (Name, Email, CreatedAt) VALUES
('John Doe', 'john.doe@email.com', '2025-08-15 10:00:00'),
('Jane Smith', 'jane.smith@email.com', '2025-08-16 11:30:00'),
('Mike Johnson', 'mike.johnson@email.com', '2025-08-17 09:15:00'),
('Sarah Wilson', 'sarah.wilson@email.com', '2025-08-17 14:20:00'),
('David Brown', 'david.brown@email.com', '2025-08-18 08:45:00');

-- 2. Insert sample orders
INSERT INTO dbo.Orders (CustomerId, OrderDate, TotalAmount, Status) VALUES
(1, '2025-08-15 12:00:00', 299.99, 'Completed'),
(1, '2025-08-17 10:30:00', 149.99, 'Pending'),
(2, '2025-08-16 15:45:00', 89.97, 'Shipped'),
(3, '2025-08-17 11:20:00', 450.00, 'Processing'),
(3, '2025-08-18 09:00:00', 75.50, 'Pending'),
(4, '2025-08-17 16:30:00', 199.99, 'Completed'),
(5, '2025-08-18 10:15:00', 325.48, 'Processing');

-- 3. Insert sample order items
INSERT INTO dbo.OrderItems (OrderId, ProductName, Quantity, UnitPrice) VALUES
-- Order 1 items (John Doe - Order 1)
(1, 'Laptop Computer', 1, 299.99),

-- Order 2 items (John Doe - Order 2)
(2, 'Wireless Mouse', 2, 24.99),
(2, 'USB Cable', 5, 9.99),
(2, 'Keyboard', 1, 49.99),

-- Order 3 items (Jane Smith - Order 1)
(3, 'Phone Case', 3, 19.99),
(3, 'Screen Protector', 2, 14.99),

-- Order 4 items (Mike Johnson - Order 1)
(4, 'Gaming Chair', 1, 299.99),
(4, 'Desk Lamp', 1, 75.00),
(4, 'Monitor Stand', 1, 75.01),

-- Order 5 items (Mike Johnson - Order 2)
(5, 'Coffee Mug', 2, 12.25),
(5, 'Notebook', 5, 8.50),
(5, 'Pen Set', 1, 15.25),

-- Order 6 items (Sarah Wilson - Order 1)
(6, 'Smartphone', 1, 199.99),

-- Order 7 items (David Brown - Order 1)
(7, 'Bluetooth Headphones', 1, 149.99),
(7, 'Power Bank', 2, 39.99),
(7, 'Phone Charger', 3, 15.99),
(7, 'Car Mount', 1, 24.99);

-- Verification queries
SELECT 'Customers' as TableName, COUNT(*) as RecordCount FROM dbo.Customers
UNION ALL
SELECT 'Orders', COUNT(*) FROM dbo.Orders
UNION ALL
SELECT 'OrderItems', COUNT(*) FROM dbo.OrderItems;

-- Sample query to see all data together
SELECT 
    c.Name as CustomerName,
    c.Email,
    o.OrderId,
    o.OrderDate,
    o.Status,
    o.TotalAmount,
    oi.ProductName,
    oi.Quantity,
    oi.UnitPrice,
    (oi.Quantity * oi.UnitPrice) as LineTotal
FROM dbo.Customers c
INNER JOIN dbo.Orders o ON c.CustomerId = o.CustomerId
INNER JOIN dbo.OrderItems oi ON o.OrderId = oi.OrderId
ORDER BY c.Name, o.OrderDate, oi.ProductName;
