using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Block
{
    [CreateAssetMenu(menuName = "BlockBreaker/Block/BlockProperties")]
    public class BlockProperties : ScriptableObject
    {
        [Header("Block Hit Animation Properties")]
        public float ExtendSquareBlockSize;
        public float ShrinkSquareBlockSize;
        public float ScaleBlockSpeed;
        
    }
}
