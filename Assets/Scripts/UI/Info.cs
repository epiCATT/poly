using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    public Image CustomImage;

    public void On()
    {
        if(CustomImage.gameObject.activeSelf)
        {
            CustomImage.gameObject.SetActive(false);
        }
        else
        {
            CustomImage.gameObject.SetActive(true);
        }

    }

    
}
