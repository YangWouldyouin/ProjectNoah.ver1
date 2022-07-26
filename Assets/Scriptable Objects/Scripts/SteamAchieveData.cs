using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SteamAchieveData : ScriptableObject
{
    /* 행동 50번 업적 */
    public int[] steam50Achieve = new int[8];
    //[Header("왈월왕멍")]
    //public int barkCount; // 0
    //[Header("너... 입에 그거 뭐야")]
    //public int biteCount; // 1
    //[Header("손 대신 앞발, 앞발 대신 코")]
    //public int pressCount; // 2
    //[Header("킁카킁카")]
    //public int smellCount; //3
    //[Header("다 먹고 살자 하는 일")]
    //public int eatCount; //4
    //[Header("기물 파손")]
    //public int destroyCount; //5
    //[Header("전지적 노아 시점")]
    //public int observeCount; // 6
    //[Header(" 등반 욕구")]
    //public int upCount; // 7

    /* 한번만 체크하면 되는 업적 */
    public bool[] steamAchieveOnce = new bool[8];
    //public bool END_TUTORIAL_CLEAR; // 0
    //public bool END_TUTORIAL_FAIL; // 1
    //public bool END_SUDDEN_DEATH; // 2
    //public bool EGG_WHO_ARE_YOU; // 3
    //public bool EGG_ONLY_US;  // 4
    //public bool EGG_POTION_DETECTION; // 5
    //public bool EGG_WRONG_FOOD; // 6
    //public bool EGG_METEOR_3; // 7

    /* 임무 3회 업적 */
    public int[] steamMission3Time = new int[2];
    //public int healthDataCount; /* 생체 보고 3회 */
    //public int pictureCount; /* 사진 찍기 3회 */
    //public bool EGG_HEALTH_DATA_3;
    //public bool EGG_PICTURE_3;

    /* 첫 엔딩 업적, 5번째 엔딩 업적, day7 업적 한번에 */
    public int endingCount;
    //public bool END_FIRST_ENDING;
    //public bool END_FIFTH_ENDING;
    public bool END_FAST_ENDING; // day7 업적 한번만 체크

    /* 모든 음성 파일 듣기 업적 */
    public int hearCount;
    public bool[] IsHearCheck = new bool[8]; // 중복 듣기 카운트 방지
    //public bool EGG_NOAH_HEAR;
}
