using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_Boxes: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton_M_Box;

    ObjData Boxes_E;

    public Animator BoxDestroyAnimation; // �ڽ� �������� �ִϸ��̼�


    void Start()
    {
        Boxes_E = GetComponent<ObjData>();


        barkButton = Boxes_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Boxes_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Boxes_E.BiteButton;
        biteButton.onClick.AddListener(OnBite); // "����"�� �ȵǴ� ������Ʈ

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = Boxes_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        NoCenterButton_M_Box = Boxes_E.CenterButton1;
    }

    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton_M_Box.transform.gameObject.SetActive(false);
    }

    void Update()
    {
    }


    public void OnBark()
    {
        Boxes_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }
    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }
    public void OnSniff()
    {
        Boxes_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        Boxes_E.IsPushOrPress = true;
        DiableButton();
        // �Ӹ��� ������ �ִϸ��̼�  
        InteractionButtonController.interactionButtonController.playerPressHead(); 
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        Invoke("DestroyBoxAnim", 1f); // 1�� �� �ڽ� �������� �ִϸ��̼� ����
        Invoke("DestroyBox", 2f); // 2�� �� �ڽ� ������Ʈ ��Ȱ��ȭ
        GameManager.gameManager._gameData.IsNoBoxes = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Boxes_E.IsPushOrPress = false;
    }

    void DestroyBoxAnim() // �ڽ� �������� �ִϸ��̼�
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // �ڽ� ������Ʈ ��Ȱ��ȭ
    {
        Boxes_E.gameObject.SetActive(false);
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
    }
}
