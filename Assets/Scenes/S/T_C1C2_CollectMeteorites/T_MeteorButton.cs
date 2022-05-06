using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_MeteorButton : MonoBehaviour, IInteraction
{
    public bool meteorCollectanimOpen_T = false;

    /*�����ִ� ������Ʈ*/
    public GameObject T_canMeteorCollectMachine;
    public GameObject T_canNormalMeteor1;
    public GameObject T_canImportantMeteor;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_T_MeteorButton, sniffButton_T_MeteorButton, biteButton_T_MeteorButton,
        pressButton_T_MeteorButton, noCenterButton_T_MeteorButton;

    /*ObjData*/
    ObjData meteorButtonObjData_T;
    public ObjectData meteorButtonData_T;

    public ObjectData canMeteorCollectMachineData_T;
    public ObjectData canNormalMeteor1Data_T;
    public ObjectData canImportantMeteorData_T;

    /*Outline*/
    Outline canMeteorCollectMachineOutline_T;
    Outline meteorButtonOutline_T;

    /*Animator*/
    public Animator meteorBoxAnim_T;

    /*Collider*/
    BoxCollider collectMachineCollider;
    BoxCollider NormalMeteor1Collider;
    BoxCollider ImportantMeteorCollider;

    // Start is called before the first frame update
    void Start()
    {
        /*Collider*/
        collectMachineCollider = T_canMeteorCollectMachine. GetComponent<BoxCollider>();
        NormalMeteor1Collider = T_canNormalMeteor1.GetComponent<BoxCollider>();
        ImportantMeteorCollider = T_canImportantMeteor.GetComponent<BoxCollider>();

        /*ObjData*/
        meteorButtonObjData_T = GetComponent<ObjData>();

        /*Outline*/
        canMeteorCollectMachineOutline_T = T_canMeteorCollectMachine.GetComponent<Outline>();
        meteorButtonOutline_T = GetComponent<Outline>();

        /*��ư ����*/
        barkButton_T_MeteorButton = meteorButtonObjData_T.BarkButton;
        barkButton_T_MeteorButton.onClick.AddListener(OnBark);

        sniffButton_T_MeteorButton = meteorButtonObjData_T.SniffButton;
        sniffButton_T_MeteorButton.onClick.AddListener(OnSniff);

        biteButton_T_MeteorButton = meteorButtonObjData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_MeteorButton = meteorButtonObjData_T.PushOrPressButton;
        pressButton_T_MeteorButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_MeteorButton = meteorButtonObjData_T.CenterButton1;


        /*�ӹ� ����*/
        //�ð��� �Ǹ� 
        GameManager.gameManager._gameData.IsStartCollectMeteorites = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        if (GameManager.gameManager._gameData.IsStartCollectMeteorites)
        {
            //C-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }

        if(meteorButtonData_T.IsPushOrPress)
        {
            //C-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }

        if(canNormalMeteor1Data_T.IsBite /*&& ���� ����*/
            || canImportantMeteorData_T.IsBite/*&& ���� ����*/)
        {
            //C-3 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }
    }

    void Update()
    {
        //� ������踦 ������ ����̰�,
        if (meteorCollectanimOpen_T == true)
        {
            if (!canNormalMeteor1Data_T.IsBite || !canImportantMeteorData_T.IsBite) //�Ϲ� ��� ���� �ʾҴٸ�
            {
                StartCoroutine(meteorBoxClose(0f, 30f)); // 30�� �Ŀ� ���� �ݴ� �ִϸ��̼��� �����ϰڴ�.
            }
        }

        //��� ���� ���� ������ �ִϸ��̼� ����
        if(GameManager.gameManager._gameData.IsBiteimportantMeteor_T_C2)
        {
            StartCoroutine(meteorBoxClose(0f, 30f));
        }

        if (GameManager.gameManager._gameData.IsBiteNormalMeteor1_T_C2)
        {
            StartCoroutine(meteorBoxClose(0f, 30f));
        }

        //���̰� �ȴٸ� ��� ��ư�� Ȱ��ȭ
        if (meteorButtonData_T.IsCollision)
        {
            meteorButtonData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            meteorButtonOutline_T.OutlineWidth = 8;

            //canMeteorCollectMachineData_T.IsCenterPlusButtonDisabled = false; //�����ϱ� �����ϰ�
            canMeteorCollectMachineData_T.IsCenterButtonChanged = false;
        }

        else if (!meteorButtonData_T.IsCollision)
        {
            meteorButtonData_T.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            meteorButtonOutline_T.OutlineWidth = 0;

            canMeteorCollectMachineData_T.IsCenterButtonChanged = true;
        }

        //�ѹ��̶� �Ϲ� ��� �����ٸ�
        if(canNormalMeteor1Data_T.IsBite)
        {
            NormalMeteor1Collider.enabled = true;
        }

        if(canImportantMeteorData_T.IsBite)
        {
            ImportantMeteorCollider.enabled = true;
        }

/*        if(!meteorButtonData_T.IsPushOrPress)
        {
            collectMachineCollider.enabled = false;
        }*/
    }

    void DisableButton()
    {
        barkButton_T_MeteorButton.transform.gameObject.SetActive(false);
        sniffButton_T_MeteorButton.transform.gameObject.SetActive(false);
        biteButton_T_MeteorButton.transform.gameObject.SetActive(false);
        pressButton_T_MeteorButton.transform.gameObject.SetActive(false);
        noCenterButton_T_MeteorButton.transform.gameObject.SetActive(false);
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
               //� ���� ��� �� ���� �ִϸ��̼�
        StartCoroutine(meteorBoxOpen());

        canMeteorCollectMachineData_T.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        canMeteorCollectMachineOutline_T.OutlineWidth = 8;

        meteorCollectanimOpen_T = true;

        collectMachineCollider.enabled = true;

    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    //�ִϸ��̼�
    IEnumerator meteorBoxOpen()
    {
        // �⺻������ �� �Լ��� ���� �� ���� 1�� ������ �Ŀ� �����ϰڴ�.
        yield return new WaitForSeconds(1f);

        meteorBoxAnim_T.SetBool("isMeteorBoxClose", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxCloseEnd", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpen", true);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpenEnd", true);

        NormalMeteor1Collider.enabled = true;
        ImportantMeteorCollider.enabled = true;

        //count += 1;
    }

    // delay: �ִϸ��̼� �����ϱ� ������ �ð����� �󸶳� �Ұ���,
    // closeTimeCheck: �ð� ���� �󸶷� �ɾ��ٰ��� ��: 20�ʸ� ������ 20��Ȯ���Ŀ� �ִϸ��̼� �����ϰڴ�.
    IEnumerator meteorBoxClose(float delay, float closeTimeCheck)
    {

        yield return new WaitForSeconds(delay);


        bool isTimeOver = false;
        float closeTime = 0f;

        while (isTimeOver == false)
        {
            yield return null;

            closeTime += Time.deltaTime;

            //���� �ð���>=���� �ɾ�� �ð����� ũ�ų� ������
            //isTimeOver = true;�� �Ǿ� �� (isTimeOver == false)���� �����ڴ�.
            if (closeTime >= closeTimeCheck)
            {
                isTimeOver = true;
            }

            //Ȥ�� ��� �����ٸ� �� (isTimeOver == false)���� �����ڴ�
            if (canNormalMeteor1Data_T.IsBite)
            {
                isTimeOver = true;
            }
        }

        // isTimeOver = true�� �Ǿ��ٸ� �Ʒ��� �ִ� �ִϸ��̼��� �����ϰڴ�.
        meteorBoxAnim_T.SetBool("isMeteorBoxOpen", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxOpenEnd", false);
        meteorBoxAnim_T.SetBool("isMeteorBoxClose", true);
        meteorBoxAnim_T.SetBool("isMeteorBoxCloseEnd", true);

        meteorCollectanimOpen_T = false; // �ٽ� �ݺ��� �� �ְ�

        //Debug.Log("�ٽ� �ݺ��� �� �־��");

        canMeteorCollectMachineData_T.IsNotInteractable = true; // ��ȣ�ۿ� �Ұ����ϰ�
        canMeteorCollectMachineOutline_T.OutlineWidth = 0;
         
        NormalMeteor1Collider.enabled = false; //��� ��ȣ�ۿ� �Ұ����ϰ�
        ImportantMeteorCollider.enabled = false;

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

    public void OnSmash()
    {

    }

    public void OnUp()
    {
       
    }

}
