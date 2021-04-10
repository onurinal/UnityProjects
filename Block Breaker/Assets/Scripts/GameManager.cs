using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BlockBreaker.Paddle;
using BlockBreaker.Ball;

namespace BlockBreaker.ManagerSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab; // for create new balls.
        [SerializeField] private int _life;

        // for updating score
        [SerializeField] private int _currentScore = 0;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private List<GameObject> _ballList = new List<GameObject>(); // storing balls
        private List<GameObject> _breakableBlockList = new List<GameObject>(); // storing breakable blocks
        private bool _ballLaunched;
        
        public static GameManager Instance;
        
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            ResetGame();
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
            CreateNewBall();
        }
        private void RemoveLife()
        {
            _life--;
            //LOSE CONDITION
            if(_life <= 0)
            {
                Debug.Log("GAME OVER!");
                return;
            }
            CreateNewBall();
            PaddleController.Instance.ResetPaddlePosition();
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
            //_ballLaunched = true;    If will be performance problem, then you can execute this code.
        }
        private void CreateNewBall()
        {
            GameObject newBall = Instantiate(_ballPrefab);
            newBall.transform.position = PaddleController.Instance.transform.position + new Vector3(0, 0.25f, 0);
            newBall.transform.SetParent(PaddleController.Instance.transform);

            _ballList.Add(newBall);
            //if (!_ballList[0].GetComponent<BallController>().BallLaunched)
            //{
            //    _ballLaunched = false;            If will be performance problem, then you can execute this code.
            //}                                     Do not run getCompenent in update ...
        }
        // ----------------------- POINTS EACH BLOCK AND MANAGE BLOCKS ---------------
        public void AddToScore(int perPointBlockDestroyed)
        {
            _currentScore = _currentScore + perPointBlockDestroyed;
            _scoreText.text = _currentScore.ToString();
        }
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

    }
}
