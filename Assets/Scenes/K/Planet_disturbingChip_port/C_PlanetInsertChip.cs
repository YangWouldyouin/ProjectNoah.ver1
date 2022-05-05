using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetInsertChip : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData InsertChipData_C;
    Outline InsertDataLine_C;

    /* 상호작용 오브젝트 */
    public GameObject Right_Chip_C;
    ObjData Right_ChipData_C;
    Outline Right_ChipLine_C;

    public GameObject Wrong_Chip_C;
    ObjData Wrong_ChipData_C;
    Outline Wrong_ChipLine_C;

    void Start()
    {
        InsertChipData_C = GetComponent<ObjData>();
        InsertDataLine_C = GetComponent<Outline>();

        Right_ChipData_C = Right_Chip_C.GetComponent<ObjData>();
        Right_ChipLine_C = Right_Chip_C.GetComponent<Outline>();

        Wrong_ChipData_C = Wrong_Chip_C.GetComponent<ObjData>();
        Wrong_ChipLine_C = Wrong_Chip_C.GetComponent<Outline>();


        barkButton = InsertChipData_C.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = InsertChipData_C.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = InsertChipData_C.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = InsertChipData_C.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = InsertChipData_C.CenterButton1;
        noCenterButton.onClick.AddListener(OnObserve);
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        InsertChipData_C.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        InsertChipData_C.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        InsertChipData_C.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (Right_ChipData_C.IsBite) // 진짜 교란칩 넣었을 때
        {
            Debug.Log("행성데이터 교란성공");

            GameManager.gameManager._gameData.IsPlanetInsertChip_In = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        if (Wrong_ChipData_C.IsBite) // 가짜 교란칩 넣었을 떄
        {
            Debug.Log("행성데이터 교란실패");
            GameManager.gameManager._gameData.IsPlanetInsertChip_In = false;
        }

        StartCoroutine(ChangePressFalse());
    }
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        InsertChipData_C.IsPushOrPress = false;
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
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

}
