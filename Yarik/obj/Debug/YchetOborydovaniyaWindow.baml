   M S B A M L   `   `   `  ����@  <Yarik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YarikYarik  5   	   $    Yarik.YchetOborydovaniyaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Yarik     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$0  *Окно учет оборудования��5	   	   $	��450��6(   $	��800��65    � WindowState$ 	Maximized=�6A   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $	��370 �6   .+�5   
   �� -   5         ��Name$
 Name��5   �   $��0��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название*��6]   $��10q�6�   $��14(�6�   6�   �� 5   
   -   5        $ Number��5   �   $��1��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$ Номер*��6]   $��10q�6�   $��14(�6�   6�   �� 5    
   -   5        $ 	RentPrice��5    �   $��2��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$$ Рентальная цена*��6]   $��10q�6�   $��14(�6�   6�   �� 5!   
   -   5        $ Count��5!   �   $��3��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$ Количество*��6]   $��10q�6�   $��14(�6�   6�   �� 5"   
   -   5        $ PriceZa1��5"   �   $��4��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$- 'Стоимость за единицу*��6]   $��10q�6�   $��14(�6�   6�   �� 5#   
   -   5         ��Name$ Category��5#   �   $��5��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3$ Категория*��6^   $��10q�6�   $��14(�6�   6�   �� 5$   
   -   5        $ Status��5$   �   $��6��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3$ Статус*��6^   $��10q�6�   $��14(�6�   6�   �� 5%   
   -   5        $ Filter��5%   �   $��7��6   $��2��6    $	��350��60   $��40��6<   ���#6C99C3$ Фильтр��6^   $��10q�6�   $��14(�6�   6�   �� 5&   
   -	   5        $��8��5&      $��2��6   ���#6C99C3$	��350��6C   $��Добавить��6O   $��14(�6b   
�������6�   �� 5'   
   -
   5        $��9��5'      $��2��6   ���#6C99C3$	��350��6C   $��Изменить��6O   $��14(�6b   
�������6�   �� 5(   
   -   5        $��10��5(      $��2��6   ���#032E66$	��350��6D   $��Удалить��6P   $��14(�6b   
�������6�   �� 5)   
   -   5        $��11��5)      $��2��6   ���#0D52AC$	��350��6D   $��Очистить поля��6P   $��14(�6h   
�������6�   &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ EquipmentWatch��5*   �   $��12��6   $��1��6%   $��2��62   ���#C4C4C4   CanUserAddRows .  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$/ )Название оборудования��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *EquipmentName+6G     5-      $' !Инвентарный номер��6I    6%   �� *InventoryNumber+6I     5.      $% Стоимость аренды��6D    6%   �� *
RentalCost+6D     5/      $, &Количество в наличии��6D    6%   �� *
StockCount+6D     50      $, &Стоимость за единицу��6B    6%   �� *
UnitCost+6B     51      $ Категория��6_    6%   �� *'%EquipmentCategories.EquipCategoryName+6_     52      $ Статус��6]    6%   �� *%#EquipmentStatus.EquipmentStatusName+6]   54      �� 55   
   ���#D2E6F3���#032E66$��1��6>   �� 56   
   ���#D2E6F3$'��!Учет оборудования��6)   $��1��6B   ���#032E66$��20(�6g   $��Center=�6u   �� 57   
   ���#D2E6F3���#032E666)   �� 58   
   -   5        ���#6C99C3$��30��58   &   $��30��61   $��0q�6>    J� Clip 59      �� 5:       �� RadiusX$ 10Q�6$    �� RadiusY$ 10Q�61    �� Rect$ 	0,0,30,30�6>   5<      '  !MaterialDesignThemes.Wpf.PackIcon  5=   
      Kind$ 	ArrowLeft=�6"   
���   �$��Center=�6F   $��Center=�6a   5>      5?      