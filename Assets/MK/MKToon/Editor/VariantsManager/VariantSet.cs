/*****************************************************
Copyright © 2025 Michael Kremmel
https://www.michaelkremmel.de
All rights reserved
*****************************************************/
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

namespace MK.Toon.Editor
{
    public sealed class VariantSet
    {
        private const string _searchPattern = @"^\s*#pragma\s+(shader_feature(?:_local)?|multi_compile(?:_local)?)\S*\s+(__(?:\s+\w+)*)$";
        private const string _replacePattern = @"^(\s*)#pragma\s+(shader_feature(?:_local)?|multi_compile(?:_local)?)\S*\s+(__(?:\s+\w+)*)$";

        private bool _alwaysIncluded = false;
        private GUIContent _guiContent;
        private string _keywords;

        private VariantSet() {}
        
        public VariantSet(string displayName, string keywords)
        {
            this._keywords = keywords;
            this._guiContent = new GUIContent(displayName);
        }

        public void LoadVariantState(string input)
        {
            Match match = Regex.Match(input, _searchPattern, RegexOptions.Singleline | RegexOptions.Compiled);
            
            if(!match.Success)
            {
                return;
            }

            string pragmaType = match.Groups[1].Value;
            string keywords = match.Groups[2].Value;

            if(keywords != _keywords)
            {
                return;
            }

            _alwaysIncluded = pragmaType.StartsWith("multi_compile");
        }

        public string ModifyVariant(string input)
        {
            return Regex.Replace(input, _replacePattern, match =>
            {
                string leadingSpaces = match.Groups[1].Value;
                string pragmaType = match.Groups[2].Value;
                string keywords = match.Groups[3].Value;

                if (keywords != _keywords)
                    return input;

                string replacement;
                if (pragmaType.StartsWith("shader_feature") && _alwaysIncluded)
                    replacement = $"#pragma multi_compile{pragmaType.Substring(14)} {keywords}";
                else if (pragmaType.StartsWith("multi_compile") && !_alwaysIncluded)
                    replacement = $"#pragma shader_feature{pragmaType.Substring(13)} {keywords}";
                else
                    return input;

                return string.Concat(leadingSpaces, replacement);
            }, RegexOptions.Singleline | RegexOptions.Compiled);
        }

        public void DrawEditor()
        {
            _alwaysIncluded = EditorGUILayout.Toggle(_guiContent, _alwaysIncluded);
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
