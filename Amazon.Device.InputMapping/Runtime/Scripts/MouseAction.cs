namespace Amazon.Device.InputMapping
{
    /// <summary>
    /// An enumeration of mouse actions as in Google Input SDK
    /// The mouse action codes are taken from Google Play Unity plugins (Apache v2 license) and modified as required. 
    /// https://github.com/google/play-unity-plugins/blob/master/GooglePlayPlugins/com.google.play.inputmapping/Runtime/Scripts/PlayMouseAction.cs
    /// </summary>
    public static class MouseAction
    {
        public const int MouseActionUnspecified = 0;
        public const int MouseLeftClick = 10;
        public const int MouseRightClick = 1;
        public const int MouseTertiaryClick = 2;
        public const int MouseForwardClick = 3;
        public const int MouseBackClick = 4;
        public const int MouseScrollUp = 5;
        public const int MouseScrollDown = 6;
        public const int MouseMovement = 7;
        public const int MouseLeftDrag = 8;
        public const int MouseRightDrag = 9;
    }
}