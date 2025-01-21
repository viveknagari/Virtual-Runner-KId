using System.Collections.Generic;

namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// A group of <c>InputAction</c>s that belong to a similar classification of actions.
    /// For eg. Movement actions, Firing controls etc.
    /// </summary>
    public class InputGroup
    {

        /// <summary>
        /// A human readable label for the action group
        /// </summary>
        public string GroupLabel { get; private set; }

        /// <summary>
        /// List of <c>InputAction</c> that correspond to the group.
        /// </summary>
        public IList<InputAction> InputActions { get; private set; }

        /// <summary>
        /// Creates a new <c>InputGroup</c> object
        /// </summary>
        /// <param name="groupLabel">A human readable label for the action group</param>
        /// <param name="inputActions">List of <c>InputAction</c> that correspond to the group</param>
        public static InputGroup Create(string groupLabel, IList<InputAction> inputActions)
        {
            return new InputGroup { GroupLabel = groupLabel, InputActions = inputActions };
        }
    }
}