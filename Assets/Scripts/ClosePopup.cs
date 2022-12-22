using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    public GameObject popup;

    public void PopupClose()
    {
        popup.SetActive(false);     
    }
   
}
