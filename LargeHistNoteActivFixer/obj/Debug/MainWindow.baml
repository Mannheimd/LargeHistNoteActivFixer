   M S B A M L   `   `   `  ����  LargeHistNoteActivFixer(    "LargeHistNoteActivFixer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$.  (Large note, history and activity locator��5   	   $	��200��6:   $	��600��6J   $	��591��6Y   $
��1090��6f   .��5      � .+�5   
   �� -   5         ��Name$ refresh��5      $��Refresh��6"   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $��80��6z   $��22��6�   �� 5   
   -   5         ��Name$ databaseNameList��5      $��10,37,0,124q�6,   $
��Left=�6A   $	��250��6\   �� 5   
   -   5        $
��Load��5      $��	95,10,0,0q�6    $	��Top=�63   $��22��6^   $
��Left=�6j   $��80��6�   �� 5	   
   $��265,10,10,10q�6   $��1��6+    K� ZIndex$ 98��6;   .@�5
      �� $��
Activities��6   .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ activitiesDataGrid��5         
IsReadOnly .    HeadersVisibility$ Column=�6M   5      5      �� 5      $��Notes��6   .��5      � .+�5        -   5        $ notesDataGrid��5       . $ Column=�6H   5      5      �� 5      $��	Histories��6   .��5      � .+�5        -   5        $ historiesDataGrid��5       . $ Column=�6L   5      5      5      �� 5   
   -   5         ��Name$ timeZoneLabel��5      $��
445,5,10,0q�6'   $ 99��6;   $��27��6N   $	��Top=�6Z   $��Right=�6r   �� 5   
   -   5        $��About��5      $
��Left=�6!   $��
180,10,0,0q�6<   $	��Top=�6P   $��80��6h   $��22��6s   6�   �� 5   
   -	   5        $ label_Status��5      $��Status: Ready��6&   $
��Left=�6>   $��	10,0,0,93q�6Y   $��Bottom=�6l   $	��250��6�   �� 5   
   $��Activities:��6   $
��Left=�6&   $��	10,0,0,62q�6A   $��Bottom=�6T   $	��219��6o   �� 5   
   -
   5        $ label_ActivitiesCount��5      $
��Left=�6/   $��
234,0,0,62q�6J   $��Bottom=�6^   $��26��6y   $��26��6�   $�� ��6�   �� 5   
   $��Notes:��6   $
��Left=�6!   $��	10,0,0,36q�6<   $��Bottom=�6O   $	��219��6j   �� 5    
   -   5        $ label_NotesCount��5       $
��Left=�6*   $��
234,0,0,36q�6E   $��Bottom=�6Y   $��26��6t   $��26��6   �� 5!   
   $��
Histories:��6   $
��Left=�6%   $��	10,0,0,10q�6@   $��Bottom=�6S   $	��219��6n   �� 5"   
   -   5        $ label_HistoriesCount��5"      $
��Left=�6.   $��
234,0,0,10q�6I   $��Bottom=�6]   $��26��6x   $��26��6�   5#      5$      