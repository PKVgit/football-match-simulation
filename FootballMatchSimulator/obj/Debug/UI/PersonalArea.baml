   M S B A M L   `   `   `  ����Q  MFootballMatchSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FootballMatchSimulator.UIFootballMatchSimulator.UI  5   	   ,    &FootballMatchSimulator.UI.PersonalArea   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FootballMatchSimulator.UI     5   	     � Title$  PersonalArea��5   	   $	��406��6   $	��600��6+    � WindowStartupLocation$ CenterScreen=�67    � Icon$: 4/FootballMatchSimulator;component/Img/icons/icon.png��6\    � WindowStyle$
 None=�6�    � 
ResizeMode$ NoResize=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��36 �6   6*   �� 5      $��60 �6   6*   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5        $��0��5      $��2��6"   ���	#FF8D5697.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��36��6N   .+�5      �� -   5        $��
aboutUsBtn��5      $��26��6+   $��26��66    � Cursor$
 Hand��6B   $��	0 0 502 0q�6P   ��6c   Z� ��6y   Z� .��5      �� $��/img/icons/icon.png��6   6;   ��5      �� 5      	 �� 
TargetType"	 ��6    
 �� Triggers
 5      P� 5   "    P� Property �@J�IsMouseOver P� Value . . �5   &   ��  �� Property � �� �� Value �	#FF5E45666C   5   #   5      5       �� 5!      -   5        $��
cutDownBtn��5!      $��20��6+   $��20��66   $��0 0 10 0q�6B   ���#ffffff��6T   Z� 6�   �� 5"      -   5        $��powerBtn��5"      $��20��6)   $��20��64   $��0 0 8 0q�6@   ���#ffffff��6Q   Z� 6�   5#      5$      �� 5%   
   $��1��6   $��2��6"   $ 
Horizontal=�66   .+�5&      �� $��Yu Gothic UI Semibold)�6   $��22(�67   ���#000000$��Center=�6Z   $��28 0 0 0q�6u    J� Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         	Direction$	 318Q�6'      Color$ 	#FFA3DFCC��67      
BlurRadius$ 10Q�6I   .��5)       Number of wins:5*      �� 5+      $��Yu Gothic UI Semibold)�6<   $��22(�6_   ���#000000$��Center=�6�   $��6 0 0 0q�6�   ��6   �� *Player.NumberOfWins+ 5,        5-      $	 318Q�6'   $ 	#FFA3DFCC��67   $ 10Q�6I   5/      �� 50      $��Yu Gothic UI Semibold)�6-   $��26(�6P   
���  ��$��Center=�6o   $��Right=�6�   $��	220 0 0 0q�6�   ��6   �� *Name+ 51        52      $	 318Q�6'   $ 	#FFA3DFCC��67   $ 10Q�6I   54      55      �� 57   
   $��2��62   $��0��6?   $��
30,30,0,30q�6O   $��Yu Gothic UI Semibold)�6c   $��18(�6�   ���	#FF483939���	#FFC3EEC3 J� Opacity$
 0.75Q�6�   ��6   �� *	Matches+59      �� 5:   
   $��2��63   $��1��6@   $	��120��6Q   $
 Hand��6`   $��50��6n   $��	70,0,70,0q�6z   $��Yu Gothic UI Semibold)�6�   $��18(�6�   ���	#FFF69595
���   ���6   �� *StartPlayGame+��6�   Z�  5;        5<      $ 8Q�6#   $ 	#FF908181��62   ��5>      �� 5?      "	 ��6   
 5@      P� 5A       � �� . . �5B      ��  � ��
 ���� 6;   5C      P� 5D       �@J�IsMouseOver . . �5E      ��  � �� �	#FFADEBF36;   �� 5F       � �� �#0000006;   5G      5I      .��5J      	Play game5K      5L      5M      