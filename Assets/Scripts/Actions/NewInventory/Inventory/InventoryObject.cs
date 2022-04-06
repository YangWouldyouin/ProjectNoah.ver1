using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        // ���߿� ��ųʸ��� �ٲ� ����
        bool hasItem = false;
        for(int i =0; i<Container.Count; i++) // �����̳� ���� ��� �����۰� ��
        {
            if(Container[i].item == _item) // �����̳ʿ� �ִ� �������̸�
            {
                Container[i].AddAmount(_amount); // ������ �߰�
                hasItem = true;
                break;
            }
        }
        if(!hasItem) // ���� �����̳ʿ� ���� ���ο� �������̸�
        {
            Container.Add(new InventorySlot(_item, _amount)); // Add : ����Ʈ �߰� �Լ�?? 
        }


    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount) /* �� �������� ������ ������ �߰��ϴ� �޼��� */
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value) // ���� �ִ� �������� ������ value ��ŭ �ø��� �޼���
    {
        amount += value;
    }
}
