using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthbooster;
    float randx;
    Vector2 wheretospawn;
    public float spawnrate = 2f;
    float nextspawn = 0f;
    void Update()
    {
        if(Time.time > nextspawn && GameManager.instance.life<3)
        {
            nextspawn = (Time.time + spawnrate);
            randx = Random.Range(2.38f, -2.38f);
            wheretospawn = new Vector2(randx, transform.position.y);
            Instantiate(healthbooster, wheretospawn, Quaternion.identity);
        }
    }
}