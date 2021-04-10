using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletMover : MonoBehaviour
{
    public float speed = 10f;
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Invoke("HideBullet", 1.0f);
    }
    void HideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}

