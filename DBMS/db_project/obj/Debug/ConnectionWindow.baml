   M S B A M L   `   `   `  ����E  Adb_project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:db_project
db_project  5   	   !    db_project.ConnectionWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:db_project     5   	     � Title$  Establish connection��5   	   $	��300��6&   $	��300��63   .��5	      � .+�5
   
   �� -   5         ��Name$ hostTextBox��5
      $
��Left=�6'   $��21��6B   $��	88,46,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $��	localhost��6u   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ label��5      $��Connect to database:��6   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l    J� RenderTransformOrigin$ 0.153,-0.176&�6�   $��16(�6�   �� 5   
   -   5        $ label1��5      $
��Host��6    $
��Left=�6/   $��	10,41,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $ label2��5      $
��Port��6    $
��Left=�6/   $��	10,67,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $ label3��5      $
��User��6    $
��Left=�6/   $��	10,93,0,0q�6J   $	��Top=�6]   �� 5   
   -   5        $ label4��5      $��Password��6    $
��Left=�63   $��
10,119,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ label5��5      $��Database��6    $
��Left=�63   $��
10,145,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ portTextBox��5      $
��Left=�6'   $��21��6B   $��	88,71,0,0q�6N   $
 Wrap=�6a   $
��5432��6u   $	��Top=�6�   $��53��6�   �� 5   
   -	   5        $ userTextBox��5      $
��Left=�6'   $��21��6B   $��	88,97,0,0q�6N   $
 Wrap=�6a   $��postgres��6u   $	��Top=�6�   $	��120��6�   �� 5   
   -
   5        $ databaseTextBox��5      $
��Left=�6+   $��21��6F   $��
88,149,0,0q�6R   $
 Wrap=�6f   $��artist_database��6z   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ buttonOK��5      $��OK��6#   $��Right=�60   $��
0,0,151,25q�6L   $��75��6`   $��20��6�   $��Bottom=�6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel��6'   $��Right=�68   $��	0,0,71,25q�6T   $��75��6g   $��20��6�   $��Bottom=�6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   $��
88,123,0,0q�6F   $	��Top=�6Z   $	��120��6r   $��21��6~    G� Password$ admin��6�   5      5      