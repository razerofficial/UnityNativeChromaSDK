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

    private const int RENDER_TEXTURE_SIZE = 256;

    private string _mAnimation = null;
    private Camera _mRenderCamera = null;
    private RenderTexture _mRenderTexture = null;
    private Texture2D _mTempTexture = null;
    private float _mInterval = 0.1f;
    private ParticleSystem _mParticleSystem = null;
    private bool _mCapturing = false;
    private DateTime _mTimerCapture = DateTime.MinValue;
    private int _mCaptureIndex = 0;
    private float _mOverrideTime = 0.1f;

    private static Texture2D _sTextureClear = null;

    private static Texture2D _sKeyboardTexture = null;

    private bool _mAutoAlignWithView = false;
    private DateTime _mTimerAlign = DateTime.MinValue;

    private bool _mToggleSceneView = false;
    private Color _mColorSceneView = Color.white;

    enum Modes
    {
        Normal,
        Composite,
        Playback
    }

    private Modes _mMode = Modes.Normal;

    private string _mLastPlaybackName = string.Empty;

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
                TextureScale.Bilinear(_mTempTexture, maxLeds, 1);
                _mTempTexture.Apply();
                RenderTexture.active = null;
                Color[] pixels = _mTempTexture.GetPixels();
                colors = new int[maxLeds];
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
                TextureScale.Bilinear(_mTempTexture, maxColumn, maxRow);
                _mTempTexture.Apply();
                RenderTexture.active = null;
                Color[] pixels = _mTempTexture.GetPixels();
                colors = new int[maxRow * maxColumn];
                int index = 0;
                for (int i = maxRow-1; i >= 0; --i)
                {
                    for (int j = 0; j < maxColumn; ++j)
                    {
                        int targetIndex = i * maxColumn + j;
                        Color color = pixels[index];
                        colors[targetIndex] = UnityNativeChromaSDK.ToBGR(color);
                        ++index;
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

    private void OnClickAlignWithView(GameObject activeGameObject, Object activeObject)
    {
        if (_mRenderCamera)
        {
            Selection.activeGameObject = _mRenderCamera.gameObject;
            EditorApplication.ExecuteMenuItem("GameObject/Align With View");
            Selection.activeObject = activeObject;
            Selection.activeGameObject = activeGameObject;
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
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;

        if (null == _sKeyboardTexture)
        {
            _sKeyboardTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/UnityNativeChromaSDK/Textures/KeyboardLayout.png", typeof(Texture2D));
        }
    }

    private void OnDisable()
    {
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        if (_mToggleSceneView)
        {
            // Do your drawing here using Handles.
            Handles.BeginGUI();
            // Do your drawing here using GUI.

            if (_mRenderCamera)
            {
                DisplayRenderTexture(0, RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE / 2);

                if (_sKeyboardTexture)
                {
                    Color oldColor = GUI.color;
                    GUI.color = _mColorSceneView;
                    GUI.DrawTexture(new Rect(0, 0, RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE / 2), _sKeyboardTexture, ScaleMode.ScaleAndCrop, true, 1.0f);
                    GUI.color = oldColor;
                }
            }

            Handles.EndGUI();
        }
    }

    private void OnGUI()
    {
        RestoreSelection();
        SaveSelection();

        UnityNativeChromaSDK.Init();

        if (_mAutoAlignWithView)
        {
            if (_mTimerAlign < DateTime.Now)
            {
                _mTimerAlign = DateTime.Now + TimeSpan.FromSeconds(_mInterval);
                OnClickAlignWithView(Selection.activeGameObject, Selection.activeObject);
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
        Object activeObject = Selection.activeObject;

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
            if (GUILayout.Button("Make Composite GameObject"))
            {
                GameObject go = new GameObject("CompositeAnimation");
                for (UnityNativeChromaSDK.Device device = UnityNativeChromaSDK.Device.ChromaLink; device < UnityNativeChromaSDK.Device.MAX; ++device)
                {
                    string animationName = GetCompositeName(device);
                    go.AddComponent<UnityNativeChromaSDKPlayOnEnable>().AnimationName = animationName;
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

                _mRenderCamera = (Camera)EditorGUILayout.ObjectField("RenderCamera", _mRenderCamera, typeof(Camera), true);

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
                    OnClickAlignWithView(activeGameObject, activeObject);
                }
                _mAutoAlignWithView = GUILayout.Toggle(_mAutoAlignWithView, "Auto");
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
                if (GUILayout.Button("Edit"))
                {
                    OnClickEdit();
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
                        OnClickAlignWithView(activeGameObject, activeObject);
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
                GUILayout.Label("Override Frame Time: (ALL FRAMES)");
                _mOverrideTime = EditorGUILayout.FloatField(_mOverrideTime);
                if (_mOverrideTime < 0.1f)
                {
                    _mOverrideTime = 0.1f;
                }
                if (GUILayout.Button("Set"))
                {
                    OnClickSetOverrideTime();
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal(GUILayout.Width(position.width));
                if (GUILayout.Button("Layout"))
                {
                    _mToggleSceneView = !_mToggleSceneView;
                }
                _mColorSceneView = EditorGUILayout.ColorField(_mColorSceneView);
                GUILayout.EndHorizontal();

                Rect rect = GUILayoutUtility.GetLastRect();
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
                    }
                }
                break;
        }

        if (GUI.Button(new Rect(0, position.height - 40, 150, 40), "Reinit"))
        {
            UnityNativeChromaSDK.Uninit();
            UnityNativeChromaSDK.Init();
        }

        Repaint();
    }
#endif
}
