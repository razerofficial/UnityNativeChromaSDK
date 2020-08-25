using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaMaterialColorOverTimeLerp : MonoBehaviour
{
    public Color _mColorStart = Color.clear;
    public Color _mColorEnd = Color.white;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;
    private float _mTime = 0;

    private void OnEnable()
    {
      _mTimer = DateTime.Now;
      _mTime = 0;
    }

    private void Update()
    {
      MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
      if (meshRenderer)
      {
          Material material = meshRenderer.material;
          if (material)
          {
              float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
              _mTimer = DateTime.Now;
              _mTime += _mSpeed * elapsed;
              float t = 1 - Mathf.Abs(Mathf.Cos(Mathf.PI * _mTime));
              Color color = Color.Lerp(_mColorStart, _mColorEnd, t);
              material.color = color;
          }
      }
    }
}
