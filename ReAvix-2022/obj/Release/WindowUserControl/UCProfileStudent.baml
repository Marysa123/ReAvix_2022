   M S B A M L   `   `   `  ???? F  BReAvix-2022, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ReAvix_2022.WindowUserControlReAvix_2022.WindowUserControl  4    .ReAvix_2022.WindowUserControl.UCProfileStudent   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:ReAvix_2022.WindowUserControl     _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    ? DataContext$  VMWindowProfileStudent??.??? 
??????  ? ColumnDefinitions ?? $	??400 ??? ??  ? RowDefinitions ?? ?? .+??? -   $??	icon_Exit??$??3??$	??Top=?$??0??$??Right=?$??	0 25 25 0q?$??17??????  ?? 
TargetType" ??.???  ?? Property ? ?? ?? Value$% /Resources/Images/icon_Exit.png?? ?? Triggers ??  ?? Binding ?? *IsMouseOver+ ?? ElementName$ 	icon_Exit??	 ?? Value	 true.a???  ? ??$, &/Resources/Images/icon_ExitStatus2.png???? $??0??$??Ваш профиль??
???????$??30(?$
??Left=?$??	30 30 0 0q?$	??Top=?$??40??$!??Bahnschrift Light Condensed)??? $
??1380??$	??380??$	??Top=?$??3?????#21335B
 ?? CornerRadius$
 10??$??0 80 0 0q?._??  ?? ?? ?? .+??? -   $??ImagesProfile??$??0??$	??440??$	??400??$??	0 50 50 0q?????  ?? Path$ SourceIm? J? Clip @?  @? Center$ 140,130&? @? RadiusX$	 120Q? @? RadiusY$	 120Q??? -   $/??)Сохранить изображение??$??0?? ? Cursor$
 Hand??$??Bottom=?$??Right=?$??0 10 140 30q?
???????$??20(?$??30??$!??Bahnschrift Light Condensed)??? -   $)??#/Resources/Images/icon_AddPhoto.png??$??65??$??65??$??Right=?$??Bottom=?$??
0 0 140 70q?$
 Hand?? J? BitmapEffect F?  F? Color$ Black?? F? 	Direction$	 320Q? F? Softness$ 1Q? F? ShadowDepth$ 20Q? F? Opacity$	 0.5Q??? $??1??.+??? $??1??$	??Top=?$??	0 120 0 0q?$
??Left=?
???????$??32(?$??40??$!??Bahnschrift Light Condensed)????? $ FI??? $??1??$	??Top=?$??0 0 0 20q?$
??Left=????#A4A1A1$??20(?$??34??$!??Bahnschrift Light Condensed)????? $ Cours?? $??0 0 0 20q?.+??? $??35??$??35??$)??#/Resources/Images/icon_OldPhone.png???? $??1??$	??Top=?$??10 0 0 0q?$
??Left=?
???????$??22(?$??34??$!??Bahnschrift Light Condensed)????? $ Phone?? $??0 0 0 20q?.+??? $??35??$??35??$&?? /Resources/Images/icon_EMail.png???? $??1??$	??Top=?$??10 0 0 0q?$
??Left=?
???????$??22(?$??34??$!??Bahnschrift Light Condensed)????? $
 Mail?? $??0 0 0 20q?$
??1000??.+??? $??35??$??35??$)??#/Resources/Images/icon_Location.png???? $??10 5 0 0q?$
??Left=?
???????$??22(?$
??Wrap=?$!??Bahnschrift Light Condensed)????? $ Adress?? .+??? $??35??$??35??$$??/Resources/Images/icon_Age.png???? $??1??$	??Top=?$??10 0 0 0q?$
??Left=?
???????$??22(?$??30??$!??Bahnschrift Light Condensed)????? $	 Age??? $??0??$??1??.+??? -   $??textbox_Fam?????#689ADD$??	40 0 0 40q?$??20(?
???????.  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  %  !MaterialDesignFloatingHintTextBox#??[  )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия:??$??60??$	??350??   UnderlineBrush ?#187AFD   
Foreground
 ?????$??0 0 0 2q????? $	 Fam??? -   $??textbox_Ima??$??	40 0 0 40q????#689ADD$??0??$??20(?
??????? . #??[  $ Имя:??$??60??$	??350?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $	 Ima??? -   $??textbox_Otc?????#689ADD$??2??$??	40 0 0 40q?$??20(?
??????? . #??[  $ Отчество:??$??60??$	??350?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $
 Otch??? $??Ваша группа:??$??1??$	??Top=?$??40 0 0 0q?$
??Left=?
???????$??22(?$??40??$!??Bahnschrift Light Condensed)??? -   $??textbox_Group?? ?? 
IsReadOnly . ???#689ADD$??	45 5 0 40q?$??20(?
???????$??50??$??90?? ?#187AFD$??0 0 0 2q?$
??Left=?$ Arrow?????? $ Group??? $??1??$??2??.+??? -	   $??textbox_EMail??$ E-mail:??   LeadingIcon$ MailboxOpenUp=?$??	40 0 0 40q?   LeadingIconSize$ 25Q?   HasLeadingIcon . ???#689ADD$??20(?
??????? . #??[  $??60??$	??350?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $
 Mail??? -
   $??textbox_Phone??$" Номер телефона:??$ Phone=?$ 25Q? . ???#689ADD$??	40 0 0 40q?$??20(?/  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions .   ?? 	MaxLength$  11??
??????? . #??[  $??60??$	??350?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $ Phone??? -   $??textbox_PhoneRod??$5 /Номер телефона родителей:??$ Phone=?$ 25Q? . ???#689ADD$??	40 0 0 30q?$??20(? . $  11??
??????? . #??[  $??60??$	??350?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $ PhoneRod??? $-??'Дата рождения (М /Д /Г):??$??1??$??
100 10 0 0q?
???????$??22(?$!??Bahnschrift Light Condensed)??? -   $??text_boxData?? . ???#689ADD$??1??$??	102 0 0 0q?$??20(?
???????#??[  $??60??$	??150?? ?#187AFD$
??Left=?
 ?????$??0 0 0 2q?$ Arrow?????? $ DataRosh??? $??2??$??1??.+??? -   $??textbox_Adress??$ Адрес:?????#689ADD$??2??$??	0 0 60 20q?$??20(?
??????? . #??[  $??60??$	??390?? ?#187AFD
 ?????$??0 0 0 2q?$ Arrow?????? $ Adress??? $*??$Краткая информация:??$??1??$??30 0 0 0q?$
??Left=?
???????$??22(?$??35??$!??Bahnschrift Light Condensed)??? -   $??textbox_DateMe?? ! MaterialDesignOutlinedTextBox#??[ $	??Top=?$	??220??$??20(?! ?? AcceptsReturn! . " ?? TextWrapping$
" Wrap=?$??
35 10 35 0q?"# ?? VerticalScrollBarVisibility$
# Auto=?$   
Background
$ ???? 
 ?   ?
???   ?%   FloatingScale$	% 0.8Q?
???????$	  400??
???????$ Arrow?????? $ InfoMe?{??? $ 	IsChecked?$2 ,MaterialDesignOutlinedTextBoxEnabledComboBox???? -   $??button_AddDop??  StyleButtonAllApplication#??[ $??	0 20 10 0q?$	??252??$??65??$??Изменить??$??18(?$??Bottom=?$??Center=?$??Bahnschrift)?