using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Beaker2 : MonoBehaviour, IInteraction
{
    /*�����ִ� ������Ʈ*/
    public GameObject M_RubberForBeaker2;
    public GameObject M_RealAnswerMeteorForBeaker;

    public GameObject M_RealCylinderGlassAnswer;
    public GameObject M_RealcylinderGlassWrong;
    public GameObject M_RealCylinderGlassNoNeed1;
    public GameObject M_RealCylinderGlassNoNeed2;

    public GameObject M_drugInBeaker2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_Beaker2, sniffButton_M_Beaker2, biteButton_M_Beaker2,
        pressButton_M_Beaker2, eatButton_M_Beaker2, eatDisableButton_M_Beaker2;


    /*ObjData*/
    ObjData Beaker2Data_M;
    ObjData RubberForBeaker2Data_M;
    ObjData RealAnswerMeteorForBeakerData_M;

    ObjData RealCylinderGlassAnswerData_M;
    ObjData RealCylinderGlassWrongData_M;
    ObjData RealCylinderGlassNoNeed1Data_M;
    ObjData RealCylinderGlassNoNeed2Data_M;

    ObjData drugInBeaker2Data_M;

    /*Outline*/
    Outline Beaker2Outline_M;
    Outline RealAnswerMeteorForBeakerOutline_M;

    /*��Ŀ �� �ٲٴ� �ڵ�*/
    MeshRenderer ChangeBeaker2;


    void Start()
    {
        //�� �ٲٴ� �ڵ�
        ChangeBeaker2 = M_drugInBeaker2.GetComponent<MeshRenderer>();

        /*ObjData*/
        Beaker2Data_M = GetComponent<ObjData>();
        RubberForBeaker2Data_M = M_RubberForBeaker2.GetComponent<ObjData>();
        RealAnswerMeteorForBeakerData_M = M_RealAnswerMeteorForBeaker.GetComponent<ObjData>();

        RealCylinderGlassAnswerData_M = M_RealCylinderGlassAnswer.GetComponent<ObjData>();
        RealCylinderGlassWrongData_M = M_RealcylinderGlassWrong.GetComponent<ObjData>();
        RealCylinderGlassNoNeed1Data_M = M_RealCylinderGlassNoNeed1.GetComponent<ObjData>();
        RealCylinderGlassNoNeed2Data_M = M_RealCylinderGlassNoNeed2.GetComponent<ObjData>();

        drugInBeaker2Data_M = M_drugInBeaker2.GetComponent<ObjData>();

        /*Outline*/
        Beaker2Outline_M = GetComponent<Outline>();
        RealAnswerMeteorForBeakerOutline_M = M_RealAnswerMeteorForBeaker.GetComponent<Outline>();


        /*��ư ����*/
        barkButton_M_Beaker2 = Beaker2Data_M.BarkButton;
        barkButton_M_Beaker2.onClick.AddListener(OnBark);

        sniffButton_M_Beaker2 = Beaker2Data_M.SniffButton;
        sniffButton_M_Beaker2.onClick.AddListener(OnSniff);

        biteButton_M_Beaker2 = Beaker2Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Beaker2 = Beaker2Data_M.PushOrPressButton;
        pressButton_M_Beaker2.onClick.AddListener(OnPushOrPress);

        eatButton_M_Beaker2 = Beaker2Data_M.CenterButton1;
        eatButton_M_Beaker2.onClick.AddListener(OnEat);

        eatDisableButton_M_Beaker2 = Beaker2Data_M.CenterButton1;

        if (Beaker2Data_M.IsEaten)
        {
            Invoke(" FakeAI2", 3f);
        }

    }

    void FakeAI2()
    {
        //D-2 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        GameManager.gameManager._gameData.IsCompletePretendDead = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

    }

    void Update()
    {
        if (GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            RealAnswerMeteorForBeakerData_M.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            RealAnswerMeteorForBeakerOutline_M.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            Beaker2Data_M.IsCenterButtonDisabled = false;

            //���� ���Ѵ�.
            ChangeBeaker2.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            M_RealAnswerMeteorForBeaker.SetActive(false);

            if (Beaker2Data_M.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
                //�������� �ִϸ��̼� ���� ����
            }
        }
    }

    void DisableButton()
    {
        barkButton_M_Beaker2.transform.gameObject.SetActive(false);
        sniffButton_M_Beaker2.transform.gameObject.SetActive(false);
        biteButton_M_Beaker2.transform.gameObject.SetActive(false);
        pressButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatButton_M_Beaker2.transform.gameObject.SetActive(false);
        eatDisableButton_M_Beaker2.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        Beaker2Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Beaker2Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());

        /*������ ���� ���� ��� ��Ŀ 2�� �ִ´ٸ�*/
        if (/*RubberForBeaker1Data_M.IsBite &&*/ RealAnswerMeteorForBeakerData_M.IsBite)
        {
            M_RealAnswerMeteorForBeaker.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
            M_RealAnswerMeteorForBeaker.transform.parent = null;

            //��� ��Ŀ ������ �̵��Ѵ�.
            M_RealAnswerMeteorForBeaker.transform.position = new Vector3(-248.367f, 539.986f, 683.427f); //��ġ ��
            M_RealAnswerMeteorForBeaker.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

            GameManager.gameManager._gameData.IsAnswerInBeaker2_M_C2 = true;
        }

        //���� ���� ��Ŀ 2�� �־��� ��
        if (RealCylinderGlassAnswerData_M.IsBite)
        {
            M_drugInBeaker2.SetActive(true);
            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassWrongData_M.IsBite)
        {
            Debug.Log("�߸��� ���� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //�ʿ� ���� ��1�� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassNoNeed1Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }

        //�ʿ� ���� ��2�� ��Ŀ 1�� �־��� ��
        if (RealCylinderGlassNoNeed2Data_M.IsBite)
        {
            Debug.Log("�ʿ���� ��2�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            M_drugInBeaker2.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = true;
        }

    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Beaker2Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        Beaker2Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        Beaker2Data_M.IsEaten = true;

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
