﻿#pragma checksum "..\..\..\Views\WindowInfoStudent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8330B18184BDFE0B830D459665CBF634A1597C0E45E49A755E75347B742197F6"
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
    /// WindowInfoStudent
    /// </summary>
    public partial class WindowInfoStudent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImagesProfile;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_TextSkils;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PanelSkils;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PanelDos;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Views\WindowInfoStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PanelPredmet;
        
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
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/views/windowinfostudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\WindowInfoStudent.xaml"
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
            
            #line 26 "..\..\..\Views\WindowInfoStudent.xaml"
            this.icon_Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImagesProfile = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.textbox_TextSkils = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PanelSkils = ((System.Windows.Controls.ListBox)(target));
            
            #line 101 "..\..\..\Views\WindowInfoStudent.xaml"
            this.PanelSkils.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PanelSkils_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PanelDos = ((System.Windows.Controls.ListBox)(target));
            
            #line 111 "..\..\..\Views\WindowInfoStudent.xaml"
            this.PanelDos.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PanelDos_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PanelPredmet = ((System.Windows.Controls.ListBox)(target));
            
            #line 122 "..\..\..\Views\WindowInfoStudent.xaml"
            this.PanelPredmet.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.PanelPredmet_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

