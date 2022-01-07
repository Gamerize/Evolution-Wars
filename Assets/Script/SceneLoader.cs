using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject StartMenuCanvas;
    [SerializeField] GameObject PauseMenuCanvas;
    [SerializeField] GameObject GameplayUICanvas;

    // Start is called before the first frame update
    void Start()
    {       
        StartMenuCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        GameplayUICanvas.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameStart()
    {       
        StartMenuCanvas.SetActive(false);
        GameplayUICanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Continue()
    {       
        PauseMenuCanvas.SetActive(false);
        GameplayUICanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Paused()
    {      
        PauseMenuCanvas.SetActive(true);
        GameplayUICanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited Game");
    }
}
