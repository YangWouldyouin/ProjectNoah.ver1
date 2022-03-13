using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanControl : MonoBehaviour
{
    public Transform canView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
         if(Input.GetKeyDown("c"))
         {
             transform.position = Vector3.Lerp(transform.position, canView.position, Time.deltaTime*100);
         }
    }
}
