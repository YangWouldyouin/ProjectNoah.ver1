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

    public GameObject meteorBox1_MB;
    public GameObject meteorBox2_MB;
    public GameObject meteorBox3_MB;
    public GameObject meteorBox4_MB;
    public GameObject meteorBox5_MB;

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
    public GameObject beaker1_MB;
    public GameObject beaker2_MB;
    
    //public GameObject cylinderInAnswer_MB;
    //public GameObject cylinderInWrong_MB;

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

    ObjData meteorBox1Data_MB;
    ObjData meteorBox2Data_MB;
    ObjData meteorBox3Data_MB;
    ObjData meteorBox4Data_MB;
    ObjData meteorBox5Data_MB;

    ObjData answerMeteorData_MB;
    ObjData wrongMeteor1Data_MB;
    ObjData wrongMeteor2Data_MB;
    ObjData wrongMeteor3Data_MB;
    ObjData wrongMeteor4Data_MB;

    ObjData cylinderGlassAnswerData_MB;
    ObjData cylinderGlassWrongData_MB;
    ObjData cylinderGlassNoNeed1Data_MB;
    ObjData cylinderGlassNoNeed2Data_MB;

    ObjData beaker1Data_MB;
    ObjData beaker2Data_MB;

    //ObjData cylinderInAnswerData_MB;
    //ObjData cylinderInWrongData_MB;
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

    Outline meteorBox1Outline_MB;
    Outline meteorBox2Outline_MB;
    Outline meteorBox3Outline_MB;
    Outline meteorBox4Outline_MB;
    Outline meteorBox5Outline_MB;

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

        meteorBox1Data_MB = meteorBox1_MB.GetComponent<ObjData>();
        meteorBox2Data_MB = meteorBox2_MB.GetComponent<ObjData>();
        meteorBox3Data_MB = meteorBox3_MB.GetComponent<ObjData>();
        meteorBox4Data_MB = meteorBox4_MB.GetComponent<ObjData>();
        meteorBox5Data_MB = meteorBox5_MB.GetComponent<ObjData>();

        answerMeteorData_MB = answerMeteor_MB.GetComponent<ObjData>();
        wrongMeteor1Data_MB = wrongMeteor1_MB.GetComponent<ObjData>();
        wrongMeteor2Data_MB = wrongMeteor2_MB.GetComponent<ObjData>();
        wrongMeteor3Data_MB = wrongMeteor3_MB.GetComponent<ObjData>();
        wrongMeteor4Data_MB = wrongMeteor4_MB.GetComponent<ObjData>();


        cylinderGlassAnswerData_MB = cylinderGlassAnswer_MB.GetComponent<ObjData>();
        cylinderGlassWrongData_MB = cylinderGlassWrong_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed1Data_MB = cylinderGlassNoNeed1_MB.GetComponent<ObjData>();
        cylinderGlassNoNeed2Data_MB = cylinderGlassNoNeed2_MB.GetComponent<ObjData>();


        //cylinderInAnswerData_MB = cylinderInAnswer_MB.GetComponent<ObjData>();
        //cylinderInWrongData_MB = cylinderInWrong_MB.GetComponent<ObjData>();
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

        meteorBox1Outline_MB = meteorBox1_MB.GetComponent<Outline>();
        meteorBox2Outline_MB = meteorBox2_MB.GetComponent<Outline>();
        meteorBox3Outline_MB = meteorBox3_MB.GetComponent<Outline>();
        meteorBox4Outline_MB = meteorBox4_MB.GetComponent<Outline>();
        meteorBox5Outline_MB = meteorBox5_MB.GetComponent<Outline>();

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

    }

    // Update is called once per frame
    void Update()
    {

        //1���---------------------------------------
        //� �ڽ� ��ư�� ������
        if (meteorBoxButton1Data_MB.IsPushOrPress)
        {
            // �� ������ �ִϸ��̼� ����
            meteorBox1Anim_MB.SetBool("isMeteorBox1Open", true);
            meteorBox1Anim_MB.SetBool("isMeteorBox1End", true);

            meteorBoxButton1Data_MB.IsNotInteractable = true; // ��ư�� ��ȣ�ۿ� �Ұ����ϰ�
            meteorBoxButton1Outline_MB.OutlineWidth = 0;

            meteorBox1Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            meteorBox1Outline_MB.OutlineWidth = 8;
        }

        //�����ϱ⸦ �Ѵٸ�
        if (meteorBox1Data_MB.IsObserve)
        {
            Debug.Log("�����ϱ� �並 �����ҰԿ�");
            CameraController.cameraController.currentView = meteorBox1Data_MB.ObserveView;

            wrongMeteor1Data_MB.IsNotInteractable = false; // � ��ȣ�ۿ� �����ϰ�
            wrongMeteor1Outline_MB.OutlineWidth = 8;

            meteorBox1Data_MB.IsNotInteractable = true; // � ������ ��ȣ�ۿ� �Ұ����ϰ�
            meteorBox1Outline_MB.OutlineWidth = 0;

            if (wrongMeteor1Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox1Data_MB.IsObserve = false;

                meteorBox1Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
                meteorBox1Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor1_M_C2 = true;

            }
        }

        else
        {
            //�ٱ����� �����ٰ� �������� �� ����
            wrongMeteor1Data_MB.IsNotInteractable = true; // � ��ȣ�ۿ� �Ұ����ϰ�
            wrongMeteor1Outline_MB.OutlineWidth = 0;

            //meteorBox1Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            //meteorBox1Outline_MB.OutlineWidth = 8;
        }



        if (GameManager.gameManager._gameData.IsBiteWrongMeteor1_M_C2)
        {
            wrongMeteor1Data_MB.IsNotInteractable = false; // � �׻� ��ȣ�ۿ� �����ϰ�
            wrongMeteor1Outline_MB.OutlineWidth = 8;
        }



        //2���---------------------------------------

        if (meteorBoxButton2Data_MB.IsPushOrPress)
        {
            meteorBox2Anim_MB.SetBool("isMeteorBox2Open", true);
            meteorBox2Anim_MB.SetBool("isMeteorBox2End", true);

            meteorBoxButton2Data_MB.IsNotInteractable = true; // ��ư�� ��ȣ�ۿ� �Ұ����ϰ�
            meteorBoxButton2Outline_MB.OutlineWidth = 0;

            meteorBox2Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            meteorBox2Outline_MB.OutlineWidth = 8;
        }

        //�����ϱ⸦ �Ѵٸ�
        if (meteorBox2Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox2Data_MB.ObserveView;

            answerMeteorData_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 8;

            meteorBox2Data_MB.IsNotInteractable = true; // � ������ ��ȣ�ۿ� �Ұ����ϰ�
            meteorBox2Outline_MB.OutlineWidth = 0;

            if (answerMeteorData_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox2Data_MB.IsObserve = false;

                meteorBox2Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
                meteorBox2Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteAnswerMeteor_M_C2 = true;
            }
        }

        else
        {
            //�ٱ����� �����ٰ� �������� �� ����
            answerMeteorData_MB.IsNotInteractable = true; // � ��ȣ�ۿ� �Ұ����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 0;
        }


        //�ٱ����� �����ٰ� �������� �� ����
        if (GameManager.gameManager._gameData.IsBiteAnswerMeteor_M_C2)
        {
            answerMeteorData_MB.IsNotInteractable = false; // � ��ȣ�ۿ�  �׻� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 8;
        }




        //3���---------------------------------------
        if (meteorBoxButton3Data_MB.IsPushOrPress)
        {
            meteorBox3Anim_MB.SetBool("isMeteorBox3Open", true);
            meteorBox3Anim_MB.SetBool("isMeteorBox3End", true);

            meteorBoxButton3Data_MB.IsNotInteractable = true; // ��ư�� ��ȣ�ۿ� �Ұ����ϰ�
            meteorBoxButton3Outline_MB.OutlineWidth = 0;

            meteorBox3Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            meteorBox3Outline_MB.OutlineWidth = 8;
        }

        //�����ϱ⸦ �Ѵٸ�
        if (meteorBox3Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox3Data_MB.ObserveView;

            wrongMeteor2Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor2Outline_MB.OutlineWidth = 8;

            meteorBox3Data_MB.IsNotInteractable = true; // � ������ ��ȣ�ۿ� �Ұ����ϰ�
            meteorBox3Outline_MB.OutlineWidth = 0;

            if (wrongMeteor2Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox3Data_MB.IsObserve = false;

                meteorBox3Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
                meteorBox3Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor2_M_C2 = true;
            }
        }

        else
        {
            //�ٱ����� �����ٰ� �������� �� ����
            wrongMeteor2Data_MB.IsNotInteractable = true; // � ��ȣ�ۿ� �Ұ����ϰ�
            wrongMeteor2Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor2_M_C2)
        {
            wrongMeteor2Data_MB.IsNotInteractable = false; // � �׻� ��ȣ�ۿ� �����ϰ�
            wrongMeteor2Outline_MB.OutlineWidth = 8;
        }




        //4���---------------------------------------

        if (meteorBoxButton4Data_MB.IsPushOrPress)
        {
            //���� ������ �ִϸ��̼� ����, ���� ���� ����
            meteorBox4Anim_MB.SetBool("isMeteorBox4Open", true);
            meteorBox4Anim_MB.SetBool("isMeteorBox4End", true);

            meteorBoxButton4Data_MB.IsNotInteractable = true; // ��ư�� ��ȣ�ۿ� �Ұ����ϰ�
            meteorBoxButton4Outline_MB.OutlineWidth = 0;

            meteorBox4Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            meteorBox4Outline_MB.OutlineWidth = 8;

        }

        //�����ϱ⸦ �Ѵٸ�
        if (meteorBox4Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox4Data_MB.ObserveView;
            
            wrongMeteor3Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor3Outline_MB.OutlineWidth = 8;

            meteorBox4Data_MB.IsNotInteractable = true; // � ������ ��ȣ�ۿ� �Ұ����ϰ�
            meteorBox4Outline_MB.OutlineWidth = 0;

            if (wrongMeteor3Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox4Data_MB.IsObserve = false;

                meteorBox4Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
                meteorBox4Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor3_M_C2 = true;
            }
        }

        else
        {
            //�ٱ����� �����ٰ� �������� �� ����
            wrongMeteor3Data_MB.IsNotInteractable = true; // � ��ȣ�ۿ� �Ұ����ϰ�
            wrongMeteor3Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor3_M_C2)
        {
            wrongMeteor3Data_MB.IsNotInteractable = false; // � �׻� ��ȣ�ۿ� �����ϰ�
            wrongMeteor3Outline_MB.OutlineWidth = 8;
        }


        //5���---------------------------------------
        if (meteorBoxButton5Data_MB.IsPushOrPress)
        {
            //���� ������ �ִϸ��̼� ����, ���� ���� ����
            meteorBox5Anim_MB.SetBool("isMeteorBox5Open", true);
            meteorBox5Anim_MB.SetBool("isMeteorBox5End", true);

            meteorBoxButton5Data_MB.IsNotInteractable = true; // ��ư�� ��ȣ�ۿ� �Ұ����ϰ�
            meteorBoxButton5Outline_MB.OutlineWidth = 0;

            meteorBox5Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
            meteorBox5Outline_MB.OutlineWidth = 8;
        }

        //�����ϱ⸦ �Ѵٸ�
        if (meteorBox5Data_MB.IsObserve)
        {
            CameraController.cameraController.currentView = meteorBox5Data_MB.ObserveView;

            wrongMeteor4Data_MB.IsNotInteractable = false; // ��ȣ�ۿ� �����ϰ�
            wrongMeteor4Outline_MB.OutlineWidth = 8;

            meteorBox5Data_MB.IsNotInteractable = true; // � ������ ��ȣ�ۿ� �Ұ����ϰ�
            meteorBox5Outline_MB.OutlineWidth = 0;

            if (wrongMeteor4Data_MB.IsBite)
            {
                CameraController.cameraController.CancelObserve();
                meteorBox5Data_MB.IsObserve = false;

                meteorBox5Data_MB.IsNotInteractable = false; // � ������ ��ȣ�ۿ� �����ϰ�
                meteorBox5Outline_MB.OutlineWidth = 8;

                GameManager.gameManager._gameData.IsBiteWrongMeteor4_M_C2 = true;
            }
        }

        else
        {
            //�ٱ����� �����ٰ� �������� �� ����
            wrongMeteor4Data_MB.IsNotInteractable = true; // � ��ȣ�ۿ� �Ұ����ϰ�
            wrongMeteor4Outline_MB.OutlineWidth = 0;
        }

        if (GameManager.gameManager._gameData.IsBiteWrongMeteor4_M_C2)
        {
            wrongMeteor4Data_MB.IsNotInteractable = false; // � �׻� ��ȣ�ۿ� �����ϰ�
            wrongMeteor4Outline_MB.OutlineWidth = 8;
        }







        //���� ���Ⱑ ���� ū �������� --------------------------
        if (rubber3Data_MB.IsBite)
        {
            //�ٸ� ����� ���Ⱑ ���������� ��Ŀ�� �־ �ƹ��� ��ȣ�ۿ��� ���Ͼ��.

/*            //������ �ƴ� �ٸ� ��� ���� ������ ��Ŀ�� ��Ȱ��ȭ �ȴ�.
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

            else
            {
                beaker1Data_MB.IsNotInteractable = false;
                beaker1Outline_MB.OutlineWidth = 8;

                beaker2Data_MB.IsNotInteractable = false;
                beaker2Outline_MB.OutlineWidth = 8;
            }*/

            


            //��Ŀ�� ���� �ֱ�-------------------------------------------------------
            if (answerMeteorData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                answerMeteorData_MB.transform.parent = null;

                //��� ��Ŀ ������ �̵��Ѵ�.
                answerMeteorData_MB.transform.position = new Vector3(-249.049f, 539.986f, 683.212f); //��ġ ��
                answerMeteorData_MB.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

                GameManager.gameManager._gameData.IsInputMeteor1_M_C2 = true;
            }

            if (answerMeteorData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
            {
                answerMeteorData_MB.GetComponent<Rigidbody>().isKinematic = false; // ��迡�� ����� �Ѵ�.
                answerMeteorData_MB.transform.parent = null;

                //��� ��Ŀ ������ �̵��Ѵ�.
                answerMeteorData_MB.transform.position = new Vector3(-248.397f, 539.986f, 683.212f); //��ġ ��
                answerMeteorData_MB.transform.rotation = Quaternion.Euler(-90, 0, 0); //�����̼� ��

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
            //cylinderInAnswer_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            Debug.Log("���� ����Ǿ����ϴ�.");
            ChangeBeaker1.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;


            //�� ��Ŀ ���빰 ������ ������ �ؼ� �װ� ���� �ִٸ� Ʈ��� üũ�ϰڴ�. �װ� Ʈ���� ���� ���� �����ȰŴ�.


            //GameManager.gameManager._gameData.IsInputAnswerDrug1_M_C2 = true;
        }

        //���� ���� ��Ŀ 2�� �־��� ��
        if (cylinderGlassAnswerData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            //cylinderInAnswer_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(173 / 255f, 221 / 255f, 158 / 255f);  //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;

            //GameManager.gameManager._gameData.IsInputAnswerDrug2_M_C2 = true;
        }





        //Ʋ�� ���� ��Ŀ 1�� �־��� ��
        if (cylinderGlassWrongData_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("�߸��� ���� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //Ʋ�� ���� ��Ŀ 2�� �־��� ��
        if (cylinderGlassWrongData_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("�߸��� ���� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 173 / 255f, 71 / 255f);//���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }






        //�ʿ� ���� ��1�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed1Data_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = false;
        }

        //�ʿ� ���� ��1�� ��Ŀ 2�� �־��� ��
        if (cylinderGlassNoNeed1Data_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(197 / 255f, 214 / 255f, 255 / 255f);//���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = true;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = false;
        }


        //�ʿ� ���� ��2�� ��Ŀ 1�� �־��� ��
        if (cylinderGlassNoNeed2Data_MB.IsBite && beaker1Data_MB.IsPushOrPress)
        {
            Debug.Log("�ʿ���� ��2�� ��Ŀ1�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker1_MB.SetActive(true);
            ChangeBeaker1.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f); //���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange1_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange1_M_C2 = true;
        }

        //�ʿ� ���� ��2�� ��Ŀ 2�� �־��� ��
        if (cylinderGlassNoNeed2Data_MB.IsBite && beaker2Data_MB.IsPushOrPress)
        {
            Debug.Log("�ʿ���� ��1�� ��Ŀ2�� �־����ϴ�.");
            //cylinderInWrong_MB.SetActive(false);
            drugInBeaker2_MB.SetActive(true);
            ChangeBeaker2.material.color = new Color(255 / 255f, 144 / 255f, 129 / 255f);//���� �� ������ ��Ŀ���� ���Ѵ�.

            GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsWrongBeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed1BeakerColorChange2_M_C2 = false;
            GameManager.gameManager._gameData.IsNoNeed2BeakerColorChange2_M_C2 = true;
        }










        // �������� �ڵ� ------------------------------------------------
        //�ùٸ� ��� �ù��� ��� ��Ŀ 1�� �־��ٸ� 
        if (GameManager.gameManager._gameData.IsInputMeteor1_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange1_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            beaker1Data_MB.IsCenterButtonDisabled = false;

            //���� ���Ѵ�.
            ChangeBeaker1.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            answerMeteor_MB.SetActive(false);

            if (beaker1Data_MB.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
            }
        }


        if (GameManager.gameManager._gameData.IsInputMeteor2_M_C2 && GameManager.gameManager._gameData.IsAnswerBeakerColorChange2_M_C2)
        {
            //���� ���� ������ٸ� ��� ��ȣ�ۿ��� �Ұ���������.
            //answerMeteor_MB.SetActive(false);
            answerMeteorData_MB.IsNotInteractable = true; // ��ȣ�ۿ� �����ϰ�
            answerMeteorOutline_MB.OutlineWidth = 0;

            //��� ��Ŀ �߾��� ���ñⰡ Ȱ��ȭ �ȴ�.
            beaker2Data_MB.IsCenterButtonDisabled = false;
            ChangeBeaker2.material.color = new Color(246 / 255f, 27 / 255f, 193 / 255f);

            answerMeteor_MB.SetActive(false);

            if (beaker2Data_MB.IsEaten)
            {
                Debug.Log("����� ������0, ����ô�� �ϴ� ���Դϴ�.");
                GameManager.gameManager._gameData.IsNoahDead_M_C2 = true;
            }
        }
    }


}
