//#define VERBOSE_LOGGING

using ChromaSDK;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
#if !UNITY_3 && !UNITY_3_0 && !UNITY_3_1 && !UNITY_3_2 && !UNITY_3_3 && !UNITY_3_4 && !UNITY_3_5
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
    bool UseLogging()
    {
#if VERBOSE_LOGGING
        return true;
#else
        return false;
#endif
    }
    private StringBuilder _mStatus = new StringBuilder();
    void ClearStatus()
    {
        if (UseLogging())
        {
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
        }
    }
    void AppendStatus(string format, params object[] args)
    {
        if (UseLogging())
        {
            _mStatus.AppendFormat(format, args);
            _mStatus.AppendLine();
        }
    }  
    private void OnGUI()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Load Scene 2"))
        {
#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
            Application.LoadLevel(1);
#else
            SceneManager.LoadScene(1);
#endif
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (UseLogging())
        {
            GUILayout.Label(_mStatus.ToString());
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        GUI.enabled = !isInitialized;
        GUI.enabled = isInitialized;
        if (GUILayout.Button("PLAY", GUILayout.Height(30)))
        {
            ClearStatus();
            foreach (string animation in _mAnimations)
            {
                int animationId = UnityNativeChromaSDK.GetAnimation(animation);
                int result = UnityNativeChromaSDK.PlayAnimation(animation);
                AppendStatus("PlayAnimation name={0} id={1} result={2}", animation, animationId, result);
            }
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("STOP", GUILayout.Height(30)))
        {
            ClearStatus();
            foreach (string animation in _mAnimations)
            {
                int animationId = UnityNativeChromaSDK.GetAnimation(animation);
                int result = UnityNativeChromaSDK.StopAnimation(animation);
                AppendStatus("StopAnimation name={0} id={1} result={2}", animation, animationId, result);
            }
        }
#if VERBOSE_LOGGING
        if (GUILayout.Button("CLOSE", GUILayout.Height(30)))
        {
            ClearStatus();
            foreach (string animation in _mAnimations)
            {
                CloseAnimation(animation);
            }
        }
#endif
        GUI.enabled = true;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        foreach (string animation in _mAnimations)
        {
            int animationId = UnityNativeChromaSDK.GetAnimation(animation);
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label(animation);
            GUI.enabled = isInitialized;
            if (GUILayout.Button("Play", GUILayout.Height(30)))
            {
                int result = UnityNativeChromaSDK.PlayAnimation(animation);
                AppendStatus("PlayAnimation name={0} id={1} result={2}", animation, animationId, result);
            }
            if (GUILayout.Button("Stop", GUILayout.Height(30)))
            {
                int result = UnityNativeChromaSDK.StopAnimation(animation);
                AppendStatus("StopAnimation name={0} id={1} result={2}", animation, animationId, result);
            }
#if VERBOSE_LOGGING
            if (GUILayout.Button("Close", GUILayout.Height(30)))
            {
                int result = UnityNativeChromaSDK.CloseAnimation(animation);
                AppendStatus("CloseAnimation name={0} id={1} result={2}", animation, animationId, result);
            }
#endif
            if (GUILayout.Button("Edit", GUILayout.Height(30)))
            {
                int result = UnityNativeChromaSDK.EditAnimation(animation);
                AppendStatus("EditAnimation name={0} result={1}", animation, result);
            }
            GUI.enabled = true;
            GUILayout.Label(string.Format("({0}) {1}", UnityNativeChromaSDK.GetFrameCount(animation), UnityNativeChromaSDK.GetDevice(animation)));
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
        int result = UnityNativeChromaSDK.Init();
        AppendStatus("Status: Init result={0}", result);
    }

    private void OnApplicationQuit()
    {
        int result = UnityNativeChromaSDK.Uninit();
        AppendStatus("Status: Uninit result={0}", result);
    }
#endif
}
