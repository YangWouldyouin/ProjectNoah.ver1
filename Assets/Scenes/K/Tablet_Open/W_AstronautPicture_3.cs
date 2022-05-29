using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_AstronautPicture_3: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, NoCenterButton, smashButton, observeButton;

    public ObjectData AstronautPictureData_3_W;
    ObjData AstronautPicture_3_W;

    public GameObject AstronautPicture_3_Image_W;
    ObjData AstronautPicture_3_ImageData_W;

    void Start()
    {
        AstronautPicture_3_W = GetComponent<ObjData>();
        AstronautPicture_3_ImageData_W = AstronautPicture_3_Image_W.GetComponent<ObjData>();


        barkButton = AstronautPicture_3_W.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = AstronautPicture_3_W.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = AstronautPicture_3_W.BiteButton;

        smashButton = AstronautPicture_3_W.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = AstronautPicture_3_W.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        observeButton = AstronautPicture_3_W.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);

        NoCenterButton = AstronautPicture_3_W.CenterButton1; // ��Ȱ��ȭ ��ư
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
        if (AstronautPictureData_3_W == false)
        {
            AstronautPicture_3_Image_W.SetActive(false);
        }
    }

    public void OnBark()
    {
        AstronautPicture_3_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        AstronautPicture_3_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        DiableButton();
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        //CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // ���� �� : ����
        // InteractionButtonController.interactionButtonController.playerObserve();

        AstronautPicture_3_Image_W.SetActive(true); // UI�� �����̹��� ũ�� �����ֱ�
        StartCoroutine(TurnOffPicture());
    }

    IEnumerator TurnOffPicture()
    {
        yield return new WaitForSeconds(5f);
        AstronautPicture_3_Image_W.SetActive(false); // UI�� �����̹��� ũ�� �����ֱ�
    }


    public void OnPushOrPress()
    {
        AstronautPicture_3_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        AstronautPicture_3_W.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        AstronautPicture_3_W.IsSniff = true;
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
