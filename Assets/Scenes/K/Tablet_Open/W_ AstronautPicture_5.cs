using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_AstronautPicture_5: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, NoCenterButton, smashButton;

    ObjData AstronautPicture_5_W;

    public GameObject AstronautPicture_5_Image_W;
    ObjData AstronautPicture_5_ImageData_W;

    void Start()
    {
        AstronautPicture_5_W = GetComponent<ObjData>();
        AstronautPicture_5_ImageData_W = AstronautPicture_5_Image_W.GetComponent<ObjData>();


        barkButton = AstronautPicture_5_W.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = AstronautPicture_5_W.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = AstronautPicture_5_W.BiteButton;

        smashButton = AstronautPicture_5_W.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pushButton = AstronautPicture_5_W.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        NoCenterButton = AstronautPicture_5_W.CenterButton1; // ��Ȱ��ȭ ��ư
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
        AstronautPicture_5_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        AstronautPicture_5_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnObserve()
    {
        AstronautPicture_5_W.IsObserve = true;
        DiableButton();
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        //CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // ���� �� : ����
        InteractionButtonController.interactionButtonController.playerObserve();

        AstronautPicture_5_ImageData_W.gameObject.SetActive(true); // UI�� �����̹��� ũ�� �����ֱ�
    }

    public void OnPushOrPress()
    {
        AstronautPicture_5_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        AstronautPicture_5_W.IsPushOrPress = false;
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
