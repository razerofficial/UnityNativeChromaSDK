//#define VERBOSE_LOGGING

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace ChromaSDK
{
    public class UnityNativeChromaSDK
    {
#if UNITY_3 || UNITY_3_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
        const string DLL_NAME = "UnityNativeChromaSDK3";

#else
        const string DLL_NAME = "UnityNativeChromaSDK";
#endif

		/// <summary>
		/// Get the plugin version
		/// </summary>
		/// <returns></returns>
		public static string GetVersion()
		{
			return "1.11";
		}

        /// <summary>
        /// Returns true if the platform is supported
        /// false if not supported
        /// </summary>
        /// <returns></returns>
        public static bool IsPlatformSupported()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            try
            {
                return PluginIsPlatformSupported();
            }
            catch (Exception)
            {
                return false;
            }
#else
            return false;
#endif
        }

		/// <summary>
		/// Initialize and clear the loaded animations dictionary
		/// </summary>
		public static int Init()
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (!UnityNativeChromaSDK.IsPlatformSupported())
            {
                return -1;
            }
            bool isInitialized = false;
            try
            {
                isInitialized = PluginIsInitialized();
            }
            catch (Exception)
            {
            }
			if (!isInitialized)
			{
                int result = -1;
                try
                {
                    result = PluginInit();
                }
                catch (Exception)
                {
                }
				return result;
			}
			//ignore: already initialized
			return 0;
#else
			return -1;
#endif
		}

		/// <summary>
		/// Uninitialize and clear the loaded animations dictionary
		/// </summary>
		/// <returns></returns>
		public static int Uninit()
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            if (!UnityNativeChromaSDK.IsPlatformSupported())
            {
                return -1;
            }
            bool isInitialized = false;
            try
            {
                isInitialized = PluginIsInitialized();
            }
            catch (Exception)
            {
            }
			if (isInitialized)
			{
                int result = -1;
                try
                {
                    result = PluginUninit();
                }
                catch (Exception)
                {
                }
				return result;
			}
			//ignore: already uninitialized
			return 0;
#else
			return -1;
#endif
		}

		/// <summary>
		/// Get the animation name with the .chroma extension
		/// </summary>
		/// <returns></returns>
		public static string GetAnimationNameWithExtension(string animation)
		{
			if (string.IsNullOrEmpty(animation))
			{
				return string.Empty;
			}
			if (animation.EndsWith(".chroma"))
			{
				return animation;
			}
			return string.Format("{0}.chroma", animation);
		}

		/// <summary>
		/// Get the animation id given an animation name,
		/// Store the opened animation and reference by animation name
		/// Returns -1 if failure occurred
		/// else returns the animation id
		/// </summary>
		/// <param name="animation"></param>
		/// <returns></returns>
		public static int GetAnimation(string animation)
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			if (string.IsNullOrEmpty(animation))
			{
				return -1;
			}
			string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            int animationId = -1;
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    animationId = PluginGetAnimation(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to get animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
            /*
            if (animationId == -1)
            {
                Debug.LogError(string.Format("Failed to load animation: {0}", path));
            }
            else
            {
                Debug.Log(string.Format("Loaded animation: {0} {1}", animationId, path));
            }
            */
			return animationId;
#else
			return -1;
#endif
		}

        /// <summary>
        /// Play the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void PlayAnimationName(string animation)
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginPlayAnimationName(lpData, false);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to play animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
		}

        /// <summary>
		/// Play the animation with loop on or off
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static void PlayAnimationName(string animation, bool loop)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginPlayAnimationName(lpData, loop);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to play animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Play composite animation with loop ON or OFF
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loop"></param>
        public static void PlayComposite(string name, bool loop)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(name);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginPlayComposite(lpData, loop);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to play composite: {0} exception={1}", name, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Stop composite animation
        /// </summary>
        /// <param name="name"></param>
        public static void StopComposite(string name)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(name);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginStopComposite(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to stop composite: {0} exception={1}", name, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Check if the animation is playing,
        /// returns true if playing
        /// returns false if not playing
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static bool IsPlaying(string animation)
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			int animationId = GetAnimation(animation);
			if (animationId >= 0)
			{
				bool result = PluginIsPlaying(animationId);
				return result;
			}
			return false;
#else
			return false;
#endif
		}

        /// <summary>
        /// Check if device is playing animation
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static bool IsPlayingType(Device device)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            bool result = false;
            switch (device)
            {
                case Device.ChromaLink:
                    result = PluginIsPlayingType((int)DeviceType.DE_1D, (int)Device1D.ChromaLink);
                    break;
                case Device.Headset:
                    result = PluginIsPlayingType((int)DeviceType.DE_1D, (int)Device1D.Headset);
                    break;
                case Device.Keyboard:
                    result = PluginIsPlayingType((int)DeviceType.DE_2D, (int)Device2D.Keyboard);
                    break;
                case Device.Keypad:
                    result = PluginIsPlayingType((int)DeviceType.DE_2D, (int)Device2D.Keypad);
                    break;
                case Device.Mouse:
                    result = PluginIsPlayingType((int)DeviceType.DE_2D, (int)Device2D.Mouse);
                    break;
                case Device.Mousepad:
                    result = PluginIsPlayingType((int)DeviceType.DE_1D, (int)Device1D.Mousepad);
                    break;

            }
            return result;
#else
			return false;
#endif
        }

        /// <summary>
        /// Stop the animation
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static void StopAnimationName(string animation)
		{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginStopAnimationName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to stop animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
		}

        public static void StopAnimationType(Device device)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            switch (device)
            {
                case Device.ChromaLink:
                    PluginStopAnimationType((int)DeviceType.DE_1D, (int)Device1D.ChromaLink);
                    break;
                case Device.Headset:
                    PluginStopAnimationType((int)DeviceType.DE_1D, (int)Device1D.Headset);
                    break;
                case Device.Keyboard:
                    PluginStopAnimationType((int)DeviceType.DE_2D, (int)Device2D.Keyboard);
                    break;
                case Device.Keypad:
                    PluginStopAnimationType((int)DeviceType.DE_2D, (int)Device2D.Keypad);
                    break;
                case Device.Mouse:
                    PluginStopAnimationType((int)DeviceType.DE_2D, (int)Device2D.Mouse);
                    break;
                case Device.Mousepad:
                    PluginStopAnimationType((int)DeviceType.DE_1D, (int)Device1D.Mousepad);
                    break;

            }
