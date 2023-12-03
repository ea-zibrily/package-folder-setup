using UnityEditor;
using UnityEngine;

namespace Tsukuyomi.Tools
{
    public class ToolsMenu : EditorWindow
    {
        [MenuItem("Tools/Setup/Default Folders")]
        private static void SetUpFolders()
        {
            Folders window = CreateInstance<Folders>();
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 150);
            window.ShowPopup();
        }
        
        [MenuItem("Tools/Setup/Packages/Profile Analyzer")]
        private static void AddProfileAnalyzer() => Packages.InstallUnityPackage("performance.profile-analyzer");
        
        [MenuItem("Tools/Setup/Packages/Memory Profiler")]
        private static void AddMemoryProfiler() => Packages.InstallUnityPackage("memoryprofiler");

        [MenuItem("Tools/Setup/Packages/New Input System")]
        private static void AddNewInputSystem() => Packages.InstallUnityPackage("inputsystem");
        
        [MenuItem("Tools/Setup/Packages/Cinemachine")]
        private static void AddCinemachine() => Packages.InstallUnityPackage("cinemachine");

    }
}