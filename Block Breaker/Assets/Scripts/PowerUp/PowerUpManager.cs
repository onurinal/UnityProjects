using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.ManagerSystem
{
    public class PowerUpManager : MonoBehaviour
    {
        [SerializeField] private PowerUpProperties _powerUpProperties = null;
        [SerializeField] private List<GameObject> _powerUpList = new List<GameObject>();

        public static PowerUpManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
          
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
                else if(powerUpIndex <= _powerUpProperties.IncreasingPaddleSizeChance)
                {
                    Instantiate(_powerUpList[1], position, Quaternion.identity);
                }
                else if(powerUpIndex <= _powerUpProperties.DecreasingPaddleSizeChance)
                {
                    Instantiate(_powerUpList[2], position, Quaternion.identity);
                }
                else if(powerUpIndex <= _powerUpProperties.LaserChance)
                {
                    Instantiate(_powerUpList[3], position, Quaternion.identity);
                }
            }
        }
    }
}
