#pragma checksum "..\..\LearningSettings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA1F623F772B878E7EABE8BB43B11A7B174A22E5E2D07DDE568C78DCAD901DA7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KeystrokeDynamicsAuthentication;
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


namespace KeystrokeDynamicsAuthentication {
    
    
    /// <summary>
    /// LearningSettings
    /// </summary>
    public partial class LearningSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\LearningSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputWord_TextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LearningSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NumOfAttemps_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\LearningSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplySettings_Btn;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\LearningSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainWindow_Btn;
        
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
            System.Uri resourceLocater = new System.Uri("/KeystrokeDynamicsAuthentication;component/learningsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LearningSettings.xaml"
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
            this.InputWord_TextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.NumOfAttemps_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ApplySettings_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\LearningSettings.xaml"
            this.ApplySettings_Btn.Click += new System.Windows.RoutedEventHandler(this.ApplySettings_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MainWindow_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\LearningSettings.xaml"
            this.MainWindow_Btn.Click += new System.Windows.RoutedEventHandler(this.MainWindow_Btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

