// Updated by XamlIntelliSenseFileGenerator 27.01.2025 6:21:39
#pragma checksum "..\..\FizLicoWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9C186FEE306421D780D02F8652D59C490CF0150BE39A28A769919D6AFE2B806"
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


namespace Yarik
{


    /// <summary>
    /// FizLicoWindow
    /// </summary>
    public partial class FizLicoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 31 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CompanyName;

#line default
#line hidden


#line 32 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientName;

#line default
#line hidden


#line 33 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientSurname;

#line default
#line hidden


#line 34 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientMiddleName;

#line default
#line hidden


#line 35 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumber;

#line default
#line hidden


#line 36 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;

#line default
#line hidden


#line 37 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientAddress;

#line default
#line hidden


#line 38 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox INN;

#line default
#line hidden


#line 44 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ClientsWatch;

#line default
#line hidden


#line 67 "..\..\FizLicoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PerexodTypeClient;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Yarik;component/fizlicowindow.xaml", System.UriKind.Relative);

#line 1 "..\..\FizLicoWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.CompanyName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.ClientName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.ClientSurname = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.ClientMiddleName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.PhoneNumber = ((System.Windows.Controls.TextBox)(target));

#line 35 "..\..\FizLicoWindow.xaml"
                    this.PhoneNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PhoneNumberPreviewTextInput);

#line default
#line hidden
                    return;
                case 6:
                    this.Email = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.ClientAddress = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.INN = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 9:
                    this.PassportData = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 10:

#line 40 "..\..\FizLicoWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);

#line default
#line hidden
                    return;
                case 11:

#line 41 "..\..\FizLicoWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Update);

#line default
#line hidden
                    return;
                case 12:

#line 42 "..\..\FizLicoWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);

#line default
#line hidden
                    return;
                case 13:

#line 43 "..\..\FizLicoWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Clear);

#line default
#line hidden
                    return;
                case 14:
                    this.ClientsWatch = ((System.Windows.Controls.DataGrid)(target));

#line 44 "..\..\FizLicoWindow.xaml"
                    this.ClientsWatch.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PerenosFiz);

#line default
#line hidden
                    return;
                case 15:
                    this.PerexodTypeClient = ((System.Windows.Controls.ComboBox)(target));

#line 68 "..\..\FizLicoWindow.xaml"
                    this.PerexodTypeClient.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RealizaciaPerexoda);

#line default
#line hidden
                    return;
                case 16:

#line 73 "..\..\FizLicoWindow.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox Dolshnost;
    }
}

