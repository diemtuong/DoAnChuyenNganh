using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace QLKiTucXa
{
    class CTruycapdulieu
    {
        private QLKTXDataContext dc;
        private static CTruycapdulieu tc = null;
        public CTruycapdulieu()
        {
            dc = new QLKTXDataContext();
        }

        public static CTruycapdulieu khoitao()
        {
            if (tc == null) tc = new CTruycapdulieu();
            return tc;
        }
        public Table<KHU> getDSKhu()
        {
            return dc.KHUs;
        }
        
        public Table<SINHVIEN> getDSSVien()
        {
            return dc.SINHVIENs;

        }

        public Table<HOPDONG> getDSHopdong()
        {
            return dc.HOPDONGs;

        }

        public Table<HOADONTIENDIEN> getDSHoadon()
        {
            return dc.HOADONTIENDIENs;
        }
        public Table<HOADONTIENPHONG> getDSHoadonphong()
        {
            return dc.HOADONTIENPHONGs;
        } 

        public void capnhat()
        {
            dc.SubmitChanges();
        }
    }
}
