   M S B A M L   `   `   `  ����Q  MFootballMatchSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FootballMatchSimulator.UIFootballMatchSimulator.UI  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	   K*clr-namespace:FootballMatchSimulator.ModelFootballMatchSimulator.Model  5   	   (    "FootballMatchSimulator.UI.MatchRes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:FootballMatchSimulator.UI     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   <model*clr-namespace:FootballMatchSimulator.Model     5   	     � Title$  MatchRes��5
   	   $	��356��6   $	��364��6'    � WindowStartupLocation$ CenterScreen=�63   ���	#FFBFF6B0 � WindowStyle$
 None=�6o    � Icon$: 4/FootballMatchSimulator;component/Img/icons/icon.png��6�   .��5      �  � RowDefinitions 5   
   �� 5      $��36 �6   6*   �� 5      $��50 �6   6*   �� 5      $��40 �6   6*   �� 5      6   �� 5      $��80 �6   6*   .+�5   
   �� -   5        $��0��5      ���	#FF8D5697.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��36��6N   .+�5      �� -   5        $��
aboutUsBtn��5      $��26��6+   $��26��66    � Cursor$
 Hand��6B   $��	0 0 266 0q�6P   ��6c   Z� ��6y   Z� .��5      �� $��/img/icons/icon.png��6   6;   ��5      �� 5       �� 
TargetType" ��6     �� Triggers 5      P� 5   "   	 P� Property	 �@J�IsMouseOver
 P� Value
 . . �5   &   ��  �� Property � �� �� Value �	#FF5E45666C   5   #   5      5       �� 5!      -   5        $��
cutDownBtn��5!      $��20��6+   $��20��66   $��0 0 10 0q�6B   ���#ffffff��6T   Z� 6�   �� 5"      -   5        $��powerBtn��5"      $��20��6)   $��20��64   $��0 0 8 0q�6@   ���#ffffff��6Q   Z� 6�   5#      5$      �� 5%   
   $��1��6(   $��Yu Gothic UI Semibold)�65   $��22(�6X   
���   �$��Center=�6y   $��Center=�6�   ��6   �� *Win+ J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         	Direction$	 318Q�6#      Color$ 	#FFA3DFCC��63      
BlurRadius$ 10Q�6E   5)      �� 5*   
   $��2��68   $��Yu Gothic UI Semibold)�6E   $��22(�6h   ���	#FFF22EFF$��Center=�6�   $��Center=�6�   ��6   �� *CurrentMatch.Result+ 5+        5,      $	 318Q�6#   $ 	#FFA3DFCC��63   $ 10Q�6E   5.      �� 5/   
   -   5        $��SecondTeamList��5/      $��3��6U   $
��40 0q�6b   $��Yu Gothic UI Semibold)�6p   $��16(�6�    J� Opacity$
 0.75Q�6�   ��6)   �� *FootballersToUpdate+ �� View 50      �� 51      .P�52      ��  �� Width$	 160��6%    �� DisplayMemberBinding 61   ��  �� Path$
 Name�.��6\   Player6d   �� 53      $	 113��6%    61   �� $ ProgressValue�.��6e   
Progress6o   54      56      �� 57   
   $��4��6.   $	��120��6;   $
 Hand��6J   $��40��6X   $��100 0q�6d   $��Yu Gothic UI Semibold)�6�   $��18(�6�   ���	#FFF69595
���   ���6   �� *
SaveGame+��6s   Z�  58        59      $ 8Q�6#   $ 	#FF908181��62   ��5;      �� 5<      " ��6    5=      P� 5>      	 � ��
 . . �5?      ��  � ��
 ���� 6;   5@      P� 5A      	 �@J�IsMouseOver
 . . �5B      ��  � �� �	#FFADEBF36;   �� 5C       � �� �#0000006;   5D      5F      .��5G      Save5I      5J      5K      