using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKExample08 : MonoBehaviour
{
    private const string SOURCE_ANIMATION = "Fire_Keyboard.chroma";
    private const string TARGET_ANIMATION = "BaseLayer_Keyboard.chroma";

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

        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Show Hotkeys", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.CloseAnimationName(TARGET_ANIMATION);

            // copy colors from another animation
            UnityNativeChromaSDK.CopyKeysColorAllFramesName(SOURCE_ANIMATION, TARGET_ANIMATION,
                new int[] {
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_W,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_A,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_S,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_D,
                    (int)UnityNativeChromaSDK.Keyboard.RZLED.RZLED_LOGO});

            // set static colors
            UnityNativeChromaSDK.SetKeysColorAllFramesName(TARGET_ANIMATION,
                new int[] {
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_I,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_J,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_K,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_L,
                    (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ENTER},
                Color.red);

            UnityNativeChromaSDK.PlayAnimationName(TARGET_ANIMATION, true);
        }

        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Hide Hotkeys", GUILayout.Height(60)))
        {
            UnityNativeChromaSDK.CloseAnimationName(TARGET_ANIMATION);
            UnityNativeChromaSDK.PlayAnimationName(TARGET_ANIMATION, true);
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
