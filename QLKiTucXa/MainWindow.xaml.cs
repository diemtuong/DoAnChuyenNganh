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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKiTucXa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuHopdong_Click(object sender, RoutedEventArgs e)
        {
            QuanLyHopDong hd = new QuanLyHopDong();
            hd.Show();
        }

        private void menuSinhvien_Click(object sender, RoutedEventArgs e)
        {
            QuanLySinhVien sv = new QuanLySinhVien();
            sv.Show();
        }

        private void menuKhu_Click(object sender, RoutedEventArgs e)
        {
            QuanLyKhu k = new QuanLyKhu();
            k.Show();
        }

        private void menuDien_Click(object sender, RoutedEventArgs e)
        {
            QuanLyHoaDonTienDien k = new QuanLyHoaDonTienDien();
            k.Show();
        }
    }
}
