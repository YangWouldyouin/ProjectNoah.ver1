using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_RecordSoundManager : MonoBehaviour
{
    // �¿� ��ư
    public GameObject RightButton_Rec;
    public GameObject LeftButton_Rec;

    public Text PageNum_Rec; // �������ѹ�
    public Text RecordTitle_1_Rec;
    public Text RecordTitle_2_Rec;

    public string[] RecordTitle;

    public int k = 0; // ������ ����

    // ��� �̹���
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

        RecordTitle[0] = "���� ���� 1";
        RecordTitle[1] = "���� ���� 2";
        RecordTitle[2] = "���� ���� 3";
        RecordTitle[3] = "���� ���� 4";
        RecordTitle[4] = "���� ���� 5";
        RecordTitle[5] = "���� ���� 6";

        RecordTitle_1_Rec.text = RecordTitle[0];
        RecordTitle_2_Rec.text = RecordTitle[1];
        PageNum_Rec.text = "1 / 3";



    }

    void Update()
    {
        // ������ �ѹ�
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


        // ���� ��� ������ ��
        if (!Audio_Rec.isPlaying)
        {
            PlayButton_1_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            PlayButton_2_Rec.GetComponent<Image>().sprite = StartIcon_Rec;
            Audio_Rec.Stop();
        }
    }

    public void OnClickRightButton() // ������ ��ư�� ���� ��
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


        PageNum_Rec.text = (k + 2).ToString() + " / 3"; // ������ �ѹ�
        k++;
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
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


        PageNum_Rec.text = (k).ToString() + " / 3"; // ������ �ѹ�
        k--;
    }




    public void OnClickPlayButton1()
    {
        if(IsButton1Clicked) // �뷡 ��� �� ������ ��
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
        if (IsButton2Clicked) // �뷡 ��� �� ������ ��
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
