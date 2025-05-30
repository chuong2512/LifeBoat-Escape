#if MK_URP
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MK.Toon.URP
{
    public class MKToonPerObjectOutlines : ScriptableRendererFeature
    {
        private const string _componentName = "MKToonPerObjectOutlines";
        private const string _shaderPassName = "MKToonOutline";

        #if UNITY_2023_3_OR_NEWER
        private UnityEngine.Rendering.Universal.RenderObjects _renderObjectsFeature;
        #else
        private UnityEngine.Experimental.Rendering.Universal.RenderObjects _renderObjectsFeature;
        #endif

        public LayerMask _layerMask = -1;

        public override void Create()
        {
            #if UNITY_2023_3_OR_NEWER
            _renderObjectsFeature = ScriptableObject.CreateInstance<UnityEngine.Rendering.Universal.RenderObjects>();
            #else
            _renderObjectsFeature = ScriptableObject.CreateInstance<UnityEngine.Experimental.Rendering.Universal.RenderObjects>();
            #endif
            _renderObjectsFeature.settings.passTag = _componentName;
            name = _componentName;
            _renderObjectsFeature.settings.filterSettings.LayerMask = _layerMask;
            _renderObjectsFeature.settings.filterSettings.PassNames = new string[1] { _shaderPassName };

            _renderObjectsFeature.Create();
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            _renderObjectsFeature.settings.filterSettings.LayerMask = _layerMask;
            _renderObjectsFeature.AddRenderPasses(renderer, ref renderingData);
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
