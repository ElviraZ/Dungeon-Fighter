using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    public AudioClip[] audioClipArray;
    [HideInInspector]
    public AudioSource musicSource;
    [HideInInspector]
    public AudioSource soundfxSource;
    [HideInInspector]
    public AudioSource TeachSource;
    [HideInInspector]
    public AudioSource tipSource;

    void Awake()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
     //   musicSource.volume = GlobelScene.MainVolume;
        musicSource.loop = true;

        soundfxSource = gameObject.AddComponent<AudioSource>();
        soundfxSource.loop = false;
        //soundfxSource.volume = GlobelScene.FXVolume;

        TeachSource = gameObject.AddComponent<AudioSource>();
        TeachSource.loop = false;
        TeachSource.volume = 1;

        tipSource = gameObject.AddComponent<AudioSource>();
        tipSource.loop = false;
        tipSource.volume = 1;

        instance = this;
        foreach (AudioClip ac in audioClipArray)
        {
            if (audioDict.ContainsKey(ac.name) == false)
            {
                audioDict.Add(ac.name, ac);
            }

        }
    }
    // Use this for initialization
    public void PlayMusic(string audioName,float  volume=1f)
    {
        AudioClip ac;
        if (audioDict.TryGetValue(audioName, out ac))
        {
            musicSource.clip = ac;
            musicSource.volume = volume;
            musicSource.Play();
        }
    }

    public void StopFX()
    {
        soundfxSource.Stop();
    }
    public void Stop()
    {
        musicSource.Stop();
    }
    public void StopAll()
    {
        musicSource.Stop();
        soundfxSource.Stop();
        TeachSource.Stop();
        tipSource.Stop();
    }
    public void PlayFX(string audioName)
    {
        AudioClip clip;
        if (audioDict.TryGetValue(audioName, out clip))
        {
            soundfxSource.clip = clip;
            soundfxSource.Play();
        }
    }
    float cliplength = 0;
    public void PlayTeach(string audioName)
    {
        AudioClip clip;
        if (audioDict.TryGetValue(audioName, out clip))
        {
            TeachSource.clip = clip;
            this.cliplength = clip.length;
            TeachSource.Play();
        }
    }

    public float PlayTip(string audioName)
    {
        AudioClip clip;
        if (audioDict.TryGetValue(audioName, out clip))
        {
            TeachSource.Stop();
            tipSource.clip = clip;
            tipSource.Play();
            return clip.length;
        }
        return 0;
    }


  
}

