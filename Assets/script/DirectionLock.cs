using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class DirectionLock : MonoBehaviour
{
    //方向鎖
    public string password = "1234";  // 預設密碼
    public Text statusText;  // 顯示解鎖狀態的文字元件
    public float minSwipeDistance = 20.0f;  // 最小滑動距離，用於檢測滑動是否有效

    public string currentInput = "";  // 目前使用者輸入的密碼
    private Vector2 startTouchPosition;  // 滑動開始的位置

    public GameObject camDL;
    public GameObject hightLight;
    public GameObject PlayerLight;

    public GameObject newspaperF;

    // 儲存所有的按鈕
    private List<GameObject> buttons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        // 取得所有的按鈕
        GameObject[] buttonArray = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttonArray.Length; i++)
        {
            buttons.Add(buttonArray[i]);
        }

        camDL.SetActive(false);
        hightLight.SetActive(false);
        newspaperF.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endTouchPosition = Input.mousePosition;
            float distance = Vector2.Distance(startTouchPosition, endTouchPosition);
            if (distance > minSwipeDistance)
            {
                Vector2 swipeDirection = endTouchPosition - startTouchPosition;
                if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                {
                    // 左右滑動
                    if (swipeDirection.x > 0)
                    {
                        // 向右滑動
                        UpdateInput("R");
                    }
                    else
                    {
                        // 向左滑動
                        UpdateInput("L");
                    }
                }
                else
                {
                    // 上下滑動
                    if (swipeDirection.y > 0)
                    {
                        // 向上滑動
                        UpdateInput("U");
                    }
                    else
                    {
                        // 向下滑動
                        UpdateInput("D");
                    }
                }
            }
        }
    }

    static public bool newsF=false;

    // 更新目前使用者輸入的密碼
    public void UpdateInput(string direction)
    {
        switch (direction)
        {
            case "U":
                currentInput += "1";
                break;
            case "D":
                currentInput += "2";
                break;
            case "L":
                currentInput += "3";
                break;
            case "R":
                currentInput += "4";
                break;
        }

        if (currentInput.Length == 5)
        {
            if (currentInput == password)
            {
                Debug.Log( "解鎖成功！");
                newsF = true;
                Flowchart.BroadcastFungusMessage("canOpen");
                newspaperF.SetActive(true);
            }
            else
            {
                currentInput = "";
                //statusText.text = "密碼錯誤！";
                Flowchart.BroadcastFungusMessage("error");
            }
        }
    }

     bool isDL=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hightLight.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isDL = true;
            if (Input.GetMouseButtonUp(0) && isDL)
            {
                camDL.SetActive(true);
                hightLight.SetActive(false);
                PlayerLight.SetActive(false);
                isDL = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isDL = true;
            hightLight.SetActive(false);
        }
    }

    public void close()
    {
        camDL.SetActive(false);
        hightLight.SetActive(true);
        PlayerLight.SetActive(true);
        currentInput = "";
    }

}

