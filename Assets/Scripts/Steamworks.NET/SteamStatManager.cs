using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamStatManager : MonoBehaviour
{
    public SteamAchieveData steamAchieveData;

    // Start is called before the first frame update
    void Start()
    {
        // 스탯 리셋하고 싶을 때
        // SteamUserStats.ResetAllStats(true); 
    }

    void Update()
    {
        if (!SteamManager.Initialized)
        {
            return;
        }

        if(steamAchieveData.barkCount==10)
        {
            Debug.Log("업적 완료");
            SteamUserStats.SetAchievement("ACT_BARK_50");
            SteamUserStats.StoreStats();
        }

        if (steamAchieveData.biteCount == 50)
        {
            Debug.Log("업적 완료");
            SteamUserStats.SetAchievement("ACT_BITE_50");
            SteamUserStats.StoreStats();
        }

        if (steamAchieveData.pressCount == 50)
        {
            Debug.Log("업적 완료");
            SteamUserStats.SetAchievement("ACT_PRESS_50");
            SteamUserStats.StoreStats();
        }
    }
}
