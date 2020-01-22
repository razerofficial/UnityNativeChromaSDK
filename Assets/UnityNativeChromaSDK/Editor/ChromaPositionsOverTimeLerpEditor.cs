using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChromaPositionsOverTimeLerp))]
public class ChromaPositionsOverTimeLerpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Add Point"))
        {
            if (target)
            {
                ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
                if (item._mPositions != null)
                {
                    Vector3[] positions = new Vector3[item._mPositions.Length + 1];
                    System.Array.Copy(item._mPositions, positions, item._mPositions.Length);
                    Vector3 pos = item.transform.position;
                    positions[positions.Length - 1] = pos;
                    item._mPositions = positions;
                }
            }
        }
        base.OnInspectorGUI();
    }
}
