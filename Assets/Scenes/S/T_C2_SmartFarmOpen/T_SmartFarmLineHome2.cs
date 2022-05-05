using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_SmartFarmLineHome2 : MonoBehaviour, IInteraction
{
    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_SmartFarmLineHome2, sniffButton_T_SmartFarmLineHome2, biteButton_T_SmartFarmLineHome2,
        pressButton_T_SmartFarmLineHome2, noCenterButton_T_SmartFarmLineHome2;

    ObjData smartFarmLineHome2Data_T;
    Outline smartFarmLineHomeOutline_T;

    /*�����ִ� ������Ʈ*/
    public GameObject T_canFixedLine2;
    public ObjectData canFixedLine2Data_T;
    Outline canFixedLine2Outline_T;


    void Start()
    {
        smartFarmLineHome2Data_T = GetComponent<ObjData>();

        smartFarmLineHomeOutline_T = GetComponent<Outline>();
        canFixedLine2Outline_T = T_canFixedLine2.GetComponent<Outline>();


        barkButton_T_SmartFarmLineHome2 = smartFarmLineHome2Data_T.BarkButton;
        barkButton_T_SmartFarmLineHome2.onClick.AddListener(OnBark);

        sniffButton_T_SmartFarmLineHome2 = smartFarmLineHome2Data_T.SniffButton;
        sniffButton_T_SmartFarmLineHome2.onClick.AddListener(OnSniff);

        biteButton_T_SmartFarmLineHome2 = smartFarmLineHome2Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_SmartFarmLineHome2 = smartFarmLineHome2Data_T.PushOrPressButton;
        pressButton_T_SmartFarmLineHome2.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_SmartFarmLineHome2 = smartFarmLineHome2Data_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_SmartFarmLineHome2.transform.gameObject.SetActive(false);
        sniffButton_T_SmartFarmLineHome2.transform.gameObject.SetActive(false);
        biteButton_T_SmartFarmLineHome2.transform.gameObject.SetActive(false);
        pressButton_T_SmartFarmLineHome2.transform.gameObject.SetActive(false);
        noCenterButton_T_SmartFarmLineHome2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        if(canFixedLine2Data_T.IsBite)
        {
            //�θ𿡼� ����
            canFixedLine2Data_T.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            canFixedLine2Data_T.transform.parent = null;

            //������ ���� ��迡 �ڵ� ����
            canFixedLine2Data_T.transform.position = new Vector3(-258.06f, 539.122f, 670.358f); //��ġ ��
            canFixedLine2Data_T.transform.rotation = Quaternion.Euler(0, -90, 90); // ���� �� 

            canFixedLine2Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            canFixedLine2Outline_T.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            smartFarmLineHome2Data_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            smartFarmLineHomeOutline_T.OutlineWidth = 0; // �ƿ����ε� ���ݴϴ�.

            Invoke("CameraBye", 1f);
        }
    }

    void CameraBye()
    {
        CameraController.cameraController.CancelObserve();
        GameManager.gameManager._gameData.IsSmartFarmFix_T_C2 = true;
    }

    public void OnSmash()
    {
       
    }

    public void OnUp()
    {
        
    }

    public void OnBite()
    {

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

}
