using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    /* prefab : 인벤토리 창에 보이는 이미지 */
    public GameObject prefab; // ItemObject 를
    public ItemType type; // 상속받은

    [TextArea(15, 20)]
    public string Description; // 클래스들이 공통적으로 갖고 있는 부분
}
