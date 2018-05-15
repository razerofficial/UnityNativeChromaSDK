using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaSetScale : MonoBehaviour
{
    public Vector3 _mScale = Vector3.one;

    private void Update()
    {
        transform.localScale = _mScale;
    }
}
