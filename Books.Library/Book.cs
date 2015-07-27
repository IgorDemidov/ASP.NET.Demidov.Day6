using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Task1.Library
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {

        #region Properties

        public string Author { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int PageCount { get; set; }
        public int ImprintDate { get; set; }

        #endregion

        #region Constructors

        public Book(string author, string title, string category, int pageCount, int imprintDate)
        {
            Author = author;
            Title = title;
            Category = category;
            PageCount = pageCount;
            ImprintDate = imprintDate;
        }
        public Book()
            : this("None", "None", "None", 0, 0){}

        #endregion

        #region Object methods overriding

        public override int GetHashCode()
        {
            int hash = 313;
            unchecked
            {
                hash = ((hash << 5) + hash) + Author.GetHashCode();
                hash = ((hash << 5) + hash) + Title.GetHashCode();
                hash = ((hash << 5) + hash) + Category.GetHashCode();
                hash = ((hash << 5) + hash) + PageCount.GetHashCode();
                hash = ((hash << 5) + hash) + ImprintDate.GetHashCode();
            }            
            return hash;
        }

        public override bool Equals(object obj)
        {
            Book objAsBook = obj as Book;  
            return this.Equals(objAsBook);
        } 

        #endregion

        #region IEquatable<Book> implementation

        public bool Equals(Book other)
        {
            if (other == null)
                return false;
            if (this.Author == other.Author)
                if (this.Title == other.Title)
                    if (this.Category == other.Category)
                        if (this.PageCount == other.PageCount)
                            if (this.ImprintDate == other.ImprintDate)
                                return true;
            return false;
        }

	    #endregion

        #region IComparable<Book> implementation

        public int CompareTo(Book other)
        {
            return this.Title.CompareTo(other.Title);
        }

        #endregion
 
    }
}
