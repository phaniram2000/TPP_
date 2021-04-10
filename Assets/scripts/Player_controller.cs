using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
   
    public Transform player;
    private Vector3 crouchPosition;
    private Vector3 original_height;
    public float crouchHeight = 0.75f;
    public bool crouch;
    public float originalheight;
    

    public CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;
    private void Awake()
    {
        crouchPosition = transform.localScale;
        crouchPosition.y = crouchHeight;
        original_height.y = transform.localScale.y;

}
    void Start()
    {
        characterController = GetComponent<CharacterController>();
     

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {       
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);       
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
       
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
       
        if(Input.GetKey(KeyCode.C))
        {           
            characterController.height = characterController.height / 2;
           crouchPosition = transform.localScale = new Vector3(transform.localScale.x, crouchPosition.y, transform.localScale.z);  
           
        }
        characterController.Move(moveDirection * Time.deltaTime);
              
    }
}
