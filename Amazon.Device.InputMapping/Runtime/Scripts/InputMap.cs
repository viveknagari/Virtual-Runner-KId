using System.Collections.Generic;

namespace Amazon.Device.InputMapping
{

    /// <summary>
    /// A set of input mappings for the game/app where <c>InputAction</c>s are classified into a set of <c>InputGroup</c>s
    /// </summary>
    public class InputMap
    {
        public IList<InputGroup> InputGroups { get; private set; }

        /// <summary>
        /// <c>MouseSettings</c> corresponding to the input map
        /// </summary>
        public MouseSettings MouseSettings { get; private set; }

        /// <summary>
        /// Creates a new <c>InputMap</c> object
        /// </summary>
        /// <param name="inputGroups">List of <c>InputGroup</c> corresponding to the input map.</param>
        /// <param name="mouseSettings"><c>MouseSettings</c> corresponding to the input map</param>
        public static InputMap Create(IList<InputGroup> inputGroups, MouseSettings mouseSettings)
        {
            return new InputMap { InputGroups = inputGroups, MouseSettings = mouseSettings };
        }
    }
}