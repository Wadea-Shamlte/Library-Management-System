using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALManageBorrowingAndReturn
    {
        static string _Path = clsDALPathConnection.Path;

        static public bool _GetRecordInfo(int BorrowingRecordID, ref int PersonID, ref int CopyID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime? ActualReturnDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM BorrowingRecords
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
                    CopyID = (int)reader["CopyID"];
                    DueDate = (DateTime)reader["DueDate"];
                    BorrowingDate = (DateTime)reader["BorrowingDate"];
                    ActualReturnDate = reader["ActualReturnDate"] != DBNull.Value ? (DateTime?)reader["ActualReturnDate"] : null;

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _GetRecordByCopyID(int CopyID, ref int PersonID, ref int BorrowingRecordID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime? ActualReturnDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM BorrowingRecords
                                              WHERE CopyID = @CopyID and ActualReturnDate is null", connection);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    BorrowingRecordID = (int)reader["BorrowingRecordID"];
                    PersonID = (int)reader["PersonID"];
                    DueDate = (DateTime)reader["DueDate"];
                    BorrowingDate = (DateTime)reader["BorrowingDate"];
                    ActualReturnDate = reader["ActualReturnDate"] != DBNull.Value ? (DateTime?)reader["ActualReturnDate"] : null;

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }



        static public int _BorrowingRecord(int PersonID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[BorrowingRecords]([PersonID],[CopyID],[BorrowingDate],[DueDate],[ActualReturnDate])
                                              VALUES (@PersonID , @CopyID , @BorrowingDate , @DueDate , @ActualReturnDate )
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);
            cmd.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            cmd.Parameters.AddWithValue("@DueDate", DueDate);
            cmd.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate.HasValue ? (object)ActualReturnDate.Value : (object)System.DBNull.Value);

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

        static public bool _ReturnRecord(int BorrowingRecordID, int PersonID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[BorrowingRecords]
                                              SET 
                                              [PersonID] = @PersonID ,
                                              [CopyID] = @CopyID ,
                                              [DueDate] = @DueDate ,
                                              [BorrowingDate] = @BorrowingDate ,
                                              [ActualReturnDate] = @ActualReturnDate 
                                              WHERE BorrowingRecordID = @BorrowingRecordID", connection);


            cmd.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@CopyID", CopyID);
            cmd.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
            cmd.Parameters.AddWithValue("@DueDate", DueDate);
            cmd.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate.HasValue ? (object)ActualReturnDate.Value : (object)System.DBNull.Value);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public DataTable _GetAllRecord()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM BorrowingAndReturn_View", connection);
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

        static public int _CheckBorrowingNumber(int PersonID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select count(*) from BorrowingRecords where PersonID = @PersonID and ActualReturnDate is null", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                
                object Result = cmd.ExecuteScalar();

                if (Result != DBNull.Value && int.TryParse(Result.ToString(), out int result))
                    return result;
                else return -1;

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return -1; }
            finally { connection.Close(); }
        }

    }
}
