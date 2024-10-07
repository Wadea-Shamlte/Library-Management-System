using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALManageFines
    {
        static string _Path = clsDALPathConnection.Path;

        static public bool _GetFine(int FineID, ref int PersonID, ref int BorrowingRecordID, ref short NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Fines
                                              WHERE FineID = @FineID", connection);
            cmd.Parameters.AddWithValue("@FineID", FineID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    BorrowingRecordID = (int)reader["BorrowingRecordID"];
                    NumberOfLateDays = (short)reader["NumberOfLateDays"];
                    FineAmount = (decimal)reader["FineAmount"];
                    PaymentStatus = (bool)reader["PaymentStatus"];

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _GetFineByBorrowingID(int BorrowingRecordID, ref int PersonID, ref int FineID, ref short NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Fines
                                              WHERE BorrowingRecordID = @BorrowingRecordID", connection);
            cmd.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FineID = (int)reader["FineID"];
                    NumberOfLateDays = (short)reader["NumberOfLateDays"];
                    FineAmount = (decimal)reader["FineAmount"];
                    PaymentStatus = (bool)reader["PaymentStatus"];

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public int _AddFine(int PersonID, int BorrowingRecordID, short NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Fines]([PersonID],[BorrowingRecordID],[NumberOfLateDays],[FineAmount],[PaymentStatus])
                                              VALUES (@PersonID , @BorrowingRecordID , @NumberOfLateDays , @FineAmount , @PaymentStatus )
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            cmd.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
            cmd.Parameters.AddWithValue("@FineAmount", FineAmount);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

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

        static public bool _UpdatePaymentStatus(int FineID, bool PaymentStatus)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Fines]
                                              SET 
                                              [PaymentStatus] = @PaymentStatus 
                                              WHERE FineID = @FineID", connection);


            cmd.Parameters.AddWithValue("@FineID", FineID);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public DataTable _GetAllFine()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Fines", connection);
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

        static public bool _IsExist(int FineID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from Fines where FineID = @FineID", connection);
            cmd.Parameters.AddWithValue("@FineID", FineID);

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



    }
}
