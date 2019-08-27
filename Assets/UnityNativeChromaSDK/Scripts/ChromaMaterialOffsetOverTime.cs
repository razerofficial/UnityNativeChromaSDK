using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaMaterialOffsetOverTime : MonoBehaviour
{
    public Vector2 _mDirection = Vector2.zero;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;
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
        Vector2 pos = _mMaterial.mainTextureOffset;
        pos += _mDirection * (elapsed * _mSpeed);
        _mMaterial.mainTextureOffset = pos;
    }
}
