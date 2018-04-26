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

        public void IncreaseScore (uint score)
        {
            _Score += score * Multiplier;

            if (_Score >= _HighScore)
                _HighScore = _Score;
        }

        public void GameOver ()
        {
            SceneManager.LoadScene ((2));
        }
    }
}
