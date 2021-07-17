using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;
using BlockBreaker.Ball;
using TMPro;

namespace BlockBreaker.ManagerSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BallProperties _ballProperties; // access scriptable object
        
        // NEW BALLS MANAGEMENT
        [SerializeField] public GameObject _ballPrefab; // for create new balls

        // LIFE UI MANAGEMENT
        [SerializeField] private TextMeshProUGUI _playerLifeText;
        [SerializeField] private int _playerLife;
        
        // LEVEL MANAGEMENT
        public bool _gameEnded; // to understand game is finished or not

        public List<GameObject> BallList = new List<GameObject>(); // storing balls
        private readonly List<GameObject> _breakableBlockList = new List<GameObject>(); // storing breakable blocks

        private PaddleController _paddleController; // accessing the paddle controller
        private PowerUpManager _powerUpManager; // accessing the power up manager
        private ScoreManager _scoreManager; // accessing the power up manager
        private DataManager _dataManager;
        private LevelManager _levelManager;

        public static GameManager Instance;  // singleton
        
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AccessObjects();
            ResetGame();
            
            // ACTIVATE THIS AFTER CHANGES
            // _levelManager.GetCurrentLevel(); // to get current playing level
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && BallList.Count > 0)
            {
                if (BallList[0] != null && !BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    LaunchBall();
                }
            }
        }
        private void AccessObjects()
        {
            _paddleController = PaddleController.Instance;
            _powerUpManager = PowerUpManager.Instance;
            _scoreManager = ScoreManager.Instance;
            _dataManager = DataManager.Instance;
            _levelManager = LevelManager.Instance;
        }

        // ----------------------- LIFE MANAGEMENT ---------------
        private void ResetGame()
        {
            _playerLife = 3;
            _playerLifeText.text = _playerLife.ToString();
            CreateBall();
        }
        private void RemoveLife()
        {
            _playerLife--;
            _playerLifeText.text = _playerLife.ToString();
            //LOSE CONDITION
            if(_playerLife <= 0 && !_gameEnded)
            {
                _gameEnded = true;
                _scoreManager.ShowLosePanel();
                _powerUpManager.StopAllCoroutines();
                Destroy(_paddleController.gameObject); // Destroy the paddle when game is over
                return;
            }
            _powerUpManager.IsExtendAlive = false; // turn off extend power up effects
            _powerUpManager.IsShrinkAlive = false; // turn off shrink power up effects
            _paddleController.ResetPaddle(); // reset size and position
            _paddleController.SetUpMovementBoundaries(); // checking movement boundaries
            CreateBall();
            // DISABLE ALL COROUTINES ( POWER UPS ) WHEN LOSE LIFE
            _powerUpManager.StopAllCoroutines();
        }
        public void LostBall(GameObject ball)
        {
            BallList.Remove(ball);
            Destroy(ball);
            if(BallList.Count <= 0 && !_gameEnded)
            {
                RemoveLife();
            }
        }
        public int GetPlayerLife()
        {
            return _playerLife;
        }
        // ----------------------- CREATE THE BALL AND LAUNCH IT AT STARTING ---------------
        private void LaunchBall()
        {
             BallList[0].GetComponent<BallController>().LaunchBall();
        }
        private void CreateBall()
        {
            // Quaternion.identity = It means no rotation
            Vector3 newBallPosition = _paddleController.transform.position + new Vector3(0, _ballProperties.BallSpawnPointY, 0);
            GameObject newBall = Instantiate(_ballPrefab,newBallPosition,Quaternion.identity,_paddleController.transform);
            BallList.Add(newBall);
        }
        // ----------------------- COUNTING AND REMOVING BLOCKS ALSO WIN CONDITION HERE ---------------
        public void CountBreakableBlock(GameObject breakableBlock)
        {
            _breakableBlockList.Add(breakableBlock);
        }
        public void RemoveBreakableBlock(GameObject breakableBlock)
        {
            _breakableBlockList.Remove(breakableBlock);
            // WIN CONDITION
            if(_breakableBlockList.Count <= 0 && !_gameEnded)
            {
                _gameEnded = true;
                _scoreManager.ShowWinPanel(_playerLife);
                
                _dataManager.IncreaseReachedLevel(_levelManager.CurrentLevel + 1);
                _dataManager.UpdateLevelRanks(_levelManager.CurrentLevel,_playerLife);
                
                _powerUpManager.StopAllCoroutines();
                Destroy(_paddleController.gameObject);
            }
        }
    }
}
