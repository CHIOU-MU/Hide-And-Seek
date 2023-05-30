using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVaudio : MonoBehaviour
{
    public Transform player;  // 跟踪玩家位置的Transform组件
    public float maxDistance = 10f;  // 聲音最大距離

    private AudioSource audioSource;  // 聲音播放器组件

    public GameObject tv1F;
    public GameObject N1F;
    public GameObject wall;

    public Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        
    }

    void Update()
    {
        wall = GameObject.Find("wall_1");

        float distance = Vector3.Distance(transform.position, player.position);
            if (distance > maxDistance)
            {
                audioSource.volume = 0f;
            }
            else
            {
                audioSource.volume = 1f - (distance / maxDistance);
            }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            wall = GameObject.Find("wall_1");
            Instantiate(tv1F);
            N1F.SetActive(false);
            wall.SetActive(false);
            animator.SetBool("tvTri", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        N1F.SetActive(true);
        wall.SetActive(true);
        GameObject objectToDelete = GameObject.Find("TVB(Clone)");
        Destroy(objectToDelete);
        animator.SetBool("tvTri", false);
    }
}
