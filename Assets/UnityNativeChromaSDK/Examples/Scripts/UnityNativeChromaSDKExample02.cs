using UnityEngine;
#if !UNITY_3 && !UNITY_3_0 && !UNITY_3_1 && !UNITY_3_2 && !UNITY_3_3 && !UNITY_3_4 && !UNITY_3_5 && !UNITY_4 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5 && !UNITY_4_6 && !UNITY_4_7
using UnityEngine.SceneManagement;
#endif

public class UnityNativeChromaSDKExample02 : MonoBehaviour
{

    private void OnGUI()
    {
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Load Scene 1"))
        {
#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            Application.LoadLevel(0);
#else
            SceneManager.LoadScene(0);
#endif
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }
}
