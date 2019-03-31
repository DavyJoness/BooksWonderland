﻿#pragma checksum "..\..\SimpleBook.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "64B0A59369DE7B7EFA50E5462F19B200"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BooksWonderland;
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


namespace BooksWonderland {
    
    
    /// <summary>
    /// SimpleBook
    /// </summary>
    public partial class SimpleBook : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBook;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TextBoxAuthor;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TextBoxPublisher;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TextBoxGenre;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker TextBoxPurchased;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxYear;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPrice;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPages;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\SimpleBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDescribe;
        
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
            System.Uri resourceLocater = new System.Uri("/BooksWonderland;component/simplebook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SimpleBook.xaml"
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
            
            #line 8 "..\..\SimpleBook.xaml"
            ((BooksWonderland.SimpleBook)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\SimpleBook.xaml"
            ((BooksWonderland.SimpleBook)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddBook = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\SimpleBook.xaml"
            this.AddBook.Click += new System.Windows.RoutedEventHandler(this.AddBook_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxAuthor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.TextBoxPublisher = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.TextBoxGenre = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.TextBoxPurchased = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.TextBoxYear = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TextBoxPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TextBoxPages = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.TextBoxDescribe = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

