using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class CategoryClass
    {
        private int categoryID;
        private string category;
        public CategoryClass(int CategoryID, string Category)
        {
            this.categoryID = CategoryID;
            this.category = Category;
        }
        public int CategoryID
        {
            set { categoryID = value; }
            get { return categoryID; }
        }
        public string Category
        {
            set { category = value; }
            get { return category; }
        }
    }
}
