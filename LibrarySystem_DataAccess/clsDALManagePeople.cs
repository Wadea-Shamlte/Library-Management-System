using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LibrarySystem_DataAccess
{
    public class clsDALManagePeople
    {
        static string _Path = clsDALPathConnection.Path;

        static public bool _getInfo(int PersonID, ref string NationalNo, ref string FName, ref string SName, ref int Gender ,
                                                ref string ThName, ref string LName ,ref string Phone, ref string NationalCardImagePath)
        {
            bool Find = false;
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT 
                                              *
                                              FROM People 
                                              where PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Find = true;

                    NationalNo = (string)reader["NationalNo"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];
                    ThName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LName = (string)reader["LastName"];
                    Gender = (int)reader["Gender"];
                    Phone = (string)reader["Phone"];
                    NationalCardImagePath = reader["NationalCardImagePath"] != DBNull.Value ? (string)reader["NationalCardImagePath"] : "";

                    reader.Close();
                    
                }
                else
                    reader.Close();
                return Find;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
            
        }

        static public bool _getInfo(string NationalNo, ref int PersonID, ref string FName, ref string SName, ref int Gender,
                                                ref string ThName, ref string LName, ref string Phone, ref string NationalCardImagePath)
        {
            bool Find = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT 
                                              *
                                              FROM People 
                                              where NationalNo = @NationalNo", connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Find = true;

                    PersonID = (int)reader["PersonID"];
                    FName = (string)reader["FirstName"];
                    SName = (string)reader["SecondName"];
                    ThName = reader["ThirdName"] != DBNull.Value ? (string)reader["ThirdName"] : "";
                    LName = (string)reader["LastName"];
                    Gender = (int)reader["Gender"];
                    Phone = (string)reader["Phone"];
                    NationalCardImagePath = reader["NationalCardImagePath"] != DBNull.Value ? (string)reader["NationalCardImagePath"] : "";

                    reader.Close();
                }
                else
                    reader.Close();
                return Find;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public int _AddPerson(string NationalNo, string FName, string SName, string ThName, string LName,
                                      int Gender, string Phone, string NationalCardImagePath)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[People]
                                              ([NationalNo],[FirstName],[SecondName],[ThirdName],
                                              [LastName],[Gender],[Phone],[NationalCardImagePath])
                                              VALUES
                                              (@NationalNo, @FirstName, @SecondName, @ThirdName, 
                                              @LastName, @Gender, @Phone, @NationalCardImagePath);
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@SecondName", SName);
            cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThName) ? (object)DBNull.Value : ThName);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@NationalCardImagePath", string.IsNullOrEmpty(NationalCardImagePath) ? (object)DBNull.Value : NationalCardImagePath);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Result))
                    return Result;
                else
                    return -1;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }

        }

        static public bool _UpdatePerson(int PersonID, string NationalNo, string FName, string SName, string ThName, string LName,
                                      int Gender, string Phone, string NationalCardImagePath)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[People]
                                              SET [NationalNo] = @NationalNo, [FirstName] = @FirstName,
                                              [SecondName] = @SecondName, [ThirdName] = @ThirdName, 
                                              [LastName] = @LastName, [Gender] = @Gender,
                                              [Phone] = @Phone, [NationalCardImagePath] = @NationalCardImagePath
                                              WHERE PersonID = @PersonID", connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FName);
            cmd.Parameters.AddWithValue("@SecondName", SName);
            cmd.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThName) ? (object)DBNull.Value : ThName);
            cmd.Parameters.AddWithValue("@LastName", LName);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@NationalCardImagePath", string.IsNullOrEmpty(NationalCardImagePath) ? (object)DBNull.Value : NationalCardImagePath);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _DeletePerson(int PersonID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[People] WHERE PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public DataTable _getAllData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT 
                                              PersonID, NationalNo, FirstName, 
	                                          SecondName, ThirdName, LastName, 
	                                          case
	                                          when Gender = 0 then 'Male'
	                                          else 'Female'
	                                          end as Gender,
	                                          Phone, NationalCardImagePath
                                              FROM People", connection);
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


        static public bool _IsExist(int PersonID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select Find = 1 from People where PersonID = @PersonID", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool Find = reader.HasRows;

                reader.Close();

                return Find;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExist(string NationalNo)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select Find = 1 from People where NationalNo = @NationalNo", connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool Find = reader.HasRows;

                reader.Close();

                return Find;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }
    }
}
