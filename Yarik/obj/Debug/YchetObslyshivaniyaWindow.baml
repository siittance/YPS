   M S B A M L   `   `   `  ����@  <Yarik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YarikYarik  5   	   %    Yarik.YchetObslyshivaniyaWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Yarik     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$2  ,Окно учета обслуживания��5	   	   $	��450��6)   $	��800��66    � WindowState$ 	Maximized=�6B   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $	��370 �6   .+�5   
   �� -   5         ��Name$ ComboOborudov��5   �   $��0��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Оборудование*��6^   $��10q�6�   $��14(�6�    �� DisplayMemberPath$ EquipmentName��6�   �� 5   
   -   5         ��Name$ DateObslText��5   �   $��1��6   $��2��6   $	��350��6/   $��40��6;   ���#D2E6F3$( "Дата обслуживания*��6]   $��10q�6�   $��14(�6�   6�   �� 5    
   -   5        $ ComboTypeWork��5    �   $��2��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3$ Вид работ*��6^   $��10q�6�   $��14(�6�   $ NameWorkType��6�   �� 5!   
   -   5        $ ComboStatus��5!   �   $��3��6   $��2��6    $	��350��60   $��40��6<   ���#D2E6F3$ Статус*��6^   $��10q�6�   $��14(�6�   $ 
MainStatus��6�   �� 5"   
   -   5        $��9��5"      $��2��6   ���#6C99C3$	��350��6C   $��Добавить��6O   $��14(�6b   
�������6�   �� 5#   
   -   5        $��10��5#      $��2��6   ���#6C99C3$	��350��6D   $��Изменить��6P   $��14(�6c   
�������6�   �� 5$   
   -   5        $��11��5$      $��2��6   ���#0D52AC$	��350��6D   $��Очистить поля��6P   $��14(�6h   
�������6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ MaintenanceWatch��5%   [   $��1��6   $��11��6    $��2��62   ���#C4C4C4	   CanUserAddRows	 .  
   
IsReadOnly
 .    AutoGenerateColumns .     Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$' !Дата обслуживания��6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *MaintenanceDate+6I     5(      $ Оборудование��6Q    6%   �� *Equipment.EquipmentName+6Q     5)      $ Тип работы��6P    6%   �� *WorkTypes.NameWorkType+6P     5*      $ Статус��6V    6%   �� *MaintenanceStatus.MainStatus+6V   5,      �� 5-   
   ���#D2E6F3���#032E66$��1��6>   �� 5.   
   ���#D2E6F3$'��!Учет обслуживания��6)   $��1��6B   ���#032E66$��20(�6g   $��Center=�6u   �� 5/   
   ���#D2E6F3���#032E666)   �� 50   
   -	   5        ���#6C99C3$��30��50   &   $��30��61   $��0q�6>    J� Clip 51      �� 52       �� RadiusX$ 10Q�6$    �� RadiusY$ 10Q�61    �� Rect$ 	0,0,30,30�6>   54      '  !MaterialDesignThemes.Wpf.PackIcon  55   
      Kind$ 	ArrowLeft=�6"   
���   �$��Center=�6F   $��Center=�6a   56      57      