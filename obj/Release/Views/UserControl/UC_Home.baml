   M S B A M L   `   `   `  ���� M  IOCR_Camera_Printer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:OCR_Camera_Printer.ViewsOCR_Camera_Printer.Views  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration &     OCR_Camera_Printer.Views.UC_Home   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:OCR_Camera_Printer.Views     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac	 _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006  	 Kwf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms  	 [wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration  	   � 	Resources  +   %OCR_Camera_Printer.Views.NumToVisConv   OptToVis�� %   &	          .��� .+�� -    �Name$ GridMain�� � ColumnDefinitions �� $	��100 ��� $��* �.+�� -   $ GridNav��$��Stretch=����#00B0ED � RowDefinitions �� $
��auto ��� $��* �.+��� $��1��$	��Top=����#E8DEF8 �� SelectedIndex$ 0��.@��� -   .���� $��10,0,0,0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  $��50��$��50��
�������   Kind$
 Home=��� $��Center=�$
��HOME���� -   .���� $��10,0,0,0q�.+�  $��50��$��50��
�������$	 Cog=��� $��Center=�$��SETTING���� -   .���� $��10,0,0,0q�.+�  $��50��$��50��
�������$ DatabaseCog=��� $��Center=�$��DATABASE���� -   .���� $��10,0,0,0q�.+�  $��50��$��50��
�������$ Information=��� $��Center=�$��ABOUT���� -   .���� $��10,0,0,0q�.+�  $��50��$��50��
�������$ Power=��� $��Center=�$
��EXIT��� -   $ GridContent��$��1�� �� $��50 ��� �� $��30 �.+�� -	   $ 
GridHeader�����#00B0ED.+��� -
    ��Name$ TextBlockTitle��$��Center=�$��Center=�$��ARIAL)�$��25(�$
��Bold"�
�������$-��'R - CENTRALIZED VERIFICATION MANAGEMENT��� -   $ GridBody��$��1��
�������.+�� -   $ GridHome��y��� *
TabIndex+ �� 	Converter# [   �� ConverterParameter$ 0��	 �� FallbackValue$	 Visible�� �� $
��1.3* ��� $��3* �.+�� -   $ GridControlTab��$��5q�
������  �� .+��� $��1��$��2q�.  (MaterialDesignThemes.Wpf.ElevationAssist
   	Elevation$	
 Dp7=�  MaterialDesignCardGroupBox#��[     PrimaryHueMidBrush �� Color�� %   &	       �� $ #00B0ED����� $��30��.+��� $��Center=�$��Center=�$��15(�$
��Bold"�
�������$��JOB OVERVIEW��.��� -   $ GridOverview�� �� $
��1.5* ��� $��2* ��� $��1* �.+�� $��0,20,0,0q�
������ .+��� $	��350��$
��auto��
�������$��2q� �� CornerRadius$ 10��y��� *
ImageVis+._�� .+�7  1System.Windows.Forms.Integration.WindowsFormsHost  -   $��CvsDisplayForm��� $��1��$��0,30,0,0q� �� $��1* ��� $��4* �.+��  �� �� $��3* �.+�� 
��� � �y��� *
SoftOnline+# [  $ 1��.+��� $��Center=�$��Center=�$��20(�$
��Bold"�
�������ONLINE� 
���  ��y��� *
SoftOnline+# [  $ 0��.+��� $��Center=�$��Center=�$��20(�$
��Bold"�
�������	OFFLINE�� $��1��$��15(�$
��Left=�$��20 0 0 0q�$��Center=����� *
CameraData+  LiveCharts.Wpf.PieChart  $��1��$��10q�$��20(�&   LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     LegendLocation$ Bottom=�   Series �� *SeriesCollection+� $��2��
������ .+�� $��Center=�$��Bottom=�
������  �� �� �� .+��� -    ��Name$ BtnStart��$	��120��$	��120��$��5,0,15,0q����	#FF0B981F
������� & "MaterialDesignIconForegroundButton#��[  � ToolTip$( "MaterialDesignIconForegroundButton��{��� *StartEnable+.��  $��50��$��50��$
 Play=��� -   $ BtnStop��$��1��$	��120��$	��120��$��5,0,15,0q����	#FFB12719
�������#��[ $( "MaterialDesignIconForegroundButton��{��� *
StopEnable+.��  $��50��$��50��$
 Stop=��� -   $ 
BtnTrigger��$��2��$	��120��$	��120��$��5,0,5,0q����	#FFCFAE13
�������#��[ $( "MaterialDesignIconForegroundButton��$y�	Collapsed=�{��� *TriggerEnable+.��  $��50��$��50��$ LightningBoltCircle=�� -   $ GridStation��$��1��$��Stretch=�$��Stretch=� �� $��4* ��� $��2* �.+�)   #OCR_Camera_Printer.Views.UC_Station  $��5q�� $��1�� �� $��2* ��� $��3* �.+��  �� �� $��3* �.+��� $��Center=�$��Bottom=�$��CHECK DATA INFORMATION��$��30(�$
��Bold"��� $��1��$��10q�
��� � �$��1q�$ 5��._��  �� �� �� �� .+��  �� �� .+��� $��10,0,0,0q�$��Center=�$��30(�$
��Bold"�$��Database Name: ���� $��CharacterEllipsis=�$��1��$��10,0,0,0q�$��Center=�$��30(����� *DbName+� $��1�� �� �� .+��� $��10,0,0,0q�$��Center=�$��30(�$
��Bold"�$��Field Count: ���� $��1��$��10,0,0,0q�$��Center=�$��30(����� *TotalRecordDb+� $��2�� �� �� .+��� $��10,0,0,0q�$��Center=�$��30(�$
��Bold"�$��Column Count: ���� $��1��$��10,0,0,0q�$��Center=�$��30(����� *ColumnCount+� $��3�� �� �� .+��� $��10,0,0,0q�$��Center=�$��30(�$
��Bold"�$��File Type: ���� $��1��$��10,0,0,0q�$��Center=�$��30(�$
��.csv��� $��1�� �� �� $��3* �.+��� $��Center=�$��Bottom=�$��CHECK DATA INFORMATION��$��30(�$
��Bold"��� $��1��$��10q�
��� � �$��1q�$ 5��._��  �� .+��� $��5,5,5,5q�$	
 Dp7=�#��[   �� %   &	       �� $ #a87332������ $��25��$��Center=�$��Center=�$��20(�$
��Bold"�
�������$��ERROR SIGNAL��.���  �� $��6* ��� $��2* �.+��� -   $ TextBlockGood��$��0��$��Center=�$��Center=�$��60(�$
��Bold"�#��[  $  MaterialDesignSubtitle2TextBlock#��[ ���� *	FailCount+$	 100000��� -   $ GridJob��y��� *
TabIndex+# [  $ 1��$	 	Collapsed��.+�*   $OCR_Camera_Printer.Views.UC_Settings  � -   $ GridDB��$��10,10,10,10q�y��� *
TabIndex+# [  $ 2��$	 	Collapsed��.+�*	   $OCR_Camera_Printer.Views.UC_Database	  � -   $ 
GridFooter��$��2�����#a4ba8c �� $	��10* ��� $��2* �.+��� -    ��Name$ ScrollViewerStatus��$��Hidden=� �� PanningMode$ HorizontalOnly=�$��Hidden=�.���� -    ��Name$ StackPanelStatus�� �� Orientation$ 
Horizontal=��� $��1��$��0,0,10,0q�$��Right=�$��Center=�$��12(�$
��Bold"�
�������$-��'Verion 1.0 - Powered by MyLanGroup 2023��