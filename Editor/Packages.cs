using System.IO;
using UnityEngine;

namespace Tsukuyomi.Tools
{
    public static class Packages
    {
        #region Tsukuyomi Callbacks

        public static void InstallUnityPackage(string packageName)
        {
            if (IsPackageInstalled(packageName))
            {
                Debug.LogWarning($"com.unity.{packageName} already installed!");
                return;
            }
            
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }
        
        private static bool IsPackageInstalled(string packageId)
        {
            if ( !File.Exists("Packages/manifest.json") )
                return false;
 
            string jsonText = File.ReadAllText("Packages/manifest.json");
            return jsonText.Contains(packageId);
        }

        #endregion
    }
}