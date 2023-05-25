using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenu : MonoBehaviour
{
    public static CharacterMenu Instance;

    private void Awake() => Instance = this;
    
    public static bool GameIsPaused = false;
    public GameObject characterMenuUI;
    private string _playerName;

    public void Resume()
    {
        characterMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    

    public void InstantiateHero(string heroName)
    {
        _playerName = heroName;
        Resume();
    }

    public string GetPlayerName()
    {
        return _playerName;
    }
}