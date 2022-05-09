using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachineButton : MonoBehaviour, IInteraction
{
    public bool IsSmellDone_T = false; // � ������ �þҴ���

    /*�����ִ� ������Ʈ*/
    public GameObject T_AreNormalMeteor1;
    public GameObject T_AreImportantMeteor;
    public GameObject T_AreAnalyticalMachine;
    public GameObject T_IsAnalyticalMachinePlate;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_AnalyticalMachineButton, sniffButton_T_AnalyticalMachineButton, biteButton_T_AnalyticalMachineButton,
        pressButton_T_AnalyticalMachineButton, noCenterButton_T_AnalyticalMachineButton;


    /*ObjData*/
    ObjData analyticalMachineButtonObjData_T;
    public ObjectData analyticalMachineButtonData_T;

    public ObjectData areNormalMeteor1Data_T;
    public ObjectData areimportantMeteorData_T;
    public ObjectData areAnalyticalMachineData_T;


    /*Outline*/
    Outline analyticalMachineButtonOutline_T;
    Outline areAnalyticalMachineOutline_T;
    Outline areNormalMeteor1Outline_T;
    Outline areimportantMeteorOutline_T;

    /*Animator*/
    public Animator analyticalMachineAnim_T;

    /*Collider*/
    BoxCollider AreAnalyticalMachine_Collider;
    BoxCollider IsAnalyticalMachinePlate_Collider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        AreAnalyticalMachine_Collider = T_AreAnalyticalMachine.GetComponent<BoxCollider>();
        IsAnalyticalMachinePlate_Collider = T_IsAnalyticalMachinePlate.GetComponent<BoxCollider>();

        /*ObjData*/
        analyticalMachineButtonObjData_T = GetComponent<ObjData>();

        /*Outline*/
        analyticalMachineButtonOutline_T = GetComponent<Outline>();
        areAnalyticalMachineOutline_T = T_AreAnalyticalMachine.GetComponent<Outline>();
        areNormalMeteor1Outline_T = T_AreNormalMeteor1.GetComponent<Outline>();
        areimportantMeteorOutline_T = T_AreImportantMeteor.GetComponent<Outline>();


        barkButton_T_AnalyticalMachineButton = analyticalMachineButtonObjData_T.BarkButton;
        barkButton_T_AnalyticalMachineButton.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachineButton = analyticalMachineButtonObjData_T.SniffButton;
        sniffButton_T_AnalyticalMachineButton.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachineButton = analyticalMachineButtonObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachineButton = analyticalMachineButtonObjData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachineButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_AnalyticalMachineButton = analyticalMachineButtonObjData_T.CenterButton1;
    }

    void Update()
    {
        /*�׻� ��� �����⿡ �ֱ� �� ����� �İ��� ���� ��� ���¸� �����ϴ� �ܰ谡 �ʿ��ϴٴ� ������
         � ������ ���� �þƾ� �ȴٴ� ���� AI�� �˷��ش�.*/

        //��� ������ �ð� �м���� ��� ���̰� ����ϴٸ�
        if(areNormalMeteor1Data_T.IsSniff  || areimportantMeteorData_T.IsSniff )
        {
            IsSmellDone_T = true;
        }

        //���̰� �Ǹ� ��������� ��� ��ư�� ���ش�.
        if(analyticalMachineButtonData_T.IsCollision && IsSmellDone_T)
        {
            analyticalMachineButtonData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            analyticalMachineButtonOutline_T.OutlineWidth = 16;

            areAnalyticalMachineData_T.IsCenterButtonDisabled = false;
        }
        else if (!analyticalMachineButtonData_T.IsCollision)
        {
            analyticalMachineButtonData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            analyticalMachineButtonOutline_T.OutlineWidth = 0;

            areAnalyticalMachineData_T.IsCenterButtonDisabled = true;
        }

        if(GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 
            || GameManager.gameManager._gameData.IsInputImportantMeteorEnd)
        {
            //StartCoroutine(analyticalMachineClose(2f, 0f));

            areAnalyticalMachineData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
            areAnalyticalMachineOutline_T.OutlineWidth = 0;

            //IsAnalyticalMachinePlate_Collider.enabled = false;
        }
    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        noCenterButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        //StartCoroutine(analyticalMachineOpen());

        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", true);
        //analyticalMachineAnim_T.SetBool("isAnalyticalMachineClose", false);
        //analyticalMachineAnim_T.SetBool("isAnalyticalMachineCloseEnd", false);

        areAnalyticalMachineData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        areAnalyticalMachineOutline_T.OutlineWidth = 8;

        AreAnalyticalMachine_Collider.enabled = true;

    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    IEnumerator analyticalMachineOpen()
    {
        yield return new WaitForSeconds(1f);

        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineClose", false);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineCloseEnd", false);

        IsAnalyticalMachinePlate_Collider.enabled = true;

        //count1 += 1;
    }

    IEnumerator analyticalMachineClose(float delay2, float CloseTimeCheck2)
    {
        yield return new WaitForSeconds(delay2);

        bool isAnalyticalTimeOver = false;
        float closeTime2 = 0f;

        while (isAnalyticalTimeOver == false)
        {
            yield return null;

            closeTime2 += Time.deltaTime;

            //���� �ð���>=���� �ɾ�� �ð����� ũ�ų� ������
            //isTimeOver = true;�� �Ǿ� �� (isTimeOver == false)���� �����ڴ�.
            if (closeTime2 >= CloseTimeCheck2)
            {
                isAnalyticalTimeOver = true;
            }

            //Ȥ�� ��� �����ٸ� �� (isTimeOver == false)���� �����ڴ�
            if (areNormalMeteor1Data_T.IsBite)
            {
                isAnalyticalTimeOver = true;
            }
        }

        analyticalMachineAnim_T.SetBool("isAnalyticalMachineClose", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineCloseEnd", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", false);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", false);

        areAnalyticalMachineData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
        areAnalyticalMachineOutline_T.OutlineWidth = 0;

        IsAnalyticalMachinePlate_Collider.enabled = false;

        //count1 += 1;
    }
    public void OnBite()
    {

    }

    public void OnSmash()
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
    public void OnUp()
    {
      
    }
}
