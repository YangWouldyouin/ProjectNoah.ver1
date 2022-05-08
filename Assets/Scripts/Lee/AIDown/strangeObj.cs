using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class strangeObj : MonoBehaviour, IInteraction
{
    
    private Button barkButton, sniffButton, biteButton, pressButton, smashButton, noCenterButton;

    public ObjectData strangeData;
    ObjData objData;

    public ParticleSystem smoke;
    public Outline playerLine;

    public GameObject dialog;
    DialogManager dialogManager;

    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        objData = GetComponent<ObjData>();

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
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();
    }

    public void OnSniff()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        GameManager.gameManager._gameData.IsFindStrangeObj = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");


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
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        Invoke("ObjSmoke", 2f);

        InteractionButtonController.interactionButtonController.PlayerSmash2();

        GameManager.gameManager._gameData.IsKnowUsingSObj = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        //��ư� ������ �ʾ� ��Ȳ�ϴ� AI ���
    }

    void ObjSmoke()
    {
        playerLine.OutlineWidth = 10f;

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        strangeData.IsBite = false;

        smoke.transform.localScale = new Vector3(1f, 1f, 1f);
        smoke.transform.position = gameObject.transform.position;
        smoke.Play();

        GameManager.gameManager._gameData.IsHide = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        gameObject.SetActive(false);
        Destroy(smoke, 3f);

        Invoke("CantHide", 180f);

        if (!GameManager.gameManager._gameData.IsFirstUseStrangeObj)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(51));
            GameManager.gameManager._gameData.IsAIVSMissionCount += 1;
            GameManager.gameManager._gameData.IsFirstUseStrangeObj = true;

            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        if (GameManager.gameManager._gameData.IsFirstUseStrangeObj)
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(53));
        }
    }

    void CantHide()
    {
        Debug.Log("이제 못 숨음");

        playerLine.OutlineWidth = 0f;

        GameManager.gameManager._gameData.IsHide = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        Destroy(gameObject, 0.5f);

        dialogManager.StartCoroutine(dialogManager.PrintAIDialog(52));
    }
}
