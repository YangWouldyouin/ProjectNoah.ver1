using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    /* 1ȸ�� �ӹ� ( �ѹ� ������ �ٽ� ���� ) */
    public bool IsAI_M_C1 = false; // �׻� AI Ȱ��ȭ
    public bool IsCockpitDoorOpened_M_C1 = false; // �׻� �����ǿ��� �������� �̵� ����

    public bool IsHealthMachineFixedT_C2 = false; // ���������� ���� ���� �ӹ� ���� ����
    public bool IsSmartFarmOpen_T_C2 = false; // �׻� ����Ʈ�� �����ְ�, ���������� ����Ʈ�� �ӹ� ���� ����



    /* ���� �ӹ� ( ���� �ð��� ������ �ٽ� false �� �ٲ� �ٽ� �ؾ��� ) */
    public bool IsHealthMachineDone = false;
    public bool IsSmartFarmMissionDone = false;



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
