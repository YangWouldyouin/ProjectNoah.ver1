using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rigid;
    public int JumpPower= 5;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

     void Update()
    {

        if(Input.GetKeyDown("u"))
        {
            rigid.AddForce(new Vector3(0, 1, 0)*JumpPower, ForceMode.Impulse);
            
        }
        
    }
}
