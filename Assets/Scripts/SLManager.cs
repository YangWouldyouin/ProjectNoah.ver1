using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SLManager : MonoBehaviour
{
    void Update()
    {
        /* ���� ���� */
        if (Input.GetKeyDown("s"))
        {
            GameData character = new GameData();
            character.statNum = 10;
            character.IsAIAwake_M_C1 = false;
            character.IsCWDoorOpened_M_C1 = false;
            character.IsHealthMachineFixed_T_C2 = false;
            character.IsSmartFarmOpen_T_C2 = false;
            character.S_IsAIAwake_M_C1 = false;
            character.ActiveMissionList[0] = false;
            character.ActiveMissionList[3] = false;
            character.IsTabletUnlock = false;
            //character.IsBasicTuto = false;
            character.IsMiddleTuto = false;
            //character.statNum = 10;



            //�ӹ� �����ϱ� ��� ī��Ʈ, 3�� �̻� ����ϱ� ������ ���� ����
            character.IsReportCancleCount = 0;
            //AI ��� �ӹ� ī��Ʈ, 2 �̻� �� �� �º� �˵� ��ǥ �ر�
            character.IsAIVSMissionCount = 0;

            character.EndingNum = 0;

            /*������ ���� ���̵�����*/
            character.IsFakefatigue = 91; //�����Ƿε�
            character.IsFakeStrength = 87; //����ü��
            character.IsFakeThirst = 84; //���̸񸶸�
            character.IsFakeHunger = 88; //���̹����

            /*������ ���� ���� ������*/
            character.IsRealfatigue = 0; //�Ƿε�
            character.IsRealStrength = 0; //ü��
            character.IsRealThirst = 0; //�񸶸�
            character.IsRealHunger = 0; //�����

            character.IscurrentHealthData = 0; //������ǻ�Ϳ��� ����ϴ� ���� ��ġ


            /* �ӹ� ���� ���� (���ϸ�Ͽ� ������ �ƴ���) */
            character.S_IsAIAwake_M_C1 = false; // �׻� AI Ȱ��ȭ  
            character.S_IsCWDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����
            character.S_IsHealthMachineFixed_T_C2 = false; // ���������� ���� ���� �ӹ� ���� ���� 
            character.ActiveMissionList[0] = false;
            character.ActiveMissionList[1] = false;
            character.ActiveMissionList[2] = false;
            character.ActiveMissionList[3] = false;
            character.ActiveMissionList[4] = false;

            character.EndMissionList[0] = false;
            character.EndMissionList[1] = false;
            character.EndMissionList[2] = false;
            character.EndMissionList[3] = false;
            character.EndMissionList[4] = false;


            /* 1ȸ�� �ӹ� */
            character.IsAIAwake_M_C1 = false; // �׻� AI Ȱ��ȭ  
            character.IsCWDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����

            character.IsHealthMachineFixed_T_C2 = false; // ���������� ���� ���� �ӹ� ���� ����   
            character.IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����

            character.IsWEDoorOpened_M_C2 = false; // �׻� ������������ ������ �̵� ����

            character.IsWLDoorHalfOpened_M_C2 = false; // �׻� ������������ ��Ȱ���� �̵� ����. ��, ���� �ݸ� ����ä��
            character.IsWLDoorOpened_M_C2 = false; // �׻� ������������ ��Ȱ���� �̵� ����

            character.IsAllDoorOpened = false; //��� ������ �ر� �Ϸ�Ǿ�����

            //���� ���� üũ
            character.IsFirstEnterWorking = false; //�������� ���� ���� Ȯ��
            character.IsFirstEnterEngine = false; //������ ���� ���� Ȯ��
            character.IsFirstEnterLiving = false; //��Ȱ���� ���� ���� Ȯ��
            character.IsFirstExitTablet = false; //�簢���� ó������ �������� ��

            character.IsFirstNoticeEnd = false; //������üũ ���� üũ

            character.afterFirstTalk = false; //���� �Ϸ� �� ����ũ�� AI�� ��ȭ���� ��� ���� ��
            character.afterNewsTalk = false; //���� �˾� & ���ֺ���� ���� ��ȭ�� ���� ��


            //����Ž�� ����
            character.IsCheckDrug = false; //������ ���� Ȯ��
            character.IsDetox = false; //���� �ص�


            //�����ѹ��� & AI �ٿ� ����
            character.IsFirstUsingStrangeObj = false; //������ ���� ����غ� �� �ִ���
            character.IsHide = false; //��ȭ��(��ȸ��) ��� �� ���ڽ� ȿ��
            character.IsAlert = false; //���ڽ� ��尡 �ƴѵ� Ĩ ���� ���νý��ۿ� ���� ��
            character.IsAIDown = false; //����Ĩ ���� �� AI �ٿ� ��

            character.IsFuelabsorberFixed_E_E1 = false; //������ ��ġ�� �ӹ�, �ر��ؾ� ���� ���� �ӹ� ���� ����

            character.HealthMachineCancelCount = 5;

            character.IsEngineDoorFix_M_C2 = false; // ������ �� ���ƴ���

            //� ���� ����
            character.IsIsReallySmellDone_T_C2 = false; // � ������ �þҴ���
            character.IsReportImportantMeteor_T_C2 = false; // �߿� ��� �м��⿡ �־���

            // ����Ʈ�� ����
            character.IsIronDisappear_T_C2 = false; // ����Ʈ�� ������ �� ��������

            character.IsOutTroubleLine2_T_C2 = false; // ����Ʈ�� ������ ���� ���´���
            character.IsSmartFarmFix_T_C2 = false;//����Ʈ�� ������ �Ϸ�


            // � ����
            character.IsBiteimportantMeteor_T_C2 = false; // �߿� ��� ��������
            character.IsBiteNormalMeteor1_T_C2 = false; // �Ϲ� ��� ��������

            character.IsAnswerInBeaker1_M_C2 = false; // ��Ŀ 1�� �´� ��� �־�����
            character.IsAnswerInBeaker2_M_C2 = false; // ��Ŀ 2�� �´� ��� �־�����

            character.IsAnswerBeakerColorChange1_M_C2 = false; // ���� �� ������ ��Ŀ 1 ���� ��ȭ
            character.IsWrongBeakerColorChange1_M_C2 = false; // Ʋ�� �� ������ ��Ŀ 1 ���� ��ȭ
            character.IsNoNeed1BeakerColorChange1_M_C2 = false; // �ʿ���� ��1 ������ ��Ŀ 1 ���� ��ȭ
            character.IsNoNeed2BeakerColorChange1_M_C2 = false; // �ʿ���� ��2 ������ ��Ŀ 1 ���� ��ȭ

            character.IsAnswerBeakerColorChange2_M_C2 = false; // ���� �� ������ ��Ŀ 2 ���� ��ȭ
            character.IsWrongBeakerColorChange2_M_C2 = false; // Ʋ�� �� ������ ��Ŀ 2 ���� ��ȭ
            character.IsNoNeed1BeakerColorChange2_M_C2 = false; // �ʿ���� ��1 ������ ��Ŀ 2 ���� ��ȭ
            character.IsNoNeed2BeakerColorChange2_M_C2 = false; // �ʿ���� ��2 ������ ��Ŀ 2 ���� ��ȭ


            // �º� UI ����
            character.Is_Tablet_WirelessOn = false; //�º� ������� on/offüũ
            character.IsFakeHealthData_Tablet = false; //�º� ������ ���� ���� ������
            character.IsFakeCoordinateData_Tablet = false; //�º�������ǥ�ر� �Ǵ�
            character.IsFakeCoordinateDatafile_Tablet = false; //�º�������ǥ�ٿ�ε� �Ǵ�
            character.IsDontFakeCoordinateDatafile_Tablet = false; //�º� ������ǥ�ٿ�ε��Ʈ �Ұ�

            // ������ǻ�� UI ����
            character.Is_MainComputer_WirelessOn = false; //������ǻ�� ���Ʈ�� on/offüũ
            character.IsFinalBusinessReport_MC = false; //���� ���� ���� ������ �ر� �Ǵ�
            character.IsFinalBusinessReportFile_MC = false; //���� ���� ���� ������ �ٿ�ε�


            // ���νý��� UI ����
            character.Is_MainSystem_WirelessOn = false; //���νý��� ���Ʈ�� on/offüũ
            character.IsCanConnect_C_MS = false; //���νý��� ������� ���� üũ 
            character.IsReturnOfTheEarth = false;//�˵� ���� ����


            // �º� �ر� ����
            character.IsFullChargeTablet = false; // �º� ��������  
            character.IsNoBoxes = false; // ������ �ڽ� ������
            character.IsTabletMoved = false; // �º� AI �̰��� �������� ����� ��
            character.IsTabletDestory = false; // �º� �ı�

            // ���� ����
            character.sweetPotatoEat[0] = false; //���� ���� �� Ȯ��
            character.sweetPotatoEat[1] = false;
            character.sweetPotatoEat[2] = false;
            character.sweetPotatoEat[3] = false;
            character.sweetPotatoEat[4] = false;
            character.sweetPotatoEat[5] = false;
            character.sweetPotatoEat[6] = false;
            character.sweetPotatoEat[7] = false;
            character.sweetPotatoEat[8] = false;
            character.sweetPotatoEat[9] = false;
            character.sweetPotatoEat[10] = false;
            character.sweetPotatoEat[11] = false;
            character.sweetPotatoEat[12] = false;
            character.sweetPotatoEat[13] = false;



            character.Pot1InPotato = false; // ����1�� ���� ������ Ȯ��
            character.Pot2InPotato = false; // ����2�� ���� ������ Ȯ��
            character.Pot3InPotato = false; // ����3�� ���� ������ Ȯ��
            character.IsCanSeePotato1 = false; // ������ ��Ÿ��ä�� ����
            character.IsCanSeePotato2 = false; // ������ ��Ÿ��ä�� ����
            character.IsCanSeePotato3 = false; // ������ ��Ÿ��ä�� ����

            character.Pot1InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��
            character.Pot2InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��
            character.Pot3InBadPotato = false; // ����1�� ���� ���� ������ Ȯ��

            character.Pot1InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��
            character.Pot2InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��
            character.Pot3InHealthyPotato = false; // ����1�� �ǰ��� ���� ������ Ȯ��

            //���� ���� �� Ȯ��
            character.BadFoodEat[0] = false;
            character.BadFoodEat[1] = false;
            character.BadFoodEat[2] = false;
            character.BadFoodEat[3] = false;
            character.BadFoodEat[4] = false;
            character.BadFoodEat[5] = false;
            character.BadFoodEat[6] = false;
            character.BadFoodEat[7] = false;
            character.BadFoodEat[8] = false;
            character.BadFoodEat[9] = false;
            character.BadFoodEat[10] = false;
            character.BadFoodEat[11] = false;
            character.BadFoodEat[12] = false;
            character.BadFoodEat[13] = false;



            //���� ���� �� Ȯ��
            character.GoodFoodEat[0] = false;
            character.GoodFoodEat[1] = false;
            character.GoodFoodEat[2] = false;
            character.GoodFoodEat[3] = false;
            character.GoodFoodEat[4] = false;
            character.GoodFoodEat[5] = false;
            character.GoodFoodEat[6] = false;
            character.GoodFoodEat[7] = false;
            character.GoodFoodEat[8] = false;
            character.GoodFoodEat[9] = false;
            character.GoodFoodEat[10] = false;
            character.GoodFoodEat[11] = false;
            character.GoodFoodEat[12] = false;
            character.GoodFoodEat[13] = false;



            // ������� ��
            character.IsMeteorCollectClose = false; //� ������ �� �������� Ȯ��
            character.IsMeteorCollectOpen = false; // � ������ �� ���ȴ��� Ȯ��


            // ��Ȱ���� ���� �ر�
            character.IsLivingRoomDollOut = false; // ��Ȱ���� ���� �����ִ� ���� ����


            /*�߿� ���� �º��� AI���� ������ ���*/
            // character.IsTabletDestroyed; // �º� AI���� ���� �ı���



            /*�������*/
            character.IsStartCollectMeteorites = false; // � ���� �ӹ� ����
            character.IsStartPretendDead = false; // ����ô �ϱ� �ӹ� ����
            character.IsStartFIndDrug = false; //����ã�� �ӹ� ����
            character.IsFindStrangeObj = false; //�̻��ѹ���(��ȭ��) ���� �þҴ���
            character.IsStartToReady = false; //����� ���� �غ� ���� (��ݵ� �ӹ� 2�� �̻� ���� ��/���� ���� ��ũ��Ʈ �ʿ�)
            character.IsStartOrbitChange = false; //'AI �ٿ�' Ȥ�� '���� ô �ϱ�' ���� �Ϸ� �� �ڵ� ���� (ä���� ����ô�ϱ� ���� �Ϸ� ������ �ش� ���� �߰����ֶ�~)

            /*����Ϸ�*/
            character.IsBasicTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ�
            character.IsMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ���� �Ϸ� Ȯ��
            character.IsRealMiddleTuto = false; //Ʃ�丮�� �� ��Ʈ ��¥ �Ϸ�
            character.IsEndTuto = false; //Ʃ�丮�� ���� �Ϸ�
            character.IsCompleteSmartFarmOpen = false; // ����Ʈ�� ���� ���� �Ϸ�
            character.IsCompleteFindEngineKey = false; // ������ ī��Ű ã�� ���� �Ϸ�
            character.IsCompleteOpenEngineRoom = false; // ������ ���� ���� �Ϸ�
            character.IsInputNormalMeteor1_T_C2 = false; // �Ϲ� �1�� �����⿡ �ֱ� �Ϸ� (���߿� ������ �� �������� �ٲ�߰ڴ�)
            character.IsCompletePretendDead = false; // ����ô ���� �Ϸ�
            character.IsTabletUnlock = false; // �º� ��ݿ��� (�رݿϷ�)
            character.IsPlanetInsertChip_In = false; // �ùٸ� ����Ĩ �Ⱦ� ��¥ �༺ ������ ��ȯ
            character.IsAIDown_M_C1C3 = false; //AI�ٿ� ���� �Ϸ�
            character.IsKnowUsingSObj = false; //��ȭ�� ��� ����� �˾Ƴ´���
            character.IsFindDrugDone_T_C2 = false; //���� ���� Ȥ�� �ص��ϸ� �ٽ� ����
            character.IsCompleteFindLivingKey = false; // ��Ȱ���� ī��Ű ã�� �Ϸ�
            character.IsCompleteHalfOpenLivingRoom = false; // ��Ȱ���� �� �ݸ� ���� �Ϸ�

            character.IsDummyDataReport = false; //���̵����ͺ��� �Ϸ�
            character.IsAIVSMissionFinish = false; //��ݵ� ���� �ر�
            character.IsPhotoMissionFinish = false; //������� ���� �Ϸ�
            character.IsRevisioncomplaint = false; //����ϱ�

            character.IsCompleteOpenLivingRoom = false; // ��Ȱ���� �� ���� ���� �Ϸ�
            character.IsTrashDoorBTFixed_L_L1 = false; //��Ȱ���� ��ġ��

            //character.randomUPic = false;

            /*����*/
            character.IsInputImportantMeteorEnd = false; // Ư�� � ���� ����
            character.IsMakeForestEnd = false; // ���°� ���� ����
            character.IsDefyMissionEnd = false; // ��� �Һ��� ����: �����ϱ� ���� Ƚ�� �ź�
            character.IsDisqualifiedEnd = false; // ������� ����: Ʃ�丮�� ����
            character.IsDiscardNoahEnd = false; // ����ü ��� ����: AI ����� �ð� �ȿ� �˵� ���� ����
            character.IsSaveOnlyOneEnd = false; // ����� ���� �ϳ� ����: ��� ����, ��� X
            character.IsSaveAllEnd = false; // ����� ���� ���� ����: �� ����, ��� O

            character.IsManagerAbilityLack = false; //��������������

            character.IsSuddenDeath = false; //������ üũ: ���� 0 ����, ���� ���� ���� ����

            character.IsEatBadPotato = false;//���� ���� ���� ����













            SaveSystem.Save(character, "save_001");
        }

        /* ���� ���� �ҷ��� *//*
        if (Input.GetKeyDown("l"))
        {
            GameData loadData = SaveSystem.Load("save_001");
            Debug.Log(string.Format("LoadData Result => IsAIAwake : {0}, IsCWDoorOpened : {1}, IsHealthMachineFixed_T_C2 : {2}, IsSmartFarmOpen_T_C2 : {3} ", 
                loadData.IsAIAwake_M_C1, loadData.IsCWDoorOpened_M_C1, loadData.IsHealthMachineFixed_T_C2, loadData.IsSmartFarmOpen_T_C2));
        }*/
    }
}




//GameData character = new GameData(false, false);
//SaveSystem.Save(character, "save_001");