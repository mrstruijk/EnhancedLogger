using UnityEngine;


namespace mrstruijk.EnhancedLogger
{
    /// <summary>
    ///     Add this to a GameObject if you want to set the log level in a Development Build to something else than Debug.
    /// </summary>
    public class DevelopmentBuildLogLevelSetter : MonoBehaviour
    {
        [SerializeField] private LogLevel m_developmentBuildLogLevel = LogLevel.Debug;


        private void Awake()
        {
            SetLogLevelInDevelopmentBuild();
        }


        private void SetLogLevelInDevelopmentBuild()
        {
            #if DEVELOPMENT_BUILD
            Log.CurrentLogLevel = m_developmentBuildLogLevel;
            #else
            Log.Info("Our current loglevel is", Log.CurrentLogLevel, "and we're not changing that to", m_developmentBuildLogLevel);
            #endif
        }
    }
}