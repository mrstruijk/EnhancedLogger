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


        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void SetLogLevelInDevelopmentBuild()
        {
            #if DEVELOPMENT_BUILD
            Log.CurrentLogLevel = m_developmentBuildLogLevel;
            #endif
        }
    }
}