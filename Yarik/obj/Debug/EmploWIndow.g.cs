﻿#pragma checksum "..\..\EmploWIndow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C05BC4EEAA16D50DB1790E53B28243A7B4816F724F1DEB97135BCC3CF8C9E1C0"
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
using Yarik;


namespace Yarik {
    
    
    /// <summary>
    /// EmploWIndow
    /// </summary>
    public partial class EmploWIndow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmploName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmploSurname;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmploMiddleName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Salary;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Password;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboRole;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EmploWIndow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EmploWatch;
        
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
            System.Uri resourceLocater = new System.Uri("/Yarik;component/emplowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EmploWIndow.xaml"
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
            this.EmploName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.EmploSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.EmploMiddleName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Salary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ComboRole = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 38 "..\..\EmploWIndow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 39 "..\..\EmploWIndow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 40 "..\..\EmploWIndow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 41 "..\..\EmploWIndow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear);
            
            #line default
            #line hidden
            return;
            case 13:
            this.EmploWatch = ((System.Windows.Controls.DataGrid)(target));
            
            #line 42 "..\..\EmploWIndow.xaml"
            this.EmploWatch.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EmploPerenos);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 57 "..\..\EmploWIndow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

