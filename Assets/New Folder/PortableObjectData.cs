using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PortableObjectData : ScriptableObject
{
    public bool IsCenterButtonDisabled = false; // true면 첫 번째 가운데 버튼 비활성화
    public bool IsCenterPlusButtonDisabled = false; // true면 두 번째 가운데 버튼 비활성화

    public bool IsNotInteractable = false;

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
