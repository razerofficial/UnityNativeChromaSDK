using System;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
#endif
public class ChromaMaterialColorOverTime : MonoBehaviour
{
    public Color _mToColor = Color.white;
    public float _mSpeed = 1f;
    private DateTime _mTimer = DateTime.Now;

    private void OnEnable()
    {
        _mTimer = DateTime.Now;
    }

    private void Update()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            Material material = meshRenderer.material;
            if (material)
            {
                Color color = material.color;
                float elapsed = (float)(DateTime.Now - _mTimer).TotalSeconds;
                _mTimer = DateTime.Now;
                color = Color.Lerp(color, _mToColor, elapsed * _mSpeed);
                material.color = color;
            }
        }
    }
}
