using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public float timeStart=04;
    public Text textBox;
    private float checker;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text=timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        checker+=Time.deltaTime;
        if(Mathf.Round(checker)==720)
        {
            timeStart += 1;
            textBox.text=Mathf.Round(timeStart).ToString();
            checker=0;
        }
    }
}
