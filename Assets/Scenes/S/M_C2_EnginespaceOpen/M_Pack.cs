using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pack : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_canCardKey;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Pack, sniffButton_M_Pack, 
        biteButton_M_Pack, pressButton_M_Pack, noCenterButton_M_Pack, smashButton_M_Pack;

    ObjData packData_M;

    void Start()
    {
        packData_M = GetComponent<ObjData>();


        barkButton_M_Pack = packData_M.BarkButton;
        barkButton_M_Pack.onClick.AddListener(OnBark);

        sniffButton_M_Pack = packData_M.SniffButton;
        sniffButton_M_Pack.onClick.AddListener(OnSniff);

        biteButton_M_Pack = packData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Pack = packData_M.PushOrPressButton;
        pressButton_M_Pack.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Pack = packData_M.CenterButton1;

        smashButton_M_Pack = packData_M.SmashButton;
        smashButton_M_Pack.onClick.AddListener(OnSmash);
    }

    void DisableButton()
    {
        barkButton_M_Pack.transform.gameObject.SetActive(false);
        sniffButton_M_Pack.transform.gameObject.SetActive(false);
        biteButton_M_Pack.transform.gameObject.SetActive(false);
        pressButton_M_Pack.transform.gameObject.SetActive(false);
        smashButton_M_Pack.transform.gameObject.SetActive(false);
        noCenterButton_M_Pack.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        packData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        packData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        packData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        packData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnSmash()
    {
        packData_M.IsSmash = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        StartCoroutine(canLookCardKey1());
        //StartCoroutine(canLookCardKey2());

        //Invoke(" canLookCardKey", 2f); // �κ�ũ �Լ� �� �� �� ��...

        /* ������Ʈ ���� �ִϸ��̼� ���� */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

    }

    IEnumerator canLookCardKey1()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject, 0f);

        packData_M.GetComponent<Rigidbody>().isKinematic = true;
        packData_M.transform.parent = null;

        //��ġ ����: ������ �� ��ġ ���� ī��Ű ��ġ �����ϱ� ī��Ű�� ���� �ξ��ϱ� ������
        gameObject.transform.position = new Vector3(transform.position.x, 539.951f, transform.position.z); 

        packData_M.IsBite = false;

        M_canCardKey.SetActive(true);
        M_canCardKey.transform.position = gameObject.transform.position;

    }


/*    IEnumerator canLookCardKey2()
    {
        yield return new WaitForSeconds(3f);

        M_canCardKey.SetActive(true);
        M_canCardKey.transform.position = gameObject.transform.position;
    }*/

/*    void canLookCardKey()
    {
        M_canCardKey.SetActive(true);
        M_canCardKey.transform.position = gameObject.transform.position;
        GameManager.gameManager._gameData.IsDestroyPack_M_C2 = true;   

    }*/

    public void OnUp()
    {
        
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

}
