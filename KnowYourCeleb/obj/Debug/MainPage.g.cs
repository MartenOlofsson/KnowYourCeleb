﻿

#pragma checksum "c:\HobbyProjekt\KnowYourCeleb\KnowYourCeleb\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B4F3CC2DBBCEE9A6BFD4FA2AB6C3926"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnowYourCeleb
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\MainPage.xaml"
                ((global::KnowYourCeleb.Controls.Normal)(target)).Changed += this.NormalView_Changed;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 13 "..\..\MainPage.xaml"
                ((global::KnowYourCeleb.Controls.Snapped)(target)).Changed += this.SnappedView_Changed;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


