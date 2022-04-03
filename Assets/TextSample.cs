using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSample : MonoBehaviour
{
    public GameObject samplePanel;
    public TMPro.TextMeshProUGUI sampleText;
    float timer = 0; 

    void printSomthing()
    {
        samplePanel.SetActive(true); // 상태창을 활성화한다. 
        sampleText.text = "이상한 소리가 들린다.";

        timer += Time.deltaTime;
        float seconds = Mathf.FloorToInt((timer % 3600) % 60);
        if(seconds>=3f) // 3초가 지나면 상태창을 비활성화 한다.
        {
            samplePanel.SetActive(false);
        }

    }
    private void Update()
    {
        
        printSomthing();
    }
}
