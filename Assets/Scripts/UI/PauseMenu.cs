using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public PhotonView View;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Update()
    {
        if(View.isMine && Input.GetKeyDown(KeyCode.Escape))
        {
            Actualize();
        }
    }

    public void Actualize()
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
    

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
