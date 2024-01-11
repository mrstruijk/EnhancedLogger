using UnityEditor;
using UnityEngine;


namespace mrstruijk.EnhancedLogger
{
    /// <summary>
    ///     This makes the Current Log Level persist between editor sessions
    /// </summary>
    public static class LogLevelEditorPrefs
    {
        public const string LogLevelKey = "CurrentLogLevel";


        /// <summary>
        ///     Load the saved log level from EditorPrefs when the editor starts
        /// </summary>
        [InitializeOnLoadMethod]
        private static void LoadLogLevel()
        {
            if (EditorPrefs.HasKey(LogLevelKey))
            {
                Log.CurrentLogLevel = (LogLevel) EditorPrefs.GetInt(LogLevelKey);
            }
            else
            {
                Debug.LogError("No log level found in EditorPrefs. Please set one in the menu Logging");
            }
        }


        /// <summary>
        ///     Save the current log level in EditorPrefs
        /// </summary>
        public static void SaveLogLevel()
        {
            EditorPrefs.SetInt(LogLevelKey, (int) Log.CurrentLogLevel);
        }
    }
}