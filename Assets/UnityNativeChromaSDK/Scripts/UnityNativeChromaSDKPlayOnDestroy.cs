using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKPlayOnDestroy : MonoBehaviour
{
    /// <summary>
    /// Name of the animation in the StreamingAssets folder
    /// </summary>
    public string AnimationName = string.Empty;

    // Play the animation on enable
    void OnDestroy()
    {
		// Turn off script if platform is not supported
		if (!UnityNativeChromaSDK.IsPlatformSupported())
		{
			enabled = false;
			return;
		}

        string animationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        UnityNativeChromaSDK.PlayAnimationName(animationName);
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
