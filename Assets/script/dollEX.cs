using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class dollEX : MonoBehaviour
{

    private Transform target;
    public float moveSpeed;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public AudioSource audioSource;

    public GameObject playCamera;
    public GameObject blood;
    public GameObject endCamera;
    public GameObject inputName;

    bool canInput = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playCamera = GameObject.Find("Main Camera");
        blood = GameObject.Find("blood");

        blood.SetActive(true);
        playCamera.SetActive(true);
        endCamera.SetActive(false);
        audioSource.Play();
        inputName.SetActive(false);


        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.speed = moveSpeed;
        if (navMeshAgent == null)
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }

        Invoke("namePanal", 2);

        Destroy(this.gameObject, 20);


    }

    // Update is called once per frame
    void Update()
    {
        if (GraphicLock.dolldie)
        {
            inputName.SetActive(false);
            Time.timeScale = 1;
            audioSource.Play();
            Flowchart.BroadcastFungusMessage("exDoll");
            GraphicLock.dolldie=false;
        }
        else
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
    }


    private void namePanal()
    {
        if (canInput)
        {
            inputName.SetActive(true);
            Time.timeScale = 0;
            audioSource.Pause();
            canInput = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }

}
