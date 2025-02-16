using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SPLUNGESRUN,
    SPLUGEHITONWALL
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;
    private SoundType[] soundstoPlayOntheNextturn;

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
        soundstoPlayOntheNextturn = new SoundType[0];
    }



    public static void PlaySound(SoundType sound, float volume = 1)
    {
        if(instance != null) { 
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }

    public static void AddSoundToNextTurn(SoundType newSound)
    {
        // Verificar si el sonido ya está en el array
        foreach (SoundType sound in instance.soundstoPlayOntheNextturn)
        {
            if (sound == newSound)
            {
                return; // Si ya está, no lo agregamos
            }
        }

        // Si no estaba, agregarlo a un array más grande
        Array.Resize(ref instance.soundstoPlayOntheNextturn, instance.soundstoPlayOntheNextturn.Length + 1);
        instance.soundstoPlayOntheNextturn[instance.soundstoPlayOntheNextturn.Length - 1] = newSound;
    }

    public static void PlayTurnSound(SoundType sound, float volume = 1)
    {
        if (instance != null)
        {
            instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }

    public static void PlayAllSoundsAndClear()
    {
        // Reproducir todos los sonidos en el array
        foreach (SoundType sound in instance.soundstoPlayOntheNextturn)
        {
            if (sound == SoundType.SPLUNGESRUN && Array.Exists(instance.soundstoPlayOntheNextturn, thisSound => thisSound == SoundType.SPLUGEHITONWALL)) { continue; }
            if (GameManager.Instance.State == GameState.Lose) { continue; } 
            PlaySound(sound);
        }

        // Vaciar el array después de reproducir los sonidos
        instance.soundstoPlayOntheNextturn = new SoundType[0];
    }
}
