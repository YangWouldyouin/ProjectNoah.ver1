using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugBag_buttons : MonoBehaviour, IInteraction
{
    public ObjectData drugBagData, drugData;
    ObjData drugBagObjData;

    public GameObject drug;
    //Outline drugLine;

    public GameObject drugSmellArea;
    public GameObject smellCheckArea;

    private Button barkButton, sniffButton, biteButton, smashButton, pressButton, noCenterButton;


    void Start()
    {
        //������Ʈ
        drugBagObjData = GetComponent<ObjData>();

        //drugLine = GetComponent<Outline>();

        //��ư
        barkButton = drugBagObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugBagObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugBagObjData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        smashButton = drugBagObjData.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pressButton = drugBagObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = drugBagObjData.CenterButton1;
    }

    void update()
    {

    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        smashButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
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
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        /*
        //BiteButton�� ��ũ��Ʈ �ֱ�
        drugData.GetComponent<Rigidbody>().isKinematic = true;
        drugData.transform.parent = gameObject.transform;

        CancelInvoke("followDrug");

        if (drugBagData.IsSmash)
        {
            Invoke("noBag", 1.5f);
        }*/
    }

    public void OnSmash()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();
        
        Invoke("NoBag", 2f);

        InteractionButtonController.interactionButtonController.PlayerSmash2();
    }

    /*void cantSmell() //�����ñ� ���� ��Ȱ��ȭ
    {
        MeshCollider meshcollider = drugSmellArea.GetComponent<MeshCollider>();
        meshcollider.enabled = false;
    }*/

    void NoBag()
    {
        MeshCollider meshcollider = drugSmellArea.GetComponent<MeshCollider>();
        meshcollider.enabled = false;

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        drugBagData.IsBite = false;

        //gameObject.SetActive(false);
        drug.SetActive(true);

        drug.transform.position = gameObject.transform.position;

        Destroy(drugSmellArea, 0f);
        Destroy(smellCheckArea, 0f);
        Destroy(gameObject, 0.5f);
    }
}
