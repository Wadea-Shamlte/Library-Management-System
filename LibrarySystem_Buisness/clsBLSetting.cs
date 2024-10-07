using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_Buisness
{
    public class clsBLSetting
    {
        static public decimal GetDefaultBorrowDays()
        {
            return clsDALSetting._GetDefaultBorrowDays();  
        }

        static public decimal GetDefaultFinePerDay()
        {
            return clsDALSetting._GetDefaultFinePerDay();
        }

        static public bool UpdateDefaultBorrowDays(decimal NewDefaultBorrowDays)
        {
            return clsDALSetting._UpdateDefaultBorrowDays(NewDefaultBorrowDays);
        }

        static public bool _UpdateDefaultFinePerDay(decimal NewDefaultFinePerDay)
        {
            return clsDALSetting._UpdateDefaultFinePerDay(NewDefaultFinePerDay);
        }
    }
}
