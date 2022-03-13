using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ppotato : MonoBehaviour
{
    public GameObject object11;
    public GameObject object22;
    public GameObject object33;
   

    void Update()
    {
        //tempTrans=object22.transform.parent;
        if(Input.GetKeyDown("l"))
        {
            
            //transform.position=new Vector3(18, 35, 3);
            object11.transform.parent = object22.transform;

        }   
        

        if(Input.GetKeyDown("k"))
        {
            //transform.position=new Vector3(18, 35, 3);
            object11.transform.parent = object33.transform;


        }
    
        
    }
}
