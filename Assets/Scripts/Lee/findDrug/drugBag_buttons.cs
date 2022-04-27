using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugBag_buttons : MonoBehaviour, IInteraction
{
    public GameObject drug;
    ObjData drugData;
    //Outline drugLine;

    public GameObject drugSmellArea;
    public GameObject smellCheckArea;

    private Button barkButton, sniffButton, biteButton, smashButton, pressButton, noCenterButton;

    ObjData drugBagData;

    void Start()
    {
        //������Ʈ
        drugBagData = GetComponent<ObjData>();

        drugData = GetComponent<ObjData>();
        //drugLine = GetComponent<Outline>();

        //��ư
        barkButton = drugBagData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugBagData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugBagData.BiteButton;
        //biteButton.onClick.AddListener(OnBite);

        smashButton = drugBagData.SmashButton;
        smashButton.onClick.AddListener(OnSmash);

        pressButton = drugBagData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = drugBagData.CenterButton1;
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
        drugBagData.IsBark = true;
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
        drugBagData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        drugBagData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        drugBagData.IsSniff = true;
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
        drugBagData.IsSmash = true;
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

        drugBagData.GetComponent<Rigidbody>().isKinematic = true;
        drugBagData.transform.parent = null;

        drugBagData.IsBite = false;

        //gameObject.SetActive(false);
        drug.SetActive(true);

        drug.transform.position = gameObject.transform.position;

        Destroy(drugSmellArea, 0f);
        Destroy(smellCheckArea, 0f);
        Destroy(gameObject, 0.5f);
    }
}
