using DAL.Database;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThong_QuanLyDiem
{
    public partial class frmManHinhChinh : Form
    {
        Database db = new Database();
        public frmManHinhChinh()
        {
            InitializeComponent();
            LoadTenTaiKhoan();
        }
        private void LoadTenTaiKhoan()
        {

            string currentUser = ThongTinSession.TaiKhoan;
            lbl_TenTaiKhoan.Text = currentUser;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có muốn thoát hệ thống ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Hàm đổi màu khi chọn nút 
        private Button _currentButton = null;

        private void HighlightButton(Button selectedButton)
        {
            if (_currentButton != null)
            {

                _currentButton.BackColor = Color.FromArgb(212, 235, 248);
                _currentButton.ForeColor = Color.DimGray;
                _currentButton.FlatAppearance.BorderSize = 0;
            }
            selectedButton.BackColor = Color.FromArgb(0, 107, 255);
            selectedButton.ForeColor = Color.White;
            _currentButton = selectedButton;
        }

        private void ManHinhChinh_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = true;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void Khoa_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = true;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void Nganh_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = true;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void Lop_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = true;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void MonHoc_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = true;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void GiangVien_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = true;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }

        private void SInhVien_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = false;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = true;
            HighlightButton((Button)sender);
        }

        private void DiemSinhVien_Click(object sender, EventArgs e)
        {
            ufrm_ManHinhChinh1.Visible = false;
            quanLyLop1.Visible = false;
            ufrm_QuanLyDiem1.Visible = true;
            ufrm_QuanLyGiangVien1.Visible = false;
            ufrm_QuanLyKhoa1.Visible = false;
            ufrm_QuanLyMonHoc1.Visible = false;
            ufrm_QuanLyNganh1.Visible = false;
            ufrm_QuanLySinhVien1.Visible = false;
            HighlightButton((Button)sender);
        }
    }
}
