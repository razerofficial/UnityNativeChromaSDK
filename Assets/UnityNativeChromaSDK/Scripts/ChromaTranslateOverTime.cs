using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaTranslateOverTime : MonoBehaviour
{
    public bool _mIsEnabled = false;
    public Vector3 _mDirection = Vector3.zero;
    public float _mSpeed = 1f;
    private Vector3 _mStartPosition = Vector3.zero;
    private DateTime _mTimer = DateTime.Now;

    private void Update()
    {
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
        if (_mIsEnabled)
        {
            Vector3 pos = transform.position;
            pos += _mDirection * (elapsed * _mSpeed);
            transform.position = pos;
        }
        else
        {
            transform.position = _mStartPosition;
        }
    }
}
