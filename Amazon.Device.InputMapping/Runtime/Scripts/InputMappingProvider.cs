namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// An interface for an input mapping provider class
    /// </summary>
    public interface InputMappingProvider
    {
        /// <summary>
        /// Returns a <c>InputMap</c> object for the game/app controls
        /// </summary>
        InputMap OnProvideInputMap();
    }
}