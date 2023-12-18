using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoaHoc
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quảnLýKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //click quản lý khóa học
            frm_QuanLyKhoaHoc f = new frm_QuanLyKhoaHoc();
            f.TopLevel = false;
            Main_pnl.Controls.Add(f);
            f.Show();
        }

        private void frm_Main_Resize(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "frm_QuanLyKhoaHoc")
                {
                    f.Height = Main_pnl.Height;
                    f.Width = Main_pnl.Width;
                }
            }
        }
    }
}
