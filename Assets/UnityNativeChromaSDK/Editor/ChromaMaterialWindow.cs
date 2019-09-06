using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

class ChromaMaterialWindow : EditorWindow
{
    private const string KEY_TEXTURE_PATH = "ChromaSDKTexturePath";
    private const string KEY_MATERIAL_PATH = "ChromaSDKMaterialPath";

    private string _mTexturePath = string.Empty;
    private string _mMaterialPath = string.Empty;

    private bool _mIsPlaying = false;
    private bool _mKeyDetected = false;

    private DateTime _mTimer = DateTime.MinValue;
    private float _mRate = 0.1f;
    private int _mFrameIndex = 0;

    private List<FileInfo> _mListTextures = null;

    [MenuItem("Window/ChromaSDK/Open Material Window")]
    private static void OpenPanel()
    {
        ChromaMaterialWindow window = GetWindow<ChromaMaterialWindow>();
        if (null == window)
        {
            window.name = "Material Chroma Window";
        }
    }

    private void OnEnable()
    {
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;

        if (EditorPrefs.HasKey(KEY_TEXTURE_PATH))
        {
            _mTexturePath = EditorPrefs.GetString(KEY_TEXTURE_PATH);
        }

        if (EditorPrefs.HasKey(KEY_MATERIAL_PATH))
        {
            _mMaterialPath = EditorPrefs.GetString(KEY_MATERIAL_PATH);
        }
    }

    private void OnDisable()
    {
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event current = Event.current;
        if (null != current &&
            current.type == EventType.keyUp &&
            current.keyCode == KeyCode.F1)
        {
            _mKeyDetected = true;
        }
    }

    private void OnGUI()
    {
        // handle unfocusing controls
        GUI.SetNextControlName(string.Empty);

        string texturePath = EditorGUILayout.TextField("Texture Path", _mTexturePath);
        if (texturePath != _mTexturePath)
        {
            _mTexturePath = texturePath;
            EditorPrefs.SetString(KEY_TEXTURE_PATH, _mTexturePath);
        }
        texturePath = string.Format("Assets/{0}", _mTexturePath);
        DirectoryInfo diTexture = new DirectoryInfo(texturePath);
        if (!diTexture.Exists)
        {
            EditorGUILayout.LabelField("Invalid texture path!");
        }

        string materialPath;
        EditorStyles.textField.wordWrap = true;
        materialPath = EditorGUILayout.TextField("Material Path", _mMaterialPath);
        if (Selection.activeObject)
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (Path.GetExtension(path).ToLower() == ".mat")
            {
                if (GUILayout.Button("Grab", GUILayout.Width(100)))
                {
                    materialPath = path;
                    GUI.FocusControl(string.Empty);
                }
            }
        }
        if (materialPath != _mMaterialPath)
        {
            _mMaterialPath = materialPath;
            EditorPrefs.SetString(KEY_MATERIAL_PATH, _mMaterialPath);
        }
        FileInfo fiMaterial = new FileInfo(materialPath);
        if (!fiMaterial.Exists)
        {
            EditorGUILayout.LabelField("Invalid material path!");
        }

        Repaint();

        if (!diTexture.Exists ||
            !fiMaterial.Exists)
        {
            GUIUtility.ExitGUI();
            return;
        }

        float rate = EditorGUILayout.FloatField("Rate", _mRate);
        _mRate = Mathf.Max(0.033f, rate);

        if (_mIsPlaying)
        {
            if (GUILayout.Button("Stop", GUILayout.Height(40)) ||
                _mKeyDetected)
            {
                _mIsPlaying = false;
                _mKeyDetected = false;
                GUIUtility.ExitGUI();
                return;
            }
        }
        else
        {
            if (GUILayout.Button("Start", GUILayout.Height(40)) ||
                _mKeyDetected)
            {
                _mIsPlaying = true;
                _mKeyDetected = false;

                FileInfo[] textures = diTexture.GetFiles("*.png");
                _mListTextures = new List<FileInfo>(textures);
                _mListTextures.Sort(delegate (FileInfo a, FileInfo b)
                {
                    if (a.Name.StartsWith("Background "))
                    {
                        return -1;
                    }
                    else if (b.Name.StartsWith("Background "))
                    {
                        return 1;
                    }
                    return GetFrameIndex(a).CompareTo(GetFrameIndex(b));
                });

                _mFrameIndex = -1;

                GUIUtility.ExitGUI();
                return;
            }
        }

        EditorGUILayout.LabelField("Frame Index", _mFrameIndex.ToString());

        if (_mIsPlaying &&
            null != _mListTextures &&
            _mListTextures.Count > 0)
        {
            if (_mTimer < DateTime.Now)
            {
                _mTimer = DateTime.Now + TimeSpan.FromSeconds(_mRate);
                _mFrameIndex = (_mFrameIndex + 1) % _mListTextures.Count;

                Material material = (Material)AssetDatabase.LoadAssetAtPath(_mMaterialPath, typeof(Material));
                if (material)
                {
                    texturePath = string.Format("Assets/{0}/{1}", _mTexturePath, _mListTextures[_mFrameIndex].Name);
                    Texture2D texture = (Texture2D)AssetDatabase.LoadAssetAtPath(texturePath, typeof(Texture2D));
                    if (texture)
                    {
                        material.mainTexture = texture;
                    }
                }
            }
        }
    }

    int GetFrameIndex(FileInfo fi)
    {
        string name = fi.Name;
        string val = string.Empty;
        for (int i = 0; i < name.Length; ++i)
        {
            if (char.IsDigit(name[i]))
            {
                val += name[i];
            }
            if (char.IsWhiteSpace(name[i]) &&
                !string.IsNullOrEmpty(val))
            {
                break;
            }
        }
        int result;
        int.TryParse(val, out result);
        return result;
    }
}
