using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Ball
{
    [CreateAssetMenu(menuName = "BlockBreaker/Ball/BallProperties")]
    public class BallProperties : ScriptableObject
    {
        [Header("Ball Movement")]
        // ------- Ball Start Speed -------
        public float BallXSpeed;       // for starting
        public float BallYSpeed;       // for starting
        // ------- Ball Base Speed -------
        public float BallBaseSpeed = 8f;
        [Header("Ball Properties")]
        public float BaseSizeX = 1f;
        public float BaseSizeY = 1f;
        public float BallSpawnPointY;
        public int BallDamage;

        [Space(20)]
        public float BallPushX = 200f;  // for paddle collision. If ball hits left side it will force left movement in PaddleController.cs
    }
}

