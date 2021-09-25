using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Story", order = 2)]
public class StoryScriptableObject : ScriptableObject 
{
    public enum Place
    {
        None = 0,
        LivingRoom,
        FruitPath,
        ReedField
    }

    public enum Character
    {
        None = 0,
        Emily,
        Rose,
        RedWoman,
        Gardener
    }
    
    [Serializable]
    public class Text
    {
        /// <summary>
        /// 화자 이름
        /// </summary>
        public string Speaker;

        /// <summary>
        /// 내용
        /// 1개 이상일 경우 랜덤하게 설정된다
        /// </summary>
        public string[] Content;

        public Sprite Image;
        
        public Place Place;
        public Character LeftCharacter;
        public Character RightCharacter;
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