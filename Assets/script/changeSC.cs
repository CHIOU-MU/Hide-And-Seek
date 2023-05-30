using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSC : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Onclick()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void start() 
    {
        SceneManager.LoadScene("StarScene");
    }

    public void exit()
    {
        Application.Quit();
    }
}
