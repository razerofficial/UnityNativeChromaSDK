using ChromaSDK;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnityNativeChromaSDKMenu : MonoBehaviour
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private const int VERSION = 1;

    [MenuItem("Assets/ChromaSDK/Open Docs")]
    private static void OpenDocs()
    {
        Application.OpenURL("https://github.com/RazerOfficial/UnityNativeChromaSDK");
    }

    [MenuItem("Assets/ChromaSDK/Create Chroma Animation")]
    private static void CreateAnimation()
    {
        string path = Application.streamingAssetsPath;
        path = EditorUtility.SaveFilePanel("Chroma Animation", path, "Animation", "chroma");
        if (!string.IsNullOrEmpty(path))
        {
            string animation = Path.GetFileName(path);
            UnityNativeChromaSDK.CreateAnimation(animation, UnityNativeChromaSDK.Device.ChromaLink);
            UnityNativeChromaSDK.EditAnimation(animation);
            AssetDatabase.Refresh();
        }
    }

    [MenuItem("Assets/ChromaSDK/Edit Chroma Animation")]
    private static void EditAnimation()
    {
        Object activeObject = Selection.activeObject;
        if (activeObject)
        {
            string path = AssetDatabase.GetAssetPath(activeObject);
            if (!string.IsNullOrEmpty(path))
            {
                string animation = Path.GetFileName(path);
                UnityNativeChromaSDK.EditAnimation(animation);
            }
        }

    }
#endif
}
