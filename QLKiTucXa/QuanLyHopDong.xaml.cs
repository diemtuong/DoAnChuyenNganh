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
    /// Interaction logic for QuanLyHopDong.xaml
    /// </summary>
    public partial class QuanLyHopDong : Window
    {
        private QLKTXDataContext dc;
        private CXulyHopdong xl;
        private CXulySinhvien xlsv = new CXulySinhvien();
        public QuanLyHopDong()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dc = new QLKTXDataContext();
            xl = new CXulyHopdong();
            cmbManv.ItemsSource = dc.NHANVIENs.ToList();
            dgHopdong.ItemsSource = xl.getDSHopdong();
        }

        private void CommandBinding_Executed_themHD(object sender, ExecutedRoutedEventArgs e)
        {
            NHANVIEN nv = (NHANVIEN)cmbManv.SelectedItem;
            HOPDONG hd = new HOPDONG();
            hd.mahd = txtMahd.Text;
            hd.masv = txtMasv.Text;
            hd.manv = nv.manv;
            hd.ngaybd = dpNgaybatdau.SelectedDate;
            hd.ngaykt = dpNgayketthuc.SelectedDate;

            xl.them(hd);

            dgHopdong.ItemsSource = xl.getDSHopdong();
        }

        private void CommandBinding_CanExecute_themHD(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMasv.Text == "" || txtMahd.Text == "")
                return;
            if (dpNgaybatdau.SelectedDate == null)
                return;
            if (dpNgayketthuc.SelectedDate == null)
                return;
            if (cmbManv.SelectedValuePath == null) return;

            if (txtMahd.Text.Length != 12) return;

            DateTime dt;
            DateTime date;
            if (dpNgaybatdau.SelectedDate != null && dpNgayketthuc.SelectedDate != null)
            {
                dt = dpNgaybatdau.SelectedDate.Value;
                date = dpNgayketthuc.SelectedDate.Value;
                if (xl.kt_rangbuoc_thoigian(dt, date) == false) return;
            }
            else return;

            if (xl.tim(txtMahd.Text) != null) return;

            if (xlsv.tim(txtMasv.Text) == null) return;

            e.CanExecute = true;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
