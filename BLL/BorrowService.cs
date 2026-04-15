using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class BorrowService
    {
        /*test branch protection with ci/cd pipeline*/
        private readonly IBorrowRecordRepository repository;

        public BorrowService() : this(new BorrowRecordDAL())
        {
        }

        public BorrowService(IBorrowRecordRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

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

            repository.BorrowBook(memberId, bookId);
        }

        public List<BorrowRecordView> GetAll()
        {
            return repository.GetAll();
        }
    }
}
