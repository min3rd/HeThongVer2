using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT4.Models
{
    class ThamSo
    {
        public string ma;
        public List<SinhVien> list;
        public float avgTuoi=0;
        public float avgGioiTinh=0;
        public float avgDiem=0;
        public float avgTinh=0;
        public ThamSo()
        {
            if (list == null)
            {
                list = new List<SinhVien>();
            }
        }
    }
}
