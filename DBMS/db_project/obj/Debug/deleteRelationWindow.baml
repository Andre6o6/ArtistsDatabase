   M S B A M L   `   `   `  ����E  Adb_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:db_project
db_project  5   	   %    db_project.deleteRelationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:db_project     5   	     � Title$  Delete Relations��5   	   $��200.241��6"   $��534.481��63   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��180* �6   �� 5      $
��179* �6   .+�5   
   �� -   5         ��Name$ tableComboBox1��5      $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��120��6q   .@�5      �� $��Artist��6   �� 5      $��Painting��6   5      �� 5   
   -   5        $ tableComboBox2��5      $��1��6+   $��Right=�6;   $��	0,10,10,0q�6W   $	��Top=�6j   $	��120��6�   {�.  6�   �� 5   
   -   5         ��Name$ buttonCancel��5      $��Cancel��6'   $��1��68   $
��Left=�6H   $��3,0,0,10q�6c   $��Bottom=�6u   $��75��6�   6�   �� 5   
   -   5        $ buttonDelete��5      $��Delete��6'   $��Right=�68   $��0,83,2,0q�6T   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ itemComboBox��5      $��
10,37,10,0q�6)   $	��Top=�6=   $��2��6U   �� 5   
   -   5         ��Name$ 	labelAttr��5      $�� ��6#   $��195,10,191,0q�6/   $	��Top=�6E   $��2��6]   $��Center=�6q   �� 5   
   -   5        $ label��5      $��Items deleted:��6   $
��Left=�68   $��	10,80,0,0q�6S   $	��Top=�6f   �� 5   
   -   5        $ labelDeletedCount��5      $��0��6+   $
��Left=�67   $��
100,80,0,0q�6R   $	��Top=�6f   �� 5   
   -	   5        $ buttonOK��5      $��OK��6#   $��Right=�60   $��0,0,2,10q�6L   $��Bottom=�6^   $��75��6y   6�   �� 5   
   -
   5        $ buttonXMLExport��5      $��
XML Export��6*   $��1��6?   $��Right=�6O   $��	0,83,10,0q�6k   $	��Top=�6~   $��70��6�   6�   �� 5   
   -   5        $ buttonXMLImport��5      $��
XML Import��6*   $��1��6?   $��Right=�6O   $��
0,103,10,0q�6k   $	��Top=�6   $��70��6�   6�   �� 5   
   -   5        $ label1��5      $�� ��6    $��1��6+   $
��Left=�6;   $��	10,80,0,0q�6V   $	��Top=�6i   $	��139��6�   $��43��6�   �� 5   
   -   5         ��Name$ richTextBox��5      $��40��6+   $��	0,83,85,0q�67   $	��Top=�6J   $��1��6b   |�.  ��.   �� IsReadOnlyCaretVisible .  �� IsDocumentEnabled .  J� IsManipulationEnabled . $��Right=�6  $	��174��6  ��6�   Z� . �5      /� .T�5      J� .*�6   .*�5       �� $8�2Use XML to backup the chages or when error happens��6   5!      5"      5#      5%      5&      