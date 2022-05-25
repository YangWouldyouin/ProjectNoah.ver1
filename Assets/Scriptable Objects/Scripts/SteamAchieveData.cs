using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SteamAchieveData : ScriptableObject
{
    [Header("�п��ո�")]
    public int barkCount;
    [Header("��... �Կ� �װ� ����")]
    public int biteCount;
    [Header("�� ��� �չ�, �չ� ��� ��")]
    public int pressCount;
    [Header("ůīůī")]
    public int smellCount;
    [Header("�� �԰� ���� �ϴ� ��")]
    public int eatCount;
    [Header("�⹰ �ļ�")]
    public int destroyCount;
    [Header("������ ��� ����")]
    public int observeCount;
    [Header(" ��� �屸")]
    public int upCount;
}
