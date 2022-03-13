using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // ���콺�� UI ���� �ִ��� üũ�ϱ� ���� �ʿ�

// ���� Ŭ���� : ���� ������ �޼��常 ���� �� ����
// Ŭ�����κ��� ��ü�� �������� �ʰ� ������ �Լ��� ȣ���� �� ����
public static class Extensions
{
    /* ���콺�� ���� UI ���� ������ true�� ��ȯ�ϴ� �޼��� */
    public static bool IsMouseOverUI()
    { // (UI �� Ŭ���� ���� �´��� üũ�ϱ� ����), ��ȭâ UI �� Ŭ���ϸ� ��ȭ�� �Ѿ���� �÷��̾�� ��ȭâ������ �������� �ʰ� �ϱ�
        return EventSystem.current.IsPointerOverGameObject();
    }
    

    /* �������� �����ϴ� �޼��� */
    public static Item CopyItem(Item item) 
    {// get set ����
        // Item Ŭ������ �������� �������� ���� ������ get���� �߱� ������ ���� �ٲ� �� ��� ��ȣ��
        Item newItem = new Item(item.ItemId, item.ItemName, item.ItemDesc, item.ItemSprite, item.AllowMultiple);
        return newItem;
    }

    public static void RunActions(Actions[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act();
        }
    }
}
