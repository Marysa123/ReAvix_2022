﻿#pragma checksum "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "714A21DFDC6CE237BBAA3B4B0D2C94FABAB25CA90AF2AB916BA4D22DFCFEFE01"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ReAvix_2022.WindowUserControl;
using Syncfusion;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.ProgressBar;
using Syncfusion.Windows;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ReAvix_2022.WindowUserControl {
    
    
    /// <summary>
    /// UСAddPredmetsPrep
    /// </summary>
    public partial class UСAddPredmetsPrep : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label button_Update;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_AddPredmets;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PanelPredmets;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/windowusercontrol/ucviewpredmetsprep.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.icon_Exit = ((System.Windows.Controls.Image)(target));
            
            #line 14 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
            this.icon_Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button_Update = ((System.Windows.Controls.Label)(target));
            
            #line 28 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
            this.button_Update.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.button_Update_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.border_AddPredmets = ((System.Windows.Controls.Border)(target));
            
            #line 40 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
            this.border_AddPredmets.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.border_AddPredmets_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PanelPredmets = ((System.Windows.Controls.ListBox)(target));
            
            #line 72 "..\..\..\WindowUserControl\UCViewPredmetsPrep.xaml"
            this.PanelPredmets.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PanelPredmets_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

