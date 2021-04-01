using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Ball
{
    [CreateAssetMenu(menuName = "BlockBreaker/Ball/BallProperties")]
    public class BallProperties : ScriptableObject
    {
        [Header("Ball Movement")]
        public float BallXSpeed = 0f;
        public float BallYSpeed = 8f;
    }
}

