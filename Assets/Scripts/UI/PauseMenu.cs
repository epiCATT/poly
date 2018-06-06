using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void update () {
        
        if (GameIsPaused)
        {
            Resume();
        }else
        {
            Pause();
        }
    }
    

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void quit()
    {
        Application.Quit();
    }
}
