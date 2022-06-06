using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class InGameTime : ScriptableObject
{
    public float days;
    public float hours;
    public float timer;

    public float missionTimer;
    public float maxTimer;
    public bool IsTimerStarted;

    public bool IsNoahOutlineTurnOn;
    public float outlineTimer;

    public int statNum;
    public float maxStatTimer;
    public float statTimer;

    public bool IsNoSeeFail1; // ��ȭ�� 1
    public bool IsNoSeeFail2; // ��ȭ�� 2

    public bool IsPretendDeadFail1; // ��Ŀ

    public bool IsMissionStart;
    public bool IsMissionClear;

    public bool IsGoToEarthMissionStart;
    public bool IsGoToEarthMissionClear;
}
