   M S B A M L   `   `   `  ����M  IOCR_Camera_Printer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:OCR_Camera_Printer.ViewsOCR_Camera_Printer.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5
      ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5      &     OCR_Camera_Printer.Views.UC_Home   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:OCR_Camera_Printer.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac	 _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	 5	      Kwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  	 5
      [wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  	 5        � 	Resources  5      +   %OCR_Camera_Printer.Views.NumToVisConv   OptToVis�� 5   
   %   &	          5      6!   5      .��5      � .+�5   
   � -   5         �Name$ GridMain��5       � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $��* �6#   .+�5      � -   5        $ GridNav��5      $��Stretch=�5      ���#00B0ED � RowDefinitions 5      �� 5      $
��auto �6$   �� 5       $��* �6$   .+�5#      �� $��1��5$      $	��Top=�5%      ���#E8DEF8 �� SelectedIndex$ 0��5'      .@�5(      �� -   5        .��5)      �� $��10,0,0,0q�6%   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  $��50��5+   !   $��50��5,   !   
�������   Kind$
 Home=�5.   !   �� 5/      $��Center=�6(   $
��HOME��6E   50      51      �� 53      -   5        .��55      �� $��10,0,0,0q�6%   .+�56        $��50��57   !   $��50��58   !   
�������$	 Cog=�5:   !   �� 5;      $��Center=�6(   $��SETTING��6E   5<      5=      �� 5?      -   5        .��5@      �� $��10,0,0,0q�6%   .+�5A        $��50��5B   !   $��50��5C   !   
�������$ DatabaseCog=�5E   !   �� 5F      $��Center=�6(   $��DATABASE��6E   5G      5H      �� 5I      -   5        .��5J      �� $��10,0,0,0q�6%   .+�5K        $��50��5L   !   $��50��5M   !   
�������$ Information=�5O   !   �� 5P      $��Center=�6(   $��ABOUT��6E   5Q      5R      �� 5U      -   5        .��5V      �� $��10,0,0,0q�6%   .+�5W        $��50��5X   !   $��50��5Y   !   
�������$ Power=�5[   !   �� 5\      $��Center=�6(   $
��EXIT��6E   5]      5^      5_      5`      � 5a      -   5        $ GridContent��5a      $��1��6(    5b      �� 5c      $��50 �6$   �� 5d      �� 5e      $��30 �6$   .+�5g      � -	   5        $ 
GridHeader��5g      ���#00B0ED.+�5h      �� -
   5         ��Name$ TextBlockTitle��5i      $��Center=�5j      $��Center=�5k      $��ARIAL)�5l      $��25(�5m      $
��Bold"�5n      
�������$-��'R - CENTRALIZED VERIFICATION MANAGEMENT��5p      5r      � 5s      -   5        $ GridBody��5t      $��1��5u      
�������.+�5y      � -   5        $ GridHome��5y      y�6-   �� *
TabIndex+ �� 	Converter# [   �� ConverterParameter$ 0��	 �� FallbackValue$	 Visible�� 5z      �� 5{      $
��1.3* �6/   �� 5|      $��3* �6/   .+�5      � -   5        $ GridControlTab��5�      $��5q�5�      
������  5�      �� 5�   "   .+�5�      �� $��1��5�   !   $��2q�5�   !   .  (MaterialDesignThemes.Wpf.ElevationAssist
   	Elevation$	
 Dp7=�5�   !     MaterialDesignCardGroupBox#��[ 5�   !     5�   "     PrimaryHueMidBrush �� Color�� 5�   &   %+   &	       �� 5�   *   $ #00B0ED��6U   5�   '   ��5�   "   � 5�   &   $��30��6+   .+�5�   *   �� $��Center=�5�   -   $��Center=�5�   -   $��15(�5�   -   $
��Bold"�5�   -   
�������$��JOB OVERVIEW��5�   -   5�   '   .��5�   "   � -   5        $ GridOverview��5�   '    5�   &   �� 5�   *   $
��1.5* �68   �� 5�   *   $��2* �68   �� 5�   *   $��1* �68   .+�5�   &   � $��0,20,0,0q�6+   
������ .+�5�   *   �� $	��350��5�   -   $
��auto��5�   -   
�������$��2q�5�   -    �� CornerRadius$ 10��5�   -   y�5�   -   �� *
ImageVis+._�5�   .   � .+�5�   2   7  1System.Windows.Forms.Integration.WindowsFormsHost  -   5        $��CvsDisplayForm��5�   G   5�   3   5�   /   5�   +   5�   '   � 5�   &   $��1��6+   $��0,30,0,0q�68    5�   *   �� 5�   .   $��1* �6<   �� 5�   .   $��4* �6<   .+�5�   *   �  5�   .   �� 5�   2   �� 5�   2   $��3* �6C   .+�5�   .   � 
��� � �y�6F   �� *
SoftOnline+# [  $ 1��.+�5�   2   �� $��Center=�5�   5   $��Center=�5�   5   $��20(�5�   5   $
��Bold"�5�   5   
�������ONLINE5�   3   5�   /   � 5�   .   
���  ��y�6D   �� *
SoftOnline+# [  $ 0��.+�5�   2   �� $��Center=�5�   5   $��Center=�5�   5   $��20(�5�   5   $
��Bold"�5�   5   
�������	OFFLINE5�   3   5�   /   �� 5�   .   $��1��66   $��15(�6F   $
��Left=�6T   $��20 0 0 0q�6o   $��Center=�5�   5   ��6P   �� *
CameraData+5�   +     LiveCharts.Wpf.PieChart  5�   *   $��1��5�   -   $��10q�5�   -   $��20(�5�   -   &   LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     LegendLocation$ Bottom=�5�   -      Series 5�   -   �� *SeriesCollection+5�   '   � 5�   &   $��2��6+   
������ .+�5�   *   � $��Center=�5�   -   $��Bottom=�5�   -   
������  5�   .   �� 5�   2   �� 5�   2   �� 5�   2   .+�5�   .   �� -   5         ��Name$ BtnStart��5�   1   $	��120��5�   1   $	��120��5�   1   $��5,0,15,0q�5�   1   ���	#FF0B981F
������� & "MaterialDesignIconForegroundButton#��[ 5�   1    � ToolTip$( "MaterialDesignIconForegroundButton��5�   1   {�5�   1   �� *StartEnable+.��5�   2     $��50��5�   5   $��50��5�   5   $
 Play=�5   5   5  /   �� 5  .   -   5        $ BtnStop��5  1   $��1��5  1   $	��120��5  1   $	��120��5	  1   $��5,0,15,0q�5
  1   ���	#FFB12719
�������#��[ 5  1   $( "MaterialDesignIconForegroundButton��5  1   {�5  1   �� *
StopEnable+.��5  2     $��50��5  5   $��50��5  5   $
 Stop=�5  5   5  /   �� 5  .   -   5        $ 
BtnTrigger��5  1   $��2��5  1   $	��120��5  1   $	��120��5  1   $��5,0,5,0q�5  1   ���	#FFCFAE13
�������#��[ 5!  1   $( "MaterialDesignIconForegroundButton��5"  1   $y�	Collapsed=�5#  1   {�5   1   �� *TriggerEnable+.��5$  2     $��50��5%  5   $��50��5&  5   $ LightningBoltCircle=�5'  5   5(  /   5,  +   5-  '   51  #   52     54     � 55     -   5        $ GridStation��56     $��1��57     $��Stretch=�58     $��Stretch=�59      5:     �� 5;  "   $��4* �60   �� 5<  "   $��2* �60   .+�5>     )   #OCR_Camera_Printer.Views.UC_Station  $��5q�6/   � 5?     $��1��6#    5@  "   �� 5A  &   $��2* �67   �� 5B  &   $��3* �67   .+�5D  "   �  5E  &   �� 5F  *   �� 5G  *   $��3* �68   .+�5I  &   �� $��Center=�5J  )   $��Bottom=�5K  )   $��CHECK DATA INFORMATION��5L  )   $��30(�5M  )   $
��Bold"�5N  )   �� 5O  &   $��1��5P  )   $��10q�5Q  )   
��� � �$��1q�5S  )   $ 5��5T  )   ._�5U  *   �  5V  .   �� 5W  2   �� 5X  2   �� 5Y  2   �� 5Z  2   .+�5\  .   �  5]  2   �� 5^  6   �� 5_  6   .+�5a  2   �� $��10,0,0,0q�5b  5   $��Center=�5c  5   $��30(�5d  5   $
��Bold"�5e  5   $��Database Name: ��5f  5   �� 5g  2   $��CharacterEllipsis=�5h  5   $��1��5i  5   $��10,0,0,0q�5j  5   $��Center=�5k  5   $��30(�5l  5   ��5m  5   �� *DbName+5n  /   � 5o  .   $��1��63    5p  2   �� 5q  6   �� 5r  6   .+�5t  2   �� $��10,0,0,0q�5u  5   $��Center=�5v  5   $��30(�5w  5   $
��Bold"�5x  5   $��Field Count: ��5y  5   �� 5z  2   $��1��5{  5   $��10,0,0,0q�5|  5   $��Center=�5}  5   $��30(�5~  5   ��5  5   �� *TotalRecordDb+5�  /   � 5�  .   $��2��63    5�  2   �� 5�  6   �� 5�  6   .+�5�  2   �� $��10,0,0,0q�5�  5   $��Center=�5�  5   $��30(�5�  5   $
��Bold"�5�  5   $��Column Count: ��5�  5   �� 5�  2   $��1��5�  5   $��10,0,0,0q�5�  5   $��Center=�5�  5   $��30(�5�  5   ��5�  5   �� *ColumnCount+5�  /   � 5�  .   $��3��63    5�  2   �� 5�  6   �� 5�  6   .+�5�  2   �� $��10,0,0,0q�5�  5   $��Center=�5�  5   $��30(�5�  5   $
��Bold"�5�  5   $��File Type: ��5�  5   �� 5�  2   $��1��5�  5   $��10,0,0,0q�5�  5   $��Center=�5�  5   $��30(�5�  5   $
��.csv��5�  5   5�  /   5�  +   5�  '   5�  #   � 5�  "   $��1��6'    5�  &   �� 5�  *   �� 5�  *   $��3* �68   .+�5�  &   �� $��Center=�5�  )   $��Bottom=�5�  )   $��CHECK DATA INFORMATION��5�  )   $��30(�5�  )   $
��Bold"�5�  )   �� 5�  &   $��1��5�  )   $��10q�5�  )   
��� � �$��1q�5�  )   $ 5��5�  )   ._�5�  *   �  5�  .   �� 5�  2   .+�5�  .   �� $��5,5,5,5q�5�  1   $	
 Dp7=�5�  1   #��[ 5�  1     5�  2   �� 5�  6   %+   &	       �� 5�  :   $ #a87332��6e   5�  7   ��5�  2   �� 5�  6   $��25��5�  9   $��Center=�5�  9   $��Center=�5�  9   $��20(�5�  9   $
