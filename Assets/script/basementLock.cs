using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class basementLock : MonoBehaviour
{
    public string password = "1234";  // 預設密碼
    public string currentInput = "";  // 目前使用者輸入的密碼

    public GameObject camBML;
    public GameObject hightLight;
    public GameObject PlayerLight;
    bool isGL = false;



    // Start is called before the first frame update
    void Start()
    {
        camBML.SetActive(false);
        hightLight.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateInput(string buttonValue)
    {
        if (currentInput.Length < 4)
        {
            currentInput += buttonValue;
        }
        if (currentInput.Length == 4)
        {
            if (currentInput == password)
            {
                Flowchart.BroadcastFungusMessage("BMopen");
                Debug.Log("解鎖成功！");
            }
            else
            {
                currentInput = "";
                Flowchart.BroadcastFungusMessage("BMerror");
                Debug.Log("密碼錯誤！");
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hightLight.SetActive(true);
            isGL = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" )
        {
            if (Input.GetMouseButtonDown(0) && isGL)
            {
                camBML.SetActive(true);
                hightLight.SetActive(false);
                PlayerLight.SetActive(false);
                isGL = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isGL = false;
            hightLight.SetActive(false);
        }
    }

    public void close()
    {
        camBML.SetActive(false);
        PlayerLight.SetActive(true);
        hightLight.SetActive(true);
        currentInput = "";
    }
}
