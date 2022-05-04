using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_RecordSoundManager : MonoBehaviour
{
    // 좌우 버튼
    public GameObject RightButton_Rec;
    public GameObject LeftButton_Rec;

    public Text PageNum_Rec; // 페이지넘버
    public Text RecordTitle_1_Rec;
    public Text RecordTitle_2_Rec;

    public string[] RecordTitle;

    public int k = 0; // 페이지 변수

    // 재생 이미지
    public Sprite StartIcon_Rec;
    public Sprite DoneIcon_Rec;

    public Button PlayButton_1_Rec;
    public Button PlayButton_2_Rec;

    public bool IsButton1Clicked;
    public bool IsButton2Clicked;

    AudioSource Audio_Rec;

    public AudioClip [] RecordAudio;

    [SerializeField]
    int currentIndex = 0;

    void Start()
    {
        Audio_Rec = GetComponent<AudioSource>();

        RecordTitle[0] = "음성 녹음 1";
        RecordTitle[1] = "음성 녹음 2";
        RecordTitle[2] = "음성 녹음 3";
        RecordTitle[3] = "음성 녹음 4";
        RecordTitle[4] = "음성 녹음 5";
        RecordTitle[5] = "음성 녹음 6";

        RecordTitle_1_Rec.text = RecordTitle[0];
        RecordTitle_2_Rec.text = RecordTitle[1];
        PageNum_Rec.text = "1 / 3";



    }

    void Update()
    {
        // 페이지 넘버
        if (k < 1)
        {
            LeftButton_Rec.SetActive(false);
        }
        else
        {
            LeftButton_Rec.SetActive(true);
        }

        if (k == 2)
        {
            RightButton_Rec.SetActive(false);
        }
        else
        {
            RightButton_Rec.SetActive(true);
        }


        // 음악 재생 끝났을 때
        if (!Audio_Rec.isPlaying)
        {
            PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            Audio_Rec.Stop();
        }
    }

    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if (currentIndex <= 3)
            currentIndex += 2;

        RecordTitle_1_Rec.text = RecordTitle[currentIndex];
        RecordTitle_2_Rec.text = RecordTitle[currentIndex + 1];

        PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
        PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
        IsButton1Clicked = false;
        IsButton2Clicked = false;
        Audio_Rec.Stop();


        PageNum_Rec.text = (k + 2).ToString() + " / 3"; // 페이지 넘버
        k++;
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {

        if (currentIndex == 2 || currentIndex ==4 )
            currentIndex -= 2;

        RecordTitle_1_Rec.text = RecordTitle[currentIndex];
        RecordTitle_2_Rec.text = RecordTitle[currentIndex + 1];

        PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
        PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
        IsButton1Clicked = false;
        IsButton2Clicked = false;
        Audio_Rec.Stop();


        PageNum_Rec.text = (k).ToString() + " / 3"; // 페이지 넘버
        k--;
    }




    public void OnClickPlayButton1()
    {
        if(IsButton1Clicked) // 노래 재생 중 눌렀을 때
        {
            PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            Audio_Rec.Stop();
            Audio_Rec.clip = RecordAudio[0];
            IsButton1Clicked = false;
        }
        else
        {
            if (IsButton2Clicked)
            {
                Audio_Rec.Stop();
                PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
                IsButton2Clicked = false;
            }

            PlayButton_1_Rec.GetComponent<Image>().sprite = DoneIcon_Rec;
            Audio_Rec.clip = RecordAudio[currentIndex];
            Audio_Rec.Play();
            IsButton1Clicked = true;
        }
    }

    public void OnClickPlayButton2()
    {
        if (IsButton2Clicked) // 노래 재생 중 눌렀을 때
        {
            PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            Audio_Rec.Stop();
            Audio_Rec.clip = RecordAudio[1];
            IsButton2Clicked = false;
        }
        else
        {
            if(IsButton1Clicked)
            {
                Audio_Rec.Stop();
                PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
                IsButton1Clicked = false;
            }

            PlayButton_2_Rec.GetComponent<Image>().sprite = DoneIcon_Rec;
            Audio_Rec.clip = RecordAudio[currentIndex + 1];
            Audio_Rec.Play();
            IsButton2Clicked = true;
        }
    }

}
