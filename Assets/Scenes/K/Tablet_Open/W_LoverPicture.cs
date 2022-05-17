using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LoverPicture : MonoBehaviour, IInteraction
{
    private Button barkButton_W_LoverPicture, sniffButton_W_LoverPicture, biteButton_W_LoverPicture,
pushButton_W_LoverPicture, smashButton_W_LoverPicture, ObserveButton_W_LoverPicture;

    public ObjectData LoverPictureData_W;
    ObjData LoverPicture_W;

    public GameObject LoverPicture_Image_W;
    ObjData LoverPicture_ImageData_W;

    // ��ȣ�ۿ� ������Ʈ
    public GameObject Tablet_W;

    // ��ȣ�ۿ� ������Ʈ ������
    ObjData TabletData_W;

    public bool TabletUnlock = false; // �º� ���

    void Start()
    {
        LoverPicture_W = GetComponent<ObjData>();
        LoverPicture_ImageData_W = LoverPicture_Image_W.GetComponent<ObjData>();
        TabletData_W = Tablet_W.GetComponent<ObjData>();

        barkButton_W_LoverPicture = LoverPicture_W.BarkButton;
        barkButton_W_LoverPicture.onClick.AddListener(OnBark);

        sniffButton_W_LoverPicture = LoverPicture_W.SniffButton;
        sniffButton_W_LoverPicture.onClick.AddListener(OnSniff);

        biteButton_W_LoverPicture = LoverPicture_W.BiteButton;

        smashButton_W_LoverPicture = LoverPicture_W.SmashButton;
        smashButton_W_LoverPicture.onClick.AddListener(OnSmash);

        pushButton_W_LoverPicture = LoverPicture_W.PushOrPressButton;
        pushButton_W_LoverPicture.onClick.AddListener(OnPushOrPress);

        ObserveButton_W_LoverPicture = LoverPicture_W.CenterButton1;
        ObserveButton_W_LoverPicture.onClick.AddListener(OnObserve);

        LoverPicture_Image_W.SetActive(false);
    }
    void DiableButton()
    {
        // ��Ȱ��ȭ ��ư���� �����Ͽ� ������ ���� ��� ��ư ������ ����.

        // ex. ������ ��ư, ��� ��ư�� ������ ��ư�ε� ó���� ��Ȱ��ȭ
        barkButton_W_LoverPicture.transform.gameObject.SetActive(false);
        sniffButton_W_LoverPicture.transform.gameObject.SetActive(false);
        biteButton_W_LoverPicture.transform.gameObject.SetActive(false);
        // �ı��ϱⰡ �Ǵ� ������Ʈ�̸� �ı��ϱ� ��ư �߰�
        smashButton_W_LoverPicture.transform.gameObject.SetActive(false);
        pushButton_W_LoverPicture.transform.gameObject.SetActive(false);
        ObserveButton_W_LoverPicture.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if(LoverPictureData_W==false)
        {
            LoverPicture_Image_W.SetActive(false);
        }
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

/*        if (TabletData_W.IsObserve)
        {
            GameManager.gameManager._gameData.IsTabletUnlock = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("�º� �������");
        }
*//*        else
        {
            GameManager.gameManager._gameData.IsTabletUnlock = false;
            // SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }*/
    }

    public void OnObserve()
    {
        DiableButton();
        // PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        // CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // ���� �� : ����
        // InteractionButtonController.interactionButtonController.playerObserve();

        LoverPicture_Image_W.SetActive(true); // UI�� �����̹��� ũ�� �����ֱ�
        StartCoroutine(TurnOffPicture());
    }

    IEnumerator TurnOffPicture()
    {
        yield return new WaitForSeconds(5f);
        LoverPicture_Image_W.SetActive(false); // UI�� �����̹��� ũ�� �����ֱ�
    }

    public void OnPushOrPress()
    {
        LoverPicture_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        LoverPicture_W.IsPushOrPress = false;
    }
    public void OnSniff()
    {
        LoverPicture_W.IsSniff = true;
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
