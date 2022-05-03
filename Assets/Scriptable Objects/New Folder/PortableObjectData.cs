using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PortableObjectData : ScriptableObject
{
    public List<bool> IsObjectActiveList = new List<bool>();

    //IsPipeActive;
    //IsBoxActive;
    //IsCardKeyActive;
}
