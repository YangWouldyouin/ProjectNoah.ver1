using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    /* 1ȸ�� �ӹ� ( �ѹ� ������ �ٽ� ���� ) */
<<<<<<< HEAD
    public bool IsAI_M_C1 = false; // ������ AI �׻� Ȱ��ȭ
    public bool IsCockpitDoorOpened_M_C1 = false; // ������ �뼺 �����ǿ��� �������� �̵� ����
    public bool IsHealthMachineFixedT_C2 = false; // ������ �׻� ���� ���� ��� �̿� ����
    public bool IsSmartFarmOpen_T_C2 = false; // ������ �׻� ����Ʈ�� �̿� ����
=======
    public bool IsAI_M_C1 = false; // �׻� AI Ȱ��ȭ
    public bool IsCockpitDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����
    public bool IsHealthMachineFixedT_C2 = false; // ���������� ���� ���� �ӹ� ���� ����
    public bool IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc



    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */
<<<<<<< HEAD
    public bool IsHealthMachineDone = false; // ���� üũ ����
    public bool IsSmartFarmMissionDone = false; // ����Ʈ�� ����
=======
    public bool IsHealthMachineDone = false;
    public bool IsSmartFarmMissionDone = false;
>>>>>>> 0fcac82fd1d521c5a68db0b2b9da975fdb053afc



    public static int Hp = 100;
    public bool isBark = false;



    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        if(IsCockpitDoorOpened_M_C1) // playerpref �� �����ϱ� 
        {
            // ������ - �������� �̵� ����
        }

    }


    private void Update()
    {
        if(isBark == true) // ¢����
        {
            Hp -= 10;
            isBark = false;
        }



        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log("ü��: " + Hp);
        //    //Debug.Log("isPush : " + isPush);
        //}
    }
}
