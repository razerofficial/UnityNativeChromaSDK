using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaPositionsOverTimeLerp : MonoBehaviour
{
    public Vector3[] _mPositions = new Vector3[1];
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
        if (_mPositions.Length > 2)
        {
            pos = NG.Vector3Ext.MultiLerp(_mPositions, t);
        }
        else if (_mPositions.Length == 2)
        {
            Vector3 pos1 = _mPositions[0];
            Vector3 pos2 = _mPositions[1];
            pos.x = Mathf.Lerp(pos1.x, pos2.x, t);
            pos.y = Mathf.Lerp(pos1.y, pos2.y, t);
            pos.z = Mathf.Lerp(pos1.z, pos2.z, t);
        }
        else if (_mPositions.Length == 1)
        {
            pos.x = _mPositions[0].x;
            pos.y = _mPositions[0].y;
            pos.z = _mPositions[0].z;
        }
        transform.localPosition = pos;
    }
}
