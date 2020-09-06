using System;
using UnityEngine;

namespace SDS.Editor.Data
{
    [Flags]
    public enum Platforms
    {
        WindowsStandalone = 1,
        MacStandalone = 2,
        LinuxStandalone = 4,
        Android = 8,
        Ios = 16,
        WebGL = 32
        
    }
    [CreateAssetMenu(fileName = "ScriptingDefine")]
    public class ScriptingDefineSymbolDataModel : ScriptableObject
    {
        public string ScriptingDefineSymbol { get; private set; }
        public Platforms Platforms { get; private set; }
        public bool EnableScriptingDefineSymbol { get; private set; }

        [SerializeField] private string scriptingDefineSymbol;
        [SerializeField] private Platforms platforms;
        [SerializeField] private bool enableScriptingDefineSymbol;

        public void SetScriptingDefineSymbol(string symbol)
        {
            scriptingDefineSymbol = symbol;
        }
    }
}
