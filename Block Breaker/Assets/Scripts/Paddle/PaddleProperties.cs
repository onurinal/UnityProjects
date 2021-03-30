using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Paddle
{
    [CreateAssetMenu(menuName = "BlockBreaker/Paddle/PaddleProperties")]
    public class PaddleProperties : ScriptableObject
    {

        [Header("Player Movement")]
        public float MovementSpeed = 4f;
    }
}
