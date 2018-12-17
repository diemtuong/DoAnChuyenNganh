using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace QLKiTucXa
{
    public class CXulyHopdong
    {
        private CTruycapdulieu tc;
        private Table<HOPDONG> dshd;
        private QLKTXDataContext dc = new QLKTXDataContext();       

        public CXulyHopdong()
        {
            tc = CTruycapdulieu.khoitao();
            dshd = tc.getDSHopdong();
        }

        public List<HOPDONG> getDSHopdong()
        {
            return dshd.ToList();
        }

        public IEnumerable<object> getDSHopdongView()
        {
            List<HOPDONG> ds = getDSHopdong();
            return ds.Select(x => new
            {
                mahd = x.mahd,
                manv = x.manv,
                masv = x.masv,
                ngaybd = x.ngaybd.Value.ToShortDateString(),
                ngaykt = x.ngaykt.Value.ToShortDateString(),
            }).ToList();
        }
        public NHANVIEN timnv(string manv)
        {
            foreach(NHANVIEN a in dc.NHANVIENs.Where(x => x.manv == manv))
            {
                return a;
            }
            return null;
        }
        public void them(HOPDONG k)
        {
            k.mahd = k.mahd.ToUpper();
            k.manv = k.manv.ToUpper();
            k.masv = k.masv.ToUpper();
            dshd.InsertOnSubmit(k);
            tc.capnhat();
        }

        
        public HOPDONG tim(string map)
        {
            foreach (HOPDONG a in dshd.Where(x => x.mahd == map))
            {
                return a;
            }
            return null;
        }

        public HOPDONG tim_masv(string masv)
        {
            foreach (HOPDONG a in dshd.Where(x => x.masv == masv))
            {
                return a;
            }
            return null;
        }

        public void sua(HOPDONG a)
        {
            HOPDONG x = tim(a.mahd);
            if (x != null)
            {
                x.masv = a.masv;
                x.manv = a.manv;
                x.ngaybd = a.ngaybd;
                x.ngaykt = a.ngaykt;

                tc.capnhat();
            }
        }

        public bool kt_rangbuoc_thoigian(DateTime bd,DateTime kt)
        {
            if (bd<kt)
            {
                int thangbd = bd.Month, nambd = bd.Year, thangkt = kt.Month, namkt = kt.Year;
                if (namkt > nambd)
                    thangkt += 12;
                if ((thangkt - thangbd) <= 0 || (thangkt - thangbd) % 3 != 0) return false;
                else
                    return true;
            }
            return false;
        }

        public string taomahd(DateTime ngay,string masv)
        {
            string sv = masv.Substring(6);
            string mahd = string.Concat("HD");
            int day = ngay.Day, month = ngay.Month, year = ngay.Year;
            string n = year.ToString().Substring(2);
            string ma=string.Concat(mahd,day.ToString());
            string ma1= string.Concat(ma,month.ToString());
            string ma2= string.Concat(ma1,n);
            string ma3 = string.Concat(ma2,sv);
            return ma3;
        }
    }
}
