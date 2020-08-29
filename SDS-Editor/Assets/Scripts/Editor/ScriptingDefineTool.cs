using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SDS.Editor
{
    public class ScriptingDefineTool : EditorWindow
    {
        
        [MenuItem("Tools/ScriptingDefineTool")]
        public static void ShowExample()
        {
            ScriptingDefineTool wnd = GetWindow<ScriptingDefineTool>();
            wnd.minSize = new Vector2(400, 300);
            wnd.titleContent = new GUIContent("ScriptingDefineTool");
        }

        public void OnEnable()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;
            
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/Editor/ScriptingDefineTool.uxml");
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/ScriptingDefineTool.uss");
            
            VisualElement uxmlRoot = visualTree.CloneTree();
            root.Add(uxmlRoot);
            root.styleSheets.Add(styleSheet);
        }

        private void OnGUI()
        {
            rootVisualElement.Q<VisualElement>("Container").style.height = new StyleLength(position.height);
        }
    }
}