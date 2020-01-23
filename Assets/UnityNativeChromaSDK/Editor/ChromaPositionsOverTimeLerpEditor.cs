using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChromaPositionsOverTimeLerp))]
public class ChromaPositionsOverTimeLerpEditor : Editor
{
    private int _mIndex = 0;
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

    void UpdatePoint()
    {
        if (target)
        {
            ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
            if (item._mPositions != null &&
                item._mPositions.Length > 0 &&
                _mIndex < item._mPositions.Length)
            {
                item._mPositions[_mIndex] = item.transform.position;
            }
        }
    }

    void MoveToPoint()
    {
        if (target)
        {
            ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
            if (item._mPositions.Length > 0 &&
                _mIndex < item._mPositions.Length)
            {
                item.transform.position = item._mPositions[_mIndex];
            }
        }
    }

    void PreviousPoint()
    {
        if (target)
        {
            ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
            if (item._mPositions == null)
            {
                return;
            }
            if (_mIndex > 0)
            {
                --_mIndex;
            }
            MoveToPoint();
        }
    }

    void NextPoint()
    {
        if (target)
        {
            ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
            if (item._mPositions == null)
            {
                return;
            }
            if ((_mIndex + 1) < (item._mPositions.Length - 1))
            {
                ++_mIndex;
            }
            else
            {
                _mIndex = item._mPositions.Length - 1;
            }
            MoveToPoint();
        }
    }


    void OnSceneGUI()
    {
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.keyUp:
                if (Event.current.keyCode == KeyCode.P)
                {
                    AddPoint();
                }
                else if (Event.current.keyCode == KeyCode.U)
                {
                    UpdatePoint();
                }
                else if (Event.current.keyCode == KeyCode.LeftBracket)
                {
                    PreviousPoint();
                }
                else if (Event.current.keyCode == KeyCode.RightBracket)
                {
                    NextPoint();
                }
                break;
        }
    }

    public override void OnInspectorGUI()
    {
        if (target)
        {
            ChromaPositionsOverTimeLerp item = (ChromaPositionsOverTimeLerp)target;
            if (item._mPositions == null)
            {
                item._mPositions = new Vector3[0];
            }
            if (GUILayout.Button("Clear Points"))
            {
                item._mPositions = new Vector3[0];
            }
            if (GUILayout.Button("(P) Add Point"))
            {
                AddPoint();
            }
            if (GUILayout.Button("(U) Update Point"))
            {
                UpdatePoint();
            }
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("[ Previous"))
            {
                PreviousPoint();
            }
            if (GUILayout.Button("] Next"))
            {
                NextPoint();
            }
            GUILayout.Label(string.Format("Index: {0} of {1}", _mIndex, item._mPositions.Length - 1));
            GUILayout.EndHorizontal();
        }
        base.OnInspectorGUI();
    }
}
