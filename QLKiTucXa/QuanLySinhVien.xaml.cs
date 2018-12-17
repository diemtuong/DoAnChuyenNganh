using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKiTucXa
{
    /// <summary>
    /// Interaction logic for QuanLySinhVien.xaml
    /// </summary>
    public partial class QuanLySinhVien : Window
    {
        private QLKTXDataContext dc;
        private CXulySinhvien xl;
        private CXulyHopdong xlhd = new CXulyHopdong();
        public QuanLySinhVien()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpNgaysinh.SelectedDate = DateTime.Now;
            xl = new CXulySinhvien();
            dc = new QLKTXDataContext();
            
            
            cmbMaphong.ItemsSource = dc.PHONGs.ToList();
            xl.kiemtra();
            dgDSSVDango.ItemsSource = xl.getDSSinhienViewDango();
            dgDSSVDao.ItemsSource = xl.getDSSinhienViewDao();
        }

        private void CommandBinding_Executed_themSV(object sender, ExecutedRoutedEventArgs e)
        {
            PHONG k = (PHONG)cmbMaphong.SelectedItem;
            SINHVIEN a = new SINHVIEN();
            a.masv = txtMasv.Text;
            a.maphong = k.maphong;
            a.tensv = txtTensv.Text;
            a.ngaysinh = dpNgaysinh.SelectedDate;
            if (rdoNam.IsChecked == true)
                a.gioitinh = true;
            else a.gioitinh = false;
            a.lop = txtLop.Text;
            a.quequan = txtQuequan.Text;
            a.dienthoai = txtDienthoai.Text;
            a.tinhtrang = true;

            xl.them(a);

            dgDSSVDango.ItemsSource = xl.getDSSinhienViewDango();
            dgDSSVDao.ItemsSource = xl.getDSSinhienViewDao();
            QuanLyHopDong hd = new QuanLyHopDong();
             hd.txtMahd.Text = xlhd.taomahd(DateTime.Now, txtMasv.Text);
            hd.txtMasv.Text = txtMasv.Text;
            hd.Show();

        }

        private void CommandBinding_CanExecute_themSV(object sender, CanExecuteRoutedEventArgs e)
        {
            //Kiểm tra chuỗi rỗng
            if (txtQuequan.Text == "" || txtDienthoai.Text == ""||txtMasv.Text==""||txtTensv.Text==""||txtLop.Text=="")
                return;

            //Kiểm tra ComboBox
            if (cmbMaphong.SelectedItem == null) return;
            //Kiem tra masv
            string masv = txtMasv.Text;
            if (masv.Length != 10) return;
            //Kiểm tra số điện thoại
            string str = txtDienthoai.Text;            
            if (str.Length != 10) return;
            //Kiểm tra tồn tại sinh viên
            SINHVIEN sv = xl.tim(txtMasv.Text);
            if (sv != null) return;
            //Kiểm tra mã sinh viên            
            string ma = txtMasv.Text.Substring(0,2);
            if (ma != "CD" && ma != "cd"&& ma != "DH" && ma != "dh") return;
            //Kiểm tra giới tính-phòng
            string maphong = cmbMaphong.SelectedValue.ToString().Substring(1,1);
            int map = Int32.Parse(maphong);
            if (map%2!=0 && rdoNu.IsChecked == true) return;
            if (map%2 == 0 && rdoNam.IsChecked == true) return;

            if (rdoDango.IsChecked == true || rdoDao.IsChecked == true) return;            

            e.CanExecute = true;

        }

        private void dgDSSVDango_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDSSVDango.SelectedValue != null)
            {
                string ma = dgDSSVDango.SelectedValue.ToString();

                foreach (SINHVIEN a in dc.SINHVIENs.Where(x => x.masv == ma))
                {
                    txtMasv.Text = a.masv;
                    cmbMaphong.Text = a.maphong;
                    txtTensv.Text = a.tensv;
                    dpNgaysinh.SelectedDate = a.ngaysinh;
                    if (a.gioitinh == true) rdoNam.IsChecked = true;
                    else rdoNu.IsChecked = true;
                    txtLop.Text = a.lop;
                    txtDienthoai.Text = a.dienthoai;
                    txtQuequan.Text = a.quequan;
                    rdoDango.IsChecked = true;
                    break;
                }
            }     
        }

        private void dgDSSVDao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDSSVDao.SelectedValue != null)
            {
                string ma = dgDSSVDao.SelectedValue.ToString();
                foreach (SINHVIEN a in dc.SINHVIENs.Where(x => x.masv == ma))
                {
                    txtMasv.Text = a.masv;
                    cmbMaphong.Text = a.maphong;
                    txtTensv.Text = a.tensv;
                    dpNgaysinh.SelectedDate = a.ngaysinh;
                    if (a.gioitinh == true) rdoNam.IsChecked = true;
                    else rdoNu.IsChecked = true;
                    txtLop.Text = a.lop;
                    txtDienthoai.Text = a.dienthoai;
                    txtQuequan.Text = a.quequan;
                    rdoDao.IsChecked = true;
                    break;
                }
            }
            
        }

        private void CommandBinding_Executed_xoaSV(object sender, ExecutedRoutedEventArgs e)
        {
            string ma = dgDSSVDango.SelectedValue.ToString();
            SINHVIEN a = xl.tim(ma);
            xl.xoa(a);

            txtMasv.Text="";
            cmbMaphong.SelectedItem="";
            txtTensv.Text="";
            dpNgaysinh.SelectedDate=DateTime.Now;
            rdoNam.IsChecked = true;
            txtLop.Text="";
            txtQuequan.Text="";
            txtDienthoai.Text="";
            rdoChuanbio.IsChecked=true;

            dgDSSVDango.ItemsSource = xl.getDSSinhienViewDango();
            dgDSSVDao.ItemsSource = xl.getDSSinhienViewDao();
        }

        private void CommandBinding_CanExecute_xoaSV(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgDSSVDango == null || dgDSSVDango.SelectedItem == null) return;
            if (dgDSSVDao.SelectedItem != null) return;

            e.CanExecute = true;
        }

       

        private void CommandBinding_Executed_timkiemSV(object sender, ExecutedRoutedEventArgs e)
        {
            SINHVIEN a = xl.tim(txtMasv.Text);
            if (a == null) MessageBox.Show("Không tìm thấy!");
            else
                dgDSSVDango.ItemsSource = xl.getDSSinhienViewDango_timMasv(txtMasv.Text);
            //MessageBox.Show("Mã sv: " + a.masv + "\nMã phòng: " + a.maphong + "\nTên sv: " + a.tensv + "\nGiới tính: " + a.gioitinh + "\nLớp: " + a.lop + "\nQuê quán: " + a.quequan + "\nĐiện thoại: " + a.dienthoai + "\nTình trạng" + a.tinhtrang);
        }

        private void CommandBinding_CanExecute_timkiemSV(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMasv.Text == "") return;

            string str = txtMasv.Text;
            if (str.Length != 10)
            {
                return;
            }

            e.CanExecute = true;
        }

        private void CommandBinding_Executed_suaSV(object sender, ExecutedRoutedEventArgs e)
        {
            PHONG k = (PHONG)cmbMaphong.SelectedItem;
            SINHVIEN a = new SINHVIEN();
            a.masv = txtMasv.Text;
            a.maphong = k.maphong;
            a.tensv = txtTensv.Text;
            a.ngaysinh = dpNgaysinh.SelectedDate;
            if (rdoNam.IsChecked == true)
                a.gioitinh = true;
            else a.gioitinh = false;
            a.lop = txtLop.Text;
            a.quequan = txtQuequan.Text;
            a.dienthoai = txtDienthoai.Text;
            if (rdoDango.IsChecked == true)
                a.tinhtrang = true;
            else if (rdoDao.IsChecked == true) a.tinhtrang = false;

            xl.sua(a);

            dgDSSVDango.ItemsSource = xl.getDSSinhienViewDango();
            dgDSSVDao.ItemsSource = xl.getDSSinhienViewDao();
        }

        private void CommandBinding_CanExecute_suaSV(object sender, CanExecuteRoutedEventArgs e)
        {
            //Kiểm tra chuỗi rỗng
            if (txtQuequan.Text == "" || txtDienthoai.Text == "" || txtMasv.Text == "" || txtTensv.Text == "" || txtLop.Text == "")
                return;

            //Kiểm tra ComboBox
            if (cmbMaphong.SelectedItem == null) return;

            //Kiem tra masv
            string masv = txtMasv.Text;
            if (masv.Length != 10) return;

            string ma = txtMasv.Text.Substring(0, 2);
            if (ma != "CD" && ma != "cd" && ma != "DH" && ma != "dh") return;

            //Kiểm tra số điện thoại
            string str = txtDienthoai.Text;
            if (str.Length != 10) return;

            //Kiểm tra tồn tại sinh viên
            SINHVIEN sv = xl.tim(txtMasv.Text);
            if (sv == null) return;

            //Kiểm tra giới tính-phòng
            string maphong = cmbMaphong.SelectedValue.ToString().Substring(1, 1);
            if (maphong == "1" && rdoNu.IsChecked == true) return;
            if (maphong == "2" && rdoNam.IsChecked == true) return;

            if (rdoChuanbio.IsChecked == true) return;

            e.CanExecute = true;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLammoi_Click(object sender, RoutedEventArgs e)
        {
            txtMasv.Text = "";
            cmbMaphong.SelectedItem = "";
            txtTensv.Text = "";
            dpNgaysinh.SelectedDate = DateTime.Now;
            rdoNam.IsChecked = true;
            txtLop.Text = "";
            txtQuequan.Text = "";
            txtDienthoai.Text = "";
            rdoChuanbio.IsChecked = true;
        }
    }
}
