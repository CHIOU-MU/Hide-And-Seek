using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class moveChair : MonoBehaviour
{
    private Transform playerHand;
    public Transform girlRoom;
    public GameObject hightLight;
    public static bool isTake;
    public static bool inhand;
    public Animator animator;
    public GameObject chairPos;

    public Flowchart stoyr2;

    // Start is called before the first frame update
    void Start()
    {
        // 獲取玩家手上的物件
        playerHand = GameObject.Find("PlayerHand").transform;
        hightLight.SetActive(false);
        chairPos.SetActive(false);
        isTake = false;
        inhand = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent==playerHand)
        {
            hightLight.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("chair = enter");

            hightLight.SetActive(true);
            isTake = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("chair = stay");

            if (Input.GetMouseButtonUp(0) && isTake == false)
            {
                hightLight.SetActive(false);

                if(transform.parent == girlRoom)
                {  
                    transform.SetParent(playerHand); // 設置物件的父物件為玩家手上的物件
                    transform.localPosition = Vector3.zero; // 將物件的本地位置設置為(0,0,0)
                    transform.localRotation= Quaternion.Euler(-196f, 5.4f, -210f);
                    animator.SetBool("chair", true);
                    stoyr2.enabled = false;
                    chairPos.SetActive(true);
                    isTake = true;
                    inhand = true;
                }        
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("chair = false");

        hightLight.SetActive(false);
    }

}
