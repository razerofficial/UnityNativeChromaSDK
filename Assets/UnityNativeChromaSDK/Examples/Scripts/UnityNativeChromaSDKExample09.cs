using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKExample09 : MonoBehaviour
{
    private const string ANIMATION = "Random_Keyboard.chroma";

    private string _mStrFrame = "10";

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

        GUI.enabled = UnityNativeChromaSDK.PluginIsInitialized();

        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();

        GUILayout.Label(string.Format("Frame Count: {0}",
            UnityNativeChromaSDK.GetFrameCountName(ANIMATION)));

        GUILayout.Label(string.Format("Current Frame: {0}",
            UnityNativeChromaSDK.GetCurrentFrameName(ANIMATION)));

        GUILayout.Label(string.Format("Is Paused: {0}",
            UnityNativeChromaSDK.IsAnimationPausedName(ANIMATION)));

        GUILayout.Label(string.Format("Has Loop: {0}",
            UnityNativeChromaSDK.HasAnimationLoopName(ANIMATION)));

        _mStrFrame = GUILayout.TextField(_mStrFrame, GUILayout.Width(150));
        if (GUILayout.Button("Set Frame", GUILayout.Width(200), GUILayout.Height(60)))
        {
            int frameId;
            if (int.TryParse(_mStrFrame, out frameId))
            {
                _mStrFrame = frameId.ToString();
                UnityNativeChromaSDK.SetCurrentFrameName(ANIMATION, frameId);
            }
        }

        GUILayout.FlexibleSpace();

        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Play", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.PlayAnimationName(ANIMATION, false);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUI.enabled = UnityNativeChromaSDK.IsPlaying(ANIMATION);

        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Pause", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.PauseAnimationName(ANIMATION);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Resume", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.ResumeAnimationName(ANIMATION, false);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Resume Loop", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.ResumeAnimationName(ANIMATION, true);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        GUI.enabled = true;
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
