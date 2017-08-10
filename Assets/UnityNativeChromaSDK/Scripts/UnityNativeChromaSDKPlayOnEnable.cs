using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKPlayOnEnable : MonoBehaviour
{
    /// <summary>
    /// Name of the animation in the StreamingAssets folder
    /// </summary>
    public string AnimationName = string.Empty;

    /// <summary>
    /// Get the animation name with the .chroma extension
    /// </summary>
    /// <returns></returns>
    string GetAnimationName()
    {
        if (!string.IsNullOrEmpty(AnimationName))
        {
            string animationName;
            if (!AnimationName.EndsWith(".chroma"))
            {
                animationName = string.Format("{0}.chroma", AnimationName);
            }
            else
            {
                animationName = AnimationName;
            }
            return animationName;
        }
        else
        {
            return string.Empty;
        }
    }

    // Play the animation on enable
    void OnEnable()
    {
        string animationName = GetAnimationName();
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
        string animationName = GetAnimationName();
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
