using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Code.Classes.User_Interface
{
    class MainMenuScreenController : MonoBehaviour
    {
        [SerializeField] private GameObject _SelectedButton = null;

        private void OnEnable ()
        {
            EventSystem.current.SetSelectedGameObject (_SelectedButton, null);
        }

        public void StartGame (int level)
        {
            SceneManager.LoadScene (level);
        }

        public void ShowOptions (GameObject optionsScreen)
        {
            optionsScreen.SetActive (true);
            this.gameObject.SetActive (false);
        }

        public void QuitGame ()
        {
            Application.Quit ();
        }
    }
}
