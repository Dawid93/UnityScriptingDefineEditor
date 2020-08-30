using System;
using System.Collections.Generic;
using System.Linq;
using SDS.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SDS.Editor
{
    public class ScriptingDefineTool : EditorWindow
    {
        private List<ScriptingDefineSymbolDataModel> _defines;
        private VisualElement _listContainer;
        
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
            
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/ScriptingDefineTool.uxml");
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/ScriptingDefineTool.uss");
            
            VisualElement uxmlRoot = visualTree.CloneTree();
            root.Add(uxmlRoot);
            root.styleSheets.Add(styleSheet);

            _listContainer = root.Q<ListView>("ScriptingDefineSymbolList");
            
            DefineElement element = new DefineElement(null, _listContainer);
            DefineElement element2 = new DefineElement(null, _listContainer);
        }

        private void OnGUI()
        {
            rootVisualElement.Q<VisualElement>("Container").style.height = new StyleLength(position.height);
        }

        private List<ScriptingDefineSymbolDataModel> LoadDefines()
        {
            var defines = AssetDatabase.LoadAllAssetsAtPath("Assets/Scripts/Data/").ToList();
            return defines.OfType<ScriptingDefineSymbolDataModel>().ToList();
        }

        private void PopulateList()
        {
            _defines = LoadDefines();
            if (_defines == null || _defines.Count == 0)
            {
                
            }
            else
            {
                
            }
        }

        private void ApplyDefines()
        {
            foreach (var define in _defines)
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.OSXPlayer:
                        break;
                    case RuntimePlatform.WindowsPlayer:
                        break;
                    case RuntimePlatform.IPhonePlayer:
                        break;
                    case RuntimePlatform.Android:
                        break;
                    case RuntimePlatform.LinuxPlayer:
                        break;
                    case RuntimePlatform.WebGLPlayer:
                        break;
                }
            }
        }
    }
}