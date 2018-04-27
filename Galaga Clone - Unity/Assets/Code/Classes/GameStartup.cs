using System.IO;
using UnityEngine;

namespace Assets.Code.Classes
{
    class GameStartup : MonoBehaviour
    {
        private void Awake ()
        {
            LoadSettings ();
        }

        private void LoadSettings ()
        {
            if (File.Exists ("settings.json"))
                LoadSettingsFromFile ();
        }

        private void LoadSettingsFromFile ()
        {
            string settingsJSON = "";

            using (var streamReader = new StreamReader ("settings.json", System.Text.Encoding.UTF8))
            {
                settingsJSON = streamReader.ReadToEnd ();
            }

            var settings = JsonUtility.FromJson<Settings> (settingsJSON);
            SetSettings (settings);
        }

        private void SetSettings (Settings settings)
        {
            QualitySettings.antiAliasing = settings.AALevel;
            QualitySettings.SetQualityLevel (settings.QualityLevel, true);
            QualitySettings.vSyncCount = settings.VSyncCount;
            Application.targetFrameRate = 60;
        }
    }
}
