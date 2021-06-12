using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;
using BlockBreaker.Ball;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

namespace BlockBreaker.ManagerSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties; // access scriptable object
        [SerializeField] private BallProperties _ballProperties; // access scriptable object
        
        // NEW BALLS MANAGEMENT
        [SerializeField] private GameObject _ballPrefab; // for create new balls
        private bool _newBallNegativeForce = true; // for releasing the balls opposite direction

        // LIFE UI MANAGEMENT
        [SerializeField] private TextMeshProUGUI _playerLifeText;
        [SerializeField] private int _playerLife;
        
        private bool _gameEnded;

        public List<GameObject> BallList = new List<GameObject>(); // storing balls
        private readonly List<GameObject> _breakableBlockList = new List<GameObject>(); // storing breakable blocks

        private PaddleController _paddleController; // accessing the paddle controller
        private PowerUpManager _powerUpManager; // accessing the power up manager
        private ScoreManager _scoreManager; // accessing the power up manager

        public static GameManager Instance;  // singleton
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AccessingObjects();
            ResetGame();
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
        private void AccessingObjects()
        {
            _paddleController = PaddleController.Instance;
            _powerUpManager = PowerUpManager.Instance;
            _scoreManager = ScoreManager.Instance;
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
                // _powerUpManager.StopAllCoroutines(); Do not need for now because there is no coroutine in PowerUpManager. Activate this when you have
                Destroy(_paddleController.gameObject); // Destroy the paddle when game is over
                return;
            }
            _powerUpManager.IsExtendAlive = false; // turn off extend power up effects
            _powerUpManager.IsShrinkAlive = false; // turn off shrink power up effects
            _paddleController.ResetPaddle(); // reset size and position
            _paddleController.SetUpMovementBoundaries(); // checking movement boundaries
            CreateBall();
            // DISABLE ALL COROUTINES ( POWER UPS ) WHEN LOSE LIFE
            // _powerUpManager.StopAllCoroutines(); Do not need for now because there is no coroutine in PowerUpManager. Activate this when you have
            _paddleController.StopAllCoroutines();
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
        // ----------------------- COUNTING AND REMOVING BLOCKS ---------------
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
                // _powerUpManager.StopAllCoroutines(); Do not need for now because there is no coroutine in PowerUpManager. Activate this when you have
                Destroy(_paddleController.gameObject);
            }
        }
        // ----------------------- POWER UPS ---------------
        public void MultiBall()
        {
            for (int i = BallList.Count - 1; i >= 0; i--)
            {
                // CHECK HOW MANY BALLS IN SCENE. IF THERE ARE TOO MUCH BALL THEN DO NOT APPLY THE POWER UP EFFECT
                // OTHERWISE IT CAN CAUSE FPS DROP AND SOME BUGS
                if (BallList.Count < _powerUpProperties.MaxBallCount)
                {
                    // Getting ball position for making new balls
                    Vector3 ballPosition = BallList[i].transform.position;
                    CreateNewBall(ballPosition);
                    CreateNewBall(ballPosition);
                    
                }
            }
        }
        private void CreateNewBall(Vector3 ballPosition)
        {
            _newBallNegativeForce = !_newBallNegativeForce;
            // Instantiate new ball
            var newBall = Instantiate(_ballPrefab, ballPosition, Quaternion.identity);
            // access the rigidbody of new ball to change velocity
            Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
            //release the balls different directions
            if (!_newBallNegativeForce)
            {
                rigidbody2D.velocity = new Vector2(Random.Range(_powerUpProperties.MultiBallMinForce, _powerUpProperties.MultiBallMaxForce), _ballProperties.BallYSpeed);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(Random.Range(- _powerUpProperties.MultiBallMinForce, - _powerUpProperties.MultiBallMaxForce), _ballProperties.BallYSpeed);
            }
            // make constant speed
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * _ballProperties.BallBaseSpeed;
            // Adding new ball in ball list
            BallList.Add(newBall);
            // FIXING THE ERROR. BALL LAUNCHED SHOULD BE TRUE TO NOT GET ERROR.
            newBall.GetComponent<BallController>().BallLaunched = true;
        }
    }
}
