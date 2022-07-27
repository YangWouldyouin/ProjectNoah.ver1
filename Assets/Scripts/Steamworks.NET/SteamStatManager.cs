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
        // 스탯 리셋하고 싶을 때
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

    /* 스팀업적 : 튜토 완료 */
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


    /* 스팀업적 : 건강검진 3회 */
    //SteamStatManager.steamAchieve3Time.Invoke(0, "EGG_HEALTH_DATA_3");

    /* 스팀업적 : 사진 3회 */
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

    /* 스팀업적 : 첫 엔딩 업적, 5번째 엔딩 업적, Day7 엔딩 업적 한번에 */
    //SteamStatManager.steamEndingCountAchieve?.Invoke();
    public void EndingCount()
    {
        steamAchieveData.endingCount += 1;
        switch(steamAchieveData.endingCount)
        {
            case 1:
                SteamUserStats.SetAchievement("END_FIRST_ENDING"); // 첫번째 엔딩 업적
                SteamUserStats.StoreStats();   
                
                if (inGameTime.days<7&& !steamAchieveData.END_FAST_ENDING)
                {
                    SteamUserStats.SetAchievement("END_FAST_ENDING"); // Day7 엔딩 업적 
                    SteamUserStats.StoreStats();
                    steamAchieveData.END_FAST_ENDING = true; // 한번만 체크되도록 
                }

                break;
            case 5:
                SteamUserStats.SetAchievement("END_FIFTH_ENDING"); // 다섯번째 엔딩 업적
                SteamUserStats.StoreStats();
                steamEndingCountAchieve -= EndingCount; // 이제 필요없으니까 델리게이트 삭제
                break;
            default:
                break;
        }
    }

    /* 스팀업적 : 모든 음성파일 듣기 */
    //SteamStatManager.steamNoahHearAchieve?.Invoke(0); // 0부터 7까지
    public void HearCount(int audioIndex)
    {
        if(!steamAchieveData.IsHearCheck[audioIndex]) // 음성파일 인덱스 0부터 7까지
        {
            steamAchieveData.hearCount += 1;
            steamAchieveData.IsHearCheck[audioIndex] = true;
        }

        if(steamAchieveData.hearCount==8) // 음성파일 8개 모두 들었으면
        {
            SteamUserStats.SetAchievement("EGG_NOAH_HEAR"); // 모든 음성파일 듣기 업적
            SteamUserStats.StoreStats();
            steamNoahHearAchieve -= HearCount; // 이제 필요없으니까 델리게이트 삭제
        }
    }
}