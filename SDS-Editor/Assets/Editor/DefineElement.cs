using SDS.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SDS.Editor
{
    public class DefineElement : VisualElement
    {
        public DefineElement (ScriptingDefineSymbolDataModel dataModel, VisualElement rootVisualElement)
        {
            VisualElement root = rootVisualElement;
            
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/DefineElement.uxml");
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/DefineElement.uss");
            
            VisualElement uxmlRoot = visualTree.CloneTree();
            root.Add(uxmlRoot);
            root.styleSheets.Add(styleSheet);
        }
    }
}