using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class T_IronPlateDoor : MonoBehaviour, IInteraction
{
    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_IronPlateDoor, sniffButton_T_IronPlateDoor, biteButton_T_IronPlateDoor,
        pressButton_T_IronPlateDoor, noCenterButton_T_IronPlateDoor;

    ObjData ironPlateDoorData_T;
    public ObjectData IronPlateDoorData_T;

     public  Outline DoIronPlateDoorOutline_T;

    BoxCollider ironPlateCollider_T;


    void Start()
    {
       
        ironPlateCollider_T = GetComponent<BoxCollider>();

        ironPlateDoorData_T = GetComponent<ObjData>();


        barkButton_T_IronPlateDoor = ironPlateDoorData_T.BarkButton;
        barkButton_T_IronPlateDoor.onClick.AddListener(OnBark);

        sniffButton_T_IronPlateDoor = ironPlateDoorData_T.SniffButton;
        sniffButton_T_IronPlateDoor.onClick.AddListener(OnSniff);

        biteButton_T_IronPlateDoor = ironPlateDoorData_T.BiteButton;
        biteButton_T_IronPlateDoor.onClick.AddListener(OnBite);

        pressButton_T_IronPlateDoor = ironPlateDoorData_T.PushOrPressButton;
        pressButton_T_IronPlateDoor.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_IronPlateDoor = ironPlateDoorData_T.CenterButton1;

        /*�������*/
        IronPlateDoorData_T.IsNotInteractable = true;
    }

    void DisableButton()
    {
        barkButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        sniffButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        biteButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        pressButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
        noCenterButton_T_IronPlateDoor.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        Invoke("IronPlateOpen", 1.7f);

    }

    void IronPlateOpen()
    {
        IronPlateDoorData_T.IsBite = false;

        // �θ� �ڽ� ���踦 �����Ѵ�.
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.parent = null;

        // �ش� ��ġ, ����, ũ��� �ٲٰڴ�.
        gameObject.transform.position = new Vector3(-258.15f, 0.2092f, 670.1605f); //��ġ ����
        gameObject.transform.rotation = Quaternion.Euler(7.034f, 90, 90); //���� ����
        gameObject.transform.localScale = new Vector3(-2.882732f, -115.34f, -93.69196f); // ũ�� ����

        // ���� �� �̻� ��ȣ�ۿ� �Ұ�
        IronPlateDoorData_T.IsNotInteractable = true;
        DoIronPlateDoorOutline_T.OutlineWidth = 0;

        //�ݶ��̴��� ����.
        ironPlateCollider_T.enabled = false;
        GameManager.gameManager._gameData.IsIronDisappear_T_C2 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnSmash()
    {
       
    }

    public void OnBite()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
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

    public void OnUp()
    {
      
    }
}
