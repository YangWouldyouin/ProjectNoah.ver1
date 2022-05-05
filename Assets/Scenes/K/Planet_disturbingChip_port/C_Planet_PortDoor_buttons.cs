using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_Planet_PortDoor_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Planet_PortDoorData_C;
    Outline Planet_PortDoorLine_C;

    public GameObject Insert_PChip_C;
    ObjData Insert_PChipData_C;
    Outline Insert_PChipLine_C;

    void Start()
    {
        Planet_PortDoorData_C = GetComponent<ObjData>();
        Planet_PortDoorLine_C = GetComponent<Outline>();

        Insert_PChipData_C = Insert_PChip_C.GetComponent<ObjData>();
        Insert_PChipLine_C = Insert_PChip_C.GetComponent<Outline>();


        barkButton = Planet_PortDoorData_C.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Planet_PortDoorData_C.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Planet_PortDoorData_C.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        //smashButton = portDoorData.SmashButton;
        //smashButton.onClick.AddListener(OnSmash);

        pressButton = Planet_PortDoorData_C.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Planet_PortDoorData_C.CenterButton1;

    }
    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        //smashButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        Planet_PortDoorData_C.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Planet_PortDoorData_C.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Planet_PortDoorData_C.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        Planet_PortDoorData_C.transform.localRotation = Quaternion.Euler(-10f, 90f, 90f);

        Planet_PortDoorData_C.IsNotInteractable = true;
        Planet_PortDoorLine_C.OutlineWidth = 0f;

        Insert_PChipData_C.IsNotInteractable = false;
        Insert_PChipLine_C.OutlineWidth = 8f;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Planet_PortDoorData_C.IsPushOrPress = false;
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        /*if (GameManager.gameManager._gameData.IsAlert)
        {
            Debug.Log("�� �ɷȴ�");
            GameManager.gameManager._gameData.IsAlert = false;

            Destroy(gameObject, 5f);
        }*/

        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        /*portDoorData.IsSmash = true;
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        Invoke();

        InteractionButtonController.interactionButtonController.PlayerSmash2();
        */
    }

}
