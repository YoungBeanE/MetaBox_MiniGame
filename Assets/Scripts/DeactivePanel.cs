using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactivePanel : MonoBehaviour
{

    public GameObject panel;
    public GameObject block;

    public void ClosePanel()
    {
        if (panel.activeInHierarchy == true)
        {
            activeblock();
            panel.SetActive(false);
        }
        else
            panel.SetActive(true);
        
    }

    public void activeblock()
    {
        if (block.activeInHierarchy == false)
            block.SetActive(true);
        else
            block.SetActive(false); 
    }
}