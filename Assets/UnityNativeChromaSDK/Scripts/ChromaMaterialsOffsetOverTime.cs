using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaMaterialsOffsetOverTime : MonoBehaviour
{
    public Vector2 _mDirection = Vector2.zero;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;
    public Material[] _mMaterials = null;

    private void OnEnable()
    {
       
        _mTimer = DateTime.Now;
    }

    private void Update()
    {
        if (_mMaterials == null)
        {
            enabled = false;
            return;
        }
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
        foreach (Material material in _mMaterials)
        {
            Vector2 pos = material.mainTextureOffset;
            pos += _mDirection * (elapsed * _mSpeed);
            material.mainTextureOffset = pos;
        }
    }
}
