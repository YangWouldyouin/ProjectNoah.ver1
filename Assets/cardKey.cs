using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardKey : MonoBehaviour
{
    [SerializeField] PortableObject portable;


    // Start is called before the first frame update
    void Start()
    {
        portable.IsBite = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
