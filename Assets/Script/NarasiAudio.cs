using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarasiAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] narasiAudio;

    public void PlayAudio(int index)
    {
        audioSource.clip = narasiAudio[index];
        audioSource.Play();
    }

    //jika audio tidak ada, tampilkan debug audio tidak ditemukan
    public void PlayAudio(string audioName)
    {
        AudioClip audio = null;
        foreach (var item in narasiAudio)
        {
            if (item.name == audioName)
            {
                audio = item;
                break;
            }
        }

        if (audio != null)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Audio " + audioName + " tidak ditemukan");
        }
    }
}
