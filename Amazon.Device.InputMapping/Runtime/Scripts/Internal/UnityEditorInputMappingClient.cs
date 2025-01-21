
using UnityEngine;

namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// A dummy input mapping client that does nothing - to be used in Unity editor and non-Android environments
    /// </summary>
    internal class DummyInputMappingClient : InputMappingClient
    {

        public DummyInputMappingClient() {
            Debug.Log("Dummy input mapping client generated");
        }

        public void ClearInputMappingProvider()
        {
            Debug.Log("Input mapping provider could not be cleared on non-Android platform");
        }

        public void SetInputMappingProvider(InputMappingProvider inputMappingProvider)
        {
            Debug.Log("Input mapping provider could not be set on non-Android platform");
        }
    }
}