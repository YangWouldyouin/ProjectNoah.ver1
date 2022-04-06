//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Inventory", menuName = "Custom Data/Inventory Data")]

//public class Inventory : ScriptableObject
//{
//    [SerializeField] ItemDatabase itemDatabase; // 아이템 데이터베이스의 오브젝트를 가져올 레퍼런스
//    [SerializeField] List<Item> inventory = new List<Item>();

//    /* 인벤토리에 아이템을 추가하는 메서드 */
//    public void AddItem(Item item)
//    {
//        inventory.Add(item); // 인벤토리 리스트에 item 추가
//    }

//    // ItemDatabase 스크립트의 itemsNames 에 List<string> 까지 가져오기 위해 필요 (objectReferenceValue는 object 로만 가져와짐 )
//    public ItemDatabase ItemDatabase { get { return itemDatabase; } }

//    // 인벤토리의 아이템과 같은 아이템인지 ID 로 비교하고 아이템의 개수를 반환
//    public int CheckAmount(Item item)
//    {
//        for (int i = 0; i < inventory.Count; i++) // List 는 Count 로 개수 가져옴
//        {
//            if (inventory[i].ItemId == item.ItemId)
//            {
//                if (inventory[i].AllowMultiple)
//                {
//                    return inventory[i].Amount; // 인벤토리의 i 번째 아이템의 개수 반환
//                }
//                else
//                {
//                    return 1; // AllowMultiple 이 거짓이므로 이 아이템은 무조건 1개만 있음
//                }
//            }
//        }
//        return 0; // 인벤토리에 item 이 없으므로 0 반환
//    }

//    public void ModifyItemAmount(Item item, int amount, bool give = false)
//    {
//        for(int i = 0; i<inventory.Count; i++)
//        {
//            if (inventory[i].ItemId == item.ItemId)
//            {
//                if (inventory[i].AllowMultiple)
//                {
//                    inventory[i].ModifyAmount(give ? -amount : amount); // give 가 참이면 amount 만큼 빼고, 거짓이면 더한다 

//                    if (inventory[i].Amount <= 0 && give)
//                        inventory.RemoveAt(i);
//                }
//                else
//                {
//                    inventory.RemoveAt(i);
//                }

//                return;
//            }

//        }
//        Item newItem = Extensions.CopyItem(item);
//        newItem.ModifyAmount(amount);

//        AddItem(newItem);


//    }
//}
