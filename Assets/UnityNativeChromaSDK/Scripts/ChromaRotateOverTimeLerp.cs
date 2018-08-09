using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaRotateOverTimeLerp : MonoBehaviour
{
    public Vector3 _mRotationStart = Vector3.zero;
	public Vector3 _mRotationEnd = Vector3.zero;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;
	private float _mTime = 0;

    private void OnEnable()
    {
        _mTimer = DateTime.Now;
    }

    private void Update()
    {
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
		_mTime += _mSpeed * elapsed;
		float t = Mathf.Abs(Mathf.Cos(Mathf.PI * _mTime));
		Vector3 rot;
		rot.x = Mathf.Lerp(_mRotationStart.x, _mRotationEnd.x, t);
		rot.y = Mathf.Lerp(_mRotationStart.y, _mRotationEnd.y, t);
		rot.z = Mathf.Lerp(_mRotationStart.z, _mRotationEnd.z, t);
        transform.localRotation = Quaternion.Euler(rot.x, rot.y, rot.z);
    }
}
