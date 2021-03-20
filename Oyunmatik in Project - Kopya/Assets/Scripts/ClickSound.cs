using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource PlayClickSound;
    DontDestroy dontDestroy;

     void Awake()
    {
        dontDestroy = gameObject.GetComponent<DontDestroy>();
    }
    public void playClickSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)  // to check whether the sound is off or on...
        {
            PlayClickSound.Play();
        }
        return;
    }
}
