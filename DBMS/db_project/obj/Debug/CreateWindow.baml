   M S B A M L   `   `   `  ����E  Adb_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:db_project
db_project  5   	       db_project.CreateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:db_project     5   	     � Title$  Create entity��5   	   $	��309��6   $��415.909��6,   .��5	      � $��0,0,2,2q�6    � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ tableSelectionComboBox��5      $
��Left=�63   $��	65,15,0,0q�6N   $	��Top=�6a   $	��120��6y   $��22��6�   $��13.333(�6�   .@�5      �� $��Artist��6   �� 5      $��Painting��6   �� 5      $��
Exhibition��6   �� 5      $��Auction��6   �� 5      $
��Site��6   �� 5      $��Address��6   �� 5      $
��City��6   �� 5      $��Country��6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ newEntityDataGrid��5      $��
10,77,10,0q�6.   $��47��6B   $	��Top=�6N      CanUserAddRows .  6f   �� 5   
   -   5         ��Name$ 	buttonAdd��5      $	��New��6$   $��
0,129,10,0q�62   $	��Top=�6F   $��22��6^   $��Right=�6j   $��32��6�   $y�Hidden=�6�   �� 5   
   -   5        $ addComboBox��5      $��
0,129,43,0q�6(   $	��Top=�6<   $��Right=�6T   $��99��6p   $��22��6{   $y�Hidden=�6�   �� 5   
   -   5         ��Name$ labelAdd��5      $	��Add��6"   $��Right=�60   $��0,127,147,0q�6L   $	��Top=�6a   $��30��6y   $y�Hidden=�6�   �� 5   
   -   5        $ buttonOK��5      $��OK��6#   $��125,0,206,10q�60   $��20��6]   $��Bottom=�6i   $��Center=�6�   $��75��6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel��6'   $��205,0,126,10q�68   $��20��6i   $��Bottom=�6u   $��Center=�6�   $��75��6�   �� 5   
   -   5        $ label��5      $��Enter values here:��6   $
��Left=�6<   $��	10,51,0,0q�6W   $	��Top=�6j   $��13.333(�6�   �� 5   
   -	   5        $ label1��5      $��Table:��6    $
��Left=�61   $��	10,10,0,0q�6L   $	��Top=�6_   $��16(�6w   �� 5   
   -
   5        $ buttonXMLExport��5      $��
XML Export��6*   $��Right=�6?   $��
0,191,43,0q�6[   $	��Top=�6o   $��70��6�   6�   �� 5    
   -   5        $ buttonXMLImport��5       $��
XML Import��6*   $��Right=�6?   $��
0,211,43,0q�6[   $	��Top=�6o   $��70��6�   {�.  6�   �� 5!   
   -   5         ��Name$ richTextBox��5!      $��40��6+   $��48,192,118,0q�67   $	��Top=�6M   |�.  ��.   �� IsReadOnlyCaretVisible . 	 �� IsDocumentEnabled	 . 
 J� IsManipulationEnabled
 . ��6�   Z� . �5"      /� .T�5#      J� .*�6   .*�5$      �� $8�2Use XML to backup the chages or when error happens��6   5%      5&      5'      5)      5*      