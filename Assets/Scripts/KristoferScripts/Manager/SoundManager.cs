using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource,effectSource;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.playOnAwake = false;
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

    }

    private void Start()
    {
        UpdateVolumes();
        SoundManager.Instance.PlayBackgroundMusic(SettingHolder.Instance.Ambiance);
    }

    public void Play(AudioClip clip)
    {
        if (clip != null)
        {
            effectSource.PlayOneShot(clip);
        }
    }

    public void Stop()
    {
        effectSource.Stop();
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        // Don't interupt playback if the clip is already playing
        if (clip != null && clip != musicSource.clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void UpdateVolumes()
    {
        effectSource.volume = SettingHolder.Instance.VolumeFx;
        musicSource.volume = SettingHolder.Instance.VolumeMusic;
    }


}
