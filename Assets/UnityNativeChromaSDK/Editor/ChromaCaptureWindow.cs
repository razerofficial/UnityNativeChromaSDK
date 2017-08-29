#define SHOW_LAYOUT_IN_SCENE_VIEW
//#define SHOW_TEMP_TEXTURE

using ChromaSDK;
using Eric5h5;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;
using Type = System.Type;

class ChromaCaptureWindow : EditorWindow
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private const string KEY_ANIMATION = "ChromaSDKAnimationPath";
    private const string KEY_CAMERA = "ChromaSDKCameraPath";
    private const string KEY_PARTICLE = "ChromaSDKParticleSystemPath";
    private const string KEY_AUTO_ALIGN = "ChromaSDKAutoAlign";
    private const string KEY_LAYOUT = "ChromaSDKLayout";
    private const string KEY_MASK = "ChromaSDKMask";

    private readonly string _mVersionString = string.Format("{0}", UnityNativeChromaSDK.GetVersion());

    private const int RENDER_TEXTURE_SIZE = 256;

    private string _mAnimation = null;
    private Camera _mRenderCamera = null;
    private RenderTexture _mRenderTexture = null;
    private Texture2D _mTempTexture = null;
    private Object _mMask = null;
    private float _mInterval = 0.1f;
    private ParticleSystem _mParticleSystem = null;
    private bool _mCapturing = false;
    private DateTime _mTimerCapture = DateTime.MinValue;
    private int _mCaptureIndex = 0;
    private float _mOverrideTime = 0.1f;

    private static Texture2D _sTextureClear = null;

    private static Texture2D _sChromaLinkTexture = null;
    private static Texture2D _sKeyboardTexture = null;
    private static Texture2D _sMouseTexture = null;
    private static Texture2D _sMousepadTexture = null;

    private bool _mAutoAlignWithView = false;
    private DateTime _mTimerAlign = DateTime.MinValue;

    private bool _mToggleLayout = false;
    private UnityNativeChromaSDK.Device _mDeviceLayout = UnityNativeChromaSDK.Device.Keyboard;
    private Color _mColorLayout = Color.white;

    enum Modes
    {
        Normal,
        Composite,
        Playback
    }

    private Modes _mMode = Modes.Normal;

    private string _mLastPlaybackName = string.Empty;

    private struct Point
    {
        public Point(int x, int y)
        {
            _mX = x;
            _mY = y;
        }
        public int _mX;
        public int _mY;

    }
    private Dictionary<int, Point> _mChromaLinkTextureMapping = new Dictionary<int, Point>();
    private Dictionary<int, Point> _mKeyboardTextureMapping = new Dictionary<int, Point>();
    private Dictionary<int, Point> _mMouseTextureMapping = new Dictionary<int, Point>();
    private Dictionary<int, Point> _mMousepadTextureMapping = new Dictionary<int, Point>();

    [MenuItem("Window/ChromaSDK/Open Capture Chroma Window")]
    private static void OpenPanel()
    {
        ChromaCaptureWindow window = GetWindow<ChromaCaptureWindow>();
        if (null == window)
        {
            window.name = "Capture Chroma Window";
        }
    }

    string GetAnimationName(string animationName)
    {
        return UnityNativeChromaSDK.GetAnimationNameWithExtension(animationName);
    }
    string GetAnimationName()
    {
        return GetAnimationName(_mAnimation);
    }
    int GetAnimation(string animationName)
    {
        if (string.IsNullOrEmpty(animationName))
        {
            return -1;
        }
        return UnityNativeChromaSDK.GetAnimation(animationName);
    }
    int GetAnimation()
    {
        return GetAnimation(GetAnimationName());
    }

    protected static void SetupBlankTexture()
    {
        if (null == _sTextureClear)
        {
            _sTextureClear = new Texture2D(1, 1, TextureFormat.RGB24, false);
            _sTextureClear.SetPixel(0, 0, Color.white);
            _sTextureClear.Apply();
        }
    }

    public static Texture2D GetBlankTexture()
    {
        SetupBlankTexture();
        return _sTextureClear;
    }

    private void DisplayRenderTexture(int y, int width, int height)
    {
        Rect rect = new Rect(0, y, width, height);
        Color oldColor = GUI.backgroundColor;
        Texture2D oldTexture = GUI.skin.box.normal.background;
        GUI.skin.box.normal.background = GetBlankTexture();
        const int border = 2;
        rect.width = width + 2 * border;
        rect.height = height + 2 * border;
        GUI.backgroundColor = Color.red;
        GUI.Box(rect, "");
        rect.width = width;
        rect.height = height;
        rect.x += border;
        rect.y += border;
        GUI.backgroundColor = Color.black;
        GUI.Box(rect, "");
        GUI.backgroundColor = oldColor;
        GUI.skin.box.normal.background = oldTexture;
        GUI.DrawTexture(rect, _mRenderTexture, ScaleMode.ScaleAndCrop, false);
    }

    void SetupTextureMapping()
    {
        _mChromaLinkTextureMapping.Clear();
        _mChromaLinkTextureMapping[0] = new Point(19, 127);
        _mChromaLinkTextureMapping[1] = new Point(73, 127);
        _mChromaLinkTextureMapping[2] = new Point(127, 127);
        _mChromaLinkTextureMapping[3] = new Point(181, 127);
        _mChromaLinkTextureMapping[4] = new Point(235, 127);


        _mKeyboardTextureMapping.Clear();
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_MACRO1] = new Point(12, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_MACRO2] = new Point(12, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_MACRO3] = new Point(12, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_MACRO4] = new Point(12, 56);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_MACRO5] = new Point(12, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ESC] = new Point(24, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F1] = new Point(49, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F2] = new Point(59, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F3] = new Point(70, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F4] = new Point(79, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F5] = new Point(91, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F6] = new Point(102, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F7] = new Point(113, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F8] = new Point(122, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F9] = new Point(134, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F10] = new Point(144, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F11] = new Point(154, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F12] = new Point(164, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_PRINTSCREEN] = new Point(176, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_SCROLL] = new Point(185, 14);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_PAUSE] = new Point(195, 14); //pause break
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_1] = new Point(23, 26); //~
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_1] = new Point(34, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_2] = new Point(44, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_3] = new Point(54, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_4] = new Point(64, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_5] = new Point(74, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_6] = new Point(84, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_7] = new Point(94, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_8] = new Point(104, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_9] = new Point(114, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_0] = new Point(124, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_2] = new Point(134, 26); //-
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_3] = new Point(143, 26); //=
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_BACKSPACE] = new Point(158, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_INSERT] = new Point(175, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_HOME] = new Point(186, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_PAGEUP] = new Point(196, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMLOCK] = new Point(208, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_DIVIDE] = new Point(218, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_MULTIPLY] = new Point(228, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_SUBTRACT] = new Point(238, 26);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_TAB] = new Point(26, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Q] = new Point(39, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_W] = new Point(49, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_E] = new Point(59, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_R] = new Point(69, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_T] = new Point(79, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Y] = new Point(89, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_U] = new Point(99, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_I] = new Point(109, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_O] = new Point(119, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_P] = new Point(129, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_4] = new Point(139, 36); //[
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_5] = new Point(148, 36); //]
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_6] = new Point(161, 36); //backslash
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_DELETE] = new Point(175, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_END] = new Point(186, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_PAGEDOWN] = new Point(195, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD7] = new Point(208, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD8] = new Point(218, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD9] = new Point(228, 36);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_ADD] = new Point(238, 42);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_CAPSLOCK] = new Point(27, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_A] = new Point(41, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_S] = new Point(51, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_D] = new Point(61, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_F] = new Point(71, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_G] = new Point(81, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_H] = new Point(91, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_J] = new Point(101, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_K] = new Point(111, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_L] = new Point(121, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_7] = new Point(131, 46); //;
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_8] = new Point(141, 46); //'
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_ENTER] = new Point(157, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD4] = new Point(208, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD5] = new Point(218, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD6] = new Point(228, 0);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_LSHIFT] = new Point(29, 56);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_Z] = new Point(46, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_X] = new Point(56, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_C] = new Point(66, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_V] = new Point(76, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_B] = new Point(86, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_N] = new Point(96, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_M] = new Point(106, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_9] = new Point(116, 46); //,
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_10] = new Point(126, 46); //.
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_OEM_11] = new Point(136, 46); // /
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_RSHIFT] = new Point(154, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_UP] = new Point(186, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD1] = new Point(208, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD2] = new Point(218, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD3] = new Point(228, 46);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_ENTER] = new Point(238, 60);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_LCTRL] = new Point(11, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_LWIN] = new Point(27, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_LALT] = new Point(39, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_SPACE] = new Point(88, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_RALT] = new Point(126, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_FN] = new Point(139, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_RMENU] = new Point(149, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_RCTRL] = new Point(161, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_LEFT] = new Point(176, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_DOWN] = new Point(186, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_RIGHT] = new Point(196, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD0] = new Point(213, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZKEY.RZKEY_NUMPAD_DECIMAL] = new Point(228, 66);
        _mKeyboardTextureMapping[(int)UnityNativeChromaSDK.Keyboard.RZLED.RZLED_LOGO] = new Point(124, 84);

        _mMouseTextureMapping.Clear();
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LOGO] = new Point(127, 167);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_BOTTOM1] = new Point(43, 237);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_BOTTOM2] = new Point(85, 237);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_BOTTOM3] = new Point(127, 237);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_BOTTOM4] = new Point(170, 237);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_BOTTOM5] = new Point(212, 237);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE1] = new Point(21, 41);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE2] = new Point(21, 70);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE3] = new Point(21, 96);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE4] = new Point(21, 123);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE5] = new Point(21, 149);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE6] = new Point(21, 178);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_LEFT_SIDE7] = new Point(21, 205);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE1] = new Point(236, 41);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE2] = new Point(236, 70);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE3] = new Point(236, 96);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE4] = new Point(236, 123);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE5] = new Point(236, 149);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE6] = new Point(236, 178);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_RIGHT_SIDE7] = new Point(236, 205);
        _mMouseTextureMapping[(int)UnityNativeChromaSDK.Mouse.RZLED2.RZLED2_SCROLLWHEEL] = new Point(127, 53);


        _mMousepadTextureMapping.Clear(); 
        _mMousepadTextureMapping[0] = new Point(235, 28);
        _mMousepadTextureMapping[1] = new Point(252, 84);
        _mMousepadTextureMapping[2] = new Point(252, 131);
        _mMousepadTextureMapping[3] = new Point(252, 182);
        _mMousepadTextureMapping[4] = new Point(244, 231);
        _mMousepadTextureMapping[5] = new Point(211, 251);
        _mMousepadTextureMapping[6] = new Point(168, 251);
        _mMousepadTextureMapping[7] = new Point(127, 251);
        _mMousepadTextureMapping[8] = new Point(88, 251);
        _mMousepadTextureMapping[9] = new Point(46, 251);
        _mMousepadTextureMapping[10] = new Point(13, 231);
        _mMousepadTextureMapping[11] = new Point(4, 182);
        _mMousepadTextureMapping[12] = new Point(4, 131);
        _mMousepadTextureMapping[13] = new Point(4, 84);
        _mMousepadTextureMapping[14] = new Point(8, 28);
    }

    private Color GetChromaLinkColor(Color[] colors, int led)
    {
        if (!_mChromaLinkTextureMapping.ContainsKey(led))
        {
            return Color.black;
        }

        Point point = _mChromaLinkTextureMapping[led];

        int index = (RENDER_TEXTURE_SIZE - 1 - point._mY) * RENDER_TEXTURE_SIZE + point._mX;
        if (index < colors.Length)
        {
            return colors[index];
        }
        return Color.black;
    }

    private Color GetKeyboardColor(Color[] colors, int key)
    {
        if (!_mKeyboardTextureMapping.ContainsKey(key))
        {
            return Color.black;
        }

        Point point = _mKeyboardTextureMapping[key];

        int index = (RENDER_TEXTURE_SIZE - 1 - point._mY) * RENDER_TEXTURE_SIZE + point._mX;
        if (index < colors.Length)
        {
            return colors[index];
        }
        return Color.black;
    }

    private Color GetMouseColor(Color[] colors, int led)
    {
        if (!_mMouseTextureMapping.ContainsKey(led))
        {
            return Color.black;
        }

        Point point = _mMouseTextureMapping[led];

        int index = (RENDER_TEXTURE_SIZE - 1 - point._mY) * RENDER_TEXTURE_SIZE + point._mX;
        if (index < colors.Length)
        {
            return colors[index];
        }
        return Color.black;
    }

    private Color GetMousepadColor(Color[] colors, int led)
    {
        if (!_mMousepadTextureMapping.ContainsKey(led))
        {
            return Color.black;
        }

        Point point = _mMousepadTextureMapping[led];

        int index = (RENDER_TEXTURE_SIZE - 1 - point._mY) * RENDER_TEXTURE_SIZE + point._mX;
        if (index < colors.Length)
        {
            return colors[index];
        }
        return Color.black;
    }

    /// <summary>
    /// Get mask colors
    /// </summary>
    /// <returns></returns>
    int[] GetMaskColors()
    {
        if (_mMask)
        {
            string animationName = GetAnimationName(_mMask.name);
            int animationId = GetAnimation(animationName);
            if (animationId >= 0)
            {
                UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.GetDevice(animationId);
                int[] colors = UnityNativeChromaSDK.CreateColors(device);
                float duration;
                UnityNativeChromaSDK.GetFrame(animationId, 0, out duration, colors);
                return colors;
            }
        }
        return null;
    }

    private void CaptureFrame(int animationId)
    {
        if (_mRenderTexture && _mRenderCamera)
        {
            int[] colors = null;
            if (UnityNativeChromaSDK.GetDeviceType(animationId) == UnityNativeChromaSDK.DeviceType.DE_1D)
            {
                UnityNativeChromaSDK.Device1D device = UnityNativeChromaSDK.GetDevice1D(animationId);
                int maxLeds = UnityNativeChromaSDK.GetMaxLeds(device);

                _mTempTexture = new Texture2D(RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE, TextureFormat.RGB24, false);
                RenderTexture.active = _mRenderTexture;
                _mRenderCamera.Render();
                DisplayRenderTexture(0, maxLeds, 1);
                _mTempTexture.ReadPixels(new Rect(0, 0, _mTempTexture.width, _mTempTexture.height), 0, 0, false);
                _mTempTexture.Apply();
                Color[] renderPixels = _mTempTexture.GetPixels();
                TextureScale.Bilinear(_mTempTexture, maxLeds, 1);
                _mTempTexture.Apply();
                RenderTexture.active = null;
                Color[] pixels = _mTempTexture.GetPixels();
                colors = UnityNativeChromaSDK.CreateColors1D(device);
                int index = 0;
                if (colors.Length > 0)
                {
                    for (int i = 0; i < maxLeds; ++i)
                    {
                        Color color = pixels[index];
                        colors[i] = UnityNativeChromaSDK.ToBGR(color);
                        ++index;
                    }
                }
                if (_mToggleLayout)
                {
                    switch (device)
                    {
                        case UnityNativeChromaSDK.Device1D.ChromaLink:
                        case UnityNativeChromaSDK.Device1D.Headset:
                            foreach (KeyValuePair<int, Point> kvp in _mChromaLinkTextureMapping)
                            {
                                Color color = GetChromaLinkColor(renderPixels, kvp.Key);
                                colors[kvp.Key] = UnityNativeChromaSDK.ToBGR(color);
                            }
                            break;
                        case UnityNativeChromaSDK.Device1D.Mousepad:
                            foreach (KeyValuePair<int, Point> kvp in _mMousepadTextureMapping)
                            {
                                Color color = GetMousepadColor(renderPixels, kvp.Key);
                                colors[kvp.Key] = UnityNativeChromaSDK.ToBGR(color);
                            }
                            break;
                    }
                }
#if !SHOW_TEMP_TEXTURE
                DestroyImmediate(_mTempTexture);
#endif
            }
            else if (UnityNativeChromaSDK.GetDeviceType(animationId) == UnityNativeChromaSDK.DeviceType.DE_2D)
            {
                UnityNativeChromaSDK.Device2D device = UnityNativeChromaSDK.GetDevice2D(animationId);
                int maxRow = UnityNativeChromaSDK.GetMaxRow(device);
                int maxColumn = UnityNativeChromaSDK.GetMaxColumn(device);

                _mTempTexture = new Texture2D(RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE, TextureFormat.RGB24, false);
                RenderTexture.active = _mRenderTexture;
                _mRenderCamera.Render();
                DisplayRenderTexture(0, maxColumn, maxRow);
                _mTempTexture.ReadPixels(new Rect(0, 0, _mTempTexture.width, _mTempTexture.height), 0, 0, false);
                _mTempTexture.Apply();
                Color[] renderPixels = _mTempTexture.GetPixels();
                TextureScale.Bilinear(_mTempTexture, maxColumn, maxRow);
                _mTempTexture.Apply();
                RenderTexture.active = null;
                Color[] pixels = _mTempTexture.GetPixels();
                colors = UnityNativeChromaSDK.CreateColors2D(device);
                int[] maskColors = GetMaskColors();
                int index = 0;
                for (int i = maxRow-1; i >= 0; --i)
                {
                    for (int j = 0; j < maxColumn; ++j)
                    {
                        int targetIndex = i * maxColumn + j;
                        Color color = pixels[index];
                        // use mask to see if key should be skipped
                        if (device == UnityNativeChromaSDK.Device2D.Keyboard &&
                            null != maskColors &&
                            targetIndex < maskColors.Length)
                        {
                            if (maskColors[targetIndex] == 0)
                            {
                                color = Color.black;
                            }
                        }
                        colors[targetIndex] = UnityNativeChromaSDK.ToBGR(color);
                        ++index;
                    }
                }
                if (_mToggleLayout)
                {
                    if (device == UnityNativeChromaSDK.Device2D.Keyboard)
                    {
                        foreach (KeyValuePair<int, Point> kvp in _mKeyboardTextureMapping)
                        {
                            Color color = GetKeyboardColor(renderPixels, kvp.Key);

                            // use mask to see if key should be skipped
                            int targetIndex = UnityNativeChromaSDK.GetKeyboardIndex(kvp.Key);
                            if (null != maskColors &&
                                targetIndex < maskColors.Length)
                            {
                                if (maskColors[targetIndex] == 0)
                                {
                                    color = Color.black;
                                }
                            }

                            UnityNativeChromaSDK.SetKeyboardColor(colors, kvp.Key, color);
                        }
                    }
                    else if (device == UnityNativeChromaSDK.Device2D.Mouse)
                    {
                        foreach (KeyValuePair<int, Point> kvp in _mMouseTextureMapping)
                        {
                            Color color = GetMouseColor(renderPixels, kvp.Key);
                            int targetIndex = UnityNativeChromaSDK.GetMouseIndex(kvp.Key);
                            colors[targetIndex] = UnityNativeChromaSDK.ToBGR(color);
                        }
                    }
                }
#if !SHOW_TEMP_TEXTURE
                DestroyImmediate(_mTempTexture);
#endif
            }
            else
            {
                Debug.LogError("Set the animation device type!");
                return;
            }

            if (null == colors)
            {
                Debug.LogError("Colors are null!");
            }
            int frameCount = UnityNativeChromaSDK.PluginGetFrameCount(animationId);
            if (frameCount == 1 && _mCaptureIndex == 0)
            {
                UnityNativeChromaSDK.UpdateFrame(animationId, 0, _mInterval, colors);
            }
            else
            {
                UnityNativeChromaSDK.AddFrame(animationId, _mInterval, colors);
            }
            PreviewLastFrame(animationId);
        }
    }

    private void PreviewLastFrame(int animationId)
    {
        int frameCount = UnityNativeChromaSDK.PluginGetFrameCount(animationId);
        UnityNativeChromaSDK.PluginPreviewFrame(animationId, frameCount - 1);
    }

    private bool IsAnimationSelected()
    {
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (!string.IsNullOrEmpty(path))
            {
                FileInfo fi = new FileInfo(path);
                if (fi.Extension == ".chroma")
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void RestoreSelection()
    {
        // restore animation name
        if (string.IsNullOrEmpty(_mAnimation) &&
            EditorPrefs.HasKey(KEY_ANIMATION))
        {
            _mAnimation = EditorPrefs.GetString(KEY_ANIMATION);
        }

        // restore camera name
        if (!_mRenderCamera &&
            EditorPrefs.HasKey(KEY_CAMERA))
        {
            GameObject go = GameObject.Find(EditorPrefs.GetString(KEY_CAMERA));
            if (go)
            {
                _mRenderCamera = go.GetComponent<Camera>();
            }
        }

        // restore particle system
        if (!_mParticleSystem &&
            EditorPrefs.HasKey(KEY_PARTICLE))
        {
            GameObject go = GameObject.Find(EditorPrefs.GetString(KEY_PARTICLE));
            if (go)
            {
                _mParticleSystem = go.GetComponent<ParticleSystem>();
            }
        }
    }
    private void SaveSelection()
    {
        // save animation name
        if (!string.IsNullOrEmpty(_mAnimation))
        {
            EditorPrefs.SetString(KEY_ANIMATION, _mAnimation);
        }

        // save render camera name
        if (_mRenderCamera)
        {
            EditorPrefs.SetString(KEY_CAMERA, _mRenderCamera.gameObject.name);
        }

        // save particle system
        if (_mParticleSystem)
        {
            EditorPrefs.SetString(KEY_PARTICLE, _mParticleSystem.gameObject.name);
        }
    }

    string GetCompositeName(UnityNativeChromaSDK.Device device)
    {
        return GetAnimationName(string.Format("{0}_{1}", _mAnimation, device));
    }

    private void MakeAnimationReady()
    {
        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                if (!File.Exists(path))
                {
                    UnityNativeChromaSDK.CreateAnimation(path, device);
                    AssetDatabase.Refresh();
                }
            }
        }
        else
        {
            string path = UnityNativeChromaSDK.GetStreamingPath(GetAnimationName());
            if (!File.Exists(path))
            {
                UnityNativeChromaSDK.CreateAnimation(path, UnityNativeChromaSDK.Device.ChromaLink);
                AssetDatabase.Refresh();
            }
        }
    }

    private void OnClickPlay()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    UnityNativeChromaSDK.PluginPlayAnimation(animationId);
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                UnityNativeChromaSDK.PluginPlayAnimation(animationId);
            }
        }
    }

    private void OnClickStop()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    UnityNativeChromaSDK.PluginStopAnimation(animationId);
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                UnityNativeChromaSDK.PluginStopAnimation(animationId);
            }
        }
    }

    private void OnClickReset()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    UnityNativeChromaSDK.PluginResetAnimation(animationId);
                    string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                    UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                UnityNativeChromaSDK.PluginResetAnimation(animationId);
                string path = UnityNativeChromaSDK.GetStreamingPath(GetAnimationName());
                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
            }
        }
    }

    private void OnClickSave()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                    UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                string path = UnityNativeChromaSDK.GetStreamingPath(GetAnimationName());
                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
            }
        }
    }

    private void OnClickClose()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                UnityNativeChromaSDK.CloseAnimation(animationName);
            }
        }
        else
        {
            UnityNativeChromaSDK.CloseAnimation(GetAnimationName());
        }
    }

    private void OnClickEdit()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Normal)
        {
            UnityNativeChromaSDK.EditAnimation(GetAnimationName());
        }
    }

    private void OnClick1Frame()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    CaptureFrame(animationId);
                    string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                    UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                    OnClickSave();
                    ++_mCaptureIndex;
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                CaptureFrame(animationId);
                OnClickSave();
                ++_mCaptureIndex;
            }
        }
    }

    private void OnClickAlignWithView()
    {
        if (_mRenderCamera)
        {
            if (SceneView.sceneViews.Count > 0 &&
                null != SceneView.sceneViews[0])
            {
                SceneView sceneView = (SceneView)SceneView.sceneViews[0];
                if (sceneView)
                {
                    Camera sceneCamera = sceneView.camera;
                    if (sceneCamera)
                    {
                        _mRenderCamera.transform.position = sceneCamera.transform.position;
                        _mRenderCamera.transform.rotation = sceneCamera.transform.rotation;
                        _mRenderCamera.orthographic = sceneCamera.orthographic;
                        _mRenderCamera.orthographicSize = sceneCamera.orthographicSize;
                    }
                }
            }
        }
    }

    private void OnClickSetOverrideTime()
    {
        MakeAnimationReady();

        if (_mMode == Modes.Composite)
        {
            for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
            {
                string animationName = GetCompositeName(device);
                int animationId = GetAnimation(animationName);
                if (animationId >= 0)
                {
                    UnityNativeChromaSDK.PluginOverrideFrameDuration(animationId, _mOverrideTime);
                    string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                    UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                }
            }
        }
        else
        {
            int animationId = GetAnimation();
            if (animationId >= 0)
            {
                UnityNativeChromaSDK.PluginOverrideFrameDuration(animationId, _mOverrideTime);
                string path = UnityNativeChromaSDK.GetStreamingPath(GetAnimationName());
                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
            }
        }
    }

    private void OnEnable()
    {
#if SHOW_LAYOUT_IN_SCENE_VIEW
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;
#endif
        SetupTextureMapping();

        if (null == _sChromaLinkTexture)
        {
            _sChromaLinkTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/UnityNativeChromaSDK/Textures/ChromaLinkLayout.png", typeof(Texture2D));
        }

        if (null == _sKeyboardTexture)
        {
            _sKeyboardTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/UnityNativeChromaSDK/Textures/KeyboardLayout.png", typeof(Texture2D));
        }

        if (null == _sMouseTexture)
        {
            _sMouseTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/UnityNativeChromaSDK/Textures/MouseLayout.png", typeof(Texture2D));
        }

        if (null == _sMousepadTexture)
        {
            _sMousepadTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/UnityNativeChromaSDK/Textures/MousepadLayout.png", typeof(Texture2D));
        }

        if (EditorPrefs.HasKey(KEY_AUTO_ALIGN))
        {
            _mAutoAlignWithView = EditorPrefs.GetBool(KEY_AUTO_ALIGN);
        }

        if (EditorPrefs.HasKey(KEY_LAYOUT))
        {
            _mToggleLayout = EditorPrefs.GetBool(KEY_LAYOUT);
        }

        if (EditorPrefs.HasKey(KEY_MASK))
        {
            string mask = EditorPrefs.GetString(KEY_MASK);
            string animationName = GetAnimationName(mask);
            int animationId = GetAnimation(animationName);
            if (animationId >= 0)
            {
                string path = string.Format("Assets/StreamingAssets/{0}", animationName);
                _mMask = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
            }
        }
    }

