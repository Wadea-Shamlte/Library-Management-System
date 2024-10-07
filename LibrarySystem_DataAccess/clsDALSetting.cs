using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALSetting
    {
        static string _Path = clsDALPathConnection.Path;

        static public decimal _GetDefaultBorrowDays()
        {
            
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT DefaultBorrowDays
                                              FROM Settings", connection);
            try
            {
                connection.Open();
                
                object Result = cmd.ExecuteScalar();

                if (Result != null && decimal.TryParse(Result.ToString(), out decimal result))
                    return result;
                else return -1;
                    
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

        static public decimal _GetDefaultFinePerDay()
        {

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT DefaultFinePerDay
                                              FROM Settings", connection);
            try
            {
                connection.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && decimal.TryParse(Result.ToString(), out decimal result))
                    return result;
                else return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }


        static public bool _UpdateDefaultBorrowDays(decimal NewDefaultBorrowDays)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Settings]
                                              SET [DefaultBorrowDays] = @DefaultBorrowDays", connection);

            cmd.Parameters.AddWithValue("@DefaultBorrowDays", NewDefaultBorrowDays);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _UpdateDefaultFinePerDay(decimal NewDefaultFinePerDay)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Settings]
                                              SET DefaultFinePerDay = @DefaultFinePerDay", connection);

            cmd.Parameters.AddWithValue("@DefaultFinePerDay", NewDefaultFinePerDay);

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
