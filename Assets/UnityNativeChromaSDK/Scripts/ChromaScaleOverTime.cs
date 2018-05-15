using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaScaleOverTime : MonoBehaviour
{
    public bool _mIsEnabled = false;
    public Vector3 _mScale = Vector3.one;
    public float _mSpeed = 1f;
    public Vector3 _mStartScale = Vector3.one;
    private DateTime _mTimer = DateTime.Now;

    private void Update()
    {
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
        if (_mIsEnabled)
        {
            Vector3 scale = transform.localScale;
            scale += _mScale * (elapsed * _mSpeed);
            scale.x = Mathf.Max(scale.x, 0f);
            scale.y = Mathf.Max(scale.y, 0f);
            scale.z = Mathf.Max(scale.z, 0f);
            transform.localScale = scale;
        }
        else
        {
            transform.localScale = _mStartScale;
        }
    }
}
