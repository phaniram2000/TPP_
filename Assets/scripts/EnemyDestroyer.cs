using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameManager.instance.UpdateScore();
        }
    }
}
