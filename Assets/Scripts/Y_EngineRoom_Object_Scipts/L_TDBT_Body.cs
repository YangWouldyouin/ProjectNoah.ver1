using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_TDBT_Body : MonoBehaviour, IInteraction
{
    private Button barkButton_L_TDBT_Body, sniffButton_L_TDBT_Body, biteButton_L_TDBT_Body, pushButton_L_TDBT_Body, noCenterButton_L_TDBT_Body;

    ObjData TDBT_BodyData_L;

    public GameObject TDBT_fixPart;

    ObjData TDBT_fixPartData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD:Assets/Scripts/ì •ë¦¬ë/L_TDBT_Body.cs

        playerEquipment = BaseCanvas._baseCanvas.equipment;

        TDBT_BodyData_L = GetComponent<ObjData>();
=======
        //L_1

        TDBT_BodyData_L = GetComponent<ObjData>();
        TDBT_fixPartData = TDBT_fixPart.GetComponent<ObjData>();
>>>>>>> 0cd04973dc88b96e2fae14629155ea058b5be739:Assets/Scripts/Y_EngineRoom_Object_Scipts/L_TDBT_Body.cs

        TDBT_BodyOutline = GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();
        /* ObjData ·ÎºÎÅÍ »óÈ£ÀÛ¿ë ¹öÆ°À» °¡Á®¿Â´Ù. */
        barkButton_L_TDBT_Body = TDBT_BodyData_L.BarkButton;

        barkButton_L_TDBT_Body.onClick.AddListener(OnBark);

        sniffButton_L_TDBT_Body = TDBT_BodyData_L.SniffButton;
        sniffButton_L_TDBT_Body.onClick.AddListener(OnSniff);

        biteButton_L_TDBT_Body = TDBT_BodyData_L.BiteButton;
        biteButton_L_TDBT_Body.onClick.AddListener(OnBite);

        pushButton_L_TDBT_Body = TDBT_BodyData_L.PushOrPressButton;
        pushButton_L_TDBT_Body.onClick.AddListener(OnPushOrPress);

        noCenterButton_L_TDBT_Body = TDBT_BodyData_L.CenterButton1;
    }

    void DiableButton()
    {
        // ºñÈ°¼ºÈ­ ¹öÆ°±îÁö Æ÷ÇÔÇÏ¿© À§¿¡¼­ ¸¸µç ¸ðµç ¹öÆ° º¯¼ö¸¦ ²ö´Ù.

        // ex. ´©¸£±â ¹öÆ°, °¡¿îµ¥ ¹öÆ°ÀÌ ¿À¸£±â ¹öÆ°ÀÎµ¥ Ã³À½¿¡ ºñÈ°¼ºÈ­
        barkButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        sniffButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        biteButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        pushButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        noCenterButton_L_TDBT_Body.transform.gameObject.SetActive(false);
    }

    /* 2ÃÊ µÚ¿¡ ´©¸£±â º¯¼ö¸¦ false ·Î ¹Ù²Ù´Â ÄÚ·çÆ¾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        TDBT_BodyData_L.IsPushOrPress = false;
    }

    public void OnBark()
    {
        TDBT_BodyData_L.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        TDBT_BodyData_L.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());


        if (TDBT_fixPartData.IsBite) // ºÎÇ°À» ¹°¾úÀ¸¸é
        {
            Invoke("TrashDoorButtonDone", 1.5f);
        }
    }

    public void TrashDoorButtonDone()
    {
        TDBT_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        TDBT_fixPartData.transform.parent = null;

        TDBT_fixPartData.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
        TDBT_fixPartData.transform.rotation = Quaternion.Euler(0, -90, 0);
        TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

        //TDBT_fixPartData.enabled = false;
        //TDBT_BodyData_L.enabled = false;

        TDBT_fixPartData.IsNotInteractable = true;
        TDBT_BodyData_L.IsNotInteractable = true;
        TDBT_BodyOutline.OutlineWidth = 0;
        TDBT_fixPartOutline.OutlineWidth = 0;


        GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        TDBT_BodyData_L.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
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

    public void OnBite()
    {
        /* »óÈ£ÀÛ¿ë ¹öÆ°À» ²û */
        DiableButton();
        /*  ¹°±â¸¸ ÇÏ´Â ¾Ö´Ï¸ÞÀÌ¼Ç & ¹° ¼ö ¾ø´Â ¿ÀºêÁ§Æ®ÀÓÀ» ¾Ë¸² */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}
