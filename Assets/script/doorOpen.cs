using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Fungus;

public class doorOpen : MonoBehaviour
{
    public GameObject hightLight;
    public Flowchart openDoor;

    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        hightLight.SetActive(false);
        openDoor.enabled = false;

        move = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("player").transform.rotation = destination.rotation;  // 使方向朝向目的地方向
                GameObject.Find("player").transform.position = destination.position;  // 瞬移到目的地位置                                                                                               

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            move = true;
            Debug.Log("move = true");

            hightLight.SetActive(true);
            openDoor.enabled = true;
        }
    }

    bool move;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                openDoor.enabled = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                move = false;
                openDoor.enabled = false;
                Debug.Log("move = false");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        move = false;
        Debug.Log("move = false");

        hightLight.SetActive(false);
        openDoor.enabled = false;
    }

}
