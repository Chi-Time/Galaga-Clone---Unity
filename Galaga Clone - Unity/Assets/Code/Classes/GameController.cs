using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Classes
{
    class GameController : MonoBehaviour
    {
        public uint Multiplier
        {
            get
            {
                return _Multiplier;
            }
            set
            {
                if (value <= 0)
                    _Multiplier = 1;
                else
                    _Multiplier = value;
            }
        }

        [SerializeField] private uint _Score = 0;
        [SerializeField] private uint _HighScore = 0;
        [SerializeField] private uint _Multiplier = 1;

        private string _FileName = "savedata.json";

        private void Awake ()
        {
            GetSave ();
        }

        private void GetSave ()
        {
            if (File.Exists (_FileName))
                LoadSave ();
        }

        private void LoadSave ()
        {
            string saveDataJSON = "";

            using (var streamReader = new StreamReader (_FileName, System.Text.Encoding.UTF8))
            {
                saveDataJSON = streamReader.ReadToEnd ();
            }

            var saveData = JsonUtility.FromJson<SaveData> (saveDataJSON);
            _HighScore = saveData.HighScore;
        }

        public void IncreaseScore (uint score)
        {
            _Score += score * Multiplier;
            
            if (IsNewHighScore ())
                _HighScore = _Score;
        }

        private bool IsNewHighScore ()
        {
            if (_Score >= _HighScore)
                return true;

            return false;
        }

        public void GameOver ()
        {
            if (IsNewHighScore ())
                SaveNewHighScore ();

            SceneManager.LoadScene ((2));
        }

        private void SaveNewHighScore ()
        {
            var saveData = new SaveData
            {
                HighScore = _HighScore
            };

            string savaDataJSON = saveData.SerializeToString ();
            using (var streamWriter = new StreamWriter (_FileName, false, System.Text.Encoding.UTF8))
            {
                streamWriter.Write (savaDataJSON);
            }
        }
    }
}
