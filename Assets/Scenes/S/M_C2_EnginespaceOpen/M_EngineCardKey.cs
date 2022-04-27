using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_EngineCardKey : MonoBehaviour, IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_DestroyPack;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_EngineCardKey, sniffButton_M_EngineCardKey, 
        biteButton_M_EngineCardKey, pressButton_M_EngineCardKey, noCenterButton_M_EngineCardKey;

    ObjData engineCardKeyData_M;

    void Start()
    {
        engineCardKeyData_M = GetComponent<ObjData>();


        barkButton_M_EngineCardKey = engineCardKeyData_M.BarkButton;
        barkButton_M_EngineCardKey.onClick.AddListener(OnBark);

        sniffButton_M_EngineCardKey = engineCardKeyData_M.SniffButton;
        sniffButton_M_EngineCardKey.onClick.AddListener(OnSniff);

        biteButton_M_EngineCardKey = engineCardKeyData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_EngineCardKey = engineCardKeyData_M.PushOrPressButton;
        pressButton_M_EngineCardKey.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_EngineCardKey = engineCardKeyData_M.CenterButton1;
    }

    void Update()
    {
/*        if (GameManager.gameManager._gameData.IsDestroyPack_M_C2 == true)
        {
            gameObject.SetActive(true);
            this.transform.position = M_DestroyPack.transform.position;
        }*/
    }

    void DisableButton()
    {
        barkButton_M_EngineCardKey.transform.gameObject.SetActive(false);
        sniffButton_M_EngineCardKey.transform.gameObject.SetActive(false);
        biteButton_M_EngineCardKey.transform.gameObject.SetActive(false);
        pressButton_M_EngineCardKey.transform.gameObject.SetActive(false);
        noCenterButton_M_EngineCardKey.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        engineCardKeyData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        engineCardKeyData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        engineCardKeyData_M.IsPushOrPress = false;
    }


    public void OnSniff()
    {
        engineCardKeyData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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

    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

}
