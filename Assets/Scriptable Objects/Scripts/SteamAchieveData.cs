using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SteamAchieveData : ScriptableObject
{
    /* �ൿ 50�� ���� */
    public int[] steam50Achieve = new int[8];
    //[Header("�п��ո�")]
    //public int barkCount; // 0
    //[Header("��... �Կ� �װ� ����")]
    //public int biteCount; // 1
    //[Header("�� ��� �չ�, �չ� ��� ��")]
    //public int pressCount; // 2
    //[Header("ůīůī")]
    //public int smellCount; //3
    //[Header("�� �԰� ���� �ϴ� ��")]
    //public int eatCount; //4
    //[Header("�⹰ �ļ�")]
    //public int destroyCount; //5
    //[Header("������ ��� ����")]
    //public int observeCount; // 6
    //[Header(" ��� �屸")]
    //public int upCount; // 7

    /* �ѹ��� üũ�ϸ� �Ǵ� ���� */
    public bool[] steamAchieveOnce = new bool[8];
    //public bool END_TUTORIAL_CLEAR; // 0
    //public bool END_TUTORIAL_FAIL; // 1
    //public bool END_SUDDEN_DEATH; // 2
    //public bool EGG_WHO_ARE_YOU; // 3
    //public bool EGG_ONLY_US;  // 4
    //public bool EGG_POTION_DETECTION; // 5
    //public bool EGG_WRONG_FOOD; // 6
    //public bool EGG_METEOR_3; // 7

    /* �ӹ� 3ȸ ���� */
    public int[] steamMission3Time = new int[2];
    //public int healthDataCount; /* ��ü ���� 3ȸ */
    //public int pictureCount; /* ���� ��� 3ȸ */
    //public bool EGG_HEALTH_DATA_3;
    //public bool EGG_PICTURE_3;

    /* ù ���� ����, 5��° ���� ����, day7 ���� �ѹ��� */
    public int endingCount;
    //public bool END_FIRST_ENDING;
    //public bool END_FIFTH_ENDING;
    public bool END_FAST_ENDING; // day7 ���� �ѹ��� üũ

    /* ��� ���� ���� ��� ���� */
    public int hearCount;
    public bool[] IsHearCheck = new bool[8]; // �ߺ� ��� ī��Ʈ ����
    //public bool EGG_NOAH_HEAR;
}
