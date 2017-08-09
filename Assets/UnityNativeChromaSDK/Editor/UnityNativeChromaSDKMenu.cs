using ChromaSDK;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UnityNativeChromaSDKMenu : MonoBehaviour
{
    private const int VERSION = 1;
    private const string KEY_SAVE_PATH = "CHROMA_SDK_SAVE_PATH";

    [MenuItem("Assets/ChromaSDK/Open Docs")]
    private static void OpenDocs()
    {
        Application.OpenURL("https://github.com/RazerOfficial/UnityNativeChromaSDK");
    }

    [MenuItem("Assets/ChromaSDK/Create Chroma Animation")]
    private static void CreateAnimation()
    {
        string path = Application.streamingAssetsPath;
        if (EditorPrefs.HasKey(KEY_SAVE_PATH))
        {
            path = EditorPrefs.GetString(KEY_SAVE_PATH);
        }
        if (string.IsNullOrEmpty(path))
        {
            path = Application.streamingAssetsPath;
        }
        path = EditorUtility.SaveFilePanel("Chroma Animation", path, "Animation", "chroma");
        if (!string.IsNullOrEmpty(path))
        {
            EditorPrefs.SetString(KEY_SAVE_PATH, path);
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    //version
                    bw.Write((int)VERSION);
                    //devicetype
                    bw.Write((int)0);
                    //device
                    bw.Write((int)0);
                    //framecount
                    bw.Write((int)0);
                    bw.Flush();
                }
            }
            UnityNativeChromaSDK.EditAnimation(path);
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
                    UnityNativeChromaSDK.EditAnimation(path);
                }
            }
        }

    }
}
