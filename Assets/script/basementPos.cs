using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basementPos : MonoBehaviour
{

    public GameObject tree;

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
            dollBdie.basementB = false;
            Destroy(tree);
        }
    }

}
