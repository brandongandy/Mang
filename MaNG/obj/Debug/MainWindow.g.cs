﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DEAAFBDAFAD6AC5ABF8D6E828AD9D0D7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mang;
using MaterialDesignThemes.Wpf;
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


namespace Mang {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Mang.MainWindow Mang;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label sourceLabel;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox nameSourceTypeCB;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label typeLabel;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox nameTypeCB;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label subTypeLabel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox nameSubTypeCB;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label orderLabel;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox orderCB;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button genFromPreset;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label inputLabel;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox markovInputBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label outputLabel;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox markovOutputBox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button inToOut;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button infoButton;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button helpButton;
        
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
            System.Uri resourceLocater = new System.Uri("/MaNG;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Mang = ((Mang.MainWindow)(target));
            return;
            case 2:
            this.sourceLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.nameSourceTypeCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\MainWindow.xaml"
            this.nameSourceTypeCB.Loaded += new System.Windows.RoutedEventHandler(this.NameSourceType_Loaded);
            
            #line default
            #line hidden
            
            #line 61 "..\..\MainWindow.xaml"
            this.nameSourceTypeCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NameSourceType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.typeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.nameTypeCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\MainWindow.xaml"
            this.nameTypeCB.Loaded += new System.Windows.RoutedEventHandler(this.NameType_Loaded);
            
            #line default
            #line hidden
            
            #line 66 "..\..\MainWindow.xaml"
            this.nameTypeCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NameType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.subTypeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.nameSubTypeCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 71 "..\..\MainWindow.xaml"
            this.nameSubTypeCB.Loaded += new System.Windows.RoutedEventHandler(this.NameSubType_Loaded);
            
            #line default
            #line hidden
            
            #line 71 "..\..\MainWindow.xaml"
            this.nameSubTypeCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NameSubType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.orderLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.orderCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 76 "..\..\MainWindow.xaml"
            this.orderCB.Loaded += new System.Windows.RoutedEventHandler(this.OrderLength_Loaded);
            
            #line default
            #line hidden
            
            #line 76 "..\..\MainWindow.xaml"
            this.orderCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OrderLength_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.genFromPreset = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\MainWindow.xaml"
            this.genFromPreset.Click += new System.Windows.RoutedEventHandler(this.Preset_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.inputLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.markovInputBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.outputLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.markovOutputBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.inToOut = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\MainWindow.xaml"
            this.inToOut.Click += new System.Windows.RoutedEventHandler(this.UserInput_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.infoButton = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\MainWindow.xaml"
            this.infoButton.Click += new System.Windows.RoutedEventHandler(this.Info_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.helpButton = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\MainWindow.xaml"
            this.helpButton.Click += new System.Windows.RoutedEventHandler(this.Help_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
