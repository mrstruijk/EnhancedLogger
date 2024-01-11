using mrstruijk.Utils;
using UnityEngine;


/// <summary>
///     The log level is set to the development build log level when the game is built as a development build
///     No changes to the Editor Log Level are made when the game is build as a release build
///     Also no changes are made when the game is run in the Editor
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
        #endif
    }
}