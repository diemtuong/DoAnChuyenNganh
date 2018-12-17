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
using System.Runtime.InteropServices;


namespace QLKiTucXa
{
    /// <summary>
    /// Interaction logic for QuanLyKhu.xaml
    /// </summary>
    public partial class QuanLyKhu : Window
    {
        private CXulyKhu xl;
        private QLKTXDataContext dc;
        public QuanLyKhu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            xl = new CXulyKhu();
            dgKhu.ItemsSource = xl.getDSKhu();           
        }

        private void dgKhu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KHU k = (KHU)dgKhu.SelectedItem;
            if (k == null) return;
            txtMakhu.Text = k.makhu;
            txtTenkhu.Text = k.tenkhu;
            txtSoluongtoida.Text = k.soluongtoida.ToString();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
        private void CommandBinding_Executed_themKhu(object sender, ExecutedRoutedEventArgs e)
        {
            KHU a = new KHU();
            a.makhu = txtMakhu.Text;
            a.tenkhu = txtTenkhu.Text;
            a.soluongtoida = int.Parse(txtSoluongtoida.Text);

            xl.them(a);

            dgKhu.ItemsSource = xl.getDSKhu(); ;
        }

        private void CommandBinding_CanExecute_themKhu(object sender, CanExecuteRoutedEventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (txtMakhu.Text == "" || txtTenkhu.Text == "" || txtSoluongtoida.Text == "")
            {
                return;
            }

            //kiểm tra chiều dài chuỗi
            string str = txtMakhu.Text;
            if (str.Length != 1)
            {
                return;
            }

            //kiểm tra dữ liệu nhập vào phải số nguyên hay không.
            double dg = 0;
            if (double.TryParse(txtSoluongtoida.Text, out dg) == false) return;

            //Kiểm tra trùng mã
            string mak = txtMakhu.Text.ToUpper();
            foreach (KHU a in xl.getDSKhu().Where(x => x.makhu == mak))
            {
                if(a!=null) return;
            }
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_xoaKhu(object sender, ExecutedRoutedEventArgs e)
        {
            KHU a = (KHU)dgKhu.SelectedItem;
            xl.xoa(a);

            txtMakhu.Text = "";
            txtTenkhu.Text = "";
            txtSoluongtoida.Text = "";

            dgKhu.ItemsSource = xl.getDSKhu();
        }

        private void CommandBinding_CanExecute_xoaKhu(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgKhu == null || dgKhu.SelectedItem == null) return;
            
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_suaKhu(object sender, ExecutedRoutedEventArgs e)
        {
            KHU a = new KHU();
            a.makhu = txtMakhu.Text;
            a.tenkhu = txtTenkhu.Text;
            a.soluongtoida = int.Parse(txtSoluongtoida.Text);

            xl.sua(a);

            dgKhu.ItemsSource = xl.getDSKhu();
        }

        private void CommandBinding_CanExecute_suaKhu(object sender, CanExecuteRoutedEventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (txtMakhu.Text == "" || txtTenkhu.Text == "" || txtSoluongtoida.Text == "")
            {
                return;
            }

            //kiểm tra chiều dài chuỗi
            string str = txtMakhu.Text;
            if (str.Length != 1)
            {
                return;
            }

            //kiểm tra dữ liệu nhập vào phải số nguyên hay không.
            double dg = 0;
            if (double.TryParse(txtSoluongtoida.Text, out dg) == false) return;

            //Kiểm tra mã

            string mak = txtMakhu.Text;
            foreach (KHU a in xl.getDSKhu().Where(x => x.makhu == mak))
            {
                if (a == null) return;
            }
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_timkiemKhu(object sender, ExecutedRoutedEventArgs e)
        {
            KHU a = xl.tim(txtMakhu.Text);
            if (a == null) MessageBox.Show("Không tìm thấy!");
            else
            {
                //MessageBox.Show("Mã khu: " + a.makhu + "\nTên khu: " + a.tenkhu + "\nSố lượng tối đa: " + a.soluongtoida);
                dgKhu.ItemsSource = xl.getDSKhu().Where(x => x.makhu == a.makhu);
            }
        }

        private void CommandBinding_CanExecute_timkiemKhu(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMakhu.Text == "") return;

            string str = txtMakhu.Text;
            if (str.Length != 1)
            {
                return;
            }

            e.CanExecute = true;
        }

        private void CommandBinding_Executed_lammoiKhu(object sender, ExecutedRoutedEventArgs e)
        {
            txtMakhu.Text = "";
            txtTenkhu.Text = "";
            txtSoluongtoida.Text = "";

            dgKhu.ItemsSource = xl.getDSKhu();
        }

        private void CommandBinding_CanExecute_lammoiKhu(object sender, CanExecuteRoutedEventArgs e)
        {
            if (txtMakhu.Text == "" && txtTenkhu.Text == "" && txtSoluongtoida.Text == "")
            {
                return;
            }
            e.CanExecute = true;
        }
    }
}
