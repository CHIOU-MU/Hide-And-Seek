using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LongTimeNoInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float maxTimeOffset = 10;
    private float lasterTime;
    private float nowTime;
    private float offsetTime;
    private float mouseX;
    private float mouseY;

    float mouseSensitivity = 100f;

    private void Awake()
    {
        lasterTime = Time.time;

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * 0.5f * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * 0.5f * mouseSensitivity * Time.deltaTime;

        nowTime = Time.time;
        if(Input.anyKey || mouseX>0 || mouseY>0 )
        {
            //Debug.LogError("操作中");
            lasterTime = nowTime;
        }

        offsetTime = Mathf.Abs(nowTime - lasterTime);
        if(offsetTime>maxTimeOffset)
        {
            SceneManager.LoadScene("home");
            //Debug.Log("長時間沒操作");
        }
    }
}
