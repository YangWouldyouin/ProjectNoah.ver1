using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert01_buttons : MonoBehaviour, IInteraction
{
    public GameObject drug;
    ObjData drugData;
    Outline drugLine;

    public GameObject machine;
    ObjData machineData;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Insert01Data;
    Outline Insert01Line;

    public GameObject LED;
    Renderer LEDColor;

    void Start()
    {
        Insert01Data = GetComponent<ObjData>();
        Insert01Line = GetComponent<Outline>();

        machineData = machine.GetComponent<ObjData>();

        drugData = drug.GetComponent<ObjData>();
        drugLine = drug.GetComponent<Outline>();

        //버튼
        barkButton = Insert01Data.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Insert01Data.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Insert01Data.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Insert01Data.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Insert01Data.CenterButton1;

        LEDColor = LED.GetComponent<Renderer>();
                                           
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
        Insert01Data.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Insert01Data.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Insert01Data.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (drugData.IsBite)
        {
            LEDColor.material.color = Color.red; //검사 결과 색상 변환
            
            GameManager.gameManager._gameData.IsCheckDrug = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            Invoke("NoDrug", 0.5f);
        }

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Insert01Data.IsPushOrPress = false;
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

    void NoDrug()
    {
        Debug.Log("약물없어");
        
        drugData.IsBite = false;

        drugData.GetComponent<Rigidbody>().isKinematic = false;
        drugData.transform.parent = null;

        drug.transform.position = new Vector3(-249.0776f, 538.895f, 669.806f);
        drug.transform.rotation = Quaternion.Euler(0, 0, 90);
        drug.transform.localScale = new Vector3(1f, 1f, 1f);

        Insert01Data.IsNotInteractable = true;
        Insert01Line.OutlineWidth = 0f;

        drugData.IsNotInteractable = true;
        drugLine.OutlineWidth = 0f;
    }
}
