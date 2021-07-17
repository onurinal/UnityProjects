using System.Collections;
using System.Collections.Generic;
using BlockBreaker.Ball;
using UnityEngine;
using BlockBreaker.Paddle;

namespace BlockBreaker.ManagerSystem
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties; // access scriptable object
        [SerializeField] private BallProperties _ballProperties; // access scriptable object
        [SerializeField] private List<GameObject> _powerUpList = new List<GameObject>();

        // EXTEND AND SHRINK POWER UP PROPERTIES
        public bool IsExtendAlive;
        public bool IsShrinkAlive;
        
        // MULTI BALL POWER UP PROPERTIES
        private bool _multiBallNegativeForce = true; // for releasing the balls opposite direction
        
        // LASER SHOT POWER UP PROPERTIES
        public Coroutine LaserShotCoroutine;

        private PaddleController _paddleController;
        private GameManager _gameManager;

        public static PowerUpManager Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AccessObjects();
        }
        private void AccessObjects()
        {
            _paddleController = PaddleController.Instance;
            _gameManager = GameManager.Instance;
        }
        public void DropPowerUp(Vector3 position)
        {
            int percent = Random.Range(0, 101);
            if (percent <= _powerUpProperties.DropChance)
            {
                // Instantiate(_powerUpList[0]) --- > MultiBall
                // Instantiate(_powerUpList[1]) --- > IncreasingPaddleSize
                // Instantiate(_powerUpList[2]) --- > DecreasingPaddleSize
                // Instantiate(_powerUpList[3]) --- > Laser
                int powerUpIndex = Random.Range(1, 101);

                if(powerUpIndex <= _powerUpProperties.MultiBallChance)
                {
                    Instantiate(_powerUpList[0], position, Quaternion.identity);
                }  
                else if(powerUpIndex <= _powerUpProperties.ExtendPaddleChance)
                {
                    Instantiate(_powerUpList[1], position, Quaternion.identity);
                }
                else if(powerUpIndex <= _powerUpProperties.ShrinkPaddleChance)
                {
                    Instantiate(_powerUpList[2], position, Quaternion.identity);
                }
                else if(powerUpIndex <= _powerUpProperties.LaserChance)
                {
                    Instantiate(_powerUpList[3], position, Quaternion.identity);
                }
            }
        }
        // ----------------------- EXTEND AND SHRINK POWER UPS ---------------
        public void StartExtendPaddle()
        {
            if (IsShrinkAlive && !IsExtendAlive) // if we got shrink and extend power up nearly same time then we need to check the last power up that we got
            {
                IsShrinkAlive = false;
                IsExtendAlive = true;
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
            else if (IsExtendAlive) // if we have extend power up effects and we are getting new one then reset the timer.
            {
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
            else // basic extend condition
            {
                IsExtendAlive = true;
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
        }
        public void StartShrinkPaddle()
        {
            // if we got shrink and extend power up nearly same time then we need to check the last power up that we got
            if (IsExtendAlive && !IsShrinkAlive)
            {
                IsExtendAlive = false;
                IsShrinkAlive = true;
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
            else if (IsShrinkAlive) // if we have shrink power up effects and we are getting new one then reset the timer.
            {
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
            else // basic shrink condition
            {
                IsShrinkAlive = true;
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
            }
        }
        // ----------------------- MULTI BALL POWER UP ---------------
        public void MultiBall()
        {
            for (int i = _gameManager.BallList.Count - 1; i >= 0; i--)
            {
                // CHECK HOW MANY BALLS IN SCENE. IF THERE ARE TOO MUCH BALL THEN DO NOT APPLY THE POWER UP EFFECT
                // OTHERWISE IT CAN CAUSE FPS DROP AND SOME BUGS
                if (_gameManager.BallList.Count < _powerUpProperties.MaxBallCount)
                {
                    // Getting ball position for making new balls
                    Vector3 ballPosition = _gameManager.BallList[i].transform.position;
                    CreateNewBall(ballPosition);
                    CreateNewBall(ballPosition);
                }
            }
        }
        private void CreateNewBall(Vector3 ballPosition)
        {
            _multiBallNegativeForce = !_multiBallNegativeForce;
            // Instantiate new ball
            var newBall = Instantiate(_gameManager._ballPrefab, ballPosition, Quaternion.identity);
            // access the rigidbody of new ball to change velocity
            Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
            //release the balls different directions
            if (!_multiBallNegativeForce)
            {
                rigidbody2D.velocity = new Vector2(Random.Range(_powerUpProperties.MultiBallMinForce, _powerUpProperties.MultiBallMaxForce), _ballProperties.BallYSpeed);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(Random.Range(-_powerUpProperties.MultiBallMinForce, -_powerUpProperties.MultiBallMaxForce), _ballProperties.BallYSpeed);
            }
            // make constant speed
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * _ballProperties.BallBaseSpeed;
            // Adding new ball in ball list
            _gameManager.BallList.Add(newBall);
            // FIXING THE ERROR. BALL LAUNCHED SHOULD BE TRUE TO NOT GET ERROR.
            newBall.GetComponent<BallController>().BallLaunched = true;
        }
        // ----------------------- LASER SHOT POWER UP ---------------
        public void StartLaserShot()
        {
            _paddleController._laserEndTime = _powerUpProperties.PowerUpEndTime; // to check the power up time is over or not
            LaserShotCoroutine = StartCoroutine(_paddleController.LaserShooting());
        }
    }
}
