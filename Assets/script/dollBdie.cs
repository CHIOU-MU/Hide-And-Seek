using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class dollBdie : MonoBehaviour
{
    public GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.Find("bedroomB");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public static bool basementB = false;
    private void OnMouseDown()
    {
        Flowchart.BroadcastFungusMessage("dollBdie");
        basementB = true;
        Destroy(room);
    }

}
