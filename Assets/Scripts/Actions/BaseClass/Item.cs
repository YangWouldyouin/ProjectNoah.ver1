using UnityEngine;

[System.Serializable] // 나중에 값을 인스펙터에 보여줄 수 있음

// 아이템을 정의하기 위해 새로만든 커스텀 클래스
public class Item 
{
    /* 변수 ( 소문자 대문자 ) */
    [SerializeField] int itemId;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] Sprite itemSprite;
    [SerializeField] bool allowMultiple; // 중복 파밍 가능한지?
    [SerializeField] int amount; // 중복 파밍 개수


    /* 받은 augument들을 상단의 serializeField 변수들에게 대입하는 컨스트럭터 */
    public Item(int itemId, string name, string desc, Sprite sprite, bool allowMultiple)
    {
        this.itemId = itemId; // 이름이 같을 때 현재 클래스 안에 있는 변수를 가리키려면 this 사용 
        itemName = name;
        itemDescription = desc;
        itemSprite = sprite;
        this.allowMultiple = allowMultiple;
    }

    /* 상단의 serializeField 변수들을 다른 스크립트에서도 접근 가능하게, 프로퍼티 ( 대문자, 대문자 ) */
    public int ItemId { get { return itemId;  } } // get : 값을 가져오는 것만 가능, set : 값 수정 가능
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

// itemId 는 새 아이템을 생성할 때 자동적으로 정해지기 때문에 itemId 을 위한 propertyField를 만들지 않을 것임 
