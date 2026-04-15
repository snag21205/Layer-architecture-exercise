using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using DTO;

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

        public List<BorrowRecordView> GetAll()
        {
            var items = new List<BorrowRecordView>();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT m.Name, b.Title, br.BorrowDate, br.ReturnDate
                    FROM BorrowRecords br
                    JOIN Members m ON br.MemberID = m.MemberID
                    JOIN Books b ON br.BookID = b.BookID
                    ORDER BY br.BorrowDate DESC";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new BorrowRecordView
                        {
                            MemberName = reader.GetString(0),
                            BookTitle = reader.GetString(1),
                            BorrowDate = reader.GetDateTime(2),
                            ReturnDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3)
                        });
                    }
                }
            }

            return items;
        }
    }
}