using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashUIManager : MonoBehaviour
{
    public GameObject Text;

    public bool Fullscreenon = true;

    // Start is called before the first frame update
    void Start()
    {
        //setResolution();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main");
        }

        //if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Return))
        //{
        //    if(Fullscreenon == true)
        //    {
        //        int setWidth = 1440;
        //        int setHeight = 900;

        //        Screen.SetResolution(setWidth, setHeight, false);
        //        Fullscreenon = false;
        //    }
        //    else if (Fullscreenon == false)
        //    {
        //        int setWidth = 1920;
        //        int setHeight = 1080;

        //        Screen.SetResolution(setWidth, setHeight, true);
        //        Fullscreenon = true;
        //    }
        //}
    }

    public void setResolution()
    {
        int setWidth = 1440;
        int setHeight = 900;

        Screen.SetResolution(setWidth, setHeight, false);
    }
}
