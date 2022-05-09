using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingListUIManager : MonoBehaviour
{
    public Sprite Finish_Ending;

    [Header("<엔딩 이미지>")]
    public Image Ending1;
    public Image Ending2;
    public Image Ending3;
    public Image Ending4;
    public Image Ending5;
    public Image Ending6;
    public Image Ending7;
    public Image Ending8;
    public Image Ending9;

    [Header("<엔딩 텍스트>")]
    public Text Ending1T;
    public Text Ending2T;
    public Text Ending3T;
    public Text Ending4T;
    public Text Ending5T;
    public Text Ending6T;
    public Text Ending7T;
    public Text Ending8T;
    public Text Ending9T;

    // Start is called before the first frame update
    void Start()
    {
        Ending1 = Ending1.GetComponent<Image>();
        Ending2 = Ending2.GetComponent<Image>();
        Ending3 = Ending3.GetComponent<Image>();
        Ending4 = Ending4.GetComponent<Image>();
        Ending5 = Ending5.GetComponent<Image>();
        Ending6 = Ending6.GetComponent<Image>();
        Ending7 = Ending7.GetComponent<Image>();
        Ending8 = Ending8.GetComponent<Image>();
        Ending9 = Ending9.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager._gameData.IsDisqualifiedEnd)
        {
            Ending1.sprite = Finish_Ending;
            Ending1T.text = "인재부족";
        }

        if (GameManager.gameManager._gameData.IsEatBadPotato)
        {
            Ending2.sprite = Finish_Ending;
            Ending2T.text = "상한 고구마 섭취";
        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd)
        {
            Ending3.sprite = Finish_Ending;
            Ending3T.text = "새로운 생태계 구축";
        }

        if (GameManager.gameManager._gameData.IsManagerAbilityLack)
        {
            Ending4.sprite = Finish_Ending;
            Ending4T.text = "관리자 자질 부족";
        }

        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd)
        {
            Ending5.sprite = Finish_Ending;
            Ending5T.text = "새로운 자원";
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd)
        {
            Ending6.sprite = Finish_Ending;
            Ending6T.text = "실험체 폐기";
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd)
        {
            Ending7.sprite = Finish_Ending;
            Ending7T.text = "당신이 구한 하나";
        }

        if (GameManager.gameManager._gameData.IsSaveAllEnd)
        {
            Ending8.sprite = Finish_Ending;
            Ending8T.text = "당신이 구한 하나이자 전부";
        }

        if (GameManager.gameManager._gameData.IsDefyMissionEnd)
        {
            Ending9.sprite = Finish_Ending;
            Ending9T.text = "명령 불복종";
        }
    }
}
