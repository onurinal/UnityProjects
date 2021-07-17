using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Ball;
using BlockBreaker.ManagerSystem;

namespace BlockBreaker.Paddle
{
    public class PaddleController : MonoBehaviour
    {
        [Header("Paddle Properties")]
        [SerializeField] private PaddleProperties _paddleProperties;
        [SerializeField] private BallProperties _ballProperties;
        [SerializeField] private PowerUpProperties _powerUpProperties;

        // FOR SETUP MOVEMENT BOUNDARIES
        private SpriteRenderer _paddleSprite;
        private float _minXAndroid, _maxXAndroid;
        private float _paddleXSize;  // paddle x size to fix screen boundaries
        private Camera _gameCamera;

        // // FOR EXTEND OR SHRINK POWER UP PROPERTIES
        private float _currentPaddleSizeX;
        private float _goalPaddleSizeX;
        public double ExtendOrShrinkTimer;

        // SETUP POSITION TO RELEASE LASER SHOTS ON PADDLE
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private Transform _leftSpawnPoint, _rightSpawnPoint;
        public float _laserEndTime;

        private GameManager _gameManager;
        private PowerUpManager _powerUpManager;
        public static PaddleController Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AccessObjects();
            SetUpMovementBoundaries();
        }
        private void AccessObjects()
        {
            _gameManager = GameManager.Instance;
            _powerUpManager = PowerUpManager.Instance;
            // FOR SETUP MOVEMENT BOUNDARIES
            _paddleSprite = GetComponent<SpriteRenderer>();
             _gameCamera = Camera.main;
        }
        private void Update()
        {
            TouchMovement();
            
            if (_powerUpManager.IsExtendAlive)
            {
                ExtendPaddle();
            }
            else if (_powerUpManager.IsShrinkAlive)
            {
                ShrinkPaddle();
            }
        }
        // ----------------------- PADDLE MOVEMENT AND SET UP BOUNDARY ---------------
        private void TouchMovement()
        {
            Vector2 touchPos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
            touchPos.y = transform.position.y;
            touchPos.x = Mathf.Clamp(touchPos.x, _minXAndroid, _maxXAndroid);  // paddle can not go out of screen
            transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * _paddleProperties.MovementSpeed);
        }
        public void SetUpMovementBoundaries()
        {
            // getting only x size because we don't need y size. Paddle can not move horizontally.
            _paddleXSize = _paddleSprite.bounds.size.x / 2;  // because paddle sprite pivot is bottom center

            _minXAndroid = _gameCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _paddleXSize;  
            _maxXAndroid = _gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _paddleXSize;
        }
        // ----------------------- BALL CONTROLLING ---------------
        // If the ball hits left side on paddle we will add force for ball to move left. It is the same for right side too
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D ballRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 hitPoint = collision.contacts[0].point;  // get coordinates of the ball on paddle when hit
            if (hitPoint.x < transform.position.x) // add force to bounce left
            {
                ballRigidBody.AddForce(new Vector2(-(Mathf.Abs(_ballProperties.BallPushX)), 0));
            }
            else // otherwise right
            {
                ballRigidBody.AddForce(new Vector2(Mathf.Abs(_ballProperties.BallPushX), 0));
            }
        }
        // ----------------------- RESET PADDLE SIZE AND POSITION WHEN YOU LOSE YOUR LIFE---------------
        public void ResetPaddle()
        {
            transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, 0);
            transform.localScale = new Vector3(_paddleProperties.PaddleBaseSizeX, transform.localScale.y, transform.localScale.z);
        }
        // ----------------------- EXTEND AND SHRINK POWER UPS ---------------
        // These Extends, Shrinks and BaseSizePaddle methods work in update function
        private void ExtendPaddle()
        {
            ExtendOrShrinkTimer -= Time.deltaTime;
            if (ExtendOrShrinkTimer > 0)
            {
                ExtendPaddleSize();
            }
            else if (ExtendOrShrinkTimer <= 0)
            {
                BaseSizePaddle();
            }
        }
        private void ExtendPaddleSize()
        {
            _currentPaddleSizeX = transform.localScale.x; // get current size of the paddle
            _goalPaddleSizeX = _powerUpProperties.MaxExtendSize; // target size to reach
            if (_goalPaddleSizeX > _currentPaddleSizeX)
            {
                if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    _gameManager.BallList[0].transform.SetParent(null); // Detach ball children from paddle to prevent not growing both
                    _currentPaddleSizeX += Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                    _gameManager.BallList[0].transform.SetParent(transform); // set the parent of the ball
                }
                else
                {
                    _currentPaddleSizeX += Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                }
                SetUpMovementBoundaries(); // after apply extend or shrink effects check the movement boundaries
            }
        }
        private void ShrinkPaddle()
        {
            ExtendOrShrinkTimer -= Time.deltaTime;
            if (ExtendOrShrinkTimer > 0)
            {
                ShrinkPaddleSize();
            }
            else if (ExtendOrShrinkTimer <= 0)
            {
                BaseSizePaddle();
            }
        }
        private void ShrinkPaddleSize()
        {
            _currentPaddleSizeX = transform.localScale.x; // get current size of the paddle
            _goalPaddleSizeX =  _powerUpProperties.MaxShrinkSize; // target size to reach
            if (_goalPaddleSizeX < _currentPaddleSizeX)
            {
                if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    _gameManager.BallList[0].transform.SetParent(null); // Detach ball children from paddle to prevent not growing both
                    _currentPaddleSizeX -= Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                    _gameManager.BallList[0].transform.SetParent(transform); // set the parent of the ball
                }
                else
                {
                    _currentPaddleSizeX -= Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                }
                SetUpMovementBoundaries(); // after apply extend or shrink effects check the movement boundaries
            }
        }
        private void BaseSizePaddle()
        {
            _currentPaddleSizeX = transform.localScale.x; // get current size of the paddle
            _goalPaddleSizeX = _paddleProperties.PaddleBaseSizeX; // target size to reach
            if (_goalPaddleSizeX > _currentPaddleSizeX && _powerUpManager.IsShrinkAlive) // if shrink power up alive then extend the current size
            {
                if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    _gameManager.BallList[0].transform.SetParent(null); // Detach ball children from paddle to prevent not growing both
                    _currentPaddleSizeX += Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                    _gameManager.BallList[0].transform.SetParent(transform); // set the parent of the ball
                }
                else
                {
                    _currentPaddleSizeX += Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                }
            }
            else if (_goalPaddleSizeX < _currentPaddleSizeX && _powerUpManager.IsExtendAlive) // if extend power up alive then shrink the current size
            {
                if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    _gameManager.BallList[0].transform.SetParent(null); // Detach ball children from paddle to prevent not growing both
                    _currentPaddleSizeX -= Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                    _gameManager.BallList[0].transform.SetParent(transform); // set the parent of the ball
                }
                else
                {
                    _currentPaddleSizeX -= Time.deltaTime * _powerUpProperties.ExtendShrinkSpeed;
                    transform.localScale = new Vector3(_currentPaddleSizeX, transform.localScale.y, transform.localScale.z);
                }
            }
            else // If the basic size is reached then turn off extend or shrink power up
            {
                _powerUpManager.IsExtendAlive = false;
                _powerUpManager.IsShrinkAlive = false;
            }
            SetUpMovementBoundaries(); // after apply extend or shrink effects check the movement boundaries
        }
        //----------------------- LASER SHOT POWER UP ---------------
        public IEnumerator LaserShooting()
        {
            while (_laserEndTime > 0)
            {
                // Instantiate laser shots
                Instantiate(_laserPrefab, _leftSpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(_powerUpProperties.ReleasingPerLaserTime);
                Instantiate(_laserPrefab, _rightSpawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(_powerUpProperties.ReleasingPerLaserTime);
                // Decrease the time after releasing two laser
                _laserEndTime -= _powerUpProperties.ReleasingPerLaserTime * 2;
            }
        }
    }
}
