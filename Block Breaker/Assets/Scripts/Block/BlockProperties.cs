using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Block
{
    [CreateAssetMenu(menuName = "BlockBreaker/Block/BlockProperties")]
    public class BlockProperties : ScriptableObject
    {
        [Header("Block Hit Animation Properties")]
        public float ExtendBlockSize;
        public float ShrinkBlockSize;
        public float ScaleBlockSpeed;

        [Header("Death Block Properties")]
        public float DeathBlockXSpeed;
        public float DeathBlockYSpeed;

    }
}
