using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_AstronautPicture_4: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, NoCenterButton, smashButton, observeButton;

    public ObjectData AstronautPictureData_4_W;
    ObjData AstronautPicture_4_W;

    public GameObject AstronautPicture_4_Image_W;
    ObjData AstronautPicture_4_ImageData_W;

    void Start()
    {
        AstronautPicture_4_W = GetComponent<ObjData>();
        AstronautPicture_4_ImageData_W = AstronautPicture_4_Image_W.GetComponent<ObjData>();


        barkButton = AstronautPicture_4_W.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = AstronautPicture_4_W.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = AstronautPicture_4_W.BiteButton;

        smashButton = AstronautPicture_4_W.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = AstronautPicture_4_W.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        observeButton = AstronautPicture_4_W.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);

        NoCenterButton = AstronautPicture_4_W.CenterButton1; // 비활성화 버튼
    }
    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        // smashButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (AstronautPictureData_4_W == false)
        {
            AstronautPicture_4_Image_W.SetActive(false);
        }
    }

    public void OnBark()
    {
        AstronautPicture_4_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        AstronautPicture_4_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        DiableButton();
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        //CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // 관찰 뷰 : 위쪽
        // InteractionButtonController.interactionButtonController.playerObserve();

        AstronautPicture_4_Image_W.SetActive(true); // UI로 사진이미지 크게 보여주기
        StartCoroutine(TurnOffPicture());
    }

    IEnumerator TurnOffPicture()
    {
        yield return new WaitForSeconds(5f);
        AstronautPicture_4_Image_W.SetActive(false); // UI로 사진이미지 크게 보여주기
    }


    public void OnPushOrPress()
    {
        AstronautPicture_4_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        AstronautPicture_4_W.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        AstronautPicture_4_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
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
    public void OnUp()
    {
    }
}
