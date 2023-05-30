using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPointManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject basementPos;
    public GameObject basementbg;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(dollBdie.basementB && dollGdie.suit && dollThing.bowtile)
        {
            basementbg.SetActive(true);
            GameObject.Find("player").transform.rotation = basementPos.transform.rotation;
            GameObject.Find("player").transform.position = basementPos.transform.position;
        }
    }
    private static Vector3 playerRecordPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerRecordPos = this.transform.position;
        }
    }

    public static Vector3 Get_playerRecordPos()
    {
        return playerRecordPos;
    }
}
