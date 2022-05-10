using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Fadeinout : MonoBehaviour
{
    public GameObject Intro_GUI;
    public Text introtext;

    // Start is called before the first frame update
    void Start()
    {
        Intro_GUI.SetActive(true);
        Invoke("nextText2", 4f);
    }

    public void nextText2()
    {
        introtext.text = "이에 대한 대책으로 인류는 지구 밖, 광활한 우주로 눈을 돌렸고"+ "\n" +"세계적인 대기업 ‘레비젼’을 선두로 하여 적극적인 우주 탐사가 시작되었다.";
        Invoke("nextText3", 4f);
    }


    public void nextText3()
    {
        introtext.text = "‘레비젼’은 동물 복지의 일환으로 여러 유기동물들을 훈련시켜 우주탐사자로 발탁하였고," + "\n" + "관련하여 대대적인 마케팅을 펼쳐 사람들의 호응을 얻었다.";
        Invoke("nextText4", 4f);
    }

    public void nextText4()
    {
        introtext.text = "‘레비젼’이 키워낸 최고의 천재견 노아no.113는" + "\n" + "블랙홀을 탐사하는 프로젝트 블랙의 113번째 탐사견이다.";
        Invoke("introEnd", 4f);
    }
    public void introEnd()
    {
        Intro_GUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
