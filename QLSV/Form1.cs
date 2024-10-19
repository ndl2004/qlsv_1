using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form1 : Form
    {
        // Sử dụng List<Employee> để lưu trữ danh sách nhân viên
        List<Employee> lstEmp;
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            lstEmp = new List<Employee>(); // Khởi tạo danh sách nhân viên rỗng
        }

        // Xử lý sự kiện khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            bs.DataSource = lstEmp;
            dgvEmployee.DataSource = bs;
        }

        // Sự kiện khi nhấn nút "Thêm"
        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateInput()) // Kiểm tra đầu vào hợp lệ trước khi thêm
            {
                Employee em = new Employee
                {
                    Id = tbId.Text,
                    Name = tbName.Text,
                    Age = int.Parse(tbAge.Text),
                    Gender = ckGender.Checked
                };

                lstEmp.Add(em);
                bs.ResetBindings(false); // Cập nhật BindingSource

                ClearForm(); // Xóa các trường sau khi thêm
            }
        }

        // Sự kiện khi nhấn nút "Xóa"
        private void btDelete_Click(object sender, EventArgs e)
        {
            int idx = dgvEmployee.CurrentCell.RowIndex;
            if (idx >= 0 && idx < lstEmp.Count)
            {
                lstEmp.RemoveAt(idx); // Xóa từ List<Employee>
                bs.ResetBindings(false); // Cập nhật hiển thị trên DataGridView
            }
        }

        // Sự kiện khi chọn hàng trong DataGridView
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            if (idx >= 0 && idx < lstEmp.Count)
            {
                // Kiểm tra giá trị của Cell[0] trước khi chuyển đổi sang chuỗi
                var idValue = dgvEmployee.Rows[idx].Cells[0].Value;
                tbId.Text = idValue != null ? idValue.ToString() : string.Empty;

                // Kiểm tra giá trị của Cell[1] trước khi chuyển đổi sang chuỗi
                var nameValue = dgvEmployee.Rows[idx].Cells[1].Value;
                tbName.Text = nameValue != null ? nameValue.ToString() : string.Empty;

                // Kiểm tra giá trị của Cell[2] trước khi chuyển đổi sang chuỗi
                var ageValue = dgvEmployee.Rows[idx].Cells[2].Value;
                tbAge.Text = ageValue != null ? ageValue.ToString() : string.Empty;

                // Sử dụng bool.TryParse để xử lý Cell[3] (giới tính)
                var genderValue = dgvEmployee.Rows[idx].Cells[3].Value;
                bool isMale;
                if (genderValue != null && bool.TryParse(genderValue.ToString(), out isMale))
                {
                    ckGender.Checked = isMale;
                }
                else
                {
                    ckGender.Checked = false; // Mặc định nếu không hợp lệ
                }
            }
        }

        // Phương thức để xóa các trường sau khi thêm/xóa
        private void ClearForm()
        {
            tbId.Clear();
            tbName.Clear();
            tbAge.Clear();
            ckGender.Checked = false;
        }

        // Phương thức kiểm tra tính hợp lệ của dữ liệu đầu vào
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(tbId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!");
                return false;
            }

            if (!int.TryParse(tbAge.Text, out _))
            {
                MessageBox.Show("Tuổi phải là một số nguyên hợp lệ!");
                return false;
            }

            return true;
        }

        // Sự kiện khi nhấn nút "Sửa"
        private void btEdit_Click(object sender, EventArgs e)
        {
            int idx = dgvEmployee.CurrentCell.RowIndex;
            if (idx >= 0 && idx < lstEmp.Count && ValidateInput())
            {
                // Cập nhật thông tin của nhân viên đã chọn
                lstEmp[idx].Id = tbId.Text;
                lstEmp[idx].Name = tbName.Text;
                lstEmp[idx].Age = int.Parse(tbAge.Text);
                lstEmp[idx].Gender = ckGender.Checked;

                // Cập nhật hiển thị trên DataGridView
                bs.ResetBindings(false);

                // Xóa các trường nhập liệu sau khi sửa
                ClearForm();
            }
        }

        // Lớp Employee để lưu thông tin nhân viên
        public class Employee
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Gender { get; set; } // true: Nam, false: Nữ
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện nhấn vào nội dung của Cell nếu cần
        }
    }
}
