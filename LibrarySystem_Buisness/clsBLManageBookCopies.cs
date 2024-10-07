using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_Buisness
{
    public class clsBLManageBookCopies
    {
        public int CopyID { set; get; }
        public int BookID{ set; get; }
        public bool AvailabilityStatus { set; get; }


        public clsBLManageBookCopies()
        {
            CopyID = -1;
            BookID = -1;
            AvailabilityStatus = false;
        }

        public clsBLManageBookCopies(int copyID, int bookID, bool availabilityStatus)
        {
            CopyID = copyID;
            BookID = bookID;
            AvailabilityStatus = availabilityStatus;
        }


        public static clsBLManageBookCopies Find(int CopyID)
        {
            int bookID = -1;
            bool availabilityStatus = false;

            if(clsDALManageBookCopies._GetCopyBookInfo(CopyID ,ref bookID , ref availabilityStatus))
                return new clsBLManageBookCopies(CopyID , bookID , availabilityStatus);
            else return null;
        }


        public bool AddCopies(int NumberOFCopies)
        {
            return clsDALManageBookCopies._AddCopies(NumberOFCopies, BookID, AvailabilityStatus);
        }

        public bool UpdateCopyStatus(bool availabilityStatus) 
        {
            return clsDALManageBookCopies._UpdateCopyStatus(CopyID, availabilityStatus);
        }

        public static bool Delete(int CopyID)
        {
            return clsDALManageBookCopies._DeleteBook(CopyID);
        }

        static public bool IsExist(int CopyID)
        {
            return clsDALManageBookCopies._IsExist(CopyID);
        }

        public bool GetCopyIdForAvailableCopy(int BookID)
        {
            CopyID = clsDALManageBookCopies._GetCopyIdForAvailableCopy(BookID);

            return (CopyID != -1);
        }


    }
}
