using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerEquipment : ScriptableObject
{ 
    [Header("< 밀기 오브젝트 정보 >")]
    public string pushObjectName;
    public Vector3 cancelPushPos, cancelPushRot, cancelPushScale;

    [Header("< 물기 오브젝트 정보 >")]
    public string biteObjectName;
    public Vector3 cancelBitePos, cancelBiteRot, cancelBiteScale;
}
