namespace mrstruijk.EnhancedLogger
{
    /// <summary>
    ///     Debug is by default the lowest shown log level in the Editor and Development Build.
    ///     Change this in the menu Logging, the Scene view, or in the DevelopmentBuildLogLevelSetter script.
    /// </summary>
    public enum LogLevel
    {
        None,
        Error,
        Warning,
        Debug,
        Success,
        Info
    }
}