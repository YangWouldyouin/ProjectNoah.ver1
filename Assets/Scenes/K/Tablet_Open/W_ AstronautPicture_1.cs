using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_AstronautPicture_1: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, NoCenterButton, smashButton;

    ObjData LoverPicture_W;

    public GameObject AstronautPicture_1_Image_W;
    ObjData AstronautPicture_1_ImageData_W;

    // 상호작용 오브젝트
    public GameObject Tablet_W;

    // 상호작용 오브젝트 데이터
    ObjData TabletData_W;

    public bool TabletUnlock = false; // 태블릿 잠금여부

    void Start()
    {
        LoverPicture_W = GetComponent<ObjData>();
        AstronautPicture_1_ImageData_W = AstronautPicture_1_Image_W.GetComponent<ObjData>();
        TabletData_W = Tablet_W.GetComponent<ObjData>();


        barkButton = LoverPicture_W.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = LoverPicture_W.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = LoverPicture_W.BiteButton;

        smashButton = LoverPicture_W.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = LoverPicture_W.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        NoCenterButton = LoverPicture_W.CenterButton1; // 비활성화 버튼
    }
    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        // smashButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {
    }
    public void OnBark()
    {
        LoverPicture_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        LoverPicture_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        if(TabletData_W.IsObserve)
        {
            TabletUnlock = true;
        }
    }

    public void OnObserve()
    {
        LoverPicture_W.IsObserve = true;
        DiableButton();
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        //CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // 관찰 뷰 : 위쪽
        InteractionButtonController.interactionButtonController.playerObserve();

        AstronautPicture_1_ImageData_W.gameObject.SetActive(true); // UI로 사진이미지 크게 보여주기
    }

    public void OnPushOrPress()
    {
        LoverPicture_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        LoverPicture_W.IsPushOrPress = false;
    }


    public void OnEat()
    {
    }

    public void OnInsert()
    {
    }
    public void OnSmash()
    {
    }
    public void OnSniff()
    {
    }
    public void OnUp()
    {
    }
}
