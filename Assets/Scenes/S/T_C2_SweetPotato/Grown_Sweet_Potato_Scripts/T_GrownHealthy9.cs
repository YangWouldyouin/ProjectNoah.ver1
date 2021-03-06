using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_GrownHealthy9 : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_GrownHealthy9, sniffButton_T_GrownHealthy9, biteButton_T_GrownHealthy9,
        pressButton_T_GrownHealthy9, eatButton_T_GrownHealthy9; // eatDisableButton_T_HealthySweetPotato1;


    /*ObjData*/
    ObjData GrownHealthy9Data_T;

    PortableObjectData portableData; // 이후 워크룸에서 안보이게 하기 위해

    void Start()
    {
        /*ObjData*/
        GrownHealthy9Data_T = GetComponent<ObjData>();

        barkButton_T_GrownHealthy9 = GrownHealthy9Data_T.BarkButton;
        barkButton_T_GrownHealthy9.onClick.AddListener(OnBark);

        sniffButton_T_GrownHealthy9 = GrownHealthy9Data_T.SniffButton;
        sniffButton_T_GrownHealthy9.onClick.AddListener(OnSniff);

        biteButton_T_GrownHealthy9 = GrownHealthy9Data_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_GrownHealthy9 = GrownHealthy9Data_T.PushOrPressButton;
        pressButton_T_GrownHealthy9.onClick.AddListener(OnPushOrPress);

        eatButton_T_GrownHealthy9 = GrownHealthy9Data_T.CenterButton1;
        eatButton_T_GrownHealthy9.onClick.AddListener(OnEat);

        //eatDisableButton_T_HealthySweetPotato1 = HealthySweetPotato1Data_T.CenterDisableButton1;
    }

    void DisableButton()
    {
        barkButton_T_GrownHealthy9.transform.gameObject.SetActive(false);
        sniffButton_T_GrownHealthy9.transform.gameObject.SetActive(false);
        biteButton_T_GrownHealthy9.transform.gameObject.SetActive(false);
        pressButton_T_GrownHealthy9.transform.gameObject.SetActive(false);
        eatButton_T_GrownHealthy9.transform.gameObject.SetActive(false);
        //eatDisableButton_T_HealthySweetPotato1.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        //GrownHealthy9Data_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnEat()
    {
        //GrownHealthy9Data_T.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();

        // 스탯 올라가게??
        //스탯 상승
        NoahStatController.noahStatController.IncreaseStat(1);

        portableData.IsObjectActiveList[17] = false;

        GameManager.gameManager._gameData.sweetPotatoEat[10] = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        //GrownHealthy9Data_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        //GrownHealthy9Data_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        //StartCoroutine(ChangePressFalse());
    }


/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        GrownHealthy9Data_T.IsPushOrPress = false;
    }*/

    public void OnBite()
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
        
    }
}
