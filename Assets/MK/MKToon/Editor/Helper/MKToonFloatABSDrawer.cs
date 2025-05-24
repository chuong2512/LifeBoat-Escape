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
    internal class MKToonFloatABSDrawer : MK.Toon.Editor.MaterialPropertyDrawer
    {
        public MKToonFloatABSDrawer(GUIContent ui) : base(ui) {}
        public MKToonFloatABSDrawer() : base() {}

        public override void OnGUI(Rect position, MaterialProperty prop, String label, MaterialEditor editor)
        {
            float value = prop.floatValue;

            EditorGUI.showMixedValue = prop.hasMixedValue;
            EditorGUI.BeginChangeCheck();

            value = EditorGUI.FloatField(position, new GUIContent(label, _guiContent.tooltip), prop.floatValue);

            if (EditorGUI.EndChangeCheck())
            {
                prop.floatValue = value < 0 ? 0 : value;
            }
            EditorGUI.showMixedValue = false;
        }
    }

    internal class MKToonOutlineSizeDrawer : MKToonFloatABSDrawer
    {
        public MKToonOutlineSizeDrawer() : base(UI.outlineMap) {}
    }
    internal class MKToonSpecularIntensityDrawer : MKToonFloatABSDrawer
    {
        public MKToonSpecularIntensityDrawer() : base(UI.specularIntensity) {}
    }
    internal class MKToonTransmissionIntensityDrawer : MKToonFloatABSDrawer
    {
        public MKToonTransmissionIntensityDrawer() : base(UI.lightTransmissionIntensity) {}
    }
    internal class MKToonSoftFadeNearDistanceDrawer : MKToonFloatABSDrawer
    {
        public MKToonSoftFadeNearDistanceDrawer() : base(UI.softFadeNearDistance) {}
    }
    internal class MKToonSoftFadeFarDistanceDrawer : MKToonFloatABSDrawer
    {
        public MKToonSoftFadeFarDistanceDrawer() : base(UI.softFadeFarDistance) {}
    }
    internal class MKToonCameraFadeFarDistanceDrawer : MKToonFloatABSDrawer
    {
        public MKToonCameraFadeFarDistanceDrawer() : base(UI.cameraFadeFarDistance) {}
    }
    internal class MKToonCameraFadeNearDistanceDrawer : MKToonFloatABSDrawer
    {
        public MKToonCameraFadeNearDistanceDrawer() : base(UI.cameraFadeNearDistance) {}
    }
    internal class MKToonBrightnessDrawer : MKToonFloatABSDrawer
    {
        public MKToonBrightnessDrawer() : base(UI.brightness) {}
    }
    internal class MKToonSaturationDrawer : MKToonFloatABSDrawer
    {
        public MKToonSaturationDrawer() : base(UI.saturation) {}
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
