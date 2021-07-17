using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    DontDestroy dontDestroyDatas;
    int isMusicOn;
    // public static int CheckingSound = 1; 
    /* Static variable need because i need an global and unchanged by any factor ( like new scenes )
       So i am using this static variables for Settings Menu.                                
    */
    void Awake()
    {
        int dontDestroyCount = FindObjectsOfType<DontDestroy>().Length;
        if (dontDestroyCount > 1 )
        {
            Destroy(gameObject);    
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("isMusicOn"))
        {
            
            if(PlayerPrefs.GetInt("isMusicOn") == 0)
            {
                GetComponent<AudioSource>().Stop();
            }
            else if(PlayerPrefs.GetInt("isMusicOn") == 1)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            PlayerPrefs.SetInt("isMusicOn", 1);
            GetComponent<AudioSource>().Play();
        }
        if (!PlayerPrefs.HasKey("isSoundOn"))
        {
            PlayerPrefs.SetInt("isSoundOn", 1);
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep; // prevent android phone from going to sleep
        /* void start() part is only for playing Menu Music in the beginning
         * and the part above is not destroying the menu music for another scenes ..
         * If i don't add DontDestroyOnLoad(gameObject), menu music will stop when new scenes will load
         */
    }
}
