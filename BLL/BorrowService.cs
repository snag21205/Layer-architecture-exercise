using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BorrowService
    {
        private BorrowRecordDAL dal = new BorrowRecordDAL();

        public void BorrowBook(int memberId, int bookId)
        {
           
            dal.BorrowBook(memberId, bookId);
        }

        public System.Data.DataTable GetAll()
        {
            return dal.GetAll();
        }
    }
}
