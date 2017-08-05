//#define VERBOSE_LOGGING

using System;
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
        /// Uninit the plugin
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_NAME)]
        public static extern int PluginUninit();

        /// <summary>
        /// Open an animation file
        /// Returns -1 if animation not found
        /// Returns >= 0 if animation has opened
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int OpenAnimation(string path)
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

        public static int EditAnimation(string path)
        {
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
#if VERBOSE_LOGGING
            Debug.LogError(string.Format("EditAnimation: Animation does not exist! {0}", path));
#endif
            return -1;
        }

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
    }
}

#endif
