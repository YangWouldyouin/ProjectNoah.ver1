//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//// Scriptable Object : �ٸ� �������� ����� �� �ְ� �����Ͱ� �ٸ� �������� ������
//// �κ��丮�� ������ �����ͺ��̽��� �ٸ���, �κ��丮�� ��Ÿ�� ���߿� �������� �߰��ϰų� ������ �� �ִµ�,
//// ������ �����ͺ��̽��� �����Ϳ� �ѹ� ����ǰ� ���� �ٲ� �� ����
//// �׷��Ƿ� ������ �����ͺ��̽��� ������ ��� ������ ������ ������ ����
//[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Custom Data/Item Database")]
//public class ItemDatabase : ScriptableObject // ScriptableObject �� ��ӹ���
//{
//    [SerializeField] List<Item> items = new List<Item>();
//    [SerializeField] List<string> itemsNames = new List<string>();

//    public List<string> ItemsNames { get { return itemsNames; } }

//    /* ���ο� �������� ������ �̰��� ������ ����Ʈ�� �����ϴ� �޼��� */
//    public void AddItem(Item item)
//    {
//        items.Add(item); // List<Item> items �� �� �������� item �߰�
//        itemsNames.Add("");
//    }

//    /* �������� ��ȯ�ϴ� �޼��� */
//    public Item GetItem(int id)
//    {
//        //List<Item> items �� �������
//        for (int i = 0; i < items.Count; i++)
//        {
//            // item's id �� �츮�� ã�� �ִ� id �� ������ �� �������� ��ȯ��
//            if (items[i].ItemId == id)
//            {
//                return items[i];

//            }
//        }
//        return null; // �츮�� ã�� �ִ� �������� ������ null ��ȯ
//    }
//}