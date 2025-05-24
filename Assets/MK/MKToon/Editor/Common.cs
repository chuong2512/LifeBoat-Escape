//////////////////////////////////////////////////////
// MK Toon Editor Common             			    //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
namespace MK.Toon.Editor
{
    internal enum RenderPipeline
    {
        Built_in,
        //Lightweight,
        Universal
    }
    internal enum RenderPipelineUpgrade
    {
        //Lightweight,
        Universal,
        Noise
    }
    internal enum ShaderTemplate
    {
        Unlit,
        Simple,
        PhysicallyBased
    }
    internal enum BlendOpaque
    {
        Default = 0,
        Custom = 4
    };

    [System.Serializable]
    public class ExampleContainer
    {
        public string name = "";
        public UnityEngine.Object scene = null;
        public UnityEngine.Texture2D icon = null;

        public void DrawEditorButton()
        {
            if(UnityEngine.GUILayout.Button(icon, UnityEngine.GUILayout.Width(64), UnityEngine.GUILayout.Height(64)))
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(UnityEditor.AssetDatabase.GetAssetOrScenePath(scene));
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
