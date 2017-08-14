using ChromaSDK;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnityNativeChromaSDKMenu : MonoBehaviour
{
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
            UnityNativeChromaSDK.CreateAnimation(path, UnityNativeChromaSDK.Device.ChromaLink);
            UnityNativeChromaSDK.PluginEditAnimation(path);
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
                FileInfo fi = new FileInfo(path);
                //Debug.Log(fi.Extension);
                if (fi.Extension == ".chroma")
                {
                    UnityNativeChromaSDK.PluginEditAnimation(path);
                }
            }
        }

    }
}
