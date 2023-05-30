using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enmeyborn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] monsterTypes;// 存放不同種類的怪物預製體
    public GameObject bollBorn;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool canborn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(canborn)
            {
                canborn = false;
                int randomIndex = Random.Range(0, monsterTypes.Length); // 隨機選擇怪物種類的索引值
                Instantiate(monsterTypes[randomIndex], bollBorn.transform.position, bollBorn.transform.rotation);
                Destroy(this.gameObject);
            }
            
        }
        
    }
}
