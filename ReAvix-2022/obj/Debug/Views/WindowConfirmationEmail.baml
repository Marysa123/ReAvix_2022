   M S B A M L   `   `   `  ????F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ReAvix_2022.ViewsReAvix_2022.Views  5   	   /    )ReAvix_2022.Views.WindowConfirmationEmail   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ReAvix_2022.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  WindowConfirmationEmail??5	   	   $	??360??6)   $	??550??66    ? AllowsTransparency .  ? WindowStartupLocation$ CenterScreen=?6]    ? WindowStyle$
 None=?6?    ? 
ResizeMode$ NoResize=?6?   
??????  ? DataContext$ VMWindowConfirmationEmail??6?   .??5
      ? .+?5   
   ??  ?? CornerRadius$ 20??6   $??1??6#   ??5      ?? 5      .??5      ?  ? Color$ #2493D1??5       ? Offset$	 0.4Q?5      ? 5      $ #3358DC??5      $	 0.9Q?5      5      ._?5      ? .+?5      ?? -   5        $??	icon_Exit??5      $??0??6I   $??20??6V   $??Right=?6b   $	??Top=?6~   $??	0 25 25 0q?6?   $??20??6?   ??5      ?? 5      	 ?? 
TargetType"	 ??6    .?5      ?? 
 ?? Property
 ? ?? ?? Value$% /Resources/Images/icon_Exit.png??67    ?? Triggers 5      ?? 5   "    ?? Binding 6.   ?? *IsMouseOver+ ?? ElementName$ 	icon_Exit?? ?? Value true6d   .a?5   &   ?? 
 ? ??$, &/Resources/Images/icon_ExitStatus2.png??6?   5   #   5       5"      ?? 5#      $??0??6   $4??.Окно подтверждения почты??6%   $
??Left=?6H   $	??Top=?6c   $??	10 30 0 0q?6{   $??24(?6?   $
??Bold"?6?   
???????$%??Bahnschrift Light SemiCondensed)?6?   ?? 5$      $????Вам необходимо подтвердить почту указанную при регистрации. Пожалуйсат введите код, указанный в письме. ??6   $
??Left=?5%   /   $	??Top=?6J   $
??Wrap=?6b   $??	10 70 0 0q?6v   $??20(?6?   $
??Bold"?6?   
???????$%??Bahnschrift Light SemiCondensed)?6?   ?? 5&      -   5        $??textbox_Code??5&      $??	50 40 0 0q?6.   $
??Left=?6A   .  (MaterialDesignThemes.Wpf.TextFieldAssist   LeadingIcon$ Onepassword=?6\      LeadingIconSize$ 30Q?6?      HasLeadingIcon . $??1??6?   $??0??6  
???????$??20(?6/  
???   ?   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#??[  6?  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$( "Код подтверждения:??6?  $??70??6?  $	??350??6      UnderlineBrush ?#187AFD   
Foreground
 ?   ?$??0 0 0 2q?6q  6?  ?? 5'      -   5        $??button_Confirmation??5'        StyleButtonAllApplication#??[ 6?   $	??252??6?   $??65??6?   $??Подтвердить??6?   $??18(?6  $??Bottom=?6"  $??0 0 0 30q?6=  $??Bahnschrift)?6O  {?6V   ??  ?? Path$ 	IsChecked?$0 *MaterialDesignFilledTextBoxEnabledComboBox??6O  5(      5)      5*      5+      