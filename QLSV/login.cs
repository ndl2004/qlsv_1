using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class login : Form
    {
        // Thêm tài khoản và mật khẩu hợp lệ để kiểm tra
        private string correctUsername = "admin";
        private string correctPassword = "123456";

        public login()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Sự kiện này có thể không cần thiết nếu không có chức năng xử lý gì.
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy giá trị nhập vào từ TextBox
            string enteredUsername = tbUsername.Text;  // Sửa lại cho đúng với TextBox username
            string enteredPassword = tbPassword.Text;  // Sửa lại cho đúng với TextBox password

            // Kiểm tra thông tin đăng nhập
            if (enteredUsername == correctUsername && enteredPassword == correctPassword)
            {
                // Nếu thông tin chính xác, mở Form1
                Form1 fr01 = new Form1();
                fr01.Show();

                // Ẩn form login sau khi đăng nhập thành công
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo nếu thông tin sai
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
