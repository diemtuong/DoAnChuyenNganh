   M S B A M L   `   `   `  ����D  @QLKiTucXa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QLKiTucXa	QLKiTucXa  5   	       QLKiTucXa.QuanLySinhVien   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QLKiTucXa     5   	   -   5          � Title$  QuanLySinhVien��5   	   $	��500��6    $	��850��6-    J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ local:CMyCommands.them��5
      6�     5   
   -   5        $ local:CMyCommands.xoa��5      6�     5   
   -   5        $ local:CMyCommands.timkiem��5      6�     5   
   -   5        $ local:CMyCommands.sua��5      6�   .��5      �� $
��Auto=�6   .��5   
   ��  � 	Resources 5       �� 
TargetType   stLabel �� Property �� Value  	stTextBox  stTComboBox  stButton(  "System.Windows.Controls.DatePicker  stDatePicker��%�  &	        &	 �     &	 m    &	 �    &	 �    �� 5      " ��6   .�5      ��  � ��$ 20 0 q�6/   6?   �� 5       � ��$	 100��6.   6<   �� 5       � ��$ 30��6/   6<   �� 5       � ��$
 Bold"�63   6B   5      �� 5      " ��6   .�5      ��  � ��$ 5q�6/   6;   �� 5       � ��$	 200��6.   6<   �� 5       � ��$ 25��6/   6<   5      �� 5      " ��6   .�5       ��  � ��$ 5q�6/   6;   �� 5!       � ��$	 200��6.   6<   5"      �� 5$      " ��6   .�5%      ��  � ��$ 70��6.   6;   �� 5&       � ��$ 25��6/   6<   �� 5'       � ��$ 	15 5 20 5q�6/   6C   �� 5(       � ��
 �����6G   5)      �� 5*      "  6   .�5+      ��  � ��$	 200��6.   6<   �� 5,       � ��$ 25��6/   6<   �� 5-       � ��$ 5q�6/   6;   5.      5/      .+�50      ]� .+�51      �� $��QUẢN LÝ SINH VIÊN��6   $��30(�64   $
��Bold"�6B   $��Center=�6T   6s   52      ]� 53      .+�54      �� $��
10 10 0 10q�6   $	��400��61   .+�55      ]� $��0 0 0 5q�6    .+�56      �� $��Mã sinh viên: ��6    #��[  69   �� 57      -   5         ��Name$ txtMasv��57   s   #��[ 6"   ��6Q   �� *masv+ �� Mode$ OneWay=�6s   58      ]� 5:      $�� 0 0 0 5q�6    .+�5;      �� $��Mã phòng: ��6    #��[  65   �� 5<      -   5        	 ��Name$	 
cmbMaphong��5<   U   #��[ 6$   
 �� SelectedValuePath$
 maphong��6i    �� DisplayMemberPath$ maphong��6�   5=      ]� 5?      $�� 0 0 0 5q�6    .+�5@      �� $��Tên sinh viên: ��6    #��[  6:   $��Center=�6g   �� 5A      -   5        $ txtTensv��5A   t   #��[ 6E   ��6"   �� *tensv+$ OneWay=�6t   5B      ]� 5D      $�� 0 0 0 5q�6    .+�5E      �� $��Ngày sinh: ��6    #��[  66     5F      -	   5          Name$ 
dpNgaysinh��5F   X   #��[ 6&   6X   5G      ]� 5I      $��0 0 0 5q�6    .+�5J      �� $��Giới tính��6    #��[  64   6c   ]� 5K      .+�5L      	� -
   5        $��rdoNam��5L   8   $	��Nam��6*    d� 	IsChecked$
 TrueY�6F   $��	30 5 20 0q�6W    	� 	GroupName$ 	gGioitinh��6j   6�   	� 5M      -   5        $��rdoNu��5M   7   $
��Nữ��6*   $��5q�6D   $ 	gGioitinh��6O   6g   5N      5O      5P      �� 5R      $��
20 10 0 10q�6   $	��400��61   .+�5S      ]� $��0 0 0 5 q�6    .+�5T      �� $��Lớp: ��6    #��[  60   �� 5U      -   5        $ txtLop��5U   r   #��[ 6C   $��0 0 00 0q�6�   ��6"   �� *lop+$ OneWay=�6�   5V      ]� 5X      $�� 0 0 0 5q�6    .+�5Y      �� $��Điện thoại: ��6    #��[  67   �� 5Z      -   5        $ txtDienthoai��5Z   r   #��[ 6C   ��6"   �� *lop+$ OneWay=�6r   5[      ]� 5]      $�� 0 0 0 5q�6    .+�5^      �� $��Quê quán: ��6    #��[  65   �� 5_      -   5        $ 
txtQuequan��5_   s   #��[ 6D   ��6"   �� *lop+$ OneWay=�6s   5`      ]� 5b      $��0 0 0 5q�6    .+�5c      �� $��Tình trạng:��6    #��[  66   6e   ]� 5d      .+�5e      	� -   5        $��rdoChuanbio��5e   ?   $��Chuẩn bị ở��6*   $ 
gTinhtrang��6R   $��30 5 5 5q�6i   $
 TrueY�6{   6�   	� 5f      -   5        $��rdoDango��5f   ;   $��	Đang ở��6*   $ 
gTinhtrang��6K   $��5q�6b   6o   	� 5g      -   5        $��rdoDao��5g   9   $��Đã ở��6*   $ 
gTinhtrang��6G   $��5q�6^   6k   5h      5i      5j      5k      ]� 5l      $��Center=�6   $��0 0 0 10q�65   .+�5m      �� -   5         ��Name$ btnThem��5m   G   #��[ 6   $��Thêm��6X   $��local:CMyCommands.them��6g   �� 5n      -   5        $ btnXoa��5n   G   #��[ 6   $
��Xóa��6W   $��local:CMyCommands.xoa��6e   �� 5o      -   5        $ btnSua��5o   G   #��[ 6   $��Sửa��6W   $��local:CMyCommands.sua��6e   �� 5p      -   5        $ 
btnTimkiem��5p   G   #��[ 6   $��Tìm kiếm��6[   $��local:CMyCommands.timkiem��6n   �� 5q      -   5        $ 	btnLammoi��5q   G   #��[ 6   $��
Làm mới��6Z   6l   �� 5r      -   5        $ btnThoat��5r   G   #��[ 6   $��Thoát��6Y   6i   5s      �� 5t      $��0��6   $��0��6$   $2��,Danh sách sinh viên đang ở kí túc xá��61   $��Italic$�6`   $
��Bold"�6s   $��15(�6�   $��	15 0 15 0q�6�   6�   9� 5u      .��5v      �� .+�5w      &   System.Windows.Controls.DataGrid  -   5        $��dgDSSVDango��5w         AutoGenerateColumns .  $��	15 0 15 0q�6K   $	��200��6^   $

 masv��6k      Columns 5x      0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sinh viên��6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *masv+   ClipboardContentBinding 6F   Z� 6i     5z      $ 
