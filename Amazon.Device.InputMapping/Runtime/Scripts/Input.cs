namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// Facilitates input mapping through an <c>InputMappingClient</c>
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Returns the current input mapping client
        /// </summary>
        public static InputMappingClient GetInputMappingClient()
        {
            // PREPROCESSOR DEFINE: Selects the appropriate input mapping clinet based on the evironment
            #if UNITY_ANDROID && !UNITY_EDITOR
                return new AndroidInputMappingClient();
            #else
                return new DummyInputMappingClient();
            #endif
        }
    }
}