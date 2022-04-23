using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert02_buttons : MonoBehaviour, IInteraction
{
    public GameObject SDrug;
    ObjData SDrugData;
    Outline SDrugLine;

    public GameObject machine;
    ObjData machineData;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Insert02Data;
    Outline Insert02Line;

    public GameObject D_LED;
    Renderer D_LEDColor;

    void Start()
    {
        Insert02Data = GetComponent<ObjData>();
        Insert02Line = GetComponent<Outline>();

        machineData = machine.GetComponent<ObjData>();

        SDrugData = SDrug.GetComponent<ObjData>();
        SDrugLine = SDrug.GetComponent<Outline>();

        //버튼
        barkButton = Insert02Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Insert02Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Insert02Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Insert02Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Insert02Data.CenterButton1;

        D_LEDColor = D_LED.GetComponent<Renderer>();

    }

    // Update is called once per frame

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
        Insert02Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Insert02Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Insert02Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (SDrugData.IsBite)
        {
            D_LEDColor.material.color = Color.blue; //검사 결과 색상 변환

            GameManager.gameManager._gameData.IsDetox = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Invoke("NoSDrug", 0.5f);
        }

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Insert02Data.IsPushOrPress = false;
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

    void NoSDrug() //특정 약물 사라지게 하기
    {
        Debug.Log("특별한 약물 없어");
        
        SDrugData.IsBite = false;

        SDrugData.GetComponent<Rigidbody>().isKinematic = false;
        SDrugData.transform.parent = null;

        SDrug.transform.position = new Vector3(-249.0776f, 538.575f, 669.806f);
        SDrug.transform.rotation = Quaternion.Euler(0, 0, 90);

        SDrugData.IsNotInteractable = false;
        SDrugLine.OutlineWidth = 0;

        Insert02Data.IsNotInteractable = false;
        Insert02Line.OutlineWidth = 0;
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
