using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameManager : MonoBehaviour
{
    // ���� �����ϰ� ���� �ʱ�ȭ

    // �ݶ��̴�
    // �ƿ�����

    /* �� ������ ���� �ʱ�ȭ */
    public PortableObjectData controlData;
    public PortableObjectData workData;
    public PortableObjectData engineData;
    public PortableObjectData livingData;

    /* ����, ��¥, ���� �б� �ʱ�ȭ */
    public InGameTime inGameTime;
    public PlayerEquipment equipment;

    public ObjectData[] objectList;

    //public ObjectData[] controlObjectList;
    //public ObjectData[] workObjectList;
    //public ObjectData[] engineObjectList;
    //public ObjectData[] livingObjectList;

    /* �������� ������Ʈ������ �ʱ�ȭ */
    public ObjectData healthMachinePartData; // ����üũ���
    public ObjectData engineDoorData; // ��������-������ �� 
    public ObjectData engineKeyData; // ��������-������ ī��Ű

    /* ��Ȱ���� ������Ʈ������ �ʱ�ȭ */
    public ObjectData trashBodyData;
    public ObjectData trashPartData;
    private void Start()
    {
        //ClearObjectData();
        RestIngameData();
        ResetPortableObject();
        ResetWorkRoomObjectData();
        ResetLivingRoomObjectData();
    }

    void RestIngameData()
    {
        inGameTime.days = 0;
        inGameTime.hours = 0;
        inGameTime.timer = 0;

        inGameTime.IsTimerStarted = false;
        inGameTime.maxTimer = 0;

        inGameTime.IsNoahOutlineTurnOn = false;
        inGameTime.outlineTimer = 0;

        inGameTime.missionTimer = 0;

        inGameTime.statNum = 10;
        inGameTime.statTimer = 0;

        equipment.biteObjectName = "";
        equipment.pushObjectName = "";
    }

    void ResetPortableObject()
    {
        for(int i=0; i<59; i++)
        {
            controlData.IsObjectActiveList[i] = false;
            workData.IsObjectActiveList[i] = false;
            engineData.IsObjectActiveList[i] = false;
            livingData.IsObjectActiveList[i] = false;
        }

        /* ������ �ʱ�ȭ */
        controlData.IsObjectActiveList[0] = true;
        controlData.IsObjectActiveList[1] = true;

        /* ������ �ʱ�ȭ */
        engineData.IsObjectActiveList[3] = true;
        engineData.IsObjectActiveList[5] = true;
        engineData.IsObjectActiveList[6] = true;
        engineData.IsObjectActiveList[8] = true;
        engineData.IsObjectActiveList[9] = true;
        engineData.IsObjectActiveList[39] = true;
        engineData.IsObjectActiveList[40] = true;
        engineData.IsObjectActiveList[58] = true;

        /* ��Ȱ���� �ʱ�ȭ */
        livingData.IsObjectActiveList[2] = true;
        livingData.IsObjectActiveList[7] = true;
        livingData.IsObjectActiveList[46] = true;
        livingData.IsObjectActiveList[47] = true;
        livingData.IsObjectActiveList[48] = true;
        livingData.IsObjectActiveList[49] = true;

        /* �������� �ʱ�ȭ */
        workData.IsObjectActiveList[4] = true;
        workData.IsObjectActiveList[10] = true;
        workData.IsObjectActiveList[11] = true;
        workData.IsObjectActiveList[12] = true;
        workData.IsObjectActiveList[13] = true;
        workData.IsObjectActiveList[14] = true;

        for (int k = 24; k < 32; k++)
        {
            workData.IsObjectActiveList[k] = true;
        }

        for (int q = 0; q < 5; q++)
        {
            workData.IsObjectActiveList[q+33] = true;
            workData.IsObjectActiveList[q+41] = true;
        }

        for(int j= 50; j<58; j++)
        {
            workData.IsObjectActiveList[j] = true;
        }
    }



    void ResetWorkRoomObjectData()
    {
        healthMachinePartData.IsNotInteractable = false; // ����üũ��� ��ǰ
        engineDoorData.IsNotInteractable = false; // ������ ��
        engineKeyData.IsNotInteractable = false; // ������ ī��Ű
        engineKeyData.IsBite= false; 
    }

    void ResetLivingRoomObjectData()
    {
        trashBodyData.IsNotInteractable = false; // ���� ���
        trashPartData.IsNotInteractable = false; // ���� ��ǰ
    }

    public void ClearObjectData()
    {
        for(int i=0; i<objectList.Length; i++)
        {
            objectList[i].IsBark = false;
            objectList[i].IsPushOrPress = false;
            objectList[i].IsSniff = false;
            objectList[i].IsBite = false;
            objectList[i].IsSmash = false;
            objectList[i].IsUpDown = false;
            objectList[i].IsEaten = false;
            objectList[i].IsInsert = false;
            objectList[i].IsEaten = false;
            objectList[i].IsObserve = false;
            objectList[i].IsCollision = false;

            objectList[i].IsClicked = false;
            objectList[i].IsCenterButtonChanged = false;
            objectList[i].IsCenterButtonDisabled = false;
            objectList[i].IsCenterPlusButtonDisabled = false;
            objectList[i].IsNotInteractable = false;
        }
    }


    public  void ResetTutorialData()
    {

    }

    public void ResetControlData()
    {
        objectList[0].IsNotInteractable = true; // AI ��ư

        objectList[1].IsNotInteractable = true; // ������ ��
        objectList[1].IsCenterButtonDisabled= true;

        objectList[5].IsNotInteractable = true; // ��Ʈ ��

        objectList[7].IsNotInteractable = true; // ��Ʈ ��

        objectList[9].IsNotInteractable = true; // ��Ʈ ��

        // �巯�׹�, ������ �¾�Ƽ��
    }


}
