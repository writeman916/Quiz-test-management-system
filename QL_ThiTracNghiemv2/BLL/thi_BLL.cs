using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_ThiTracNghiemv2.DAL;
using QL_ThiTracNghiemv2.DTO;

namespace QL_ThiTracNghiemv2.BLL
{

    public class thi_BLL
    {
        public thi_DAL dal { get; set; }
        public thi_BLL()
        {
            dal = new thi_DAL();
        }
        public void resetDapan()
        {
            dal.reset();
        }
        public void setDapAn(int socauhoi, string dapan)
        {
            dal.setDA(socauhoi, dapan);
        }
        public InfoSV getInfoSV(string mssv)
        {
            return dal.getInfo(mssv);
        }
        public string getPass(string mssv)
        {
            return dal.getPW(mssv);
        }
        public CauHoiThi getCauHoi(int socauhoi)
        {
            return dal.getCH(socauhoi);
        }
        public float nopBaiThi()
        {
            return dal.nopbai();
        }
        public int countC()
        {
            return dal.countCH();
        }
    }
}
