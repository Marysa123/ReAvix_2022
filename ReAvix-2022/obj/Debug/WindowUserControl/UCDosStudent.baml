   M S B A M L   `   `   `  ????F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ReAvix_2022.WindowUserControlReAvix_2022.WindowUserControl  5      ?$clr-namespace:ReAvix_2022.ViewModelsReAvix_2022.ViewModels  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5
      g cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 6O   h dSyncfusion.SfProgressBar.WPF, Version=20.2460.0.45, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89uRclr-namespace:Syncfusion.UI.Xaml.ProgressBar;assembly=Syncfusion.SfProgressBar.WPFSyncfusion.UI.Xaml.ProgressBar 6?   0    *ReAvix_2022.WindowUserControl.UCDosStudent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:ReAvix_2022.WindowUserControl     5      7local1$clr-namespace:ReAvix_2022.ViewModels     5      _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      a	 ]Syncfusion.Shared.Wpf, Version=20.2460.0.45, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89b
 ^Syncfusion.SfChart.WPF, Version=20.2460.0.45, Culture=neutral, PublicKeyToken=3d67ed1f87d44c891chart!http://schemas.syncfusion.com/wpf 	  
 5	      BWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf 	  
 5
      flvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF 	  
 6O   g
SyncfusionRclr-namespace:Syncfusion.UI.Xaml.ProgressBar;assembly=Syncfusion.SfProgressBar.WPF 	  
 6?   
??????   ? DataContext$  VMWindowDosStudent??5   R   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??0.75* ?6   ?? 5      .+?5   
   ?? $+??%/Resources/Images/icon_TrophyBack.png??6   $??2??6?   $??Right=?6P   $??716.8??6l   $??716.8??6z   $??Bottom=?6?   ?? 5   
   -   5        $??	icon_Exit??5      $??1??6!   $	??Top=?6e   $??0??6}   $??Right=?6?   $??	0 25 25 0q?6?   $??17??6?   ??5      ?? 5       ?? 
TargetType" ??6   .?5      ??  ?? Property ? ?? ?? Value$% /Resources/Images/icon_Exit.png??6/    ?? Triggers 5      ?? 5       ?? Binding 6&   ?? *IsMouseOver+ ?? ElementName$ 	icon_Exit?? ?? Value true6\   .a?5      ??  ? ??$, &/Resources/Images/icon_ExitStatus2.png??67   5      5      5      ?? 5   
   $??0??6   $??Ваши навыки??6   
???????$??24(?6F   $
??Left=?6T   $??	30 30 0 0q?6o   $	??Top=?6?   $??40??6?   $!??Bahnschrift Light Condensed)?6?   ?? 5!   
   -   5        $??button_Update??5!   #   $??Обновить??6   $??0??68   $??20(?6i   $??Right=?6w   $??Bottom=?6?   $??
0 0 225 15q?6?   $??40??6?   $??Corbel Light)?6?   	 ? Cursor$
	 Hand??6?   ??5"      ?? 5#      " ??6   .?5$      ??  ? ??
 ?????63    5%      ?? 5&       6&   ?? *IsMouseOver+$ button_Update?? true6`   .a?5'      ??  ? ?? ?#3AFFDC6;   5(      5*      5,      ?? 5-   
   -   5        
 ??Name$
 border_AddSliks??5-      $??2q?6P   $	??130??6d   $??60??6p    ?? CornerRadius$ 20??6|   $??Right=?6?   $??Bottom=?6?   $??0 0 85 5q?6?   $
	 Hand??6?   ??5.      ?? 5/       ?? 
StartPoint$ 0.5,0&?6&    ?? EndPoint$ 0.5,1&?69   .??50      ?  ? Color$ #A81DFE??6#    ? Offset$ 0Q?51   '   ? 52      $ #E76E8B??6#   $ 1Q?53   '   54      ??56      ?? 57      " ??6   .?58      ??  ? ??
 ???? 63    59      ?? 5:       6&   ?? *IsMouseOver+$ border_AddSliks?? true6b   .a?5;      ??  ? ?? 5<   "   ?? 5=   &   $ 0.5,0&?6:   $ 0.5,1&?6M   .??5>   *   ? $ #A81DFE??67   $ 0Q?5?   '   ? 5@   *   $ #E76E8B??67   $ 1Q?5A   '   5B   '   5D      5E      5G      ._?5I      ?? $??Добавить??6   $??19(?6'   
???????$!??Bahnschrift Light Condensed)?6H   $??Center=?6q   $??Center=?6?   5J      ?? 5L   
   $
??Auto=?6   $??Hidden=?6<   $??0??6a   $??10 70 10 70q?6n   .??5M      ?? -   5         ??Name$ 
PanelSkils??5M      ??5N      ?? 5O      .R?5P      ? 5Q      5S      5T      ?? 5U   
   $??1??6   $#??Ваши достижения??6   
???????$??24(?6J   $
??Left=?6X   $??	30 10 0 0q?6s   $	??Top=?6?   $??40??6?   $!??Bahnschrift Light Condensed)?6?   ?? 5V   
   $
??Auto=?6   $??1??6;   $??10 50 10 100q?6H   .??5W      ?? -   5        $ PanelDos??5W      ??5X      ?? 5Y      .R?5Z      ? 5[      5]      5^      ?? 5_   
   -   5        $??button_UpdateDos??5_   #   $??Обновить??6   $??1??6;   $??20(?6o   $??Right=?6}   $??Bottom=?6?   $??
0 0 225 45q?6?   $??40??6?   $??Corbel Light)?6?   $
	 Hand??6?   ??5`      ?? 5a      " ??6   .?5b      ??  ? ??
 ?????63    5c      ?? 5d       6&   ?? *IsMouseOver+$ button_UpdateDos?? true6c   .a?5e      ??  ? ?? ?#3AFFDC6;   5f      5h      5j      ?? 5k   
   -   5        $
 border_AddDos??5k      $??1??6L   $??2q?6Y   $	??130??6m   $??60??6y   $ 20??6?   $??Right=?6?   $??Bottom=?6?   $??	0 0 85 35q?6?   $
	 Hand??6?   ??5l      ?? 5m      $ 0.5,0&?6&   $ 0.5,1&?69   .??5n      ? $ #A81DFE??6#   $ 0Q?5o   '   ? 5p      $ #E76E8B??6#   $ 1Q?5q   '   5r      ??5t      ?? 5u      " ??6   .?5v      ??  ? ??
 ???? 63    5w      ?? 5x       6&   ?? *IsMouseOver+$ border_AddDos?? true6`   .a?5y      ??  ? ?? 5z   "   ?? 5{   &   $ 0.5,0&?6:   $ 0.5,1&?6M   .??5|   *   ? $ #A81DFE??67   $ 0Q?5}   '   ? 5~   *   $ #E76E8B??67   $ 1Q?5   '   5?   '   5?      5?      5?      ._?5?      ?? $??Добавить??6   $??19(?6'   
???????$!??Bahnschrift Light Condensed)?6H   $??Center=?6q   $??Center=?6?   5?      5?      5?      