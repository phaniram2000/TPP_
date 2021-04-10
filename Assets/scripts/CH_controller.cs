using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH_controller : MonoBehaviour
{
     private float x;
    private float strafe_input;
  [SerializeField] [ Range (0,20f)]  private float speed;
    [SerializeField] private  CharacterController ch;
    [SerializeField] private   float  gravaty = -20f;
    [SerializeField] private  float hight = 2f;
    [SerializeField] private  Transform groundcheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private bool isgrounded;
    [SerializeField] private float mouse_DPI;
    Vector3 velocity;
    [SerializeField] private float run;
    [SerializeField] private float runspeed = 3;
    public Transform main_cam;
    void Start()
    {
        ch = GetComponent<CharacterController>();   
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bool run = Input.GetKey(KeyCode.LeftShift) ;
        float currentrun = run ? runspeed : speed;
        float mousex = Input.GetAxis("Mouse X");
        isgrounded = Physics.CheckSphere(groundcheck.position, hight, groundlayer);
        if(isgrounded && velocity.y<0f)
        {
            velocity.y = -2f;
        }
       //Vector3 mouse_move = Vector3.RotateTowards
        x = Input.GetAxis("Vertical") ;
        strafe_input = Input.GetAxis("Horizontal");
        
        Vector3 move = transform.right * strafe_input + transform.forward*x;
        if (move.magnitude >= 0.1f)
        {


            //float target_angle = move.z  + main_cam.eulerAngles.y;
            //transform.rotation = Quaternion.Euler(0f, target_angle, 0f);
            //Vector3 move_dir = Quaternion.Euler(0, target_angle, 0) * Vector3.forward;
            //ch.Move(move_dir *  currentrun * Time.deltaTime);
            ch.Move(move*currentrun*Time.deltaTime);
        }
    }   
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(hight * -2f * gravaty);           
        }
        velocity.y += gravaty * Time.deltaTime;
        ch.Move(velocity * Time.deltaTime);
       // transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * speed);
      
    }
}
 