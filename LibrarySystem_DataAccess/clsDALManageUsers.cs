using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALManageUsers
    {
        static string _Path = clsDALPathConnection.Path;
        
        static public bool _GetInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref bool Permeation, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Users
                                              WHERE UserID = @UserID", connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    Permeation = (bool)reader["Permeation"];
                    IsActive = (bool)reader["IsActive"];

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _GetInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref bool Permeation, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT * 
                                              FROM Users
                                              WHERE PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    Permeation = (bool)reader["Permeation"];
                    IsActive = (bool)reader["IsActive"];

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        } 

        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,ref int UserID, ref int PersonID, ref bool Permeation, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand command = new SqlCommand(@"SELECT * FROM Users WHERE Username = @Username and Password = @Password;", connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Permeation = (bool)reader["Permeation"];
                    IsActive = (bool)reader["IsActive"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        static public int _AddNewUser(int PersonID, string UserName,string Password , bool Permeation, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Users]([PersonID],[UserName],[Permeation],[Password],[IsActive])
                                              VALUES (@PersonID , @UserName , @Permeation , @Password , @IsActive )
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Permeation", Permeation);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int result))
                    return result;
                else return -1;
                    

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }

        }

        static public bool _UpdateUser(int UserID, int PersonID, string UserName, bool Permeation, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Users]
                                              SET 
                                              [PersonID] = @PersonID ,
                                              [UserName] = @UserName ,
                                              [Password] = @Password ,
                                              [Permeation] = @Permeation ,
                                              [IsActive] = @IsActive 
                                              WHERE UserID = @UserID", connection);


            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Permeation", Permeation);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _DeleteUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Users] WHERE UserID = @UserID", connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return RowAffected > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public DataTable _GetAllDataUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT Users.UserID, Users.PersonID, FullName =( People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName), Users.UserName, Users.Permeation , Users.IsActive
                                              FROM Users INNER JOIN People ON Users.PersonID = People.PersonID", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { connection.Close(); }

            return dt;

        }

        static public bool _IsExistByUserID(int UserID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from Users where UserID = @UserID", connection);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool result = reader.HasRows ? true : false;

                reader.Close();

                return result;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExistByPersonID(int PersonID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from Users where PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool result = reader.HasRows ? true : false;

                reader.Close();

                return result;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExistByUserName(string UserName)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from Users where UserName = @UserName", connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool result = reader.HasRows ? true : false;

                reader.Close();

                return result;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _ChangePassword(int UserID, string NewPassword)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Users]
                                              SET 
                                              [Password] = @NewPassword 
                                              WHERE UserID = @UserID", connection);


            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@NewPassword", NewPassword);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

    }
}
