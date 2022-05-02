using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerEquipment : ScriptableObject
{ 
    [Header("< �б� ������Ʈ ���� >")]
    public string pushObjectName;
    public Vector3 cancelPushPos, cancelPushRot, cancelPushScale;

    [Header("< ���� ������Ʈ ���� >")]
    public string biteObjectName;
    public Vector3 cancelBitePos, cancelBiteRot, cancelBiteScale;
}
