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
    public partial class register : Form
    {
        // Static properties to store registered username and password
        public static string RegisteredUsername { get; private set; }
        public static string RegisteredPassword { get; private set; }

        public register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy giá trị nhập vào từ RichTextBox
            RegisteredUsername = tbUsername.Text;  // Username
            RegisteredPassword = tbPassword.Text;  // Password
            string confirmPassword = tbConfirmPassword.Text;  // Confirm Password

            // Kiểm tra nếu mật khẩu xác nhận khớp
            if (RegisteredPassword == confirmPassword)
            {
                // Thực hiện thêm tài khoản mới (có thể lưu vào cơ sở dữ liệu hoặc file nếu cần)
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Có thể mở form đăng nhập sau khi đăng ký thành công
                this.Hide();
                login loginForm = new login();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

