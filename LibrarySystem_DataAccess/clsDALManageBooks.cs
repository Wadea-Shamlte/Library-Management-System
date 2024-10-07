using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem_DataAccess
{
    public class clsDALManageBooks
    {
        static string _Path = clsDALPathConnection.Path;

        static public bool _GetBookInfo(int BookID, ref string Title, ref string ISBN, ref DateTime PublicationDate, ref string Genre, ref string AdditionalDetails)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT *
                                              FROM Books
                                              WHERE BookID = @BookID", connection);
            cmd.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Title = (string)reader["Title"];
                    Genre = (string)reader["Genre"];
                    ISBN = (string)reader["ISBN"];
                    PublicationDate = (DateTime)reader["PublicationDate"];
                    AdditionalDetails = reader["AdditionalDetails"] != DBNull.Value ? (string)reader["AdditionalDetails"] : ""; 

                    reader.Close();
                }
                else
                    reader.Close();
                return isFound;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public int _AddBook(string Title, string ISBN, DateTime PublicationDate, string Genre, string AdditionalDetails)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Books]([Title],[ISBN],[PublicationDate],[Genre],[AdditionalDetails])
                                              VALUES (@Title , @ISBN , @PublicationDate , @Genre , @AdditionalDetails )
                                              select SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate); 
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@AdditionalDetails", !string.IsNullOrEmpty(AdditionalDetails) ? AdditionalDetails : (object)System.DBNull.Value);

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

        static public bool _UpdateBookInfo(int BookID, string Title, string ISBN, DateTime PublicationDate,  string Genre, string AdditionalDetails)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[Books]
                                              SET 
                                              [Title] = @Title ,
                                              [ISBN] = @ISBN ,
                                              [Genre] = @Genre ,
                                              [PublicationDate] = @PublicationDate ,
                                              [AdditionalDetails] = @AdditionalDetails 
                                              WHERE BookID = @BookID", connection);


            cmd.Parameters.AddWithValue("@BookID", BookID);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@ISBN", ISBN);
            cmd.Parameters.AddWithValue("@PublicationDate", PublicationDate);
            cmd.Parameters.AddWithValue("@Genre", Genre);
            cmd.Parameters.AddWithValue("@AdditionalDetails", !string.IsNullOrEmpty(AdditionalDetails) ? AdditionalDetails : (object)System.DBNull.Value);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return (RowAffected > 0);

            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }

        static public bool _DeleteBook(int BookID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Books] WHERE BookID = @BookID", connection);
            cmd.Parameters.AddWithValue("@BookID", BookID);

            try
            {
                connection.Open();
                int RowAffected = cmd.ExecuteNonQuery();

                return RowAffected > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return false; }
            finally { connection.Close(); }
        }


        static public DataTable _GetAllBookData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT BookID, Title, ISBN, Genre,
                                                     AvailableCopies = (SELECT COUNT(*) 
                                                                        FROM BookCopies 
                                                                        WHERE BookCopies.BookID = Books.BookID 
                                                                        AND BookCopies.AvailabilityStatus = 1),
                                                     FullCopies = (SELECT COUNT(*) 
                                                                   FROM BookCopies 
                                                                   WHERE BookCopies.BookID = Books.BookID)
                                                     FROM Books ", connection);
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

        static public DataTable _GetAvailableBookData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT Books.BookID, Books.Title, Books.ISBN, Books.Genre,
                                              COUNT(BookCopies.CopyID) AS AvailableCopies
                                              FROM Books
                                              LEFT JOIN 
                                                  BookCopies ON Books.BookID = BookCopies.BookID 
                                                  AND BookCopies.AvailabilityStatus = 1
                                              GROUP BY Books.BookID, Books.Title, Books.ISBN, Books.Genre
                                              HAVING COUNT(BookCopies.CopyID) > 0;", connection);
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

        static public DataTable _GetBookBy(int PersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand(@"SELECT Books.BookID, BookCopies.CopyID, Books.Title, Books.ISBN, Books.Genre
                                              FROM Books 
                                              INNER JOIN BookCopies ON Books.BookID = BookCopies.BookID 
                                              INNER JOIN BorrowingRecords ON BookCopies.CopyID = BorrowingRecords.CopyID
                                              WHERE BorrowingRecords.PersonID = @PersonID AND BorrowingRecords.ActualReturnDate IS NULL;", connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); return dt; }
            finally { connection.Close(); }

            return dt;

        }



        static public bool _IsExist(int BookID)
        {
            SqlConnection connection = new SqlConnection(_Path);
            SqlCommand cmd = new SqlCommand("select 1 from Books where BookID = @BookID", connection);
            cmd.Parameters.AddWithValue("@BookID", BookID);

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
