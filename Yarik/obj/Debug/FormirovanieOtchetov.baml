   M S B A M L   `   `   `  ����@  <Yarik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YarikYarik  5   	        Yarik.FormirovanieOtchetov   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Yarik     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$6  0Окно формирования отчетов��5	   	   $	��450��6+   $	��800��68    � WindowState$ 	Maximized=�6D   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $	��370 �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ StartDatePicker��5      $��0��6.   $��2��6;   $	��350��6K   $��40��6W   ���#D2E6F3)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Дата начала��6x   $��10q�6�   $��14(�6�     5   
   -   5        $ EndDatePicker��5      $��1��6,   $��2��69   $	��350��6I   $��40��6U   ���#D2E6F3$! Дата окончания��6v   $��10q�6�   $��14(�6�   �� 5    
   -   5         ��Name$ ReportComboBox��5       $��3��6+   $��2��68   $	��350��6H   $��40��6T   ���#D2E6F3$! Выберите отчет��6u   $��10q�6�   $��14(�6�   6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ RentalsWatch��5!      $��1��6)   $��2��66   ���#C4C4C4   CanUserAddRows .  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $��12��6�   $y�	Collapsed=�6�      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$( "Дата начала аренды��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
RentalDate+6D     5$      $. (Дата окончания аренды��6D    6%   �� *
ReturnDate+6D     5%      $' !Дата бронирования��6I    6%   �� *ReservationDate+6I     5&      $ Сумма оплаты��6C    6%   �� *	TotalCost+6C     5'      $ Клиент��6L    6%   �� *Clients.ClientName+6L     5(      $ Оборудование��6Q    6%   �� *Equipment.EquipmentName+6Q     5)      $ Статус заказа��6Y    6%   �� *!RentalsStatus.RentalsStatusName+6Y   5+        5,   
   -   5        $ EquipmentWatch��5,      $��12��6+   $��1��6=   $��2��6J   ���#C4C4C4 .  	 . 
 .  $y�	Collapsed=�6�    5-        5.      $/ )Название оборудования��6G    6%   �� *EquipmentName+6G     5/      $' !Инвентарный номер��6I    6%   �� *InventoryNumber+6I     50      $% Стоимость аренды��6D    6%   �� *
RentalCost+6D     51      $, &Количество в наличии��6D    6%   �� *
StockCount+6D     52      $, &Стоимость за единицу��6B    6%   �� *
UnitCost+6B     53      $ Категория��6_    6%   �� *'%EquipmentCategories.EquipCategoryName+6_     54      $ Статус��6]    6%   �� *%#EquipmentStatus.EquipmentStatusName+6]   56      �� 57   
   -   5        $��10��57      $��2��6   ���#6C99C3$	��350��6D   $)��#Сформировать отчет��6P   $��14(�6m   
�������6�   �� 58   
   -   5        $��11��58      $��2��6   ���#0D52AC$	��350��6D   $��Очистить поля��6P   $��14(�6h   
�������6�   �� 59   
   ���#D2E6F3���#032E66$��1��6>   �� 5:   
   ���#D2E6F3���#032E66$��0��6>   �� 5;   
   ���#D2E6F3$-��'Формирование отчетов��6)   $��1��6E   ���#032E66$��20(�6j   $��Center=�6x   �� 5<   
   -   5        ���#6C99C3$��30��5<   &   $��30��61   $��0q�6=    J� Clip 5=      �� 5>       �� RadiusX$ 10Q�6$    �� RadiusY$ 10Q�61    �� Rect$ 	0,0,30,30�6>   5@      '  !MaterialDesignThemes.Wpf.PackIcon  5A   
      Kind$ 	ArrowLeft=�6"   
���   �$��Center=�6F   $��Center=�6a   5B      5C      