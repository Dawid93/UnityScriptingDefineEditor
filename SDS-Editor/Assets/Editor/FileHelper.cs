using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SDS.Editor
{
    public static class FileHelper
    {
        public static ScriptableObject[] GetAllScriptablesFromPath(string path)
        {
            
            var files = System.IO.Directory.GetFiles(path, "*.asset");
            ScriptableObject[] so = new ScriptableObject[files.Length];

            for (int i = 0; i < files.Length; i++)
                so[i] = AssetDatabase.LoadAssetAtPath<ScriptableObject>(files[i]);

            return so;
        }

        public static T[] GetAllScriptablesOfTypeFromPath<T>(string path)
        {
            var assets = GetAllScriptablesFromPath(path);
            return assets.OfType<T>().ToArray();
        }
    }
}
