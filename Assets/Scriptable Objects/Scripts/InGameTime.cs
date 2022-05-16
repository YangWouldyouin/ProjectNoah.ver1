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
}
