using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker1 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_RubberForBeaker1;
    public GameObject M_AnswerMeteorForBeaker;

    public GameObject M_cylinderGlassAnswer;
    public GameObject M_cylinderGlassWrong;
    public GameObject M_cylinderGlassNoNeed1;
    public GameObject M_cylinderGlassNoNeed2;

    public GameObject M_drugInBeaker1;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Beaker1, sniffButton_M_Beaker1, biteButton_M_Beaker1,
        pressButton_M_Beaker1, eatButton_M_Beaker1, eatDisableButton_M_Beaker1;


    /*ObjData*/
    ObjData Beaker1Data_M;
    ObjData RubberForBeaker1Data_M;
    ObjData AnswerMeteorForBeakerData_M;

    ObjData cylinderGlassAnswerData_M;
    ObjData cylinderGlassWrongData_M;
    ObjData cylinderGlassNoNeed1Data_M;
    ObjData cylinderGlassNoNeed2Data_M;

    ObjData drugInBeaker1Data_M;

    /*Outline*/
    Outline Beaker1Outline_M;
    Outline AnswerMeteorForBeakerOutline_M;

   /*��Ŀ �� �ٲٴ� �ڵ�*/
   MeshRenderer ChangeBeaker1;

    void Start()
    {
        //�� �ٲٴ� �ڵ�
        ChangeBeaker1 = M_drugInBeaker1.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker1Data_M = GetComponent<ObjData>();
        RubberForBeaker1Data_M = M_RubberForBeaker1.GetComponent<ObjData>();
        AnswerMeteorForBeakerData_M = M_AnswerMeteorForBeaker.GetComponent<ObjData>();

        cylinderGlassAnswerData_M = M_cylinderGlassAnswer.GetComponent<ObjData>();
        cylinderGlassWrongData_M = M_cylinderGlassWrong.GetComponent<ObjData>();
        cylinderGlassNoNeed1Data_M = M_cylinderGlassNoNeed1.GetComponent<ObjData>();
        cylinderGlassNoNeed2Data_M = M_cylinderGlassNoNeed2.GetComponent<ObjData>();

        drugInBeaker1Data_M = M_drugInBeaker1.GetComponent<ObjData>();


        /*Outline*/
        Beaker1Outline_M = GetComponent<Outline>();
        AnswerMeteorForBeakerOutline_M = M_AnswerMeteorForBeaker.GetComponent<Outline>();

        barkButton_M_Beaker1 = Beaker1Data_M.BarkButton;
        barkButton_M_Beaker1.onClick.AddListener(OnBark);

        sniffButton_M_Beaker1 = Beaker1Data_M.SniffButton;
        sniffButton_M_Beaker1.onClick.AddListener(OnSniff);

        biteButton_M_Beaker1 = Beaker1Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker1 = Beaker1Data_M.PushOrPressButton;
        pressButton_M_Beaker1.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker1 = Beaker1Data_M.CenterButton1;
        eatButton_M_Beaker1.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker1 = Beaker1Data_M.CenterDisableButton1;

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            AnswerMeteorForBeakerData_M.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            AnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            Beaker1Data_M.IsCenterButtonDisabled= false;

            //���� ���Ѵ�.
            ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            M_AnswerMeteorForBeaker.SetActive(false);

            if (Beaker1Data_M.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
                //�������� �ִϸ��̼� ���� ����
            }
        }
    }

    void DisableButton()
    {
        barkButton_M_Beaker1.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker1.transform.gameObject.SetActive(false);
        biteButton_M_Beaker1.transform.gameObject.SetActive(false);
        pressButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatButton_M_Beaker1.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker1.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        Beaker1Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Beaker1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());

        /*�������� ���� ���� ��� ��Ŀ 1�� �ִ´ٸ�*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ AnswerMeteorForBeakerData_M.IsBite)
        {
            M_AnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_AnswerMeteorForBeaker.transform.parent = null;

            //��� ��Ŀ ������ �̵��Ѵ�.
            M_AnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 539.986f, 683.427f); //��ġ ��
            M_AnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

            GameManager.gameManager._gameData.IsAnswerInBeaker1_M_C2 = true;
        }

        //���� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker1.SetActive(true);
            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("�߸��� ���� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //�ʿ� ���� ��1�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //�ʿ� ���� ��2�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��2�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker1.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;
        }
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Beaker1Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Beaker1Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        Beaker1Data_M.IsEaten = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerEat();
    }

    public void OnBite()
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