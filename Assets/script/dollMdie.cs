using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollMdie : MonoBehaviour
{
    public GameObject room;
    public GameObject house;
    public GameObject hatM;

    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.Find("HouseInterDesign");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Instantiate(house);
        Destroy(room);
        Destroy(hatM);
    }

}
