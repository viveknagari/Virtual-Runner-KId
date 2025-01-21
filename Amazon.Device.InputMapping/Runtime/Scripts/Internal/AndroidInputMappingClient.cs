
using UnityEngine;

namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// <c>InputMappingClient</c> for Android games/applications
    /// </summary>
    internal class AndroidInputMappingClient : InputMappingClient
    {
        private readonly AndroidJavaObject _inputMappingClient;
        private InputMappingProviderProxy _currentProvider;

        /// <summary>
        /// Gets a <c>AndroidInputMappingClient</c> object from the Android Input SDK
        /// </summary>
        public AndroidInputMappingClient() {
            try
            {
                using (var inputClass = new AndroidJavaClass(JavaConstants.InputClassName)) 
                using (var activity = GetCurrentActivity())
                {
                    _inputMappingClient = inputClass.CallStatic<AndroidJavaObject>("getInputMappingClient", activity);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Clears the currently registered input mapping provider
        /// </summary>
        public void ClearInputMappingProvider()
        {
            if (_currentProvider != null)
            {
                _inputMappingClient.Call("clearInputMappingProvider");
            }
        }

        /// <summary>
        /// Sets a <c>AndroidInputMappingProvider</c> as the current provider
        /// </summary>
        public void SetInputMappingProvider(InputMappingProvider inputMappingProvider)
        {
            Debug.Log("Received an input mapping client " + inputMappingProvider);
            Debug.Log("The input map is " + inputMappingProvider.OnProvideInputMap());

            _currentProvider = new InputMappingProviderProxy(inputMappingProvider);
            _inputMappingClient.Call("setInputMappingProvider", _currentProvider);
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