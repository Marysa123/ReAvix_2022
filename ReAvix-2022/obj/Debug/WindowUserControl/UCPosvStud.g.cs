﻿#pragma checksum "..\..\..\WindowUserControl\UCPosvStud.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78E63496993074D3856025CCADEFD0A24D295DC428BFB1A551DE493BCA6FCB8E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ReAvix_2022.WindowUserControl;
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
    /// UCPosvStud
    /// </summary>
    public partial class UCPosvStud : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GridViewOmissions;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_Yvash;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_NoYvash;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_Bolezn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_NomerStud;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_DeleteOmissions;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\WindowUserControl\UCPosvStud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_AddOtch;
        
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
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/windowusercontrol/ucposvstud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowUserControl\UCPosvStud.xaml"
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
            
            #line 15 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.icon_Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridViewOmissions = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.textbox_Yvash = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.textbox_Yvash.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_Yvash_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textbox_NoYvash = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.textbox_NoYvash.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_NoYvash_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textbox_Bolezn = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.textbox_Bolezn.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.textbox_Bolezn_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.label_NomerStud = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            
            #line 61 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.button_DeleteOmissions = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.button_DeleteOmissions.Click += new System.Windows.RoutedEventHandler(this.button_DeleteOmissions_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.button_AddOtch = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\WindowUserControl\UCPosvStud.xaml"
            this.button_AddOtch.Click += new System.Windows.RoutedEventHandler(this.button_AddOtch_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

