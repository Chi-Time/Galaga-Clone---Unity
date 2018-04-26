using UnityEngine;

namespace Assets.Code.Classes
{
    class GameController : MonoBehaviour
    {
        [SerializeField] private uint _Score = 0;
        [SerializeField] private uint _HighScore = 0;

        public void IncreaseScore (uint score)
        {
            _Score += score;

            if (_Score >= _HighScore)
                _HighScore = _Score;
        }
    }
}
