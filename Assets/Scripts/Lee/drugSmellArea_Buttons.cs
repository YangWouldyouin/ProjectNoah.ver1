using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugSmellArea_Buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton;

    ObjData drugSmellAreaData;

    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        drugSmellAreaData = GetComponent<ObjData>();

        barkButton = drugSmellAreaData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugSmellAreaData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugSmellAreaData.BiteDestroyButton;
        biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = drugSmellAreaData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

    }

    // Update is called once per frame

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        drugSmellAreaData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        drugSmellAreaData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        drugSmellAreaData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        drugSmellAreaData.IsPushOrPress = false;
    }

    public void OnBiteDestroy()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerBite();
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
}
