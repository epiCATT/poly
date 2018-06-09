using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    public Image CustomImage1;
    public Image CustomImage2;
    public Image CustomImage3;
    public Text text1;
    public Text text2;
    public Text text3;
    public GameObject Panel;


    public void On()
    {
        if(CustomImage1.gameObject.activeSelf)
        {
            CustomImage1.gameObject.SetActive(false);
            CustomImage2.gameObject.SetActive(false);
            CustomImage3.gameObject.SetActive(false);
            text1.gameObject.SetActive(false);
            text2.gameObject.SetActive(false);
            text3.gameObject.SetActive(false);
            Panel.SetActive(false);
        }
        else
        {
            CustomImage1.gameObject.SetActive(true);
            CustomImage2.gameObject.SetActive(true);
            CustomImage3.gameObject.SetActive(true);
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(true);
            text3.gameObject.SetActive(true);
            Panel.SetActive(true);

        }

    }

    
}
