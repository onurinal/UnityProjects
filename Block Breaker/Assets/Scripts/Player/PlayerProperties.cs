using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.Player
{
    [CreateAssetMenu(menuName = "BlockBreaker/Player/PlayerProperties")]
    public class PlayerProperties : ScriptableObject
    {

        [Header("Player Movement")]
        public float MovementSpeed = 4f;
    }
}
