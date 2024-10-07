using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibrarySystem_Buisness
{
    public class clsBLManageBooks
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew; 

        public int BookID { set; get; }
        public string Title{ set; get; }
        public string ISBN { set; get; }
        public DateTime PublicationDate { set; get; }
        public string Genre { set; get; }
        public string AdditionalDetails { set; get; }


        public clsBLManageBooks()
        {
            BookID = -1;
            Title = "";
            ISBN = "";
            PublicationDate = DateTime.Now;
            Genre = "";
            AdditionalDetails = "";

            Mode = enMode.AddNew;
        }

        public clsBLManageBooks(int bookID, string title, string iSBN, DateTime publicationDate, string genre, string additionalDetails)
        {
            BookID = bookID;
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            Genre = genre;
            AdditionalDetails = additionalDetails;

            Mode = enMode.Update;
        }
        

        public static clsBLManageBooks Find(int BookID)
        {
            string title = "";
            string iSBN = "";
            DateTime publicationDate = DateTime.Now ;
            string genre = "";
            string additionalDetails = "";

            if (clsDALManageBooks._GetBookInfo(BookID, ref title, ref iSBN, ref publicationDate, ref genre, ref additionalDetails))
            {
                return new clsBLManageBooks(BookID, title, iSBN, publicationDate, genre, additionalDetails);
            }
            else
                return null;
        }


        public bool AddBook()
        {
            BookID = clsDALManageBooks._AddBook(Title, ISBN, PublicationDate, Genre, AdditionalDetails);
            return BookID != -1;
        }

        public bool UpdateBookInfo()
        {
            return clsDALManageBooks._UpdateBookInfo(BookID, Title, ISBN, PublicationDate, Genre, AdditionalDetails);
        }

        public static bool Delete(int BookID)
        {
            return clsDALManageBooks._DeleteBook(BookID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddBook())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return UpdateBookInfo();

            }

            return false;
        }


        public static bool IsExist(int BookID)
        {
            return clsDALManageBooks._IsExist(BookID);
        }

        public static DataTable getAllDataBooks()
        {
            return clsDALManageBooks._GetAllBookData();
        }

        public static DataTable getAvailableBookData()
        {
            return clsDALManageBooks._GetAvailableBookData();
        }

        static public DataTable GetBookBy(int PersonID)
        {
            return clsDALManageBooks._GetBookBy(PersonID);
        }


    }
}
