namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// Constants to interact with the Java Android Input SDK
    /// </summary>
    internal class JavaConstants
    {
        internal const string JavaPackage = "com.amazon.device.inputmapping";
        internal const string InputPackageName = JavaPackage + ".input";
        internal const string HelpPackageName = JavaPackage + ".help";

        internal const string InputClassName = InputPackageName + ".Input";
        
        internal const string IntegerClassName = "java.lang.Integer";
        internal const string ArraysClassName = "java.util.Arrays";
        internal const string InputControlsClassName = InputPackageName + ".InputControls";
        internal const string InputActionClassName = InputPackageName + ".InputAction";
        internal const string InputGroupClassName = InputPackageName + ".InputGroup";
        internal const string MouseSettingsClassName = InputPackageName + ".MouseSettings";
        internal const string InputMapClassName = InputPackageName + ".InputMap";
        internal const string InputMappingProviderClassName = InputPackageName + ".InputMappingProvider";

        internal const string TriggerHandlerClassName = HelpPackageName + ".TriggerHandler";
        internal const string UIModeEnumName = HelpPackageName + ".UIMode";
    }
}