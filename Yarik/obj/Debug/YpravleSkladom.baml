   M S B A M L   `   `   `  ����@  <Yarik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YarikYarik  5   	       Yarik.YpravleSkladom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Yarik     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$2  ,Окно управления складом��5	   	   $	��450��6)   $	��800��66    � WindowState$ 	Maximized=�6B   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $	��370 �6   .+�5   
   �� -   5         ��Name$ Oborudovanie��5   �   $��0��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Оборудование*��6^   $��10q�6�   $��14(�6�   6�   �� 5   
   -   5         ��Name$ 
HowTextBox��5   �   $��1��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$6 0Сколько заказать на склад*��6]   $��10q�6�   $��14(�6�   6�   �� 5    
   -   5        $��10��5       $��2��6   ���#6C99C3$	��350��6D   $&�� Заказать на склад��6P   $��14(�6l   
�������6�   �� 5!   
   -   5        $��11��5!      $��2��6   ���#0D52AC$	��350��6D   $��Очистить поля��6P   $��14(�6h   
�������6�   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ EquipmentWatch��5"   [   $��1��6   $��11��6    $��2��62   ���#C4C4C4   CanUserAddRows .  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$/ )Название оборудования��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *EquipmentName+6G     5%      $' !Инвентарный номер��6I    6%   �� *InventoryNumber+6I     5&      $% Стоимость аренды��6D    6%   �� *
RentalCost+6D     5'      $, &Количество в наличии��6D    6%   �� *
StockCount+6D     5(      $  Себестоимость��6B    6%   �� *
UnitCost+6B     5)      $ Категория��6_    6%   �� *'%EquipmentCategories.EquipCategoryName+6_   5+      �� 5,   
   ���#D2E6F3���#032E66$��1��6>   �� 5-   
   ���#D2E6F3$)��#Управление складом��6)   $��1��6C   ���#032E66$��20(�6h   $��Center=�6v   �� 5.   
   ���#D2E6F3���#032E666)   �� 5/   
   -   5        ���#6C99C3$��30��5/   &   $��30��61   $��0q�6>    J� Clip 50      �� 51       �� RadiusX$ 10Q�6$    �� RadiusY$ 10Q�61    �� Rect$ 	0,0,30,30�6>   53      '  !MaterialDesignThemes.Wpf.PackIcon  54   
      Kind$ 	ArrowLeft=�6"   
���   �$��Center=�6F   $��Center=�6a   55      56      