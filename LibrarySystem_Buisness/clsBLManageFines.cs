using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_Buisness
{
    public class clsBLManageFines
    {
        public int FineID { set; get; }
        public int PersonID { set; get; }
        public int BorrowingRecordID { set; get; }
        public short NumberOfLateDays { set; get; }
        public decimal FineAmount { set; get; }
        public bool PaymentStatus { set; get; }

        public clsBLManageFines()
        {
            FineID = -1;
            PersonID = -1;
            BorrowingRecordID = -1;
            NumberOfLateDays = -1;
            FineAmount = 0;
            PaymentStatus = false;
        }

        public clsBLManageFines(int fineID, int personID, int borrowingRecordID, short numberOfLateDays, decimal fineAmount, bool paymentStatus)
        {
            FineID = fineID;
            PersonID = personID;
            BorrowingRecordID = borrowingRecordID;
            NumberOfLateDays = numberOfLateDays;
            FineAmount = fineAmount;
            PaymentStatus = paymentStatus;
        }


        public static clsBLManageFines Find(int FineID)
        {
            int personID = -1;
            int borrowingRecordID = -1;
            short numberOfLateDays = -1;
            decimal fineAmount = 0;
            bool paymentStatus = false;

            if (clsDALManageFines._GetFine(FineID, ref personID, ref borrowingRecordID, ref numberOfLateDays, ref fineAmount, ref paymentStatus))
                return new clsBLManageFines(FineID, personID, borrowingRecordID, numberOfLateDays, fineAmount, paymentStatus);
            else return null;
        }

        public static clsBLManageFines FindByBorrowingID(int borrowingRecordID)
        {
            int personID = -1;
            int fineID = -1;
            short numberOfLateDays = -1;
            decimal fineAmount = 0;
            bool paymentStatus = false;

            if (clsDALManageFines._GetFineByBorrowingID(borrowingRecordID, ref personID, ref fineID, ref numberOfLateDays, ref fineAmount, ref paymentStatus))
                return new clsBLManageFines(fineID, personID, borrowingRecordID, numberOfLateDays, fineAmount, paymentStatus);
            else return null;
        }



        public bool AddFine()
        {
            FineID = clsDALManageFines._AddFine(PersonID, BorrowingRecordID, NumberOfLateDays, FineAmount, PaymentStatus);
            return FineID != -1;
        }

        public bool UpdatePaymentStatus(bool PaymentStatus)
        {
            return clsDALManageFines._UpdatePaymentStatus(FineID, PaymentStatus);
        }


        public static DataTable getAllFine()
        {
            return clsDALManageFines._GetAllFine();
        }

        public static bool IsExist(int FineID)
        {
            return clsDALManageFines._IsExist(FineID);
        }
    }
}
