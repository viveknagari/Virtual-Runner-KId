namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// Input mapping client helps manage the current input mapping provider
    /// </summary>
    public interface InputMappingClient
    {
        /// <summary>
        /// Sets the current <c>>InputMappingProvider</c> that provides the input mappings
        /// </summary>
        void SetInputMappingProvider(InputMappingProvider inputMappingProvider);

        /// <summary>
        /// CLears the current <c>>InputMappingProvider</c>
        /// </summary>
        void ClearInputMappingProvider();
    }
}