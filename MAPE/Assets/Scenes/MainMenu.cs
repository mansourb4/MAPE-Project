using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject settingsPanel;
        public GameObject startPanel;
        public GameObject musicPanel;
        public GameObject controlsPanel;
        public GameObject creditsPanel;
        public GameObject onlinePanel;
        public GameObject localPanel;
        public GameObject soloPanel;
        public GameObject duoPanel;

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }
    
        public void ExitGame()
        {
            Debug.Log("Fermeture du Jeu");
            Application.Quit();
        }

        public void OpenSettings()
        {
            settingsPanel.SetActive(true);
        }
    
        public void CloseSettings()
        {
            settingsPanel.SetActive(false);
        }

        public void OpenStart()
        {
            startPanel.SetActive(true);
        }
    
        public void CloseStart()
        {
            startPanel.SetActive(false);
        }

        public void OpenMusic()
        {
            musicPanel.SetActive(true);
        }
    
        public void CloseMusic()
        {
            musicPanel.SetActive(false);
        }

        public void OpenControls()
        {
            controlsPanel.SetActive(true);
        }
    
        public void CloseControls()
        {
            controlsPanel.SetActive(false);
        }

        public void OpenCredits()
        {
            creditsPanel.SetActive(true);
        }
    
        public void CloseCredits()
        {
            creditsPanel.SetActive(false);
        }

        public void OpenOnline()
        {
            onlinePanel.SetActive(true);
        }
    
        public void CloseOnline()
        {
            onlinePanel.SetActive(false);
        }

        public void OpenLocal()
        {
            localPanel.SetActive(true);
        }
    
        public void CloseLocal()
        {
            localPanel.SetActive(false);
        }

        public void OpenSolo()
        {
            soloPanel.SetActive(true);
        }
    
        public void CloseSolo()
        {
            soloPanel.SetActive(false);
        }

        public void OpenDuo()
        {
            duoPanel.SetActive(true);
        }
        
        public void CloseDuo()
        {
            duoPanel.SetActive(false);
        }

        public void OpenAkomiScene()
        {
            SceneManager.LoadScene(1);
        }

        public void OpenGentaroScene()
        {
            SceneManager.LoadScene(2);
        }
        
        public void OpenHeiraScene()
        {
            SceneManager.LoadScene(3);
        }
        
        public void OpenKettewenScene()
        {
            SceneManager.LoadScene(4);
        }
    }
}
