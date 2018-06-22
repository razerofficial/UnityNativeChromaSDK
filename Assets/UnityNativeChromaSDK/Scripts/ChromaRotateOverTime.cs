using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaRotateOverTime : MonoBehaviour
{
    public Vector3 _mRotation = Vector3.zero;
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
        transform.Rotate(_mRotation * _mSpeed * elapsed);
    }
}
