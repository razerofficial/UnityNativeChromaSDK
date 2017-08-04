using ChromaSDK;
using System.Collections.Generic;
using UnityEngine;

public class UnityNativeChromaSDKExample01 : MonoBehaviour
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    readonly string[] _mAnimations =
    {
        "RandomChromaLinkEffect.chroma",
        "RandomHeadsetEffect.chroma",
        "RandomKeyboardEffect.chroma",
        "RandomKeypadEffect.chroma",
        "RandomMouseEffect.chroma",
        "RandomMousepadEffect.chroma",
    };
    Dictionary<string, int> _mLoadedAnimations = new Dictionary<string, int>();
    string GetPath(string animation)
    {
        return string.Format("{0}/{1}", Application.streamingAssetsPath, animation);
    }
    int GetAnimation(string animation)
    {
        string path = GetPath(animation);
        int animationid;
        if (!_mLoadedAnimations.ContainsKey(animation))
        {
            animationid = UnityNativeChromaSDK.OpenAnimation(path);
            _mLoadedAnimations[animation] = animationid;
        }
        else
        {
            animationid = _mLoadedAnimations[animation];
        }
        return animationid;
    }
    void PlayAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            UnityNativeChromaSDK.PluginPlayAnimation(animationId);
        }
    }
    void StopAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            UnityNativeChromaSDK.PluginStopAnimation(animationId);
        }
    }   
    private void OnGUI()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        GUI.enabled = !isInitialized;
        if (GUILayout.Button("Init", GUILayout.Height(30)))
        {
            UnityNativeChromaSDK.PluginInit();
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("PLAY", GUILayout.Height(30)))
        {
            foreach (string animation in _mAnimations)
            {
                PlayAnimation(animation);
            }
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("STOP", GUILayout.Height(30)))
        {
            foreach (string animation in _mAnimations)
            {
                StopAnimation(animation);
            }
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("Uninit", GUILayout.Height(30)))
        {
            UnityNativeChromaSDK.PluginUninit();
            _mLoadedAnimations.Clear();
        }
        GUI.enabled = true;
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        foreach (string animation in _mAnimations)
        {
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label(animation);
            GUI.enabled = isInitialized;
            if (GUILayout.Button("Play", GUILayout.Height(30)))
            {
                PlayAnimation(animation);
            }
            if (GUILayout.Button("Stop", GUILayout.Height(30)))
            {
                StopAnimation(animation);
            }
            GUI.enabled = true;
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
        UnityNativeChromaSDK.PluginInit();
    }

    private void OnApplicationQuit()
    {
        UnityNativeChromaSDK.PluginUninit();
    }
#endif
}
