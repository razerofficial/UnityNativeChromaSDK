using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChromaPositionsOverTimeLerp))]
public class ChromaPositionsOverTimeLerpEditor : Editor
{
    void AddPoint()
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

    void OnSceneGUI()
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.keyUp:
                {
                    if (Event.current.keyCode == (KeyCode.P))
                    {
                        AddPoint();
                    }
                    break;
                }
        }
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Clear Points"))
        {
            if (target)
            {
                ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
                item._mPositions = new Vector3[0];
            }
        }
        if (GUILayout.Button("Add Point"))
        {
            AddPoint();
        }
        base.OnInspectorGUI();
    }
}
