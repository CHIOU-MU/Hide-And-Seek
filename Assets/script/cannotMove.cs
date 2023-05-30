using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannotMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public bool canMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canMove = true;
        }
    }
}
