using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public static target instance;
    public float health = 50f;
    public UnityEngine.AI.NavMeshAgent nav;
    public Transform player;
    public void take_damage(float damage_amount)
    {
        health -= damage_amount;
        if (health <= 0)
        {
          
            die();
        }
    }
    public enum enemy
    {
        run, idle, die
    }
    public enemy myenemy = enemy.idle;

    public void die()
    {
       myenemy=  enemy.die;
    }
    public void Update()
    {
        switch (myenemy)
        {
            case enemy.run:
                nav.SetDestination(player.transform.position);
                break;
            case enemy.idle:
                nav.SetDestination(this.transform.position);
                break;
            case enemy.die:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myenemy = enemy.run;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myenemy = enemy.idle;
        }
    }
}
