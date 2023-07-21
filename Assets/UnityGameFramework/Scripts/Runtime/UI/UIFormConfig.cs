using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public static class UI
    {
        public static readonly string Home = "ui_home";
        public static readonly string Loading = "ui_loading";
        public static readonly string SettingsPopup = "ui_settings_popup";
        public static readonly string Template = "ui_template";
    }

    public static class UIConfig
    {
        public static Dictionary<string, UIProperty> DicUIProperty = new Dictionary<string, UIProperty>
        {
            //----------------------------功能模板UI------------------------------
            {UI.Template,new UIProperty(UIGroup.UI)},

            //----------------------------功能UI---------------------------------
            {UI.Home,new UIProperty(UIGroup.UI)},
            {UI.Loading,new UIProperty(UIGroup.UI)},
            {UI.SettingsPopup,new UIProperty(UIGroup.UI)},
        };
    }

    public class UIGroup 
    {
        public static readonly string System = "System";
        public static readonly string Root = "Root";
        public static readonly string UI = "UI";
        public static readonly string Dialog = "Dialog";
    }

    public class UIProperty
    {
        public string UIGroup;

        public UIProperty(string uiGroup)
        {
            UIGroup = uiGroup;
        }
    }
}

