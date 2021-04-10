using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    public float mouse_sens = 100f;
    public Transform player_control;
    float xrotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouse_sens * Time.deltaTime;      
        player_control.Rotate(Vector3.up * mousex);
    }
}
