using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BlockBreaker.ManagerSystem
{
    public class ScoreManager : MonoBehaviour
    {
       [SerializeField] private TextMeshProUGUI _scoreText;
       [SerializeField] private TextMeshProUGUI _winPanelScoreText;
       [SerializeField] private TextMeshProUGUI _losePanelScoreText;
       [SerializeField] private int _currentScore;
       
       // WIN AND LOSE PANEL MANAGEMENT
       [SerializeField] private GameObject _losePanel;
       [SerializeField] private GameObject _winPanel;
       [SerializeField] private GameObject[] _listStarRank; // to get 3-2 or 1 star when level is completed

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
            _winPanel.SetActive(true);
            _winPanelScoreText.text = _currentScore.ToString();
            if (playerLife == 3)
            {
                _listStarRank[0].SetActive(true);
                _listStarRank[1].SetActive(true);
                _listStarRank[2].SetActive(true);
            }
            else if (playerLife == 2)
            {
                _listStarRank[0].SetActive(true);
                _listStarRank[1].SetActive(true);
            }
            else
            {
                _listStarRank[0].SetActive(true);
            }
        }
        public void ShowLosePanel()
        {
            _losePanel.SetActive(true);
            _losePanelScoreText.text = _currentScore.ToString();
        }
    }
}
