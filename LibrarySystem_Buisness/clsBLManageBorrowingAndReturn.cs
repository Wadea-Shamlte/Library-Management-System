using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_Buisness
{
    public class clsBLManageBorrowingAndReturn
    {
        public int BorrowingRecordID{ set; get; }
        public int PersonID { set; get; }
        public int CopyID { set; get; }
        public DateTime BorrowingDate { set; get; }
        public DateTime DueDate { set; get; }
        public DateTime? ActualReturnDate { set; get; }

        public clsBLManageBorrowingAndReturn()
        {
            BorrowingRecordID = -1;
            PersonID = -1;
            CopyID = -1;
            BorrowingDate = DateTime.Now;
            DueDate = DateTime.Now;
            ActualReturnDate = DateTime.Now;
        }

        public clsBLManageBorrowingAndReturn(int borrowingRecordID, int personID, int copyID, DateTime borrowingDate, DateTime dueDate, DateTime? actualReturnDate)
        {
            BorrowingRecordID = borrowingRecordID;
            PersonID = personID;
            CopyID = copyID;
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
            ActualReturnDate = actualReturnDate;
        }


        public static clsBLManageBorrowingAndReturn _Find(int BorrowingRecordID)
        {
            int personID = -1;
            int copyID = -1;
            DateTime borrowingDate = DateTime.Now;
            DateTime dueDate = DateTime.Now;
            DateTime? actualReturnDate = DateTime.Now;

            if (clsDALManageBorrowingAndReturn._GetRecordInfo(BorrowingRecordID, ref personID, ref copyID, ref borrowingDate, ref dueDate, ref actualReturnDate))
                return new clsBLManageBorrowingAndReturn(BorrowingRecordID, personID, copyID, borrowingDate, dueDate, actualReturnDate);
            else return null;   
        }

        public static clsBLManageBorrowingAndReturn _FindByCopyID(int copyID)
        {
            int BorrowingRecordID = -1;
            int personID = -1;
            DateTime borrowingDate = DateTime.Now;
            DateTime dueDate = DateTime.Now;
            DateTime? actualReturnDate = DateTime.Now;

            if (clsDALManageBorrowingAndReturn._GetRecordByCopyID(copyID, ref personID, ref BorrowingRecordID, ref borrowingDate, ref dueDate, ref actualReturnDate))
                return new clsBLManageBorrowingAndReturn(BorrowingRecordID, personID, copyID, borrowingDate, dueDate, actualReturnDate);
            else return null;
        }



        public bool BorrowingRecord()
        {
            BorrowingRecordID = clsDALManageBorrowingAndReturn._BorrowingRecord(PersonID, CopyID, BorrowingDate, DueDate, ActualReturnDate);
            return BorrowingRecordID != -1;
        }

        public bool ReturnRecord()
        {
            return clsDALManageBorrowingAndReturn._ReturnRecord(BorrowingRecordID, PersonID, CopyID, BorrowingDate, DueDate, ActualReturnDate);
        }


        public static DataTable GetAllRecord()
        {
            return clsDALManageBorrowingAndReturn._GetAllRecord();
        }

        public static int CheckBorrowingNumber(int PersonID)
        {
            return clsDALManageBorrowingAndReturn._CheckBorrowingNumber(PersonID);
        }


    }
}
