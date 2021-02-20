using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelByIndex : MonoBehaviour
{
    public void OpenScene(int levelIndex)
    {
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
