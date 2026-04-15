using System;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly BorrowService service = new BorrowService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMemberID.Text, out int memberId))
            {
                MessageBox.Show("Member ID must be a number.");
                return;
            }

            if (!int.TryParse(txtBookID.Text, out int bookId))
            {
                MessageBox.Show("Book ID must be a number.");
                return;
            }

            try
            {
                service.BorrowBook(memberId, bookId);
                MessageBox.Show("Borrow success!");
                dataGridView1.DataSource = service.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Borrow failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = service.GetAll();
        }
    }
}
