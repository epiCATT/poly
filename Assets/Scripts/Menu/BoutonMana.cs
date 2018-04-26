using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonMana : MonoBehaviour {

	public  void SingleBtn(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }
    public void MultiBtn(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }
    public void OptionBtn(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene);
    }

    public void exitbtn()
    {
        Application.Quit();
    }
}
