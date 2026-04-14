using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace DAL
{
    public class BorrowRecordDAL
    {
        public void BorrowBook(int memberId, int bookId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO BorrowRecords (MemberID, BookID, BorrowDate)
                    VALUES (@m, @b, DATE('now'))";

                cmd.Parameters.AddWithValue("@m", memberId);
                cmd.Parameters.AddWithValue("@b", bookId);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT m.Name, b.Title, br.BorrowDate, br.ReturnDate
                    FROM BorrowRecords br
                    JOIN Members m ON br.MemberID = m.MemberID
                    JOIN Books b ON br.BookID = b.BookID";

                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
    }
}