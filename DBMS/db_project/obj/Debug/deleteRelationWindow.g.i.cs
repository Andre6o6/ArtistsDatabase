﻿#pragma checksum "..\..\deleteRelationWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "33DC876B9B5DD179A4D66DDF4C19447F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using db_project;


namespace db_project {
    
    
    /// <summary>
    /// deleteRelationWindow
    /// </summary>
    public partial class deleteRelationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tableComboBox1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox tableComboBox2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCancel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox itemComboBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAttr;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelDeletedCount;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOK;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonXMLExport;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonXMLImport;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\deleteRelationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox richTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/db_project;component/deleterelationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\deleteRelationWindow.xaml"
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
            this.tableComboBox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\deleteRelationWindow.xaml"
            this.tableComboBox1.DropDownClosed += new System.EventHandler(this.tableComboBox1_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tableComboBox2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\deleteRelationWindow.xaml"
            this.tableComboBox2.DropDownClosed += new System.EventHandler(this.tableComboBox2_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\deleteRelationWindow.xaml"
            this.buttonCancel.Click += new System.Windows.RoutedEventHandler(this.buttonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\deleteRelationWindow.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.itemComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.labelAttr = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.labelDeletedCount = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.buttonOK = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\deleteRelationWindow.xaml"
            this.buttonOK.Click += new System.Windows.RoutedEventHandler(this.buttonOK_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.buttonXMLExport = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\deleteRelationWindow.xaml"
            this.buttonXMLExport.Click += new System.Windows.RoutedEventHandler(this.buttonXMLExport_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.buttonXMLImport = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\deleteRelationWindow.xaml"
            this.buttonXMLImport.Click += new System.Windows.RoutedEventHandler(this.buttonXMLImport_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.richTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

