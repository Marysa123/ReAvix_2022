   M S B A M L   `   `   `  ����F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ReAvix_2022.ViewModelsReAvix_2022.ViewModels  5   	   (    "ReAvix_2022.Views.WindowAboutSkils   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local1$clr-namespace:ReAvix_2022.ViewModels     5   	   ` \MaterialDesignThemes.Wpf, Version=4.10.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$F  @Окно просмотра информации о навыке��5	   	   $	��640��64   $	��600��6A    � WindowStartupLocation$ CenterScreen=�6M    � 
ResizeMode$ NoResize=�6r    � DataContext$ VMWindowAboutSkils��6�   
������  � WindowStyle$
 None=�6�    � AllowsTransparency . .��5
      � .+�5   
   ��  �� CornerRadius$ 10��6   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      � 	 � Color$	 #112035��6#   
 � Offset$
 0Q�5   '   � 5      $	 #041B3F��6#   $
 1Q�5   '   5      5      �� 5   
   -   5        $��	icon_Exit��5      $��1��6!   $	��Top=�6e   $��0��6}   $��Right=�6�   $��	0 25 25 0q�6�   $��17��6�   ��5   
   �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$% /Resources/Images/icon_Exit.png��6+    �� Triggers 5      �� 5       �� Binding 6"   �� *IsMouseOver+ �� ElementName$ 	icon_Exit�� �� Value true6X   .a�5      ��  � ��$, &/Resources/Images/icon_ExitStatus2.png��63   5      5      5       �� 5"   
   .+�5#      �� $F��@Окно просмотра информации о навыке��6   $	��Top=�6A   $��	30 20 0 0q�6Y   $
��Left=�6l   
�������$��26(�6�   $��40��6�   $!��Bahnschrift Light Condensed)�6�   �� 5$      $*��$Название категории:��6   
�������$��24(�6E   $��35 0 0 0q�6S   $
��Left=�6e   $��Bottom=�6�   $��40��6�   $!��Bahnschrift Light Condensed)�6�   �� 5%      $	��Top=�65   $��35 0 0 0q�6M   $
��Left=�6_   
�������$��20(�6�   $��30��6�   $%��Bahnschrift Light SemiCondensed)�6�   ��6   ��  �� Path$ NameKat�6�   �� 5&      $.��(Подробная информация:��6   $	��Top=�64   $��	35 10 0 0q�6L   $
��Left=�6_   
�������$��22(�6�   $��30��6�   $!��Bahnschrift Light Condensed)�6�   �� 5'      -   5        $��textbox_TextSkils��5)       !  MaterialDesignOutlinedTextBox#��[  5(      $	��Top=�5+      $	��220��5,      $��20(�5-      $��3��5.      $��2��5/      $��3��50       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�52      $��
35 15 35 0q�53      " �� VerticalScrollBarVisibility$
 Auto=�54      )  #MaterialDesignThemes.Wpf.HintAssist   
Background
 ����    
Foreground
 �   �
���   �   FloatingScale$	 0.8Q�58      
������� �� 	MaxLength$	 400��5:      
������� � Cursor$ Arrow��5;   �   ��5*      �� $ FullDate�{�5;      �� $ 	IsChecked�$2 ,MaterialDesignOutlinedTextBoxEnabledComboBox��6�   �� 5<      $:��4Уровень мастерства(от 0 до 10):��6   $	��Top=�6>   $��	35 10 0 0q�6V   $
��Left=�6i   
�������$��20(�6�   $��30��6�   $!��Bahnschrift Light Condensed)�6�   �� 5=      -   5        $��combobox_ValueMaster��5=      $��Bahnschrift SemiCondensed)�63   $��
35 10 0 10q�6Z   .  (MaterialDesignThemes.Wpf.TextFieldAssist   TrailingIcon$ ArrowBottom=�6�   
���   �$��Center=�6�   $	��Top=�6     UnderlineBrush
 ���� $
��Left=�6^  $��21(�6y  $��1��6�  $��3��6�  $��85��6�  $��70��6�  ���#FFFFFF   MaterialDesignFilledComboBox#��[ 6�   �� Text 6n   �� $ LevelsMaster�.@�5>      ��  �� 
IsSelected . $��0��61   �� 5?      $��1��6   �� 5@      $��2��6   �� 5A      $��3��6   �� 5B      $��4��6   �� 5C      $��5��6   �� 5D      $��6��6   �� 5E      $��7��6   �� 5F      $��8��6   �� 5G      $��9��6   �� 5H      $��10��6   5I      � 5J      $��90��6   $��0 0 0 0q�6$   $��Center=�65   .+�5K      �� -   5        $��button_UpdateSkilsStud��5K        StyleButtonAllApplication#��[ 6^   $��	0 20 30 0q�6�   $��3��6�   $��5��6�   $	��252��6�   $��65��6�   $��Изменить��6�   $��18(�6�   $	��Top=�6�   $��Bahnschrift)�6  �� 5L      -   5        $��button_DeleteSkilsStud��5L        StyleButtonDelete#��[ 6^   $��0 20 0 0q�6�   $��3��6�   $��5��6�   $	��252��6�   $��65��6�   $��Удалить��6�   $��18(�6�   $	��Top=�6�   $��Bahnschrift)�6  $
 Hand��6!  5M      5N      5O      5P      