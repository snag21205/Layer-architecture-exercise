using System;

namespace DTO
{
    public class BorrowRecordView
    {
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
