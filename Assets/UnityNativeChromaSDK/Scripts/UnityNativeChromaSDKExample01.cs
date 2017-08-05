//#define VERBOSE_LOGGING

using ChromaSDK;
using System.Collections.Generic;
using System.Text;
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
            AppendStatus("OpenAnimation {0} id={1}", animation, animationid);
            if (animationid >= 0)
            {
                _mLoadedAnimations[animation] = animationid;
            }
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
            int result = UnityNativeChromaSDK.PluginPlayAnimation(animationId);
            AppendStatus("PlayAnimation name={0} id={1} result={2}", animation, animationId, result);
        }
    }
    void CloseAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            int result = UnityNativeChromaSDK.PluginCloseAnimation(animationId);
            AppendStatus("CloseAnimation name={0} id={1} result={2}", animation, animationId, result);
            if (_mLoadedAnimations.ContainsKey(animation))
            {
                _mLoadedAnimations.Remove(animation);
            }
        }
    }
    void EditAnimation(string animation)
    {
        string path = GetPath(animation);
        int result = UnityNativeChromaSDK.EditAnimation(path);
        AppendStatus("EditAnimation name={0} result={1}", animation, result);
    }
    void StopAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            int result = UnityNativeChromaSDK.PluginStopAnimation(animationId);
            AppendStatus("StopAnimation id={0} result={1}", animationId, result);
        }
    }   
    private void OnGUI()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
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
                PlayAnimation(animation);
            }
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("STOP", GUILayout.Height(30)))
        {
            ClearStatus();
            foreach (string animation in _mAnimations)
            {
                StopAnimation(animation);
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
#if VERBOSE_LOGGING
            if (GUILayout.Button("Close", GUILayout.Height(30)))
            {
                CloseAnimation(animation);
            }
#endif
            if (GUILayout.Button("Edit", GUILayout.Height(30)))
            {
                EditAnimation(animation);
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
    private void Init()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        if (!isInitialized)
        {
            int result = UnityNativeChromaSDK.PluginInit();
            ClearStatus();
            AppendStatus("Status: Init result={0}", result);
        }
    }
    void Uninit()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        if (isInitialized)
        {
            int result = UnityNativeChromaSDK.PluginUninit();
            ClearStatus();
            AppendStatus("Status: Unit result={0}", result);
        }
        _mLoadedAnimations.Clear();
    }

    private void Awake()
    {
        Init();
    }

    private void OnApplicationQuit()
    {
        Uninit();
    }
#endif
        }
