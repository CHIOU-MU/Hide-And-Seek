using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP03 : MonoBehaviour
{

    public static bool dollG;
    public GameObject newspaperG;
    // Start is called before the first frame update
    void Start()
    {
        dollG = false;
        newspaperG.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0) )
            {
                dollG = true;
                newspaperG.SetActive(true);
            }
        }
    }

}
