using System.ComponentModel;

namespace Library_Management_System
{
    /// <summary>
    /// A row of tblBook (plus the category name from tblCategories).
    /// Public properties so DataGridView / BindingSource can see them.
    /// </summary>
    public class BookClass
    {
        public int BookID { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";

        [Browsable(false)]                 // hidden in the grid, still used in code
        public int CategoryID { get; set; }

        [DisplayName("Category")]          // grid header text
        public string CategoryName { get; set; } = "";

        public int Quantity { get; set; }

        public BookClass() { }

        public BookClass(int bookID, string title, string author,
                         int categoryID, int quantity, string categoryName = "")
        {
            BookID = bookID;
            Title = title;
            Author = author;
            CategoryID = categoryID;
            Quantity = quantity;
            CategoryName = categoryName;
        }
    }
}