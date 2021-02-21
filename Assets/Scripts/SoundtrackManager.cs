using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundtrackManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip[] ostArray;
    private int previousLevel;

    public Toggle AudioToggle;
    bool isMuted;

    private void Awake() {
        AudioToggle = GameObject.FindGameObjectsWithTag("AudioMute")[0].GetComponent<Toggle>();
        AudioToggle.onValueChanged.AddListener(MuteAudio);
        MuteAudio(AudioToggle.isOn);

        previousLevel = SceneManager.GetActiveScene().buildIndex;
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

    void InitializeAllAudioSources()
    {
        var sources = GameObject.FindObjectsOfType<AudioSource>();

        foreach (var item in sources)
        {
            if (isMuted)
            {
                item.volume = .0f;
            }
        }
    }

    IEnumerator MusicFadeIn(float fadeIn) {
        AudioToggle.isOn = isMuted;

        if (!isMuted)
        {
            audioSource.volume = 0.0f;
            audioSource.Play();
            audioSource.DOFade(.5f, fadeIn);
        }

        yield return null;
    }

    private void OnLevelWasLoaded(int level) {
        InitializeAllAudioSources();

        if (SceneManager.GetActiveScene().buildIndex != previousLevel)
        {
            Awake();
        }
    }

    void MuteAudio(bool value)
    {
        audioSource.volume = value ? .0f : .5f;
        isMuted = value;
        InitializeAllAudioSources();
    }
}
