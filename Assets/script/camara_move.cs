using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_move : MonoBehaviour
{
    [SerializeField] Transform target;
   // [SerializeField] Transform target2;
    [SerializeField] private  float vertical_target;
   [Range(1,20)] [SerializeField] private float vertical_target_DPI;
    [SerializeField] Vector3 translationoffset;
    [SerializeField] Vector3 followOffSet;
    [SerializeField] public float maxviewing_angle;
    [SerializeField] public float minviewing_angle;
    [SerializeField] private Transform player_body;
   void Start()
    {
        
    }
    private void FixedUpdate()
    {
        float yangle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, yangle, 0);
        transform.position = target.transform.position - (rotation * followOffSet);
        vertical_target += Input.GetAxis("Mouse Y")*vertical_target_DPI;
      vertical_target = Mathf.Clamp(vertical_target, maxviewing_angle, minviewing_angle);
        transform.LookAt(target.transform.position + translationoffset);
       transform.RotateAround(target.transform.position, target.transform.right, vertical_target);
        float mouse_move = Input.GetAxis("Mouse X") * vertical_target_DPI*Time.deltaTime;
        player_body.Rotate(Vector3.up * mouse_move);

    }
}
