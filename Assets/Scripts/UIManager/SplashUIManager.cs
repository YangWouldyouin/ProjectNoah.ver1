using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashUIManager : MonoBehaviour
{
    public GameObject Text;
    
    // Start is called before the first frame update
    void Start()
    {
        setResolution();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void setResolution()
    {
        int setWidth = 1440;
        int setHeight = 900;

        Screen.SetResolution(setWidth, setHeight, false);
    }
}
