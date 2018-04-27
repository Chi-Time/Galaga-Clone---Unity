using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Code.Classes.User_Interface
{
    sealed class GameOverScreenController : MonoBehaviour
    {
        [SerializeField] private GameObject _SelectedButton = null;

        private void OnEnable ()
        {
            EventSystem.current.SetSelectedGameObject (_SelectedButton.gameObject, null);
        }

        public void LoadScene (int level)
        {
            SceneManager.LoadScene (level);
        }
    }
}
