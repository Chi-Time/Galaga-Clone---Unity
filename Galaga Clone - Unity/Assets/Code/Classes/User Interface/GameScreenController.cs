using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Classes.User_Interface
{
    class GameScreenController : MonoBehaviour
    {
        [SerializeField] private Text _ScoreLabel = null;
        [SerializeField] private Text _LivesLabel = null;
        [SerializeField] private Text _HighScoreLabel = null;

        private void Start ()
        {
            _HighScoreLabel.gameObject.SetActive (false);
        }

        public void UpdateScoreLabel (uint score)
        {
            _ScoreLabel.text = "Score: " + score.ToString ();
        }

        public void UpdateHighScoreLabel (uint highScore)
        {
            _HighScoreLabel.gameObject.SetActive (true);

            _HighScoreLabel.text = "High Score: " + highScore.ToString ();
        }

        public void UpdateLivesLabel (int lives)
        {
            _LivesLabel.text = "Lives " + lives.ToString ();
        }
    }
}
