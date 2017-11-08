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

#if !UNITY_3 && !UNITY_3_0 && !UNITY_3_1 && !UNITY_3_2 && !UNITY_3_3 && !UNITY_3_4 && !UNITY_3_5
    [MenuItem("Window/ChromaSDK/Set DLL Platforms")]
    private static void SetDLLPlatforms()
    {
        FileInfo fi = new FileInfo("Assets/Plugins/UnityNativeChromaSDK3.dll");
        if (fi.Exists)
        {
            fi.Delete();
        }

        fi = new FileInfo("Assets/Plugins/UnityNativeChromaSDK3.dll.meta");
        if (fi.Exists)
        {
            fi.Delete();
        }

        const string DLL_64 = "Assets/Plugins/x64/UnityNativeChromaSDK.dll";
        const string DLL_32 = "Assets/Plugins/x86/UnityNativeChromaSDK.dll";

        //todo automate setting platforms

        AssetDatabase.ImportAsset(DLL_64);
        AssetDatabase.ImportAsset(DLL_32);

        AssetDatabase.ImportAsset("Assets/UnityNativeChromaSDK/Editor/ChromaCaptureWindow.cs");
        AssetDatabase.ImportAsset("Assets/UnityNativeChromaSDK/Editor/ChromaMaterialWindow.cs");

        AssetDatabase.Refresh();
    }
#endif

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
