using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaTranslateOverTimeLerp : MonoBehaviour
{
    public Vector3 _mPositionStart = Vector3.zero;
	public Vector3 _mPositionEnd = Vector3.zero;
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
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        _mTimer = DateTime.Now;
		_mTime += _mSpeed * elapsed;
        float t = 1 - Mathf.Abs(Mathf.Cos(Mathf.PI * _mTime));
		Vector3 pos = transform.position;
		pos.x = Mathf.Lerp(_mPositionStart.x, _mPositionEnd.x, t);
		pos.y = Mathf.Lerp(_mPositionStart.y, _mPositionEnd.y, t);
		pos.z = Mathf.Lerp(_mPositionStart.z, _mPositionEnd.z, t);
        transform.localPosition = pos;
    }
}
