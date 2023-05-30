using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {

    }

    void Update()
    {
       if (cannotMove.canMove)
       {
            if(family04.donTransform == false)
            {
                //旋轉身體的視角
                float mouseX = Input.GetAxis("Mouse X") * 0.5f * mouseSensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * 0.5f * mouseSensitivity * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 讓頭部旋轉在90度

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                playerBody.Rotate(Vector3.up * mouseX);
            }


        }

    }

}
