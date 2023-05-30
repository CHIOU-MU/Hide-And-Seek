using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform target;
    public float moveSpeed;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    AudioSource audioSource;

    public GameObject playCamera;
    public GameObject blood;
    public GameObject endCamera;
    public GameObject inputName;
    public GameObject endWord;

    bool canInput = true;

    private Coroutine _destroyCoroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playCamera = GameObject.Find("Main Camera");
        blood = GameObject.Find("blood");

        blood.SetActive(true);
        playCamera.SetActive(true);
        endCamera.SetActive(false);
        endWord.SetActive(false);
        audioSource.Play();
        inputName.SetActive(false);


        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.speed = moveSpeed;
        if(navMeshAgent == null)
        {
            navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        }

        Invoke("namePanal",3);

        _destroyCoroutine = StartCoroutine(DestroyAfterTime(20f));

    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        enmeyborn.canborn = true;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(GraphicLock.dolldie)
        {
            audioSource.Stop();
            navMeshAgent.speed = 0;
        }
        else
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        
    }

    private void namePanal()
    {
        if(canInput)
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
            canInput = false;
            blood.SetActive(false);
            playCamera.SetActive(false);
            endCamera.SetActive(true);
            animator.SetBool("end", true);
            endWord.SetActive(true);
            audioSource.Stop();

            StopCoroutine(_destroyCoroutine);
        }

    }

    public void replay()
    {
        Flowchart.BroadcastFungusMessage("end");
        endWord.SetActive(false);
        Invoke("reStart", 2);
    }

    public void close()
    {
        inputName.SetActive(false);
        Time.timeScale = 1;
        audioSource.Play();

    }

    void reStart()
    {
        enmeyborn.canborn = true;
        playCamera.SetActive(true);
        Destroy(this.gameObject);
        GameObject.Find("player").transform.position = RecordPointManager.Get_playerRecordPos();
        
    }
}
