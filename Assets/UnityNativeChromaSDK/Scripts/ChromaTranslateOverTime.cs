using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaTranslateOverTime : MonoBehaviour
{
    public Vector3 _mDirection = Vector3.zero;
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
        Vector3 pos = transform.position;
        pos += _mDirection * (elapsed * _mSpeed);
        transform.position = pos;
    }
}
