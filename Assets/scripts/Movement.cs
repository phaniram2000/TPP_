using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    float hz;
    public float speed = 10f;
    float xrange = 2.183128f;
    float yrange = 4.0f;
    Rigidbody2D rb;
    private Animator anime;
    private void Start()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hz = Input.GetAxis("Horizontal");
        float vz = Input.GetAxis("Vertical");
        if (transform.position.x > xrange) 
        {
            transform.position=new Vector2(xrange, transform.position.y);
        }

        if (transform.position.x < -xrange) 
        {
            transform.position = new Vector2(-xrange, transform.position.y);
        }

        if (transform.position.y > yrange) 
        {
            transform.position = new Vector2(transform.position.x, 4f);
        }
        if (transform.position.y < -4.44) 
        {
            transform.position = new Vector2(transform.position.x, -4.44f);
        }
        transform.Translate(Vector2.right * hz * Time.deltaTime * speed);
        transform.Translate(Vector2.up * vz * Time.deltaTime * speed);
           //anime.SetFloat("Left",1.0f);
           //anime.SetFloat("Right", 1.0f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {             
            GameManager.instance.LiveScore();
            if(GameManager.instance.life<=0)
            {
                GameManager.instance.SoundManager();
                SceneManager.LoadScene(2);
                Destroy(gameObject,0.5f);
            }
        }
    }
}