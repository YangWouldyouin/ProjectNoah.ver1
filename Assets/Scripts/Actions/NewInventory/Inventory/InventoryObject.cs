using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        // 나중에 딕셔너리로 바꿀 것임
        bool hasItem = false;
        for(int i =0; i<Container.Count; i++) // 컨테이너 안의 모든 아이템과 비교
        {
            if(Container[i].item == _item) // 컨테이너에 있는 아이템이면
            {
                Container[i].AddAmount(_amount); // 개수만 추가
                hasItem = true;
                break;
            }
        }
        if(!hasItem) // 현재 컨테이너에 없는 새로운 아이템이면
        {
            Container.Add(new InventorySlot(_item, _amount)); // Add : 리스트 추가 함수?? 
        }


    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount) /* 새 아이템의 정보와 개수를 추가하는 메서드 */
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value) // 원래 있던 아이템의 개수만 value 만큼 늘리는 메서드
    {
        amount += value;
    }
}