#if SHOW_LAYOUT_IN_SCENE_VIEW
    private void OnDisable()
    {
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }
#endif

#if SHOW_LAYOUT_IN_SCENE_VIEW
    private void OnSceneGUI(SceneView sceneView)
    {
        if (_mToggleLayout)
        {
            // Do your drawing here using Handles.
            Handles.BeginGUI();
            // Do your drawing here using GUI.

            if (_mRenderCamera)
            {
                Color oldColor = GUI.color;
                GUI.color = _mColorLayout;
                int size = Mathf.Min(Screen.width, Screen.height);
                int centerWidth = Screen.width / 2;
                int centerHeight = Screen.height / 2;
                Rect rect = new Rect(centerWidth - size / 2, centerHeight - size / 2, size, size);
                switch (_mDeviceLayout)
                {
                    case UnityNativeChromaSDK.Device.ChromaLink:
                    case UnityNativeChromaSDK.Device.Headset:
                        if (_sChromaLinkTexture)
                        {
                            GUI.DrawTexture(rect, _sChromaLinkTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                        }
                        break;
                    case UnityNativeChromaSDK.Device.Keyboard:
                        if (_sKeyboardTexture)
                        {
                            GUI.DrawTexture(rect, _sKeyboardTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                        }
                        break;
                    case UnityNativeChromaSDK.Device.Mouse:
                        if (_sMouseTexture)
                        {
                            GUI.DrawTexture(rect, _sMouseTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                        }
                        break;
                    case UnityNativeChromaSDK.Device.Mousepad:
                        if (_sMousepadTexture)
                        {
                            GUI.DrawTexture(rect, _sMousepadTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                        }
                        break;
                }
                GUI.color = oldColor;
            }

            Handles.EndGUI();
        }
    }
#endif

    private void OnGUI()
    {
        Rect rect;

        RestoreSelection();
        SaveSelection();

        UnityNativeChromaSDK.Init();

        if (_mAutoAlignWithView)
        {
            if (_mTimerAlign < DateTime.Now)
            {
                _mTimerAlign = DateTime.Now + TimeSpan.FromSeconds(_mInterval);
                OnClickAlignWithView();
            }
        }

        if (_mCapturing)
        {
            if (_mTimerCapture < DateTime.Now)
            {
                _mTimerCapture = DateTime.Now + TimeSpan.FromSeconds(_mInterval);
                if (_mMode == Modes.Composite)
                {
                    for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                    {
                        string animationName = GetCompositeName(device);
                        int animationId = GetAnimation(animationName);
                        CaptureFrame(animationId);
                    }
                    ++_mCaptureIndex;
                }
                else
                {
                    int animationId = GetAnimation();
                    CaptureFrame(animationId);
                    ++_mCaptureIndex;
                }
            }
        }

        GameObject activeGameObject = Selection.activeGameObject;
        if (activeGameObject)
        {
            ParticleSystem particleSystem = activeGameObject.GetComponent<ParticleSystem>();
            if (particleSystem)
            {
                _mParticleSystem = particleSystem;
            }
        }

#if SHOW_TEMP_TEXTURE
        _mTempTexture = (Texture2D)EditorGUILayout.ObjectField("TempTexture", _mTempTexture, typeof(Texture2D), true);
#endif

        if (string.IsNullOrEmpty(_mAnimation))
        {
            _mAnimation = string.Empty;
        }

        GUILayout.BeginHorizontal(GUILayout.Width(position.width));
        GUILayout.Label("Mode:");
        GUI.enabled = _mMode != Modes.Normal;
        if (GUILayout.Button("Normal"))
        {
            _mMode = Modes.Normal;
        }
        GUI.enabled = _mMode != Modes.Composite;
        if (GUILayout.Button("Composite"))
        {
            _mMode = Modes.Composite;
        }
        GUI.enabled = _mMode != Modes.Playback;
        if (GUILayout.Button("Playback"))
        {
            _mMode = Modes.Playback;
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();

        if (_mMode == Modes.Composite)
        {
            GUILayout.BeginHorizontal(GUILayout.Width(position.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label("Make Composite:");
            if (GUILayout.Button("PlayOnEnable"))
            {
                GameObject go = new GameObject("CompositePlayOnEnable");
                for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                {
                    string animationName = GetCompositeName(device);
                    go.AddComponent<UnityNativeChromaSDKPlayOnEnable>().AnimationName = animationName;
                }
            }
            if (GUILayout.Button("PlayAndDeactivate"))
            {
                GameObject go = new GameObject("CompositePlayAndDeactivate");
                for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                {
                    string animationName = GetCompositeName(device);
                    go.AddComponent<UnityNativeChromaSDKPlayAndDeactivate>().AnimationName = animationName;
                }
            }
            if (GUILayout.Button("PlayOnDestroy"))
            {
                GameObject go = new GameObject("CompositePlayOnDestroy");
                for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                {
                    string animationName = GetCompositeName(device);
                    go.AddComponent<UnityNativeChromaSDKPlayOnDestroy>().AnimationName = animationName;
                }
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        switch (_mMode)
        {
            case Modes.Normal:
            case Modes.Composite:

                _mAnimation = EditorGUILayout.TextField("Animation Name:", _mAnimation);

                _mRenderCamera = (Camera)EditorGUILayout.ObjectField("RenderCamera:", _mRenderCamera, typeof(Camera), true);

                Object mask = (Object)EditorGUILayout.ObjectField("Mask", _mMask, typeof(Object), true);
                if (mask != _mMask)
                {
                    _mMask = mask;
                    if (mask)
                    {
                        string animationName = GetAnimationName(mask.name);
                        int animationId = GetAnimation(animationName);
                        if (animationId >= 0)
                        {
                            EditorPrefs.SetString(KEY_MASK, animationName);
                        }
                    }
                }

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Select:");
                GUI.enabled = null != _mAnimation;
                if (GUILayout.Button("Animation"))
                {
                    Selection.activeGameObject = null;
                    string path = string.Format("Assets/StreamingAssets/{0}", GetAnimationName());
                    if (File.Exists(path))
                    {
                        Selection.activeObject = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
                    }
                    else
                    {
                        Selection.activeObject = null;
                    }
                }
                GUI.enabled = null != _mRenderCamera;
                if (GUILayout.Button("Camera"))
                {
                    Selection.activeObject = null;
                    Selection.activeGameObject = _mRenderCamera.gameObject;
                }
                GUI.enabled = null != _mParticleSystem;
                if (GUILayout.Button("ParticleSystem"))
                {
                    Selection.activeGameObject = null;
                    Selection.activeObject = _mParticleSystem;
                }
                GUI.enabled = true;
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Camera:");
                GUI.enabled = null != _mRenderCamera;
                if (GUILayout.Button("Align With View"))
                {
                    OnClickAlignWithView();
                }
                bool autoAlignWithView = GUILayout.Toggle(_mAutoAlignWithView, "Auto");
                if (_mAutoAlignWithView != autoAlignWithView)
                {
                    _mAutoAlignWithView = autoAlignWithView;
                    EditorPrefs.SetBool(KEY_AUTO_ALIGN, _mAutoAlignWithView);
                }
                GUI.enabled = true;
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Animation:");
                if (GUILayout.Button("Play"))
                {
                    OnClickPlay();
                }
                if (GUILayout.Button("Stop"))
                {
                    OnClickStop();
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                if (GUILayout.Button("Reset"))
                {
                    OnClickReset();
                }
                if (GUILayout.Button("Close"))
                {
                    OnClickClose();
                }
                if (_mMode == Modes.Normal)
                {
                    if (GUILayout.Button("Edit"))
                    {
                        OnClickEdit();
                    }
                }
                GUILayout.EndHorizontal();

                if (_mMode == Modes.Normal)
                {
                    string animationName = GetAnimationName();
                    int frameCount = UnityNativeChromaSDK.GetFrameCount(animationName);
                    UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.GetDevice(animationName);
                    GUILayout.Label(string.Format("Name: {0}", animationName));
                    GUILayout.Label(string.Format("Device: {0}", device));
                    GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                    bool doSave = false;
                    GUI.enabled = device != UnityNativeChromaSDK.Device.ChromaLink;
                    if (GUILayout.Button("ChromaLink"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.ChromaLink);
                        doSave = true;
                    }
                    GUI.enabled = device != UnityNativeChromaSDK.Device.Headset;
                    if (GUILayout.Button("Headset"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.Headset);
                        doSave = true;
                    }
                    GUI.enabled = device != UnityNativeChromaSDK.Device.Keyboard;
                    if (GUILayout.Button("Keyboard"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.Keyboard);
                        doSave = true;
                    }
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                    GUI.enabled = device != UnityNativeChromaSDK.Device.Keypad;
                    if (GUILayout.Button("Keypad"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.Keypad);
                        doSave = true;
                    }
                    GUI.enabled = device != UnityNativeChromaSDK.Device.Mouse;
                    if (GUILayout.Button("Mouse"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.Mouse);
                        doSave = true;
                    }
                    GUI.enabled = device != UnityNativeChromaSDK.Device.Mousepad;
                    if (GUILayout.Button("Mousepad"))
                    {
                        UnityNativeChromaSDK.SetDevice(animationName, UnityNativeChromaSDK.Device.Mousepad);
                        doSave = true;
                    }
                    GUILayout.EndHorizontal();
                    GUI.enabled = true;
                    if (doSave)
                    {
                        int animationId = GetAnimation();
                        string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                        UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                    }
                    GUILayout.Label(string.Format("Frame Count: {0}", frameCount));
                }
                else if (_mMode == Modes.Composite)
                {
                    for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                    {
                        string animationName = GetCompositeName(device);
                        int frameCount = UnityNativeChromaSDK.GetFrameCount(animationName);
                        GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                        GUILayout.Label(string.Format("{0}: {1} frames - ({2})", device, frameCount, animationName));
                        GUILayout.EndHorizontal();
                    }
                }

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                float interval = EditorGUILayout.FloatField("Capture Interval", _mInterval);
                if (interval >= 0.1f)
                {
                    _mInterval = interval;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Capture:");
                GUI.enabled = null != _mRenderCamera && !string.IsNullOrEmpty(_mAnimation);
                if (GUILayout.Button("1 Frame"))
                {
                    if (_mAutoAlignWithView)
                    {
                        OnClickAlignWithView();
                    }
                    OnClick1Frame();
                }
                if (GUILayout.Button(_mCapturing ? "Stop" : "Start"))
                {
                    MakeAnimationReady();

                    _mCapturing = !_mCapturing;
                    if (_mCapturing)
                    {
                        OnClickReset();
                        _mCaptureIndex = 0;
                    }
                    else
                    {
                        OnClickSave();
                    }
                }
                GUI.enabled = true;
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Override Time (ALL FRAMES):");
                _mOverrideTime = EditorGUILayout.FloatField(_mOverrideTime);
                if (_mOverrideTime < 0.1f)
                {
                    _mOverrideTime = 0.1f;
                }
                if (GUILayout.Button("Set", GUILayout.Width(50)))
                {
                    OnClickSetOverrideTime();
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                GUILayout.Label("Layout");
                if (GUILayout.Button("C"))
                {
                    if (!_mToggleLayout || _mDeviceLayout == UnityNativeChromaSDK.Device.ChromaLink)
                    {
                        _mToggleLayout = !_mToggleLayout;
                        EditorPrefs.SetBool(KEY_LAYOUT, _mToggleLayout);
                    }
                    _mDeviceLayout = UnityNativeChromaSDK.Device.ChromaLink;
                }
                if (GUILayout.Button("K"))
                {
                    if (!_mToggleLayout || _mDeviceLayout == UnityNativeChromaSDK.Device.Keyboard)
                    {
                        _mToggleLayout = !_mToggleLayout;
                        EditorPrefs.SetBool(KEY_LAYOUT, _mToggleLayout);
                    }
                    _mDeviceLayout = UnityNativeChromaSDK.Device.Keyboard;
                }
                if (GUILayout.Button("M"))
                {
                    if (!_mToggleLayout || _mDeviceLayout == UnityNativeChromaSDK.Device.Mouse)
                    {
                        _mToggleLayout = !_mToggleLayout;
                        EditorPrefs.SetBool(KEY_LAYOUT, _mToggleLayout);
                    }
                    _mDeviceLayout = UnityNativeChromaSDK.Device.Mouse;
                }
                if (GUILayout.Button("MP"))
                {
                    if (!_mToggleLayout || _mDeviceLayout == UnityNativeChromaSDK.Device.Mousepad)
                    {
                        _mToggleLayout = !_mToggleLayout;
                        EditorPrefs.SetBool(KEY_LAYOUT, _mToggleLayout);
                    }
                    _mDeviceLayout = UnityNativeChromaSDK.Device.Mousepad;
                }
                _mColorLayout = EditorGUILayout.ColorField(_mColorLayout);
                GUILayout.EndHorizontal();

                rect = GUILayoutUtility.GetLastRect();
                if (_mRenderCamera)
                {
                    if (null == _mRenderTexture)
                    {
                        _mRenderTexture = new RenderTexture(RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE, 24, RenderTextureFormat.ARGB32);
                        _mRenderCamera.targetTexture = _mRenderTexture;
                    }
                    _mRenderCamera.Render();
                    rect.y += 30;
                    DisplayRenderTexture((int)rect.y, RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE);

                    if (_mToggleLayout)
                    {
                        if (_sKeyboardTexture)
                        {
                            Color oldColor = GUI.color;
                            GUI.color = _mColorLayout;
                            const int border = 2;
                            rect = new Rect(rect.x + border, rect.y + border, RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE);
                            
                            switch (_mDeviceLayout)
                            {
                                case UnityNativeChromaSDK.Device.ChromaLink:
                                case UnityNativeChromaSDK.Device.Headset:
                                    if (_sChromaLinkTexture)
                                    {
                                        GUI.DrawTexture(rect, _sChromaLinkTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                                    }
                                    break;
                                case UnityNativeChromaSDK.Device.Keyboard:
                                    if (_sKeyboardTexture)
                                    {
                                        GUI.DrawTexture(rect, _sKeyboardTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                                    }
                                    break;
                                case UnityNativeChromaSDK.Device.Mouse:
                                    if (_sMouseTexture)
                                    {
                                        GUI.DrawTexture(rect, _sMouseTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                                    }
                                    break;
                                case UnityNativeChromaSDK.Device.Mousepad:
                                    if (_sMousepadTexture)
                                    {
                                        GUI.DrawTexture(rect, _sMousepadTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                                    }
                                    break;
                            }

                            GUI.color = oldColor;
                        }
                    }
                }
                break;

            case Modes.Playback:
                if (IsAnimationSelected())
                {
                    if (Selection.activeObject)
                    {
                        string animationName = GetAnimationName(Selection.activeObject.name);
                        if (_mLastPlaybackName != animationName)
                        {
                            UnityNativeChromaSDK.StopAnimation(_mLastPlaybackName);
                            _mLastPlaybackName = animationName;
                            UnityNativeChromaSDK.PlayAnimation(animationName);
                        }
                        int frameCount = UnityNativeChromaSDK.GetFrameCount(animationName);
                        UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.GetDevice(animationName);
                        GUILayout.Label(string.Format("Name: {0}", animationName));
                        GUILayout.Label(string.Format("Device: {0}", device));
                        GUILayout.Label(string.Format("Frame Count: {0}", frameCount));
                        GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                        if (GUILayout.Button("Play"))
                        {
                            UnityNativeChromaSDK.PlayAnimation(animationName);
                        }
                        if (GUILayout.Button("Stop"))
                        {
                            UnityNativeChromaSDK.StopAnimation(animationName);
                        }
                        if (GUILayout.Button("Reload"))
                        {
                            UnityNativeChromaSDK.CloseAnimation(animationName);
                        }
                        GUILayout.EndHorizontal();

                        GUILayout.Label("Edit:");
                        if (GUILayout.Button("Edit"))
                        {
                            UnityNativeChromaSDK.EditAnimation(animationName);
                        }
                        if (GUILayout.Button("Reverse Animation"))
                        {
                            int animationId = GetAnimation(animationName);
                            if (animationId >= 0)
                            {
                                UnityNativeChromaSDK.Reverse(animationName);
                                string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                                UnityNativeChromaSDK.CloseAnimation(animationName);
                                UnityNativeChromaSDK.PlayAnimation(animationName);
                            }
                        }

                        if (GUILayout.Button("Mirror Animation Horizontally"))
                        {
                            int animationId = GetAnimation(animationName);
                            if (animationId >= 0)
                            {
                                UnityNativeChromaSDK.MirrorHorizontally(animationName);
                                string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                                UnityNativeChromaSDK.CloseAnimation(animationName);
                                UnityNativeChromaSDK.PlayAnimation(animationName);
                            }
                        }

                        if (GUILayout.Button("Mirror Animation Vertically"))
                        {
                            int animationId = GetAnimation(animationName);
                            if (animationId >= 0)
                            {
                                UnityNativeChromaSDK.MirrorVertically(animationName);
                                string path = UnityNativeChromaSDK.GetStreamingPath(animationName);
                                UnityNativeChromaSDK.PluginSaveAnimation(animationId, path);
                                UnityNativeChromaSDK.CloseAnimation(animationName);
                                UnityNativeChromaSDK.PlayAnimation(animationName);
                            }
                        }
                    }
                }
                break;
        }

        rect = new Rect(0, position.height - 40, 75, 40);
        if (GUI.Button(rect, "Reinit"))
        {
            UnityNativeChromaSDK.Uninit();
            UnityNativeChromaSDK.Init();
        }

        rect = new Rect(position.width - 40, position.height - 20, 100, 40);
        GUI.Label(rect, _mVersionString);

        Repaint();
    }
#endif
}
