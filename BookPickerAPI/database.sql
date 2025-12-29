CREATE DATABASE booksDb;

USE booksDb;

CREATE TABLE books (
    id INT PRIMARY KEY IDENTITY(1,1),
    title NVARCHAR(255) NOT NULL,
    author NVARCHAR(255),
    isPaper BIT,
    status NVARCHAR(50),
    lastModified TIMESTAMP
);
