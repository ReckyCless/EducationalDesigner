﻿#pragma checksum "..\..\..\..\Pages\Views\QualificationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BC1C4E59E8D0AF5AE44042A4F74F790B6936C7516A3BDC9599CD6AA658E9AEE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EducationalDesigner.Pages.Views;
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


namespace EducationalDesigner.Pages.Views {
    
    
    /// <summary>
    /// QualificationPage
    /// </summary>
    public partial class QualificationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxSortBy;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkItemCounter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewQualifications;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPagePrev;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxCurrentPageSelection;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPageNext;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Pages\Views\QualificationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/EducationalDesigner;component/pages/views/qualificationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Views\QualificationPage.xaml"
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
            
            #line 9 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            ((EducationalDesigner.Pages.Views.QualificationPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cboxSortBy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.cboxSortBy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBoxSortBy_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.tbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TbSearch_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbkItemCounter = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.LViewQualifications = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.btnPagePrev = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.btnPagePrev.Click += new System.Windows.RoutedEventHandler(this.BtnPagePrev_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cboxCurrentPageSelection = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.cboxCurrentPageSelection.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBoxCurrentPageSelection_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnPageNext = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.btnPageNext.Click += new System.Windows.RoutedEventHandler(this.BtnPageNext_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 6:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 32 "..\..\..\..\Pages\Views\QualificationPage.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_MouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

