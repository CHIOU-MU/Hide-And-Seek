using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairPos : MonoBehaviour
{
    public GameObject chair;
    private Transform playerHand;
    public Transform girlRoom;

    public GameObject chairP;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = GameObject.Find("PlayerHand").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }

    private void OnMouseUp()
    {
        if(moveChair.inhand)
        {
            chair.transform.SetParent(girlRoom);
            animator.SetBool("chair", false);
            chair.transform.position = this.gameObject.transform.position;
            chair.transform.localRotation = this.gameObject.transform.rotation;
            
            GetComponent<Outline>().enabled = false;
            chairP.SetActive(false);
        }
    }

}
