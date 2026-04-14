using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        BorrowService service = new BorrowService();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            int memberId = int.Parse(txtMemberID.Text);
            int bookId = int.Parse(txtBookID.Text);

            service.BorrowBook(memberId, bookId);

            MessageBox.Show("Borrow success!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = service.GetAll();
        }
    }
}
