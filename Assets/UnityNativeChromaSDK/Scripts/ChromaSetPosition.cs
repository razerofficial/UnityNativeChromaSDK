using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaSetPosition : MonoBehaviour
{
    public Vector3 _mPosition = Vector3.zero;

    private void OnEnable()
    {
        transform.localPosition = _mPosition;
    }
}
