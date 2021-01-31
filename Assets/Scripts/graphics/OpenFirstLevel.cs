using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFirstLevel : MonoBehaviour
{
    public void OpenScene()
    {
        Application.LoadLevel("Level 1");
    }
}
