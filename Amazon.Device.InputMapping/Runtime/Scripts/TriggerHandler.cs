
using UnityEngine;
namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// Facilitates displaying the input help
    /// </summary>
    public class TriggerHandler
    {
        /// <summary>
        /// Shows a help as a dialog over the game/app view
        /// </summary>
        /// <param name="title">The title of the app which will be displayed in the dialog title</param>
        public static void ShowHelp(string title){

            #if UNITY_ANDROID && !UNITY_EDITOR
                using (var triggerHandlerClass = new AndroidJavaClass(JavaConstants.TriggerHandlerClassName)) 
                using (var activity = GetCurrentActivity())
                {
                    var triggerHandler = triggerHandlerClass.CallStatic<AndroidJavaObject>("getInstance");
                    triggerHandler.Call("showHelp", activity, title);
                }
            #else
                Debug.Log("Amazon InputSDK help screen invocation is not supported outside of Android apps.");
                return;
            #endif
            
        }
        
        /// <summary>
        /// Shows a help as a dialog over the game/app view with a theme
        /// </summary>
        /// <param name="title">The title of the app which will be displayed in the dialog title</param>
        /// <param name="uiMode">One of <see cref="UIMode.LIGHT"/>, <see cref="UIMode.DARK"/>, <see cref="UIMode.AUTO"/></param>
        public static void ShowHelp(string title, UIMode uiMode){

            #if UNITY_ANDROID && !UNITY_EDITOR
                using(var uiModeJavaEnum = GetJavaUIModeEnum(uiMode))
                using (var triggerHandlerClass = new AndroidJavaClass(JavaConstants.TriggerHandlerClassName)) 
                using (var activity = GetCurrentActivity())
                {
                    var triggerHandler = triggerHandlerClass.CallStatic<AndroidJavaObject>("getInstance");
                    triggerHandler.Call("showHelp", activity, title, uiModeJavaEnum);
                }
            #else
                Debug.Log("Amazon InputSDK help screen invocation is not supported outside of Android apps.");
                return;
            #endif
            
        }

        /// <summary>
        /// Set the theme for the dialog box
        /// </summary>
        /// <param name="uiMode">One of <see cref="UIMode.LIGHT"/>, <see cref="UIMode.DARK"/>, <see cref="UIMode.AUTO"/></param>
        public static void SetUiMode(UIMode uiMode){

            #if UNITY_ANDROID && !UNITY_EDITOR
                using(var uiModeJavaEnum = GetJavaUIModeEnum(uiMode))
                using (var triggerHandlerClass = new AndroidJavaClass(JavaConstants.TriggerHandlerClassName)) 
                {
                    var triggerHandler = triggerHandlerClass.CallStatic<AndroidJavaObject>("getInstance");
                    triggerHandler.Call("setUiMode", uiModeJavaEnum);
                }
            #else
                Debug.Log("Amazon InputSDK help screen invocation is not supported outside of Android apps.");
                return;
            #endif
            
        }

        private static AndroidJavaObject GetJavaUIModeEnum(UIMode uiMode) {
            var uiModeJavaEnum = new AndroidJavaClass(JavaConstants.UIModeEnumName).GetStatic<AndroidJavaObject>("AUTO");
                
                switch (uiMode)
                {
                    case UIMode.LIGHT:
                        uiModeJavaEnum = new AndroidJavaClass(JavaConstants.UIModeEnumName).GetStatic<AndroidJavaObject>("LIGHT");
                        break;
                    case UIMode.DARK:
                        uiModeJavaEnum = new AndroidJavaClass(JavaConstants.UIModeEnumName).GetStatic<AndroidJavaObject>("DARK");
                        break;
                }
                return uiModeJavaEnum;
        }

        private static AndroidJavaObject GetCurrentActivity()
        {
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }
    }
}