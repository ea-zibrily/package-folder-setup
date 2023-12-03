using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tsukuyomi.Tools
{
    public class Folders : EditorWindow
    {
        #region Variable

        private static string projectName = "Project";
        private static string[] currentSubFolder;

        // Folder Name
        private static string[] mainFolders = 
        {
            "Art",
            "Audio",
            "Data",
            "Prefabs",
            "Property",
            "Scenes",
            "Scripts",
            "ScriptableObject"
        };
        
        private static string[] artSubFolders =
        {
            "Animation",
            "Sprites",
            "Tilemap",
            "Timeline",
            "UI"
        };
        
        private static string[] audioSubFolders =
        {
            "Music",
            "SoundEffect"
        };
        
        private static string[] propertySubFolders =
        {
            "Presets",
            "Fonts",
            "Materials",
            "PhysicMaterials",
            "TileRule"
        };
        
        private static string[] sceneSubFolders =
        {
            "Main",
            "Feature",
            "Asset"
        };
        
        private static string[] scriptSubFolders =
        {
            "DesignPattern",
            "Entities",
            "Gameplay",
            "Managers",
            "Puzzle",
            "Quest",
            "ScriptableObject"
        };

        #endregion

        #region EditorWindow Callbacks

        private void OnGUI()
        {
            EditorGUILayout.LabelField("Insert the Project name used as the root folder");
            projectName = EditorGUILayout.TextField("Project Name: ", projectName);
            this.Repaint();
            GUILayout.Space(70);

            if (GUILayout.Button("Generate"))
            {
                CreateDefaultFolders();
                this.Close();
            }
        }

        #endregion
        
        #region Tsukuyomi Callbacks
        
        private static void CreateDefaultFolders()
        {
            var i = 0;
            string[] roots = 
            {
                projectName,
                projectName + "/Art",
                projectName + "/Audio",
                projectName + "/Property",
                projectName + "/Scenes",
                projectName + "/Scripts"
            };
            
            foreach (var root in roots)
            {
                SubFolderSwitcher(i);
                FolderDirector("_" + root, currentSubFolder);
                i++;
            }
            
            AssetDatabase.Refresh();
        }
        
        private static void FolderDirector(string rootName, params string[] dirName)
        {
            var fullPath = Path.Combine(Application.dataPath, rootName);
            foreach (var folder in dirName)
            {
                if (!Directory.Exists(Path.Combine(rootName, folder)))
                    Directory.CreateDirectory(Path.Combine(fullPath, folder));
            }
        }

        private static void SubFolderSwitcher(int index)
        {
            currentSubFolder = index switch
            {
                0 => mainFolders,
                1 => artSubFolders,
                2 => audioSubFolders,
                3 => propertySubFolders,
                4 => sceneSubFolders,
                5 => scriptSubFolders,
                _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
            };
        }

        #endregion
        
    }
}