//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Inventory", menuName = "Custom Data/Inventory Data")]

//public class Inventory : ScriptableObject
//{
//    [SerializeField] ItemDatabase itemDatabase; // ������ �����ͺ��̽��� ������Ʈ�� ������ ���۷���
//    [SerializeField] List<Item> inventory = new List<Item>();

//    /* �κ��丮�� �������� �߰��ϴ� �޼��� */
//    public void AddItem(Item item)
//    {
//        inventory.Add(item); // �κ��丮 ����Ʈ�� item �߰�
//    }

//    // ItemDatabase ��ũ��Ʈ�� itemsNames �� List<string> ���� �������� ���� �ʿ� (objectReferenceValue�� object �θ� �������� )
//    public ItemDatabase ItemDatabase { get { return itemDatabase; } }

//    // �κ��丮�� �����۰� ���� ���������� ID �� ���ϰ� �������� ������ ��ȯ
//    public int CheckAmount(Item item)
//    {
//        for (int i = 0; i < inventory.Count; i++) // List �� Count �� ���� ������
//        {
//            if (inventory[i].ItemId == item.ItemId)
//            {
//                if (inventory[i].AllowMultiple)
//                {
//                    return inventory[i].Amount; // �κ��丮�� i ��° �������� ���� ��ȯ
//                }
//                else
//                {
//                    return 1; // AllowMultiple �� �����̹Ƿ� �� �������� ������ 1���� ����
//                }
//            }
//        }
//        return 0; // �κ��丮�� item �� �����Ƿ� 0 ��ȯ
//    }

//    public void ModifyItemAmount(Item item, int amount, bool give = false)
//    {
//        for(int i = 0; i<inventory.Count; i++)
//        {
//            if (inventory[i].ItemId == item.ItemId)
//            {
//                if (inventory[i].AllowMultiple)
//                {
//                    inventory[i].ModifyAmount(give ? -amount : amount); // give �� ���̸� amount ��ŭ ����, �����̸� ���Ѵ� 

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
