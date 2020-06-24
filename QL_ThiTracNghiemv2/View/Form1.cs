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
    public partial class Form1 : Form
    {
        public thi_BLL bll { get; set; }

        public Form1()
        {
            InitializeComponent();
            bll = new thi_BLL();
            timer1.Start();
            bll.resetDapan();
            load_cauhoi();
        }
        int socauhoi = 1;

        private string getdapan()
        {
            if (rb_A.Checked == true) return "A";
            else if (rb_B.Checked == true) return "B";
            else if (rb_C.Checked == true) return "C";
            else if (rb_D.Checked == true) return "D";
            return null;
        }
        public void setNameSV(InfoSV sv)
        {
            lb_hoten.Text = sv.hoten;
            lb_sothe.Text = sv.sothe.ToString();
            lb_ngaysinh.Text = sv.ngaysinh.ToString();
            lb_lopsh.Text = sv.lopsh;
        }
        private void saveDA()
        {
            string dapan = getdapan();
            bll.setDapAn(socauhoi, dapan.Trim());
        }
        private void setButtonNull()
        {
            rb_A.Checked = false;
            rb_B.Checked = false;
            rb_C.Checked = false;
            rb_D.Checked = false;
        }

        private void load_cauhoi()
        {
            CauHoiThi ch = bll.getCauHoi(socauhoi);

            lb_cauhoi.Text = ch.noidung;
            rb_A.Text = ch.dapanA;
            rb_B.Text = ch.dapanB;
            rb_C.Text = ch.dapanC;
            rb_D.Text = ch.dapanD;

            if (ch.choice != null)
            {
                if (ch.choice.Trim() == "A") rb_A.Checked = true;
                else if (ch.choice.Trim() == "B") rb_B.Checked = true;
                else if (ch.choice.Trim() == "C") rb_C.Checked = true;
                else if (ch.choice.Trim() == "D") rb_D.Checked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int phut = Int32.Parse(lb_minute.Text);
            int giay = Int32.Parse(lb_second.Text);

            if (phut >= 0)
            {
                if (giay > 0)
                {
                    giay--;
                }
                else
                {
                    giay = 59;
                    if (phut != 0) phut--;
                }
                this.lb_minute.Text = phut.ToString();
                this.lb_second.Text = giay.ToString();
            }

            if (phut == 0 && giay == 0)
            {
                timer1.Stop();
                float diem = bll.nopBaiThi();
                MessageBox.Show("diem cua ban la: " + diem + "");

            }

        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            if (getdapan() == null) bt_next.Enabled = true;
            else
            {
                if (socauhoi == bll.countC()) bt_next.Enabled = true;
                else
                {
                    saveDA();
                    socauhoi++;
                    setButtonNull();
                    load_cauhoi();
                }
            }
        }

        private void bt_previous_Click(object sender, EventArgs e)
        {
            if (socauhoi == 1) bt_previous.Enabled = true;
            else
            {
                saveDA();
                socauhoi--;
                load_cauhoi();
            }
        }

        private void bt_nopbai_Click(object sender, EventArgs e)
        {
            saveDA();
            float diem = bll.nopBaiThi();
            MessageBox.Show("diem cua ban la: " + diem + "");
        }
    }
}
