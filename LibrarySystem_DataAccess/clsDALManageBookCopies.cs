using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALManageBookCopies
    {
        static string _Path = clsDALPathConnection.Path;

        static public bool _GetCopyBookInfo(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM BookCopies
                                              WHERE CopyID = @CopyID", connection);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    BookID = (int)reader["CopyID"];
                    AvailabilityStatus = (bool)reader["AvailabilityStatus"];

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public bool _AddCopies(int NumberOfCopies, int BookID, bool AvailabilityStatus)
        {
            SqlConnection connection = new SqlConnection(_Path);

            int NumberOfAdded = 0;

            try
            {
                connection.Open();

                for (int i = 0; i < NumberOfCopies; i++)
                {
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[BookCopies]([BookID],[AvailabilityStatus])
                                                      VALUES (@BookID , @AvailabilityStatus)", connection);

                    cmd.Parameters.AddWithValue("@BookID", BookID);
                    cmd.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    if (rowsAffected > 0)
                        NumberOfAdded++;

                }
                return NumberOfAdded == NumberOfCopies;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }

        }

        static public bool _UpdateCopyStatus(int CopyID, bool AvailabilityStatus)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[BookCopies]
                                              SET 
                                              [AvailabilityStatus] = @AvailabilityStatus 
                                              WHERE CopyID = @CopyID", connection);

            cmd.Parameters.AddWithValue("@CopyID", CopyID);
            cmd.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _DeleteBook(int CopyID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[BookCopies] WHERE CopyID = @CopyID", connection);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return RowAffected > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _IsExist(int CopyID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from BookCopies where CopyID = @CopyID", connection);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);

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


        static public int _GetCopyIdForAvailableCopy(int BookID)
        {
            SqlConnection connection = new SqlConnection(_Path);

            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(@"select top 1 BookCopies.CopyID from BookCopies 
                                                  join Books on BookCopies.BookID = Books.BookID 
                                                  where Books.BookID = @BookID and BookCopies.AvailabilityStatus = 1", connection);

                cmd.Parameters.AddWithValue("@BookID", BookID);
                object Result = cmd.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString() , out int result))
                    return result;
                else
                    return -1;
                    
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }
    }
}
