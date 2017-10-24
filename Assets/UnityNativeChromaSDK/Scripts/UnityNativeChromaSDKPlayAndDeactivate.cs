using ChromaSDK;
using UnityEngine;

public class UnityNativeChromaSDKPlayAndDeactivate: MonoBehaviour
{
    /// <summary>
    /// Name of the animation in the StreamingAssets folder
    /// </summary>
    public string AnimationName = string.Empty;

    /// <summary>
    /// Cache the name with extension
    /// </summary>
    private string _mAnimationName = string.Empty;

    /// <summary>
    /// Reactivate the animation scripts
    /// </summary>
    public void Activate()
    {
        // reactivate animation scripts in the on enable event
        // this is so each animation can play and deactivate itself
        UnityNativeChromaSDKPlayAndDeactivate[] animations =
            gameObject.GetComponents<UnityNativeChromaSDKPlayAndDeactivate>();
        foreach (UnityNativeChromaSDKPlayAndDeactivate animation in animations)
        {
            animation.enabled = true;
        }

#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
        gameObject.active = true;
#else
        gameObject.SetActive(true);
#endif
    }

    // Play the animation on enable
    void OnEnable()
    {
		// Turn off script if platform is not supported
		if (!UnityNativeChromaSDK.IsPlatformSupported())
		{
			enabled = false;
			return;
		}
		
        // play the animation in the on enable event
        _mAnimationName = UnityNativeChromaSDK.GetAnimationNameWithExtension(AnimationName);
        UnityNativeChromaSDK.PlayAnimationName(_mAnimationName);
    }

    /// <summary>
    /// Stop the animation on disable
    /// </summary>
    private void OnDisable()
    {
        UnityNativeChromaSDK.StopAnimationName(_mAnimationName);
    }

    private void FixedUpdate()
    {
        if (!UnityNativeChromaSDK.IsPlaying(_mAnimationName))
        {
            //Debug.Log(string.Format("Animation is done: {0}", _mAnimationName));
            enabled = false;
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
