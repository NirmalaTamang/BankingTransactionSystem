-- Create the database
CREATE DATABASE IF NOT EXISTS banking_transaction_system;

-- Use the database
USE banking_transaction_system;

-- Create accounts table
CREATE TABLE IF NOT EXISTS accounts (
    account_number INT AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(50) NOT NULL UNIQUE,
    pin_code INT NOT NULL,
    holder_name VARCHAR(100) NOT NULL,
    balance DECIMAL(12,2) NOT NULL,
    status VARCHAR(20) NOT NULL,
    role VARCHAR(20) NOT NULL
);

-- Insert sample admin account
INSERT INTO accounts (login, pin_code, holder_name, balance, status, role)
VALUES ('admin1', 12345, 'System Administrator', 0.00, 'Active', 'Admin');

-- Insert sample customer account
INSERT INTO accounts (login, pin_code, holder_name, balance, status, role)
VALUES ('Adnan123', 12345, 'Adnan Khan', 150000.00, 'Active', 'Customer');