#endif
        }

        /// <summary>
        /// Set the animation frame's key to the supplied color
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        /// <param name="color"></param>
        public static void SetKeyColorName(string animation, int frameId, int rzkey, Color color)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginSetKeyColorName(lpData, frameId, rzkey, ToBGR(color));
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to set key color: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Set the key to the supplied color for all animation frames
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        /// <param name="color"></param>
        public static void SetKeyColorAllFramesName(string animation, int rzkey, Color color)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    int frameCount = GetFrameCountName(animation);
                    for (int frameId = 0; frameId < frameCount; ++frameId)
                    {
                        PluginSetKeyColorName(lpData, frameId, rzkey, ToBGR(color));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to set key color: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Set the animation frame to the supplied color for a set of keys
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="frameId"></param>
        /// <param name="keys"></param>
        /// <param name="color"></param>
        public static void SetKeysColorName(string animation, int frameId, int[] keys, Color color)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    foreach (int rzkey in keys)
                    {
                        PluginSetKeyColorName(lpData, frameId, rzkey, ToBGR(color));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to set keys color: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Set the keys to the supplied color for all animation frames
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="frameId"></param>
        /// <param name="keys"></param>
        /// <param name="color"></param>
        public static void SetKeysColorAllFramesName(string animation, int[] keys, Color color)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    int frameCount = GetFrameCountName(animation);
                    foreach (int rzkey in keys)
                    {
                        for (int frameId = 0; frameId < frameCount; ++frameId)
                        {
                            PluginSetKeyColorName(lpData, frameId, rzkey, ToBGR(color));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to set keys color: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Copy color from a source animation to a target animation for a key
        /// </summary>
        /// <param name="sourceAnimation"></param>
        /// <param name="targetAnimation"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        public static void CopyKeyColorName(string sourceAnimation, string targetAnimation, int frameId, int rzkey)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string sourcePath = GetStreamingPath(sourceAnimation);
            string targetPath = GetStreamingPath(targetAnimation);
            IntPtr sourceLpData = GetIntPtr(sourcePath);
            IntPtr targetLpData = GetIntPtr(targetPath);
            try
            {
                if (sourceLpData != IntPtr.Zero)
                {
                    PluginCopyKeyColorName(sourceLpData, targetLpData, frameId, rzkey);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to copy key color: source={0} target={1} exception={2}", sourceAnimation, targetAnimation, ex));
            }
            FreeIntPtr(sourceLpData);
            FreeIntPtr(targetLpData);
#endif
        }

        /// <summary>
        /// Copy color from a source animation to a target animation for a key for all frames
        /// </summary>
        /// <param name="sourceAnimation"></param>
        /// <param name="targetAnimation"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        public static void CopyKeyColorAllFramesName(string sourceAnimation, string targetAnimation, int rzkey)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string sourcePath = GetStreamingPath(sourceAnimation);
            string targetPath = GetStreamingPath(targetAnimation);
            IntPtr sourceLpData = GetIntPtr(sourcePath);
            IntPtr targetLpData = GetIntPtr(targetPath);
            try
            {
                if (sourceLpData != IntPtr.Zero)
                {
                    int frameCount = GetFrameCountName(targetAnimation);
                    for (int frameId = 0; frameId < frameCount; ++frameId)
                    {
                        PluginCopyKeyColorName(sourceLpData, targetLpData, frameId, rzkey);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to copy key color: source={0} target={1} exception={2}", sourceAnimation, targetAnimation, ex));
            }
            FreeIntPtr(sourceLpData);
            FreeIntPtr(targetLpData);
#endif
        }

        /// <summary>
        /// Copy color from a source animation to a target animation for a set of keys
        /// </summary>
        /// <param name="sourceAnimation"></param>
        /// <param name="targetAnimation"></param>
        /// <param name="frameId"></param>
        /// <param name="keys"></param>
        public static void CopyKeysColorName(string sourceAnimation, string targetAnimation, int frameId, int[] keys)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string sourcePath = GetStreamingPath(sourceAnimation);
            string targetPath = GetStreamingPath(targetAnimation);
            IntPtr sourceLpData = GetIntPtr(sourcePath);
            IntPtr targetLpData = GetIntPtr(targetPath);
            try
            {
                if (sourceLpData != IntPtr.Zero)
                {
                    foreach (int rzkey in keys)
                    {
                        PluginCopyKeyColorName(sourceLpData, targetLpData, frameId, rzkey);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to copy keys color: source={0} target={1} exception={2}", sourceAnimation, targetAnimation, ex));
            }
            FreeIntPtr(sourceLpData);
            FreeIntPtr(targetLpData);
#endif
        }

        /// <summary>
        /// Copy color from a source animation to a target animation for a set of keys for all frames
        /// </summary>
        /// <param name="sourceAnimation"></param>
        /// <param name="targetAnimation"></param>
        /// <param name="frameId"></param>
        /// <param name="keys"></param>
        public static void CopyKeysColorAllFramesName(string sourceAnimation, string targetAnimation, int[] keys)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string sourcePath = GetStreamingPath(sourceAnimation);
            string targetPath = GetStreamingPath(targetAnimation);
            IntPtr sourceLpData = GetIntPtr(sourcePath);
            IntPtr targetLpData = GetIntPtr(targetPath);
            try
            {
                if (sourceLpData != IntPtr.Zero &&
                    targetLpData != IntPtr.Zero)
                {
                    int frameCount = GetFrameCountName(targetAnimation);
                    foreach (int rzkey in keys)
                    {
                        for (int frameId = 0; frameId < frameCount; ++frameId)
                        {
                            PluginCopyKeyColorName(sourceLpData, targetLpData, frameId, rzkey);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to copy keys color: source={0} target={1} exception={2}", sourceAnimation, targetAnimation, ex));
            }
            FreeIntPtr(sourceLpData);
            FreeIntPtr(targetLpData);
#endif
        }

        /// <summary>
        /// Copy color from a source animation to a target animation for a set of keys that aren't black for all frames
        /// </summary>
        /// <param name="sourceAnimation"></param>
        /// <param name="targetAnimation"></param>
        /// <param name="frameId"></param>
        /// <param name="keys"></param>
        public static void CopyNonZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string sourcePath = GetStreamingPath(sourceAnimation);
            string targetPath = GetStreamingPath(targetAnimation);
            IntPtr sourceLpData = GetIntPtr(sourcePath);
            IntPtr targetLpData = GetIntPtr(targetPath);
            try
            {
                if (sourceLpData != IntPtr.Zero &&
                    targetLpData != IntPtr.Zero)
                {
                    PluginCopyNonZeroAllKeysAllFramesName(sourceLpData, targetLpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to copy nonzero keys color: source={0} target={1} exception={2}", sourceAnimation, targetAnimation, ex));
            }
            FreeIntPtr(sourceLpData);
            FreeIntPtr(targetLpData);
#endif
        }

        /// <summary>
        /// Offset the RGB color for keys that are not black for all frames
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
		public static void OffsetNonZeroColorsAllFramesName(string animation, int red, int green, int blue)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginOffsetNonZeroColorsAllFramesName(lpData, red, green, blue);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to offset nonzero color animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

        /// <summary>
        /// Multiple the color intensity of all frames
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="intensity"></param>
		public static void MultiplyIntensityAllFramesName(string animation, float intensity)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginMultiplyIntensityAllFramesName(lpData, intensity);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to multiply intensity animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
#endif
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

        /// <summary>
        /// Is the platform supported?
        /// </summary>
        [DllImport(DLL_NAME)]
        public static extern bool PluginIsPlatformSupported();

        /// <summary>
        /// Is the plugin initialized
        /// </summary>
        [DllImport(DLL_NAME)]
        public static extern bool PluginIsInitialized();

        /// <summary>
        /// Is the editor dialog open?
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern bool PluginIsDialogOpen();

        /// <summary>
        /// Open the editor dialog and play animation on open
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginOpenEditorDialogAndPlay(IntPtr path);

        /// <summary>
        /// Open a chroma animation, returns -1 if failed to open,
        /// otherwise returns the id of the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginOpenAnimation(IntPtr path);

        /// <summary>
        /// Load animation effects
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginLoadAnimation(int animationId);

        /// <summary>
        /// Unload animation effects
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginUnloadAnimation(int animationId);

        /// <summary>
        /// Play animation
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginPlayAnimation(int animationId);

        /// <summary>
        /// Is animation playing?
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern bool PluginIsPlaying(int animationId);

        /// <summary>
        /// Stop animation
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginStopAnimation(int animationId);

        /// <summary>
        /// Close animation
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginCloseAnimation(int animationId);

        /// <summary>
        /// Init the plugin
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginInit();

        /// <summary>
        /// Create a chroma animation, returns -1 if failed to create, otherwise returns the id of the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginCreateAnimation(IntPtr path, int deviceType, int device);

        /// <summary>
        /// Uninit the plugin
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginUninit();

        /// <summary>
        /// Save a chroma animation, returns -1 if failed to save, otherwise returns the id of the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginSaveAnimation(int animationId, IntPtr path);

        /// <summary>
        /// Reset a chroma animation, returns -1 if failed to reset, otherwise returns the id of the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginResetAnimation(int animationId);

        /// <summary>
        /// Get the device type of a chroma animation, returns -1 if failed to get data, otherwise returns the device type
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetDeviceType(int animationId);

        /// <summary>
        /// Get the device of a chroma animation, returns -1 if failed to get data, otherwise returns the device type
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetDevice(int animationId);

        /// <summary>
        /// Set the device of a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="animationId"></param>
        /// <param name="deviceType"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginSetDevice(int animationId, int deviceType, int device);

        /// <summary>
        /// Get the frame count of a chroma animation,
        /// returns -1 if failed to get data, otherwise returns the number of frames
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginGetFrameCount(int animationId);

        /// <summary>
        /// Get the frame count
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetFrameCountName(IntPtr path);

        /// <summary>
        /// Get the current frame of a chroma animation,
        /// returns -1 if failed to get data, otherwise returns the current frame
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginGetCurrentFrame(int animationId);

        /// <summary>
        /// Get the current frame
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetCurrentFrameName(IntPtr path);

        /// <summary>
        /// Set key color for a frame
        /// </summary>
        /// <param name="path"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        /// <param name="color"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginSetKeyColorName(IntPtr path, int frameId, int rzkey, int color);

        /// <summary>
        /// Copy from a source animation to set a target key color for a frame
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <param name="frameId"></param>
        /// <param name="rzkey"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginCopyKeyColorName(IntPtr sourcePath, IntPtr targetPath, int frameId, int rzkey);

        /// <summary>
        /// Copy from a source animation to set a target key color for nonzero colors for a frame
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginCopyNonZeroAllKeysAllFramesName(IntPtr sourcePath, IntPtr targetPath);

        /// <summary>
        /// Clear all playing animations
        /// </summary>
        [DllImport(DLL_NAME)]
        public static extern void PluginClearAll();

        /// <summary>
        /// Offset all nonzero keys that aren't black for all frames
        /// </summary>
        /// <param name="path"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginOffsetNonZeroColorsAllFramesName(IntPtr path, int red, int green, int blue);

        /// <summary>
        /// Multiply the color intensity of all frames
        /// </summary>
        /// <param name="path"></param>
        /// <param name="intensity"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginMultiplyIntensityAllFramesName(IntPtr path, float intensity);

        /// <summary>
        /// Get the Max Leds for 1D Devices
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetMaxLeds(int device);

        /// <summary>
        /// Get the Max Row for 2D Devices
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetMaxRow(int device);

        /// <summary>
        /// Get the Max Column for 2D Devices
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetMaxColumn(int device);

        /// <summary>
        /// Add a frame to the end of a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PluginAddFrame(int animationId, float duration, int[] colors, int length);

        /// <summary>
        /// Update a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PluginUpdateFrame(int animationId, int frameIndex, float duration, int[] colors, int length);

        /// <summary>
        /// Get a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern int PluginGetFrame(int animationId, int frameIndex, out float duration, int[] colors, int length);

        /// <summary>
        /// Preview a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginPreviewFrame(int animationId, int frameIndex);

        /// Override duration for all frames for a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        [DllImport(DLL_NAME)]
        public static extern int PluginOverrideFrameDuration(int animationId, float duration);

        /// Reverse the frames for a chroma animation, returns -1 on failure, otherwise returns the animation id
        [DllImport(DLL_NAME)]
        public static extern int PluginReverse(int animationId);

        /// Mirrors the frames horizontally for a chroma animation, returns -1 on failure, otherwise returns the animation id
        [DllImport(DLL_NAME)]
        public static extern int PluginMirrorHorizontally(int animationId);

        /// Mirrors the frames vertically for a chroma animation, returns -1 on failure, otherwise returns the animation id
        [DllImport(DLL_NAME)]
        public static extern int PluginMirrorVertically(int animationId);

        /// <summary>
        /// Open a chroma animation, returns -1 if failed to open,
        /// otherwise returns the id of the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginGetAnimation(IntPtr path);

        /// <summary>
        /// Close the animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginCloseAnimationName(IntPtr path);

        /// <summary>
        /// Play animation with looping on or off
        /// </summary>
        /// <param name="animationId"></param>
        /// <param name="loop"></param>
        [DllImport(DLL_NAME)]
        public static extern void PluginPlayAnimationLoop(int animationId, bool loop);

        /// <summary>
        /// Play animation with looping on or off by path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loop"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginPlayAnimationName(IntPtr path, bool loop);

        /// <summary>
        /// Stop animation by path
        /// </summary>
        /// <param name="path"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginStopAnimationName(IntPtr path);

        /// <summary>
        /// Stop animation by type
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="device"></param>
        [DllImport(DLL_NAME)]
        public static extern void PluginStopAnimationType(int deviceType, int device);

        /// <summary>
        /// Check if animation is playing by name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern bool PluginIsPlayingName(IntPtr path);

        /// <summary>
        /// Check if animation is playing by type
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern bool PluginIsPlayingType(int deviceType, int device);

        /// <summary>
        /// Play composite animation by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loop"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginPlayComposite(IntPtr name, bool loop);

        /// <summary>
        /// Stop composite animation by name
        /// </summary>
        /// <param name="name"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginStopComposite(IntPtr name);

        /// <summary>
        /// Set the current frame
        /// </summary>
        /// <param name="path"></param>
        /// <param name="frameId"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginSetCurrentFrameName(IntPtr path, int frameId);

        /// <summary>
        /// Pause the animation
        /// </summary>
        /// <param name="path"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginPauseAnimationName(IntPtr path);

        /// <summary>
        /// Check if the animation is paused
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern bool PluginIsAnimationPausedName(IntPtr path);

        /// <summary>
        /// Does the animation have loop on?
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern bool PluginHasAnimationLoopName(IntPtr path);

        /// <summary>
        /// Resume the animation
        /// </summary>
        /// <param name="path"></param>
        /// <param name="loop"></param>
        [DllImport(DLL_NAME)]
        private static extern void PluginResumeAnimationName(IntPtr path, bool loop);

        #region Helpers (handle path conversions)

        /// <summary>
        /// Helper to convert string to IntPtr
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static IntPtr GetIntPtr(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return IntPtr.Zero;
            }
            FileInfo fi = new FileInfo(path);
            byte[] array = ASCIIEncoding.ASCII.GetBytes(fi.FullName + "\0");
            IntPtr lpData = Marshal.AllocHGlobal(array.Length);
            Marshal.Copy(array, 0, lpData, array.Length);
            return lpData;
        }

        /// <summary>
        /// Helper to recycle the IntPtr
        /// </summary>
        /// <param name="lpData"></param>
        private static void FreeIntPtr(IntPtr lpData)
        {
            if (lpData != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(lpData);
            }
        }

        /// <summary>
        /// Open an animation file
        /// Returns -1 if animation not found
        /// Returns >= 0 if animation has opened
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static int OpenAnimation(string animation)
        {
            if (string.IsNullOrEmpty(animation))
            {
                return - 1;
            }
#if VERBOSE_LOGGING
            Debug.Log(string.Format("OpenAnimation: {0}", animation));
#endif
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            int animationId = 1;
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    animationId = PluginOpenAnimation(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to open animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
            return animationId;
        }

        public static int PluginSaveAnimation(int animationId, string animation)
        {
            Init();
            if (string.IsNullOrEmpty(animation))
            {
                return -1;
            }
            int result = -1;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginSaveAnimation(animationId, lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to save animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        public enum DeviceType
        {
            Invalid = -1,
            DE_1D = 0,
            DE_2D = 1,
            MAX = 2,
        }

        public enum Device
        {
            Invalid = -1,
            ChromaLink = 0,
            Headset = 1,
            Keyboard = 2,
            Keypad = 3,
            Mouse = 4,
            Mousepad = 5,
            MAX = 6,
        }

        public enum Device1D
        {
            Invalid = -1,
            ChromaLink = 0,
            Headset = 1,
            Mousepad = 2,
            MAX = 3,
        }

        public enum Device2D
        {
            Invalid = -1,
            Keyboard = 0,
            Keypad = 1,
            Mouse = 2,
            MAX = 3,
        }

        /// <summary>
        /// Get the maxmimum LEDs for the given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxLeds(Device1D device)
        {
            return PluginGetMaxLeds((int)device);
        }

        /// <summary>
        /// Get the max rows for the given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxRow(Device2D device)
        {
            return PluginGetMaxRow((int)device);
        }

        /// <summary>
        /// Get the max columns for the given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxColumn(Device2D device)
        {
            return PluginGetMaxColumn((int)device);
        }

        public static int CreateAnimation(string animation, Device device)
        {
            Init();
            if (string.IsNullOrEmpty(animation))
            {
                return -1;
            }
            int dt = 0;
            int d = 0;
            switch (device)
            {
                case Device.ChromaLink:
                    dt = 0;
                    d = 0;
                    break;
                case Device.Headset:
                    dt = 0;
                    d = 1;
                    break;
                case Device.Keyboard:
                    dt = 1;
                    d = 0;
                    break;
                case Device.Keypad:
                    dt = 1;
                    d = 1;
                    break;
                case Device.Mouse:
                    dt = 1;
                    d = 2;
                    break;
                case Device.Mousepad:
                    dt = 0;
                    d = 2;
                    break;
            }
            int result = -1;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginCreateAnimation(lpData, dt, d);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to create animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        /// <summary>
        /// Get the device type given the animation id
        /// </summary>
        /// <param name="animationId"></param>
        /// <returns></returns>
        public static DeviceType GetDeviceType(int animationId)
        {
            switch (PluginGetDeviceType(animationId))
            {
                case 0:
                    return DeviceType.DE_1D;
                case 1:
                    return DeviceType.DE_2D;
                default:
                    return DeviceType.Invalid;
            }
        }
        public static DeviceType GetDeviceType(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                return GetDeviceType(animationId);
            }
            return DeviceType.Invalid;
        }

        public static Device GetDevice(int animationId)
        {
            switch (GetDeviceType(animationId))
            {
                case DeviceType.DE_1D:
                    switch (PluginGetDevice(animationId))
                    {
                        case (int)Device1D.ChromaLink:
                            return Device.ChromaLink;
                        case (int)Device1D.Headset:
                            return Device.Headset;
                        case (int)Device1D.Mousepad:
                            return Device.Mousepad;
                    }
                    break;
                case DeviceType.DE_2D:
                    switch (PluginGetDevice(animationId))
                    {
                        case (int)Device2D.Keyboard:
                            return Device.Keyboard;
                        case (int)Device2D.Keypad:
                            return Device.Keypad;
                        case (int)Device2D.Mouse:
                            return Device.Mouse;
                    }
                    break;
            }
            return Device.Invalid;
        }
        public static Device GetDevice(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                return GetDevice(animationId);
            }
            return Device.Invalid;
        }

        public static Device1D GetDevice1D(int animationId)
        {
            switch (GetDeviceType(animationId))
            {
                case DeviceType.DE_1D:
                    switch (PluginGetDevice(animationId))
                    {
                        case (int)Device1D.ChromaLink:
                            return Device1D.ChromaLink;
                        case (int)Device1D.Headset:
                            return Device1D.Headset;
                        case (int)Device1D.Mousepad:
                            return Device1D.Mousepad;
                    }
                    break;
            }
            return Device1D.Invalid;
        }

        public static Device2D GetDevice2D(int animationId)
        {
            switch (GetDeviceType(animationId))
            {
                case DeviceType.DE_2D:
                    switch (PluginGetDevice(animationId))
                    {
                        case (int)Device2D.Keyboard:
                            return Device2D.Keyboard;
                        case (int)Device2D.Keypad:
                            return Device2D.Keypad;
                        case (int)Device2D.Mouse:
                            return Device2D.Mouse;
                    }
                    break;
            }
            return Device2D.Invalid;
        }

        public static int SetDevice(string animation, Device device)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                switch (device)
                {
                    case Device.ChromaLink:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_1D, (int)Device1D.ChromaLink);
                    case Device.Headset:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_1D, (int)Device1D.Headset);
                    case Device.Keyboard:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_2D, (int)Device2D.Keyboard);
                    case Device.Keypad:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_2D, (int)Device2D.Keypad);
                    case Device.Mouse:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_2D, (int)Device2D.Mouse);
                    case Device.Mousepad:
                        return PluginSetDevice(animationId, (int)DeviceType.DE_1D, (int)Device1D.Mousepad);
                }
            }
            return animationId;
        }

        public static int GetFrameCountName(string animation)
        {
            int result = -1;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginGetFrameCountName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to get frame count: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        public static int GetCurrentFrameName(string animation)
        {
            int result = -1;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginGetCurrentFrameName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to get current frame: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        public static void SetCurrentFrameName(string animation, int frameId)
        {
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginSetCurrentFrameName(lpData, frameId);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to set current frame: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
        }

        public static bool IsAnimationPausedName(string animation)
        {
            bool result = false;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginIsAnimationPausedName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to get is animation paused: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        public static bool HasAnimationLoopName(string animation)
        {
            bool result = false;
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    result = PluginHasAnimationLoopName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to get has animation loop: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
            return result;
        }

        public static void PauseAnimationName(string animation)
        {
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginPauseAnimationName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to pause animation: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
        }

        public static void ResumeAnimationName(string animation, bool loop)
        {
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginResumeAnimationName(lpData, loop);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to resume animation: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
        }

        /// <summary>
        /// Add a frame to the end of a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="animationId"></param>
        /// <param name="duration"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static int AddFrame(int animationId, float duration, int[] colors)
        {
            return PluginAddFrame(animationId, duration, colors, colors.Length);
        }

        /// <summary>
        /// Update a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="animationId"></param>
        /// <param name="frameIndex"></param>
        /// <param name="duration"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static int UpdateFrame(int animationId, int frameIndex, float duration, int[] colors)
        {
            return PluginUpdateFrame(animationId, frameIndex, duration, colors, colors.Length);
        }

        /// <summary>
        /// Update a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="animationId"></param>
        /// <param name="frameIndex"></param>
        /// <param name="duration"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static int GetFrame(int animationId, int frameIndex, out float duration, int[] colors)
        {
            return PluginGetFrame(animationId, frameIndex, out duration, colors, colors.Length);
        }

        #endregion

        [DllImport(DLL_NAME)]
        private static extern void PluginSetLogDelegate(IntPtr logDelegate);

#if VERBOSE_LOGGING
        #region Handle Debug.Log from unmanged code

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void DebugLogDelegate(string text);

        private static IntPtr _sLogDelegate = IntPtr.Zero;

        private static void LogCallBack(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            Debug.Log(string.Format(":C++: {0}", text));
        }

        private static void SetupLogMechanism()
        {
            DebugLogDelegate logCallback = new DebugLogDelegate(LogCallBack);
            _sLogDelegate = Marshal.GetFunctionPointerForDelegate(logCallback);

            // Call the API passing along the function pointer.
            PluginSetLogDelegate(_sLogDelegate);
        }

        #endregion
#endif

        static UnityNativeChromaSDK()
        {
#if VERBOSE_LOGGING
            SetupLogMechanism();
#else
            // Call the API passing along the function pointer.
            PluginSetLogDelegate(IntPtr.Zero);
#endif
        }

        /// <summary>
        /// Get the streaming path for the animation given the relative path from Assets/StreamingAssets
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static string GetStreamingPath(string animation)
        {
            return string.Format("{0}/{1}", Application.streamingAssetsPath, animation);
        }

        /// <summary>
        /// Close the animation
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static void CloseAnimationName(string animation)
        {
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    PluginCloseAnimationName(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to close animation: {0} exception={1}", path, ex));
            }
            FreeIntPtr(lpData);
        }

        /// Reverse the frames for a chroma animation, returns -1 on failure, otherwise returns the animation id
        public static int Reverse(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginReverse(animationId);
                return result;
            }
            return animationId;
        }

        /// Mirrors the frames horizontally for a chroma animation, returns -1 on failure, otherwise returns the animation id
        public static int MirrorHorizontally(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginMirrorHorizontally(animationId);
                return result;
            }
            return animationId;
        }

        /// Mirrors the frames vertically for a chroma animation, returns -1 on failure, otherwise returns the animation id
        public static int MirrorVertically(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginMirrorVertically(animationId);
                return result;
            }
            return animationId;
        }

        /// Edit the animation,
        /// returns -1 on failure
        /// returns 0 on success
        public static int EditAnimation(string animation)
        {
            Init();
            if (string.IsNullOrEmpty(animation))
            {
                return -1;
            }
            string path = GetStreamingPath(animation);
            IntPtr lpData = GetIntPtr(path);
            int animationId = 1;
            try
            {
                if (lpData != IntPtr.Zero)
                {
                    animationId = PluginOpenEditorDialogAndPlay(lpData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(string.Format("Failed to edi animation: {0} exception={1}", animation, ex));
            }
            FreeIntPtr(lpData);
            return animationId;
        }

        /// <summary>
        /// Convert BGR int to Unity Color
        /// </summary>
        /// <param name="bgrInt"></param>
        /// <returns></returns>
        public static Color ToColor(int bgrInt)
        {
            int red = bgrInt & 0xFF;
            int green = (bgrInt & 0xFF00) >> 8;
            int blue = (bgrInt & 0xFF0000) >> 16;
            return new Color(red / 255f, green / 255f, blue / 255f, 1f);
        }

        /// <summary>
        /// Convert Unity Color to BGR int
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int ToBGR(Color color)
        {
            int red = (int)(Mathf.Clamp01(color.r) * 255);
            int green = (int)(Mathf.Clamp01(color.g) * 255) << 8;
            int blue = (int)(Mathf.Clamp01(color.b) * 255) << 16;
            return blue | green | red;
        }

        /// <summary>
        /// Convert Unity Color to RGB int
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int ToRGB(Color color)
        {
            int red = (int)(Mathf.Clamp01(color.b) * 255);
            int green = (int)(Mathf.Clamp01(color.g) * 255) << 8;
            int blue = (int)(Mathf.Clamp01(color.r) * 255) << 16;
            return blue | green | red;
        }

        public class Keyboard
        {
            //! Definitions of keys.
            public enum RZKEY
            {
                RZKEY_ESC = 0x0001,                 /*!< Esc (VK_ESCAPE) */
                RZKEY_F1 = 0x0003,                  /*!< F1 (VK_F1) */
                RZKEY_F2 = 0x0004,                  /*!< F2 (VK_F2) */
                RZKEY_F3 = 0x0005,                  /*!< F3 (VK_F3) */
                RZKEY_F4 = 0x0006,                  /*!< F4 (VK_F4) */
                RZKEY_F5 = 0x0007,                  /*!< F5 (VK_F5) */
                RZKEY_F6 = 0x0008,                  /*!< F6 (VK_F6) */
                RZKEY_F7 = 0x0009,                  /*!< F7 (VK_F7) */
                RZKEY_F8 = 0x000A,                  /*!< F8 (VK_F8) */
                RZKEY_F9 = 0x000B,                  /*!< F9 (VK_F9) */
                RZKEY_F10 = 0x000C,                 /*!< F10 (VK_F10) */
                RZKEY_F11 = 0x000D,                 /*!< F11 (VK_F11) */
                RZKEY_F12 = 0x000E,                 /*!< F12 (VK_F12) */
                RZKEY_1 = 0x0102,                   /*!< 1 (VK_1) */
                RZKEY_2 = 0x0103,                   /*!< 2 (VK_2) */
                RZKEY_3 = 0x0104,                   /*!< 3 (VK_3) */
                RZKEY_4 = 0x0105,                   /*!< 4 (VK_4) */
                RZKEY_5 = 0x0106,                   /*!< 5 (VK_5) */
                RZKEY_6 = 0x0107,                   /*!< 6 (VK_6) */
                RZKEY_7 = 0x0108,                   /*!< 7 (VK_7) */
                RZKEY_8 = 0x0109,                   /*!< 8 (VK_8) */
                RZKEY_9 = 0x010A,                   /*!< 9 (VK_9) */
                RZKEY_0 = 0x010B,                   /*!< 0 (VK_0) */
                RZKEY_A = 0x0302,                   /*!< A (VK_A) */
                RZKEY_B = 0x0407,                   /*!< B (VK_B) */
                RZKEY_C = 0x0405,                   /*!< C (VK_C) */
                RZKEY_D = 0x0304,                   /*!< D (VK_D) */
                RZKEY_E = 0x0204,                   /*!< E (VK_E) */
                RZKEY_F = 0x0305,                   /*!< F (VK_F) */
                RZKEY_G = 0x0306,                   /*!< G (VK_G) */
                RZKEY_H = 0x0307,                   /*!< H (VK_H) */
                RZKEY_I = 0x0209,                   /*!< I (VK_I) */
                RZKEY_J = 0x0308,                   /*!< J (VK_J) */
                RZKEY_K = 0x0309,                   /*!< K (VK_K) */
                RZKEY_L = 0x030A,                   /*!< L (VK_L) */
                RZKEY_M = 0x0409,                   /*!< M (VK_M) */
                RZKEY_N = 0x0408,                   /*!< N (VK_N) */
                RZKEY_O = 0x020A,                   /*!< O (VK_O) */
                RZKEY_P = 0x020B,                   /*!< P (VK_P) */
                RZKEY_Q = 0x0202,                   /*!< Q (VK_Q) */
                RZKEY_R = 0x0205,                   /*!< R (VK_R) */
                RZKEY_S = 0x0303,                   /*!< S (VK_S) */
                RZKEY_T = 0x0206,                   /*!< T (VK_T) */
                RZKEY_U = 0x0208,                   /*!< U (VK_U) */
                RZKEY_V = 0x0406,                   /*!< V (VK_V) */
                RZKEY_W = 0x0203,                   /*!< W (VK_W) */
                RZKEY_X = 0x0404,                   /*!< X (VK_X) */
                RZKEY_Y = 0x0207,                   /*!< Y (VK_Y) */
                RZKEY_Z = 0x0403,                   /*!< Z (VK_Z) */
                RZKEY_NUMLOCK = 0x0112,             /*!< Numlock (VK_NUMLOCK) */
                RZKEY_NUMPAD0 = 0x0513,             /*!< Numpad 0 (VK_NUMPAD0) */
                RZKEY_NUMPAD1 = 0x0412,             /*!< Numpad 1 (VK_NUMPAD1) */
                RZKEY_NUMPAD2 = 0x0413,             /*!< Numpad 2 (VK_NUMPAD2) */
                RZKEY_NUMPAD3 = 0x0414,             /*!< Numpad 3 (VK_NUMPAD3) */
                RZKEY_NUMPAD4 = 0x0312,             /*!< Numpad 4 (VK_NUMPAD4) */
                RZKEY_NUMPAD5 = 0x0313,             /*!< Numpad 5 (VK_NUMPAD5) */
                RZKEY_NUMPAD6 = 0x0314,             /*!< Numpad 6 (VK_NUMPAD6) */
                RZKEY_NUMPAD7 = 0x0212,             /*!< Numpad 7 (VK_NUMPAD7) */
                RZKEY_NUMPAD8 = 0x0213,             /*!< Numpad 8 (VK_NUMPAD8) */
                RZKEY_NUMPAD9 = 0x0214,             /*!< Numpad 9 (VK_ NUMPAD9*/
                RZKEY_NUMPAD_DIVIDE = 0x0113,       /*!< Divide (VK_DIVIDE) */
                RZKEY_NUMPAD_MULTIPLY = 0x0114,     /*!< Multiply (VK_MULTIPLY) */
                RZKEY_NUMPAD_SUBTRACT = 0x0115,     /*!< Subtract (VK_SUBTRACT) */
                RZKEY_NUMPAD_ADD = 0x0215,          /*!< Add (VK_ADD) */
                RZKEY_NUMPAD_ENTER = 0x0415,        /*!< Enter (VK_RETURN - Extended) */
                RZKEY_NUMPAD_DECIMAL = 0x0514,      /*!< Decimal (VK_DECIMAL) */
                RZKEY_PRINTSCREEN = 0x000F,         /*!< Print Screen (VK_PRINT) */
                RZKEY_SCROLL = 0x0010,              /*!< Scroll Lock (VK_SCROLL) */
                RZKEY_PAUSE = 0x0011,               /*!< Pause (VK_PAUSE) */
                RZKEY_INSERT = 0x010F,              /*!< Insert (VK_INSERT) */
                RZKEY_HOME = 0x0110,                /*!< Home (VK_HOME) */
                RZKEY_PAGEUP = 0x0111,              /*!< Page Up (VK_PRIOR) */
                RZKEY_DELETE = 0x020f,              /*!< Delete (VK_DELETE) */
                RZKEY_END = 0x0210,                 /*!< End (VK_END) */
                RZKEY_PAGEDOWN = 0x0211,            /*!< Page Down (VK_NEXT) */
                RZKEY_UP = 0x0410,                  /*!< Up (VK_UP) */
                RZKEY_LEFT = 0x050F,                /*!< Left (VK_LEFT) */
                RZKEY_DOWN = 0x0510,                /*!< Down (VK_DOWN) */
                RZKEY_RIGHT = 0x0511,               /*!< Right (VK_RIGHT) */
                RZKEY_TAB = 0x0201,                 /*!< Tab (VK_TAB) */
                RZKEY_CAPSLOCK = 0x0301,            /*!< Caps Lock(VK_CAPITAL) */
                RZKEY_BACKSPACE = 0x010E,           /*!< Backspace (VK_BACK) */
                RZKEY_ENTER = 0x030E,               /*!< Enter (VK_RETURN) */
                RZKEY_LCTRL = 0x0501,               /*!< Left Control(VK_LCONTROL) */
                RZKEY_LWIN = 0x0502,                /*!< Left Window (VK_LWIN) */
                RZKEY_LALT = 0x0503,                /*!< Left Alt (VK_LMENU) */
                RZKEY_SPACE = 0x0507,               /*!< Spacebar (VK_SPACE) */
                RZKEY_RALT = 0x050B,                /*!< Right Alt (VK_RMENU) */
                RZKEY_FN = 0x050C,                  /*!< Function key. */
                RZKEY_RMENU = 0x050D,               /*!< Right Menu (VK_APPS) */
                RZKEY_RCTRL = 0x050E,               /*!< Right Control (VK_RCONTROL) */
                RZKEY_LSHIFT = 0x0401,              /*!< Left Shift (VK_LSHIFT) */
                RZKEY_RSHIFT = 0x040E,              /*!< Right Shift (VK_RSHIFT) */
                RZKEY_MACRO1 = 0x0100,              /*!< Macro Key 1 */
                RZKEY_MACRO2 = 0x0200,              /*!< Macro Key 2 */
                RZKEY_MACRO3 = 0x0300,              /*!< Macro Key 3 */
                RZKEY_MACRO4 = 0x0400,              /*!< Macro Key 4 */
                RZKEY_MACRO5 = 0x0500,              /*!< Macro Key 5 */
                RZKEY_OEM_1 = 0x0101,               /*!< ~ (tilde/半角/全角) (VK_OEM_3) */
                RZKEY_OEM_2 = 0x010C,               /*!< -- (minus) (VK_OEM_MINUS) */
                RZKEY_OEM_3 = 0x010D,               /*!< = (equal) (VK_OEM_PLUS) */
                RZKEY_OEM_4 = 0x020C,               /*!< [ (left sqaure bracket) (VK_OEM_4) */
                RZKEY_OEM_5 = 0x020D,               /*!< ] (right square bracket) (VK_OEM_6) */
                RZKEY_OEM_6 = 0x020E,               /*!< \ (backslash) (VK_OEM_5) */
                RZKEY_OEM_7 = 0x030B,               /*!< ; (semi-colon) (VK_OEM_1) */
                RZKEY_OEM_8 = 0x030C,               /*!< ' (apostrophe) (VK_OEM_7) */
                RZKEY_OEM_9 = 0x040A,               /*!< , (comma) (VK_OEM_COMMA) */
                RZKEY_OEM_10 = 0x040B,              /*!< . (period) (VK_OEM_PERIOD) */
                RZKEY_OEM_11 = 0x040C,              /*!< / (forward slash) (VK_OEM_2) */
                RZKEY_EUR_1 = 0x030D,               /*!< "#" (VK_OEM_5) */
                RZKEY_EUR_2 = 0x0402,               /*!< \ (VK_OEM_102) */
                RZKEY_JPN_1 = 0x0015,               /*!< ¥ (0xFF) */
                RZKEY_JPN_2 = 0x040D,               /*!< \ (0xC1) */
                RZKEY_JPN_3 = 0x0504,               /*!< 無変換 (VK_OEM_PA1) */
                RZKEY_JPN_4 = 0x0509,               /*!< 変換 (0xFF) */
                RZKEY_JPN_5 = 0x050A,               /*!< ひらがな/カタカナ (0xFF) */
                RZKEY_KOR_1 = 0x0015,               /*!< | (0xFF) */
                RZKEY_KOR_2 = 0x030D,               /*!< (VK_OEM_5) */
                RZKEY_KOR_3 = 0x0402,               /*!< (VK_OEM_102) */
                RZKEY_KOR_4 = 0x040D,               /*!< (0xC1) */
                RZKEY_KOR_5 = 0x0504,               /*!< (VK_OEM_PA1) */
                RZKEY_KOR_6 = 0x0509,               /*!< 한/영 (0xFF) */
                RZKEY_KOR_7 = 0x050A,               /*!< (0xFF) */
            }

            //! Definition of LEDs.
            public enum RZLED
            {
                RZLED_LOGO = 0x0014                 /*!< Razer logo */
            };
        }

        public class Mouse
        {
            //! Mouse LED Id defintion for the virtual grid.
            public enum RZLED2
            {
                RZLED2_SCROLLWHEEL = 0x0203,  //!< Scroll Wheel LED.
                RZLED2_LOGO = 0x0703,  //!< Logo LED.
                RZLED2_BACKLIGHT = 0x0403,  //!< Backlight LED.
                RZLED2_LEFT_SIDE1 = 0x0100,  //!< Left LED 1.
                RZLED2_LEFT_SIDE2 = 0x0200,  //!< Left LED 2.
                RZLED2_LEFT_SIDE3 = 0x0300,  //!< Left LED 3.
                RZLED2_LEFT_SIDE4 = 0x0400,  //!< Left LED 4.
                RZLED2_LEFT_SIDE5 = 0x0500,  //!< Left LED 5.
                RZLED2_LEFT_SIDE6 = 0x0600,  //!< Left LED 6.
                RZLED2_LEFT_SIDE7 = 0x0700,  //!< Left LED 7.
                RZLED2_BOTTOM1 = 0x0801,  //!< Bottom LED 1.
                RZLED2_BOTTOM2 = 0x0802,  //!< Bottom LED 2.
                RZLED2_BOTTOM3 = 0x0803,  //!< Bottom LED 3.
                RZLED2_BOTTOM4 = 0x0804,  //!< Bottom LED 4.
                RZLED2_BOTTOM5 = 0x0805,  //!< Bottom LED 5.
                RZLED2_RIGHT_SIDE1 = 0x0106,  //!< Right LED 1.
                RZLED2_RIGHT_SIDE2 = 0x0206,  //!< Right LED 2.
                RZLED2_RIGHT_SIDE3 = 0x0306,  //!< Right LED 3.
                RZLED2_RIGHT_SIDE4 = 0x0406,  //!< Right LED 4.
                RZLED2_RIGHT_SIDE5 = 0x0506,  //!< Right LED 5.
                RZLED2_RIGHT_SIDE6 = 0x0606,  //!< Right LED 6.
                RZLED2_RIGHT_SIDE7 = 0x0706   //!< Right LED 7.
            }
        }

        public static int GetLowByte(int mask)
        {
            return (int)(mask & 0xFF);
        }

        public static int GetHighByte(int mask)
        {
            return (int)(((mask & 0xFF00) >> 8) & 0xFF);
        }

        /// <summary>
        /// Create an array of colors for the device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int[] CreateColors1D(Device1D device)
        {
            switch (device)
            {
                case Device1D.ChromaLink:
                case Device1D.Headset:
                case Device1D.Mousepad:
                    break;
                default:
                    Debug.LogError("CreateColors1D: Invalid device!");
                    return null;
            }
            int maxLeds = GetMaxLeds(device);
            int[] colors = new int[maxLeds];
            for (int index = 0; index < colors.Length; ++index)
            {
                colors[0] = 0;
            }
            return colors;
        }

        /// <summary>
        /// Create an array of colors for the device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int[] CreateColors2D(Device2D device)
        {
            switch (device)
            {
                case Device2D.Keyboard:
                case Device2D.Keypad:
                case Device2D.Mouse:
                    break;
                default:
                    Debug.LogError("CreateColors2D: Invalid device!");
                    return null;
            }
            int maxRow = GetMaxRow(device);
            int maxColumn = GetMaxColumn(device);
            int[] colors = new int[maxRow * maxColumn];
            for (int index = 0; index < colors.Length; ++index)
            {
                colors[0] = 0;
            }
            return colors;
        }

        /// <summary>
        /// Create an array of colors for the device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int[] CreateColors(Device device)
        {
            switch (device)
            {
                case Device.ChromaLink:
                    return CreateColors1D(Device1D.ChromaLink);
                case Device.Headset:
                    return CreateColors1D(Device1D.Headset);
                case Device.Keyboard:
                    return CreateColors2D(Device2D.Keyboard);
                case Device.Keypad:
                    return CreateColors2D(Device2D.Keypad);
                case Device.Mouse:
                    return CreateColors2D(Device2D.Mouse);
                case Device.Mousepad:
                    return CreateColors1D(Device1D.Mousepad);
                default:
                    Debug.LogError("CreateColors: Invalid device!");
                    return null;
            }
        }

        /// <summary>
        /// Get the index of the keyboard key
        /// The key should be (int)Keyboard.RZKEY or (int)Keyboard.RZLED
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetKeyboardIndex(int key)
        {
            int maxColumn = GetMaxColumn(Device2D.Keyboard);
            int row = GetHighByte((int)key);
            int column = GetLowByte((int)key);
            int index = row * maxColumn + column;
            return index;
        }

        /// <summary>
        /// Set the keyboard color given the key
        /// The key should be (int)Keyboard.RZKEY or (int)Keyboard.RZLED
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="key"></param>
        /// <param name="color"></param>
        public static void SetKeyboardColor(int[] colors, int key, Color color)
        {
            int index = GetKeyboardIndex(key);
            if (index < colors.Length)
            {
                colors[index] = ToBGR(color);
            }
        }

        /// <summary>
        /// Get the index of the mouse led
        /// The key should be (int)Mouse.RZLED2
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetMouseIndex(int led)
        {
            int maxColumn = GetMaxColumn(Device2D.Mouse);
            int row = GetHighByte((int)led);
            int column = GetLowByte((int)led);
            int index = row * maxColumn + column;
            return index;
        }

#endif
        }
    }
