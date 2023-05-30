using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class boyPhoto : MonoBehaviour
{
    public GameObject cam;
    public GameObject highlight;
    public GameObject playerLight;

    public GameObject puzzle;
    public GameObject puzzleB;
    public GameObject pu09;
    public GameObject ep04;

    public GameObject chair;
    public GameObject chairB;

    public Animator animator;

    public Button emptyButton;
    public Button[] buttons;

    void Start()
    {
        cam.SetActive(false);
        highlight.SetActive(false);
        ep04.SetActive(false);

        puzzle09.p09can = false;

        emptyButton.onClick.AddListener(OnEmptyButtonClick);

        /*// 找到空白按鈕
        int emptyButtonIndex = -1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == emptyButton)
            {
                emptyButtonIndex = i;
                break;
            }
        }

        // 從空白按鈕的上下左右四個方向中選擇一個進行交換
        for (int i = 0; i < 100; i++)
        {
            int randomDirection = Random.Range(0, 4);
            int swapButtonIndex = -1;

            switch (randomDirection)
            {
                case 0: // 上
                    if (emptyButtonIndex - 3 >= 0)
                    {
                        swapButtonIndex = emptyButtonIndex - 3;
                    }
                    break;

                case 1: // 下
                    if (emptyButtonIndex + 3 < buttons.Length)
                    {
                        swapButtonIndex = emptyButtonIndex + 3;
                    }
                    break;

                case 2: // 左
                    if (emptyButtonIndex % 3 != 0)
                    {
                        swapButtonIndex = emptyButtonIndex - 1;
                    }
                    break;

                case 3: // 右
                    if ((emptyButtonIndex + 1) % 3 != 0)
                    {
                        swapButtonIndex = emptyButtonIndex + 1;
                    }
                    break;
            }

            if (swapButtonIndex != -1)
            {
                SwapButtons(emptyButton, buttons[swapButtonIndex]);
                emptyButtonIndex = swapButtonIndex;
            }
        }*/

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

    }


    void OnEmptyButtonClick()
    {

    }

    void OnButtonClick(Button clickedButton)
    {
        if (IsAdjacentToEmptyButton(clickedButton))
        {
            SwapButtons(emptyButton, clickedButton);
        }
        
    }

    bool IsAdjacentToEmptyButton(Button button)
    {
        // 獲取空白按鈕的位置
        Vector3 emptyButtonPos = emptyButton.transform.localPosition;

        // 獲取被點擊的按鈕的位置
        Vector3 clickedButtonPos = button.transform.localPosition;

        // 如果被點擊的按鈕與空白按鈕水平或垂直相鄰，返回 true，否則返回 false
        if (Mathf.Abs(clickedButtonPos.x - emptyButtonPos.x) + Mathf.Abs(clickedButtonPos.y - emptyButtonPos.y) == 70)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    int GetButtonIndex(Button button)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == button)
            {
                return i;
            }
        }

        return -1;
    }

    void SwapButtons(Button button1, Button button2)
    {
        int index1 = GetButtonIndex(button1);
        int index2 = GetButtonIndex(button2);

        Vector3 pos1 = button1.transform.localPosition;
        Vector3 pos2 = button2.transform.localPosition;

        button1.transform.localPosition = pos2;
        button2.transform.localPosition = pos1;

        buttons[index1] = button2;
        buttons[index2] = button1;

        // 獲取 button1 和 button2 在 GridLayoutGroup 的索引
        int button1Index = button1.transform.GetSiblingIndex();
        int button2Index = button2.transform.GetSiblingIndex();

        // 交換 button1 和 button2 在 GridLayoutGroup 中的位置
        button1.transform.SetSiblingIndex(button2Index);
        button2.transform.SetSiblingIndex(button1Index);

        // 檢查是否解鎖成功
        if (IsSolved())
        {
            Destroy(puzzleB);
            puzzle.SetActive(true);
            Destroy(chair);
            chairB.SetActive(true);
            Flowchart.BroadcastFungusMessage("puzzle");
        }
    }

    bool IsSolved()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // 獲取物件名稱
            string buttonName = buttons[i].name;

            // 判斷名字是否對應到物件
            if (buttonName != "Puzzle" + (i + 1))
            {
                return false;
            }
        }

        return true;
    }

    public void close()
    {
        cam.SetActive(false);
        highlight.SetActive(true);
        playerLight.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            highlight.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if(puzzle09.p09can)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pu09.SetActive(true);
                    highlight.SetActive(false);                    
                    animator.SetBool("can", true);
                    ep04.SetActive(true);
                    Destroy(cam);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    cam.SetActive(true);
                    highlight.SetActive(false);
                    playerLight.SetActive(false);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        cam.SetActive(false);
        highlight.SetActive(false);
    }

}
