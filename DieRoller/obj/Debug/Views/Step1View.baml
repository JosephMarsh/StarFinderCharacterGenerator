   M S B A M L   `   `   `  ����D  @DieRoller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DieRoller.ViewsDieRoller.Views  5          DieRoller.Views.Step1View   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:DieRoller.Views     5      $��Segoe UI Black)�5
      $��14(�5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��0 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��0 �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5"      $
��auto �6   �� 5$      $
��auto �6   �� 5&      $
��auto �6   �� 5(      $
��auto �6   �� 5*      $��0 �6   .+�5.   
   �� $��1��5/      $��1��50      $��5��51      
����  �$��16(�53      $��	Underline{�54      $��Center=�55      $��Center=�56      $
��0,10q�57      Step 1 Character Concept58   '   �� 5<   
   -   5         ��Name$ LableCharacterName��5>      $��Character Name:��5=      $��1��5?      $��2��5@      $��5,0,15,0q�5A      �� 5C   
   -   5         ��Name$ ChraracterName��5D      $	��150��5F      $��0��5G      $��2��5I      $��2��5J      ��5H      ��  �� Path$ ChraracterName� �� Mode$ TwoWay=�5J      �� 5K   
   -   5        $��GroupBoxNotes��5L      $��2��5M      $��3��5N      $��4��5O      $��Notes��5P      $��2q�5Q      ���	#FF006DAE���	#FFDDDFF9$��5q�5T      $	��5,0q�5U      .��5V      �� -   5        $ PlayerNotes��5[      $��5��5W       �� TextWrapping$
 Wrap=�5X       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5Z      5\      5]      �� 5a   
   -   5        $ LablePlayerName��5c      $��Player Name:��5b      $��1��5d      $��3��5e      $��5,0,15,0q�5f      �� 5h   
   -   5        $ 
PlayerName��5j      $��3��5i      $	��150��5l      $��2��5m      $��3��5n      �� 5q   
   -   5        $ LableCharacterConcept��5s      $��Character Concept:��5r      $��1��5t      $��4��5u      $��5,0,15,0q�5v      �� 5x   
   -   5        $ CharacterConcept��5y      $	��150��5{      $��4��5|      $
 Wrap=�5}       . $��2��5      $��4��5�      $	��200��5�      �� 5�   
   -	   5        	 ��Name$	 CommitButton��5�      $��2��5�      $	��150��5�      $��6��5�      $��5��5�      $��Commit��5�      �� 5�   
   -
   5        $��GroupBoxInformation1��5�      $��6��5�      $��1��5�      $��3��5�      $��Information��5�      $��2q�5�      ���	#FF006DAE���	#FFDDDFF9$��5q�5�      $	��5,0q�5�      .��5�      �� -   5        $��StackInfoBox1��5�      .+�5�      �� .��5�      �� -   5        $��TextBoxInfo1��5�      $	��800��5�      $	��200��5�      {�.  $
 Wrap=�5�      
 �� TextAlignment$
 Justify=�5�      ��5�      �� $ InfoBox1�$ OneWay=�5�      5�      5�      5�      5�      5�      