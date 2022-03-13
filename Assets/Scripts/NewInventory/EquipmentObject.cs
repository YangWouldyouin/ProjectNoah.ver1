using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "InventorySystem/Item/Equipment")]
public class EquipmentObject : ItemObject
{
    public float AttackBonus; // EquipmentObject : ItemObject로 만든 오브젝트들만 공통으로 갖는 변수
    public void Awake() // EquipmentObject 는 어차피 ItemType이 Equipment이므로 이렇게 하면 새 오브젝트를 만들때마다 새로 ItemType을 지정할 필요가 없다.
    {
        type = ItemType.Equipment;
    }
}
