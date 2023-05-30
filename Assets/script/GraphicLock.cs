using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class GraphicLock : MonoBehaviour
{
    public string password = "";  // 預設密碼

    public string currentInput = "";  // 目前使用者輸入的密碼

    // 儲存所有的按鈕
    private List<GameObject> buttons = new List<GameObject>();

    public InputField inputField;
    private int charCount = 0;

    public Image TBar;
    public GameObject hide;

    public static bool dolldie;

    // Start is called before the first frame update
    void Start()
    {
        dolldie = false;
        // 取得所有的按鈕
        GameObject[] buttonArray = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttonArray.Length; i++)
        {
            buttons.Add(buttonArray[i]);
        }
    }

    void Update()
    {
        TBar.GetComponent<Image>().fillAmount -= 0.001f;

        if (TBar.GetComponent<Image>().fillAmount == 0)
        {
            if (hide != null)
            {
                // 取得按鈕的 EventSystem
                EventSystem eventSystem = EventSystem.current;

                // 建立按鈕的 PointerEventData
                PointerEventData pointerEventData = new PointerEventData(eventSystem);
                // 將事件位置設為按鈕中心
                pointerEventData.position = hide.transform.position;

                // 手動觸發按鈕的點擊事件
                hide.GetComponent<Button>().OnPointerClick(pointerEventData);
            }
        }
    }

    bool InputError = true;

    public void SetInputFieldText(string text)
    {
        if (charCount < 3)
        {
            inputField.text += text;
            charCount++;
        }
        else
        {
            inputField.text = text;
            charCount = 1;
        }
    }

    // 更新目前使用者輸入的密碼
    public void UpdateInput(string buttonValue)
    {
        if (currentInput.Length < 6)
        {
            currentInput += buttonValue;
        }
        if (currentInput.Length == 6)
        {
            if (currentInput == password)
            {
                Debug.Log("解鎖成功！");
                enmeyborn.canborn = true;
                if (hide != null)
                {
                    // 取得按鈕的 EventSystem
                    EventSystem eventSystem = EventSystem.current;

                    // 建立按鈕的 PointerEventData
                    PointerEventData pointerEventData = new PointerEventData(eventSystem);
                    // 將事件位置設為按鈕中心
                    pointerEventData.position = hide.transform.position;

                    // 手動觸發按鈕的點擊事件
                    hide.GetComponent<Button>().OnPointerClick(pointerEventData);
                }
                Flowchart.BroadcastFungusMessage("dollDie");
                dolldie = true;
            }
            else
            {
                InputError = false;
                currentInput = "";
                Debug.LogError("密碼錯誤！");
                InputError = true;
            }
        }
    }



    // 重設使用者輸入的密碼
    public void ResetInput()
    {
        currentInput = "";
    }

    // 隱藏所有的按鈕
    public void HideButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    // 顯示所有的按鈕
    public void ShowButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }
}
