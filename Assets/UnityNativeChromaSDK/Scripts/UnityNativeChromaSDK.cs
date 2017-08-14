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
        /// Returns true if the platform is supported
        /// false if not supported
        /// </summary>
        /// <returns></returns>
        public static bool IsPlatformSupported()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// Get the plugin version
        /// </summary>
        /// <returns></returns>
        public static string GetVersion()
        {
            return "1.0";
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

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
        /// Open the editor dialog
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        private static extern int PluginOpenEditorDialog(IntPtr path);

        /// <summary>
        /// Open a chroma animation, returns -1 if failed to open, otherwise returns the id of the animation
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
        /// Get the frame count of a chroma animation, returns -1 if failed to get data, otherwise returns the number of frames
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginGetFrameCount(int animationId);

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
        /// Preview a frame in a chroma animation, returns -1 if failed to get data, otherwise returns the animation id
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginPreviewFrame(int animationId, int frameIndex);

        #region Helpers (handle path conversions)

        /// <summary>
        /// Open an animation file
        /// Returns -1 if animation not found
        /// Returns >= 0 if animation has opened
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static int OpenAnimation(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return - 1;
            }
#if VERBOSE_LOGGING
            Debug.Log(string.Format("OpenAnimation: {0}", path));
#endif
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                byte[] array = ASCIIEncoding.ASCII.GetBytes(fi.FullName+"\0");
                IntPtr lpData = Marshal.AllocHGlobal(array.Length);
                Marshal.Copy(array, 0, lpData, array.Length);
                int animationId = PluginOpenAnimation(lpData);
                Marshal.FreeHGlobal(lpData);
                return animationId;
            }
            return -1;
        }

        /// <summary>
        /// Edit an animation file
        /// Returns -1 if animation nott found
        /// Returns 0 on success
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int PluginEditAnimation(string path)
        {
            Init();
            if (string.IsNullOrEmpty(path))
            {
                return -1;
            }
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                byte[] array = ASCIIEncoding.ASCII.GetBytes(fi.FullName+"\0");
                IntPtr lpData = Marshal.AllocHGlobal(array.Length);
                Marshal.Copy(array, 0, lpData, array.Length);
                int animationId = PluginOpenEditorDialog(lpData);
                Marshal.FreeHGlobal(lpData);
                return animationId;
            }
            Debug.LogError(string.Format("EditAnimation: Animation does not exist! {0}", path));
            return -1;
        }

        public static int PluginSaveAnimation(int animationId, string path)
        {
            Init();
            if (string.IsNullOrEmpty(path))
            {
                return -1;
            }
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                byte[] array = ASCIIEncoding.ASCII.GetBytes(fi.FullName + "\0");
                IntPtr lpData = Marshal.AllocHGlobal(array.Length);
                Marshal.Copy(array, 0, lpData, array.Length);
                int result = PluginSaveAnimation(animationId, lpData);
                Marshal.FreeHGlobal(lpData);
                return result;
            }
            Debug.LogError(string.Format("SaveAnimation: Animation does not exist! {0}", path));
            return -1;
        }

        public enum DeviceType
        {
            DE_1D = 0,
            DE_2D = 1,
            Invalid = -1,
        }

        public enum Device
        {
            ChromaLink,
            Headset,
            Keyboard,
            Keypad,
            Mouse,
            Mousepad,
            Invalid = -1,
        }

        public enum Device1D
        {
            ChromaLink = 0,
            Headset = 1,
            Mousepad = 2,
            Invalid = -1,
        }

        public enum Device2D
        {
            Keyboard = 0,
            Keypad = 1,
            Mouse = 2,
            Invalid = -1,
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

        public static int CreateAnimation(string path, Device device)
        {
            Init();
            if (string.IsNullOrEmpty(path))
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
            FileInfo fi = new FileInfo(path);
            byte[] array = ASCIIEncoding.ASCII.GetBytes(fi.FullName + "\0");
            IntPtr lpData = Marshal.AllocHGlobal(array.Length);
            Marshal.Copy(array, 0, lpData, array.Length);
            int result = PluginCreateAnimation(lpData, dt, d);
            Marshal.FreeHGlobal(lpData);
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

        public static int GetFrameCount(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginGetFrameCount(animationId);
                return result;
            }
            return animationId;
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

        #endregion

#if VERBOSE_LOGGING
        #region Handle Debug.Log from unmanged code

        [DllImport(DLL_NAME)]
        private static extern void PluginSetLogDelegate(IntPtr logDelegate);

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

        static UnityNativeChromaSDK()
        {
            SetupLogMechanism();
        }

#endif

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
        /// Dictionary of loaded animation, key is animation name, value is animation id
        /// </summary>
        private static Dictionary<string, int> _sLoadedAnimations = new Dictionary<string, int>();

        /// <summary>
        /// Initialize and clear the loaded animations dictionary
        /// </summary>
        public static int Init()
        {
            bool isInitialized = PluginIsInitialized();
            if (!isInitialized)
            {
                int result = PluginInit();
                _sLoadedAnimations.Clear();
                return result;
            }
            //ignore: already initialized
            return 0;
        }

        /// <summary>
        /// Uninitialize and clear the loaded animations dictionary
        /// </summary>
        /// <returns></returns>
        public static int Uninit()
        {
            _sLoadedAnimations.Clear();
            bool isInitialized = PluginIsInitialized();
            if (isInitialized)
            {
                int result = PluginUninit();
                return result;
            }
            //ignore: already uninitialized
            return 0;
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
            if (string.IsNullOrEmpty(animation))
            {
                return -1;
            }
            string path = GetStreamingPath(animation);
            int animationid;
            if (!_sLoadedAnimations.ContainsKey(animation))
            {
                animationid = OpenAnimation(path);
                if (animationid >= 0)
                {
                    _sLoadedAnimations[animation] = animationid;
                }
            }
            else
            {
                animationid = _sLoadedAnimations[animation];
            }
            return animationid;
        }

        /// <summary>
        /// Play the animation,
        /// returns animation id upon success
        /// returns -1 on failure
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static int PlayAnimation(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginPlayAnimation(animationId);
                return result;
            }
            return animationId;
        }

        /// <summary>
        /// Close the animation,
        /// returns animation id upon success
        /// returns -1 on failure
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static int CloseAnimation(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginCloseAnimation(animationId);
                if (result >= 0)
                {
                    if (_sLoadedAnimations.ContainsKey(animation))
                    {
                        _sLoadedAnimations.Remove(animation);
                    }
                }
                return result;
            }
            return animationId;
        }

        /// <summary>
        /// Stop the animation,
        /// returns animation id upon success
        /// returns -1 on failure
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        public static int StopAnimation(string animation)
        {
            int animationId = GetAnimation(animation);
            if (animationId >= 0)
            {
                int result = PluginStopAnimation(animationId);
                return result;
            }
            return animationId;
        }

        /// Edit the animation,
        /// returns -1 on failure
        /// returns 0 on success
        public static int EditAnimation(string animation)
        {
            string path = GetStreamingPath(animation);
            int result = PluginEditAnimation(path);
            return result;
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
    }
#endif
}
