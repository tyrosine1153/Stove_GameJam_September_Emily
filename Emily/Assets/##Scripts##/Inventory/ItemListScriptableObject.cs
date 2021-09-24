using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemList", order = 2)]
public class ItemListScriptableObject : ScriptableObject
{
    public Item[] items;
}

#if UNITY_EDITOR
public class ItemScriptableObjectPostprocessor : AssetPostprocessor {
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
        foreach (string str in importedAssets) {
            if (str.IndexOf("_item_list.csv") != -1) {
                TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                string assetfile = str.Replace(".csv", ".asset");
                var obj = AssetDatabase.LoadAssetAtPath<ItemListScriptableObject>(assetfile);
                if (obj == null) {
                    obj = new ItemListScriptableObject();
                    AssetDatabase.CreateAsset(obj, assetfile);
                }

                obj.items = CSVSerializer.Deserialize<Item>(data.text);

                EditorUtility.SetDirty(obj);
                AssetDatabase.SaveAssets();
#if DEBUG_LOG || UNITY_EDITOR
                Debug.Log("Reimported Asset: " + str);
#endif
            }
        }
    }
}
#endif