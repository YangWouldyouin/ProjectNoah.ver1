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
        // 스탯 리셋하고 싶을 때
        if (!SteamManager.Initialized)
        {
            return;
        }
        SteamUserStats.ResetAllStats(true);


        for (int i=0;i<8; i++)
        {
            // 행동 50번 업적 
            steamData.steam50Achieve[i] = 0;
            // 한번만 체크하면 되는 업적
            steamData.steamAchieveOnce[i] = false;
            // 음성 파일 모두 듣기 업적
            steamData.IsHearCheck[i] = false;
        }

        // 임무 3회 업적(생체보고, 사진찍기)
        for (int j=0; j<2; j++)
        {
            steamData.steamMission3Time[j] = 0;
        }

        // 첫 엔딩 업적, 5번째 엔딩 업적, day7 업적 한번에
        steamData.endingCount = 0;
        steamData.END_FAST_ENDING = false; // day7 업적 한번만 체크용
        steamData.hearCount = 0; //모든 음성 파일 듣기 업적
    }
}
