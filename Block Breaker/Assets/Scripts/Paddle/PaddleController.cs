using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Ball;

namespace BlockBreaker.Paddle
{
    public class PaddleController : MonoBehaviour
    {
        [Header("Paddle Properties")]
        [SerializeField] private PaddleProperties _playerProperties = null;
        [SerializeField] private BallProperties _ballProperties = null;

        private SpriteRenderer _paddle;
        private float _minXAndroid = 0f, _maxXAndroid = 0f;
        private float _paddleX = 0f;  // paddle x size to fix screen boundaries

        public static PaddleController Instance;
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            SetUpMovementBoundaries();
        }
        private void Update()
        {
            TouchMovement();
        }
        // ----------------------- PADDLE MOVEMENT AND SET UP BOUNDARY ---------------
        private void TouchMovement()
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.y = transform.position.y;
            touchPos.x = Mathf.Clamp(touchPos.x, _minXAndroid, _maxXAndroid);  // paddle can not go out of screen
            transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * _playerProperties.MovementSpeed);
        }
        private void SetUpMovementBoundaries()
        {
            // getting only x size because we don't need y size. Paddle can not move horizontally.
            _paddle = GetComponent<SpriteRenderer>(); 
            _paddleX = _paddle.bounds.size.x / 2;  // Because paddle sprite pivot is bottom center

            Camera gameCamera = Camera.main;
            _minXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + _paddleX;  
            _maxXAndroid = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - _paddleX;
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
        public void ResetPaddlePosition()
        {
            transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, 0);
        }
    }
}
