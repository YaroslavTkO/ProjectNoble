using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AudioClip musicClip;
    public float musicVolume;
    private AudioSource musicAudioSource;
    public static Background _instance;

    public AudioSource jumpSound;
    public AudioSource buttonSound;
    public AudioSource collisionSound;

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
        jumpSound.volume = globalVolume;
        buttonSound.volume = globalVolume;
        collisionSound.volume = globalVolume;


    }

    public void JumpSound()
    {
        jumpSound.Play();
    }
    public void ButtonSound() {
        buttonSound.Play();
    }
    public void CollisionSound()
    {
        collisionSound.Play();
    }


    void Start()
    {
        
        musicAudioSource.Play();
    }


}