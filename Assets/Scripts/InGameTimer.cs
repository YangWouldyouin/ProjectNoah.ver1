using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameTimer : MonoBehaviour
{
    public void change()
    {
        SceneManager.LoadScene("New Scene");
    }
    bool IsStarted = false;
    public Text textCounter;
    int counter = 1;
    DateTime pauseDateTime;
    // Start is called before the first frame update
    void Start()
    {
        IsStarted = true;
        StartCoroutine(Count());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationPause(bool paused)
    {
        if(IsStarted)
        {
            if(paused)
            {
                pauseDateTime = DateTime.Now;
            }
            else
            {
                counter += (int)(DateTime.Now - pauseDateTime).TotalSeconds;
            }
        }       
    }

    IEnumerator Count()
    {
        while (true)
        {
            textCounter.text = (counter++).ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
