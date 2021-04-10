using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Camera maincam;
    public float damage = 20f;
    public float range = 100f;
    private AudioSource gunaudio;
    public AudioClip gunclip;
    void Start()
    {
        gunaudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shooting();
            gunaudio.PlayOneShot(gunclip, 1.0f);
        }
      
    }
    void shooting()
    {
        RaycastHit hitinfo;
        if(Physics.Raycast(maincam.transform.position ,maincam.transform.forward,out hitinfo,range))
        {
            Debug.Log(hitinfo.transform.name);
         target Target =   hitinfo.transform.GetComponent<target>();
            if(Target != null)
            {
                Target.take_damage(damage);
            }
        }
    }
}
