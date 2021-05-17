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
        public int ExtendPaddle;
        public int ShrinkPaddle;
        public int LaserChance;

        [Header("Properties")]
        public float DropXSpeed;
        public float DropYSpeed;
        public float PowerUpEndTime;

        [Header("MultiBall Properties")]
        public float MaxBallCount;
        public float MaxSpeedX1;
        public float MaxSpeedX2;

        [Header("Extend Paddle Properties")]
        public float MaxExtend;
        public float ExtendPerPower;
        [Header("Shrink Paddle Properties")]
        public float MaxShrink;
        public float ShrinkPerPower;
        [Header("Laser Shot Properties")]
        public int LaserDamage;
        public float LaserSpeedY;
        public float ReleasingPerLaserTime;
    }
}
