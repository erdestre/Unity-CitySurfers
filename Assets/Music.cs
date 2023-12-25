using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceMusic, audioSourceSfx;
    [SerializeField] AudioClip inGameMusic, menuMusic, coinCollectSfx, playerDeathSfx, scoreBoardSfx;

    public void ChangeMusicToInGame()
    {
        audioSourceMusic.clip = inGameMusic;
        audioSourceMusic.Play();
    }
    public void PlaySfx(AudioClip audioClip)
    {

    }
}
