using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteoritesStorage1 : MonoBehaviour, IInteraction
{

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MeteoritesStorage1, sniffButton_M_MeteoritesStorage1, biteButton_M_MeteoritesStorage1, pressButton_M_MeteoritesStorage1;

    ObjData meteoritesStorage1Data_M;

    // Start is called before the first frame update
    void Start()
    {
        meteoritesStorage1Data_M = GetComponent<ObjData>();


        barkButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.BarkButton;
        barkButton_M_MeteoritesStorage1.onClick.AddListener(OnBark);

        sniffButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.SniffButton;
        sniffButton_M_MeteoritesStorage1.onClick.AddListener(OnSniff);

        biteButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.BiteButton;
        biteButton_M_MeteoritesStorage1.onClick.AddListener(OnBiteDestroy);
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteoritesStorage1 = meteoritesStorage1Data_M.PushOrPressButton;
        pressButton_M_MeteoritesStorage1.onClick.AddListener(OnPushOrPress);
    }

    void DisableButton()
    {
        barkButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        sniffButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        biteButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
        pressButton_M_MeteoritesStorage1.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        meteoritesStorage1Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
        meteoritesStorage1Data_M.IsBite = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();
    }


    public void OnPushOrPress()
    {
        meteoritesStorage1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        meteoritesStorage1Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        meteoritesStorage1Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnUp()
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

    void IInteraction.OnBite()
    {
        throw new System.NotImplementedException();
    }


    void IInteraction.OnSmash()
    {
        throw new System.NotImplementedException();
    }
}
