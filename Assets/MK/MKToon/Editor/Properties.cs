//////////////////////////////////////////////////////
// MK Toon Editor Properties           			    //
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2020 All rights reserved.            //
//////////////////////////////////////////////////////

#if UNITY_EDITOR
using MK.Toon;

namespace MK.Toon.Editor
{
    internal static class EditorProperties
    {
        /////////////////
        // Editor Only //
        /////////////////
        internal static readonly BoolProperty initialized   = new BoolProperty(Uniforms.initialized);
        internal static readonly BoolProperty optionsTab    = new BoolProperty(Uniforms.optionsTab);
        internal static readonly BoolProperty inputTab      = new BoolProperty(Uniforms.inputTab);
        internal static readonly BoolProperty stylizeTab    = new BoolProperty(Uniforms.stylizeTab);
        internal static readonly BoolProperty advancedTab   = new BoolProperty(Uniforms.advancedTab);
        internal static readonly BoolProperty particlesTab = new BoolProperty(Uniforms.particlesTab);
        internal static readonly BoolProperty outlineTab    = new BoolProperty(Uniforms.outlineTab);
        internal static readonly BoolProperty refractionTab = new BoolProperty(Uniforms.refractionTab);
        
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
