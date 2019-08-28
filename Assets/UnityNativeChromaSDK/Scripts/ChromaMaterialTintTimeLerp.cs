using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaMaterialTintTimeLerp : MonoBehaviour
{
    public Color _mColor1 = Color.white;
    public Color _mColor2 = Color.black;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;
    private float _mTime = 0;
    private MeshRenderer _mRenderer = null;
    private Material _mMaterial = null;

    private void Awake()
    {
        _mRenderer = GetComponent<MeshRenderer>();
        if (_mRenderer == null)
        {
            enabled = false;
            return;
        }

        _mMaterial = _mRenderer.sharedMaterial;
        if (_mMaterial == null)
        {
            enabled = false;
            return;
        }
    }

    private void OnEnable()
    {
        _mTimer = DateTime.Now;
        _mTime = 0;
    }

    private void Update()
    {
        if (_mMaterial == null)
        {
            enabled = false;
            return;
        }
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
        _mTime += _mSpeed * elapsed;
        float t = 1 - Mathf.Abs(Mathf.Cos(Mathf.PI * _mTime));
        Color color = _mMaterial.color;
        color.r = Mathf.Lerp(_mColor1.r, _mColor2.r, t);
        color.g = Mathf.Lerp(_mColor1.g, _mColor2.g, t);
        color.b = Mathf.Lerp(_mColor1.b, _mColor2.b, t);
        color.a = Mathf.Lerp(_mColor1.a, _mColor2.a, t);
        _mMaterial.color = color;
    }
}
