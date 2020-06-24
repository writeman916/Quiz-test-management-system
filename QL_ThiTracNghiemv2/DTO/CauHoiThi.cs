using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiemv2.DTO
{
    public class CauHoiThi
    {
        public int id_cauhoi { get; set; }
        public string noidung { get; set; }
        public string dapanA { get; set; }
        public string dapanB { get; set; }
        public string dapanC { get; set; }
        public string dapanD { get; set; }
        public bool LoaiCauHoi { get; set;}
        public string dapanDung { get; set; }
        public string choice { get; set; }

        public CauHoiThi()
        {

        }

        public CauHoiThi(int id_cauhoi, string noidung, string dapanA, string dapanB, string dapanC, string dapanD, string dapanDung)
        {
            this.id_cauhoi = id_cauhoi;
            this.noidung = noidung;
            this.dapanA = dapanA;
            this.dapanB = dapanB;
            this.dapanC = dapanC;
            this.dapanD = dapanD;
            this.dapanDung = dapanDung;
        }
    }
}
