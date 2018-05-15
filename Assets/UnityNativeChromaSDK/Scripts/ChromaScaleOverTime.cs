using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaScaleOverTime : MonoBehaviour
{
    public Vector3 _mScale = Vector3.one;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;

    private void OnEnable()
    {
        _mTimer = DateTime.Now;
    }

    private void Update()
    {
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
        Vector3 scale = transform.localScale;
        scale += _mScale * (elapsed * _mSpeed);
        scale.x = Mathf.Max(scale.x, 0f);
        scale.y = Mathf.Max(scale.y, 0f);
        scale.z = Mathf.Max(scale.z, 0f);
        transform.localScale = scale;
    }
}
