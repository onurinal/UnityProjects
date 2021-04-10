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
        public float BallXSpeed = 0f;       // for starting
        public float BallYSpeed = 7f;       // for starting
        // ------- Ball Base Speed -------  // make the ball constant speed.
        public float BallBaseSpeed = 8f;
        [Space(20)]
        public float BallPushX = 200f;  // for paddle collision. If ball hits left side it will force left movement in PaddleController.cs
    }
}

