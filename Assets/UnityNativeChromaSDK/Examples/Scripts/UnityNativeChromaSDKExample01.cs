using ChromaSDK;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
#if !UNITY_3 && !UNITY_3_0 && !UNITY_3_1 && !UNITY_3_2 && !UNITY_3_3 && !UNITY_3_4 && !UNITY_3_5 && !UNITY_4 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5 && !UNITY_4_6 && !UNITY_4_7
using UnityEngine.SceneManagement;
#endif

public class UnityNativeChromaSDKExample01 : MonoBehaviour
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    readonly string[] _mAnimations =
    {
        "Random_ChromaLink.chroma",
        "Random_Headset.chroma",
        "Random_Keyboard.chroma",
        "Random_Keypad.chroma",
        "Random_Mouse.chroma",
        "Random_Mousepad.chroma",
    };
    private void OnGUI()
    {
        if (!UnityNativeChromaSDK.IsPlatformSupported())
        {
            GUILayout.BeginVertical(GUILayout.Height(Screen.height));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label("The ChromaSDK is not supported on this platform!");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            return;
        }

        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Load Scene 2"))
        {
#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            Application.LoadLevel(1);
#else
            SceneManager.LoadScene(1);
#endif
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        GUI.enabled = isInitialized;
        if (GUILayout.Button("PLAY", GUILayout.Height(30)))
        {
            UnityNativeChromaSDK.PlayComposite("Random", false);
        }
        if (GUILayout.Button("LOOP", GUILayout.Height(30)))
        {
            UnityNativeChromaSDK.PlayComposite("Random", true);
        }
        if (GUILayout.Button("STOP", GUILayout.Height(30)))
        {
            UnityNativeChromaSDK.StopComposite("Random");
        }
        if (GUILayout.Button("RELOAD", GUILayout.Height(30)))
        {
            foreach (string animation in _mAnimations)
            {
                UnityNativeChromaSDK.CloseAnimationName(animation);
            }
        }
#endif
        GUI.enabled = true;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        foreach (string animation in _mAnimations)
        {
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label(string.Format("{0}:", UnityNativeChromaSDK.GetDevice(animation)));
            GUILayout.Label(animation);
            GUI.enabled = isInitialized;
            if (GUILayout.Button("Play", GUILayout.Height(30)))
            {
                UnityNativeChromaSDK.PlayAnimationName(animation);
            }
            if (GUILayout.Button("Loop", GUILayout.Height(30)))
            {
                UnityNativeChromaSDK.PlayAnimationName(animation, true);
            }
            if (GUILayout.Button("Stop", GUILayout.Height(30)))
            {
                UnityNativeChromaSDK.StopAnimationName(animation);
            }
            if (GUILayout.Button("Reload", GUILayout.Height(30)))
            {
                UnityNativeChromaSDK.CloseAnimationName(animation);
            }
            if (GUILayout.Button("Edit", GUILayout.Height(30)))
            {
                UnityNativeChromaSDK.EditAnimation(animation);
            }
            GUI.enabled = true;
            GUILayout.Label(string.Format("({0} frames)", UnityNativeChromaSDK.GetFrameCountName(animation)));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("QUIT", GUILayout.Height(30)))
        {
            Application.Quit();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }

    private void Awake()
    {
        UnityNativeChromaSDK.Init();
    }

    private void OnApplicationQuit()
    {
        UnityNativeChromaSDK.Uninit();
    }
}
