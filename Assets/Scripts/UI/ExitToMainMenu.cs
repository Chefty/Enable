using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    Canvas canvas;

    private void Awake() {
        canvas = GetComponent<Canvas>();    
    }

    private void LateUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape))
            canvas.enabled = true;
    }

    public void LoadMainMenu() {
        SceneManager.LoadSceneAsync(0);   
    }
}
