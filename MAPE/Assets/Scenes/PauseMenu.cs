using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }

                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void OpenMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Debug.Log("Fermeture du jeu...");
            Application.Quit();
        }
    }
}
