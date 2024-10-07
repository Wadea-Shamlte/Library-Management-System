using LibrarySystem_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_Buisness
{
    public class clsBLManageUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { set; get; }
        public int PersonID { set; get; }
        public string UserName { set; get; }
        public bool Permeation { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }

        public clsBLManageUsers()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Permeation = false;
            Password = "";
            IsActive = false;

            Mode = enMode.AddNew;
        }

        public clsBLManageUsers(int userID, int personID, string userName, string password ,bool permeation , bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Permeation = permeation;
            Password = password;
            IsActive = isActive;

            Mode = enMode.Update;

        }


        public static clsBLManageUsers FindByByUserID(int UserID)
        {
            int personID = -1;
            string userName = "";
            bool permeation = false;
            string password = "";
            bool isActive = false;

            if (clsDALManageUsers._GetInfoByUserID(UserID, ref personID, ref userName, ref permeation, ref password, ref isActive))
                return new clsBLManageUsers(UserID , personID, userName, password, permeation, isActive);
            else return null;
        }

        public static clsBLManageUsers FindByPersonID(int PersonID)
        {
            int userID = -1;
            string userName = "";
            bool permeation = false;
            string password = "";
            bool isActive = false;

            if (clsDALManageUsers._GetInfoByUserID(PersonID, ref userID, ref userName, ref permeation, ref password, ref isActive))
                return new clsBLManageUsers(userID, PersonID, userName, password, permeation, isActive);
            else return null;
        }

        public static clsBLManageUsers GetUserInfoByUsernameAndPassword(string UserName, string Password)
        {
            int userID = -1;
            int personID = -1;
            bool permeation = false;
            bool isActive = false;

            if (clsDALManageUsers.GetUserInfoByUsernameAndPassword(UserName, Password, ref userID, ref personID, ref permeation, ref isActive))
                return new clsBLManageUsers(userID, personID, UserName, Password, permeation, isActive);
            else return null;
        }


        public bool Add()
        {
            UserID = clsDALManageUsers._AddNewUser(PersonID , UserName , Password , Permeation , IsActive );

            return UserID != -1;
        }

        public bool Update()
        {
            return clsDALManageUsers._UpdateUser(UserID , PersonID , UserName , Permeation , Password , IsActive );
        }

        public static bool Delete(int UserID)
        {
            return clsDALManageUsers._DeleteUser(UserID);
        }
        
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (Add())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return Update();

            }

            return false;
        }


        public static DataTable GetAllData()
        {
            return clsDALManageUsers._GetAllDataUsers();
        }


        public static bool IsExistByUserID(int UserID)
        {
            return clsDALManageUsers._IsExistByUserID(UserID);
        }

        public static bool IsExistByPersonID(int PersonID)
        {
            return clsDALManageUsers._IsExistByPersonID((PersonID));
        }

        public static bool IsExistByUserName(string UserName)
        {
            return clsDALManageUsers._IsExistByUserName((UserName));
        }


        public static bool ChangePassword(int UserID, string NewPassword)
        {
            return clsDALManageUsers._ChangePassword(UserID, NewPassword);
        }

    }
}
