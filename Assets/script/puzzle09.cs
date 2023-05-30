using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class puzzle09 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Outline>().enabled = false;
        p09.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Flowchart p09;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Outline>().enabled = true;
            p09.enabled = true;
        }
    }

    public static bool p09can=false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonUp(0))
            {
                p09can = true;
                GetComponent<Outline>().enabled = false;
                p09.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Outline>().enabled = false;
            p09.enabled = false;
        }
    }

}
