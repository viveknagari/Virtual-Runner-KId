using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Amazon.Device.InputMapping
{

    /// <summary>
    /// A converter to convert Unity classes into their corresponding Java counterparts.
    /// </summary>
    internal class JavaConverter : IDisposable
    {

        private readonly InputMap _inputMap;

        private readonly AndroidJavaClass _arraysClass;
        private readonly AndroidJavaClass _inputControlsClass;
        private readonly AndroidJavaClass _inputActionClass;
        private readonly AndroidJavaClass _inputGroupClass;
        private readonly AndroidJavaClass _mouseSettingsClass;
        private readonly AndroidJavaClass _inputMapClass;

        /// <summary>
        /// Creates a new Java converter instance for a given <c>InputMap</c>
        /// </summary>
        public JavaConverter(InputMap inputMap)
        {
            _inputMap = inputMap;

            _arraysClass = new AndroidJavaClass(JavaConstants.ArraysClassName);
            _inputControlsClass = new AndroidJavaClass(JavaConstants.InputControlsClassName);
            _inputActionClass = new AndroidJavaClass(JavaConstants.InputActionClassName);
            _inputGroupClass = new AndroidJavaClass(JavaConstants.InputGroupClassName);
            _inputMapClass = new AndroidJavaClass(JavaConstants.InputMapClassName);
            _mouseSettingsClass = new AndroidJavaClass(JavaConstants.MouseSettingsClassName);
        }

        /// <summary>
        /// Converts the corresponding input map to a Java object
        /// </summary>
        public AndroidJavaObject ToJavaObject()
        {
            if (_inputMap == null) {
                throw new NullReferenceException("Null value passed for input map");
            }

            var inputGroupsJavaObjects = ConvertToJava(_inputMap.InputGroups, ConvertToJava);
            var mouseSettingsJavaObject = ConvertToJava(_inputMap.MouseSettings);
            
            return _inputMapClass.CallStatic<AndroidJavaObject>("create", inputGroupsJavaObjects, mouseSettingsJavaObject);
        }

        private AndroidJavaObject ConvertToJava<T>(IList<T> list, Func<T, AndroidJavaObject> converter)
        {
            if (list == null)
            {
                list = new List<T>();
            }

            AndroidJavaObject[] javaObjects = list.Select(converter).ToArray();

            object[] arguments = {javaObjects}; //arguments for call static method
            return _arraysClass.CallStatic<AndroidJavaObject>("asList", arguments);
        }


        private AndroidJavaObject ConvertToJava(InputGroup inputGroup) {
            if (inputGroup == null) {
                throw new NullReferenceException("Null value passed for input group");
            }

            //construct java objects for input actions
            var inputActionJavaObjects = ConvertToJava(inputGroup.InputActions, ConvertToJava);
            return _inputGroupClass.CallStatic<AndroidJavaObject>("create", inputGroup.GroupLabel, inputActionJavaObjects);
        }

        private AndroidJavaObject ConvertToJava(InputAction inputAction) {
            if (inputAction == null) {
                throw new NullReferenceException("Null value passed for input action");
            }

            //construct java object for input controls
            var inputControlsJavaObject = ConvertToJava(inputAction.InputControls);
            return _inputActionClass.CallStatic<AndroidJavaObject>("create", inputAction.ActionLabel,inputAction.UniqueId, 
                inputControlsJavaObject);
        }

        private AndroidJavaObject ConvertToJava(InputControls inputControls) {
            if (inputControls == null) {
                throw new NullReferenceException("Null value passed for input controls");
            }

            //construct java objects for input actions
            var keyCodesJavaObject = ConvertToJava(inputControls.AndroidKeycodes, ConvertToJava);
            var mouseActionsJavaObject = ConvertToJava(inputControls.MouseActions, ConvertToJava);
            return _inputControlsClass.CallStatic<AndroidJavaObject>("create", keyCodesJavaObject, mouseActionsJavaObject);
        }

        private AndroidJavaObject ConvertToJava(MouseSettings mouseSettings)
        {
            if (mouseSettings == null) {
                throw new NullReferenceException("Null value passed for mouse settings");
            }

            return _mouseSettingsClass.CallStatic<AndroidJavaObject>("create", mouseSettings.AllowMouseSensitivityAdjustment, 
                mouseSettings.InvertMouseMovement);
        }

        private AndroidJavaObject ConvertToJava(int integer)
        {
            return new AndroidJavaObject(JavaConstants.IntegerClassName, integer);
        }

        public void Dispose()
        {
            _inputControlsClass.Dispose();
            _inputActionClass.Dispose();
            _inputGroupClass.Dispose();
            _inputMapClass.Dispose();
            _mouseSettingsClass.Dispose();
        }
    }
}