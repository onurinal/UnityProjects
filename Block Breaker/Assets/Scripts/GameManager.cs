using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;
using BlockBreaker.Ball;

namespace BlockBreaker.ManagerSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab; // for create new balls.
        [SerializeField] private int _life;

        private List<GameObject> _ballList = new List<GameObject>(); // storing balls
        private List<GameObject> _breakableBlockList = new List<GameObject>(); // storing breakable blocks

        public static GameManager Instance;  // singleton
        private PaddleController _paddleController; // for accessing the paddle
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
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && _ballList.Count > 0)
            {
                if (_ballList[0] != null && !_ballList[0].GetComponent<BallController>().BallLaunched)
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
            _paddleController.ResetPaddlePosition();
        }
        public void LostBall(GameObject ball)
        {
            _ballList.Remove(ball);
            Destroy(ball);
            if(_ballList.Count <= 0)
            {
                RemoveLife();
            }
        }
        // ----------------------- CREATE NEW BALL AND LAUNCH THE BALL ---------------
        private void LaunchBall()
        {
            _ballList[0].GetComponent<BallController>().LaunchBall();
        }
        private void CreateBall()
        {
            // Quartenion.identity = It means no rotation
            Vector3 newBallPosition = _paddleController.transform.position + new Vector3(0, 0.25f, 0);
            GameObject newBall = Instantiate(_ballPrefab,newBallPosition,Quaternion.identity,_paddleController.transform);

            _ballList.Add(newBall);
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
            //GameObject newBall;
            for (int i = _ballList.Count - 1; i >= 0; i--)
            {
                // CHECK HOW MANY BALLS IN SCENE. IF THERE ARE TOO MUCH BALL THEN DO NOT APPLY THE POWER UP EFFECT
                // OTHERWISE IT CAN CAUSE FPS DROP AND SOME BUGS
                if (_ballList.Count < 24)
                {
                    CreateNewBalls(i);
                    CreateNewBalls(i);
                }
            }
        }
        private void CreateNewBalls(int i)
        {
            GameObject newBall;
            // Getting ball position for making new balls
            Vector3 ballPosition = _ballList[i].transform.position;
            // Instantiate new ball
            newBall = Instantiate(_ballPrefab, ballPosition, Quaternion.identity);
            //  For example if you make AddForce 400f then you are making rigidbody.velocity -> 8
            newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-150f, 150f), Random.Range(350f, 400f)));
            // Adding new ball in ball list
            _ballList.Add(newBall);
            // FIXING THE ERROR. BALL LAUNCHED SHOULD BE TRUE TO NOT GET ERROR.
            newBall.GetComponent<BallController>().BallLaunched = true;
        }
    }
}
