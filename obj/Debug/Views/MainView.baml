   M S B A M L   `   `   `  ����V  REcommerceERPConnector(V1.0), Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EcommerceERPConnector_V1._0_.Views"EcommerceERPConnector_V1._0_.Views  5   	   1    +EcommerceERPConnector_V1._0_.Views.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:EcommerceERPConnector_V1._0_.Views     5   	   -   5          � Title$  MainView��5   	   $	��450��6   $	��800��6'   
������  � AllowsTransparency .  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ��  �� CornerRadius$ 50��6   ��5   
   �� 5       �� ImageSource$ .././Images/loginbg.jpg��6    j� Stretch$
 None=�5      ._�5   
   �� $ 20��5   	   $��5q�5   	    J� Opacity$
 0.95Q�5   	   ��5      �� 5      	 �� 
StartPoint$		 0,0&�6&   
 �� EndPoint$	
 1,1&�67   .��5      �  � Color$ #462AD8��6#    � Offset$ 0Q�63   � 5      $ #DA34AE��6#   $
 0.75Q�63   � 5      $ #8A16C1��6#   $ 1Q�63   5!      ��5$      �� 5%      $		 0,1&�6&   $	
 1,0&�67   .��5&      � $ #060531��6#   $ 0Q�63   � 5'      $ #1B1448��6#   $
 0.75Q�63   5(      ._�5*      �  � RowDefinitions 5+      �� 5,      $��30 �6$   �� 5-      $
��399* �6$   �� 5.      $	��11* �6$   �� 5/      $��0* �6$   .+�51      � $��	38,0,10,0q�6    � ColumnDefinitions 52      �� 53      �� 54      $��25 �6+   �� 55      $��25 �6+   �� 56      $��5 �6+   .+�59      �� $��	CONNECTOR��6!   
�������$��18(�5;   !   $��0��5<   !   $	��Top=�5=   !   $��	-14,6,0,0q�5>   !   $��24��64   �� 5@      -   5         ��Name$ btnMinimize��5@   !   ���#28AEED$��0q�5B   !   $��-��5C   !   
�������$��16(�5E   !    � Cursor$
 Hand��5F   !   $��1��5G   !   5J      �� 5L      -   5        $ btnClose��5L   !   ���#DA34AE$��0q�5N   !   $��X��5O   !   
�������$��16(�5Q   !   $
 Hand��5R   !   $��2��5S   !   5U      5V      �� 5W      $ 70��6   �� 5X      $��
-1,2,534,0q�6    �� Padding$ 5q�5Y      ���#8A16C1
�����F�$ 20��5\      $	��Top=�5]      $	��409��65   $��1��6B   $��3��6O   ._�5^      �� $	��159��6!   $��	304,0,0,0q�6.   5`      5a      �� 5b      $
��Left=�6   $��	14,57,0,0q�5c      $��20(�5d      $��Medium"�5e      $��
Montserrat)�5f      $��1��5g      $
��Wrap=�5h      $��Retrive Table columns��5i      $	��Top=�5j      �� 5k      $
��Left=�6   $��
36,212,0,0q�5l      $��15(�5m      $��Medium"�5n      $��
Montserrat)�5o      $��1��5p      $
��Wrap=�5q      $��E-Commerce Endpoint��5r      $	��Top=�5s      �� 5t      -   5        $��ecommerceGet��5v      $
��Left=�5t      $��
33,237,0,0q�5u      $��1��5w       �� TextWrapping$
 Wrap=�5x      $��URL...��5y      $	��Top=�5z      $	��177��5{      �� 5|      $
��Left=�6   $��
75,275,0,0q�5}      $��15(�5~      $��Medium"�5      $��
Montserrat)�5�      $��1��5�      $
��Wrap=�5�      $��ERP Endpoint��5�      $	��Top=�5�       J� RenderTransformOrigin$ 0.485,0.922&�6-   �� 5�      -   5        $��erpGet��5�      $
��Left=�5�      $��
35,302,0,0q�5�      $��1��5�      $
 Wrap=�5�      $��URL or Json Object...��5�      $	��Top=�5�      $	��177��5�      �� 5�      -   5        $��Send request��5�      $
