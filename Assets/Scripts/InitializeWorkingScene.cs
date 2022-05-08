using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeWorkingScene : MonoBehaviour
{
    public GameObject ChangeScene;


    [Header("<����Ʈ�� ����>")]
    public GameObject FixedLine2; //������ ��
    public GameObject LineHome2; // ���� Ȩ
    public GameObject IronPlateDoor; // ����Ʈ�� ���� 
    public GameObject TroubleLine; // ������ ��
    public Animator smartFarmDoorAnim;



    [Header("<������ ī��Ű ã��>")]
    public GameObject CardPack; //ī����
    public GameObject EngineCardKey; // ������ ī�� Ű



    [Header("<������ �� ���� �Ϸ�>")]
    public Animator engineDoorAnim; // �������� �ִϸ��̼�
    public GameObject BrokenArea; // ������ ����
    public GameObject Conduction; // ����ü
    public GameObject EngineDoor; // ������ ��
    public GameObject InsertCardPad; // ī�� �е�

    [Header("<� ���� �Ϸ�>")]
    public Animator meteorBoxAnim; //  ������ �������� �ִϸ��̼�
    public Animator analyticalMachineAnim; // �м��� �������� �ִϸ��̼�
    public GameObject ImportantMeteor; // �߿� �
    public GameObject NormalMeteor1; // ����� �1



    /*Object Data*/
    public ObjectData MeteorButtonData_Save;
    public ObjectData MeteorCollectMachineData_Save;
    public ObjectData AnalyticalMachineData_Save;
    public ObjectData AnalyticalMachineButtonData_Save;

    /*Outline*/
    public Outline MeteorButtonOutline_Save;
    public Outline MeteorCollectMachineOutline_Save;
    public Outline AnalyticalMachineOutline_Save;
    public Outline AnalyticalMachineButtonOutline_Save;

    /*BoxCollider*/
    BoxCollider LineHome2_Collider;
    BoxCollider IronPlateDoor_Collider;

    BoxCollider BrokenArea_Collider;
    BoxCollider EngineDoor_Collider;
    BoxCollider InsertCardPad_Collider;



    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");


        /*����Ʈ�� ����*/
        LineHome2_Collider = LineHome2.GetComponent<BoxCollider>();
        IronPlateDoor_Collider = IronPlateDoor.GetComponent<BoxCollider>();

        /*������ ����*/
        BrokenArea_Collider = BrokenArea.GetComponent<BoxCollider>();
        EngineDoor_Collider = EngineDoor.GetComponent<BoxCollider>();
        InsertCardPad_Collider = InsertCardPad.GetComponent<BoxCollider>();




        /*����Ʈ�� ���� ������ �Ϸ� �ϸ�*/
        if (intialGameData.IsCompleteSmartFarmOpen)
        {
            LineHome2_Collider.enabled = false;
            IronPlateDoor_Collider.enabled = false;
            TroubleLine.SetActive(false);
            FixedLine2.SetActive(false);
            smartFarmDoorAnim.SetBool("FarmDoorMoving", true);
            smartFarmDoorAnim.SetBool("FarmDoorStop", true);
        }
         

        /*������ ī�� Ű ã�� ������ �Ϸ��ϸ�*/
        if (intialGameData.IsCompleteFindEngineKey)
        {
            CardPack.SetActive(false);
            EngineCardKey.SetActive(true);

        }
         

        /*������ ���� ������ �Ϸ��ϸ�*/
        if (intialGameData.IsCompleteOpenEngineRoom)
        {
            engineDoorAnim.SetBool("canEngineDoorOpen", true);
            engineDoorAnim.SetBool("canEngineDoorEnd", true);
            ChangeScene.SetActive(true);

            EngineCardKey.SetActive(false);
            Conduction.SetActive(false);

            BrokenArea_Collider.enabled = false;
            EngineDoor_Collider.enabled = false;
            InsertCardPad_Collider.enabled = false;
        }


        /*� ���� ������ �Ϸ��ϸ�*/
        if(intialGameData.IsInputNormalMeteor1_T_C2)
        {
            meteorBoxAnim.SetBool("isMeteorBoxClose", false);
            meteorBoxAnim.SetBool("isMeteorBoxCloseEnd", false);
            meteorBoxAnim.SetBool("isMeteorBoxOpen", true);
            meteorBoxAnim.SetBool("isMeteorBoxOpenEnd", true);


            analyticalMachineAnim.SetBool("isAnalyticalMachineOpen", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineOpenEnd", true);
            analyticalMachineAnim.SetBool("isAnalyticalMachineClose", false);
            analyticalMachineAnim.SetBool("isAnalyticalMachineCloseEnd", false);

            NormalMeteor1.SetActive(false);

            MeteorButtonData_Save.IsNotInteractable = true;
            MeteorButtonOutline_Save.OutlineWidth = 0;

            MeteorCollectMachineData_Save.IsNotInteractable = false;
            MeteorCollectMachineOutline_Save.OutlineWidth = 8;

            AnalyticalMachineButtonData_Save.IsNotInteractable = true;
            AnalyticalMachineButtonOutline_Save.OutlineWidth = 0;

            AnalyticalMachineData_Save.IsNotInteractable = false;
            AnalyticalMachineOutline_Save.OutlineWidth = 8;

        }
    }

}