Mã phòng��6l    6-   �� *	maphong+ 6I   Z� 6l     5{      $ Tên sinh viên��6j    6-   �� *tensv+ 6G   Z� 6j     5|      $ 
Ngày sinh��6m    6-   �� *
ngaysinh+ 6J   Z� 6m     5}      $ giới tính��6m    6-   �� *
gioitinh+ 6J   Z� 6m     5~      $ Lớp��6h    6-   �� *lop+ 6E   Z� 6h     5      $ Điện thoại��6n    6-   �� *	dienthoai+ 6K   Z� 6n     5�      $ 
Quê quán��6l    6-   �� *	quequan+ 6I   Z� 6�   5�      5�      5�      �� 5�      $1��+Danh sách sinh viên đã ở kí túc xá��6   $��Italic$�6B   $
��Bold"�6U   $��15(�6g   $��
15 15 15 0q�6u   6�   9� 5�      .��5�      �� .+�5�        -   5        $��	dgDSSVDao��5�        .  $��
15 0 15 15q�6M   $	��200��6a   $

 masv��6n    5�        5�      $ Mã sinh viên��6m    61   �� *masv+ 6J   Z� 6m     5�      $ 
Mã phòng��6p    61   �� *	maphong+ 6M   Z� 6p     5�      $ Tên sinh viên��6n    61   �� *tensv+ 6K   Z� 6n     5�      $ 
Ngày sinh��6q    61   �� *
ngaysinh+ 6N   Z� 6q     5�      $ giới tính��6q    61   �� *
gioitinh+ 6N   Z� 6q     5�      $ Lớp��6l    61   �� *lop+ 6I   Z� 6l     5�      $ Điện thoại��6r    61   �� *	dienthoai+ 6O   Z� 6r     5�      $ 
Quê quán��6p    61   �� *	quequan+ 6M   Z� 6�   5�      5�      5�      5�      5�      5�      