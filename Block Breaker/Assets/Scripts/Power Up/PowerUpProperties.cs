using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.ManagerSystem
{
    [CreateAssetMenu(menuName = "BlockBreaker/PowerUp/PowerUpProperties")]
    public class PowerUpProperties : ScriptableObject
    {
        // ----------------------- DROP CHANCES FOR POWER UPS---------------
        [Header("Drop Chances")]
        public int MultiBallChance;
        public int ExtendPaddleChance;
        public int ShrinkPaddleChance;
        public int LaserChance;

        [Header("Properties")]
        public float DropXSpeed;
        public float DropYSpeed;
        public float PowerUpEndTime;

        [Header("MultiBall Properties")]
        public float MaxBallCount;
        public float MultiBallMinForce;
        public float MultiBallMaxForce;

        [Header("Extend Shrink Properties")]
        public float ExtendShrinkSpeed;

        [Header("Extend Paddle Properties")]
        public float ExtendPaddleSizePerPower;
        public float MaxExtendSize;
        [Header("Shrink Paddle Properties")]
        public float MaxShrinkSize;
        [Header("Laser Shot Properties")]
        public int LaserDamage;
        public float LaserSpeedY;
        public float ReleasingPerLaserTime;
    }
}
