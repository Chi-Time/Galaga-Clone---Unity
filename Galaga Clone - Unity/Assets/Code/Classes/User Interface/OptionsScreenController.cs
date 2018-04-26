using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Classes.User_Interface
{
    class OptionsScreenController : MonoBehaviour
    {
        [SerializeField] private Text _VsyncLabel = null;
        [SerializeField] private Text _AntiAliasingLabel = null;
        [SerializeField] private Text _VisualQualityLabel = null;

        public void ReturnToMenu (GameObject menuScreen)
        {
            menuScreen.SetActive (true);
            this.gameObject.SetActive (false);
        }

        public void TogglyVSync (bool isEnabled)
        {
            if (isEnabled)
            {
                QualitySettings.vSyncCount = 1;
                _VsyncLabel.text = "VSync: Enabled";
            }
            else
            {
                QualitySettings.vSyncCount = 0;
                _VsyncLabel.text = "VSync: Disabled";
            }
        }

        public void SetAntiAliasingLevel (int level)
        {
            QualitySettings.antiAliasing = level;

            if (level == 0)
                _AntiAliasingLabel.text = "Anti-Aliasing: Off";
            else if (level == 2)
                _AntiAliasingLabel.text = "Anti-Aliasing: 2X";
            else if (level == 4)
                _AntiAliasingLabel.text = "Anti-Aliasing: 4X";
            else if (level == 8)
                _AntiAliasingLabel.text = "Anti-Aliasing: 8X";
        }

        public void SetQualityLevel (int level)
        {
            QualitySettings.SetQualityLevel (level, true);

            if (level == 1)
                _VisualQualityLabel.text = "Visual Quality: Low";
            else if (level == 2)
                _VisualQualityLabel.text = "Visual Quality: Medium";
            else if (level == 3)
                _VisualQualityLabel.text = "Visual Quality: High";
            else if (level == 5)
                _VisualQualityLabel.text = "Visual Quality: Ultra";
        }
    }
}
