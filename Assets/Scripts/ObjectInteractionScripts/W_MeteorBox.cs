using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_MeteorBox : MonoBehaviour
{
    // � ������
    public GameObject meteorBoxButton1_MB; 
    public GameObject meteorBoxButton2_MB;
    public GameObject meteorBoxButton3_MB; 
    public GameObject meteorBoxButton4_MB; 
    public GameObject meteorBoxButton5_MB; 

    //���
    public GameObject answerMeteor_MB;
    public GameObject wrongMeteor1_MB;
    public GameObject wrongMeteor2_MB;
    public GameObject wrongMeteor3_MB;
    public GameObject wrongMeteor4_MB;

    //����
    public GameObject cylinderGlassAnswer_MB;
    public GameObject cylinderGlassWrong_MB;
    public GameObject cylinderGlassNoNeed1_MB;
    public GameObject cylinderGlassNoNeed2_MB;

    //��
    public GameObject cylinderInAnswer_MB;
    public GameObject cylinderInWrong_MB;
    public GameObject beaker1_MB;
    public GameObject beaker2_MB;

    public GameObject drugInBeaker1_MB;
    public GameObject drugInBeaker2_MB;


    //����
    //��� ���߿� ���� �ڵ�� ���� ��ã�� ���� �ߴ��� ���ߴ��� �׻� Ȯ���ϰ� �����ϰ� �����߰ڴ�.
    public GameObject rubber3_MB; 



    //ObjData
    ObjData meteorBoxButton1Data_MB;
    ObjData meteorBoxButton2Data_MB;
    ObjData meteorBoxButton3Data_MB;
    ObjData meteorBoxButton4Data_MB;
    ObjData meteorBoxButton5Data_MB;

    ObjData answerMeteorData_MB;
    ObjData wrongMeteor1Data_MB;
    ObjData wrongMeteor2Data_MB;
    ObjData wrongMeteor3Data_MB;
    ObjData wrongMeteor4Data_MB;

    ObjData cylinderGlassAnswerData_MB;
    ObjData cylinderGlassWrongData_MB;
    ObjData cylinderGlassNoNeed1Data_MB;
    ObjData cylinderGlassNoNeed2Data_MB;

    ObjData cylinderInAnswerData_MB;
    ObjData cylinderInWrongData_MB;
    ObjData beaker1Data_MB;
    ObjData beaker2Data_MB;
    ObjData drugInBeaker1Data_MB;
    ObjData drugInBeaker2Data_MB;

    ObjData rubber3Data_MB;

    //��Ŀ �� �ٲٴ� �ڵ�
    //SpriteRenderer ChangeBeaker1;
    //SpriteRenderer ChangeBeaker2;
    MeshRenderer ChangeBeaker1;
    MeshRenderer ChangeBeaker2;




    //Outline
    Outline meteorBoxButton1Outline_MB;
    Outline meteorBoxButton2Outline_MB;
    Outline meteorBoxButton3Outline_MB;
    Outline meteorBoxButton4Outline_MB;
    Outline meteorBoxButton5Outline_MB;

    Outline answerMeteorOutline_MB;
    Outline wrongMeteor1Outline_MB;
    Outline wrongMeteor2Outline_MB;
    Outline wrongMeteor3Outline_MB;
    Outline wrongMeteor4Outline_MB;

    Outline beaker1Outline_MB;
    Outline beaker2Outline_MB;

    //�ִϸ��̼�
    public Animator meteorBox1Anim_MB;
    public Animator meteorBox2Anim_MB;
    public Animator meteorBox3Anim_MB;
    public Animator meteorBox4Anim_MB;
    public Animator meteorBox5Anim_MB;

    // Start is called before the first frame update
    void Start()
    {
        //ObjData
        meteorBoxButton1Data_MB = meteorBoxButton1_MB.GetComponent<ObjData>();
        meteorBoxButton2Data_MB = meteorBoxButton2_MB.GetComponent<ObjData>();
        meteorBoxButton3Data_MB = meteorBoxButton3_MB.GetComponent<ObjData>();
        meteorBoxButton4Data_MB = meteorBoxButton4_MB.GetComponent<ObjData>();
        meteorBoxButton5Data_MB = meteorBoxButton5_MB.GetComponent<ObjData>();

        answerMeteorData_MB = answerMeteor_MB.GetComponent<ObjData>();
        wrongMeteor1Data_MB = wrongMeteor1_MB.GetComponent<ObjData>();
        wrongMeteor2Data_MB = wrongMeteor2_MB.GetComponent<ObjData>();
        wrongMeteor3Data_MB = wrongMeteor3_MB.GetComponent<ObjData>();
        wrongMeteor4Data_MB = wrongMeteor4_MB.GetComponent<ObjData>();


        cylinderGlassAnswerData_MB = cylinderGlassAnswer_MB.GetComponent<ObjData>();
        cylinderGlassWrongData_MB = cylinderGlassWrong_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed1Data_MB = cylinderGlassNoNeed1_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed2Data_MB = cylinderGlassNoNeed2_MB.GetComponent<ObjData>();


        cylinderInAnswerData_MB = cylinderInAnswer_MB.GetComponent<ObjData>();
        cylinderInWrongData_MB = cylinderInWrong_MB.GetComponent<ObjData>();
        beaker1Data_MB = beaker1_MB.GetComponent<ObjData>();
        beaker2Data_MB = beaker2_MB.GetComponent<ObjData>();
        drugInBeaker1Data_MB = drugInBeaker1_MB.GetComponent<ObjData>();
        drugInBeaker2Data_MB = drugInBeaker2_MB.GetComponent<ObjData>();

        rubber3Data_MB = rubber3_MB.GetComponent<ObjData>();


        //�ƿ�����
        meteorBoxButton1Outline_MB = meteorBoxButton1_MB.GetComponent<Outline>();
        meteorBoxButton2Outline_MB = meteorBoxButton2_MB.GetComponent<Outline>();
        meteorBoxButton3Outline_MB = meteorBoxButton3_MB.GetComponent<Outline>();
        meteorBoxButton4Outline_MB = meteorBoxButton4_MB.GetComponent<Outline>();
        meteorBoxButton5Outline_MB = meteorBoxButton5_MB.GetComponent<Outline>();

        answerMeteorOutline_MB = answerMeteor_MB.GetComponent<Outline>();
        wrongMeteor1Outline_MB = wrongMeteor1_MB.GetComponent<Outline>();
        wrongMeteor2Outline_MB = wrongMeteor2_MB.GetComponent<Outline>();
        wrongMeteor3Outline_MB = wrongMeteor3_MB.GetComponent<Outline>();
        wrongMeteor4Outline_MB = wrongMeteor4_MB.GetComponent<Outline>();

        beaker1Outline_MB = beaker1_MB.GetComponent<Outline>();
        beaker2Outline_MB = beaker2_MB.GetComponent<Outline>();

        //�� �ٲٴ� �ڵ�
        ChangeBeaker1 = drugInBeaker1_MB.GetComponent<MeshRenderer>();
        ChangeBeaker2 = drugInBeaker2_MB.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //���� � 5���� ���� �� ����̶�� trueȮ���ϰ�
        //���� ��ȣ�ۿ��� ���ش�.

        meteorBoxButton1Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton1Outline_MB.OutlineWidth = 8;

        meteorBoxButton2Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton2Outline_MB.OutlineWidth = 8;

        meteorBoxButton3Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton3Outline_MB.OutlineWidth = 8;

        meteorBoxButton4Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton4Outline_MB.OutlineWidth = 8;

        meteorBoxButton5Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
        meteorBoxButton5Outline_MB.OutlineWidth = 8;






        //� �ڽ� ��ư�� ������
        if(meteorBoxButton1Data_MB.IsPushOrPress)
        {
            meteorBox1Anim_MB.SetBool("isMeteorBox1Open", true);
            meteorBox1Anim_MB.SetBool("isMeteorBox1End", true);

            wrongMeteor1Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor1Outline_MB.OutlineWidth = 8;
        }

        if (meteorBoxButton2Data_MB.IsPushOrPress)
        {
            meteorBox2Anim_MB.SetBool("isMeteorBox2Open", true);
            meteorBox2Anim_MB.SetBool("isMeteorBox2End", true);

            answerMeteorData_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 8;
        }

        if (meteorBoxButton3Data_MB.IsPushOrPress)
        {
            meteorBox3Anim_MB.SetBool("isMeteorBox3Open", true);
            meteorBox3Anim_MB.SetBool("isMeteorBox3End", true);

            wrongMeteor2Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor2Outline_MB.OutlineWidth = 8;
        }

        if (meteorBoxButton4Data_MB.IsPushOrPress)
        {
            //���� ������ �ִϸ��̼� ����, ���� ���� ����
            meteorBox4Anim_MB.SetBool("isMeteorBox4Open", true);
            meteorBox4Anim_MB.SetBool("isMeteorBox4End", true);

            wrongMeteor3Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor3Outline_MB.OutlineWidth = 8;
        }

        if (meteorBoxButton5Data_MB.IsPushOrPress)
        {
            //���� ������ �ִϸ��̼� ����, ���� ���� ����
            meteorBox5Anim_MB.SetBool("isMeteorBox5Open", true);
            meteorBox5Anim_MB.SetBool("isMeteorBox5End", true);

            wrongMeteor4Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor4Outline_MB.OutlineWidth = 8;
        }


        //���� ���Ⱑ ���� ū ��������
        if(rubber3Data_MB.IsBite)
        {
            //������ �ƴ� �ٸ� ��� ���� ������ ��Ŀ�� ��Ȱ��ȭ �ȴ�.
            if (wrongMeteor1Data_MB.IsBite || wrongMeteor2Data_MB.IsBite || wrongMeteor3Data_MB.IsBite || wrongMeteor4Data_MB.IsBite 
                || cylinderGlassNoNeed1Data_MB.IsBite || cylinderGlassNoNeed2Data_MB.IsBite)
            {
                Debug.Log("�߸��� ��� �������. ��Ŀ�� ��Ȱ��ȭ �˴ϴ�.");
                //�� ������ ��Ŀ ��� ��Ȱ��ȭ �ȴ�.
                beaker1Data_MB.IsNotInteractable = true;
                beaker1Outline_MB.OutlineWidth = 0;

                beaker2Data_MB.IsNotInteractable = true;
                beaker2Outline_MB.OutlineWidth = 0;
            }

            else if(answerMeteorData_MB.IsBite)
            {
                beaker1Data_MB.IsNotInteractable = false;
                beaker1Outline_MB.OutlineWidth = 8;

                beaker2Data_MB.IsNotInteractable = false;
                beaker2Outline_MB.OutlineWidth = 8;
            }


            //��Ŀ�� � �ֱ�-------------------------------------------------------
            if (answerMeteorData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                answerMeteorData_MB.transform.parent = null;

                //��� ��Ŀ ������ �̵��Ѵ�.
                answerMeteorData_MB.transform.position = new Vector3(-248.397f, 539.986f, 683.212f); //��ġ ��

                GameManager.gameManager._gameData.IsInputMeteor1_M_C2 = true;
            }

            if (answerMeteorData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                answerMeteorData_MB.transform.parent = null;

                //��� ��Ŀ ������ �̵��Ѵ�.
                answerMeteorData_MB.transform.position = new Vector3(-249.049f, 539.986f, 683.212f); //��ġ ��

                GameManager.gameManager._gameData.IsInputMeteor2_M_C2 = true;
            }
        }

        else if (answerMeteorData_MB.IsBite || wrongMeteor1Data_MB.IsBite || wrongMeteor2Data_MB.IsBite ||
            wrongMeteor2Data_MB.IsBite || wrongMeteor3Data_MB.IsBite || wrongMeteor4Data_MB.IsBite )
        {
            Debug.Log("��������");
        }




        //��Ŀ�� �� �ֱ�-------------------------------------------------------
        //���� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassAnswerData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            cylinderInAnswer_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker1.material.color = new Color(90 / 255f, 142 / 255f, 72 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsInputAnswerDrug1_M_C2 = true;
        }

        //���� ���� ��Ŀ 2�� �־��� ��
        if (cylinderGlassAnswerData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            cylinderInAnswer_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(90 / 255f, 142 / 255f, 72 / 255f);  //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsInputAnswerDrug2_M_C2 = true;
        }

        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassWrongData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(20 / 255f, 100 / 255f, 7 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.
        }

        //Ʋ�� ���� ��Ŀ 2�� �־��� ��
        if (cylinderGlassWrongData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(20 / 255f, 100 / 255f, 7 / 255f);//���� �� ������ ��Ŀ���� ���Ѵ�.
        }

        //�ùٸ� ��� �ù��� ��� �־��ٸ�
        if (GameManager.gameManager._gameData.IsInputMeteor1_M_C2 && GameManager.gameManager._gameData.IsInputAnswerDrug1_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            beaker1Data_MB.IsCenterButtonDisabled = false;

            //���� ���Ѵ�.
            ChangeBeaker1.material.color = new Color(90 / 255f, 142 / 255f, 72 / 255f);

            if (beaker1Data_MB.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
            }
        }


        if (GameManager.gameManager._gameData.IsInputMeteor2_M_C2 && GameManager.gameManager._gameData.IsInputAnswerDrug2_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            beaker2Data_MB.IsCenterButtonDisabled = false;
            ChangeBeaker2.material.color = new Color(90 / 255f, 142 / 255f, 72 / 255f);

            if (beaker2Data_MB.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
            }
        }
    }


}
