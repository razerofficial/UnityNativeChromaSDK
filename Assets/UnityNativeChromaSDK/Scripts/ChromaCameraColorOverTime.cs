using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaCameraColorOverTime : MonoBehaviour
{
    public Color _mToColor = Color.white;
    public float _mSpeed = 1f;
    private Color _mFromColor = Color.black;
    private DateTime _mTimer = DateTime.Now;

    private void OnEnable()
    {
        Camera camera = GetComponent<Camera>();
        if (camera)
        {
            _mFromColor = camera.backgroundColor;
        }
        _mTimer = DateTime.Now;
    }

    private void Update()
    {
        float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
        Color color = Color.Lerp(_mFromColor, _mToColor, elapsed * _mSpeed);

        Camera camera = GetComponent<Camera>();
        if (camera)
        {
            camera.backgroundColor = color;
        }
    }
}
