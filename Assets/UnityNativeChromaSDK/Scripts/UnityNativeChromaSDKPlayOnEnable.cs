using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKPlayOnEnable : MonoBehaviour
{
    /// <summary>
    /// Name of the animation in the StreamingAssets folder
    /// </summary>
    public string AnimationName = string.Empty;

    /// <summary>
    /// Loop the animation
    /// </summary>
    public bool Loop = false;

    /// <summary>
    /// Cache the name with extension
    /// </summary>
    private string _mAnimationName = string.Empty;

    // Play the animation on enable
    void OnEnable()
    {
        _mAnimationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        UnityNativeChromaSDK.PlayAnimation(_mAnimationName);
    }

    /// <summary>
    /// Stop the animation on disable
    /// </summary>
    private void OnDisable()
    {
        UnityNativeChromaSDK.StopAnimation(_mAnimationName);
    }

    private void FixedUpdate()
    {
        if (Loop)
        {
            if (!UnityNativeChromaSDK.IsPlaying(_mAnimationName))
            {
                UnityNativeChromaSDK.PlayAnimation(_mAnimationName);
            }
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
