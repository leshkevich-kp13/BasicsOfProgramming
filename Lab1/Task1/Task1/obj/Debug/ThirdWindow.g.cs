#pragma checksum "..\..\ThirdWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A4B74576E98FC8D5D45DCAC710906D5694EC31119C4F23082EBD967992147D7"
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
using Task1;


namespace Task1 {
    
    
    /// <summary>
    /// ThirdWindow
    /// </summary>
    public partial class ThirdWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Score_X_Label;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Score_O_Label;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CurrentTurnLabel;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid grid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MoveToMainFromThird_Btn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartTwoPlayers_Btn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\ThirdWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartOnePlayer_Btn;
        
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
            System.Uri resourceLocater = new System.Uri("/Task1;component/thirdwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThirdWindow.xaml"
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
            this.Score_X_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Score_O_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CurrentTurnLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.grid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 5:
            this.MoveToMainFromThird_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\ThirdWindow.xaml"
            this.MoveToMainFromThird_Btn.Click += new System.Windows.RoutedEventHandler(this.MoveToMainFromThird_Btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartTwoPlayers_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\ThirdWindow.xaml"
            this.StartTwoPlayers_Btn.Click += new System.Windows.RoutedEventHandler(this.StartTwoPlayersBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StartOnePlayer_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\ThirdWindow.xaml"
            this.StartOnePlayer_Btn.Click += new System.Windows.RoutedEventHandler(this.StartOnePlayerBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

