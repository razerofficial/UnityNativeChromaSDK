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
		// Turn off script if platform is not supported
		if (!UnityNativeChromaSDK.IsPlatformSupported())
		{
			enabled = false;
			return;
		}

        _mAnimationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        UnityNativeChromaSDK.PlayAnimationName(_mAnimationName, Loop);
    }

    /// <summary>
    /// Stop the animation on disable
    /// </summary>
    private void OnDisable()
    {
        UnityNativeChromaSDK.StopAnimationName(_mAnimationName);
    }

    private void OnApplicationQuit()
    {
        UnityNativeChromaSDK.Uninit();
    }
}
