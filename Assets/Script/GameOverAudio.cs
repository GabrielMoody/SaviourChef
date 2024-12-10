using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    public AudioSource gameOverAudio;

    private void Awake()
    {
        gameOverAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        gameOverAudio.Play();
    }
}
