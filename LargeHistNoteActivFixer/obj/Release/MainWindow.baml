   M S B A M L   `   `   `  ����   LargeHistNoteActivFixer(    "LargeHistNoteActivFixer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$.  (Large note, history and activity locator��$	��200��$	��600��$	��591��$
��1090��.��� .+��� -    ��Name$ refresh��$��Refresh��$
��Left=�$��	10,10,0,0q�$	��Top=�$��80��$��22���� -    ��Name$ databaseNameList��$��10,37,0,124q�$
��Left=�$	��250���� -   $
��Load��$��	95,10,0,0q�$	��Top=�$��22��$
��Left=�$��80���� $��265,10,10,10q�$��1�� K� ZIndex$ 98��.@��� $��
Activities��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ activitiesDataGrid��   
IsReadOnly .    HeadersVisibility$ Column=��� $��Notes��.��� .+�  -   $ notesDataGrid�� . $ Column=��� $��	Histories��.��� .+�  -   $ historiesDataGrid�� . $ Column=��� -    ��Name$ timeZoneLabel��$��
445,5,10,0q�$ 99��$��27��$	��Top=�$��Right=��� -   $��About��$
��Left=�$��
180,10,0,0q�$	��Top=�$��80��$��22���� -	   $ label_Status��$��Status: Ready��$
��Left=�$��	10,0,0,93q�$��Bottom=�$	��250���� $��Activities:��$
��Left=�$��	10,0,0,62q�$��Bottom=�$	��219���� -
   $ label_ActivitiesCount��$
��Left=�$��
234,0,0,62q�$��Bottom=�$��26��$��26��$�� ���� $��Notes:��$
��Left=�$��	10,0,0,36q�$��Bottom=�$	��219���� -   $ label_NotesCount��$
��Left=�$��
234,0,0,36q�$��Bottom=�$��26��$��26���� $��
Histories:��$
��Left=�$��	10,0,0,10q�$��Bottom=�$	��219���� -   $ label_HistoriesCount��$
��Left=�$��
234,0,0,10q�$��Bottom=�$��26��$��26��