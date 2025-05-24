//////////////////////////////////////////////////////
// MK Toon Editor Int Slider Drawer        			//
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
    internal class MKToonVector3Drawer : MK.Toon.Editor.MaterialPropertyDrawer
    {
        public MKToonVector3Drawer(GUIContent ui) : base(ui) {}
        public MKToonVector3Drawer() : base(GUIContent.none) {}

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor editor)
        {
            EditorGUI.showMixedValue = prop.hasMixedValue;
            Vector3 vectorValue = prop.vectorValue;
            EditorGUI.BeginChangeCheck();

            vectorValue = EditorGUI.Vector3Field(position, new GUIContent(label), vectorValue);

            if (EditorGUI.EndChangeCheck())
            {
                prop.vectorValue = vectorValue;
            }
            EditorGUI.showMixedValue = false;
        }
    }
    internal class MKToonVertexAnimationFrequencyDrawer : MKToonVector3Drawer
    {
        public MKToonVertexAnimationFrequencyDrawer() : base(UI.vertexAnimationFrequency) {}
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
