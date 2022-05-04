using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeObj : MonoBehaviour, IInteraction
{
    
    private Button barkButton, sniffButton, biteButton, pressButton, smashButton, noCenterButton;

    ObjData objData;

    public ParticleSystem smoke;

    public GameObject player;
    Outline playerLine;

    void Start()
    {
        objData = GetComponent<ObjData>();

        playerLine = player.GetComponent<Outline>();

        barkButton = objData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = objData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = objData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        pressButton = objData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        smashButton = objData.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        noCenterButton = objData.CenterButton1;
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
        smashButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        objData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
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

    public void OnPushOrPress()
    {
        objData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        objData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        objData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        //����Ʈ ��ư�� ��ũ��Ʈ �ֱ�
    }

    public void OnSmash()
    {
        objData.IsSmash = true;
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        Invoke("ObjSmoke", 2f);

        InteractionButtonController.interactionButtonController.PlayerSmash2();

        //��ư� ������ �ʾ� ��Ȳ�ϴ� AI ���
    }

    void ObjSmoke()
    {
        playerLine.OutlineWidth = 10f;

        objData.GetComponent<Rigidbody>().isKinematic = true;
        objData.transform.parent = null;

        objData.IsBite = false;

        smoke.transform.localScale = new Vector3(1f, 1f, 1f);
        smoke.transform.position = gameObject.transform.position;
        smoke.Play();

        GameManager.gameManager._gameData.IsHide = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        gameObject.SetActive(false);
        Destroy(smoke, 3f);

        Invoke("CantHide", 5f);
    }

    void CantHide()
    {
        Debug.Log("이제 못 숨음");

        playerLine.OutlineWidth = 0f;

        GameManager.gameManager._gameData.IsHide = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        Destroy(gameObject, 0.5f);
    }
}
