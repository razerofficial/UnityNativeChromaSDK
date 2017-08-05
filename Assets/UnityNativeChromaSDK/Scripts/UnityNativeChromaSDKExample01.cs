using ChromaSDK;
using System.Collections;
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
    private StringBuilder _mStatus = new StringBuilder();
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
            _mStatus.AppendFormat("OpenAnimation {0} id={1}", animation, animationid);
            _mStatus.AppendLine();
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
            _mStatus.AppendFormat("PlayAnimation name={0} id={1} result={2}", animation, animationId, result);
            _mStatus.AppendLine();
        }
    }
    void CloseAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            int result = UnityNativeChromaSDK.PluginCloseAnimation(animationId);
            _mStatus.AppendFormat("CloseAnimation name={0} id={1} result={2}", animation, animationId, result);
            _mStatus.AppendLine();
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
        _mStatus.AppendFormat("EditAnimation name={0} result={1}", animation, result);
        _mStatus.AppendLine();
    }
    void StopAnimation(string animation)
    {
        int animationId = GetAnimation(animation);
        if (animationId >= 0)
        {
            int result = UnityNativeChromaSDK.PluginStopAnimation(animationId);
            _mStatus.AppendFormat("StopAnimation id={0} result={1}", animationId, result);
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
        GUILayout.Label(_mStatus.ToString());
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        GUI.enabled = !isInitialized;
        GUI.enabled = isInitialized;
        if (GUILayout.Button("PLAY", GUILayout.Height(30)))
        {
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
            foreach (string animation in _mAnimations)
            {
                PlayAnimation(animation);
            }
        }
        GUI.enabled = isInitialized;
        if (GUILayout.Button("STOP", GUILayout.Height(30)))
        {
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
            foreach (string animation in _mAnimations)
            {
                StopAnimation(animation);
            }
        }
        if (GUILayout.Button("CLOSE", GUILayout.Height(30)))
        {
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
            foreach (string animation in _mAnimations)
            {
                CloseAnimation(animation);
            }
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
            if (GUILayout.Button("Close", GUILayout.Height(30)))
            {
                CloseAnimation(animation);
            }
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
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
            _mStatus.AppendFormat("Status: Init result={0}", result);
            _mStatus.AppendLine();
        }
    }
    void Uninit()
    {
        bool isInitialized = UnityNativeChromaSDK.PluginIsInitialized();
        if (isInitialized)
        {
            int result = UnityNativeChromaSDK.PluginUninit();
            if (_mStatus.Length > 0)
            {
                _mStatus.Remove(0, _mStatus.Length);
            }
            _mStatus.AppendFormat("Status: Unit result={0}", result);
            _mStatus.AppendLine();
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
