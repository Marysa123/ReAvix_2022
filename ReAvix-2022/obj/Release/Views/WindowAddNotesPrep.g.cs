﻿#pragma checksum "..\..\..\Views\WindowAddNotesPrep.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7D285A2AD125B6192228C3023B234C6CD73E47ACF7A08CBDD3E704022A485BF3"
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
using ReAvix_2022.Views;
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
    /// WindowAddNotesPrep
    /// </summary>
    public partial class WindowAddNotesPrep : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\Views\WindowAddNotesPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\WindowAddNotesPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_Text;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\WindowAddNotesPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_Property;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\WindowAddNotesPrep.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_AddNotes;
        
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
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/views/windowaddnotesprep.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\WindowAddNotesPrep.xaml"
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
            
            #line 23 "..\..\..\Views\WindowAddNotesPrep.xaml"
            this.icon_Exit.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textbox_Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.combobox_Property = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.button_AddNotes = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Views\WindowAddNotesPrep.xaml"
            this.button_AddNotes.Click += new System.Windows.RoutedEventHandler(this.button_AddNotes_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

