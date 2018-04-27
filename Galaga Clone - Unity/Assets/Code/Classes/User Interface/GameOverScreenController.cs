using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Code.Classes.User_Interface
{
    sealed class GameOverScreenController : MonoBehaviour
    {
        [SerializeField] private Text _HighScoreLabel = null;
        [SerializeField] private GameObject _SelectedButton = null;

        private string _FileName = "savedata.json";

        private void OnEnable ()
        {
            EventSystem.current.SetSelectedGameObject (_SelectedButton.gameObject, null);

            GetSave ();
        }

        private void GetSave ()
        {
            if (File.Exists (_FileName))
            {
                LoadSave ();
                return;
            }

            SetHighScoreLabel (0);
        }

        private void LoadSave ()
        {
            string saveDataJSON = "";

            using (var streamReader = new StreamReader (_FileName, System.Text.Encoding.UTF8))
            {
                saveDataJSON = streamReader.ReadToEnd ();
            }

            var saveData = JsonUtility.FromJson<SaveData> (saveDataJSON);
            SetHighScoreLabel (saveData.HighScore);
        }

        private void SetHighScoreLabel (uint highScore)
        {
            _HighScoreLabel.text = "High Score: " + highScore.ToString ();
        }

        public void LoadScene (int level)
        {
            SceneManager.LoadScene (level);
        }
    }
}