��Bold"�5�  9   
�������$��ERROR SIGNAL��5�  9   .��5�  2   �  5�  6   �� 5�  :   $��6* �6H   �� 5�  :   $��2* �6H   .+�5�  6   �� -   5        $ TextBlockGood��5�  9   $��0��5�  9   $��Center=�5�  9   $��Center=�5�  9   $��60(�5�  9   $
��Bold"�5�  9   #��[ 5�  9    $  MaterialDesignSubtitle2TextBlock#��[ 5�  9   ��5�  9   �� *	FailCount+$	 100000��5�  3   5�  /   5/  +   50  '   51  #   54     55     56     � 5:     -   5        $ GridJob��5:     y�6,   �� *
TabIndex+# [  $ 1��$	 	Collapsed��.+�5;     *   $OCR_Camera_Printer.Views.UC_Settings  5<     � 5A     -   5        $ GridDB��5B     $��10,10,10,10q�5C     y�5D     �� *
TabIndex+# [  $ 2��$	 	Collapsed��.+�5E     *	   $OCR_Camera_Printer.Views.UC_Database	  5F     5I     � 5L     -   5        $ 
GridFooter��5M     $��2��5N     ���#a4ba8c 5P     �� 5Q     $	��10* �6+   �� 5R     $��2* �6+   .+�5T     �� -   5         ��Name$ ScrollViewerStatus��5U     $��Hidden=�5V      �� PanningMode$ HorizontalOnly=�5W     $��Hidden=�5X     .��5Y     �� -   5         ��Name$ StackPanelStatus��5Y  %    �� Orientation$ 
Horizontal=�6?   5[     �� 5\     $��1��5]     $��0,0,10,0q�5^     $��Right=�5_     $��Center=�5`     $��12(�5a     $
��Bold"�5b     
�������$-��'Verion 1.0 - Powered by MyLanGroup 2023��5d     5f     5g     5h     5i     5j     