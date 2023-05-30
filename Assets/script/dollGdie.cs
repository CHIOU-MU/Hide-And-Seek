using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class dollGdie : MonoBehaviour
{
    public GameObject room;

    public GameObject tv;
    private Animator TVanimator;
    private AudioSource audioSource;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.Find("bedroomG");

        tv = GameObject.Find("TV");
        TVanimator = tv.GetComponent<Animator>();
        audioSource = tv.GetComponent<AudioSource>();
        boxCollider = tv.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool suit = false;

    private void OnMouseDown()
    {
        suit = true;
        Flowchart.BroadcastFungusMessage("dollGdie");
        if (dollThing.bowtile && suit)
        {
            Invoke("TV", 2.5f);
        }
        Destroy(room);
    }
    void TV()
    {
        TVanimator.SetBool("open", true);
        audioSource.enabled = true;
        boxCollider.enabled = true;
    }

}
