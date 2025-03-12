using DAL.Database;
using DAL.Model;
using HeThong_QuanLyDiem.UI.ManHinhGiaoVien;
using HeThong_QuanLyDiem.UI.ManHinhSinhVien;
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
    public partial class frmDangNhap : Form
    {
        Database db = new Database();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void forgot_password_Click(object sender, EventArgs e)
        {
            frmQuenMatkhau quen = new frmQuenMatkhau();
            quen.ShowDialog();
        }

        private void checkBox_pass_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = checkBox_pass.Checked ? '\0' : '*';
        }

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin để đăng nhập!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = db.getDatabase();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                
                    string selectData = @"
                    SELECT MADANGNHAP, USERNAME, TENPHANQUYEN, CAPDOPHANQUYEN
                    FROM DANGNHAP
                    WHERE USERNAME = @Username AND PASSWORD_HASH = @Password";

                    using (SqlCommand cmd = new SqlCommand(selectData, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtTenDangNhap.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtMatKhau.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count == 1)
                        {
                          
                            string tenPhanQuyen = table.Rows[0]["TENPHANQUYEN"].ToString();
                            int capDoPhanQuyen = Convert.ToInt32(table.Rows[0]["CAPDOPHANQUYEN"]);
                            int maDangNhap = Convert.ToInt32(table.Rows[0]["MADANGNHAP"]);

                         
                            ThongTinSession.TaiKhoan = txtTenDangNhap.Text.Trim();
                            ThongTinSession.IDTaiKhoan = maDangNhap;
                                                 
                          
                            if (capDoPhanQuyen == 1)
                            {
                                MessageBox.Show("Đăng nhập thành công - GIÁO VIÊN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmManHinhGiaoVien giaoVien = new frmManHinhGiaoVien();
                                giaoVien.Show();

                                this.Hide();
                            }
                            else if (capDoPhanQuyen == 2)
                            {
                                MessageBox.Show("Đăng nhập thành công - SINH VIÊN !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmManHinhSinhVien sinhVien = new frmManHinhSinhVien();
                                sinhVien.Show();

                                this.Hide();
                            } else if (capDoPhanQuyen == 3)
                            {
                                MessageBox.Show("Đăng nhập thành công - BỘ GIÁO DỤC !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmManHinhChinh manHinhChinh = new frmManHinhChinh();
                                manHinhChinh.Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản không có quyền truy cập !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn thoát đăng nhập ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn thoát đăng nhập ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
