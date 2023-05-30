using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;//移動速度
    public float gravity = -9.81f;//重力

    public Transform groundCheck;
    public float grounDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {

    }

   void startMove()
    {
        if(cannotMove.canMove==false)
        {
            this.gameObject.transform.Translate(new Vector3(0, 0, 1f)*Time.deltaTime);
        }
        
    }

    void Update()
    {
       if(cannotMove.canMove)
        {
            if(family04.donTransform==false)
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                }

                float x = Input.GetAxis("Horizontal");//input水平
                float z = Input.GetAxis("Vertical");//input垂直

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
            

       }
       else
        {
            Invoke("startMove", 3.5f);
        }
    }
}
