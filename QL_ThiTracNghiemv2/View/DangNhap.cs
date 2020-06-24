using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_ThiTracNghiemv2.BLL;
using QL_ThiTracNghiemv2.DTO;

namespace QL_ThiTracNghiemv2
{
    public partial class DangNhap : Form
    {
        public delegate void Mydelegate(InfoSV sv);
        public thi_BLL bll { get; set; }
        public DangNhap()
        {
            InitializeComponent();
            bll = new thi_BLL();
        }
        public Mydelegate Dele;
        private void bt_dangnhap_Click(object sender, EventArgs e)
        {
            string mssv = tb_mssv.Text;
            string pass = bll.getPass(mssv);
            InfoSV sv = bll.getInfoSV(mssv);
            if ((tb_matkhau.Text.Trim()) == pass)
            {
                Form1 f1 = new Form1();

                Mydelegate del = new Mydelegate(f1.setNameSV);
                del(sv);

                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            }

        }
    }
}
