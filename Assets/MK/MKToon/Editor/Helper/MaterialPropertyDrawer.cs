//////////////////////////////////////////////////////
// MK Toon Editor Material Property Drawer Base     //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace MK.Toon.Editor
{
    internal abstract class MaterialPropertyDrawer : UnityEditor.MaterialPropertyDrawer
    {
        protected GUIContent _guiContent;
        public MaterialPropertyDrawer(GUIContent ui)
        {
            this._guiContent = ui;
        }
        public MaterialPropertyDrawer()
        {
            this._guiContent = GUIContent.none;
        }
    }
}
#endif

//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
