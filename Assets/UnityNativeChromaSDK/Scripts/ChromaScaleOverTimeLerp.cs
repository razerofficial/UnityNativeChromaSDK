using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaScaleOverTimeLerp : MonoBehaviour
{
	public Vector3 _mScaleStart = Vector3.one;
	public Vector3 _mScaleEnd = Vector3.one;
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
		Vector3 scale;
		scale.x = Mathf.Lerp(_mScaleStart.x, _mScaleEnd.x, t);
		scale.y = Mathf.Lerp(_mScaleStart.y, _mScaleEnd.y, t);
		scale.z = Mathf.Lerp(_mScaleStart.z, _mScaleEnd.z, t);
        transform.localScale = scale;
    }
}
