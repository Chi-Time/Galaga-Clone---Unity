using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Classes.User_Interface
{
    class MainMenuScreenController : MonoBehaviour
    {
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
