using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoaHoc
{
    public partial class frm_QuanLyKhoaHoc : Form
    {
        DatabaseDataContext db = new DatabaseDataContext();
        public frm_QuanLyKhoaHoc()
        {
            InitializeComponent();
        }
        
        private void LoadData() 
        {
            List<tbl_KhoaHoc> dskh = new List<tbl_KhoaHoc>();
            dskh = db.tbl_KhoaHocs.ToList();
            DSKhoaHoc_dgv.DataSource = dskh;
        }

        private void ClearData_btn_Click( object sender, EventArgs e)
        {
            MaKhoaHoc_txt.Text = "";
            TenKhoaHoc_txt.Text = "";
            ThoiGian_txt.Text = "";
            GioiHanSinhVien_num.Text = "";
            GioiHanGiangVien_num.Text = "";
            KinhPhiDongGop_num.Text = "";
            SoBuoiThucHanh_num.Text = "";
            SoBuoiLyThuyet_num.Text = "";
        }

        private void frm_QuanLyKhoaHoc_Load(object sender, EventArgs e)
        {

            LoadData();
            XoaKhoaHoc_btn.Enabled = false;
            SuaKhoaHoc_btn.Enabled = false;
            LamMoiKhoaHoc_btn.Enabled = false;
        }
        private void ThemKhoaHoc_btn_Click(object sender, EventArgs e)
        {
            //xử lý sự kiện click nút thêm
            try {
                tbl_KhoaHoc newObj = new tbl_KhoaHoc();
                newObj.MaKhoaHoc = MaKhoaHoc_txt.Text;
                MaKhoaHoc_txt.ReadOnly = false; 
                newObj.TenKhoaHoc = TenKhoaHoc_txt.Text;
                newObj.ThoiGian = ThoiGian_txt.Text;
                newObj.GioiHanSinhVien = Convert.ToInt32(GioiHanSinhVien_num.Value);
                newObj.GioiHanGiangVien = Convert.ToInt32(GioiHanGiangVien_num.Value);
                newObj.KinhPhiDongGop = Convert.ToInt32(KinhPhiDongGop_num.Value);
                newObj.SoBuoiThucHanh = Convert.ToInt32(SoBuoiThucHanh_num.Value);
                newObj.SoBuoiLyThuyet = Convert.ToInt32(SoBuoiLyThuyet_num.Value);
                db.tbl_KhoaHocs.InsertOnSubmit(newObj);
                db.SubmitChanges();
                MessageBox.Show("Thêm khóa học thành công!");
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm khóa học không thành công");
            }

            ClearData_btn_Click(sender, e);

        }
        
        private void XoaKhoaHoc_btn_Click(object sender, EventArgs e)
        {
            try 
            { 
                tbl_KhoaHoc delObj = db.tbl_KhoaHocs.Where(o => o.MaKhoaHoc.Equals(MaKhoaHoc_txt.Text)).FirstOrDefault();
                db.tbl_KhoaHocs.DeleteOnSubmit(delObj);
                db.SubmitChanges();
                MessageBox.Show("Xóa khóa học thành công");
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa khóa học không thành công");
            }

            ClearData_btn_Click(sender, e);

        }

        private void SuaKhoaHoc_btn_Click_1(object sender, EventArgs e)
        {
            try
            {
                var mkh = MaKhoaHoc_txt.Text;
                tbl_KhoaHoc editObj = db.tbl_KhoaHocs.Where(o => o.MaKhoaHoc.Equals(mkh)).FirstOrDefault();
                editObj.MaKhoaHoc = MaKhoaHoc_txt.Text;
                editObj.TenKhoaHoc = TenKhoaHoc_txt.Text;
                editObj.ThoiGian = ThoiGian_txt.Text;
                editObj.GioiHanSinhVien = Convert.ToInt32(GioiHanGiangVien_num.Text);
                editObj.GioiHanGiangVien = Convert.ToInt32(GioiHanGiangVien_num.Text);
                editObj.KinhPhiDongGop = Convert.ToInt32(KinhPhiDongGop_num.Text);
                editObj.SoBuoiThucHanh = Convert.ToInt32(SoBuoiThucHanh_num.Text);
                editObj.SoBuoiLyThuyet = Convert.ToInt32(SoBuoiLyThuyet_num.Text);
                db.SubmitChanges();
                MessageBox.Show("Sửa thông tin thành công!");
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thông tin không thành công");
            }
        }

        private void LamMoiKhoaHoc_btn_Click(object sender, EventArgs e)
        {
            ClearData_btn_Click(sender, e);
            MaKhoaHoc_txt.ReadOnly = false;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DSKhoaHoc_dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            XoaKhoaHoc_btn.Enabled = true;
            SuaKhoaHoc_btn.Enabled = true;
            LamMoiKhoaHoc_btn.Enabled = true;
            DataGridViewRow row = new DataGridViewRow();
            row = DSKhoaHoc_dgv.Rows[e.RowIndex];
            MaKhoaHoc_txt.Text = Convert.ToString(row.Cells["MaKhoaHoc"].Value);
            MaKhoaHoc_txt.ReadOnly = true;
            TenKhoaHoc_txt.Text = Convert.ToString(row.Cells["TenKhoaHoc"].Value);
            ThoiGian_txt.Text = Convert.ToString(row.Cells["ThoiGian"].Value);
            GioiHanGiangVien_num.Text = Convert.ToString(row.Cells["GioiHanGiangVien"].Value);
            GioiHanSinhVien_num.Text = Convert.ToString(row.Cells["GioiHanSinhVien"].Value);
            KinhPhiDongGop_num.Text = Convert.ToString(row.Cells["KinhPhiDongGop"].Value);
            SoBuoiLyThuyet_num.Text = Convert.ToString(row.Cells["SoBuoiLyThuyet"].Value);
            SoBuoiThucHanh_num.Text = Convert.ToString(row.Cells["SoBuoiThucHanh"].Value);
        }
    }
}
