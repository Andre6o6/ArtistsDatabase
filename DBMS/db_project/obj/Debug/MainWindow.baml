   M S B A M L   `   `   `  ����E  Adb_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:db_project
db_project  5   	       db_project.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:db_project     5   	     � Title$  Artist Database Manager��5   	   $	��373��6)   $	��525��66   .��5	      �  � ColumnDefinitions 5
   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $��173,30,10,29q�6%      
IsReadOnly . 6;   �� 5   
   -   5         ��Name$ buttonCreate��5      $��Create item��6'   $
��Left=�6=   $��
173,10,0,0q�6X   $	��Top=�6l   $��70��6�   6�   �� 5   
   -   5        $ buttonUpdate��5      $��Update selected��6'   $��Right=�6A   $��
0,10,108,0q�6]   $��93��6q   $��20��6�   $	��Top=�6�   �� 5   
   -   5        $ buttonDelete��5      $��Delete selected��6'   $��Right=�6A   $��	0,10,10,0q�6]   $	��Top=�6p   $��93��6�   6�   �� 5   
   -   5         ��Name$ tableSelectionComboBox��5      $��	10,10,0,0q�63   $	��Top=�6F   $��23��6^   $
��Left=�6�   $	��153��6�   .@�5      �� $��Artists��6   �� 5      $��	Paintings��6   �� 5      $��Exhibitions��6   �� 5      $��Auctions��6   �� 5      $��Sites��6   5      �� 5   
   -   5         ��Name$ addCheckBox0��5      $��CheckBox��6)   $
��Left=�6<   $��	19,38,0,0q�6W   $	��Top=�6j   $y�Hidden=�6�   �� 5   
   -   5        $ addCheckBox1��5      $��CheckBox��6)   $
��Left=�6<   $��	19,53,0,0q�6W   $	��Top=�6j   $y�Hidden=�6�   �� 5   
   -   5        $ buttonCreateRelation��5      $��Create relations��6/   $
��Left=�6J   $��
10,144,0,0q�6e   $	��Top=�6y   $��93��6�   6�   �� 5   
   -	   5        $ buttonDeleteRelation��5      $��Delete relations��6/   $
��Left=�6J   $��
10,169,0,0q�6e   $	��Top=�6y   $��93��6�   6�   �� 5   
   -
   5         ��Name$ searchTextBox��5      $��23��6)   $��	70,73,0,0q�65    �� TextWrapping$
 Wrap=�6H   $��Search��6\   $	��Top=�6j   	 J� RenderTransformOrigin$	 	0.5,0.174&�6�   $
��Left=�6�   $��70��6�   6�   �� 5   
   -   5        $ buttonSearch��5      $��S��6'   $
��Left=�63   $��
140,73,0,0q�6N   $	��Top=�6b   $��23��6z   $��23��6�   $	��Top=�6�   
���   ����	#FFDDDDDD6�   �� 5   
   -   5        $ searchFieldComboBox��5      $��	10,73,0,0q�60   $	��Top=�6C   $��23��6[   $
��Left=�6g   $��60��6�   �� 5   
   -   5        $ buttonCancelSearch��5      $��X��6-   $
��Left=�69   $��
140,96,0,0q�6T   $	��Top=�6h   $��23��6�   $��23��6�   $	��Top=�6�   6�   �� 5    
   -   5        $ exactMatchCheckBox��5       $��Exact match��6/   $
��Left=�6E   $��
19,101,0,0q�6`   $	��Top=�6t   �� 5!   
   -   5        $ button��5!      $��
Export XML��6!   $��Right=�66   $��	0,0,10,10q�6R   $��Bottom=�6e   $��69��6�   6�   �� 5"   
   -   5        $ buttonRefreshConn��5"      $��R��6,   $
��Left=�68   $��	10,0,0,10q�6S   $��Bottom=�6f   $��21��6�   6�   5$      5%      