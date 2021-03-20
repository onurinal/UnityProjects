using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassButtonLimit : MonoBehaviour
{
    TestingQuestions TestingQuestions;
    ButtonActivities ButtonActivities;

    public void passQuestion()
    {
        TestingQuestions = gameObject.GetComponent<TestingQuestions>();
        ButtonActivities = gameObject.GetComponent<ButtonActivities>();

        TestingQuestions.PassCounter++;

        if (TestingQuestions.PassCounter <= 3)
        {
            TestingQuestions.TimeLeft = 11.7f;
            if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                TestingQuestions.PassButtonLimit.text = "( " + (3 - TestingQuestions.PassCounter) + " hakkın kaldı )";
            }
            else if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                TestingQuestions.PassButtonLimit.text = "( " + (3 - TestingQuestions.PassCounter) + " left )";
            }
            ButtonActivities.disableButtons();
            StartCoroutine(TestingQuestions.wait());
        }
        else
            {
            if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "Turkish")
            {
                TestingQuestions.PassButtonLimit.text = "( Hiç Hakkın kalmadı )";
            }
            else if (PlayerPrefs.GetString("LeanLocalization.CurrentLanguage") == "English")
            {
                TestingQuestions.PassButtonLimit.text = "( You can no longer use )";
            }
            disablePassButton();
            }
            /* This part is for Pass Button. The player has 3 rights to pass the question If PassCounter smaller than eqaul to 3 it will work.
             * Otherwise the player can not use pass button. They have to answer the questions
             */
    }
    void disablePassButton()
    {
        TestingQuestions.PassButton.enabled = false;
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        TestingQuestions.PassButtonLimit.text = "";
        TestingQuestions.PassButton.enabled = true;
    }

}