namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// An action that represents a game/app action along with the input controls to invoke that action
    /// </summary>
    public class InputAction
    {
 
        /// <summary>
        /// A human readable label for the game/app action
        /// </summary>
        public string ActionLabel { get; private set; }

        /// <summary>
        /// A unique id for the game action
        /// </summary>
        public int UniqueId { get; private set; }

        /// <summary>
        /// <c>InputControls</c> corresponding to the action
        /// </summary>
        public InputControls InputControls { get; private set; }

        /// <summary>
        /// Creates a new <c>InputAction</c> object
        /// </summary>
        /// <param name="actionLabel">A human readable label for the game/app action</param>
        /// <param name="uniqueId">A unique id for the game action</param>
        /// <param name="inputControls"><c>InputControls</c> corresponding to the action</param>
        public static InputAction Create(string actionLabel, int uniqueId, InputControls inputControls)
        {
            return new InputAction
            {
                ActionLabel = actionLabel,
                UniqueId = uniqueId,
                InputControls = inputControls
            };
        }
    }
}