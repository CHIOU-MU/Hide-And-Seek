using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class family04 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject familyP4;
    public GameObject BG;

    public Flowchart photo;
    public GameObject hightLight;

    static public bool donTransform;

    void Start()
    {
        donTransform = false;
        familyP4.SetActive(false);
        BG.SetActive(false);

        hightLight.SetActive(false);
        photo.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void close()
    {
        familyP4.SetActive(false);
        BG.SetActive(false);
        donTransform = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            photo.enabled = true;
            hightLight.SetActive(true);
            if (Input.GetMouseButtonUp(0))
            {
                photo.enabled = false;
            }
        }
     }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0) && photo.enabled)
            {
                donTransform = true;

            }
            if (Input.GetMouseButtonUp(0))
            {
                photo.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hightLight.SetActive(false);
        photo.enabled = false;
    }

}
