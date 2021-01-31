using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCredits : MonoBehaviour
{
    public GameObject creditsPanel;
    
    public void Toggle()
    {
        creditsPanel.SetActive (!creditsPanel.activeSelf);
    }

}
