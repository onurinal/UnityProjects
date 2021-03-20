using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestingQuestions : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject OriginalCanvas;
    public GameObject AnimationCanvas, mathDuelWinnerAnim, duelGameOverPanel;
    public TextMeshProUGUI PassButtonLimit;
    public TextMeshProUGUI TrueCounting, WrongCounting, trueCounting2, wrongCounting2;
    public TextMeshProUGUI TrueCountingOver, WrongCountingOver;
    public TextMeshProUGUI RandomQuestion, randomQuestion2;
    public TextMeshProUGUI[] Guesses;
    public TextMeshProUGUI[] Guesses2 = new TextMeshProUGUI[4];
    public TextMeshProUGUI Answers;
    public TextMeshProUGUI TimeLeftText, duelTimeleftText, duelTimeleftText2;
    public Button Guess1, Guess2, Guess3, Guess4, PassButton, guess2to1, guess2to2, guess2to3, guess2to4;
    public Sprite[] CorrectOrIncorrect = new Sprite[2];  // This Sprite variables are just emote.. If the player choose true answer it will get check mark( tick) otherwise error.
    public AudioSource TrueSound, WrongSound, DefeatSound, victorySound, countdownSound;
    public Animator animator;

    public int randomResult, result, temp, randomIndex, DigitChoices = 0;
    public int[] randomResultList = new int[4];  // to make randomly results. Why size 4? Because the questions have 4 answer option
    public int[] GuessList = { 0, 1, 2, 3 };     // to make randomly guesses . Guesses are buttons.
    public int[] TwoNumInOneList = { 0, 1 };         // to generate random order in 2 numbers which one number is two-digit or more. Ex : 5 + 72 or 72 + 5
    public int[] ThreeNumInOneList = { 0, 1, 2 };    // to generate random order in 2 numbers which one number is two-digit or more. Ex : 5 + 72 + 3 or 3 + 5 + 72
    public int[] FourNumInOneList = { 0, 1, 2, 3 };  // to generate random order in 2 numbers which one number is two-digit or more. Ex : 5 + 72 + 3 + 8 or 3 + 5 + 72 + 8
    public int[] MaxNumberList = new int[4];         // to make randomly numbers for results. I am generate 4 random numbers with this list.
    public int WrongCounter = 0, TrueCounter = 0, trueCounter2 = 0, PassCounter = 0, AdditionCount = 0, SubtractionCount = 0, MultiplicationCount = 0, DivisionCount = 0;
    public int TrueOrFalse; // for true or wrong condition and sounds
    public int[] SpecialList = new int[17]; // for players who loves the hard questions, 17 possibility similar random answers... 
    public int[] FactorList = new int[50]; public int FactorCounter = 0, PrimeCounter = 0;  // for Division part...
    public int CheckFunctionNumber = 0; public int[] FunctionNumber = { 1, 2, 3, 4, 5 };
    /* for calling functions randomly...  2 - AdditionPart 3- SubtractionPart 4- MultiplicationPart 5-Medium or Hard DivisionPart 1- EasyDivisionPart...
      Because of FindingFactors's script. These variables to call randomly functions in mix mode for my game. */
    public float TimeLeft = 11.7f;  // For 10 Seconds mode.
    string CheckScene;
    public int FixedVariableFactor = 1;  // For " 1 " number in factor list... The part which is "EasyDivision" doesn't generate " 1 " in factorlist that's why i created this.
    public float duelTimeLeft = 64.7f, duelTimeLeft2 = 64.7f;


    GenerateGuessesList GenerateGuessesList;
    GetAnswersGuesses GetAnswersGuesses;
    GameOverPOP GameOverPOP;
    CheckingScenes CheckingScenes;
    ButtonActivities ButtonActivities;
    ResumePop ResumePop;
    DontDestroy dontDestroy;

    void Awake()
    {
        CheckScene = SceneManager.GetActiveScene().name;  // Finding scene for update() function.
        GenerateGuessesList = gameObject.GetComponent<GenerateGuessesList>(); // to access values from GenerateGuessesList script.
        GetAnswersGuesses = gameObject.GetComponent<GetAnswersGuesses>();
        GameOverPOP = gameObject.GetComponent<GameOverPOP>();
        CheckingScenes = gameObject.GetComponent<CheckingScenes>();
        ButtonActivities = gameObject.GetComponent<ButtonActivities>();
        ResumePop = gameObject.GetComponent<ResumePop>();
        dontDestroy = gameObject.GetComponent<DontDestroy>();
    }


    void Start()
    {
        StartCoroutine(AnimationTime()); // Animation will start in the beginning
    }
    public IEnumerator AnimationTime()
    {
        if (CheckScene == ("EasyMathDuel") || CheckScene == ("MediumMathDuel") || CheckScene == ("HardMathDuel"))
        {
            animator.enabled = false;
            yield return new WaitForSeconds(1);
            countdownSound.Play();
            animator.enabled = true;
            yield return new WaitForSeconds(3);
            OriginalCanvas.SetActive(true); // Then i am activating the OriginalCanvas which is generating the questions
            generateQuestions();
            if (ButtonActivities.buttonControl == false)
            {
                ButtonActivities.activeButtons();
            }
            yield return new WaitForSeconds(0.1f);
            AnimationCanvas.SetActive(false); // and i am disabling the AnimationCanvas which is starting the animations

        }
        else
        {
            yield return new WaitForSeconds(1);
            AnimationCanvas.SetActive(false); // and i am disabling the AnimationCanvas which is starting the animations
            OriginalCanvas.SetActive(true); // Then i am activating the OriginalCanvas which is generating the questions
            generateQuestions();
        }

    }

    void Update()
    {
        if (CheckScene == ("Easy10Seconds") || CheckScene == ("Medium10Seconds") || CheckScene == ("Hard10Seconds")) // It's just for 10 Seconds mode.
        {
            if (TimeLeft >= 10.5f && TimeLeft <= 11.7f) // When a new question is generating it will take 1 seconds. Thats why i am giving 11 seconds and 
                                                  // I just keep the time constant for 1 second then the timer will go on.
            {
                TimeLeft -= Time.deltaTime;
                TimeLeftText.text = "10";
            }
            else if (TimeLeft < 10.5f && TimeLeft > 0.4f)
            {
                TimeLeft -= Time.deltaTime;
                TimeLeftText.text = TimeLeft.ToString("0"); // this "0" is converting time to one digit
            }
            if (TimeLeft < 0.4f && WrongCounter != 3)
            {
                TimeLeft -= Time.deltaTime;
                GameOverPOP.gameOverPop();
                TimeLeft = Mathf.Clamp(TimeLeft, 0.4f, Mathf.Infinity);  // Timer won't go below 0 in timer
            }
        }
        else if (CheckScene == ("EasyMathDuel") || CheckScene == ("MediumMathDuel") || CheckScene == ("HardMathDuel"))
        {

            if (duelTimeLeft >= 60.5f && duelTimeLeft <= 64.7f)
            {
                duelTimeLeft -= Time.deltaTime;
                duelTimeLeft2 -= Time.deltaTime;
                duelTimeleftText.text = "60";
                duelTimeleftText2.text = "60";
                TrueCounting.text = "0";
                trueCounting2.text = "0";
            }
            else if (duelTimeLeft < 60.5f && duelTimeLeft > 0.4f)
            {
                duelTimeLeft -= Time.deltaTime;
                duelTimeLeft2 -= Time.deltaTime;
                duelTimeleftText.text = duelTimeLeft.ToString("0"); // this "0" is converting time to one digit
                duelTimeleftText2.text = duelTimeLeft2.ToString("0"); // this "0" is converting time to one digit
            }
            else if (duelTimeLeft < 0.4f)
            {
                duelTimeLeft -= Time.deltaTime;
                duelTimeLeft2 -= Time.deltaTime;
                GameOverPOP.GameOverDuel();
                duelTimeLeft = Mathf.Clamp(duelTimeLeft, 0.4f, Mathf.Infinity);  // Timer won't go below 0 in timer
                duelTimeLeft2 = Mathf.Clamp(duelTimeLeft2, 0.4f, Mathf.Infinity);  // Timer won't go below 0 in timer
            }
        }
    }
    public void generateQuestions()
    {
        CheckingScenes.checkingScenes();
        GenerateGuessesList.generateGuessesList();        // generating the guesses which are buttons.
    }
    public IEnumerator wait()
    {
        if (CheckScene == "EasyMathDuel" || CheckScene == "MediumMathDuel" || CheckScene == "HardMathDuel")
        {
            yield return new WaitForSeconds(1);
            generateQuestions();
            if (mathDuelWinnerAnim.activeInHierarchy == true)
            {
                yield break;
            }
            else if (AnimationCanvas.activeInHierarchy == true)
            {
                yield break;
            }
            ButtonActivities.activeButtons();
            yield break;
        }
        yield return new WaitForSeconds(1);
        Answers.text = "";
        PassButtonLimit.text = "";
        if (WrongCounter == 3)
        {
            GameOverPOP.gameOverPop();
            ButtonActivities.activeButtons();
        }
        else
        {
            generateQuestions();
            ButtonActivities.activeButtons();
        }
    }
    public void onPressGuess1()
    {
        GetAnswersGuesses.getAnswersGuesses(0);  // FIRST BUTTON
        Minimize();
    }
    public void onPressGuess2()
    {
        GetAnswersGuesses.getAnswersGuesses(1); // SECOND BUTTON
        Minimize();
    }
    public void onPressGuess3()
    {
        GetAnswersGuesses.getAnswersGuesses(2); // THIRD BUTTON
        Minimize();
    }
    public void onPressGuess4()
    {
        GetAnswersGuesses.getAnswersGuesses(3); // AND FOURTH BUTTON
        Minimize();
    }
    public void OnPressGuess2to1()
    {
        GetAnswersGuesses.GetAnswersGuesses2(0);  // FIRST BUTTON
        Minimize2();
    }
    public void OnPressGuess2to2()
    {
        GetAnswersGuesses.GetAnswersGuesses2(1); // SECOND BUTTON
        Minimize2();
    }
    public void OnPressGuess2to3()
    {
        GetAnswersGuesses.GetAnswersGuesses2(2); // THIRD BUTTON
        Minimize2();
    }
    public void OnPressGuess2to4()
    {
        GetAnswersGuesses.GetAnswersGuesses2(3); // AND FOURTH BUTTON
        Minimize2();
    }
    public void playAgainButton()
    {
        GameOverPOP.playAgainButton();
    }
    public void PlayAgainButton()
    {
        ResumePop.playAgainButton();
    }
    public void PlayTrueSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            TrueSound.Play();
        }
        return;
    }
    public void PlayWrongSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            WrongSound.Play();
        }
        return;
    }
    public void PlayDefeatSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            DefeatSound.Play();
        }
        return;
    }
    public void PlayVictorySound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            victorySound.Play();
        }
        return;
    }
    public void PlayCountdownSound()
    {
        if (PlayerPrefs.GetInt("isSoundOn") == 1)
        {
            countdownSound.Play();
        }
        return;
    }
    void Minimize()
    {
        TrueCounting.text = "" + TrueCounter;
        if (CheckScene == "EasyMathDuel" || CheckScene == "MediumMathDuel" || CheckScene == "HardMathDuel")
        {
            return;
        }
        WrongCounting.text = "" + WrongCounter;
    }
    void Minimize2()
    {
        trueCounting2.text = "" + trueCounter2;
    }
}