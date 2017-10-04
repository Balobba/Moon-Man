using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{


    public static bool mcExists;

    public AudioSource[] musicTracks;

    public int currentTrack;
    public bool musicCanPlay;

    public AudioMixer masterMixer;

    private float savedMusicVol;

    // Use this for initialization
    void Start()
    {
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();


            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }


        SaveSliderValue();

    }


    public void SwitchTrack(int newTrack)
    {

        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();

    }

    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("SliderMusicVolumeLevel", savedMusicVol); //Saves slider value to a global variable PlayerPrefs

        //Debug.Log("music volume is: " + PlayerPrefs.GetFloat("SliderMusicVolumeLevel"));
        //Debug.Log("savedMusicVol: " + savedMusicVol);
    }




    public void SetSFXVolMenu(float sfxvol)
    {
        masterMixer.SetFloat("sfxvol", sfxvol);

    }

    public void SetMusicVolMenu(float musicvol)
    {
        masterMixer.SetFloat("musicvol", musicvol);
       // Debug.Log("musicvol: " + musicvol);
        savedMusicVol = musicvol;

    }

}
