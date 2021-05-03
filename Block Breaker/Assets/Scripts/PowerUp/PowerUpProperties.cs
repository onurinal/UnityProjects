using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.ManagerSystem
{
    [CreateAssetMenu(menuName = "BlockBreaker/PowerUp/PowerUpProperties")]
    public class PowerUpProperties : ScriptableObject
    {
        // ----------------------- GENERAL DROP CHANCE---------------
        [Header("General Drop Chance")]
        [Range(0,100)]
        public int DropChance;

        // ----------------------- DROP CHANCES FOR POWER UPS---------------
        [Header("Drop Chances")]
        public int MultiBallChance;
        public int IncreasingPaddleSizeChance;
        public int DecreasingPaddleSizeChance;
        public int LaserChance;

        [Header("Properties")]
        public float DropXSpeed;
        public float DropYSpeed;
    }
}
