using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SPLUNGES,
    SWITCH
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
   
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public static void PlaySound(SoundType sound, float volume = 1)
    {
        if(instance != null) { 
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }
}
