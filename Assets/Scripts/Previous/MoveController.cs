using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float speed= 2.5f;
    private int turnSpeed = 120;


    // Start is called before the first frame update
    /*
    void Start()
    {
        Invoke("ChangeSpeed", 6f);
        
    }

    void ChangeSpeed()
    {
        speed=0.5f;
        turnSpeed=50;
    }
    */

    /*
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }
    */

    // Update is called once per frame
    void Update()
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, -v)*speed*Time.deltaTime);
        transform.Rotate(0f, turnSpeed*Time.deltaTime*h, 0f);
        
        /*
        if(Input.GetKeyDown("v")){
            transform.position=new Vector3(8.28f,36.58f, -2.226f);

    
        }*/
    

    
        
    }

    
}
