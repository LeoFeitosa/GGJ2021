using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    AudioSource effectSource;

    [SerializeField]
    AudioSource musicSource;

    [SerializeField]
    AudioClip[] playlist;

    [SerializeField]
    AudioClip[] soundlist;

    /*temporario*/
    [SerializeField]
    float volumeMaxMusic = 1;

    [SerializeField]
    float volumeMaxFx = 1;

    //troca de musica
    AudioClip newMusic;

    void Start()
    {
        SceneMusic("Level1");
        ChangeVolumeMusic(0.2f);
    }

    void ChangeMusic(AudioClip clip)
    {
        if (newMusic != clip)
        {
            newMusic = clip;
            StartCoroutine("DelayChangeMusic");
        }
    }

    public void ChangeVolumeMusic(float volume)
    {
        volumeMaxMusic = volume;

        musicSource.volume = volume;
    }

    public void ChangeVolumeEffects(float volume)
    {
        volumeMaxFx = volume;
    }

    IEnumerator DelayChangeMusic()
    {
        for (float volume = volumeMaxMusic; volume >= 0; volume -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            musicSource.volume = volume;
        }

        musicSource.volume = 0;
        musicSource.clip = newMusic;
        musicSource.Play();

        for (float volume = 0; volume < volumeMaxMusic; volume += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            musicSource.volume = volume;
        }

        musicSource.volume = volumeMaxMusic;
    }

    public void SceneMusic(string musicName)
    {
        if (musicName != null)
        {
            int key = 0;

            foreach (AudioClip clip in playlist)
            {
                if (musicName == clip.name)
                {
                    ChangeMusic(playlist[key]);
                }
                key++;
            }
        }
    }

    public void EffectSound(string soundName)
    {
        if (soundName != null)
        {
            int key = 0;

            foreach (AudioClip clip in soundlist)
            {
                if (soundName == clip.name)
                {
                    effectSource.PlayOneShot(soundlist[key], volumeMaxFx);
                }
                key++;
            }
        }
    }
}
