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
        [SerializeField] private PaddleProperties _paddleProperties = null;
        [SerializeField] private BallProperties _ballProperties = null;
        [SerializeField] private PowerUpProperties _powerUpProperties = null;

        // FOR SETUP MOVEMENT BOUNDRAIES
        private SpriteRenderer _paddleSprite;
        private float _minXAndroid = 0f, _maxXAndroid = 0f;
        private float _paddleXSize = 0f;  // paddle x size to fix screen boundaries
        private Camera _gameCamera;

        // SETUP POSITION TO RELEASE LASER SHOTS ON PADDLE
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private Transform _leftSpawnPoint, _rightSpawnPoint;
        public float _laserEndTime = 0f;

        private GameManager _gameManager;
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
            // FOR SETUP MOVEMENT BOUNDRAIES
            _paddleSprite = GetComponent<SpriteRenderer>();
             _gameCamera = Camera.main;
        }
        private void Update()
        {
            TouchMovement();
        }
        // ----------------------- PADDLE MOVEMENT AND SET UP BOUNDARY ---------------
        private void TouchMovement()
        {
            Vector2 touchPos = _gameCamera.ScreenToWorldPoint(Input.mousePosition);
            touchPos.y = transform.position.y;
            touchPos.x = Mathf.Clamp(touchPos.x, _minXAndroid, _maxXAndroid);  // paddle can not go out of screen
            transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * _paddleProperties.MovementSpeed);
        }
        private void SetUpMovementBoundaries()
        {
            // getting only x size because we don't need y size. Paddle can not move horizontally.
            _paddleXSize = _paddleSprite.bounds.size.x / 2;  // Because paddle sprite pivot is bottom center

            _minXAndroid = _gameCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _paddleXSize;  
            _maxXAndroid = _gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _paddleXSize;
        }
        // ----------------------- BALL CONTROLLING ---------------
        // If the ball hits left side on paddle we will add force for ball to move left. It is the same for right side too
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D ballRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 hitPoint = collision.contacts[0].point;  // get coordinates of the ball on paddle when hit
            float difference = transform.position.x - hitPoint.x;
            if (hitPoint.x < transform.position.x)
            {
                ballRigidBody.AddForce(new Vector2(-(Mathf.Abs(_ballProperties.BallPushX)), 0));
            }
            else
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
        public void ExtendPaddleSize()
        {
            // If the paddle has max extend size, then do not extend
            if (transform.localScale.x >= _powerUpProperties.MaxExtend) return;
            // If  the ball didn't launch then detach children and resize the paddle.
            if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
            {
                _gameManager.BallList[0].transform.parent = null;  // Detach ball children from paddle to prevent not growing both
                transform.localScale += new Vector3(_powerUpProperties.ExtendPerPower, 0f, 0f);
                _gameManager.BallList[0].transform.SetParent(transform);
            }
            else
            {
                transform.localScale += new Vector3(_powerUpProperties.ExtendPerPower, 0f, 0f);
            }
            SetUpMovementBoundaries(); // fix the screen boundraies when you take the extend - shrink power up
        }
        public void ShrinkPaddleSize()
        {
            // If the paddle has max shrink size, then do not shrink
            if (transform.localScale.x <= _powerUpProperties.MaxShrink) return;
            // If the ball didn't launch then detach children and resize the paddle.
            if (!_gameManager.BallList[0].GetComponent<BallController>().BallLaunched)
            {
                _gameManager.BallList[0].transform.parent = null;  // Detach ball children from paddle to prevent not growing both
                transform.localScale -= new Vector3(_powerUpProperties.ShrinkPerPower, 0f, 0f);
                _gameManager.BallList[0].transform.SetParent(transform);
            }
            else
            {
                transform.localScale -= new Vector3(_powerUpProperties.ShrinkPerPower, 0f, 0f);
            }
            SetUpMovementBoundaries(); // fix the screen boundraies when you take the extend - shrink power up
        }
        //----------------------- LASER SHOT POWER UP ---------------
        private IEnumerator LaserShooting()
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
        public void StartLaserShot()
        {
            _laserEndTime = _powerUpProperties.PowerUpEndTime; // to check the power up time is over or not
            StartCoroutine(LaserShooting());
        }
    }
}
