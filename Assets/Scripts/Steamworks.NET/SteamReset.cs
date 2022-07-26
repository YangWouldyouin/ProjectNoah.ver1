using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamReset : MonoBehaviour
{
    public SteamAchieveData steamData;
    // Start is called before the first frame update
    void Start()
    {
        // ���� �����ϰ� ���� ��
        if (!SteamManager.Initialized)
        {
            return;
        }
        SteamUserStats.ResetAllStats(true);


        for (int i=0;i<8; i++)
        {
            // �ൿ 50�� ���� 
            steamData.steam50Achieve[i] = 0;
            // �ѹ��� üũ�ϸ� �Ǵ� ����
            steamData.steamAchieveOnce[i] = false;
            // ���� ���� ��� ��� ����
            steamData.IsHearCheck[i] = false;
        }

        // �ӹ� 3ȸ ����(��ü����, �������)
        for (int j=0; j<2; j++)
        {
            steamData.steamMission3Time[j] = 0;
        }

        // ù ���� ����, 5��° ���� ����, day7 ���� �ѹ���
        steamData.endingCount = 0;
        steamData.END_FAST_ENDING = false; // day7 ���� �ѹ��� üũ��
        steamData.hearCount = 0; //��� ���� ���� ��� ����
    }
}
