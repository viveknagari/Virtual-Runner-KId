using System.Collections.Generic;

namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// An input control consisting of a set of keyboard keys and mouse actions that combine to invoke the game/app action
    /// </summary>
    public class InputControls
    {
        /// <summary>
        /// A list of keyboard key codes corresponding to the input control
        /// </summary>
        public IList<int> AndroidKeycodes { get; private set; }

        /// <summary>
        /// A list of mouse actions corresponding to the input control
        /// </summary>
        public IList<int> MouseActions { get; private set; }

        /// <summary>
        /// Creates a new <c>InputControls</c> object
        /// </summary>
        /// <param name="androidKeycodes">A list of keyboard key codes corresponding to the input control</param>
        /// <param name="mouseActions">A list of mouse actions corresponding to the input control</param>
        public static InputControls Create(IList<int> androidKeycodes, IList<int> mouseActions)
        {
            return new InputControls { AndroidKeycodes = androidKeycodes, MouseActions = mouseActions };
        }
    }
}