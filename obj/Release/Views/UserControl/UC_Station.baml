   M S B A M L   `   `   `  ���� M  IOCR_Camera_Printer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:OCR_Camera_Printer.ViewsOCR_Camera_Printer.Views  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem )    #OCR_Camera_Printer.Views.UC_Station   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     8local&clr-namespace:OCR_Camera_Printer.Views     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   2sys&clr-namespace:System;assembly=mscorlib     � 	Resources  +   %OCR_Camera_Printer.Views.NumToVisConv   OptToVis  FontSizeCounter�� %&   &	        &	        X�100Q�.���� 
����������#354754$��2q� �� CornerRadius$ 6��._�� -    �Name$ GridItem��.+��  � ColumnDefinitions �� $��2* ��� $��3* �.+�� $��Stretch=�$��Stretch=�
������  � RowDefinitions �� $
��0.9* ��� $��3* �.+�� $��5,5,0,0q�$
��Left=�$	��Top=�
������ .+��� -    ��Name$ TextBoxTagName��$��5,0,0,0q�$��Center=�$��Center=�$��20(�$
��Bold"�
���   ����� *StationTagName+ �� FallbackValue$ STATE��� $��1��$��
16,16,5,16q�y��� *CameraConnStat+ �� 	Converter# [   �� ConverterParameter$ 1��.+��� $
��auto��$
��auto��$��Stretch=�$��Stretch=����� 	 �� 
StartPoint$		 0,0&�
 �� EndPoint$	
 1,1&�.���  � Offset$	 0.0Q� � Color$ 
LightGreen��� $	 1.0Q�$ 	DarkGreen���� -   $ 
TextBoxRUN��$��Center=�$��Center=�$��30(�$
��Bold"�
�������$	��RUN��� -   $ GridStop��$��1��$��
16,16,5,16q�y��� *CameraConnStat+# [  $ 0��.+��� $
��auto��$
��auto��$��Stretch=�$��Stretch=�$y�Visible=����� $		 0,0&�$	
 1,1&�.��� $	 0.0Q�$ 
LightCoral��� $	 1.0Q�$ DarkRed���� -   $ TextBoxSTOP��$��Center=�$��Center=�$��40(�$��	UltraBold"�
�������$
��STOP��� $��1��    PrimaryHueMidBrush �� Color�� %   &	       �� $ #3449bf��.+��  �� �� �� .+��� $��5,5,5,5q�.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp7=�  MaterialDesignCardGroupBox#��[   �� %   &	       �� $ #3449BF������ $��25��$��Center=�$��Center=�$��20(�$
��Bold"�
�������$��TOTAL��.���  �� $��6* ��� $��2* �.+��� -   $ TextBlockTotal��$��0��$��Center=�$��Center=�#���  $
��Bold"�#��[  $  MaterialDesignSubtitle2TextBlock#��[ ���� *
TotalCount+$ 100000���� -    ��Name$ BtnDetailTotal��$��1��$��30��$��30��$��Right=�$��Bottom=� * &MaterialDesignFloatingActionDarkButton#��[  � ToolTip$, &MaterialDesignFloatingActionDarkButton��{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��   Kind$ DotsHorizontal=�    PrimaryHueDarkBrush�� %   &	       �� $ #3449BF���� $��1��$��5,5,5,5q�$	 Dp7=�#��[   �� %   &	       �� $ #2cc743������ $��25��$��Center=�$��Center=�$��20(�$
��Bold"�
�������$
��GOOD��.���  �� $��6* ��� $��2* �.+��� -   $ TextBlockPrinted��$��0��$��Center=�$��Center=�#���  $
��Bold"�#��[ #��[ ���� *	GoodCount+$ 100000���� -	   $ BtnDetailGood��$��1��$��30��$��30��$��Right=�$��Bottom=�#��[ $, &MaterialDesignFloatingActionDarkButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��  $��30��$��30��$ DotsHorizontal=�  �� %   &	       �� $ #2cc743���� $��2��$��5,5,5,5q�$	 Dp7=�#��[   �� %   &	       �� $ #fa2d2d������ $��25��$��Center=�$��Center=�$��20(�$
��Bold"�
�������$
��FAIL��.���  �� $��6* ��� $��2* �.+��  �� �� .+��� -
   $ TextBlockGood��$��0��$��Center=�$��Center=�#���  $
��Bold"�#��[ #��[ ���� *	FailCount+$ 100000��� $��1�� �� �� .+��  �� �� $��2* �.+��� $
��Bold"�#��[ $��15(�$��Center=�$��Center=�$��	Not Found���� $��1��$��Center=�$��Center=�$��30(�$
��Bold"�#��[ #��[ ���� *NotFoundCount+$ 0��� $��1�� �� �� $��2* �.+��� $
��Bold"�#��[ $��15(�$��Center=�$��Center=�$��	Duplicate���� $��1��$��Center=�$��Center=�$��30(�$
��Bold"�#��[ #��[ ���� *
DupCount+$ 0���� -   $ BtnDetailFail��$��1��$��30��$��30��$��Right=�$��Bottom=�#��[ $, &MaterialDesignFloatingActionDarkButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��  $��30��$��30��$ DotsHorizontal=�  �� %   &	       �� $ #fa2d2d��