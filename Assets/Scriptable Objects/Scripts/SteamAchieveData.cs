using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SteamAchieveData : ScriptableObject
{
    [Header("왈월왕멍")]
    public int barkCount;
    [Header("너... 입에 그거 뭐야")]
    public int biteCount;
    [Header("손 대신 앞발, 앞발 대신 코")]
    public int pressCount;
    [Header("킁카킁카")]
    public int smellCount;
    [Header("다 먹고 살자 하는 일")]
    public int eatCount;
    [Header("기물 파손")]
    public int destroyCount;
    [Header("전지적 노아 시점")]
    public int observeCount;
    [Header(" 등반 욕구")]
    public int upCount;
}
