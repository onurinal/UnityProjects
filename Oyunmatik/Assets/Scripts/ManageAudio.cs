using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageAudio : MonoBehaviour
{
    DontDestroy dontDestroy;
    GameObject MenuMusic;
    public Button MusicOn, MusicOff, SoundOn, SoundOff;
    ColorBlock colors;
    ColorBlock colors1;
    string CheckingScenes;

    void Awake()
    {
        MenuMusic = GameObject.FindGameObjectWithTag("Music");
        dontDestroy = gameObject.GetComponent<DontDestroy>();
        /* This code is finding a tag which name is Music .
         * This tag is connected with static DontDestroy Music;
         * I had to do this. If i dont use i can't stop or play "Menu music" anymore when i want.
         * Because my DontDestory.cs script has DontDestroyOnLoad function and static Music variable. I can lose my previous
         * gameObject and values in this script when i load a new scene.
         */
    }
    void Start()
    {
        CheckingScenes = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if (CheckingScenes == "Settings")
        {
            if (PlayerPrefs.GetInt("isMusicOn") == 1)
            {
                colors1 = MusicOff.colors;
                colors1.normalColor = new Color32(55, 48, 48, 255);
                MusicOff.colors = colors1;
                colors = MusicOn.colors;
                colors.normalColor = Color.white;
                MusicOn.colors = colors;
            }
            else
            {
                colors = MusicOn.colors;
                colors.normalColor = new Color32(55, 48, 48, 255);
                MusicOn.colors = colors;
                colors1 = MusicOff.colors;
                colors1.normalColor = Color.white;
                MusicOff.colors = colors1;
            }
            if (PlayerPrefs.GetInt("isSoundOn") == 1)
            {
                colors1 = SoundOff.colors;
                colors1.normalColor = new Color32(55, 48, 48, 255);
                SoundOff.colors = colors1;
                colors = SoundOn.colors;
                colors.normalColor = Color.white;
                SoundOn.colors = colors;
            }
            else
            {
                colors = SoundOn.colors;
                colors.normalColor = new Color32(55, 48, 48, 255);
                SoundOn.colors = colors;
                colors1 = SoundOff.colors;
                colors1.normalColor = Color.white;
                SoundOff.colors = colors1;
            }
            /* This codes only working in Settings Menu. It is changing colour of the buttons according to button activity
             * If CheckingSound is 1 - > Sound On and if CheckingSound is 0 it means Sound Off
             * And then Sound On button will be white and Sound Off button will be a little gray
             */
        }
    }
    public void PlayMenuMusic()
    {
        if (MenuMusic.GetComponent<AudioSource>().isPlaying)
        {
            return;
        }
        MenuMusic.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("isMusicOn", 1);
    }
    public void StopMenuMusic()
    {
        MenuMusic.GetComponent<AudioSource>().Stop();
        PlayerPrefs.SetInt("isMusicOn", 0);
    }

    public void StopSound()
    {
        PlayerPrefs.SetInt("isSoundOn", 0);
    }
    public void PlaySound()
    {
        PlayerPrefs.SetInt("isSoundOn", 1);
    }
}