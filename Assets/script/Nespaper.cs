using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class Nespaper : MonoBehaviour
{
    public GameObject newspaperBG;
    public GameObject BG;

    public Flowchart newspaper;
    public GameObject hightLight;

    public GameObject newspaperB;
    public GameObject newspaperM;


    private bool canKey;

    // Start is called before the first frame update
    void Start()
    {
        newspaperBG.SetActive(false);
        BG.SetActive(false);

        newspaperB.SetActive(false);
        newspaperM.SetActive(false);


        hightLight.SetActive(false);
        newspaper.enabled = false;

        canKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        newspaperBG.SetActive(false);
        BG.SetActive(false);
        family04.donTransform = false;
    }

    public void Newspaper(string news)
    {
        Flowchart.BroadcastFungusMessage(news);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canKey = true;
            newspaper.enabled = true;
            hightLight.SetActive(true);
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0) && canKey)
            {
                if (DirectionLock.newsF || EP03.dollG || puzzle09.p09can)
                {
                    Flowchart.BroadcastFungusMessage("have");
                }
                else
                {
                    Flowchart.BroadcastFungusMessage("newspaper");
                }               
                family04.donTransform = true;
                canKey = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        hightLight.SetActive(false);
        newspaper.enabled = false;
        canKey = false;
    }

}