��Left=�5�      $��
87,380,0,0q�5�      $��1��5�      $	��Top=�5�      6-   �� 5�      $��.././Images/table.png��5�      $
��Left=�5�      $	��100��5�      $��	69,97,0,0q�5�      $��1��5�      $	��Top=�5�      $	��100��5�      &   System.Windows.Controls.DataGrid  5�      -   5        $��	dataTable��5�      $��1��5�      $��275,46,16,80q�5�         CanUserResizeColumns .    CanUserResizeRows .     CanUserSortColumns .    AutoGenerateColumns .  ��5�      �� *Item+   ColumnHeaderStyle 5�      �� 5�       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5�      ��  �� Property � �� �� Value �#8A16C15�   -   �� 5�       � ��$ 10(�69   �� 5�       � ��$ 
Montserrat)�6;   �� 5�       � ��$ Center=�6I   5�         	CellStyle 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"  6    .�5�      ��  � ��
 ��� �6<   �� 5�       � ��$ 1 1 1 1q�6@   5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    FontSize$ 10Q�6_       Header$  
New Object��6m   !   Width5  /System.Windows.Controls.DataGridLengthConverter$! * 6�   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6?   �� # �� Path$# erpObj�6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $  Is Empty��6R   $! * 6d   " 61   �� $# isEmpty�6d     5�      $  Remove from Json��6T   $! * 6n   " 61   �� $# 	isRemoved�6n     5�      $ 10Q�6R   $  Manual Input��6`   $! * 6v   " 6-   �� $# manualInput�6v   4	  .System.Windows.Controls.DataGridTemplateColumn	  5�      $  Original Value��61   $! * 6I   $ 	  CellTemplate$ 5�      �� 5�   "   .R�5�   &   �� ��61   �� *ecommerceObjList+% �� SelectedValue% 5�   1   �� *ecommerceObj+& �� SelectedItem& 5�   1   �� *ecommerceObj+5�   #   5�      	  5�      $  Constraint 
 Location��62   $! * 6V   $ 5�      �� 5�   "   .R�5�   &   �� $
��cmb2��6/   ��6;   �� *constraints+% 5�   1   �� *
constraint+& 5�   1   �� *
constraint+5�   #   5�        5�      $ 10Q�6V   $  Extention 
 Value��6d   $! * 6�   " 6-   �� $# cinstraintValue�6�   5�      �� 5�      $
��Left=�6   $��274,329,0,0q�67   $��13(�6L   $��1��6Z   $
��Wrap=�6g   $c��]To add a variable value into your generated object write it inside two curly brackets ' {} '.��6{   $	��Top=�6�   
����� �' �� TextAlignment$' Center=�6
  $	��502��6!  $��21��6-  �� 5�      -   5        $��Generate Object��5�      $
��Left=�63   $��682,378,0,0q�6N   $��1��6c   $	��Top=�6p   $ 
1.82,0.977&�6�   $��19��6�   $	��100��6�   6�   �� 5�      -	   5        $��getListEndpoint��5�   5   $
��Left=�6   $��283,353,0,0q�6L   $��1��6a   $
 Wrap=�6n   $?��9[E-Commerce] Get Endpoitn from which data will be read...��6�   $	��Top=�6�   $	��319��6�   $��20��6�   �� 5�      -
   5        $��PostListEndpoint��5�   5   $
��Left=�6   $��282,379,0,0q�6M   $��1��6b   $
 Wrap=�6o   $+��%[ERP] Post Endpoint to add new etires��6�   $	��Top=�6�   $	��207��6�   $��20��6�   $ 0.492,0.446&�6�   5�      5�      5�      5�      