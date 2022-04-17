using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractData : MonoBehaviour
{
    public static InteractData interactData { get; private set; }

    private void Awake()
    {
        interactData = this;
    }

    public bool IsBoxUpDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
