using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class SoundtrackManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip[] ostArray;

    private void Awake() {

        audioSource = GetComponent<AudioSource>();
        ostArray = Resources.LoadAll<AudioClip>("OST");
        string sceneNameLowerCase = SceneManager.GetActiveScene().name.ToLower();

        //looking for the dedicated level ost
        for (int i = 0; i < ostArray.Length; i++) {
            
            string ostNameLowerCase = ostArray[i].name.ToLower();

            if (sceneNameLowerCase.Contains(ostNameLowerCase)) {
                audioSource.clip = ostArray[i];
                StartCoroutine(MusicFadeIn(2f));
                return;
            }
        }
        //no dedicated ost found - load default soundtrack
        audioSource.clip = ostArray.FirstOrDefault(o => o.name.Contains("Default")); ;
        StartCoroutine(MusicFadeIn(2f));
    }

    IEnumerator MusicFadeIn(float fadeIn) {
        audioSource.volume = 0.0f;
        audioSource.Play();
        audioSource.DOFade(1.0f, fadeIn);

        yield return null;
    }

    private void OnLevelWasLoaded(int level) {
        Awake();
    }
}
