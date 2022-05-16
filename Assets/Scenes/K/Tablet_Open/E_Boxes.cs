using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_Boxes: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton_M_Box;

    ObjData BoxesData_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;

    //public GameObject TabletOutli_E;
    //ObjData TabletOutlineData_E;

    public Animator BoxDestroyAnimation; // �ڽ� �������� �ִϸ��̼�

    /* �Ҹ� */
    AudioSource Box_Collapse_Sound;
    public AudioClip Box_Collapse; // ����� �ҽ�

    void Start()
    {
        Box_Collapse_Sound = GetComponent<AudioSource>(); 

        BoxesData_E = GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        // TabletOutlineData_E = Tablet_E.GetComponent<Outline>();

        // Tablet_E.SetActive(false);

        barkButton = BoxesData_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = BoxesData_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = BoxesData_E.BiteButton;
        biteButton.onClick.AddListener(OnBite); // "����"�� �ȵǴ� ������Ʈ

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = BoxesData_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        NoCenterButton_M_Box = BoxesData_E.CenterButton1;

        GameManager.gameManager._gameData.IsNoBoxes = false; // ó���� ���� ����
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
        BoxesData_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }
    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }
    public void OnSniff()
    {
        BoxesData_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    /* ���������������������������������������� ���� �� ���������������������������������������� */
    public void OnPushOrPress()
    {
        BoxesData_E.IsPushOrPress = true;
        DiableButton();
        // �Ӹ��� ������ �ִϸ��̼�  
        InteractionButtonController.interactionButtonController.playerPressHead(); 
        StartCoroutine(ChangePressFalse()); // 2�� �ڿ� IsPushOrPress �� false �� �ٲ�

        Invoke("DestroyBoxAnim", 1f); // 1�� �� �ڽ� �������� �ִϸ��̼� ����
        Box_Collapse_Sound.Play();
        Invoke("DestroyBox", 2f); // 2�� �� �ڽ� ������Ʈ ��Ȱ��ȭ
        GameManager.gameManager._gameData.IsNoBoxes = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    /* 2�� �ڿ� ������ ������ false �� �ٲٴ� �ڷ�ƾ */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        BoxesData_E.IsPushOrPress = false;
    }

    void DestroyBoxAnim() // �ڽ� �������� �ִϸ��̼�
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // �ڽ� ������Ʈ ��Ȱ��ȭ
    {
        BoxesData_E.gameObject.SetActive(false);
    }

/*    void FindTablet()
    {

    }*/

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
