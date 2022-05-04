using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ObjectData :ScriptableObject
{
    [Header("< 상호작용 시 바뀌는 데이터 목록 (평소에 건드리지 x) >")]
    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsSmash = false;
    public bool IsUpDown = false;
    public bool IsEaten = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsObservePlus = false;
    public bool IsCenterButtonChanged = false;
    public bool IsCollision = false; // 책상 올라가려고 추가한 것이다. UpUP, M_C2_FindEnginespaceKey 코드 참고
    public bool IsClicked = false;
}
