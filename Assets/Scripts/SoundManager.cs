using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip[] Death;
    public AudioClip[] Pick;
    public AudioClip[] Win;

    AudioSource _source;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.loop = false;
    }

    public void PlayDeathSound()
    {
        PlayRandomClip(Death);
    }

    public void PlayPickSound()
    {
        PlayRandomClip(Pick);
    }

    public void PlayWinSound()
    {
        PlayRandomClip(Win);
    }

    private void PlayRandomClip(AudioClip[] clips)
    {
        _source.clip = clips[(int)Random.Range(0f, (float)clips.Length)];
        _source.Play();
    }

}
