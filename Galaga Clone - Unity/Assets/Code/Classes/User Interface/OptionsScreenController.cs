using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Code.Classes.User_Interface
{
    class OptionsScreenController : MonoBehaviour
    {
        [SerializeField] private GameObject _SelectedButton = null;
        [SerializeField] private Text _VsyncLabel = null;
        [SerializeField] private Toggle _VsyncToggle = null;
        [SerializeField] private Text _AntiAliasingLabel = null;
        [SerializeField] private Text _VisualQualityLabel = null;

        private Settings _GameSettings = null;

        private void OnEnable ()
        {
            EventSystem.current.SetSelectedGameObject (_SelectedButton, null);

            GetSettings ();
            SetAALabel ();
            SetQualityLabel ();
            SetVsyncLabel ();
        }

        private void GetSettings ()
        {
            if (File.Exists ("settings.json"))
                _GameSettings = LoadSettingsFromFile ();
            else
                _GameSettings = LoadDefaultSettings ();
        }

        private Settings LoadSettingsFromFile ()
        {
            string settingsJSON = "";

            using (var streamReader = new StreamReader ("settings.json", System.Text.Encoding.UTF8))
            {
                settingsJSON = streamReader.ReadToEnd ();
            }

            var settings = JsonUtility.FromJson<Settings> (settingsJSON);
            return settings;
        }

        private Settings LoadDefaultSettings ()
        {
            var settings = new Settings
            {
                AALevel = QualitySettings.antiAliasing,
                QualityLevel = QualitySettings.GetQualityLevel (),
                VSyncCount = QualitySettings.vSyncCount
            };

            return settings;
        }

        private void SaveSettings ()
        {
            string settingsJSON = _GameSettings.SerializeToString ();

            using (var streamWriter = new StreamWriter ("settings.json", false, System.Text.Encoding.UTF8))
            {
                streamWriter.Write (settingsJSON);
            }
        }

        private void SetVsyncLabel ()
        {
            if (_GameSettings.VSyncCount == 0)
            {
                _VsyncToggle.isOn = false;
                _VsyncLabel.text = "Vsync: Disabled";
            }
            else if (_GameSettings.VSyncCount == 1)
            {
                _VsyncToggle.isOn = true;
                _VsyncLabel.text = "Vsync: Enabled";
            }
        }

        private void SetAALabel ()
        {
            if (_GameSettings.AALevel == 0)
                _AntiAliasingLabel.text = "Anti-Aliasing: Off";
            else if (_GameSettings.AALevel == 2)
                _AntiAliasingLabel.text = "Anti-Aliasing: 2X";
            else if (_GameSettings.AALevel == 4)
                _AntiAliasingLabel.text = "Anti-Aliasing: 4X";
            else if (_GameSettings.AALevel == 8)
                _AntiAliasingLabel.text = "Anti-Aliasing: 8X";
        }

        private void SetQualityLabel ()
        {
            if (_GameSettings.QualityLevel == 1)
                _VisualQualityLabel.text = "Visual Quality: Low";
            else if (_GameSettings.QualityLevel == 2)
                _VisualQualityLabel.text = "Visual Quality: Medium";
            else if (_GameSettings.QualityLevel == 3)
                _VisualQualityLabel.text = "Visual Quality: High";
            else if (_GameSettings.QualityLevel == 5)
                _VisualQualityLabel.text = "Visual Quality: Ultra";
        }

        public void ReturnToMenu (GameObject menuScreen)
        {
            menuScreen.SetActive (true);
            this.gameObject.SetActive (false);

            SaveSettings ();
        }

        public void TogglyVSync (bool isEnabled)
        {
            if (isEnabled)
            {
                QualitySettings.vSyncCount = 1;
                _GameSettings.VSyncCount = 1;
                Application.targetFrameRate = 60;
            }
            else
            {
                QualitySettings.vSyncCount = 0;
                _GameSettings.VSyncCount = 0;
                Application.targetFrameRate = 60;
            }
            
            SetVsyncLabel ();
        }

        public void SetAntiAliasingLevel (int level)
        {
            QualitySettings.antiAliasing = level;
            _GameSettings.AALevel = level;

            SetAALabel ();
        }

        public void SetQualityLevel (int level)
        {
            QualitySettings.SetQualityLevel (level, true);
            _GameSettings.QualityLevel = level;

            SetQualityLabel ();
        }
    }
}
