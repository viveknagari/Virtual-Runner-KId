namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// Configurations with respect to the mouse behaviour for the game/app
    /// </summary>
    public class MouseSettings
    {
        /// <summary>
        /// NOT IMPLEMENTED
        /// Allows adjustment of mouse sensitivity
        /// </summary>
        public bool AllowMouseSensitivityAdjustment { get; private set; }

        /// <summary>
        /// Indicates if the mouse axis is inverted
        /// </summary>
        public bool InvertMouseMovement { get; private set; }

        /// <summary>
        /// Creates a new <c>MouseSettings</c> object
        /// </summary>
        public static MouseSettings Create(bool allowMouseSensitivityAdjustment, bool invertMouseMovement)
        {
            return new MouseSettings {AllowMouseSensitivityAdjustment = allowMouseSensitivityAdjustment, InvertMouseMovement = invertMouseMovement};
        }
    }
}