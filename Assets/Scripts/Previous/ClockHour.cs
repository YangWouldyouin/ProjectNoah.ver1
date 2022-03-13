using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHour : MonoBehaviour
{
    public float timeStartt=02;

    public Text Boxx1;
    public Text Boxx2;
    public Text Boxx3;

    public Text DayBoxx;

    private float checkerr;

    // Start is called before the first frame update
    void Start()
    {
        Boxx3.text=timeStartt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        checkerr+=Time.deltaTime;
        if(Mathf.Round(checkerr)==2)
        {
            timeStartt += 1;
            if(timeStartt!=6)
            {
                Boxx3.text=Mathf.Round(timeStartt).ToString();
                checkerr=0;
            }
            else
            {
                timeStartt=0;
                Boxx1.text=Mathf.Round(timeStartt).ToString();
                Boxx2.text=Mathf.Round(timeStartt).ToString();
                Boxx3.text=Mathf.Round(timeStartt).ToString();
                DayBoxx.text=Mathf.Round(3).ToString();
                checkerr=0;
            }
        }
    }


}
