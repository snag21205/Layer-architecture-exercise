using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class BorrowService
    {
        private readonly BorrowRecordDAL dal = new BorrowRecordDAL();

        public void BorrowBook(int memberId, int bookId)
        {
            if (memberId <= 0)
            {
                throw new ArgumentException("Member ID must be greater than 0.", nameof(memberId));
            }

            if (bookId <= 0)
            {
                throw new ArgumentException("Book ID must be greater than 0.", nameof(bookId));
            }

            dal.BorrowBook(memberId, bookId);
        }

        public List<BorrowRecordView> GetAll()
        {
            return dal.GetAll();
        }
    }
}
