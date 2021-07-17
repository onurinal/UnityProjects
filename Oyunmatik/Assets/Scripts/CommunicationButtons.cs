using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationButtons : MonoBehaviour
{
    public void getInstagram()
    {
        Application.OpenURL("https://www.instagram.com/onuriinall");
    }
    public void getTwitter()
    {
        Application.OpenURL("https://www.twitter.com/onuriinall");
    }
}
