LIBRARY MANAGEMENT SYSTEM
USER INTERFACE GUIDE
====================

This guide explains how to use the Library Management System interface
and its main features.


1. MAIN DASHBOARD
-----------------

When you start the application, the Main Dashboard appears.

The dashboard provides access to the main functions of the library system:

- Books - Manage library books.
- Members - Manage library members.
- Borrow / Return - Manage borrowed and returned books.
- Dashboard / Home - View general library information and statistics.

Use the menu or buttons on the main interface to open the section you want.


2. BOOKS INTERFACE
------------------

The Books interface is used to manage all books in the library.

The book list displays information such as:

- Book ID
- Title
- Author
- Category
- Quantity


ADDING A BOOK

To add a new book:

1. Open the Books interface.
2. Enter the book Title.
3. Enter the Author name.
4. Select a Category.
5. Enter the Quantity.
6. Click the Add / Insert button.
7. The new book will appear in the book list.


SELECTING A BOOK

Click a book from the table to select it.

The selected book's information will appear in the input fields.
You can then edit or delete the selected book.


UPDATING A BOOK

To update book information:

1. Select a book from the table.
2. Change the information you want to modify.
3. Click the Update button.
4. The book information will be updated in the database.


DELETING A BOOK

To delete a book:

1. Select the book from the table.
2. Click the Delete button.
3. Confirm the deletion if a confirmation message appears.

Note:
A book that is still referenced by borrowing records may not be
allowed to be deleted.


SEARCHING FOR BOOKS

The search function allows you to find books quickly.

You can search using:

- Book ID
- Title
- Author
- Category

Example:

    Title : Harry

or:

    Author : Orwell

The table will display the matching results.


3. MEMBERS INTERFACE
--------------------

The Members interface is used to manage people who are registered
with the library.

The member list can contain:

- Member ID
- Member Name
- Gender
- Phone Number
- Registration Date


ADDING A MEMBER

To register a new member:

1. Open the Members interface.
2. Enter the member's name.
3. Select the member's gender.
4. Enter the phone number.
5. Select the registration date.
6. Click Insert Member.
7. The new member will appear in the member list.

The Member ID is generated automatically.


UPDATING A MEMBER

To update member information:

1. Select a member from the table.
2. Change the required information.
3. Click Update.
4. The updated information will appear in the table.


DELETING A MEMBER

To delete a member:

1. Select the member from the table.
2. Click Delete.
3. Confirm the deletion.

A member who currently has an unreturned book should return the book
before the member can be deleted.


4. BORROW / RETURN INTERFACE
----------------------------

The Borrow / Return interface is used to manage the process of
borrowing and returning books.

This interface normally contains:

- Member selection
- Book selection
- Borrow date
- Return date
- Borrowing records
- Search function


BORROWING A BOOK

To record a new book borrowing:

1. Open the Borrow / Return interface.
2. Select the member who wants to borrow a book.
3. Select an available book.
4. Select the Borrow Date.
5. Click the Borrow button.
6. The borrowing record will be added to the system.

The system checks the available quantity before allowing the book
to be borrowed.

The available quantity of the selected book is reduced when the
borrowing is recorded.


DUE DATE

After a book is borrowed, the system calculates and displays the
expected Due Date.

The due date helps the librarian determine when the book should
be returned.


RETURNING A BOOK

To return a borrowed book:

1. Open the Borrow / Return interface.
2. Find the active borrowing record.
3. Select the book being returned.
4. Select the Return Date.
5. Click the Return button.
6. The borrowing record will be updated.

When the book is returned, its available quantity is increased
automatically.

If the book is returned after the due date, the system can display
the number of days the book is overdue.


5. SEARCHING BORROWING RECORDS
------------------------------

The Borrow / Return interface also provides a search function.

You can search using:

- Borrow ID
- Member ID

To search:

1. Enter the ID you want to search for.
2. Click Search.
3. The matching borrowing records will be displayed.

To display all records again, clear the search field and perform
the search again.


6. WORKING WITH TABLES
----------------------

Most interfaces display information in a table.

SELECTING A RECORD

Click a row in the table to select it.

The selected record can then be used for operations such as:

- Update
- Delete
- Return
- Viewing information


REFRESHING DATA

After adding, updating, deleting, borrowing, or returning a record,
the table may refresh automatically.

If the table does not immediately show the latest information,
use the available refresh/reload function or reopen the corresponding
interface.


7. RECOMMENDED ORDER OF USE
---------------------------

For a new library system, it is recommended to use the application
in the following order:

STEP 1 - ADD CATEGORIES

Create the book categories that will be used by the library.

STEP 2 - ADD BOOKS

Add books and assign each book to a category.

STEP 3 - ADD MEMBERS

Register the people who are allowed to borrow books.

STEP 4 - BORROW BOOKS

Select a member and an available book, then create a borrowing record.

STEP 5 - RETURN BOOKS

When a book is returned, select the borrowing record and record
the return.

STEP 6 - CHECK RECORDS

Use the tables and search functions to check:

- Books
- Members
- Available quantities
- Active borrowings
- Returned books
- Borrowing history


8. IMPORTANT INTERFACE RULES
----------------------------

Keep the following rules in mind when using the system:

- A book must have available quantity before it can be borrowed.
- A member should be registered before borrowing a book.
- Required fields should be completed before adding a record.
- Select a record from the table before using Update or Delete.
- A borrowed book should be returned before the member is removed.
- Returning a book increases its available quantity.
- Search fields can be used to quickly find specific records.


9. BASIC USER WORKFLOW
----------------------

The normal workflow of the Library Management System is:

    Main Dashboard
          |
          +---- Books
          |      |
          |      +---- Add Book
          |      +---- Update Book
          |      +---- Delete Book
          |      +---- Search Book
          |
          +---- Members
          |      |
          |      +---- Add Member
          |      +---- Update Member
          |      +---- Delete Member
          |
          +---- Borrow / Return
                 |
                 +---- Borrow Book
                 +---- Return Book
                 +---- Search Borrow Records

Following this workflow makes it easier to manage the library's
books, members, and borrowing records.


END OF USER INTERFACE GUIDE
