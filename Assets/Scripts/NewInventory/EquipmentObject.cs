using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "InventorySystem/Item/Equipment")]
public class EquipmentObject : ItemObject
{
    public float AttackBonus; // EquipmentObject : ItemObject�� ���� ������Ʈ�鸸 �������� ���� ����
    public void Awake() // EquipmentObject �� ������ ItemType�� Equipment�̹Ƿ� �̷��� �ϸ� �� ������Ʈ�� ���鶧���� ���� ItemType�� ������ �ʿ䰡 ����.
    {
        type = ItemType.Equipment;
    }
}
