   M S B A M L   `   `   `  ????F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ReAvix_2022.ViewsReAvix_2022.Views  5   	   .    (ReAvix_2022.Views.WindowPasswordRecovery   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ReAvix_2022.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  WindowPasswordRecovery??5	   	   $	??360??6(   $	??550??65    ? AllowsTransparency .  ? WindowStartupLocation$ CenterScreen=?6\    ? WindowStyle$
 None=?6?    ? 
ResizeMode$ NoResize=?6?   
??????  ? DataContext$ VMWindowPasswordRecovery??6?   .??5
      ? .+?5   
   ??  ?? CornerRadius$ 20??6   $??1??6#   ??5      ?? 5      .??5      ?  ? Color$ #2493D1??5       ? Offset$	 0.4Q?5      ? 5      $ #3358DC??5      $	 0.9Q?5      5      ._?5      ? .+?5      ?? -   5        $??	icon_Exit??5      $??0??6I   $??20??6V   $??Right=?6b   $	??Top=?6~   $??	0 25 25 0q?6?   $??20??6?   ??5      ?? 5      	 ?? 
TargetType"	 ??6    .?5      ?? 
 ?? Property
 ? ?? ?? Value$% /Resources/Images/icon_Exit.png??67    ?? Triggers 5      ?? 5   "    ?? Binding 6.   ?? *IsMouseOver+ ?? ElementName$ 	icon_Exit?? ?? Value true6d   .a?5   &   ?? 
 ? ??$, &/Resources/Images/icon_ExitStatus2.png??6?   5   #   5       5"      ?? 5#      $8??2Окно восстановления пароля??6   $
??Left=?6>   $	??Top=?6Y   $??	10 30 0 0q?6q   $??24(?6?   $
??Bold"?6?   
???????$%??Bahnschrift Light SemiCondensed)?6?   ?? 5$      $????Введите ваш email, введенный при регистрации. На него отправится код, для его подтверждения.??6   $
??Left=?6?   $	??Top=?6?   $
??Wrap=?6?   $??	10 70 0 0q?6?   $??20(?6?   $
??Bold"?6?   
???????$%??Bahnschrift Light SemiCondensed)?6  ?? 5%      -   5        $??textbox_Email??5%      $??50,165,0,125q?6/   $
??Left=?6E   .  (MaterialDesignThemes.Wpf.TextFieldAssist   LeadingIcon$ Onepassword=?6`      LeadingIconSize$ 30Q?6?      HasLeadingIcon . $??0??6  
???????$??20(?6#  
???   ?   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#??[  6y  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ваш E-mail:??6?  $??70??6?  $	??439??6?     UnderlineBrush ?#187AFD   
Foreground
 ?   ?$??0 0 0 2q?6^  ?? 5&      -   5        $??button_Confirmation??5&        StyleButtonAllApplication#??[ 6?   $	??252??6?   $??65??6?   $??Продолжить??6?   $??18(?6  $??Bottom=?6!  $??0 0 0 30q?6<  $??Bahnschrift)?6N  {?6V   ??  ?? Path$ 	IsChecked?$0 *MaterialDesignFilledTextBoxEnabledComboBox??6N  5'      5(      5)      5*      