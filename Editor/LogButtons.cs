using System;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace SOSXR.EnhancedLogger
{
    /// <summary>
    ///     Creates buttons in the Scene view to change the log level
    ///     The current log level is shown in Green in the Scene view
    ///     Also adds menu items to change the log level (see the Logging menu)
    ///     Log level is persistent from Play mode to Edit mode and vice versa
    /// </summary>
    [ExecuteAlways]
    public class LogButtons : MonoBehaviour
    {
        private const string _menuPath = "SOSXR/EnhancedLogger/";
        private const float _buttonWidth = 80f;
        private const float _buttonHeight = 20f;
        private const float _margin_hor = 25;
        private const float _margin_vert = 50;
        private static readonly int _buttonCount = (int) Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>().Last() + 1; // We want to get the Max count of the enum LogLevel.


        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            SceneView.duringSceneGui += OnSceneGUI;
        }


        private static void OnSceneGUI(SceneView sceneView)
        {
            Handles.BeginGUI();

            // Get the size of the Scene view
            var sceneViewSize = new Vector2(sceneView.position.width, sceneView.position.height);

            // Calculate the position for the buttons in the bottom-right corner
            var verticalButtonRect = new Rect(
                sceneViewSize.x - (_buttonWidth + _margin_hor),
                sceneViewSize.y - (_buttonHeight * _buttonCount + _margin_vert),
                _buttonWidth + _margin_hor,
                _buttonHeight * _buttonCount + _margin_vert
            );

            GUILayout.BeginArea(verticalButtonRect);

            GUILayout.BeginVertical();

            if (CreateButton(nameof(None)))
            {
                None();
            }

            if (CreateButton(nameof(Error)))
            {
                Error();
            }

            if (CreateButton(nameof(Warning)))
            {
                Warning();
            }
            
            if (CreateButton(nameof(Solid)))
            {
                Solid();
            }

            if (CreateButton(nameof(Debug)))
            {
                Debug();
            }

            if (CreateButton(nameof(Success)))
            {
                Success();
            }

            if (CreateButton(nameof(Info)))
            {
                Info();
            }

            GUILayout.EndVertical();

            GUILayout.EndArea();

            Handles.EndGUI();
        }


        private static bool CreateButton(string text)
        {
            var isSelected = Log.CurrentLogLevel.ToString() == text;

            if (isSelected)
            {
                GUI.backgroundColor = Color.green; // Highlight the selected button with a different color
            }

            var result = GUILayout.Button(text, GUILayout.Width(_buttonWidth), GUILayout.Height(_buttonHeight));

            if (isSelected)
            {
                GUI.backgroundColor = Color.white; // Reset the color after drawing the button
            }

            return result;
        }


        /// <summary>
        ///     Chose if you want NO logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(None))]
        private static void None()
        {
            Log.CurrentLogLevel = LogLevel.None;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Chose if you ONLY want Error logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(Error))]
        private static void Error()
        {
            Log.CurrentLogLevel = LogLevel.Error;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want both Warning and Error logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(Warning))]
        private static void Warning()
        {
            Log.CurrentLogLevel = LogLevel.Warning;
            LogLevelEditorPrefs.SaveLogLevel();
        }

        /// <summary>
        ///     Choose if you want both Warning and Error logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(Solid))]
        private static void Solid()
        {
            Log.CurrentLogLevel = LogLevel.Solid;
            LogLevelEditorPrefs.SaveLogLevel();
        }

        

        /// <summary>
        ///     Choose if you want Debug, Warning, and Error logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(Debug))]
        private static void Debug()
        {
            Log.CurrentLogLevel = LogLevel.Debug;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want Success, Debug, Warning, and Error logs shown.
        /// </summary>
        [MenuItem(_menuPath + nameof(Success))]
        private static void Success()
        {
            Log.CurrentLogLevel = LogLevel.Success;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want to see ALL logs. This is Info, Success, Debug, Warning, and Error logs.
        /// </summary>
        [MenuItem(_menuPath + nameof(Info))]
        private static void Info()
        {
            Log.CurrentLogLevel = LogLevel.Info;
            LogLevelEditorPrefs.SaveLogLevel();
        }
    }
}