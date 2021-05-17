using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlockBreaker.ManagerSystem{
    public class GameOverCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ball"))
            {
                GameManager.Instance.LostBall(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
