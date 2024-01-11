

using UnityEngine;


namespace mrstruijk.EnhancedLogger
{
    /// <summary>
    ///     This is a simple logger that can be used to log different types of messages
    ///     It allows me to control the output of the logs in the editor and in the development build,
    ///     while also allowing me to persist the log level between editor sessions.
    ///     The log level is set in the menu Logging, or via the buttons in the Scene view (see LogButtons.cs)
    ///     The log level is set to the development build log level when the game is built as a development build (see
    ///     DevelopmentBuildLogLevelSetter.cs)
    ///     Logs are not shown in the release build
    ///     Adapted from DrowsyFoxDev: https://www.youtube.com/watch?v=lRqR4YF8iQs
    /// </summary>
    public static class Log
    {
        public const string ErrorPrefix = "[!ERROR!]";
        private const string WarningPrefix = "[WARNING]";
        private const string DebugPrefix = "<DEBUG>";
        private const string SuccessPrefix = "";
        private const string InfoPrefix = "";

        private const string ErrorColor = "red";
        public const string WarningColor = "yellow";
        private const string DebugColor = "orange";
        private const string SuccessColor = "green";
        private const string InfoColor = "pink";

        public static LogLevel CurrentLogLevel = LogLevel.Debug;


        private static string Color(this string myString, string color)
        {
            #if UNITY_EDITOR
            return $"<color={color}>{myString}</color>";
            #elif DEVELOPMENT_BUILD
            return myString;
            #else
            return null;
            #endif
        }


        public static string GetPrefix(LogLevel logLevel)
        {
            return logLevel switch
                   {
                       LogLevel.Error => ErrorPrefix,
                       LogLevel.Warning => WarningPrefix,
                       LogLevel.Debug => DebugPrefix,
                       LogLevel.Success => SuccessPrefix,
                       _ => InfoPrefix
                   };
        }


        public static string GetColor(LogLevel logLevel)
        {
            return logLevel switch
                   {
                       LogLevel.Error => ErrorColor,
                       LogLevel.Warning => WarningColor,
                       LogLevel.Debug => DebugColor,
                       LogLevel.Success => SuccessColor,
                       _ => InfoColor
                   };
        }


        /// <summary>
        ///     Logs are not shown in the release build
        ///     Theoretically, this should be less expensive than the Debug.Log, over which I have no control
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        private static void DoLog(LogLevel logLevel, object caller, params object[] message)
        {
            #if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (CurrentLogLevel < logLevel)
            {
                return;
            }

            var objectName = caller is Object unityObject ? "[" + unityObject.name + "]" : "[" + caller + "]";
            var prefix = GetPrefix(logLevel);
            var color = GetColor(logLevel);

            if (!string.IsNullOrEmpty(prefix))
            {
                objectName = string.Concat(objectName, prefix);
            }

            UnityEngine.Debug.Log($"{objectName.Color(color)} : {string.Join(" : ", message)}\n");
            #endif
        }


        /// <summary>
        ///     Designed for catastrophic level error-logging.
        ///     The logger defaults to show Error messages in the editor / development build (Debug and up).
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Error(this Object caller, params object[] message)
        {
            DoLog(LogLevel.Error, caller, message);
        }


        /// <summary>
        ///     Designed for catastrophic level error-logging
        ///     The logger defaults to show Error messages in the editor / development build (Debug and up).
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Error(string caller, params object[] message)
        {
            DoLog(LogLevel.Error, caller, message);
        }


        /// <summary>
        ///     Designed for warnings which need to be fixed, but do not break the game.
        ///     The logger defaults to show Warning messages in the editor / development build (Debug and up).
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Warning(this Object caller, params object[] message)
        {
            DoLog(LogLevel.Warning, caller, message);
        }


        /// <summary>
        ///     Designed for warnings which need to be fixed, but do not break the game
        ///     The logger defaults to show Warning messages in the editor / development build (Debug and up).
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Warning(string caller, params object[] message)
        {
            DoLog(LogLevel.Warning, caller, message);
        }


        /// <summary>
        ///     Designed for temporary debug messages. The Logger defaults to show Debug messages in the editor / development
        ///     build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Debug(this Object caller, params object[] message)
        {
            DoLog(LogLevel.Debug, caller, message);
        }


        /// <summary>
        ///     Designed for temporary debug messages. The Logger defaults to show Debug messages in the editor / development
        ///     build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Debug(string caller, params object[] message)
        {
            DoLog(LogLevel.Debug, caller, message);
        }


        /// <summary>
        ///     Designed to note when something does work
        ///     By default these messages are not shown in the editor / development build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Success(this Object caller, params object[] message)
        {
            DoLog(LogLevel.Success, caller, message);
        }


        /// <summary>
        ///     Designed to note when something does work
        ///     By default these messages are not shown in the editor / development build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Success(string caller, params object[] message)
        {
            DoLog(LogLevel.Success, caller, message);
        }


        /// <summary>
        ///     Designed for the lowest level of persistent Logging. Only shown in Full / Info logging mode
        ///     By default these messages are not shown in the editor / development build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Info(this Object caller, params object[] message)
        {
            DoLog(LogLevel.Info, caller, message);
        }


        /// <summary>
        ///     Designed for the lowest level of persistent Logging. Only shown in Full / Info logging mode
        ///     By default these messages are not shown in the editor / development build.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="message"></param>
        public static void Info(string caller, params object[] message)
        {
            DoLog(LogLevel.Info, caller, message);
        }
    }
}