   M S B A M L   `   `   `  ????F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ReAvix_2022.ViewsReAvix_2022.Views  5   	   *    $ReAvix_2022.Views.WindowAddNotesPrep   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +localclr-namespace:ReAvix_2022.Views  5   	     ? Title$  WindowAddNotesPrep??5	   	   $	??270??6$   $	??500??61   
??????  ? AllowsTransparency .  ? WindowStyle$
 None=?6p    ? 
ResizeMode$ NoResize=?6?    ? WindowStartupLocation$ CenterScreen=?6?   .??5
      ? .+?5   
   ?? ???#1B5293 ?? CornerRadius$ 5??6&   ._?5      ? .+?5      ?? -   5        $??	icon_Exit??5      $??20??6I   $??Right=?6U   $	??Top=?6q   $??	0 15 15 0q?6?   $??20??6?   ??5      ?? 5       ?? 
TargetType" ??6    .?5      ??  ?? Property ? ?? ?? Value$% /Resources/Images/icon_Exit.png??67   	 ?? Triggers	 5      ?? 5   "   
 ?? Binding
 6.   ?? *IsMouseOver+ ?? ElementName$ 	icon_Exit?? ?? Value true6d   .a?5   &   ??  ? ??$, &/Resources/Images/icon_ExitStatus2.png??6?   5   #   5      5      ?? 5      $)??#Добавление заметки??6   
???????$??22(?6H   $
??Left=?6V   $	??Top=?6q   $??	20 20 0 0q?6?   $??30??6?   $??Bahnschrift Condensed)?6?   ?? 5      -   5        $??textbox_Text??5      ???#689ADD$??0??6D   $??Center=?6Q   $
??Left=?6l   $??	40 0 0 40q?6?   $??18(?6?   
???????.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#??[  6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$/ )Введите текст заметки:??6+  $??60??6c  $	??250??6o     UnderlineBrush ?#187AFD   
Foreground
 ?????$??0 0 0 2q?6?   ? Cursor$ Arrow??6?  ?? 5      -   5        $??combobox_Property??5      $??Bahnschrift SemiCondensed)?64      TrailingIcon$ ArrowBottom=?6\   $??	0 0 40 50q?6?   
???   ?$
??Left=?6?   $	??Top=?6?   
 ???? $??Right=?6:  $??Center=?6W  $??20(?6r  $	??135??6?  $??70??6?  ???#FFFFFF   MaterialDesignFilledComboBox#??[ 6?  .@?5      ?? $??Высокий??6#    ?? 
IsSelected . 65   ?? 5      $??Средний??6#   ?? 5      $??Низкий??6#   5      ?? 5       -   5        $??button_AddNotes??5         StyleButtonAllApplication#??[ 6O   $??Bottom=?6?   $??0 0 0 20q?6?   $	??150??6?   $??65??6?   $??Добавить??6?   $??18(?6?   $??Bahnschrift)?6?   5!      5"      5#      5$      