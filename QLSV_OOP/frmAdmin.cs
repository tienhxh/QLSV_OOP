    using QLSV_OOP.DTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace QLSV_OOP
    {
        public partial class frmAdmin : Form
        {
            private Account account;
            public frmAdmin(Account acc)
            {
                InitializeComponent();
                account = acc;
            }

            private void toolStripMenuItemSignOut_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (MessageBox.Show("Xác nhận đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }

            private void frmAdmin_Load(object sender, EventArgs e)
            {

            }

            private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmChangePassword changePass = new frmChangePassword(account);
            }
        }
    }
