using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOption : MonoBehaviour
{
    public GameObject Popup;

    public void OptionActive()
    {
        Popup.SetActive(true);
    }
}
