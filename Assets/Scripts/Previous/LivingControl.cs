using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingControl : MonoBehaviour
{
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        {
            //transform.position = Vector3.MoveTowards(transform.position, targettttt, 0.1f);
            transform.Translate(Vector3.right*Time.deltaTime*7);
        }
        
    }
}
