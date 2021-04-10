using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletSpawner : MonoBehaviour
{
    private AudioSource audioo;
    public AudioClip shoot;
    private void Start()
    {
        audioo = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = ObjectPool.instance.getpooledobjects();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                audioo.PlayOneShot(shoot, 1.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);            
        }
    }
}
