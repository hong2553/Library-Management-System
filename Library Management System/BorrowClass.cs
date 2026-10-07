using System.ComponentModel;

namespace Library_Management_System
{
    public class BorrowClass
    {
        public const int LoanDays = 14;

        public int BorrowID { get; set; }

        [Browsable(false)]
        public int MemberID { get; set; }

        [DisplayName("Member")]
        public string MemberName { get; set; } = "";     // from tblMember.M_Name

        [Browsable(false)]
        public int BookID { get; set; }

        [DisplayName("Book")]
        public string BookTitle { get; set; } = "";      // from tblBook.Title

        [DisplayName("Borrowed")]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        [DisplayName("Returned")]
        public DateTime? ReturnDate { get; set; }        // NULL = still borrowed

        // ---- Computed in C#, never stored in SQL ----

        [DisplayName("Due")]
        public DateTime DueDate => BorrowDate.Date.AddDays(LoanDays);

        [Browsable(false)]
        public bool IsReturned => ReturnDate.HasValue;

        [Browsable(false)]
        public bool IsOverdue => !IsReturned && DueDate < DateTime.Today;

        [DisplayName("Status")]
        public string Status =>
            IsReturned ? "Returned" :
            IsOverdue  ? "Overdue"  :
                         "Borrowed";

        public BorrowClass() { }

        public BorrowClass(int borrowID, int memberID, int bookID,
                           DateTime borrowDate, DateTime? returnDate = null,
                           string memberName = "", string bookTitle = "")
        {
            BorrowID = borrowID;
            MemberID = memberID;
            BookID = bookID;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
            MemberName = memberName;
            BookTitle = bookTitle;
        }
    }
}
