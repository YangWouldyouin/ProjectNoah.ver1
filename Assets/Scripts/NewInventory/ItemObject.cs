using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    /* prefab : �κ��丮 â�� ���̴� �̹��� */
    public GameObject prefab; // ItemObject ��
    public ItemType type; // ��ӹ���

    [TextArea(15, 20)]
    public string Description; // Ŭ�������� ���������� ���� �ִ� �κ�
}
