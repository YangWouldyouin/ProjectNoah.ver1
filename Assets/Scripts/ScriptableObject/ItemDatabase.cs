//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Scriptable Object : 다른 씬에서도 사용할 수 있고 데이터가 다른 씬에서도 보존됨
//// 인벤토리와 아이템 데이터베이스는 다른데, 인벤토리는 런타임 도중에 아이템을 추가하거나 삭제할 수 있는데,
//// 아이템 데이터베이스는 에디터에 한번 빌드되고 나면 바뀔 수 없음
//// 그러므로 아이템 데이터베이스는 게임의 모든 아이템 정보를 가지고 있음
//[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Custom Data/Item Database")]
//public class ItemDatabase : ScriptableObject // ScriptableObject 를 상속받음
//{
//    [SerializeField] List<Item> items = new List<Item>();
//    [SerializeField] List<string> itemsNames = new List<string>();

//    public List<string> ItemsNames { get { return itemsNames; } }

//    /* 새로운 아이템이 들어오면 이것을 아이템 리스트에 저장하는 메서드 */
//    public void AddItem(Item item)
//    {
//        items.Add(item); // List<Item> items 에 새 아이템인 item 추가
//        itemsNames.Add("");
//    }

//    /* 아이템을 반환하는 메서드 */
//    public Item GetItem(int id)
//    {
//        //List<Item> items 을 보고싶음
//        for (int i = 0; i < items.Count; i++)
//        {
//            // item's id 가 우리가 찾고 있는 id 와 같으면 그 아이템을 반환함
//            if (items[i].ItemId == id)
//            {
//                return items[i];

//            }
//        }
//        return null; // 우리가 찾고 있는 아이템이 없으면 null 반환
//    }
//}