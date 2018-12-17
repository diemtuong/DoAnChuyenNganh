using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace QLKiTucXa
{
    class XuLyHoaDon
    {
        private CTruycapdulieu data;
        private Table<HOADONTIENDIEN> tbhd;
        public XuLyHoaDon()
        {
            data = CTruycapdulieu.khoitao();
        }
        public List<HOADONTIENDIEN> getDSHoadon()
        {
            return data.getDSHoadon().ToList();
        }
        public void them(HOADONTIENDIEN hd)
        {
            data.getDSHoadon().InsertOnSubmit(hd);
            data.capnhat();
        }
        //public HOADONTIENDIEN tim(String sc)
        //{

        //    foreach (HOADONTIENDIEN a in tbhd.Where(x =>x.sohd==sc.sohd))
        //    {
        //        return a;
        //    }
        //    return null;
        //}
        //public void xoa(HOADONTIENDIEN a)
        //{

        //    HOADONTIENDIEN b = tim(a);
        //    if (b != null)
        //    {
        //        tbhd.DeleteOnSubmit(a);
        //        data.capnhat();
        //    }
        //}
        public string taoSoHD()
        {
            string sohd = "hd001";
            foreach (HOADONTIENDIEN a in data.getDSHoadon().OrderByDescending(x => x.sohd).Take(1))
            {
                string t = a.sohd.Substring(2);
                int n = int.Parse(t) + 1;
                t = n.ToString("D3");
                sohd = "hd" + t;
                break;
            }
            return sohd;
        }
    }
}
