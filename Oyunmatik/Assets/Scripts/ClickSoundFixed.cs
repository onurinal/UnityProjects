using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundFixed : MonoBehaviour
{
    DontDestroy dontDestroy;
    public AudioSource ClickSound;

    void Awake()
    {
        dontDestroy = gameObject.GetComponent<DontDestroy>();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject); 
    }

    public void PlayClickSound()
    {
        if(PlayerPrefs.GetInt("isSoundOn") == 1) // to check whether the sound is off or on...
        {
            ClickSound.Play();
            StartCoroutine(wait());
        }
        StartCoroutine(wait());
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

        /* This function needed because i need to destroy gameobject.
         * If i don't , The game duplicate game object over and over again when a new scene load.
         * That's why i need this function.
        */
    }
}
