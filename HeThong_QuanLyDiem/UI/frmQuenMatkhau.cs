using DAL.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong_QuanLyDiem.UI
{
    public partial class frmQuenMatkhau : Form
    {
        Database db = new Database();
        public frmQuenMatkhau()
        {
            InitializeComponent();
        }

        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
            txtXacNhanMatKhau.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();       
            string newPassword = txtMatKhauMoi.Text.Trim();
            string confirmNewPassword = txtXacNhanMatKhau.Text.Trim();

            // Kiểm tra nhập đầy đủ thông tin
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmNewPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu có giống nhau không
            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = db.getDatabase();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra xem tài khoản có tồn tại và mật khẩu cũ có đúng không
                    string checkUserQuery = @" SELECT COUNT(*) FROM DANGNHAP  WHERE USERNAME = @Username";

                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                     
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists == 0)
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc không tồn tại !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Cập nhật mật khẩu mới-----------------------------------------------------------
                    string updatePasswordQuery = @" UPDATE DANGNHAP  SET PASSWORD_HASH = @NewPassword  WHERE USERNAME = @Username";

                    using (SqlCommand updateCmd = new SqlCommand(updatePasswordQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@Username", username);
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Khôi phục mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Khôi phục mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
