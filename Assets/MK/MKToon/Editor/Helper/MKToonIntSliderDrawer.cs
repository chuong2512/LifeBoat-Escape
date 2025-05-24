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
    internal class MKToonIntSliderDrawer : MK.Toon.Editor.MaterialPropertyDrawer
    {
        public MKToonIntSliderDrawer(GUIContent ui) : base(ui) {}
        public MKToonIntSliderDrawer() : base(GUIContent.none) {}

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor editor)
        {
            EditorGUI.showMixedValue = prop.hasMixedValue;
            int intValue = (int) prop.floatValue;
            EditorGUI.BeginChangeCheck();

            intValue = EditorGUI.IntSlider(position, new GUIContent(label, _guiContent.tooltip), intValue, (int) prop.rangeLimits.x, (int) prop.rangeLimits.y);

            if (EditorGUI.EndChangeCheck())
            {
                prop.floatValue = intValue;
            }
            EditorGUI.showMixedValue = false;
        }
    }
    internal class MKToonLightBandsDrawer : MKToonIntSliderDrawer
    {
        public MKToonLightBandsDrawer() : base(UI.lightBands) {}
    }
    internal class MKToonStencilRefDrawer : MKToonIntSliderDrawer
    {
        public MKToonStencilRefDrawer() : base(UI.stencilRef) {}
    }
    internal class MKToonStencilReadMaskDrawer : MKToonIntSliderDrawer
    {
        public MKToonStencilReadMaskDrawer() : base(UI.stencilReadMask) {}
    }
    internal class MKToonStencilWriteMaskDrawer : MKToonIntSliderDrawer
    {
        public MKToonStencilWriteMaskDrawer() : base(UI.stencilWriteMask) {}
    }
    internal class MKToonRenderPriorityDrawer : MKToonIntSliderDrawer
    {
        public MKToonRenderPriorityDrawer() : base(UI.renderPriority) {}
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
