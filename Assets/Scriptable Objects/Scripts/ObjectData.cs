using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ObjectData :ScriptableObject
{
    [Header("< ��ȣ�ۿ� �� �ٲ�� ������ ��� (��ҿ� �ǵ帮�� x) >")]
    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsSmash = false;
    public bool IsUpDown = false;
    public bool IsEaten = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsCollision = false; // å�� �ö󰡷��� �߰��� ���̴�. UpUP, M_C2_FindEnginespaceKey �ڵ� ����

    internal T GetComponent<T>()
    {
        throw new NotImplementedException();
    }

    public bool IsClicked = false;

    public bool IsCenterButtonChanged = false;
    public bool IsCenterButtonDisabled = false; // true�� ù ��° ��� ��ư ��Ȱ��ȭ
    public bool IsCenterPlusButtonDisabled = false; // true�� �� ��° ��� ��ư ��Ȱ��ȭ
    public bool IsNotInteractable = false;
}
