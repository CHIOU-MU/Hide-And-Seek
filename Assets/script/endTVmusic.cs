using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTVmusic : MonoBehaviour
{
    public GameObject player;  // 跟踪玩家位置的Transform组件
    public float maxDistance = 10f;  // 聲音最大距離

    private AudioSource audioSource;  // 聲音播放器组件


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = 1f - (distance / maxDistance);
        }
    }
}
