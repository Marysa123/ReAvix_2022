﻿#pragma checksum "..\..\..\Views\WindowAboutSkils.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD9156CB53AA8A275C901CD9C09466200C0AE2EBA6AAEE4F8096A8950281263D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using ReAvix_2022.ViewModels;
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


namespace ReAvix_2022.Views {
    
    
    /// <summary>
    /// WindowAboutSkils
    /// </summary>
    public partial class WindowAboutSkils : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Views\WindowAboutSkils.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\WindowAboutSkils.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_TextSkils;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\WindowAboutSkils.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_ValueMaster;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Views\WindowAboutSkils.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_UpdateSkilsStud;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\WindowAboutSkils.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_DeleteSkilsStud;
        
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
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/views/windowaboutskils.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\WindowAboutSkils.xaml"
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
            
            #line 21 "..\..\..\Views\WindowAboutSkils.xaml"
            this.icon_Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textbox_TextSkils = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.combobox_ValueMaster = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.button_UpdateSkilsStud = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\Views\WindowAboutSkils.xaml"
            this.button_UpdateSkilsStud.Click += new System.Windows.RoutedEventHandler(this.button_UpdateSkilsStud_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button_DeleteSkilsStud = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Views\WindowAboutSkils.xaml"
            this.button_DeleteSkilsStud.Click += new System.Windows.RoutedEventHandler(this.button_DeleteSkilsStud_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

