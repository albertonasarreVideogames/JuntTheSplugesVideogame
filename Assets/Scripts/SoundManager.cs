using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SPLUNGESRUN,
    SPLUGEHITONWALL,
    SPUNGEJUMP,
    SPLINGEFALLING,
    SWITCHDOWN
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;
    private AudioSource audioSourceOst;
    private SoundType[] soundstoPlayOntheNextturn;
    private SoundType[] PlaySoundOnTimeBuffer;

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
        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSource = audioSources[0];
        audioSourceOst = audioSources[1];
        soundstoPlayOntheNextturn = new SoundType[0];
    }

    public static void StartOst()
    {
        if (instance == null) { return; }
        instance.audioSourceOst.Play();
    }



    public static void PlaySound(SoundType sound, float volume = 1)
    {
        if(instance != null) { 
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
        }
    }

    public static void AddSoundToNextTurn(SoundType newSound)
    {
        if (instance == null) { return; }

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
        if (instance == null) { return; }
        // Reproducir todos los sonidos en el array
        foreach (SoundType sound in instance.soundstoPlayOntheNextturn)
        {
            if (sound == SoundType.SPLUNGESRUN && (Array.Exists(instance.soundstoPlayOntheNextturn, thisSound => thisSound == SoundType.SPLUGEHITONWALL|| Array.Exists(instance.soundstoPlayOntheNextturn, thisSound2 => thisSound2 == SoundType.SPUNGEJUMP)))) { continue; }
            if (GameManager.Instance.State == GameState.Lose) { continue; } 
            PlaySound(sound);
        }

        // Vaciar el array después de reproducir los sonidos
        instance.soundstoPlayOntheNextturn = new SoundType[0];
    }

    public static void PlaySoundONCE(SoundType sound, float volume = 1)
    {
        if (instance != null && !Array.Exists(instance.PlaySoundOnTimeBuffer, thisSound => thisSound == sound))
        {
            instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
            AddSoundToBuffer(sound);
        }
    }

    public static void cleanSoundToBuffer()
    {
        if (instance != null) {
        instance.PlaySoundOnTimeBuffer = new SoundType[0];
        }
    }

    private static void AddSoundToBuffer(SoundType newSound)
    {
        // Verificar si el sonido ya está en el array
        foreach (SoundType sound in instance.PlaySoundOnTimeBuffer)
        {
            if (sound == newSound)
            {
                return; // Si ya está, no lo agregamos
            }
        }

        // Si no estaba, agregarlo a un array más grande
        Array.Resize(ref instance.PlaySoundOnTimeBuffer, instance.PlaySoundOnTimeBuffer.Length + 1);
        instance.PlaySoundOnTimeBuffer[instance.PlaySoundOnTimeBuffer.Length - 1] = newSound;
    }
}
