using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibrarySystem_DataAccess;


namespace LibrarySystem_Business
{
    public class clsBLManagePeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string NationalNo{ set; get; } 
        public string FName { set; get; }
        public string SName { set; get; }
        public string ThName { set; get; }
        public string LName { set; get; }
        public string FullName { get { return FName + " " + SName + " " + ThName + " " + LName; } }
        public int Gender { set; get; }
        public string Phone { set; get; }
        public string NationalCardImagePath { set; get; }

        public clsBLManagePeople()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FName = "";
            this.SName = "";
            this.ThName = "";
            this.LName = "";
            this.Gender = -1;
            this.Phone = "";
            this.NationalCardImagePath = "";

            Mode = enMode.AddNew;
        }

        public clsBLManagePeople(int personID, string nationalNo, string fName, string sName, string thName, string lName,
                                      int gender, string phone, string nationalCardImagePath)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FName = fName;
            this.SName = sName;
            this.ThName = thName;
            this.LName = lName;
            this.Gender = gender;
            this.Phone = phone;
            this.NationalCardImagePath = nationalCardImagePath;

            Mode = enMode.Update;
        }

        public static clsBLManagePeople Find(int PersonID)
        {
            string nationalNo = "";
            string fName = "";
            string sName = "";
            string thName = "";
            string lName = "";
            int gender = -1 ;
            string phone = "";
            string nationalCardImagePath = "";

            if (clsDALManagePeople._getInfo(PersonID, ref nationalNo, ref fName, ref sName, ref gender, ref thName, ref lName, ref phone, ref nationalCardImagePath))
                return new clsBLManagePeople(PersonID, nationalNo, fName, sName, thName, lName, gender, phone, nationalCardImagePath);
            else return null;
        }

        public static clsBLManagePeople Find(string NationalNo)
        {
            int personID = -1;
            string fName = "";
            string sName = "";
            string thName = "";
            string lName = "";
            int gender = -1;
            string phone = "";
            string nationalCardImagePath = "";

            if (clsDALManagePeople._getInfo(NationalNo, ref personID, ref fName, ref sName, ref gender, ref thName, ref lName, ref phone, ref nationalCardImagePath))
                return new clsBLManagePeople(personID , NationalNo, fName, sName, thName, lName, gender, phone, nationalCardImagePath);
            else return null;
        }

        bool _Add()
        {
            PersonID = clsDALManagePeople._AddPerson(NationalNo, FName, SName, ThName, LName, Gender, Phone, NationalCardImagePath);

            return PersonID != -1;
        }

        bool _Update()
        {
            return clsDALManagePeople._UpdatePerson(PersonID, NationalNo, FName, SName, ThName, LName, Gender, Phone, NationalCardImagePath);
        }

        public static bool Delete(int PersonID)
        {
            return clsDALManagePeople._DeletePerson(PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public static DataTable GetAllData()
        {
            return clsDALManagePeople._getAllData();
        }

        public static bool IsExist(int PersonID)
        {
            return clsDALManagePeople._IsExist(PersonID);
        }

        public static bool IsExist(string NationalNo)
        {
            return clsDALManagePeople._IsExist(NationalNo);
        }


    }
}
