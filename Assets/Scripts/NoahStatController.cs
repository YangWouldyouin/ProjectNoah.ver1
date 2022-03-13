using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoahStatController : MonoBehaviour
{
    public static NoahStatController noahStatController { get; private set; }


    [SerializeField] Image[] statColor;
    [SerializeField] Image[] statBar;

    [SerializeField] TMPro.TextMeshProUGUI conditionText;

    private int statColorIndex = 3;
    private int statBarIndex = 9;
    

    void Start()
    {
        StartCoroutine("StatBar");
    }
        

    IEnumerator StatBar()
    {
        while (statBarIndex >= 0)
        {
            Color color = statBar[statBarIndex].GetComponent<Image>().color;
            color.a = 0f;
            statBar[statBarIndex].GetComponent<Image>().color = color;


            if(statBarIndex <= 4 && statBarIndex > 1)
            {
                Color statColor2 = statColor[2].GetComponent<Image>().color;
                statColor2.a = 0f;
                statColor[2].GetComponent<Image>().color = statColor2;

                Color statColor1 = statColor[1].GetComponent<Image>().color;
                statColor1.a = 1f;
                statColor[1].GetComponent<Image>().color = statColor1;
                conditionText.text = "[상태] \"불안함\"";
            }
            else if(statBarIndex == 1)
            {
                Color statColor1 = statColor[1].GetComponent<Image>().color;
                statColor1.a = 0f;
                statColor[1].GetComponent<Image>().color = statColor1;

                Color statColor0 = statColor[0].GetComponent<Image>().color;
                statColor0.a = 1f;
                statColor[0].GetComponent<Image>().color = statColor0;
                conditionText.text = "[상태] \"나쁨\"";
            }
            else if(statBarIndex==0)
            {
                Color statColor0 = statColor[0].GetComponent<Image>().color;
                statColor0.a = 0f;
                statColor[0].GetComponent<Image>().color = statColor0;
                conditionText.text = "[상태] \"사망\"";
            }
            statBarIndex--;
            yield return new WaitForSeconds(1f); 
        }
    }
}
