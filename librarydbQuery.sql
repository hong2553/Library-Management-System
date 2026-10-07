CREATE DATABASE librarydb;
USE librarydb;

CREATE TABLE tblCategories (
	CategoryID SMALLINT PRIMARY KEY,
	Category VARCHAR(20)
)

CREATE TABLE tblBook (
	BookID INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(50),
	Author VARCHAR(25),
	CategoryID SMALLINT FOREIGN KEY REFERENCES tblCategories(CategoryID)
	ON UPDATE CASCADE ON DELETE CASCADE,
	Quantity SMALLINT
)

CREATE TABLE tblMember (
	MemberID INT IDENTITY(1,1) PRIMARY KEY,
	M_Name VARCHAR(25),
	M_Gender CHAR,
	M_Phone VARCHAR(12) UNIQUE,
	RegisterDate DATETIME DEFAULT CURRENT_TIMESTAMP
)

CREATE TABLE tblBorrow (
	BorrowID INT IDENTITY(1,1) PRIMARY KEY,
	MemberID INT FOREIGN KEY REFERENCES tblMember(MemberID)
	ON UPDATE CASCADE ON DELETE CASCADE,
	BookID INT FOREIGN KEY REFERENCES tblBook(BookID)
	ON UPDATE CASCADE ON DELETE CASCADE,
	BorrowDate DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReturnDate DATETIME
)

USE librarydb;

-- Insert order matters: parent tables first (tblCategories, tblBook, tblMember), then tblBorrow.

INSERT INTO tblCategories (CategoryID, Category) VALUES
(1, 'Fiction'),
(2, 'Science'),
(3, 'History'),
(4, 'Technology'),
(5, 'Biography'),
(6, 'Fantasy'),
(7, 'Mystery'),
(8, 'Self-Help'),
(9, 'Philosophy'),
(10, 'Children');

INSERT INTO tblBook (Title, Author, CategoryID, Quantity) VALUES
('To Kill a Mockingbird', 'Harper Lee', 1, 5),
('A Brief History of Time', 'Stephen Hawking', 2, 4),
('Sapiens', 'Yuval Noah Harari', 3, 6),
('Clean Code', 'Robert C. Martin', 4, 3),
('Steve Jobs', 'Walter Isaacson', 5, 2),
('The Hobbit', 'J.R.R. Tolkien', 6, 7),
('And Then There Were None', 'Agatha Christie', 7, 4),
('Atomic Habits', 'James Clear', 8, 8),
('Meditations', 'Marcus Aurelius', 9, 3),
('Charlotte''s Web', 'E.B. White', 10, 5);

INSERT INTO tblMember (M_Name, M_Gender, M_Phone) VALUES
('Sokha Chan', 'M', '012345678'),
('Sreymom Keo', 'F', '015234567'),
('Vannak Heng', 'M', '017345678'),
('Dara Sok', 'M', '010456789'),
('Srey Neang Lim', 'F', '096567890'),
('Rithy Pov', 'M', '098678901'),
('Chantha Meas', 'F', '011789012'),
('Bopha Ouk', 'F', '069890123'),
('Visal Ny', 'M', '085901234'),
('Kunthea Prak', 'F', '092012345');

INSERT INTO tblBorrow (MemberID, BookID, BorrowDate, ReturnDate) VALUES
(1, 2, '2026-09-01 09:00:00', '2026-09-10 14:30:00'),
(2, 6, '2026-09-02 10:15:00', '2026-09-12 11:00:00'),
(3, 4, '2026-09-03 13:45:00', '2026-09-15 16:20:00'),
(4, 8, '2026-09-05 08:30:00', '2026-09-14 09:10:00'),
(5, 1, '2026-09-08 11:00:00', '2026-09-18 15:00:00'),
(6, 2, '2026-09-10 14:00:00', '2026-10-02 13:00:00'),
(7, 10, '2026-09-12 09:30:00', '2026-09-20 10:45:00'),
(8, 17, '2026-09-15 15:10:00', '2026-10-02 15:00:00'),
(9, 19, '2026-09-18 12:00:00', '2026-10-02 20:00:00'),
(10, 5, '2026-09-20 10:00:00', '2026-10-02 11:00:00');

SELECT * FROM tblBorrow
SELECT * FROM tblMember
SELECT * FROM tblCategories
SELECT * FROM tblBook