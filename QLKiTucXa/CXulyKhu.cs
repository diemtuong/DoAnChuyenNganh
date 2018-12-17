using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace QLKiTucXa
{
    class CXulyKhu
    {
        private CTruycapdulieu tc;
        private Table<KHU> dskhu;

        public CXulyKhu()
        {
            tc = CTruycapdulieu.khoitao();
            dskhu = tc.getDSKhu();
        }

        public List<KHU> getDSKhu()
        {
            return dskhu.ToList();
        }

        public void them(KHU k)
        {
            k.makhu = k.makhu.ToUpper();
            dskhu.InsertOnSubmit(k);
            tc.capnhat();
        }

        public void xoa(KHU k)
        {
            dskhu.DeleteOnSubmit(k);
            tc.capnhat();
        }
        public KHU tim(string mahang)
        {
            foreach (KHU a in dskhu.Where(x => x.makhu == mahang))
            {
                return a;
            }
            return null;
        }

        public void sua(KHU a)
        {
            KHU x = tim(a.makhu);
            if (x != null)
            {
                x.tenkhu = a.tenkhu;
                x.soluongtoida = a.soluongtoida;
                tc.capnhat();
            }
        }
    }
}
