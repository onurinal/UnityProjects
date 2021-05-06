using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;
using BlockBreaker.Ball;

namespace BlockBreaker.ManagerSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties = null; // access scriptable object
        [SerializeField] private BallProperties _ballProperties = null; // access scriptable object
        [SerializeField] private GameObject _ballPrefab; // for create new balls.
        [SerializeField] private int _life;

        public List<GameObject> BallList = new List<GameObject>(); // storing balls
        private List<GameObject> _breakableBlockList = new List<GameObject>(); // storing breakable blocks

        private PaddleController _paddleController; // accessing the paddle
        private PowerUpManager _powerUpManager; // accessing the power up manager

        public static GameManager Instance;  // singleton
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            AccesingObjects();
            ResetGame();
        }
        private void AccesingObjects()
        {
            _paddleController = PaddleController.Instance;
            _powerUpManager = PowerUpManager.Instance;
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && BallList.Count > 0)
            {
                if (BallList[0] != null && !BallList[0].GetComponent<BallController>().BallLaunched)
                {
                    LaunchBall();
                }
            }
        }
        // ----------------------- LIFE MANAGEMENT ---------------
        private void ResetGame()
        {
            _life = 3;
            CreateBall();
        }
        private void RemoveLife()
        {
            _life--;
            //LOSE CONDITION
            if(_life <= 0)
            {
                Debug.Log("GAME OVER!");  // Update game over screen
                return;
            }
            CreateBall();
            _paddleController.ResetPaddle(); // reset size and position
            _powerUpManager.StopAllCoroutines(); // disable all power ups when lose life
           
        }
        public void LostBall(GameObject ball)
        {
            BallList.Remove(ball);
            Destroy(ball);
            if(BallList.Count <= 0)
            {
                RemoveLife();
            }
        }
        // ----------------------- CREATE NEW BALL AND LAUNCH THE BALL ---------------
        private void LaunchBall()
        {
            BallList[0].GetComponent<BallController>().LaunchBall();
        }
        private void CreateBall()
        {
            // Quartenion.identity = It means no rotation
            Vector3 newBallPosition = _paddleController.transform.position + new Vector3(0, 0.25f, 0);
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
            if(_breakableBlockList.Count <= 0)
            {
                Debug.Log("You Won"); // Update win screen...
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
            GameObject newBall;
            // Instantiate new ball
            newBall = Instantiate(_ballPrefab, ballPosition, Quaternion.identity);
            // access the rigidbody of new ball to change velocity
            Rigidbody2D rigidbody2D = newBall.GetComponent<Rigidbody2D>();
            //release the balls different directions
            rigidbody2D.velocity = new Vector2(Random.Range(_powerUpProperties.MaxSpeedX1, _powerUpProperties.MaxSpeedX2), _ballProperties.BallYSpeed);
            // make constant speed
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * _ballProperties.BallBaseSpeed;
            // Adding new ball in ball list
            BallList.Add(newBall);
            // FIXING THE ERROR. BALL LAUNCHED SHOULD BE TRUE TO NOT GET ERROR.
            newBall.GetComponent<BallController>().BallLaunched = true;
        }
    }
}
