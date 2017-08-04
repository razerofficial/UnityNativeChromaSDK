using UnityEngine;

public class UnityNativeChromaSDKExample01 : MonoBehaviour
{
    readonly string[] _mAnimations =
    {
        "ChromaLinkEffect.chroma",
        "HeadsetEffect.chroma",
        "KeyboardCoolFireAnimation.chroma",
        "KeyboardEffect.chroma",
        "KeyboardParticleAnimation.chroma",
        "KeyboardParticleAnimation2.chroma",
        "KeypadEffect.chroma",
        "MouseEffect.chroma",
        "MousepadEffect.chroma",
        "RandomChromaLinkEffect.chroma",
        "RandomHeadsetEffect.chroma",
        "RandomKeyboardEffect.chroma",
        "RandomKeypadEffect.chroma",
        "RandomMouseEffect.chroma",
        "RandomMousepadEffect.chroma",
    };
    private void OnGUI()
    {
        GUILayout.BeginVertical(GUILayout.Height(Screen.height));
        GUILayout.FlexibleSpace();
        foreach (string animation in _mAnimations)
        {
            GUILayout.BeginHorizontal(GUILayout.Width(Screen.width));
            GUILayout.FlexibleSpace();
            GUILayout.Label(animation);
            if (GUILayout.Button("Play", GUILayout.Height(30)))
            {

            }
            if (GUILayout.Button("Stop", GUILayout.Height(30)))
            {

            }
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
    }
}
