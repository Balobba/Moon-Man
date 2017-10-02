using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{


    public AudioMixer masterMixer;
    public Slider musicSlider;


    private void Start()
    {


        masterMixer.SetFloat("musicvol", PlayerPrefs.GetFloat("SliderMusicVolumeLevel"));
        musicSlider.value = PlayerPrefs.GetFloat("SliderMusicVolumeLevel");

    }


    public void SetSFXVol(float sfxvol)
    {
        masterMixer.SetFloat("sfxvol", sfxvol);

    }

    public void SetMusicVol(float musicvol)
    {
        masterMixer.SetFloat("musicvol", musicvol);

    }



}
