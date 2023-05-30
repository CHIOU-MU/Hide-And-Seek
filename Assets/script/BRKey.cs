using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRKey : MonoBehaviour
{

    public GameObject cam;
    public GameObject highlight;
    public GameObject playerLight;


    // Start is called before the first frame update
    void Start()
    {
        cam.SetActive(false);
        highlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        cam.SetActive(false);
        highlight.SetActive(true);
        playerLight.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
          if(Input.GetMouseButtonDown(0))
            {
                cam.SetActive(true);
                highlight.SetActive(false);
                playerLight.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cam.SetActive(false);
        highlight.SetActive(false);
        playerLight.SetActive(true);
    }
}
