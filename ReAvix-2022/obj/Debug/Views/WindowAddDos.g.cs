#pragma checksum "..\..\..\Views\WindowAddDos.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "79AB3555AF164416A554BB9F2579AABB948563FB27146FF3D038B2B08850EF34"
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
    /// WindowAddDos
    /// </summary>
    public partial class WindowAddDos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image icon_Exit;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_Mesto;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_Mesto;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textbox_Name;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image DopImage;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\WindowAddDos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_AddDop;
        
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
            System.Uri resourceLocater = new System.Uri("/ReAvix-2022;component/views/windowadddos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\WindowAddDos.xaml"
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
            
            #line 26 "..\..\..\Views\WindowAddDos.xaml"
            this.icon_Exit.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.icon_Exit_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Image = ((System.Windows.Controls.Image)(target));
            
            #line 41 "..\..\..\Views\WindowAddDos.xaml"
            this.Image.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.combobox_Mesto = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.textbox_Mesto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textbox_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.DopImage = ((System.Windows.Controls.Image)(target));
            
            #line 75 "..\..\..\Views\WindowAddDos.xaml"
            this.DopImage.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DopImage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button_AddDop = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Views\WindowAddDos.xaml"
            this.button_AddDop.Click += new System.Windows.RoutedEventHandler(this.button_AddDop_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

