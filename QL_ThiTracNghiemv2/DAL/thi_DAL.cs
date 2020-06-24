using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_ThiTracNghiemv2.DTO;
using QL_ThiTracNghiemv2.View;

namespace QL_ThiTracNghiemv2.DAL
{
    public class thi_DAL
    {
         ThiTHDCDataContext db { get; set; }
        public thi_DAL()
        {
            db = new ThiTHDCDataContext();
        }
        public string getPW(string mssv)
        {
            string pass = "";
            var c = db.SinhViens.Where(p => p.SoThe.ToString() == mssv).Select(p => new { p.SoThe });
            foreach (var i in c)
            {
                pass = i.SoThe.ToString();
            }
            return pass;
        }
        public InfoSV getInfo(string mssv)
        {
            InfoSV sv = new InfoSV();
            var c = db.SinhViens.Where(p => p.SoThe.ToString() == mssv).Select(p => new { p.HoTen, p.SoThe, p.NgaySinh, p.LopSH });
            foreach (var i in c)
            {
                sv.sothe = i.SoThe;
                sv.hoten = i.HoTen;
                sv.ngaysinh = i.NgaySinh;
                sv.lopsh = i.LopSH;
            }
            return sv;
        }

        public void reset()
        {
            var c = db.CauHois.Select(p => p);
            foreach (CauHoi i in c)
            {
                i.Choice = null;
            }
            db.SubmitChanges();
        }
        public int countCH()
        {
            int count = 0;
            var c = db.CauHois.Select(p => p);
            foreach (CauHoi i in c)
            {
                count++;
            }
            return count;
        }
        public void setDA(int socauhoi, string dapan)
        {
            var c = db.CauHois.Single(p => p.MaCH == socauhoi);
            c.Choice = dapan;
            db.SubmitChanges();
        }
        public CauHoiThi getCH(int socauhoi)
        {
            CauHoiThi ch = new CauHoiThi();
            var c = db.CauHois.Where(p => p.MaCH == socauhoi).Select(p => p);
            foreach (var i in c)
            {
                ch.id_cauhoi = i.MaCH;
                ch.noidung = i.NoiDung;
                ch.dapanA = i.DapanA;
                ch.dapanB = i.DapanB;
                ch.dapanC = i.DapanC;
                ch.dapanD = i.DapanD;
                ch.dapanDung = i.DapanDung;
                ch.choice = i.Choice;
            }
            return ch;
        }
        public float nopbai()
        {
            float diem = 0;
            var c = db.CauHois.Select(p => p);
            foreach (CauHoi i in c)
            {
                if (i.Choice != null)
                {

                    if (i.DapanDung.Trim() == i.Choice.Trim()) diem++;
                }
            }
            return diem;
        }

    }
}
