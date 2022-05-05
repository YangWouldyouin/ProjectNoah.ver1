using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class P_PictureButton : MonoBehaviour, IInteraction
{
    private Button barkButton_P_PictureButton, sniffButton_P_PictureButton, biteButton_P_PictureButton,
pushButton_P_PictureButton, noCenterButton_P_PictureButton,smashButton_P_PictureButton;

    ObjData PictureButton_P;
    public ObjectData pictureButtonData;

    // UI 오브젝트
    public GameObject UniverseImage_P; // 우주 사진

    // 오브젝트 데이터
    ObjData UniverseImageData_P;

    AudioSource TakePic_Sound_P;

    public GameObject[] UniverseImageList; // 우주 사진 리스트

    public GameObject Report_GUI_P; // 보고하기 GUI
    private bool IsReported = false;

    public int ran; // 랜덤 사진

    void Start()
    {
        PictureButton_P = GetComponent<ObjData>();

        TakePic_Sound_P = GetComponent<AudioSource>();
        TakePic_Sound_P.Stop();

        barkButton_P_PictureButton = PictureButton_P.BarkButton;
        barkButton_P_PictureButton.onClick.AddListener(OnBark);

        sniffButton_P_PictureButton = PictureButton_P.SniffButton;
        sniffButton_P_PictureButton.onClick.AddListener(OnSniff);

        biteButton_P_PictureButton = PictureButton_P.BiteButton;
        biteButton_P_PictureButton.onClick.AddListener(OnBite);

        smashButton_P_PictureButton = PictureButton_P.SmashButton;
        smashButton_P_PictureButton.onClick.AddListener(OnSmash);

        pushButton_P_PictureButton = PictureButton_P.PushOrPressButton;
        pushButton_P_PictureButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_P_PictureButton = PictureButton_P.CenterButton1;
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_P_PictureButton.transform.gameObject.SetActive(false);
        sniffButton_P_PictureButton.transform.gameObject.SetActive(false);
        biteButton_P_PictureButton.transform.gameObject.SetActive(false);
        pushButton_P_PictureButton.transform.gameObject.SetActive(false);
        noCenterButton_P_PictureButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }


    public void OnBark()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnBite()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnPushOrPress()
    {
        ran = Random.Range(0, 5); // 랜덤 사진
        GameManager.gameManager._gameData.randomUPic = ran;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        Debug.Log("랜덤 사진 저장");

        /* 밀기 & 누르기 중에 "누르기"일 때!!! */
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        Invoke("RandomUniversePic", 1f); // 랜덤 우주 사진 설정 + 이미지 보여주기

        TakePic_Sound_P.Play(); // 효과음 재생
        Invoke("Report_Popup", 4f); // 보고하기 팝업
    }

    /* UI 스크립트 */
    public void RandomUniversePic() // 랜덤 우주 사진 보여주기
    {
        UniverseImage_P = UniverseImageList[ran]; // 우주 이미지 랜덤으로 UniverseImage_P 에 삽입
        UniverseImage_P.SetActive(true); // 우주 사진 보여주기
    }

    public void Report_Popup() // 보고하기 GUI 띄우기
    {
        Report_GUI_P.SetActive(true);
    }



    public void Report() // 보고하기 버튼 누르면
    {
        Debug.Log("보고하기");
        IsReported = true;

        Report_GUI_P.SetActive(false); // 창 끄기
        UniverseImage_P.SetActive(false);
    }

    public void Cancel() //캔슬 버튼 누르면
    {
        Debug.Log("취소하기");

        GameManager.gameManager._gameData.IsReportCancleCount -= 1; // 임무 보고 카운트 줄어들기
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsReported = true;
        Debug.Log("임무 보고 카운트 줄어들기 + 저장");

        Report_GUI_P.SetActive(false); // 창 끄기
        UniverseImage_P.SetActive(false);
    }





    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnObserve()
    {
    }
    public void OnSmash()
    {
    }

    public void OnUp()
    {
    }

}
