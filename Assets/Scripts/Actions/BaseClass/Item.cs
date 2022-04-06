using UnityEngine;

[System.Serializable] // ���߿� ���� �ν����Ϳ� ������ �� ����

// �������� �����ϱ� ���� ���θ��� Ŀ���� Ŭ����
public class Item 
{
    /* ���� ( �ҹ��� �빮�� ) */
    [SerializeField] int itemId;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemSprite;
    [SerializeField] bool allowMultiple; // �ߺ� �Ĺ� ��������?
    [SerializeField] int amount; // �ߺ� �Ĺ� ����


    /* ���� augument���� ����� serializeField �����鿡�� �����ϴ� ����Ʈ���� */
    public Item(int itemId, string name, string desc, Sprite sprite, bool allowMultiple)
    {
        this.itemId = itemId; // �̸��� ���� �� ���� Ŭ���� �ȿ� �ִ� ������ ����Ű���� this ��� 
        itemName = name;
        itemDescription = desc;
        itemSprite = sprite;
        this.allowMultiple = allowMultiple;
    }

    /* ����� serializeField �������� �ٸ� ��ũ��Ʈ������ ���� �����ϰ�, ������Ƽ ( �빮��, �빮�� ) */
    public int ItemId { get { return itemId;  } } // get : ���� �������� �͸� ����, set : �� ���� ����
    public string ItemName { get { return itemName; } }
    public string ItemDesc { get { return itemDescription; } }
    public Sprite ItemSprite { get { return itemSprite; } }
    public bool AllowMultiple { get { return allowMultiple; } }
    public int Amount { get { return amount; } }


    public void ModifyAmount(int value)
    {
        amount += value;
    }


}

// itemId �� �� �������� ������ �� �ڵ������� �������� ������ itemId �� ���� propertyField�� ������ ���� ���� 
