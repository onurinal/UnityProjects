using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BlockBreaker.ManagerSystem
{
    public class ScoreManager : MonoBehaviour
    {
       [SerializeField] private TextMeshProUGUI _scoreText; // to show score in gameplay
       [SerializeField] private TextMeshProUGUI _winPanelScoreText; // to show score in win panel
       [SerializeField] private TextMeshProUGUI _losePanelScoreText; // to show score in lose panel
       [SerializeField] private int _currentScore;
       
       // WIN AND LOSE PANEL MANAGEMENT
       [SerializeField] private GameObject _gameplayCanvas;

       public static ScoreManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        // ----------------------- ADDING SCORE ---------------
        public void AddToScore(int perPointBlockDestroyed)
        {
            _currentScore = _currentScore + perPointBlockDestroyed;
            _scoreText.text = _currentScore.ToString();
        }
        public void ShowWinPanel(int playerLife)
        {
            // If you complete the any level when you have 3 life then get 3 star
            // 3 Player life -> 3 Star
            // 2 Player life -> 2 Star
            // 1 Player life -> 1 Star
            
            // gets the third child of the GameplayCanvas object
            _gameplayCanvas.transform.GetChild(2).gameObject.SetActive(true);
            _winPanelScoreText.text = _currentScore.ToString();
            if (playerLife == 3)
            {
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(3).gameObject.SetActive(true);
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(4).gameObject.SetActive(true);
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(5).gameObject.SetActive(true);
            }
            else if (playerLife == 2)
            {
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(3).gameObject.SetActive(true);
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(4).gameObject.SetActive(true);
            }
            else
            {
                _gameplayCanvas.transform.GetChild(2).GetChild(6).GetChild(3).gameObject.SetActive(true);
            }
        }
        public void ShowLosePanel()
        {
            _gameplayCanvas.transform.GetChild(3).gameObject.SetActive(true);
            _losePanelScoreText.text = _currentScore.ToString();
        }
    }
}
