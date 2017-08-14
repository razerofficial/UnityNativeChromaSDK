using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKPlayOnEnable : MonoBehaviour
{
    /// <summary>
    /// Name of the animation in the StreamingAssets folder
    /// </summary>
    public string AnimationName = string.Empty;

    // Play the animation on enable
    void OnEnable()
    {
        string animationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        if (!string.IsNullOrEmpty(animationName))
        {
            UnityNativeChromaSDK.PlayAnimation(animationName);
        }
    }

    /// <summary>
    /// Stop the animation on disable
    /// </summary>
    private void OnDisable()
    {
        string animationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        if (!string.IsNullOrEmpty(animationName))
        {
            UnityNativeChromaSDK.StopAnimation(animationName);
        }
    }

    private void Awake()
    {
        UnityNativeChromaSDK.Init();
    }

    private void OnApplicationQuit()
    {
        UnityNativeChromaSDK.Uninit();
    }
}
