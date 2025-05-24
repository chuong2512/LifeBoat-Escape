#if UNITY_EDITOR
#if MK_URP
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MK.Toon.URP.Editor
{
    [CustomEditor(typeof(MK.Toon.URP.MKToonPerObjectOutlines))]
    public class MKToonPerObjectOutlinesEditor : UnityEditor.Editor
    {
        private GUIContent _layerMaskUI = new GUIContent
        (
            "Layer Mask",
            "Defines the layermask for objects, which should render the outline, if a MK Toon outlined shader is applied."
        );

        private SerializedProperty _layerMask;

        private void UpdateInstallWizard()
        {
            MK.Toon.Editor.InstallWizard.InstallWizard installWizard = MK.Toon.Editor.InstallWizard.InstallWizard.instance;
            if(installWizard != null)
                MK.Toon.Editor.InstallWizard.InstallWizard.instance.Repaint();
        }

        private void OnEnable()
        {
            UpdateInstallWizard();
        }

        private void OnDisable()
        {
            UpdateInstallWizard();
        }

        private void FindProperties()
        {
            _layerMask = serializedObject.FindProperty("_layerMask");
        }

        public override void OnInspectorGUI()
        {
            FindProperties();
            
            EditorGUILayout.PropertyField(_layerMask, _layerMaskUI);
            //DrawDefaultInspector();

            UpdateInstallWizard();
        }
    }
}
#endif
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
