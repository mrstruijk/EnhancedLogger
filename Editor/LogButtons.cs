using UnityEditor;
using UnityEngine;


namespace mrstruijk.Utils
{
    /// <summary>
    ///     Creates buttons in the Scene view to change the log level
    ///     Also adds menu items to change the log level
    ///     Log level is persistent from Play mode to Edit mode and vice versa
    /// </summary>
    [ExecuteAlways]
    public class LogButtons : MonoBehaviour
    {
        private const float buttonWidth = 80f;
        private const float buttonHeight = 20f;
        private const float margin_hor = 25;
        private const float margin_vert = 50;
        private const int buttonCount = 6;
        private const string menuPath = "Logging/";


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
                sceneViewSize.x - (buttonWidth + margin_hor),
                sceneViewSize.y - (buttonHeight * buttonCount + margin_vert),
                buttonWidth + margin_hor,
                buttonHeight * buttonCount + margin_vert
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

            var result = GUILayout.Button(text, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight));

            if (isSelected)
            {
                GUI.backgroundColor = Color.white; // Reset the color after drawing the button
            }

            return result;
        }


        /// <summary>
        ///     Chose if you want NO logs shown.
        /// </summary>
        [MenuItem(menuPath + nameof(None))]
        private static void None()
        {
            Log.CurrentLogLevel = LogLevel.None;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Chose if you ONLY want Error logs shown.
        /// </summary>
        [MenuItem(menuPath + nameof(Error))]
        private static void Error()
        {
            Log.CurrentLogLevel = LogLevel.Error;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want both Warning and Error logs shown.
        /// </summary>
        [MenuItem(menuPath + nameof(Warning))]
        private static void Warning()
        {
            Log.CurrentLogLevel = LogLevel.Warning;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want Debug, Warning, and Error logs shown.
        /// </summary>
        [MenuItem(menuPath + nameof(Debug))]
        private static void Debug()
        {
            Log.CurrentLogLevel = LogLevel.Debug;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want Success, Debug, Warning, and Error logs shown.
        /// </summary>
        [MenuItem(menuPath + nameof(Success))]
        private static void Success()
        {
            Log.CurrentLogLevel = LogLevel.Success;
            LogLevelEditorPrefs.SaveLogLevel();
        }


        /// <summary>
        ///     Choose if you want to see ALL logs. This is Info, Success, Debug, Warning, and Error logs.
        /// </summary>
        [MenuItem(menuPath + nameof(Info))]
        private static void Info()
        {
            Log.CurrentLogLevel = LogLevel.Info;
            LogLevelEditorPrefs.SaveLogLevel();
        }
    }
}