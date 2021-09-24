using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Story", order = 2)]
public class StoryScriptableObject : ScriptableObject {
    [Serializable]
    public class Text
    {
        /// <summary>
        /// 화자 이름
        /// </summary>
        public string Speaker;

        /// <summary>
        /// 내용
        /// </summary>
        public string Content;

        public Sprite Image;
    }

    public Text[] Texts;
}

#if UNITY_EDITOR
public class TextScriptableObjectPostprocessor : AssetPostprocessor {
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
        foreach (string str in importedAssets) {
            if (str.IndexOf("_story.csv") != -1) {
                TextAsset data = AssetDatabase.LoadAssetAtPath<TextAsset>(str);
                string assetfile = str.Replace(".csv", ".asset");
                StoryScriptableObject gm = AssetDatabase.LoadAssetAtPath<StoryScriptableObject>(assetfile);
                if (gm == null) {
                    gm = new StoryScriptableObject();
                    AssetDatabase.CreateAsset(gm, assetfile);
                }

                gm.Texts = CSVSerializer.Deserialize<StoryScriptableObject.Text>(data.text);

                EditorUtility.SetDirty(gm);
                AssetDatabase.SaveAssets();
#if DEBUG_LOG || UNITY_EDITOR
                Debug.Log("Reimported Asset: " + str);
#endif
            }
        }
    }
}
#endif