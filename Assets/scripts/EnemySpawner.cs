using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randx;
    Vector2 wheretospawn;
    public float spawnrate = 2f;
    float nextspawn = 0.0f;

    private void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawnrate;
            randx = Random.Range(2.38f, -2.38f);
            wheretospawn = new Vector2(randx, transform.position.y);
            Instantiate(enemy, wheretospawn, Quaternion.identity);
        }
        if (GameManager.instance.scoreincre > 10)
        {
            spawnrate = 1.5f;
        }

        if (GameManager.instance.scoreincre > 25)
        {
            spawnrate = 1.0f;
        }
        if (GameManager.instance.scoreincre > 50)
        {
            spawnrate = 0.8f;
        }
        if (GameManager.instance.scoreincre > 75)
        {
            spawnrate = 0.4f;
        }
    }
}
