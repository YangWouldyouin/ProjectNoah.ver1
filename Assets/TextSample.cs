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
        samplePanel.SetActive(true); // ����â�� Ȱ��ȭ�Ѵ�. 
        sampleText.text = "�̻��� �Ҹ��� �鸰��.";

        timer += Time.deltaTime;
        float seconds = Mathf.FloorToInt((timer % 3600) % 60);
        if(seconds>=3f) // 3�ʰ� ������ ����â�� ��Ȱ��ȭ �Ѵ�.
        {
            samplePanel.SetActive(false);
        }

    }
    private void Update()
    {
        
        printSomthing();
    }
}
