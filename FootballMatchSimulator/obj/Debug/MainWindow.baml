   M S B A M L   `   `   `  ����Q  MFootballMatchSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FootballMatchSimulatorFootballMatchSimulator  5   	   '    !FootballMatchSimulator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FootballMatchSimulator     5   	     � Title$  Football Match Simulation��5   	   $	��606��6+   $	��698��68    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ NoResize=�6i   ���	#FFAFAFC6 � WindowStyle$
 None=�6�    � Icon$ Img/icons/icon.png��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��36 �6   6*   �� 5      $��80 �6   6*   �� 5      $	��400 �6   6+   �� 5      6   .+�5   
   �� -   5        $��0��5      ���	#FF8D5697.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��36��6N   .+�5      �� -   5        $��
aboutUsBtn��5      $��26��6+   $��26��66    � Cursor$
 Hand��6B   $��	0 0 600 0q�6P   ��6c   Z� ��6y   Z� .��5      �� $��/img/icons/icon.png��6   6;   ��5      �� 5       �� 
TargetType" ��6    	 �� Triggers	 5      P� 5   "   
 P� Property
 �@J�IsMouseOver P� Value . . �5   &   ��  �� Property � �� �� Value �	#FF5E45666C   5   #   5      5      �� 5      -   5        $��
cutDownBtn��5      $��20��6+   $��20��66   $��0 0 10 0q�6B   ���#ffffff��6T   Z� 6�   �� 5      -   5        $��powerBtn��5      $��20��6)   $��20��64   $��0 0 8 0q�6@   ���#ffffff��6Q   Z� 6�   5       5!      �� 5"   
   $��1��6   $��Football match simulator��6   $��Center=�6@   $��Bottom=�6]   $
��Bold"�6x   $��Stencil)�6�   $��24(�6�   ���	#FF6C2A2A J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         
BlurRadius$ 15Q�6#      	Direction$	 294Q�63      Opacity$
 0.75Q�6C      Color$ 	#FF7D93A5��6R   5&      �� 5'   
   $��2��6   $��Img/main.jpg��6   65   �� 5(   
   $��3��6   $ 
Horizontal=�6"   .+�5)      �� -   5        $��LogInBtn��5)      $	��120��6%   $
 Hand��64   $��50��6B   $��
214,0,20,0q�6N   $��Yu Gothic UI Semibold)�6y   $��18(�6�   ���	#FF95CDCD���	#FF483939��6b   Z�  5*        5+      $ 8Q�6'   $ 	#FF908181��66   ��5-      �� 5.      " ��6   	 5/      P� 50      
 � �� . . �51   "   ��  � ��
 ���� 6?   52      P� 53      
 �@J�IsMouseOver . . �54   "   ��  � �� �	#FFADEBF36?   �� 55   "    � �� �#0000006?   56      58      .��59       Log In5:      �� 5;      -   5        $��	SignUpBtn��5;      $	��120��6&   $
 Hand��65   $��50��6C   $��Yu Gothic UI Semibold)�6f   $��18(�6�   ���	#FF95CDCD���	#FF483939��6O   Z�  5<        5=      $ 8Q�6'   $ 	#FF908181��66   .��5>   !   	Sign Up6+   5?      5@      5A      