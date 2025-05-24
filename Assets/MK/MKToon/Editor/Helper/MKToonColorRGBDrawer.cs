//////////////////////////////////////////////////////
// MK Toon Editor Color RGB Drawer        			//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;

namespace MK.Toon.Editor
{
    internal class MKToonColorRGBDrawer : MK.Toon.Editor.MaterialPropertyDrawer
    {
        public MKToonColorRGBDrawer(GUIContent ui) : base(ui) {}
        public MKToonColorRGBDrawer() : base(GUIContent.none) {}

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor editor)
        {
            EditorGUI.showMixedValue = prop.hasMixedValue;
            Color color = prop.colorValue;
            EditorGUI.BeginChangeCheck();

            color = EditorGUI.ColorField(position, new GUIContent(label), color, true, false, false);

            if (EditorGUI.EndChangeCheck())
            {
                prop.colorValue = color;
            }
            EditorGUI.showMixedValue = false;
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
