using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_move : MonoBehaviour
{
    private float rotationX;
    public float lookXLimit = 45.0f;
    public float lookSpeed = 2.0f;
    public Camera playerCamera;
    public Transform Player;
    private void Update()
    {

        float x = Input.GetAxis("Mouse X") * lookSpeed;
        Player.Rotate(Vector3.up * x);
    }
      
}
