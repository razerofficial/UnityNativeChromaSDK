using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaSetCameraColor : MonoBehaviour
{
    public Color _mColor = Color.black;

    private void Update()
    {
        Camera camera = GetComponent<Camera>();
        if (camera)
        {
            camera.backgroundColor = _mColor;
        }
    }
}
