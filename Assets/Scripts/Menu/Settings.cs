using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;

    public void return2(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void SetScreenResolution(int i)
    {

    }
    public void fullscreen(bool isFullScreen)
    {

    }

    public void SetVolume(float value)
    {

    }

    public void setMusic(float value)
    {

    }
}
