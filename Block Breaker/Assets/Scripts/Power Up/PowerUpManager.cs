using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlockBreaker.Paddle;

namespace BlockBreaker.ManagerSystem
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties;
        [SerializeField] private List<GameObject> _powerUpList = new List<GameObject>();

        // EXTEND AND SHRINK POWER UP PROPERTIES
        public bool IsExtendAlive;
        public bool IsShrinkAlive;

        private PaddleController _paddleController;

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
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
                IsExtendAlive = true;
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
                _paddleController.ExtendOrShrinkTimer = _powerUpProperties.PowerUpEndTime;
                IsShrinkAlive = true;
            }
        }
    }
}
