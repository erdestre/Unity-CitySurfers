using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceMusic, audioSourceSfx;
    [SerializeField] AudioClip inGameMusic, menuMusic;
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private Slider sfxVolumeSlider = null;


    void Start()
    {
        LoadValues();
    }
    public void VolumeSliderMusic()
    {
        float volumeValue = musicVolumeSlider.value;
        audioSourceMusic.volume = volumeValue;
        PlayerPrefs.SetFloat("MusicVolumeValue", volumeValue);
        LoadValues();
    }
    public void VolumeSliderSfx()
    {
        float volumeValue = sfxVolumeSlider.value;
        audioSourceSfx.volume = volumeValue;
        PlayerPrefs.SetFloat("SfxVolumeValue", volumeValue);
        LoadValues();
    }

    private void LoadValues()
    {
        float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolumeValue");
        float sfxVolumeValue = PlayerPrefs.GetFloat("SfxVolumeValue");
        musicVolumeSlider.value = musicVolumeValue;
        sfxVolumeSlider.value = sfxVolumeValue;
        audioSourceSfx.volume = sfxVolumeValue;
        audioSourceMusic.volume = musicVolumeValue;

    }

    public void ChangeMusicToInGame()
    {
        audioSourceMusic.clip = inGameMusic;
        audioSourceMusic.Play();
    }
    public void PlaySfx(AudioClip audioClip)
    {
        audioSourceSfx.clip = audioClip;
        audioSourceSfx.Play();
    }
    public void StopMusic()
    {
        audioSourceMusic.Stop();
    }
}
