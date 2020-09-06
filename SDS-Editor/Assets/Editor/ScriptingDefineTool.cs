using System;
using System.Collections.Generic;
using System.Linq;
using SDS.Editor.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace SDS.Editor
{
    public class ScriptingDefineTool : EditorWindow
    {
        private List<ScriptingDefineSymbolDataModel> _savedDefines;
        private List<DefineElement> _defineElements = new List<DefineElement>();
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
            
            ConnectEvents(root);
            UpdateList();
            
        }

        private void ConnectEvents(VisualElement root)
        {
            var applyButton = root.Q<Button>("Apply");
            var addNew = root.Q<Button>("AddNew");
            var removeAll = root.Q<Button>("RemoveAll");

            applyButton.clicked += ApplyDefines;
            addNew.clicked += () =>
            {
                CreateNewDefine();
                UpdateList();
            };
            removeAll.clicked += DeleteAllDefines;
        }

        private void OnGUI()
        {
            rootVisualElement.Q<VisualElement>("Container").style.height = new StyleLength(position.height);
        }

        private List<ScriptingDefineSymbolDataModel> LoadDefines()
        {
            var defines = FileHelper.GetAllScriptablesOfTypeFromPath<ScriptingDefineSymbolDataModel>("Assets/Editor/Data");
            return defines.ToList();
        }

        private void UpdateList()
        {
            _savedDefines = LoadDefines();
            
            if (_savedDefines == null || _savedDefines.Count == 0 && _defineElements.Count == 0)
            {
                CreateNewDefine();
            }
            else
            {
                foreach (var define in _savedDefines)
                {
                    CreateNewDefine(define);
                }
            }
        }

        private void ApplyDefines()
        {
            foreach (var define in _savedDefines)
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

        private void CreateNewDefine()
        {
            var dataModel = CreateInstance<ScriptingDefineSymbolDataModel>();
            var element = new DefineElement(dataModel, _listContainer);
            _defineElements.Add(element);
        }

        private void CreateNewDefine(ScriptingDefineSymbolDataModel data)
        {
            var element = new DefineElement(data, _listContainer);
            _defineElements.Add(element);
        }

        private void DeleteAllDefines()
        {
            foreach (var define in _savedDefines)
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(define));
            }
            _savedDefines.Clear();
            _defineElements.Clear();
            
            _listContainer.Clear();
            UpdateList();
        }
    }
}