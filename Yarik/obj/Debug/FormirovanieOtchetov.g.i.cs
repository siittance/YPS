﻿#pragma checksum "..\..\FormirovanieOtchetov.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B254C62EE8E8FC572EB8595484BC3442FBC1B5534D3D8A0E1C181180754254D6"
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
    /// FormirovanieOtchetov
    /// </summary>
    public partial class FormirovanieOtchetov : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\FormirovanieOtchetov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker StartDatePicker;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FormirovanieOtchetov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDatePicker;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FormirovanieOtchetov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ReportComboBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FormirovanieOtchetov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RentalsWatch;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\FormirovanieOtchetov.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EquipmentWatch;
        
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
            System.Uri resourceLocater = new System.Uri("/Yarik;component/formirovanieotchetov.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FormirovanieOtchetov.xaml"
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
            this.StartDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.EndDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.ReportComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\FormirovanieOtchetov.xaml"
            this.ReportComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ReportComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RentalsWatch = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.EquipmentWatch = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 55 "..\..\FormirovanieOtchetov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateReportButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 56 "..\..\FormirovanieOtchetov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 60 "..\..\FormirovanieOtchetov.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

