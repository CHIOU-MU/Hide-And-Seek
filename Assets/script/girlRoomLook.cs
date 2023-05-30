using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class girlRoomLook : MonoBehaviour
{

    public string password = "1234";  // 預設密碼
    public string currentInput = "";  // 目前使用者輸入的密碼

    public GameObject camGL;
    public GameObject hightLight;
    public GameObject PlayerLight;
    bool isGL = false;
    bool open = true;

    public GameObject OGD;
    public GameObject inOGD;
    public GameObject CGD;
    public GameObject GD;


    // Start is called before the first frame update
    void Start()
    {
        camGL.SetActive(false);
        hightLight.SetActive(false);
        OGD.SetActive(false);
        inOGD.SetActive(false);
        CGD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInput(string buttonValue)
    {
        if (currentInput.Length < 8)
        {
            currentInput += buttonValue;
        }
        if (currentInput.Length == 8)
        {
            if (currentInput == password)
            {
                Flowchart.BroadcastFungusMessage("GRopen");
                open = false;
                OGD.SetActive(true);
                inOGD.SetActive(true);
                CGD.SetActive(true);
                Destroy(GD);
                Debug.Log( "解鎖成功！");
            }
            else
            {
                currentInput = "";
                Flowchart.BroadcastFungusMessage("GLerror");
                Debug.Log( "密碼錯誤！");
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && open )
        {
            hightLight.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && open)
        {
            isGL = true;
            if (Input.GetMouseButtonUp(0) && isGL)
            {
                camGL.SetActive(true);
                hightLight.SetActive(false);
                PlayerLight.SetActive(false);
                isGL = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && open)
        {
            isGL = true;
            hightLight.SetActive(false);
        }
    }

    public void close()
    {
        camGL.SetActive(false);
        PlayerLight.SetActive(true);
        hightLight.SetActive(true);
        currentInput = "";
    }

}
