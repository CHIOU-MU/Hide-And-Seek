using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayPosPB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(Input.GetMouseButton(0))
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(3.2f, 6.1f, -1.6f);
            }
           
        }
    }
}
