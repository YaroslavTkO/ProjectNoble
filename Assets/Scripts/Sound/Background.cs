using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AudioClip musicClip;
    public float musicVolume;
    private AudioSource musicAudioSource;
    public static Background _instance;

    public float globalVolume;


    void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        musicAudioSource = gameObject.AddComponent<AudioSource>();
        musicAudioSource.clip = musicClip;
        musicAudioSource.loop = true;
        musicAudioSource.volume = musicVolume;
    }

    public void UpdateGlobalVolume(float newVolume)
    {
        Debug.Log(newVolume);
        globalVolume = newVolume;
        musicAudioSource.volume = globalVolume * musicVolume;

    }




    void Start()
    {
        
        musicAudioSource.Play();
    }


}