using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKExample10 : MonoBehaviour
{
    private float _mBaseIntensity = 1;
    private float _mEffectIntensity = 1;
    private float _mHotkeyIntensity = 1;
    private int _mSelectedAnimation = 0;

    private void OnApplicationQuit()
    {
        string baseLayer = "EnvironmentSnow_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(baseLayer);

        UnityNativeChromaSDK.PluginClearAll();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Heal", GUILayout.Width(100), GUILayout.Height(40)))
        {
            _mSelectedAnimation = 0;
            ClickHeal();
        }

        if (GUILayout.Button("Damage", GUILayout.Width(100), GUILayout.Height(40)))
        {
            _mSelectedAnimation = 1;
            ClickDamage();
        }

        if (GUILayout.Button("Item Pickup", GUILayout.Width(100), GUILayout.Height(40)))
        {
            _mSelectedAnimation = 2;
            ClickItemPickup();
        }

        GUILayout.EndHorizontal();

        GUILayout.FlexibleSpace();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Base Intensity:");
        float baseIntensity = GUILayout.HorizontalSlider(_mBaseIntensity, 0f, 1f, GUILayout.Width(300));
        if (baseIntensity != _mBaseIntensity)
        {
            _mBaseIntensity = baseIntensity;
            ClickLastAnimation();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Effect Intensity:");
        float effectIntensity = GUILayout.HorizontalSlider(_mEffectIntensity, 0f, 1f, GUILayout.Width(300));
        if (effectIntensity != _mEffectIntensity)
        {
            _mEffectIntensity = effectIntensity;
            ClickLastAnimation();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Hotkey Intensity:");
        float hotkeyIntensity = GUILayout.HorizontalSlider(_mHotkeyIntensity, 0f, 1f, GUILayout.Width(300));
        if (hotkeyIntensity != _mHotkeyIntensity)
        {
            _mHotkeyIntensity = hotkeyIntensity;
            ClickLastAnimation();
        }
        GUILayout.EndHorizontal();
    }

    private void ClickHeal()
    {
        int[] keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZLED.RZLED_LOGO,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ESC,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Q,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_E
        };

        string baseLayer = "EnvironmentSnow_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(baseLayer);
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(baseLayer, 1.0f + 64.0f * _mBaseIntensity);

        string layer2 = "RingGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer2);
        // turn animation green
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer2, -127, 127, -127); //animation starts with 127,127,127 so adding -127,127,-127 results in 0,255,0 or green
        // set intensity
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(layer2, _mEffectIntensity);
        UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesName(layer2, baseLayer);

        string layer3 = "FadeInOutGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer3);
        // change color
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer3, 173 - 127, 255 - 127, 47 - 127);
        // set intensity
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(layer3, _mHotkeyIntensity);
        UnityNativeChromaSDK.CopyKeysColorAllFramesName(layer3, baseLayer, keys);

        keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_W,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_A,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_S,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_D
        };

        Color color = new Color(_mHotkeyIntensity * 1, _mHotkeyIntensity * 0.5f, 0);
        UnityNativeChromaSDK.SetKeysColorAllFramesName(baseLayer, keys, color);

        UnityNativeChromaSDK.PlayAnimationName(baseLayer, true);
    }

    private void ClickDamage()
    {
        int[] keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZLED.RZLED_LOGO,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ESC,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Q,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_E
        };

        string baseLayer = "EnvironmentSnow_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(baseLayer);
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(baseLayer, 1.0f + 64.0f * _mBaseIntensity);

        string layer2 = "RingGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer2);
        // turn animation red
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer2, 127, -127, -127); //animation starts with 127,127,127 so adding 127,-127,-127 results in 255,0,0 or red
        // set intensity
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(layer2, _mEffectIntensity);
        UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesName(layer2, baseLayer);

        string layer3 = "FadeInOutGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer3);
        // change color
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer3, 220 - 127, 20 - 127, 60 - 127);
        // set intensity
        UnityNativeChromaSDK.CopyKeysColorAllFramesName(layer3, baseLayer, keys);

        keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_W,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_A,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_S,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_D
        };

        Color color = new Color(_mHotkeyIntensity * 1, _mHotkeyIntensity * 0.5f, 0);
        UnityNativeChromaSDK.SetKeysColorAllFramesName(baseLayer, keys, color);

        UnityNativeChromaSDK.PlayAnimationName(baseLayer, true);
    }

    private void ClickItemPickup()
    {
        int[] keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZLED.RZLED_LOGO,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ESC,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Q,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_E
        };

        string baseLayer = "EnvironmentSnow_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(baseLayer);
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(baseLayer, 1.0f + 64.0f * _mBaseIntensity);

        string layer2 = "RingGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer2);
        // turn animation blue
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer2, -127, -127, 127); //animation starts with 127,127,127 so adding -127,-127,127 results in 0,0,255 or blue
        // set intensity
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(layer2, _mEffectIntensity);
        UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesName(layer2, baseLayer);

        string layer3 = "FadeInOutGray_Keyboard.chroma";
        UnityNativeChromaSDK.CloseAnimationName(layer3);
        // change color
        UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(layer3, 64 - 127, 224 - 127, 208 - 127);
        // set intensity
        UnityNativeChromaSDK.MultiplyIntensityAllFramesName(layer3, _mHotkeyIntensity);
        UnityNativeChromaSDK.CopyKeysColorAllFramesName(layer3, baseLayer, keys);

        keys = new int[]
        {
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_W,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_A,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_S,
            (int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_D
        };

        Color color = new Color(_mHotkeyIntensity * 1, _mHotkeyIntensity * 0.5f, 0);
        UnityNativeChromaSDK.SetKeysColorAllFramesName(baseLayer, keys, color);

        UnityNativeChromaSDK.PlayAnimationName(baseLayer, true);
    }

    private void ClickLastAnimation()
    {
        switch (_mSelectedAnimation)
        {
            case 0:
                ClickHeal();
                break;
            case 1:
                ClickDamage();
                break;
            case 2:
                ClickItemPickup();
                break;
        }
    }
}
