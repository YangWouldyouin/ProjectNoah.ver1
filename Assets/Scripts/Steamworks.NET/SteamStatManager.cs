using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using System;

public class SteamStatManager : MonoBehaviour
{
    public SteamAchieveData steamAchieveData;
    public InGameTime inGameTime;

    public static Action<int, string> steamAchieve1Time;
    public static Action<int, string> steamAchieve3Time;
    public static Action steamEndingCountAchieve;
    public static Action<int> steamNoahHearAchieve;

    void Start()
    {
        // ���� �����ϰ� ���� ��
        //if (!SteamManager.Initialized)
        //{
        //    return;
        //}
        //SteamUserStats.ResetAllStats(true);

        InteractionButtonController.steam50Achieve += Achieve50;
        steamAchieve1Time += AchieveEnding;
        steamAchieve3Time += mission3Time;
        steamEndingCountAchieve += EndingCount;
        steamNoahHearAchieve += HearCount;
    }

    void Update()
    {
        if (!SteamManager.Initialized)
        {
            return;
        }
    }

    public void Achieve50(int achieve50Index, string achieveName)
    {
        if (steamAchieveData.steam50Achieve[achieve50Index] < 50)
        {
            steamAchieveData.steam50Achieve[achieve50Index] += 1;
            if (steamAchieveData.steam50Achieve[achieve50Index] == 50)
            {
                SteamUserStats.SetAchievement(achieveName);
                SteamUserStats.StoreStats();
            }
        }
    }

    /* �������� : Ʃ�� �Ϸ� */
    //SteamStatManager.steamAchieve1Time.Invoke(0, "END_TUTORIAL_CLEAR");
    public void AchieveEnding(int achieveOnceIndex, string achieveName)
    {
        if(!steamAchieveData.steamAchieveOnce[achieveOnceIndex])
        {
            SteamUserStats.SetAchievement(achieveName);
            SteamUserStats.StoreStats();
            steamAchieveData.steamAchieveOnce[achieveOnceIndex] = true;
        }
    }


    /* �������� : �ǰ����� 3ȸ */
    //SteamStatManager.steamAchieve3Time.Invoke(0, "EGG_HEALTH_DATA_3");

    /* �������� : ���� 3ȸ */
    //SteamStatManager.steamAchieve3Time.Invoke(1, "EGG_PICTURE_3");

    public void mission3Time(int missionIndex, string achieveName)
    {
        if(steamAchieveData.steamMission3Time[missionIndex] <3)
        {
            steamAchieveData.steamMission3Time[missionIndex] += 1;
            if(steamAchieveData.steamMission3Time[missionIndex] == 3)
            {
                SteamUserStats.SetAchievement(achieveName);
                SteamUserStats.StoreStats();
            }
        }
    }

    /* �������� : ù ���� ����, 5��° ���� ����, Day7 ���� ���� �ѹ��� */
    //SteamStatManager.steamEndingCountAchieve?.Invoke();
    public void EndingCount()
    {
        steamAchieveData.endingCount += 1;
        switch(steamAchieveData.endingCount)
        {
            case 1:
                SteamUserStats.SetAchievement("END_FIRST_ENDING"); // ù��° ���� ����
                SteamUserStats.StoreStats();   
                
                if (inGameTime.days<7&& !steamAchieveData.END_FAST_ENDING)
                {
                    SteamUserStats.SetAchievement("END_FAST_ENDING"); // Day7 ���� ���� 
                    SteamUserStats.StoreStats();
                    steamAchieveData.END_FAST_ENDING = true; // �ѹ��� üũ�ǵ��� 
                }

                break;
            case 5:
                SteamUserStats.SetAchievement("END_FIFTH_ENDING"); // �ټ���° ���� ����
                SteamUserStats.StoreStats();
                steamEndingCountAchieve -= EndingCount; // ���� �ʿ�����ϱ� ��������Ʈ ����
                break;
            default:
                break;
        }
    }

    /* �������� : ��� �������� ��� */
    //SteamStatManager.steamNoahHearAchieve?.Invoke(0); // 0���� 7����
    public void HearCount(int audioIndex)
    {
        if(!steamAchieveData.IsHearCheck[audioIndex]) // �������� �ε��� 0���� 7����
        {
            steamAchieveData.hearCount += 1;
            steamAchieveData.IsHearCheck[audioIndex] = true;
        }

        if(steamAchieveData.hearCount==8) // �������� 8�� ��� �������
        {
            SteamUserStats.SetAchievement("EGG_NOAH_HEAR"); // ��� �������� ��� ����
            SteamUserStats.StoreStats();
            steamNoahHearAchieve -= HearCount; // ���� �ʿ�����ϱ� ��������Ʈ ����
        }
    }
}