using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace QLKiTucXa
{
    public class CXulySinhvien
    {
        private CTruycapdulieu tc;
        
        private Table<SINHVIEN> dssv;
        private QLKTXDataContext dc=new QLKTXDataContext();
        public CXulySinhvien()
        {
            tc = CTruycapdulieu.khoitao();
            dssv = tc.getDSSVien();
        }

        public List<SINHVIEN> getDSSinhvien()
        {
            return dssv.ToList();
        }

        public List<SINHVIEN> getDSSinhvienDango()
        {
            return dssv.Where(x => x.tinhtrang == true).ToList();
        }

        public List<SINHVIEN> getDSSinhvienDao()
        {
            return dssv.Where(x => x.tinhtrang == false).ToList();
        }

        public List<SINHVIEN> getDSSinhVienDango_timMasv(string ma)
        {
            return dssv.Where(x => x.masv == ma && x.tinhtrang == true).ToList();
        }
        public IEnumerable<object> getDSSinhienViewDango_timMasv(string ma)
        {
            List<SINHVIEN> ds = getDSSinhVienDango_timMasv(ma);
            return ds.Select(x => new
            {
                masv = x.masv,
                maphong = x.maphong,
                tensv = x.tensv,
                ngaysinh = x.ngaysinh.Value.ToShortDateString(),
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                lop = x.lop,
                quequan = x.quequan,
                dienthoai = x.dienthoai,
                tinhtrang = x.tinhtrang,
            }).ToList();
        }
        public IEnumerable<object> getDSSinhienViewDango()
        {
            List<SINHVIEN> ds = getDSSinhvienDango();
            return ds.Select(x => new
            {
                masv = x.masv,
                maphong = x.maphong,
                tensv = x.tensv,
                ngaysinh = x.ngaysinh.Value.ToShortDateString(),
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                lop = x.lop,
                quequan = x.quequan,
                dienthoai = x.dienthoai,
                tinhtrang = x.tinhtrang,
            }).ToList();
        }


        public IEnumerable<object> getDSSinhienViewDao()
        {
            List<SINHVIEN> ds = getDSSinhvienDao();
            return ds.Select(x => new
            {
                masv = x.masv,
                maphong = x.maphong,
                tensv = x.tensv,
                ngaysinh = x.ngaysinh.Value.ToShortDateString(),
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                lop = x.lop,
                quequan = x.quequan,
                dienthoai = x.dienthoai,
                tinhtrang = x.tinhtrang,
            }).ToList();
        }


        public void them(SINHVIEN k)

        {
            k.masv = k.masv.ToUpper();
            k.lop = k.lop.ToUpper();
            k.tinhtrang = true;
            dssv.InsertOnSubmit(k);
            tc.capnhat();
        }

        public void delete(SINHVIEN a)
        {
            SINHVIEN x = tim(a.masv);
            if (x != null)
            {
                dssv.DeleteOnSubmit(a);
                tc.capnhat();
            }
            
        }
        public void xoa(SINHVIEN a)
        {
            SINHVIEN x = tim(a.masv);
            if (x != null)
            {
                x.maphong = a.maphong;
                x.tensv = a.tensv;
                x.ngaysinh = a.ngaysinh;
                x.gioitinh = a.gioitinh;
                x.lop = a.lop;
                x.dienthoai = a.dienthoai;
                x.quequan = a.quequan;
                x.tinhtrang = false;

                tc.capnhat();
            }
        }

        public SINHVIEN tim(string mahang)
        {
            foreach (SINHVIEN a in dssv.Where(x => x.masv == mahang))
            {
                return a;
            }
            return null;
        }

        public void kiemtra()
        {
            foreach(SINHVIEN a in dssv)
            {
                HOPDONG hd = tim_hd(a.masv);
                if (hd == null)
                {
                    delete(a);
                }
            }
        }

        public HOPDONG tim_hd(string masv)
        {
            foreach (HOPDONG a in dc.HOPDONGs.Where(x => x.masv == masv))
            {
                return a;
            }
            return null;
        }
        public void sua(SINHVIEN a)
        {
            SINHVIEN x = tim(a.masv);
            if (x != null)
            {
                x.maphong = a.maphong;
                x.tensv = a.tensv;
                x.ngaysinh = a.ngaysinh;
                x.gioitinh = a.gioitinh;
                x.lop = a.lop;
                x.dienthoai = a.dienthoai;
                x.quequan = a.quequan;
                x.tinhtrang = a.tinhtrang;

                tc.capnhat();
            }
        }

        
    }
}
