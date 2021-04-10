using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float velocityX = 0.0f;
    [SerializeField] private float velocityZ = 0.0f;
    [SerializeField] private float crouchX = 0.0f;
    [SerializeField] private float CrouchZ = 0.0f;
    [SerializeField] private float accleration = 2.0f;
    [SerializeField] private float Deccleration = 2.0f;
    [SerializeField] private float MaxRunVelocity = 2.0f;
    [SerializeField] private float MaxWalkVelocity = 0.5f;
    [SerializeField] private float mouse_dpi = 10;
    [SerializeField] private Transform player;
    [SerializeField] private bool crouch_animation;
    [SerializeField] private bool iscrouching = false;
    void Start()
    {
        anim.GetComponent<Animator>();
       
    }
   void change_velocity(bool forwardpress, bool Leftpressed, bool rightpressed, bool runpressed, float jump_Pressed, bool crouch_Pressed, float currentMaxVelocity, bool aim,bool aim_2)
    {
       
        if (forwardpress && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * accleration;
        }

        if (Leftpressed && velocityX > -currentMaxVelocity)
        {
            velocityX -= Time.deltaTime * accleration;
        }
        if (rightpressed && velocityX < currentMaxVelocity)
        {
            velocityX += Time.deltaTime * accleration;
           
        }
       if (crouch_Pressed)
        {
            if (!iscrouching)
            {
                anim.SetBool("Crouch", true);
                iscrouching = true;
            }
            else if(iscrouching)
            {
                anim.SetBool("Crouch", false);
                iscrouching = false;
            }

        }
       if(aim)
        {
            anim.SetBool("Aim", true);
        }
       if(aim_2)
        {
            anim.SetBool("Aim", false);
        }
      
        //else if(crouch_Pressed && iscrouching==true)
        //{

        //    anim.SetBool("Crouch", false);
        //}
        //if(iscrouching == true && crouch_Pressed)
        //{
        //    anim.SetFloat("Velocity z", velocityZ);
        //}
    }
    void lock_velocity(bool forwardpress, bool Leftpressed, bool rightpressed, bool runpressed, float jump_Pressed, bool crouch_Pressed)
    {

        if (!forwardpress && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * Deccleration;
        }
        if (!forwardpress && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }
        if (!Leftpressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * Deccleration;

        }
        if (!rightpressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * Deccleration;
        }
        if (!Leftpressed && !rightpressed && velocityX != 0.0f && (velocityX > -MaxWalkVelocity && velocityX < MaxWalkVelocity))
        {
            velocityX = 0.0f;
        }

    }

    private void Update()
    {
        bool forwardpress = Input.GetKey(KeyCode.W);
        bool Leftpressed = Input.GetKey(KeyCode.A);
        bool rightpressed = Input.GetKey(KeyCode.D);
        bool runpressed = Input.GetKey(KeyCode.LeftShift);
        float jump_Pressed = Input.GetAxis("Jump");
        bool crouch_Pressed = Input.GetKeyDown(KeyCode.C);
        bool aim_2= Input.GetKeyUp(KeyCode.Mouse1);
        bool aim = Input.GetKeyDown(KeyCode.Mouse1);
       
        float currentMaxVelocity = runpressed ? MaxRunVelocity : MaxWalkVelocity;
        change_velocity( forwardpress,  Leftpressed,  rightpressed,  runpressed, jump_Pressed,crouch_Pressed,currentMaxVelocity, aim,aim_2);
        lock_velocity(forwardpress, Leftpressed, rightpressed, runpressed, jump_Pressed, crouch_Pressed);
        animations_();
    }
 
   void animations_()
    {
        anim.SetFloat("Velocity z", velocityZ);
        anim.SetFloat("Velocity x", velocityX);       
      //  anim.SetFloat("Crouch z", velocityZ);
      

    }
  
}
